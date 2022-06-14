using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FinFriend.Services;
using FinFriend.Views;
using API;
using Models.Models;
using FinFriend.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace FinFriend
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<DataStore<Company>>();
            DependencyService.Register<DataStore<Neighborhood>>();
            DependencyService.Register<DataStore<RealEstateCredit>>();
            DependencyService.Register<StocksApiService>();
            DependencyService.Register<FinancialApiService>();
            DependencyService.Register<SentimentApiService>();

            MainPage = new LoginPage();
        }

        protected override async void OnStart()
        {
            try
            {
                await Task.WhenAll(
                    DependencyService.Get<DataStore<Company>>().InitializeData(),
                    DependencyService.Get<DataStore<Neighborhood>>().InitializeData(),
                    DependencyService.Get<DataStore<RealEstateCredit>>().InitializeData());

                await DependencyService.Get<DataStore<Company>>().InsertAsync(Data.Companies);
                await DependencyService.Get<DataStore<Neighborhood>>().InsertAsync(Data.Neighborhoods);
                await DependencyService.Get<DataStore<RealEstateCredit>>().InsertAsync(Data.Credits);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
