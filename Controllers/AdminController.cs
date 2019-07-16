using BACommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;           

namespace BACommerce.Controllers
{
    public class AdminController : Controller
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
                    List<Admin> liste = db.Admins.OrderByDescending(x => x.AdminID).ToList();

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
        public ActionResult Ekle(Admin ad)
        {
            db.Admins.Add(ad);
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
                Admin update = db.Admins.Find(id);
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
        public ActionResult Guncelle(Admin guncel)
        {
            db.Entry(db.Admins.Find(guncel.AdminID)).CurrentValues.SetValues(guncel);
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
            Admin silinecek = db.Admins.Find(id);
            db.Admins.Remove(silinecek);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}