using BACommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BACommerce.Controllers
{
    using Models;
    using Tools;
   
    public class HomeController : Controller
    {

        public ActionResult PanelIndex()
        {
            try
            {

                ViewBag.CurrentAdmin = User.Identity.Name;
                ViewBag.CurrentAdmin = Session["AdminName"];
                ViewBag.Rights = Session["Rights"];
                int yetki = ViewBag.Rights;
                if (yetki > 0)
                {
                 

                    return View();

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

        BACommercesEntities1 db = new BACommercesEntities1();
        public ActionResult Index()
        {

            ViewBag.CurrentUser = Session["UserName"];
            ////ViewBag.credits
            //return View();
            return View(db.Products.OrderByDescending(x => x.ProductID).ToList());
        }

        public ActionResult Hakkimizda()
        {
            ViewBag.CurrentUser = Session["UserName"];
            return View();
        }


        public ActionResult İletisim()
        {
            ViewBag.CurrentUser = Session["UserName"];
           

            return View();
        }

        public ActionResult İndirimliUrunler()
        {
            ViewBag.CurrentUser = Session["UserName"];
            return View();
        }



       

     

        


    }




}