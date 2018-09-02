using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interface.Interface;
using MvcPL.Infrastructure;

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
    }
}