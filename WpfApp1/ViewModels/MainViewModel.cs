using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
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

        public MainViewModel()
        {
            Currencies = new ObservableCollection<Currency>();
            LoadData();
        }

        private async void LoadData()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.coincap.io/v2/");
                var response = await client.GetAsync("assets?limit=10");
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
                          
                        };
                        Currencies.Add(currency);
                    }
                }
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
