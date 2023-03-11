using INSAATTaksitTakip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INSAATTaksitTakip.Controllers
{
    public class IsSaglıgıVeGuvenligiController : Controller
    {
        INSAATBITIRMEEntities2 db = new INSAATBITIRMEEntities2();
        // GET: IsSaglıgıVeGuvenligi
        public ActionResult Index()
        {
            var sayfa = db.TBLSAYFA.Where(s => s.ADI == "İŞ SAĞLIĞI VE GÜVENLİĞİ").SingleOrDefault();
            return View(sayfa);
        }
    }
}