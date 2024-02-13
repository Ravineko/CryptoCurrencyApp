using System.Collections.Generic;
using System.Linq;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    public class CurrencyDetailViewModel
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public decimal Price { get; set; }
        public decimal Volume { get; set; }
        public decimal PriceChange { get; set; }

        public CurrencyDetailViewModel(Currency selectedCurrency)
        {
            Name = selectedCurrency.Name;
            Symbol = selectedCurrency.Symbol;
            Price = selectedCurrency.Price;
            Volume = selectedCurrency.Volume;
            PriceChange = selectedCurrency.PriceChange;
        }
    }
}
