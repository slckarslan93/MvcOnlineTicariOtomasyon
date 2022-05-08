using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        Context c = new Context();
        public ActionResult Index()
        {
            var products = c.Products.Where(x=>x.Status==true).ToList();
            return View(products);
        }
        [HttpGet]
        public ActionResult newProduct()
        {
            List<SelectListItem> value1 = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.val1 = value1;
            return View();
        }
        [HttpPost]
        public ActionResult newProduct(Product p)
        {
            c.Products.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public  ActionResult deleteProduct(int id)
        {
            var deger = c.Products.Find(id);
            deger.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult getProduct(int id)
        {
            List<SelectListItem> value1 = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.val1 = value1;
            var productvalue = c.Products.Find(id);
            return View("getProduct", productvalue);
        }
        public ActionResult updateProduct(Product p)
        {
            var product = c.Products.Find(p.ProductId);
            product.PurchasePrice = p.PurchasePrice;
            product.Status = p.Status;
            product.Categoryid = p.Categoryid;
            product.ProductBrand = p.ProductBrand;
            product.SellingPrice = p.SellingPrice;
            product.Stock = p.Stock;
            product.ProductName = p.ProductName;
            product.ProductImage = p.ProductImage;
            
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult productList()
        {
            var values = c.Products.ToList();
            return View(values);
        }
    }
}