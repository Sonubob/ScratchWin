using System;
using System.Diagnostics;
using System.Threading.Tasks;
using ScratchWin.Models;
using SQLite;
using Xamarin.Forms;

namespace ScratchWin.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string itemId;
        private string text;
        private string description;
        public string name;
        public Guid id;
        private bool isOpened;
        private DateTime dateOpened;

        public Guid Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
        public bool IsOpened
        {
            get => isOpened;
            set => SetProperty(ref isOpened, value);
        }
        public DateTime DateOpened
        {
            get => dateOpened;
            set => SetProperty(ref dateOpened, value);
        }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Text = item.Text;
                Description = item.Description;
                Name = item.Name;
              
                item.IsOpened = true;
                item.DateOpened = DateTime.Today;
                IsOpened = item.IsOpened;
                DateOpened = item.DateOpened;
              await DataStore.UpdateItemAsync(item);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to Load Item"+ex.InnerException.Message);
            }
        }
    }
}
