using GeneralStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GeneralStoreAPI.Controllers
{
    public class ProductController : ApiController
    {
        private StoreDbContext _context = new StoreDbContext();

        // POST
        public IHttpActionResult Post(Product product)
        {
            // if an empty customer is passed in
            if (product == null)
            {
                return BadRequest("request body can't be empty");
            }

            product.SKU = GenerateSku(product.Name);

            // if ModelState is not valid
            if (ModelState.IsValid && product.SKU != null)
            {
                _context.Products.Add(product);   // add product to dbset
                _context.SaveChanges();     // save changes
                return Ok();    // return 200 ok message in postman
            }
            return BadRequest(ModelState);
        }

        // GET
        public IHttpActionResult GetAll()
        {
            List<Product> products = _context.Products.ToList();
            if (products.Count != 0)
            {
                return Ok(products);
            }
            return BadRequest("no products in db");
        }

        // GET {ID}
        public IHttpActionResult GetById(string sku)
        {
            Product product = _context.Products.Find(sku);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // PUT {ID}

        // DELETE {ID} 


        // METHOD TO GENERATE RANDOM SKU
        private string GenerateSku(string productName)
        {
            Random random = new Random();
            var randItemNum = random.Next(0, 1000).ToString();
            var itemId = new string('0', 3 - randItemNum.Length) + randItemNum;
            return $"EFA-{productName.Substring(0, 3)}-{itemId}";
        }

    }
}
