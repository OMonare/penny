using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Penny.Models;

namespace Penny.Repositories
{
    public class UserRepo
    {
        public async Task<User> login(string username, string password)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                try
                {
                    var user = (await (ConnectionManager.MobileService.GetTable<User>().Where(u => u.Username == username)).ToListAsync()).FirstOrDefault();

                    if (user.Username == username && user.Password == password)
                    {
                        return user;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
                
            }
            else
            {
                return null;
            }

        }

        public async Task<User> register(string name, string contactNo, string city, string password, string username, string email)
        {

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(contactNo) && !string.IsNullOrEmpty(city) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(email))
            {
                User user = new User()
                {
                    Id = new Guid(),
                    Name = name,
                    Username = username,
                    ContactNumber = contactNo,
                    SellerRating = 3,
                    City = city,
                    Password = password,
                    Email = email

                };

                try
                {
                    await ConnectionManager.Insert<User>(user);
                    return user;
                }
                catch (Exception ex)
                {
                    return null;
                }

            } else
            {
                return null;
            }
           
            
        }

        public async Task<User> getUserDetails(string username)
        {
            try
            {
                var user = (await (ConnectionManager.MobileService.GetTable<User>().Where(u => u.Username == username)).ToListAsync()).FirstOrDefault();

                return user;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
