using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Penny.Repositories
{
    public class ConnectionManager
    {
        public static MobileServiceClient MobileService = new MobileServiceClient("https://pennyapp.azurewebsites.net");

        public static async Task<bool> Insert<T>(T objectToInsert)
        {

            try
            {
                await MobileService.GetTable<T>().InsertAsync(objectToInsert);
                return true;
            }
            catch
            {
                return false;
            }

        }

        
    }
}
