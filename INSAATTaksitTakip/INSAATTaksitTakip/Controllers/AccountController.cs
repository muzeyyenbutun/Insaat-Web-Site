using INSAATTaksitTakip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;

namespace INSAATTaksitTakip.Controllers
{
    public class AccountController : BaseController
    {
        INSAATBITIRMEEntities2 db = new INSAATBITIRMEEntities2();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(TBLKULLANICILAR kul)
        {
            var data = db.TBLKULLANICILAR.FirstOrDefault(m => m.KULLANICI_ADI == kul.KULLANICI_ADI && m.KULLANICI_SIFRE == kul.KULLANICI_SIFRE);
            if (data!=null)
            {
                FormsAuthentication.SetAuthCookie(kul.KULLANICI_ADI,true);
                if (data.KULLNICI_TIPI_REFNO==1)
                {
                    return RedirectToAction("Index", "Uyeler");
                }
                else if (data.KULLNICI_TIPI_REFNO == 2)
                {
                    return RedirectToAction("Login");
                }
                return RedirectToAction("Login");
            }
            else
            {
                return RedirectToAction("Login");
                    
            }
            
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}