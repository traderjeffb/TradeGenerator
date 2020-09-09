using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeGenerator.Data
{
    public class Stock
    {
        [Key]
        [Required]
        public int TickerId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }
        public string Ticker { get; set; }


        [Required]
        public DateTime Date { get; set; }
        
        public decimal High { get; set; }
        public decimal Low { get; set; }
        [Required]
        public decimal Close { get; set; }




    }
}
