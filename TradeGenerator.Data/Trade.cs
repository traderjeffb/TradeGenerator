using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeGenerator.Data
{
    public class Trade
    {
        [Key]
        public int TickerId { get; set; }
        [Required]
        public DateTime EnterDate { get; set; }
        [Required]
        public DateTime ExitDate { get; set; }
        public decimal ProfitLoss { get; set; }


    }
}
