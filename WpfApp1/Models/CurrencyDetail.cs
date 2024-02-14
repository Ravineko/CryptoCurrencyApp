
namespace WpfApp1.Models
{
    public class CurrencyDetail
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public decimal Price { get; set; }
        public decimal Volume { get; set; }
        public decimal PriceChange { get; set; }

        public CurrencyDetail(Currency selectedCurrency)
        {
            Name = selectedCurrency.Name;
            Symbol = selectedCurrency.Symbol;
            Price = selectedCurrency.Price;
            Volume = selectedCurrency.Volume;
            PriceChange = selectedCurrency.PriceChange;
        }
    }
}
