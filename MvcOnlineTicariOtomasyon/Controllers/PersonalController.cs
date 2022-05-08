using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class PersonalController : Controller
    {
        // GET: Personal
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Personals.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult addPersonal()
        {
            List<SelectListItem> value1 = (from x in c.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmentName,
                                               Value = x.DepartmentId.ToString()
                                           }).ToList();
            ViewBag.val1 = value1;
            return View();
        }
        [HttpPost]
        public ActionResult addPersonal(Personal p)
        {
            c.Personals.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult getPersonal(int id)
        {
            List<SelectListItem> value1 = (from x in c.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmentName,
                                               Value = x.DepartmentId.ToString()
                                           }).ToList();
            ViewBag.val1 = value1;
            var prs = c.Personals.Find(id);
            return View("getPersonal", prs);

        }
        public ActionResult updatePersonal(Personal p)
        {
            var prs = c.Personals.Find(p.PersonalId);
            prs.PersonalName = p.PersonalName;
            prs.PersonalSurname = p.PersonalSurname;
            prs.PersonalImage = p.PersonalImage;
            prs.Departmentid = p.Departmentid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}