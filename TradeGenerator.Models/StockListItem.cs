using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeGenerator.Models
{
    public class StockListItem   
    {
        public int StockId { get; set; }
        public string Ticker { get; set;}
        public decimal Close { get; set; }
        public DateTime Date { get; set; }
    }
}
