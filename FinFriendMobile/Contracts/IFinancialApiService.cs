using System;
using System.Threading.Tasks;
using Models.Models;

namespace Contracts
{
    public interface IFinancialApiService
    {
        Task<FinancialData> GetFinancialData(string symbol);
    }
}
