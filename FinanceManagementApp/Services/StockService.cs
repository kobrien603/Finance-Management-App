using FinanceManagementApp.StockAPI;
using YahooQuotesApi;

namespace FinanceManagementApp.Services
{
    public class StockService
    {
        #region init
        public StockService() { }

        public void Init()
        {
            FetchStocks();
            isLoading = false;
        }

        public event Action? OnChange;
        private void NotifyStateChanged() => OnChange?.Invoke();
        #endregion

        #region properties
        private Dictionary<string, Security?> stocks;
        public Dictionary<string, Security?> Stocks
        {
            get => stocks;
            set
            {
                stocks = value;
                NotifyStateChanged();
            }
        }

        private bool isLoading = true;
        public bool IsLoading
        {
            get => isLoading;
            set
            {
                isLoading = value;
                NotifyStateChanged();
            }
        }
        #endregion

        #region functions
        public async void FetchStocks()
        {
            Stocks = await new StockAPIHelper().FetchDataAsync();
        }
        #endregion
    }
}
