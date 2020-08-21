using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeGenerator.Data;
using TradeGenerator.Models;

namespace TradeGenerator.Services
{
    class StockService
    {
        private readonly Guid _userId;

        public StockService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateStock(StockCreate model)
        {
            var entity =
                new Stock()
                {
                    OwnerId = _userId,
                    Ticker = model.Ticker,
                    Date = model.Date,
                    High = model.High,
                    Low = model.Low,
                    Close = model.Close,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Stocks.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<StockListItem> GetNotes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Stocks
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new StockListItem
                                {
                                    //StockId = e
                                    Ticker = e.Ticker,
                                    Close = e.Close,
                                    Date = e.Date,
                                }
                        );

                return query.ToArray();
            }
        }

    }


}

