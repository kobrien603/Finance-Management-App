﻿using FinanceManagementApp.StockAPI;
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
        private Security stocks;
        public Security Stocks
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
            FetchLatestData();
            Stocks = await new StockAPIHelper().FetchAllStockInfo();
        }

        public async void FetchLatestData()
        {
            var updated_data = await new StockAPIHelper().FetchLatestData();
        }
        #endregion
    }
}
