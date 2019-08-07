using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class MenuProcessor
    {
        public static async Task<MenuModel> LoadMenuInformation()
        {
            string url = "https://api.sunrise-sunset.org/json?lat=41.494804&lng=-75.536852&date=today";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    MenuModel menu = await response.Content.ReadAsAsync<MenuModel>();

                    return menu;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
