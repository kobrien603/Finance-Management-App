using FinanceManagementApp.StockAPI.Models;
using System.Diagnostics;
using YahooFinanceApi;

namespace FinanceManagementApp.StockAPI
{
    public class StockAPIHelper
    {
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
        public async Task<List<IReadOnlyList<Candle>>> FetchAllStockInfo()
        {
            List<IReadOnlyList<Candle>> historical_data = new();
            try
            {
                foreach (var stock in _stocks)
                {
                    //var t = await Yahoo.GetHistoricalAsync(stock, new DateTime(2022, 01, 01), new DateTime(2022, 12, 01), Period.Daily);
                    //var x = await Yahoo.GetDividendsAsync(stock, new DateTime(2022, 01, 01), new DateTime(2022, 12, 01));
                    string s = "";
                    //historical_data.Add();
                }
            }
            catch (Exception e)
            {
                string t = "";
            }

            return historical_data;
        }

        /// <summary>
        /// fetch latest data for all stocks
        /// </summary>
        /// <returns></returns>
        public async Task<IReadOnlyDictionary<string, Security>> FetchLatestData()
        {
            var stock_response = await Yahoo.Symbols(_stocks).QueryAsync();
            return stock_response;
        }
    }
}
