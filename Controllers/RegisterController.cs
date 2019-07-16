using BACommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BACommerce.Controllers
{
    public class RegisterController : Controller
    {

        BACommercesEntities1 db = new BACommercesEntities1();
     
        public ActionResult Yonlendirilecek()
        {
            return View();
        }
        public ActionResult Kayit()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Kayit(User Kullanici)
        {
           
            if (ModelState.IsValid)
            {
                try
                {
                    db.Users.Add(Kullanici);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    ViewBag.Bilgi = "Lütfen zorunlu alanları doldurunuz.";
                    return View();
                }
                return RedirectToAction("Yonlendirilecek","Register");
            }
            return View();

        }


    }
}