﻿using FinFriend.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FinFriend.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active
            await Shell.Current.GoToAsync($"//{nameof(StocksPage)}");
        }
    }
}
