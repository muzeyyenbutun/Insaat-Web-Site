using INSAATTaksitTakip.Models;
using PagedList;
using System.Linq;
using System.Web.Mvc;

namespace INSAATTaksitTakip.Yonetim
{
    public class GelirGiderTipleriController : Controller
    {
        INSAATBITIRMEEntities2 db = new INSAATBITIRMEEntities2();
        // GET: GelirGiderTipleri
        public ActionResult Index(int sayfa = 1)
        {
            var degerler = db.TBLGG_TIPI.ToList().ToPagedList(sayfa, 4);
            if (Request["ara"] != null)
            {
                var kelime = Request["ara"].ToString();
                degerler = db.TBLGG_TIPI.Where(e => e.GG_TIPI_ADI.Contains(kelime)).ToList().ToPagedList(sayfa, 4);
            }
            else
            {
                degerler = db.TBLGG_TIPI.ToList().ToPagedList(sayfa, 4);
            }
            return View(degerler);
        }

        public ActionResult KayitFormu(int id)
        {
            TBLGG_TIPI ggt = new TBLGG_TIPI();
            if (id != -1)
            {
                ggt = db.TBLGG_TIPI.Find(id);
            }
            return View(ggt);
        }

        [HttpPost]
        public ActionResult KayitFormu(TBLGG_TIPI t)
        {
            if (!ModelState.IsValid)
            {
                return View(t);
            }
            else
            {

                if (t.GG_TIPI_REFNO == 0)
                {
                    // Kayıt

                    db.TBLGG_TIPI.Add(t);
                }
                else
                {
                    // Güncelle
                    db.Entry(t).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

        }

        public ActionResult Sil(int id)
        {
            var ggt = db.TBLGG_TIPI.Find(id);
            db.TBLGG_TIPI.Remove(ggt);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Ara(string txtAra)
        {
            return RedirectToAction("Index", new { ara = txtAra });
        }

    }
}