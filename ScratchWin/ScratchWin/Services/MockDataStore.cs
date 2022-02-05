using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScratchWin.Models;
using SQLite;
using Xamarin.Forms;

namespace ScratchWin.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;
        SQLiteConnection dbConnection;
        public MockDataStore()
        {
            dbConnection = DependencyService.Get<IDBInterface>().CreateConnection();
            //items = new List<Item>()
            //{
            //    new Item { Id = "7F4ED1B8-B472-4744-BB9D-A4CC680AA144", Text = "Day 1", Description="bracelet.jpg", Name = "BRACELET!!", DateOpened = DateTime.Today.AddDays(-1), IsOpened = false },
            //    new Item { Id = "C2FF9F71-B284-45C6-BD55-B412EECC4858", Text = "Day 3", Description="buddha.jpg", Name = "Figurine!!",DateOpened = DateTime.Today.AddDays(-1), IsOpened = false   },
            //    new Item { Id = "79C09B2A-1203-4F7B-82C2-65101E8C1202", Text = "Day 5", Description="earrings.jpg", Name = "Earrings!!",DateOpened = DateTime.Today.AddDays(-1), IsOpened = false    },
            //    new Item { Id = "1B500804-BEBF-42A9-8D77-029497F8A37F", Text = "Day 4", Description="rings.jpg", Name = "RING!!" ,DateOpened = DateTime.Today.AddDays(-1) , IsOpened = false   },
            //    new Item { Id = "732E445F-1276-456C-9D2A-4FBE5790E6F5", Text = "Day 2", Description="hairstuff.jpg", Name = "Hair Accessories!!",DateOpened = DateTime.Today.AddDays(-1) , IsOpened = false    },


            //};
             items = dbConnection.Query<Item>("Select * From [TblBdayGift]");

        }

        public async Task<bool> AddItemAsync(Item item)
        {
           
            dbConnection.Insert(item);
            
           // items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var isopen = item.IsOpened ? "1" : "0";
            //dbConnection.Update(item);
            dbConnection.Execute("update [TblBdayGift] set DateOpened =?,IsOpened = ? where Id = ?  " , item.DateOpened.ToString(), isopen,
               item.Id.ToString());
            
            // var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            // items.Remove(oldItem);
            // items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id.ToString() == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            //var result = dbConnection.Query<Item>("Select * From [TblBdayGift] where id = {0}",id);
            return await Task.FromResult(items.FirstOrDefault(s => s.Id.ToString() == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
           // var result = dbConnection.Query<Item>("Select * From [TblBdayGift]");
            return await Task.FromResult(items);
        }
    }
}