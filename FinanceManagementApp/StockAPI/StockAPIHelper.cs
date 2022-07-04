using FinanceManagementApp.StockAPI.Models;
using NodaTime;
using System.Diagnostics;
using YahooQuotesApi;

namespace FinanceManagementApp.StockAPI
{
    public class StockAPIHelper
    {
        YahooQuotes yahooAPI;

        public StockAPIHelper(DateTime? startDate = null)
        {
            var date = startDate ?? new DateTime(2020, 1, 1);
            yahooAPI = new YahooQuotesBuilder()
                .WithHistoryStartDate(Instant.FromUtc(date.Year, date.Month, date.Day, date.Hour, date.Minute))
                .Build();
        }

        /// <summary>
        /// array of all stocks we want to monitor
        /// TODO - make list dynamic (user selects and saves?)
        /// </summary>
        private static readonly string[] _stocks = new[]
        {
            "AAPL",
            "GOOG"
        };

        /// <summary>
        /// initial call to fetch historical data for all stocks
        /// </summary>
        /// <returns></returns>
        public async Task<Security> FetchAllStockInfo()
        {
            
                Security historical_data = await yahooAPI.GetAsync("MSFT", HistoryFlags.PriceHistory)
                    ?? throw new ArgumentException("Unknown symbol.");
            

            return historical_data;
        }

        /// <summary>
        /// fetch latest data for all stocks
        /// </summary>
        /// <returns></returns>
        public async Task<Dictionary<string, Security?>> FetchLatestData()
        {
            var stock_response = await yahooAPI.GetAsync(_stocks);
            return stock_response;
        }
    }
}
