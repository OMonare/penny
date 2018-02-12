using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Penny.Models
{
    public class Category
    {
        // Returns a list of all different product categories that an item can have
        // Statically defined rn, but suject to change if we have time
        public static IList<string> GetCategories()
        {
            return new string[] { "Laptops and PC's", "Home Appliances", "Stationary", "Fashion", "Gaming Consoles", "Furniture", "Garden and DIY", "Miscellaneous Electronics" };
        }
    }
}
