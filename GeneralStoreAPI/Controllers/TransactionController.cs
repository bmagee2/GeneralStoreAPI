using GeneralStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GeneralStoreAPI.Controllers
{
    public class TransactionController : ApiController
    {
        private StoreDbContext _context = new StoreDbContext();

        // POST
        public IHttpActionResult Post(Transaction transaction)
        {
            // if an empty customer is passed in
            if (transaction == null)
            {
                return BadRequest("request body can't be empty");
            }

            // if ModelState is valid
            if (ModelState.IsValid && transaction.CustomerId != 0 && transaction.ProductSKU != null)
            {
                _context.Transactions.Add(transaction);   // add product to dbset
                _context.SaveChanges();     // save changes
                return Ok();    // return 200 ok message in postman
            }
            return BadRequest(ModelState);
        }

        // GET
        public IHttpActionResult GetAll()
        {
            List<Transaction> transactions = _context.Transactions.ToList();
            if (transactions.Count != 0)
            {
                return Ok(transactions);
            }
            return BadRequest("no transactions in db");
        }

        // GET {ID}
        public IHttpActionResult GetById(int id)
        {
            Transaction transaction = _context.Transactions.Find(id);
            if (transaction == null)
            {
                return NotFound();
            }
            return Ok(transaction);
        }

        // PUT {ID}

        // DELETE {ID} 
    }
}
