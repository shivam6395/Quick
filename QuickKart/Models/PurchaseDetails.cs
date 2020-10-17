using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuickKart.Models
{
    public class PurchaseDetails
    {
        [DisplayName("Purchase Id")]
        public long PurchaseId { get; set; }
        [DisplayName("Email Id")]
        public string EmailId { get; set; }
        [DisplayName("Product Id")]
        public string ProductId { get; set; }
        [DisplayName("Quantity purchased")]
        [Required(ErrorMessage = "Quantity purchased is required")]
        [Range(1, 100, ErrorMessage = "Quantity purchased must be greater than 0 and less than 100")]
        public short QuantityPurchased { get; set; }
        [DisplayName("Date of purchase")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yy hh:mm tt}")]
        public System.DateTime DateOfPurchase { get; set; }
    }

}
