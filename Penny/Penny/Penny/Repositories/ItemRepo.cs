using Microsoft.WindowsAzure.MobileServices;
using Penny.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Penny.Repositories
{
    public class ItemRepo
    {
        MobileServiceClient connection = ConnectionManager.MobileService;

        // Returns a list of all the items
        public async Task<IList<Item>> GetItemsAsync()
        {
            var result = await connection.GetTable<Item>()
                .Where(i => i.Available == true)
                .ToListAsync();

            return result;
        }

        public async Task<bool> SoldItemAsync(Item item, User buyer)
        {
            item.Available = false;
            item.BuyerID = buyer.Id;
            item.DateSold = DateTime.Now;

            try
            {
                await connection.GetTable<Item>()
                .UpdateAsync(item);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }
        
    }
}
