using Library;
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
        List<MenuModel> menuList = new List<MenuModel>();

        public MenuController()
        {
            menuList.Add(new MenuModel { Id = 1, Title = "Receive", Description = "This is a note" });
            menuList.Add(new MenuModel { Id = 2, Title = "Shipping", Description = "This is a note" });
        }

        // GET: api/Menu
        [HttpGet]
        public List<MenuModel> GetAllMenus()
        {
            return menuList;
        }

        // GET: api/Menu/5
        [HttpGet]
        public MenuModel GetMenu(int id)
        {
            return menuList.Where(x => x.Id == id).FirstOrDefault();
        }

        // POST: api/Menu
        [HttpPost]
        public void SaveMenu(MenuModel menu)
        {
            menuList.Add(menu);
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
