using System;
using API;
using Models.Constants;

namespace Contracts
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowHistoricalData();
            Console.Read();
        }

        private static async void ShowHistoricalData()
        {
            try
            {
                //var stockService = new StocksApiService();
                //var result = await stockService.GetStockHistoricalData(CompaniesSymbols.TSLA);

                //foreach (var data in result)
                //{
                //    Console.WriteLine(data.Close);
                //}

                //var financeService = new FinancialApiService();
                //var result = await financeService.GetFinancialData("AAPL");

                var sentimentService = new SentimentApiService();
                var result = await sentimentService.GetSentiment("TSLA");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
