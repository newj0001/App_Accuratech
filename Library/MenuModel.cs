using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class MenuModel
    {
        static HttpClient client = new HttpClient();
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public static async Task RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("https://localhost:44333/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<MenuModel> GetProductAsync(string path)
        {
            MenuModel menu = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                menu = await response.Content.ReadAsAsync<MenuModel>();
            }
            return menu;
        }
    }
}
