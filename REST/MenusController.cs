
using Common;
using Common_Backend.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                var test = dbContext.Menus.Include<MenuItemEntity>(nameof(MenuItemEntity.SubItems)).ToList();

                return test;
            }
        }
    }
}
