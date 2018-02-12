using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Penny.Models
{
    public class Category
    {
        public static IList<string> GetCategories()
        {
            return new string[] { "Laptops and PC's", "Home Appliances", "Stationary", "Fashion", "Gaming Consoles", "Furniture", "Garden and DIY" };
        }

    }
}
