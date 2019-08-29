using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Common;
using Common_Backend.Context;

namespace REST
{
    public class RegistrationValuesController : ApiController
    {
        public IEnumerable<RegistrationValue> Get()
        {
            using (var dbContext = new DatabaseContext())
            {
                var listEntities = dbContext.RegistrationValues.Include(x => x.SubItemEntity).ToList();
                return listEntities;
            }
        }

        public HttpResponseMessage Post([FromBody] ICollection<RegistrationValue> registrationValues)
        {
            if (registrationValues.Count < 1)
            {
                var message = Request.CreateResponse(HttpStatusCode.BadRequest, registrationValues);
                message.Headers.Location = new Uri(Request.RequestUri.ToString());

                return message;
            }
            try
            {
                using (var dbContext = new DatabaseContext())
                {
                    
                    var menuItemId = registrationValues.ToList()[0].SubItemEntity?.MenuItemId;
                    var registration = new Registration()
                    {
                        MenuItemId = menuItemId == null ? 0 : menuItemId.Value,
                    };

                    dbContext.Registrations.Add(registration);
                    dbContext.SaveChanges();


                    foreach (var value in registrationValues)
                    {
                        value.SubItemEntity = null;
                        value.RegistrationId = registration.Id;
                        dbContext.RegistrationValues.AddOrUpdate(value);
                    }
                    dbContext.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, registrationValues);
                    message.Headers.Location = new Uri(Request.RequestUri + registration.Id.ToString());

                    return message;
                }
            }
            catch (Exception exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, exception);
            }
        }
    }
}
