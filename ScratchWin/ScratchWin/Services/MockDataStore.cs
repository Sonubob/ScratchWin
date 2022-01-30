using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScratchWin.Models;

namespace ScratchWin.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Day 1", Description="bracelet.jpg", Name = "BRACELET!!", DateOpened = DateTime.Today.AddDays(-1), IsOpened = false },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Day 2", Description="buddha.jpg", Name = "Figurine!!",DateOpened = DateTime.Today.AddDays(-1), IsOpened = false   },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Day 3", Description="earrings.jpg", Name = "Earrings!!",DateOpened = DateTime.Today.AddDays(-1), IsOpened = false    },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Day 4", Description="rings.jpg", Name = "RING!!" ,DateOpened = DateTime.Today.AddDays(-1) , IsOpened = false   },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Day 5", Description="hairstuff.jpg", Name = "Hair Accessories!!",DateOpened = DateTime.Today.AddDays(-1) , IsOpened = false    },
            
               
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}