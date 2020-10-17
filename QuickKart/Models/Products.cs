using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuickKart.Models
{
    public class Products
    {
        [Required(ErrorMessage = "CategoryId is mandatory.")]
        [DisplayName("Category Id")]
        public byte? CategoryId { get; set; }

        [Required(ErrorMessage = "Price is mandatory.")]
        [DisplayName("Price")]
        public decimal Price { get; set; }
        
        [Required(ErrorMessage = "ProductId is mandatory.")]
        [DisplayName("Product Id")]
        public string ProductId { get; set; }

        [Required(ErrorMessage = "ProductName is mandatory.")]
        [DisplayName("Product Name")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "QuantityAvailable is mandatory.")]
        [DisplayName("Quantity available")]
        public int QuantityAvailable { get; set; }

       
    }
}
