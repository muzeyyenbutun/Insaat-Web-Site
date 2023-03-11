using INSAATTaksitTakip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INSAATBITIRME.Controllers
{
    public class MısyonController : Controller
    {
        INSAATBITIRMEEntities2 db = new INSAATBITIRMEEntities2();
        // GET: Misyon
        public ActionResult Index()
        {
            var sayfa = db.TBLSAYFA.Where(s => s.ADI == "MİSYON").SingleOrDefault();
            return View(sayfa);
        }
    }
}