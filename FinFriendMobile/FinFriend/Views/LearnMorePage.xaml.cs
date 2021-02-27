using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FinFriend.Views
{
    public partial class LearnMorePage : ContentPage
    {
        public LearnMorePage()
        {
            InitializeComponent();
            webView.Source = "http://178.62.226.22:3005/learning";
            Shell.SetNavBarIsVisible(this, false);
        }
    }
}
