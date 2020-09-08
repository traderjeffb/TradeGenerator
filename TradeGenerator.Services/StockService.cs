using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeGenerator.Data;
using TradeGenerator.Models;

namespace TradeGenerator.Services
{
    public class StockService
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
                   TickerId = model.TickerId,
                    OwnerId = _userId,
                    Ticker = model.Ticker,
                    Date = model.Date,
                    High = model.High,
                    Low = model.Low,
                    Close = model.Close,
                    //MovingAvg1 = model.Close

                };

            using (var ctx = new ApplicationDbContext())
            {

                ctx.Stocks.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<StockListItem> GetStocks()
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
                                    TickerId =e.TickerId,
                                    Ticker = e.Ticker,
                                    Close = e.Close,
                                    Date = e.Date,
                                }
                        );

                return query.ToArray();
            }
        }

        public StockDetail GetStockById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Stocks
                        .Single(e => e.TickerId == id );
                return
                    new StockDetail
                    {
                        OwnerId = entity.OwnerId,
                        TickerId = entity.TickerId,
                        Ticker = entity.Ticker,
                        Date = entity.Date,
                        High = entity.High,
                        Low = entity.Low,
                        Close = entity.Close
                    };
            }
        }

        public bool UpdateStock(StockEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Stocks
                        .Single(e => e.TickerId == model.TickerId && e.OwnerId == _userId);

                entity.TickerId = model.TickerId;
                entity.Ticker = model.Ticker;
                //entity.Date = model.Date;
                entity.High = model.High;
                entity.Low = model.Low;
                entity.Close = model.Close;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteStock(int tickerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Stocks
                        .Single(e => e.TickerId == tickerId && e.OwnerId == _userId);

                ctx.Stocks.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }


}

