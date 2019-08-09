using Common_Backend.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace REST
{
    public class DefaultController : ApiController
    {
        //Creating Instance of DatabaseContext class  
        private DatabaseContext db = new DatabaseContext();

        //Creating a method to return Json data   
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                //Prepare data to be returned using Linq as follows  
                var result = from country in db.Countries
                             select new
                             {
                                 country.CountryId,
                                 country.Name,
                                 State = from state in db.States
                                         where state.CountryId == country.CountryId
                                         select new
                                         {
                                             state.StateId,
                                             state.Name,
                                             City = from city in db.Cities
                                                    where city.StateId == state.StateId
                                                    select new
                                                    {
                                                        city.CityId,
                                                        city.Name
                                                    }
                                         }
                             };
                return Ok(result);
            }
            catch (Exception)
            {
                //If any exception occurs Internal Server Error i.e. Status Code 500 will be returned  
                return InternalServerError();
            }
        }
    }
}
