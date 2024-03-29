﻿using System;
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
        public decimal volumeUsd24Hr { get; set; } 
        public decimal changePercent24Hr { get; set; } 
        public List<Market> Markets { get; set; } 

    }
}

