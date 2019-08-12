using Common;
using Common_Backend.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace REST
{
    public class MenusController : ApiController
    {
        public IEnumerable<MenuItemEntity> GetAllMenus()
        {
            using (var dbContext = new DatabaseContext())
            {
                var test = dbContext.Menus.ToList();

                return test;
            }
        }

        //public MenuItemEntity GetMenuById(int id)
        //{
        //    var menu = menus.FirstOrDefault((m) => m.ID == id);
        //    if (menu == null)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    }
        //    return menu;
        //}
    }
}
