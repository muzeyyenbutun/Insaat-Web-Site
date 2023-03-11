using INSAATTaksitTakip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INSAATBITIRME.Controllers
{
    public class YonetimKuruluController : Controller
    {
        INSAATBITIRMEEntities2 db = new INSAATBITIRMEEntities2();
        // GET: YonetimKurulu
        public ActionResult Index()
        {
            var sayfa = db.TBLSAYFA.Where(s => s.ADI == "YÖNETİM KURULU").SingleOrDefault();
            return View(sayfa);
        }
    }
}