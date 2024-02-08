using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class CoinCapApiResponse
    {
        public List<Coin> Data { get; set; }
    }

    public class Coin
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public decimal PriceUsd { get; set; }

    }
}

