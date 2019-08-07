using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CallWebApiConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Get();
            Console.ReadLine();
        }

        static void Get()
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

                    foreach (var m in menus)
                    {
                        Console.WriteLine(m.Title);
                        Console.WriteLine(m.Description);
                    }
                }
            }
        }

        //static void Post()
        //{
        //    var product = new ProductModel() { Name = "Cola" };

        //    var client = new HttpClient();

        //    var postTask = client.PostAsJsonAsync<ProductModel>("product", product);
        //    postTask.Wait();

        //    var result = postTask.Result;

        //    if (result.IsSuccessStatusCode)
        //    {
        //        var readTask = result.Content.ReadAsAsync<ProductModel>();
        //        readTask.Wait();

        //        var insertedProduct = readTask.Result;

        //        Console.WriteLine("Product {0} inserted with id: {1}", insertedProduct.Name, insertedProduct.Id);
        //    }
        //    else
        //    {
        //        Console.WriteLine(result.StatusCode);////
        //    }
        //}
    }
}

