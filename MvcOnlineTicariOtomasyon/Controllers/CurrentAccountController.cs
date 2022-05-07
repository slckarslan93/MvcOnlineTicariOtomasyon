using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CurrentAccountController : Controller
    {
        // GET: CurrentAccount
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.CurrentAccounts.Where(x => x.Status == true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult newCurrenAccount()
        {
            return View();
        }
        [HttpPost]
        public ActionResult newCurrenAccount(CurrentAccount p)
        {
            p.Status = true;
            c.CurrentAccounts.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult deleteCurrentAccount(int id)
        {
            var cr = c.CurrentAccounts.Find(id);
            cr.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult getCurrentAccount(int id)
        {
            var current = c.CurrentAccounts.Find(id);
            return View("getCurrentAccount", current);
        }
        public ActionResult updateCurrentAccount(CurrentAccount p)
        {
            if (!ModelState.IsValid)
            {
                return View("getCurrentAccount");
            }
            var current = c.CurrentAccounts.Find(p.CurrentAccountId);
            current.CurrentAccountName = p.CurrentAccountName;
            current.CurrentAccountSurname = p.CurrentAccountSurname;
            current.CurrentAccountCity = p.CurrentAccountCity;
            current.CurrentAccountMail = p.CurrentAccountMail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult customerSales(int id)
        {
            var deger = c.SalesTransactions.Where(x => x.CurrentAccountId == id).ToList();
            var cr = c.CurrentAccounts.Where(x => x.CurrentAccountId == id).Select(y => y.CurrentAccountName + " " + y.CurrentAccountSurname).FirstOrDefault();
            ViewBag.CurrentAccount = cr;
            return View(deger);
        }
    }
}