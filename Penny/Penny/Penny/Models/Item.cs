using System;
using System.Collections.Generic;
using System.Text;

namespace Penny.Models
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public string City { get; set; }
        public Guid SellerId { get; set; }
        public string Condition { get; set; }
        public string Description { get; set; }

        public string image { get; set; }
    }
}
