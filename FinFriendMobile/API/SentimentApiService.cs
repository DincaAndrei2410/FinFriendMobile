using System;
using System.Threading.Tasks;
using Contracts;
using Models.Models;

namespace API
{
    public class SentimentApiService : ISentimentApiService
    {
        private const string SentimentURL = "sentiment/analysis/";

        public async Task<SentimentData> GetSentiment(string companySymbol)
        {
            var url = SentimentURL + companySymbol;
            return await ApiClient.Instance.GetAsync<SentimentData> (url);
        }
    }
}
