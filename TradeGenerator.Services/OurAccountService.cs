using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeGenerator.Data;
using TradeGenerator.Models;

namespace TradeGenerator.Services
{
    public class OurAccountService
    {

        private readonly Guid _userId;

        public OurAccountService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateOurAccount(OurAccountCreate model)
        {
            var entity =
                new OurAccount()
                {
                    OwnerId = _userId,
                    Name = model.Name,
                    Balance = model.Balance,
                    TickerId =model.TickerId,

  
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.OurAccounts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<OurAccountListItem> GetOurAccounts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .OurAccounts
                        .Where(e => e.OwnerId == _userId) // && e.AccountId == _accountId)
                        .Select(
                            e =>
                                new OurAccountListItem
                                {
                                    AccountId = e.AccountId,
                                    Balance = e.Balance,
                                    Name = e.Name,
                                    TickerId = e.TickerId,
                                }
                        );

                return query.ToArray();
            }
        }

        public OurAccountDetail GetOurAccountById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .OurAccounts
                        .Single(e => e.AccountId == id && e.OwnerId == _userId);
                return
                    new OurAccountDetail
                    {
                        Name = entity.Name,
                        OwnerId = entity.OwnerId,
                        AccountId = entity.AccountId,
                        Balance =entity.Balance,
                        TotalPL = entity.TotalPL,
                        TradeId =entity.TradeId,
                        TradePL =entity.TradePL,
                        EnterDate = entity.EnterDate,
                        ExitDate =entity.ExitDate,
                        OpenPL = entity.OpenPL,
                        TickerId = entity.TickerId,
                    };
            }
        }

        public bool UpdateOurAccount(OurAccountEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .OurAccounts
                        .Single(e => e.AccountId == model.AccountId && e.OwnerId == _userId);

                entity.Name = model.Name;
                entity.OwnerId = model.OwnerId;
                entity.AccountId = model.AccountId;
                entity.Balance = model.Balance;
                entity.TotalPL = model.TotalPL;
                entity.TradeId = model.TradeId;
                entity.EnterDate = model.EnterDate;
                entity.ExitDate = model.ExitDate;
                entity.OpenPL = model.OpenPL;
                entity.TickerId = model.TickerId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteOurAccount(int AccountId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .OurAccounts
                        .Single(e => e.AccountId == AccountId && e.OwnerId == _userId);

                ctx.OurAccounts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
