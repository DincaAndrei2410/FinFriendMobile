using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinFriend.Models;

namespace FinFriend.Services
{
    public class RealEstateCreditDataStore : IDataStore<RealEstateCredit>
    {
        private IEnumerable<RealEstateCredit> _realEstateCredits;

        public RealEstateCreditDataStore()
        {
            _realEstateCredits = new List<RealEstateCredit>()
            {
                new RealEstateCredit() {BankName = "ING", DobandaAnuala="4 %", Logo="https://upload.wikimedia.org/wikipedia/commons/4/4b/ING_logo.png", RataLunara = "1200 LEI", TotalPlata = "50,00 LEI", SimulatorURL="https://ing.ro/persoane-fizice/credite/ipotecar"},
                new RealEstateCredit() {BankName = "ING2", DobandaAnuala="4.5 %", Logo="https://upload.wikimedia.org/wikipedia/commons/4/4b/ING_logo.png", RataLunara = "1200 LEI", TotalPlata = "50,00 LEI", SimulatorURL="https://ing.ro/persoane-fizice/credite/ipotecar"},
            };
        }

        public Task<IEnumerable<RealEstateCredit>> GetItemsAsync(bool forceRefresh = false)
        {
            return Task.FromResult(_realEstateCredits);
        }
    }
}
