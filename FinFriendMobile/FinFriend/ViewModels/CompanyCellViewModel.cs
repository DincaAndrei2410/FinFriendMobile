using System;
using Models.Models;

namespace FinFriend.ViewModels
{
    public class CompanyCellViewModel : BaseViewModel
    {
        public Company Company { get; set; }

        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }

        public CompanyCellViewModel(Company company)
        {
            Company = company;
            IsSelected = false;
        }

        public void ChangeSelection()
        {
            IsSelected = !IsSelected;
        }
    }
}
