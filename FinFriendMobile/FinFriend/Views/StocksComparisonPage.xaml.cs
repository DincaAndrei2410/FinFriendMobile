using System;
using System.Collections.Generic;
using FinFriend.ViewModels;
using Models.Models;
using Xamarin.Forms;

namespace FinFriend.Views
{
    public partial class StocksComparisonPage : ContentPage
    {
        public StocksComparisonPage(IEnumerable<Company> companies)
        {
            InitializeComponent();
            BindingContext = new CompaniesComparisonViewModel(companies);
            Shell.SetNavBarIsVisible(this, true);
        }
    }
}
