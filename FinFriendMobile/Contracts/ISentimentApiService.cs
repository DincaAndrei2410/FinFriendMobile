using System;
using System.Threading.Tasks;
using Models.Models;

namespace Contracts
{
    public interface ISentimentApiService
    {
        Task<SentimentData> GetSentiment(string companySymbol);
    }
}
