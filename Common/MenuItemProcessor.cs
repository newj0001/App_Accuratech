using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class MenuItemProcessor
    {
        public static string url = "http://172.30.1.110:44333/api/menus";
        public static async Task<List<MenuItemEntity>> LoadMenus()
        {
            //string url = "http://172.30.1.110:44333/api/menus";
            //string url = "http://localhost:44333/api/menus";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<List<MenuItemEntity>>();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<Uri> CreateMenu(MenuItemEntity menuItem)
        {
            HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(url, menuItem);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }

        public static async Task<Uri> CreateSubMenu(SubItemEntity subItem)
        {
            HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(url, subItem);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }
    }
}
