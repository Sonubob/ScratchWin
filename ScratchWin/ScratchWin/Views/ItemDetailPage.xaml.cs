using System.ComponentModel;
using Xamarin.Forms;
using ScratchWin.ViewModels;

namespace ScratchWin.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}