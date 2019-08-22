using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Processor
    {
        public static string url = "http://172.30.1.103:44333/api/menus";
        public static string url1 = "http://172.30.1.103:44333/api/subitem";
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

        public static async Task<List<SubItemEntity>> LoadSubItems()
        {
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<List<SubItemEntity>>();
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
            HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(url1, subItem);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }

        public static async Task<HttpStatusCode> DeleteSubItem(SubItemEntity subItemEntity)
        {
            HttpResponseMessage response = await ApiHelper.ApiClient.DeleteAsync(url + "/{id}");
            return response.StatusCode;
        }
    }
}
