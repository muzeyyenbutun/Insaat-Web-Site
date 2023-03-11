using INSAATTaksitTakip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INSAATTaksitTakip.Yonetim
{
    public class AdminLoginController : Controller
    {
        INSAATBITIRMEEntities2 db = new INSAATBITIRMEEntities2();
        // GET: AdminLogin
        public ActionResult Index()
        {
            return View();
        }
    }
}