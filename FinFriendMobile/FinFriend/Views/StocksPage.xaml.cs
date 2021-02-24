using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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
            BindingContext = new CompaniesComparisonViewModel();
            Shell.SetNavBarIsVisible(this, false);
        }
    }
}