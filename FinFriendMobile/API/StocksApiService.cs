using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts;
using Models;

namespace API
{
    public class StocksApiService : IStocksApiService
    {
        private const string HistoricalAPI = "finance/historicalByCompany/";

        public async Task<IEnumerable<StockHistoricalData>> GetStockHistoricalData(string companySymbol)
        {
            var url = HistoricalAPI + companySymbol;
            return await ApiClient.Instance.GetAsync<IEnumerable<StockHistoricalData>>(url);
        }
    }
}
