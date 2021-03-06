﻿using Microsoft.WindowsAzure.MobileServices;
using Penny.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Penny.Repositories
{
    public class ItemRepo
    {
        MobileServiceClient connection = ConnectionManager.MobileService;

        // Returns a list of all the items that have not been sold
        public async Task<IList<Item>> GetItemsAsync()
        {
            var result = await connection.GetTable<Item>()
                .Where(i => i.Available == true)
                .ToListAsync();

            return result;
        }

        //Returns a list of all items posted by the current logged in user
        public static async Task<IList<Item>> GetCurrentUsersItemsAsync(string currentUserId)
        {
            var result = await ConnectionManager.MobileService.GetTable<Item>()
                .Where(i => i.SellerId == currentUserId)
                .ToListAsync();

            return result;
        }

        //Returns a list of all items that are available near the user
        public static async Task<IList<Item>> GetLocalItemsAsync(string city)
        {
            var result = await ConnectionManager.MobileService.GetTable<Item>()
                .Where(i=>i.City==city)
                .ToListAsync();

            return result;
        }

        public static async Task<bool> AddItem(string name, string category, double price, string city, string sellerId, string condition, string description, string image)
        {
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(category) && !string.IsNullOrEmpty(city) && !string.IsNullOrEmpty(condition) && !string.IsNullOrEmpty(description) && !string.IsNullOrEmpty(image))
            {
                Item item = new Item()
                {
                   
                    Name = name,
                    Category = category,
                    Price = price,
                    City = city,
                    SellerId = sellerId,
                    Condition =condition,
                    Description = description,
                    Image = image,
                    Available = true

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


        // Returns a list of every item that matches what ever condition that the user has specified on the front end
        // If left blank, the values take defaults, which means it will not apply a filter to that specific field
        public async Task<IList<Item>> SearchItemAsync(IList<string> city, IList<string> condition, string itemName = "", double minPrice = 0, double maxPrice = Double.MaxValue)
        {
            if(city.Count == 0)
            {
                city = City.GetConditions();
            }

            if( condition.Count == 0)
            {
                condition = Condition.GetConditions();
            }

            var result = await connection.GetTable<Item>()
                .Where(i => city.Contains(i.City) 
                && condition.Contains(i.Condition)
                && i.Price >= minPrice
                && i.Price <= maxPrice)
                .ToListAsync();

            return result;
        }

        
    }
}
