using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Currency> _currencies;
        public ObservableCollection<Currency> Currencies
        {
            get { return _currencies; }
            set
            {
                _currencies = value;
                OnPropertyChanged(nameof(Currencies));
            }
        }

        private ObservableCollection<Currency> _filteredCurrencies;
        public ObservableCollection<Currency> FilteredCurrencies
        {
            get { return _filteredCurrencies; }
            set
            {
                _filteredCurrencies = value;
                OnPropertyChanged(nameof(FilteredCurrencies));
            }
        }

        private string _searchQuery;
        public string SearchQuery
        {
            get { return _searchQuery; }
            set
            {
                _searchQuery = value;
                FilterCurrencies();
                OnPropertyChanged(nameof(SearchQuery));
            }
        }

        private Currency _selectedCurrency;
        public Currency SelectedCurrency
        {
            get { return _selectedCurrency; }
            set
            {
                _selectedCurrency = value;
                OnPropertyChanged(nameof(SelectedCurrency));
                // Populate detailed information property here
                PopulateDetailedInformation(value);
            }
        }

        // Property to hold detailed information about the selected currency
        private CurrencyDetail _detailedInformation;
        public CurrencyDetail DetailedInformation
        {
            get { return _detailedInformation; }
            set
            {
                _detailedInformation = value;
                OnPropertyChanged(nameof(DetailedInformation));
            }
        }

        public HomeViewModel()
        {
            Currencies = new ObservableCollection<Currency>();
            FilteredCurrencies = new ObservableCollection<Currency>();
            LoadData();
        }

        private async Task LoadData()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.coincap.io/v2/");
                var response = await client.GetAsync("assets?limit=100");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<CoinCapApiResponse>(json);
                    foreach (var coin in result.Data)
                    {
                        var currency = new Currency
                        {
                            Name = coin.Name,
                            Symbol = coin.Symbol,
                            Price = coin.PriceUsd,
                            Volume = coin.volumeUsd24Hr,
                            PriceChange = coin.changePercent24Hr,
                        };
                        Currencies.Add(currency);
                    }
                    FilterCurrencies();
                }
            }
        }

        private void FilterCurrencies()
        {
            if (string.IsNullOrWhiteSpace(SearchQuery))
            {
                FilteredCurrencies = Currencies;
            }
            else
            {
                FilteredCurrencies = new ObservableCollection<Currency>(
                    Currencies.Where(c =>
                        c.Name.ToLower().Contains(SearchQuery.ToLower()) ||
                        c.Symbol.ToLower().Contains(SearchQuery.ToLower())));
            }
        }

        private void PopulateDetailedInformation(Currency currency)
        {
            if (currency != null)
            {
                DetailedInformation = new CurrencyDetail(currency);
            }
            else
            {
                DetailedInformation = null;
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
