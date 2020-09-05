using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeGenerator.Models
{
    public class OurAccountDetail
    {
        public string Name { get; set; }
        public Guid OwnerId { get; set; }
        public int AccountId { get; set; }
        public decimal Balance { get; set; }
        public decimal? TotalPL { get; set; }
        public int? TradeId { get; set; }
        public decimal? TradePL { get; set; }
        public DateTime? EnterDate { get; set; }
        public DateTime? ExitDate { get; set; }
        public decimal? OpenPL { get; set; }
        public int TickerId { get; set; }

    }
}
