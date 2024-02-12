using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WpfApp1.Models
{
    public class MarketApiResponse
    {
        [JsonProperty("data")]
        public List<MarketData> Data { get; set; }
    }

    public class MarketData
    {
        [JsonProperty("exchangeId")]
        public string ExchangeId { get; set; }

        [JsonProperty("pair")]
        public string TradingPair { get; set; }

        [JsonProperty("priceUsd")]
        public decimal PriceUsd { get; set; }

    }
}
