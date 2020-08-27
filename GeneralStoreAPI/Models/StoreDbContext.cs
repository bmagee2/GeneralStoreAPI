using System;
using System.Collections.Generic;
using System.Data.Entity;   // INSTALL PACKAGE ENTITY FRAMEWORK -- LATEST VERSION
using System.Linq;
using System.Web;

namespace GeneralStoreAPI.Models
{
    public class StoreDbContext : DbContext 
    {
        public StoreDbContext() : base("DefaultConnection") { } // BASE CONSTRUCTOR
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}