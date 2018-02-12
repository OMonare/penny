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
        public async Task<bool> login(string username, string password)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                var user = (await (ConnectionManager.MobileService.GetTable<User>().Where(u => u.Username == username)).ToListAsync()).FirstOrDefault();

                if (user.Username == username && user.Password == password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }    

        }

        public async Task<bool> register(string name, string contactNo, )
        {

        }
    }
}
