using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Contracts
{
    public interface IStocksApiService
    {
        Task<IEnumerable<StockHistoricalData>> GetStockHistoricalData(string companySymbol);
    }
}
