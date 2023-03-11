using INSAATTaksitTakip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INSAATTaksitTakip.Controllers
{
    public class DevamEdenProjelerController : Controller
    {
        INSAATBITIRMEEntities2 db = new INSAATBITIRMEEntities2();
        // GET: DevamEdenProjeler
        public ActionResult Index()
        {

            var sayfa = db.TBLSAYFA.Where(s => s.ADI == "DEVAM EDEN PROJELER").SingleOrDefault();
            return View(sayfa);
        }
    }
}