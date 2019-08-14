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
        public static async Task<List<SubItemEntity>> LoadSubMenus()
        {
            //string url = "http://172.30.1.110:44333/api/menus";
            //string url = "http://localhost:44333/api/menus";

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

    }
}
