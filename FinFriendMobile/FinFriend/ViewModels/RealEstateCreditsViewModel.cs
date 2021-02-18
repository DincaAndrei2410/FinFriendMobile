using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinFriend.Models;
using FinFriend.Services;
using Xamarin.Forms;

namespace FinFriend.ViewModels
{
    public class RealEstateCreditsViewModel : BaseViewModel
    {
        public IDataStore<RealEstateCredit> _realEstateCreditService => DependencyService.Get<IDataStore<RealEstateCredit>>();

        IEnumerable<RealEstateCredit> _realEstateCredits;
        public IEnumerable<RealEstateCredit> RealEstateCredits
        {
            get => _realEstateCredits;
            set => SetProperty(ref _realEstateCredits, value);
        }

        public RealEstateCreditsViewModel()
        {
            FireAndForgetSafeAsync(LoadData());
        }

        private async Task LoadData()
        {
            _realEstateCredits = await _realEstateCreditService.GetItemsAsync();
        }
    }
}
