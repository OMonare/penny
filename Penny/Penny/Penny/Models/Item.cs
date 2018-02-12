using System;
using System.Collections.Generic;
using System.Text;

namespace Penny.Models
{
    public class Item
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public string Location { get; set; }
        public string SellerID { get; set; }
        public string Description { get; set; }
        public string Condition { get; set; }
    }
}
