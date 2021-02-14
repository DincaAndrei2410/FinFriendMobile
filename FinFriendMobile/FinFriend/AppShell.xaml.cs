using System;
using System.Collections.Generic;
using FinFriend.ViewModels;
using FinFriend.Views;
using Xamarin.Forms;

namespace FinFriend
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            SetNavBarIsVisible(this, false);
            Routing.RegisterRoute(nameof(RealEstatePage), typeof(RealEstatePage));
            Routing.RegisterRoute(nameof(StocksPage), typeof(StocksPage));
            Routing.RegisterRoute(nameof(WalletPage), typeof(WalletPage));
        }

    }
}
