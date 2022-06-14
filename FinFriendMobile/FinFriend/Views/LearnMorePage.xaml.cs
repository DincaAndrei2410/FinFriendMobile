using System;
using System.Collections.Generic;
using API;
using Xamarin.Forms;

namespace FinFriend.Views
{
    public partial class LearnMorePage : ContentPage
    {
        public LearnMorePage()
        {
            InitializeComponent();
            webView.Source = $"{ApiClient.ApiBase}learning";
            Shell.SetNavBarIsVisible(this, false);
        }
    }
}
