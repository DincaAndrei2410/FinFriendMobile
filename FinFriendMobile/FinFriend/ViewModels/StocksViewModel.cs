using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using FinFriend.Services;
using Models.Models;
using Xamarin.Forms;


namespace FinFriend.ViewModels
{
    public class StocksViewModel : BaseViewModel
    {
        const int MAX_SELECTION_ALLOWED = 2;

        private IDataStore<Company> _companiesService => DependencyService.Get<IDataStore<Company>>();

        private IEnumerable<CompanyCellViewModel> _companies;
        public IEnumerable<CompanyCellViewModel> Companies
        {
            get => _companies;
            set => SetProperty(ref _companies, value);
        }

        private bool _areEnoughCompaniesSelected;
        public bool AreEnoughCompaniesSelected
        {
            get => _areEnoughCompaniesSelected;
            set => SetProperty(ref _areEnoughCompaniesSelected, value);
        }

        public StocksViewModel()
        {
            FireAndForgetSafeAsync(LoadCompanies());
        }

        private async Task LoadCompanies()
        {
            var companies = (await _companiesService.GetItemsAsync()).OrderBy(company => company.CompanyName);

            var companiesVM = new List<CompanyCellViewModel>();
            foreach (var company in companies)
            {
                companiesVM.Add(new CompanyCellViewModel(company));
            }

            Companies = companiesVM;
        }

        public void CompanySelected(string companyName)
        {
            var selectedCount = Companies.Count(c => c.IsSelected);
            var companyVM = Companies.Where(c => c.Company.CompanyName == companyName).FirstOrDefault();

            if (selectedCount >= MAX_SELECTION_ALLOWED && !companyVM.IsSelected)
                return;

            if(companyVM != null)
            {
                companyVM.ChangeSelection();
            }

            AreEnoughCompaniesSelected = Companies.Count(c => c.IsSelected) == 2;
        }

        public IEnumerable<Company> GetSelectedCountries()
        {
            var selectedCompanies = Companies.Where(c => c.IsSelected).Select(c => c.Company);
            return selectedCompanies;
        }
    }
}
