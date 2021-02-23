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
                var stockService = new StocksApiService();
                var result = await stockService.GetStockHistoricalData(CompaniesSymbols.TSLA);

                foreach (var data in result)
                {
                    Console.WriteLine(data.Close);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
