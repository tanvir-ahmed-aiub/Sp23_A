using IntroAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IntroAPI.Controllers
{
    public class ProductController : ApiController
    {
        [Route("api/dotnet/test")]
        [HttpGet]
        public List<Product> Products() { 
            List<Product> products = new List<Product>();   
            for(int i = 1; i <= 10; i++)
            {
                products.Add(new Product()
                {
                    Id = i,
                    Name = "P-" + i
                }) ;
            }
            return products;
        }
        [Route("api/products/name")]
        [HttpGet]   
        public List<string> ProductNames() {
            List<Product> products = new List<Product>();
            for (int i = 1; i <= 10; i++)
            {
                products.Add(new Product()
                {
                    Id = i,
                    Name = "P-" + i
                });
            }

            var names = (from p in products
                        select p.Name).ToList();
            return names;
        }
        [Route("api/product/create")]
        [HttpPost]
        public string CreateProduct(Product p)
        {
            //db insert 
            return "OK";
        }
    }
   
}
