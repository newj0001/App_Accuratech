using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RESTWebservice.Controllers
{

    public class ProductsController : ApiController
    {
        List<ProductModel> products = new List<ProductModel>();

        public ProductsController()
        {
            products.Add(new ProductModel { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 });
            products.Add(new ProductModel { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M });
            products.Add(new ProductModel { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M });
        }

        [HttpGet]
        public List<ProductModel> GetAllProducts()
        {
            return products;
        }

        [HttpGet]
        public ProductModel GetProduct(int id)
        {
            return products.Where(x => x.Id == id).FirstOrDefault();
        }

        [HttpPost]
        public void Post(ProductModel prod)
        {
            products.Add(prod);
        }

        //[HttpPut]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //[HttpDelete]
        //public void Delete(int id)
        //{
        //}
    }
}
