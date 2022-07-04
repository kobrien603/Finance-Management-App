using FinanceManagementApp.StockAPI.Models;
using NodaTime;
using System.Diagnostics;
using YahooQuotesApi;

namespace FinanceManagementApp.StockAPI
{
    public class StockAPIHelper
    {
        private readonly YahooQuotes yahooAPI;

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
        /// fetch latest data for all stocks
        /// </summary>
        /// <returns></returns>
        public async Task<Dictionary<string, Security?>> FetchDataAsync()
        {
            var stock_response = await yahooAPI.GetAsync(_stocks, HistoryFlags.All);
            return stock_response;
        }
    }
}
