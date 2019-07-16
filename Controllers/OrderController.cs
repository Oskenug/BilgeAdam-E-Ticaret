using BACommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BACommerce.Controllers
{
    public class OrderController : Controller
    {
        BACommercesEntities1 db = new BACommercesEntities1();
        public ActionResult Index()
        {
            ViewBag.CurrentAdmin = User.Identity.Name;
            ViewBag.CurrentAdmin = Session["AdminName"];
            ViewBag.Rights = Session["Rights"];

            try
            {

                int yetki = ViewBag.Rights;
                if (yetki > 0)
                {
                    List<Order> list = db.Orders.OrderByDescending(x => x.OrderID).ToList();
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



        public ActionResult Sil(int id)
        {
            Order silinecek = db.Orders.Find(id);
            db.Orders.Remove(silinecek);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}