using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interface.Interface;
using MvcPL.Infrastructure;
using MvcPL.Models;
using TypeOfAccount;

namespace MvcPL.Controllers
{
    public class AccountController : Controller
    {
        private readonly IService service;

        public AccountController(IService service)
        {
            this.service = service;
        }
        // GET: Account
        [ActionName("Index")]
        public ActionResult Index()
        {
            return View(service.GetAll().Select(account => account.ToMvcAccount()));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [ActionName("Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AccountViewModel account)
        {
            service.OpenAccount(account.HolderFirstName,account.HolderLastName,account.HolderEmail,account.AccountType);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Deposite()
        {
            return View();
        }

        [ActionName("Deposite")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deposite(string id,decimal amount)
        {
            service.Deposite(id,amount);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Withdraw()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Withdraw(string id,decimal amount)
        {
            service.Withdraw(id,amount);
            return RedirectToAction("Index");
        }

    }
}