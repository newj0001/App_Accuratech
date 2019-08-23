using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Common;
using Common_Backend.Context;

namespace REST
{
    public class RegistrationController : ApiController
    {
        public IEnumerable<Registration> Get()
        {
            using (var dbContext = new DatabaseContext())
            {
                var listEntities = dbContext.Registrations.Include(x => x.RegistrationValues).ToList();
                return listEntities;
            }
        }

        public HttpResponseMessage Post([FromBody] Registration registration)
        {
            try
            {
                using (var dbContext = new DatabaseContext())
                {
                    dbContext.Registrations.Add(registration);
                    dbContext.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, registration);
                    message.Headers.Location = new Uri(Request.RequestUri + registration.Id.ToString());

                    return message;
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
