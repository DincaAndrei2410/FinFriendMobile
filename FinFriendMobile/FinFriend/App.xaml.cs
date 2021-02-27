using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FinFriend.Services;
using FinFriend.Views;
using API;

namespace FinFriend
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<NeighborhoodDataStore>();
            DependencyService.Register<RealEstateCreditDataStore>();
            DependencyService.Register<StocksApiService>();
            DependencyService.Register<CompaniesDataStore>();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
