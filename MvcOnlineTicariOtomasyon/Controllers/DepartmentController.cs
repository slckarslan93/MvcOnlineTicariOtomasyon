using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Departments.Where(x=>x.Status==true).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult addDepartment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addDepartment(Department d)
        {
            c.Departments.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult deleteDepartment(int id)
        {
            var dep = c.Departments.Find(id);
            dep.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult getDepartment(int id)
        {
            var department = c.Departments.Find(id);
            return View("getDepartment",department);
        }
        public ActionResult updateDepartment(Department p)
        {
            var department = c.Departments.Find(p.DepartmentId);
            department.DepartmentName = p.DepartmentName;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult detailDepartment(int id)
        {
            var deger = c.Personals.Where(x => x.Departmentid == id).ToList();
            var dpt = c.Departments.Where(x => x.DepartmentId == id).Select(y => y.DepartmentName).FirstOrDefault();
            ViewBag.d = dpt;
            return View(deger);

        }
        public ActionResult departmentPersonalSales(int id)
        {
            var values = c.SalesTransactions.Where(x => x.PersonalId == id).ToList();
            var pers = c.Personals.Where(x => x.PersonalId == id).Select(y => y.PersonalName +" "+ y.PersonalSurname).FirstOrDefault();
            ViewBag.dpers = pers;
            return View(values);
        }
    }
}