using BACommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BACommerce.Classes;            // Classes
using System.Web.Security;



namespace BACommerce.Controllers
{
    public class AccountController : Controller
    {
        // GET: Hesap
        BACommercesEntities1 db = new BACommercesEntities1();
        public ActionResult Login()
        {

            db.Users.ToList();
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Login(LoginVM model)
        {
            try { 
            if (ModelState.IsValid)
            {
                BACommercesEntities1 db = new BACommercesEntities1();

                var user = db.Users.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);
                Session["UserName"] = user.UserName;
               
                if (user != null)
                {

                    FormsAuthentication.SetAuthCookie(user.UserName, true);
                    return RedirectToAction("Index", "Home");
                }

            }
            }
            catch { ViewBag.Message = "Kullanıcı Adı veya Parola Yanlış."; }

          
            return View();


        }
        public ActionResult LogOut()
        {
            Session.Remove("UserName");
          
            Session.Clear();
            Session.Abandon();
            Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
            Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-10);
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");


        }
        public ActionResult Hata()
        {
            return View();
        }



        public ActionResult AdminLogin()
        {
            db.Admins.ToList();
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("AdminLogin", "Account");
            }
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult AdminLogin(AdminVM model)
        {try {if (ModelState.IsValid)
            {
                var admin = db.Admins.FirstOrDefault(x => x.AdminName == model.AdminName && x.Password == model.Password);
                Session["AdminName"] = admin.AdminName;
                Session["Rights"] = admin.Rights;
                if (admin != null)
                {

                    FormsAuthentication.SetAuthCookie(admin.AdminName, true);
                    return RedirectToAction("PanelIndex", "Home");
                }

            } }
            catch {ViewBag.Message = "Kullanıcı Adı veya Parola Yanlış."; }
            
            
            return View();


        }

        public ActionResult AdminLogOut()
        {
            Session.Remove("AdminName");
            Session.Remove("Rights");
            Session.Clear();
            Session.Abandon();
            Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
            Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-10);
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");


        }




    }
}