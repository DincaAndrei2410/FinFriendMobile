using System.Threading.Tasks;
using Contracts;
using Models.Models;

namespace API
{
    public class FinancialApiService : IFinancialApiService
    {
        public const string FINANCE_URL = "finance/summaryByCompany/";

        public async Task<FinancialData> GetFinancialData(string companySymbol)
        {
            var url = FINANCE_URL + companySymbol;
            return await ApiClient.Instance.GetAsync<FinancialData>(url);
        }
    }
}
