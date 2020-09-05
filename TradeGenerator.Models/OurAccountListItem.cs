using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeGenerator.Models
{
    public class OurAccountListItem
    {
        public string Name { get; set; }
        public int AccountId { get; set; }
        public decimal Balance { get; set; }
        public int TickerId { get; set; }


    }
}
