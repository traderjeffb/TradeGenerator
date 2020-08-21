using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TradeGenerator.Models;

namespace TradeGenerator.Controllers
{
    [Authorize]
    public class StockController : Controller
    {
        // GET: Trade
        public ActionResult Index()
        {
            var model = new StockListItem[0];
            return View(model);
        }
    }
}