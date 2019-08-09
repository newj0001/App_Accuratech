using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp
{
    class Program
    {
        public static HttpClient client = new HttpClient();
        static void Main(string[] args)
        {



        }
        public static void ListAll()
        {
            HttpResponseMessage resp = client.GetAsync("api/default").Result;
            resp.EnsureSuccessStatusCode();
        }
    }
}
