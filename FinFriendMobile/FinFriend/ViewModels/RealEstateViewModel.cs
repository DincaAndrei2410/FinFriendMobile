using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using FinFriend.Models;
using FinFriend.Views;

namespace FinFriend.ViewModels
{
    public class RealEstateViewModel : BaseViewModel
    {
        private const int PriceStepValue = 1000;
        private const double MinAdvancePercentage = 0.15;
        private const double MaxAdvancePercentage = 0.85;

        double _priceMinValue;
        public double PriceMinValue
        {
            get => _priceMinValue;
            set => SetProperty(ref _priceMinValue, value);
        }

        double _priceMaxValue;
        public double PriceMaxValue
        {
            get => _priceMaxValue;
            set => SetProperty(ref _priceMaxValue, value);
        }

        int _selectedPrice;
        public int SelectedPrice
        {
            get => _selectedPrice;
            set
            {
                var newStep = Math.Round((double)value / PriceStepValue);
                value = (int)newStep * PriceStepValue;
                SetProperty(ref _selectedPrice, value);
            }
        }

        double _advanceMinPercentage;
        public double AdvanceMinPercentage
        {
            get => _advanceMinPercentage;
            set => SetProperty(ref _advanceMinPercentage, value);
        }

        double _advanceMaxPercentage;
        public double AdvanceMaxPercentage
        {
            get => _advanceMaxPercentage;
            set => SetProperty(ref _advanceMaxPercentage, value);
        }

        int _selectedPercentage;
        public int SelectedPercentage
        {
            get => _selectedPercentage;
            set => SetProperty(ref _selectedPercentage, value);
        }

        public RealEstateViewModel()
        {
            PriceMinValue = 10000;
            PriceMaxValue = 100000;
            SelectedPrice = (int)PriceMinValue;
            AdvanceMinPercentage = 15;
            AdvanceMaxPercentage = 85;
        }
    }
}