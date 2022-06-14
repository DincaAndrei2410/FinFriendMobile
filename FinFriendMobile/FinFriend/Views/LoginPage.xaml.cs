using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FinFriend.Views
{	
	public partial class LoginPage : ContentPage
	{	
		public LoginPage ()
		{
			InitializeComponent ();
		}

        async void ButtonOnClicked(object sender, EventArgs e)
        {
			Application.Current.MainPage = new AppShell();
			await Shell.Current.GoToAsync("//main");
        }
    }
}

