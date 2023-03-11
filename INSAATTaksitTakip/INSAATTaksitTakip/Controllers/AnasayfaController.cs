using INSAATTaksitTakip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INSAATTaksitTakip.Controllers
{
    public class AnasayfaController : Controller
    {
        INSAATBITIRMEEntities2 db = new INSAATBITIRMEEntities2();
        // GET: Anasayfa
        public ActionResult Index()
        {
            var sayfa = db.TBLSAYFA.Where(s => s.ADI == "ANASAYFA").SingleOrDefault();
            return View(sayfa);
        }
    }
}