using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using FinFriend.ViewModels;
using Models.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinFriend.Views
{
    public partial class StocksPage : ContentPage
    {
        public StocksPage()
        {
            InitializeComponent();
            BindingContext = new StocksViewModel();
            Shell.SetNavBarIsVisible(this, false);
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            var selectedCompanies = (BindingContext as StocksViewModel).GetSelectedCountries();
            Navigation.PushAsync(new StocksComparisonPage(selectedCompanies));
        }

        void CompaniesListView_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            if (((ListView)sender).SelectedItem is CompanyCellViewModel company)
            {
                (BindingContext as StocksViewModel).CompanySelected(company.Company.CompanyName);
            }

            ((ListView)sender).SelectedItem = null;
        }
    }
}