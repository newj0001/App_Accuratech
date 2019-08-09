using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RESTWebservice.Controllers
{
    public class MenuController : ApiController
    {
        List<MenuItemEntity> menuList = new List<MenuItemEntity>();

        public MenuController()
        {
            //menuList.Add(new MenuModel { Id = 1, Title = "Receive", Field = "Order.no" });
            //menuList.Add(new MenuModel { Id = 2, Title = "Shipping", Field = "This is a note" });
        }

        // GET: api/Menu
        [HttpGet]
        public IEnumerable<MenuItemEntity> GetAllMenus()
        {
            using (MenuDetailsEntities entities = new MenuDetailsEntities())
            {
                return entities.MenuTable.ToList();
            }
        }

        // GET: api/Menu/5
        [HttpGet]
        public MenuItemEntity GetMenu(int id)
        {
            return menuList.Where(x => x.ID == id).FirstOrDefault();
        }

        // POST: api/Menu
        [HttpPost]
        public void SaveMenu(MenuItemEntity val)
        {
            menuList.Add(val);
        }

        //// PUT: api/Menu/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Menu/5
        //public void Delete(int id)
        //{
        //}
    }
}
