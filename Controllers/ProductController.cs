using BACommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BACommerce.Controllers
{
    public class ProductController : Controller
    {
        BACommercesEntities1 db = new BACommercesEntities1();
        public ActionResult Index()
        {
            try
            {
                ViewBag.CurrentAdmin = User.Identity.Name;
                ViewBag.CurrentAdmin = Session["AdminName"];
                ViewBag.Rights = Session["Rights"];

                int yetki = ViewBag.Rights;
                if (yetki > 0)
                {
                    return View(db.Products.OrderByDescending(x => x.ProductID).ToList());
                }
                else
                {
                    return RedirectToAction("AdminLogin", "Account");
                }
            }
            catch
            {
                return RedirectToAction("AdminLogin", "Account");
            }
        }
        
        public ActionResult Ekle()
        {
            try
            {
                ViewBag.CurrentAdmin = User.Identity.Name;
                ViewBag.CurrentAdmin = Session["AdminName"];
                ViewBag.Rights = Session["Rights"];

                int yetki = ViewBag.Rights;
                if (yetki > 0)
                {
                    ViewBag.Info = null;
                    ViewBag.CategoryList = new SelectList(db.Categories.OrderByDescending(x => x.CategoryID).Select(x => new
                    {
                        value = x.CategoryID,
                        text = x.CategoryName
                    }), "value", "text");
                    return View();
                }
                else
                {
                    return RedirectToAction("AdminLogin", "Account");
                }
            }
            catch
            {
                return RedirectToAction("AdminLogin", "Account");
            }
        }

        [HttpPost]
        public ActionResult Ekle(Product yeniUrun)
        {
            try
            {
                ViewBag.CategoryList = new SelectList(db.Categories.OrderByDescending(a => a.CategoryID).Select(x => new
            {
                value = x.CategoryID,
                text = x.CategoryName
            }), "value", "text");


            db.Products.Add(yeniUrun);
           
               
                db.SaveChanges();
                ViewBag.bilgi = true;
            }
            catch
            {
                ViewBag.bilgi = false;
            }

            return View();
        }


        public ActionResult Guncelle(int id)
        {
            try
            {
                ViewBag.CurrentAdmin = User.Identity.Name;
                ViewBag.CurrentAdmin = Session["AdminName"];
                ViewBag.Rights = Session["Rights"];

                int yetki = ViewBag.Rights;
                if (yetki > 0)
                {
                    ViewBag.Info = null;
                    ViewBag.CategoryList = db.Categories.ToList();
                    Product update = db.Products.Find(id);
                    return View(update);
                }
                else
                {
                    return RedirectToAction("AdminLogin", "Account");
                }
            }
            catch
            {
                return RedirectToAction("AdminLogin", "Account");
            }
        }

        [HttpPost]
        public ActionResult Guncelle(Product guncel)
        {
            ViewBag.CategoryList = db.Categories.ToList();
            db.Entry(db.Products.Find(guncel.ProductID)).CurrentValues.SetValues(guncel);
            try
            {
                db.SaveChanges();
                ViewBag.bilgi = true;
            }
            catch
            {
                ViewBag.bilgi = false;
            }

            return View(guncel);
        }


        public ActionResult Sil(int id)
        {
            Product silinecek = db.Products.Find(id);
            db.Products.Remove(silinecek);
            db.SaveChanges();

            return RedirectToAction("Index");
        }





        public ActionResult ProductDetails(int id)
        {
            ViewBag.CurrentUser = Session["UserName"];

            return View(db.Products.Find(id));

        }
    }



}