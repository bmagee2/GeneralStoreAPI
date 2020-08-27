using GeneralStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GeneralStoreAPI.Controllers
{
    public class CustomerController : ApiController
    {
        private StoreDbContext _context = new StoreDbContext();

        // POST
        public IHttpActionResult Post(Customer customer)
        {
            // if an empty customer is passed in
            if (customer == null)
            {
                return BadRequest("request body can't be empty");
            }
            // if ModelState is not valid
            if (ModelState.IsValid)
            {
                _context.Customers.Add(customer);   // add customer to dbset
                _context.SaveChanges();     // save changes
                return Ok();    // return 200 ok message in postman
            }
            return BadRequest(ModelState);
        }

        // GET
        public IHttpActionResult GetAll()
        {
            List<Customer> customers = _context.Customers.ToList();
            if (customers.Count != 0)
            {
                 return Ok(customers);
            }
            return BadRequest("no customers in db");
        }

        // GET {ID}
        public IHttpActionResult GetById(int id)
        {
            Customer customer = _context.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        // PUT {ID}

        // DELETE {ID} 
    }
}
