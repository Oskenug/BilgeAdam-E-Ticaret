using BACommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BACommerce.Controllers
{
    public class UserController : Controller
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
                    List<User> list = db.Users.OrderByDescending(x => x.UserID).ToList();
                    return View(list);
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
        public ActionResult Ekle(User kullanici)
        {
            db.Users.Add(kullanici);
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
            try
            {
                ViewBag.CurrentAdmin = User.Identity.Name;
                ViewBag.CurrentAdmin = Session["AdminName"];
                ViewBag.Rights = Session["Rights"];

                int yetki = ViewBag.Rights;
                if (yetki > 0)
                {
                    ViewBag.Info = null;
                    User update = db.Users.Find(id);
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
        public ActionResult Guncelle(User guncel)
        {
            db.Entry(db.Users.Find(guncel.UserID)).CurrentValues.SetValues(guncel);
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
            User silinecek = db.Users.Find(id);
            db.Users.Remove(silinecek);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}