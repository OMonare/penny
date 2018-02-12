using System;
using System.Collections.Generic;
using System.Text;

namespace Penny.Models
{
    public class Condition
    {
        // Returns a list of all the conditions that an Item can have
        // statically defined rn, but suject to change if we have time
        public static IList<string> GetConditions()
        {
            return new string[] { "Brand New", "Used - Refurbished", "Used - Good Condition", "Used - Decent Condition", "Used - Needs Refurbishing" };
        }
    }
}
