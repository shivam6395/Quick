using System;
using System.Collections.Generic;

namespace QuickKartDataAccessLayer.Models
{
    public partial class Rating
    {
        public string EmailId { get; set; }
        public string ProductId { get; set; }
        public byte ReviewRating { get; set; }
        public string ReviewComments { get; set; }

        public Users Email { get; set; }
        public Products Product { get; set; }
    }
}
