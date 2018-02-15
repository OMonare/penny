using System;
using System.Collections.Generic;
using System.Text;

namespace Penny.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public string City { get; set; }
        public string SellerId { get; set; }
        public string Condition { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public bool? Available { get; set; }
        public string BuyerId { get; set; }
        public DateTime? DateSold { get; set; }

    }
}
