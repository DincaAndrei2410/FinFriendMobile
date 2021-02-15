using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using FinFriend.Models;
using FinFriend.Views;
using FinFriend.ViewModels;

namespace FinFriend.Views
{
    public partial class RealEstatePage : ContentPage
    {
        RealEstateViewModel _viewModel;

        public RealEstatePage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new RealEstateViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //_viewModel.OnAppearing();
        }
    }
}