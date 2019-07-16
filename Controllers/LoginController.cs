using BACommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace BACommerce.Controllers
{
    [Authorize]
    public class LoginController : Controller
    {
        BACommercesEntities1 db = new BACommercesEntities1();
        public ActionResult LoginIndex()
        {
            string deger = User.Identity.Name;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult PanelIndex()
        {
            string deger = User.Identity.Name;
            return RedirectToAction("Index", "Home");
        }
    }
}