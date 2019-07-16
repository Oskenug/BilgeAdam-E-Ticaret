using BACommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BACommerce.Controllers
{
    public class CategoryController : Controller
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
                if (yetki >0)
                {
                    List<Category> liste = db.Categories.OrderByDescending(x => x.CategoryID).ToList();

                    return View(liste);

                }
                else
                {
                    return RedirectToAction("AdminLogin", "Account");
                } //Buraası Yönlendirme KISMI
            }
            catch
            {

                return RedirectToAction("AdminLogin", "Account");
            }


        }
        [HttpGet]
        public ActionResult Ekle()
        {
            try
            {
                ViewBag.CurrentAdmin = User.Identity.Name;
                ViewBag.CurrentAdmin = Session["AdminName"];
                ViewBag.Rights = Session["Rights"];
                ViewBag.Info = null;

                int yetki = ViewBag.Rights;
                if (yetki > 0)
                {
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
        public ActionResult Ekle(Category kategori)
        {
            db.Categories.Add(kategori);
            try
            {
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
            ViewBag.CurrentAdmin = User.Identity.Name;
            ViewBag.CurrentAdmin = Session["AdminName"];
            ViewBag.Rights = Session["Rights"];
            ViewBag.Info = null;
            try
            {
                Category update = db.Categories.Find(id);
                ViewBag.Rights = Session["Rights"];

                int yetki = ViewBag.Rights;
                if (yetki > 0)
                {
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
        public ActionResult Guncelle(Category guncel)
        {
            db.Entry(db.Categories.Find(guncel.CategoryID)).CurrentValues.SetValues(guncel);
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
            Category silinecek = db.Categories.Find(id);
            db.Categories.Remove(silinecek);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
