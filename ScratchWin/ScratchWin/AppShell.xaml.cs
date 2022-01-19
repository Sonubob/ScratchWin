using System;
using System.Collections.Generic;
using ScratchWin.ViewModels;
using ScratchWin.Views;
using Xamarin.Forms;

namespace ScratchWin
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
        
        }

    }
}
