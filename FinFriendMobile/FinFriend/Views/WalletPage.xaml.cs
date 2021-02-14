using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinFriend.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinFriend.Views
{
    public partial class WalletPage : ContentPage
    {
        public WalletPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }
    }
}