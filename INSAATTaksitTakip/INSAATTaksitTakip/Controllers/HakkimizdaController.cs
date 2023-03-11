using INSAATTaksitTakip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using INSAATTaksitTakip;

namespace INSAATBITIRME.Controllers
{
    public class HakkimizdaController : Controller
    {
        INSAATBITIRMEEntities2 db = new INSAATBITIRMEEntities2();
        // GET: Hakkimizda
        public ActionResult Index()
        {
            var sayfa = db.TBLSAYFA.Where(s => s.ADI == "HAKKIMIZDA").SingleOrDefault();
            return View(sayfa);
        }
    }
}