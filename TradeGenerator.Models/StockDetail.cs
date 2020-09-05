using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeGenerator.Models
{
    public class StockDetail
    {
     
        public int TickerId { get; set; }
        public Guid OwnerId { get; set; }
        public string Ticker { get; set; }
        public DateTime Date { get; set; }

        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
    }
}
