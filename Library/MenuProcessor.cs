using Newtonsoft.Json;
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
        public static async Task<MenuModel> LoadMenu()
        {
            string url = "https://localhost:44333/api/menu";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var jsonstring = await response.Content.ReadAsAsync<string>();
                    MenuModel menu = JsonConvert.DeserializeObject<MenuModel>(jsonstring);
                    return menu;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        public void GetMenu()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44333/api/");

                //HTTP GET
                var responseTask = client.GetAsync("menu");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<MenuModel[]>();
                    readTask.Wait();

                    var menus = readTask.Result;
                    //foreach (var m in menus)
                    //{
                    //    Console.WriteLine(m.Title);
                    //    Console.WriteLine(m.Description);
                    //}
                }
            }
        }
        //public static async Task<MenuModel> LoadMenuInformation()
        //{
        //    string url = "https://api.sunrise-sunset.org/json?lat=41.494804&lng=-75.536852&date=today";

        //    using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
        //    {
        //        if (response.IsSuccessStatusCode)
        //        {
        //            MenuModel menu = await response.Content.ReadAsAsync<MenuModel>();

        //            return menu;
        //        }
        //        else
        //        {
        //            throw new Exception(response.ReasonPhrase);
        //        }
        //    }
        //}
    }
}
