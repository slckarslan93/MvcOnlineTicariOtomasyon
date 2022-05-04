using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CategoryController : Controller //Controler back-end kodları
    {
        // GET: Category

        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Categories.ToList();
            return View(degerler);
        }

        //kategori ekle methodu hem form load olduğunda hemde ekle butonu ile çalışacak
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category k)
        {
            c.Categories.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult deleteCategory(int id)
        {
            var category = c.Categories.Find(id);
            c.Categories.Remove(category);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult getCategory(int id)
        {
            var category = c.Categories.Find(id);
            return View("getCategory", category);
        }
        public ActionResult updateCategory(Category k)
        {
            var ctgry = c.Categories.Find(k.CategoryId);
            ctgry.CategoryName = k.CategoryName;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}