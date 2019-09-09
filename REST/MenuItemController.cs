
using Common;
using Common_Backend.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace REST
{
    public class MenuItemController : ApiController
    {
        private readonly DatabaseContext _dbContext = new DatabaseContext();
        public IEnumerable<MenuItemEntityModel> GetAllMenus()
        {
            using (var dbContext = new DatabaseContext())
            {
                var listEntities = dbContext.Menus.Include(m => m.SubItems).Include(m => m.Registrations).Include(m => m.Registrations.Select(r => r.RegistrationValues)).ToList();
                return listEntities;
            }
        }

        [System.Web.Http.HttpPost]
        public HttpResponseMessage CreateMenuItem([FromBody] MenuItemEntityModel menuItem)
        {
            try
            {
                using (var dbContext = new DatabaseContext())
                {
                    dbContext.Menus.Add(menuItem);
                    dbContext.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, menuItem);
                    message.Headers.Location = new Uri(Request.RequestUri + menuItem.Id.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        private bool MenuItemExists(int id)
        {
            return _dbContext.Menus.Count(m => m.Id == id) > 0;
        }

        [System.Web.Http.HttpPut]
        public IHttpActionResult Put(int id, MenuItemEntityModel menuItemEntityModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != menuItemEntityModel.Id)
            {
                return BadRequest();
            }

            _dbContext.Entry(menuItemEntityModel).State = EntityState.Modified;

            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
        //public HttpResponseMessage Put(int id, [FromBody] MenuItemEntityModel menuItemEntityModel)
        //{
        //    var menuItemDetail = (from a in _dbContext.Menus where a.Id == id select a).FirstOrDefault();

        //    if (menuItemDetail != null)
        //    {
        //        menuItemDetail.Header = menuItemEntityModel.Header;

        //        _dbContext.SaveChanges();

        //        return Request.CreateResponse(HttpStatusCode.OK, menuItemDetail);
        //    }
        //    else
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Code or Member Not Found");
        //    }
        //}

      
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (var dbContext = new DatabaseContext())
                {
                    var entity = dbContext.Menus.FirstOrDefault(e => e.Id == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Menu with Id = " + id.ToString() + " not found to delete");
                    }
                    else
                    {
                        dbContext.Menus.Remove(entity);
                        dbContext.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
            
        }
    }
}
