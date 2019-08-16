using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp
{
    class Program
    {
        public static string url = "http://172.30.1.110:44333/api/menus";
        public static HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
            client.BaseAddress = new Uri("http://localhost:44333/");

            ListAllSubMenus();
            ListAllMenus();
            RunAsync().GetAwaiter().GetResult();

            Console.WriteLine("Press Enter to quit.");
            Console.ReadLine();
        }

        static async Task RunAsync()
        {
            try
            {
                MenuItemEntity m = new MenuItemEntity
                {
                    Id = 5,
                    Header = "test",
                };

                var url = await CreateMenu(m);
                Console.WriteLine($"Created at {url}");
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        public static async Task<Uri> CreateMenu(MenuItemEntity menu)
        {
            HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(url, menu);
            response.EnsureSuccessStatusCode();
            var menulist = await ApiHelper.ApiClient.PostAsJsonAsync(url, menu);
            return response.Headers.Location;
        }

        static void ListAllSubMenus()
        {
            HttpResponseMessage resp = client.GetAsync("api/menus").Result;
            resp.EnsureSuccessStatusCode();

            var submenus = resp.Content.ReadAsAsync<IEnumerable<SubItemEntity>>().Result;
            foreach (var s in submenus)
            {
                Console.WriteLine("{0}", s.Name );
            }
        }

        static void ListAllMenus()
        {
            HttpResponseMessage resp = client.GetAsync("api/menus").Result;
            resp.EnsureSuccessStatusCode();

            var menus = resp.Content.ReadAsAsync<IEnumerable<MenuItemEntity>>().Result;
            foreach (var m in menus)
            {
                Console.WriteLine("{0} {1}", m.Header, m.SubItems.Count());
            }
        }

        //static void ListAllProducts()
        //{
        //    HttpResponseMessage resp = client.GetAsync("api/products").Result;
        //    resp.EnsureSuccessStatusCode();

        //    var products = resp.Content.ReadAsAsync<IEnumerable<Product>>().Result;
        //    foreach (var p in products)
        //    {
        //        Console.WriteLine("{0} {1} {2} ({3})", p.Id, p.Name, p.Price, p.Category);
        //    }
        //}

        //static void ListProduct(int id)
        //{
        //    var resp = client.GetAsync(string.Format("api/products/{0}", id)).Result;
        //    resp.EnsureSuccessStatusCode();

        //    var product = resp.Content.ReadAsAsync<Product>().Result;
        //    Console.WriteLine("ID {0}: {1}", id, product.Name);
        //}

        //static void ListProducts(string category)
        //{
        //    Console.WriteLine("Products in '{0}':", category);

        //    string query = string.Format("api/products?category={0}", category);

        //    var resp = client.GetAsync(query).Result;
        //    resp.EnsureSuccessStatusCode();

        //    var products = resp.Content.ReadAsAsync<IEnumerable<Product>>().Result;
        //    foreach (var product in products)
        //    {
        //        Console.WriteLine(product.Name);
        //    }
        //}
    }
}
