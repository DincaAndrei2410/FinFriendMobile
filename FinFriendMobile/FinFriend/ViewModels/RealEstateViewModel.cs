using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using FinFriend.Models;
using FinFriend.Views;
using System.Collections.Generic;
using FinFriend.Services;

namespace FinFriend.ViewModels
{
    public class RealEstateViewModel : BaseViewModel
    {
        private const int PriceStepValue = 1000;
        private const double MinAdvancePercentage = 0.15;
        private const double MaxAdvancePercentage = 0.85;

        public IDataStore<Neighborhood> _neighborhoodsService => DependencyService.Get<IDataStore<Neighborhood>>();

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
                OnPropertyChanged(nameof(AdvanceValue));
            }
        }

        int _advanceMinPercentage;
        public int AdvanceMinPercentage
        {
            get => _advanceMinPercentage;
            set => SetProperty(ref _advanceMinPercentage, value);
        }

        int _advanceMaxPercentage;
        public int AdvanceMaxPercentage
        {
            get => _advanceMaxPercentage;
            set => SetProperty(ref _advanceMaxPercentage, value);
        }

        int _yearMin;
        public int YearMin
        {
            get => _yearMin;
            set => SetProperty(ref _yearMin, value);
        }

        int _yearMax;
        public int YearMax
        {
            get => _yearMax;
            set => SetProperty(ref _yearMax, value);
        }

        int _selectedYear;
        public int SelectedYear
        {
            get => _selectedYear;
            set => SetProperty(ref _selectedYear, value);
        }

        int _selectedPercentage;
        public int SelectedPercentage
        {
            get => _selectedPercentage;
            set 
            {
                SetProperty(ref _selectedPercentage, value);
                OnPropertyChanged(nameof(AdvanceValue));
            }
        }

        IEnumerable<Neighborhood> _neighborhoods;
        public IEnumerable<Neighborhood> Neighborhoods
        {
            get => _neighborhoods;
            set => SetProperty(ref _neighborhoods, value);
        }

        public int AdvanceValue => (int)Math.Round(SelectedPrice * ((float)SelectedPercentage / 100));

        public RealEstateViewModel()
        {
            LoadDefaultValues();
            FireAndForgetSafeAsync(LoadNeighborHoods());

            int a = 3;
            object b = new object();
        }

        private void LoadDefaultValues()
        {
            PriceMinValue = 10000;
            PriceMaxValue = 100000;
            AdvanceMinPercentage = 15;
            AdvanceMaxPercentage = 85;
            YearMin = 3;
            YearMax = 30;
        }

        private async Task LoadNeighborHoods()
        {
            Neighborhoods = await _neighborhoodsService.GetItemsAsync();
        }
    }
}