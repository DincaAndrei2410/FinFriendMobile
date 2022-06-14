using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using FinFriend.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinFriend.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RealEstateCreditsPage : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public RealEstateCreditsPage()
        {
            InitializeComponent();
            BindingContext = new RealEstateCreditsViewModel();
            Shell.SetNavBarIsVisible(this, true);
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            var url = ((sender as View)?.BindingContext) as string;
            await Browser.OpenAsync(new Uri(url), BrowserLaunchMode.SystemPreferred);
        }
    }
}
