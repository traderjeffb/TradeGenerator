using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeGenerator.Models
{
    public class OurAccountCreate
    {
        [Required]
        public string Name { get; set; }
        public int AccountId { get; set; }
        public decimal Balance { get; set; }
        //public int StockTicker{ get; set; }
        public int TickerId { get; set; }

    }
}
