using INSAATTaksitTakip.Models;
using PagedList;
using System.Linq;
using System.Web.Mvc;

namespace INSAATTaksitTakip.Yonetim
{
    public class AcikPozisyonlarController : Controller
    {
        INSAATBITIRMEEntities2 db = new INSAATBITIRMEEntities2();
        // GET: AcikPozisyonlar
        public ActionResult Index(int sayfa = 1)
        {
            var degerler = db.TBLACIKPOZISYONLAR.ToList().ToPagedList(sayfa, 4);
            if (Request["ara"] != null)
            {
                var kelime = Request["ara"].ToString();
                degerler = db.TBLACIKPOZISYONLAR.Where(e => e.POZISYON_ADI.Contains(kelime)).ToList().ToPagedList(sayfa, 4);
            }
            else
            {
                degerler = db.TBLACIKPOZISYONLAR.ToList().ToPagedList(sayfa, 4);
            }
            return View(degerler);
        }

        public ActionResult KayitFormu(int id)
        {
            TBLACIKPOZISYONLAR ap = new TBLACIKPOZISYONLAR();
            if (id != -1)
            {
                ap = db.TBLACIKPOZISYONLAR.Find(id);
            }           
            return View(ap);
        }

        [HttpPost]
        public ActionResult KayitFormu(TBLACIKPOZISYONLAR t)
        {
            if (!ModelState.IsValid)
            {
                return View(t);
            }
            else
            {

                if (t.POZISYON_REFNO == 0)
                {
                    // Kayıt

                    db.TBLACIKPOZISYONLAR.Add(t);
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
            var ap = db.TBLACIKPOZISYONLAR.Find(id);
            db.TBLACIKPOZISYONLAR.Remove(ap);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Ara(string txtAra)
        {
            return RedirectToAction("Index", new { ara = txtAra });
        }
    }
}