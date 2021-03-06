﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TradeGenerator.Models;
using TradeGenerator.Services;

namespace TradeGenerator.Controllers
{
    [Authorize]
    public class StockController : Controller
    {
        // GET: Trade
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new StockService(userId);
            var model = service.GetStocks();

            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StockCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateStockService();

            if (service.CreateStock(model))
            {
                TempData["SaveResult"] = "Your Stock was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Stock could not be created.");

            return View(model);
        }

        private StockService CreateStockService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new StockService(userId);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateStockService();
            //var model = svc.GetStockById(id);
            var model = svc.GetStockById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateStockService();
            var detail = service.GetStockById(id);
            var model =
                new StockEdit
                {
                    TickerId = detail.TickerId,
                    High = detail.High,
                    Low = detail.Low,
                    Close = detail.Close,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, StockEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.TickerId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateStockService();

            if (service.UpdateStock(model))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your note could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateStockService();
            var model = svc.GetStockById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateStockService();

            service.DeleteStock(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
        }
    }
}
