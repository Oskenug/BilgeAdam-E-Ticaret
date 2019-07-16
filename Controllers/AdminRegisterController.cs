using BACommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BACommerce.Controllers
{
    public class AdminRegisterController : Controller
    {


        BACommercesEntities1 db = new BACommercesEntities1();
        // GET: Register
        public ActionResult Yonlendirilecek()
        {
            return View();
        }
        public ActionResult Kayit()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Kayit(Admin Admin)
        {
            db.Admins.Add(Admin);
            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("Yonlendirilecek", this);
        }


    }
}
