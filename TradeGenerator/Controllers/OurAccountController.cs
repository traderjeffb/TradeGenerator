using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TradeGenerator.Models;
using TradeGenerator.Services;

namespace TradeGenerator.Controllers
{
    public class OurAccountController : Controller
    {
        // GET: OurAccount
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new OurAccountService(userId);
            var model = service.GetOurAccounts();

            return View(model);
            //    return View();
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OurAccountCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateOurAccountService();

            if (service.CreateOurAccount(model))
            {
                TempData["SaveResult"] = "Your Account was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Account could not be created.");

            return View(model);
        }

        private OurAccountService CreateOurAccountService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new OurAccountService(userId);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateOurAccountService();
            var model = svc.GetOurAccountById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateOurAccountService();
            var detail = service.GetOurAccountById(id);
            var model =
                new OurAccountEdit
                {
                    Name = detail.Name,
                    OwnerId = detail.OwnerId,
                    AccountId = detail.AccountId,
                    Balance = detail.Balance,
                    TotalPL = detail.TotalPL,
                    TradeId = detail.TradeId,
                    EnterDate = detail.EnterDate,
                    ExitDate = detail.ExitDate,
                    OpenPL = detail.OpenPL,
                    TickerId = detail.TickerId,
                };
        
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, OurAccountEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.AccountId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateOurAccountService();

            if (service.UpdateOurAccount(model))
            {
                TempData["SaveResult"] = "Your account was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your account could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateOurAccountService();
            var model = svc.GetOurAccountById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateOurAccountService();

            service.DeleteOurAccount(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
        }
    }
}
