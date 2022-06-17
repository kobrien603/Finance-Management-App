namespace FinanceManagementApp.StockAPI.Models
{
    public class Stock
    {
        /// <summary>
        /// stock symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;

        /// <summary>
        /// company name
        /// </summary>
        public string CompanyName { get; set; } = string.Empty;

        /// <summary>
        /// list of stock data
        /// </summary>
        public List<StockData> Data { get; set; } = new();
    }
}
