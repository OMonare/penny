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
        
        public async Task<bool> AddItem(string name, string category, double price, string city, Guid sellerId, string condition, string description, string image)
        {
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(category) && !string.IsNullOrEmpty(city) && !string.IsNullOrEmpty(condition) && !string.IsNullOrEmpty(description) && !string.IsNullOrEmpty(image))
            {
                Item item = new Item()
                {
                    Id = new Guid(),
                    Name = name,
                    Category = category,
                    Price = price,
                    City = city,
                    SellerId = sellerId,
                    Condition =condition,
                    Description = description,
                    image = image

                };

                try
                {
                    await ConnectionManager.Insert<Item>(item);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }
    }
}
