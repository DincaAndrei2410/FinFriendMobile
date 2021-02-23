using System;

namespace Models
{
    public class StockHistoricalData
    {
        public DateTime Date { get; set; }
        public double Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Close { get; set; }
        public double AdjClose { get; set; }
        public long Volume { get; set; }
        public string Symbol { get; set; }
        public double CumulativeReturn { get; set; }
        public double DailyPercentageChange { get; set; }
    }
}
