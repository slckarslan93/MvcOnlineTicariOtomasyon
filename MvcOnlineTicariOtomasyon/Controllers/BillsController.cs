using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class BillsController : Controller
    {
        // GET: Bills
        Context c = new Context();
        public ActionResult Index()
        {
            var list = c.Bills.ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult addBills()
        {
            return View();
        }
        [HttpPost]
        public ActionResult addBills(Bills b)
        {
            c.Bills.Add(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult getBills(int id)
        {
            var bill = c.Bills.Find(id);
            return View("getBills", bill);
        }
        public ActionResult updateBills(Bills b)
        {
            var bill = c.Bills.Find(b.BillsId);
            bill.BillSerialNo = b.BillSerialNo;
            bill.BillOrderNo = b.BillOrderNo;
            bill.Hour = b.Hour;
            bill.BillDate = b.BillDate;
            bill.Submitter = b.Submitter;
            bill.Receiver = b.Receiver;
            bill.TaxAdministration = b.TaxAdministration;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult detailBills(int id)
        {
            var value = c.BillsItems.Where(x => x.BillsId == id).ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult newBillsItem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult newBillsItem(BillsItems p)
        {
            c.BillsItems.Add(p);
            c.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}