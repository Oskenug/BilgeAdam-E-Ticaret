using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BACommerce.Controllers
{
    using Models;
    using Tools;
    public class CartController : Controller
    {
        BACommercesEntities1 db = new BACommercesEntities1();

        public ActionResult SepeteEkle(int id)
        {
            ViewBag.CurrentUser = Session["UserName"];
            ////ViewBag.credits
            //return View();
           
            Cart mc = Session["sepet"] == null ? new Cart() : Session["sepet"] as Cart;

            var eklenecek = db.Products.Find(id);

            CartItem ct = new CartItem();
            ct.Id = eklenecek.ProductID;
            ct.ProductName = eklenecek.ProductName;
            ct.UnitPrice = Convert.ToDecimal(eklenecek.UnitPrice);
            ct.UnitsInStock = eklenecek.UnitInStock;
            ct.Quantity = 1;


            try
            {
                db.SaveChanges(); mc.AddCart(ct);
                Session["sepet"] = mc;
                ViewBag.bilgi = true;
                return View(db.Products.OrderByDescending(x => x.ProductID).ToList());
            }
            catch
            {
                ViewBag.bilgi = false;
            }




            return RedirectToAction("Index", "Home");
        }
        public ActionResult SepeteGit()
        {
            ViewBag.CurrentUser = Session["UserName"];
            if (Session["sepet"] != null)
            {
                Cart mc = Session["sepet"] as Cart;
                return View(mc.CartProductList);

            }

            else
            {

                return RedirectToAction("BosSepet", "Cart");

            }
        }

        public ActionResult SepetOnayla()
        {
            ViewBag.CurrentUser = Session["UserName"];
            Cart cart = Session["sepet"] as Cart;

            foreach (CartItem item in cart.CartProductList)
            {  
                Order od = new Order();
                od.AdminID = 1;
                od.CustomerID = 1;
                od.OrderDate = DateTime.Now;
                od.ProductName = item.ProductName;
                od.UnitPrice = Convert.ToInt32(item.UnitPrice);
                od.UnitInStock = Convert.ToInt32(item.UnitsInStock);

                db.Orders.Add(od);
                try
                {
                    db.SaveChanges();
                    Session["sepet"] = null;
                    ViewBag.bilgi = "Alışveriş tamamlanmıştır admin sayfasından sıpariş listelerini görüntüleyebilirisniz.";
                }
                catch
                {
                    ViewBag.bilgi = "Bir hatadan dolayı alışveriş tamamlanamamıştır.";
                }


            }

            return View();
        }
        public ActionResult SepettenSil(int id)
        {
            Cart mc = Session["sepet"] as Cart;
            mc.RemoveCart(id);
            return RedirectToAction("SepeteGit");
        }


        public ActionResult BosSepet()
        {
            ViewBag.CurrentUser = Session["UserName"];
            ViewBag.bilgi = "Sepetinizde ürün bulunmamaktadır.";
            return View();


        }

    }
}