using INSAATTaksitTakip.Models;
using PagedList;
using System.Linq;
using System.Web.Mvc;

namespace INSAATTaksitTakip.Yonetim
{
    public class GelirGiderController : Controller
    {
        INSAATBITIRMEEntities2 db = new INSAATBITIRMEEntities2();
        // GET: GelirGider
        public ActionResult Index(int sayfa = 1)
        {
            var degerler = db.TBLGELIR_GIDER.ToList().ToPagedList(sayfa, 4);
            if (Request["ara"] != null)
            {
                var kelime = Request["ara"].ToString();
                degerler = db.TBLGELIR_GIDER.Where(e => e.ACIKLAMA.Contains(kelime)).ToList().ToPagedList(sayfa, 4);
            }
            else
            {
                degerler = db.TBLGELIR_GIDER.ToList().ToPagedList(sayfa, 4);
            }
            return View(degerler);
        }

        public ActionResult KayitFormu(int id)
        {
            TBLGELIR_GIDER gg = new TBLGELIR_GIDER();
            if (id != -1)
            {
                gg = db.TBLGELIR_GIDER.Find(id);
            }
            var ggtip = db.TBLGG_TIPI.ToList();
            ViewData["ggtip"] = ggtip;
            return View(gg);
        }

        [HttpPost]
        public ActionResult KayitFormu(TBLGELIR_GIDER t)
        {
            if (!ModelState.IsValid)
            {
                return View(t);
            }
            else
            {

                if (t.GELIR_GIDER_REFNO == 0)
                {
                    // Kayıt

                    db.TBLGELIR_GIDER.Add(t);
                }
                else
                {
                    // Güncelle
                    db.Entry(t).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();
                var ggtip = db.TBLGG_TIPI.ToList();
                ViewData["ggtip"] = ggtip;
                return RedirectToAction("Index");
            }

        }

        public ActionResult Sil(int id)
        {
            var ap = db.TBLGELIR_GIDER.Find(id);
            db.TBLGELIR_GIDER.Remove(ap);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Ara(string txtAra)
        {
            return RedirectToAction("Index", new { ara = txtAra });
        }

    }
}