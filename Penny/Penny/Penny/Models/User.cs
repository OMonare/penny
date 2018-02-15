using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Penny.Models
{
    public class User 
    {

        public string  Name { get; set; }
        public string Id { get; set; }
        public string ContactNumber { get; set; }
        public int SellerRating { get; set; }
        public string City { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

 
    }
}
