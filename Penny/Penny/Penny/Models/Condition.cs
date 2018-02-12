using System;
using System.Collections.Generic;
using System.Text;

namespace Penny.Models
{
    public class Condition
    {

        public static IList<string> GetCondition()
        {
            return new string[] { "Brand New", "Used - Refurbished", "Used - Good Condition", "Used - Decent Condition", "Used - Needs Refurbishing" };
        }
    }
}
