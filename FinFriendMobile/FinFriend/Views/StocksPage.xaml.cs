using System;
using System.ComponentModel;
using FinFriend.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinFriend.Views
{
    public partial class StocksPage : ContentPage
    {
        public StocksPage()
        {
            InitializeComponent();
            Shell.SetNavBarIsVisible(this, false);
            BindingContext = new CompaniesComparisonViewModel();
        }
    }
}