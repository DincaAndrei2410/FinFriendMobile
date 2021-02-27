using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Models;

namespace FinFriend.Services
{
    public class CompaniesDataStore : IDataStore<Company>
    {
        public CompaniesDataStore()
        {
        }

        public Task<IEnumerable<Company>> GetItemsAsync(bool forceRefresh = false)
        {
            IEnumerable<Company> companies;
            companies = new List<Company>()
            {
                new Company() { CompanyName = "Amazon.com Inc.", CompanySymbol="AMZN", CompanyLogo="http://media.corporate-ir.net/media_files/IROL/17/176060/Oct18/Amazon%20logo.PNG", IsSelected=true, },
                new Company() { CompanyName = "Apple Inc.", CompanySymbol="AAPL", CompanyLogo="https://pngimg.com/uploads/apple_logo/apple_logo_PNG19674.png", IsSelected=true,},
                new Company() { CompanyName = "Google LLC", CompanySymbol="GOOGL", CompanyLogo="https://upload.wikimedia.org/wikipedia/commons/thumb/2/2f/Google_2015_logo.svg/368px-Google_2015_logo.svg.png"},
                new Company() { CompanyName = "Tesla, Inc.", CompanySymbol="TSLA", CompanyLogo="https://upload.wikimedia.org/wikipedia/commons/e/e8/Tesla_logo.png"},
                new Company() { CompanyName = "Facebook", CompanySymbol="FB", CompanyLogo="https://1000logos.net/wp-content/uploads/2016/11/Facebook-logo.png"},
                new Company() { CompanyName = "Netflix, Inc.", CompanySymbol="NFLX", CompanyLogo="https://i.pinimg.com/originals/f6/97/4e/f6974e017d3f6196c4cbe284ee3eaf4e.png"},
            };

            return Task.FromResult(companies);
        }
    }
}
