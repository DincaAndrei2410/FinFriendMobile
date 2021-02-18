using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using FinFriend.ViewModels;
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

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
