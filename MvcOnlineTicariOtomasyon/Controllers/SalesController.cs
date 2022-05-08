using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.SalesTransactions.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult newSales()
        {
            List<SelectListItem> value1 = (from x in c.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProductName,
                                               Value = x.ProductId.ToString()
                                           }).ToList();
            List<SelectListItem> value2 = (from x in c.CurrentAccounts.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CurrentAccountName+" "+x.CurrentAccountSurname,
                                               Value = x.CurrentAccountId.ToString()
                                           }).ToList();
            List<SelectListItem> value3 = (from x in c.Personals.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonalName+" "+x.PersonalSurname,
                                               Value = x.PersonalId.ToString()
                                           }).ToList();
            ViewBag.val1 = value1;
            ViewBag.val2 = value2;
            ViewBag.val3 = value3;
            return View();
        }
        [HttpPost]
        public ActionResult newSales(SalesTransactions s)
        {
            s.Date =DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SalesTransactions.Add(s);
            c.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult getSales(int id)
        {
            List<SelectListItem> value1 = (from x in c.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProductName,
                                               Value = x.ProductId.ToString()
                                           }).ToList();
            List<SelectListItem> value2 = (from x in c.CurrentAccounts.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CurrentAccountName + " " + x.CurrentAccountSurname,
                                               Value = x.CurrentAccountId.ToString()
                                           }).ToList();
            List<SelectListItem> value3 = (from x in c.Personals.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonalName + " " + x.PersonalSurname,
                                               Value = x.PersonalId.ToString()
                                           }).ToList();
            ViewBag.val1 = value1;
            ViewBag.val2 = value2;
            ViewBag.val3 = value3;
            var value = c.SalesTransactions.Find(id);
            return View("getSales", value);
        }
        public ActionResult updateSales(SalesTransactions p)
        {
            var value = c.SalesTransactions.Find(p.SalesId);
            value.CurrentAccountId = p.CurrentAccountId;
            value.Unit = p.Unit;
            value.Price = p.Price;
            value.PersonalId = p.PersonalId;
            value.Date = p.Date;
            value.TotalPrice = p.TotalPrice;
            value.ProductId = p.ProductId;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult detailSales(int id)
        {
            var value = c.SalesTransactions.Where(x => x.SalesId == id).ToList();
            return View(value);
        }
    }
}