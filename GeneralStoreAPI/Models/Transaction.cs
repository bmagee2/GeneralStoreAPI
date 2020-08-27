using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GeneralStoreAPI.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Customer")]    // tells CustomerId property is connected to Customer property
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [Required]
        [ForeignKey("Product")]
        public int ProductSKU { get; set; }
        public virtual Product Product { get; set; }

        [Required]
        public int ItemCount { get; set; }

        [Required]
        public DateTime DateOfTransaction { get; set; }
    }
}