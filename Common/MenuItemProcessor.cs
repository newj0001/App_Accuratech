using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class MenuItemProcessor
    {
        public HttpClient client = new HttpClient();

        public MenuItemProcessor()
        {
            ListAllMenus();
        }

        public void ListAllMenus()
        {
            HttpResponseMessage resp = client.GetAsync("api/menus").Result;
            resp.EnsureSuccessStatusCode();

            var menus = resp.Content.ReadAsAsync<IEnumerable<MenuItemEntity>>().Result;
        }
    }
}
