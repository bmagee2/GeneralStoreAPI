using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GeneralStoreAPI.Models
{
    public class Product
    {
        [Key] 
        public string SKU { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Cost { get; set; }
        [Required]
        public int NumberInInventory { get; set; }
        public bool IsInStock 
        {
            get
            {
                if (NumberInInventory > 0)
                {
                    return true;
                }
                return false;
            }
        }

//        private string GenerateSku(string productName)
//        {
//            // Initialize a Random object so we can randomly assign this a number
//            Random random = new Random();
//​
//	        // Get a Random number and turn it into a string
//	        var randItemNum = random.Next(0, 1000).ToString();
//​
//	        // Construct a 3 character string based on the above number. If the number is less than 3 digits, add 0's in front              of it to make it 3 digits
//	        var itemId = new string('0', 3 - randItemNum.Length) + randItemNum;
//        ​
//	        // Create the entire SKU and return it
//	        return $"EFA-{productName.Substring(0, 3)}-{itemId}";

//        }
    }
}