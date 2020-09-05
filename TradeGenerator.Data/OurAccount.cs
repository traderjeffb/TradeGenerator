using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace TradeGenerator.Data
{
    public class OurAccount
    {

        public string Name { get; set; }
        public Guid OwnerId { get; set; }
        [Key]
        public int AccountId { get; set; }
        public decimal Balance { get; set; }
        public decimal? TotalPL { get; set; }
        public int? TradeId { get; set; }
        public decimal? TradePL { get; set; }
        public DateTime? EnterDate { get; set; }
        public DateTime? ExitDate { get; set; }
        public decimal? OpenPL { get; set; }
        public int TickerId { get; set; }
        [ForeignKey("TickerId")]
        public virtual Stock Stock { get; set; }
    }
}
