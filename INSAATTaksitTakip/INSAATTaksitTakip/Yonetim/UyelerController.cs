using INSAATTaksitTakip.Models;
using PagedList;
using System.Linq;
using System.Web.Mvc;

namespace INSAATTaksitTakip.Yonetim
{
    public class UyelerController : Controller
    {
        INSAATBITIRMEEntities2 db = new INSAATBITIRMEEntities2();
        // GET: Uyeler
        public ActionResult Index(int sayfa = 1)
        {
            var degerler = db.TBLUYELER.ToList().ToPagedList(sayfa,4);
            if (Request["ara"] != null)
            {
                var kelime = Request["ara"].ToString();
                degerler = db.TBLUYELER.Where(e => e.UYE_AD.Contains(kelime)).ToList().ToPagedList(sayfa,4);
            }
            else
            {
                degerler = db.TBLUYELER.ToList().ToPagedList(sayfa,4);
            }
            return View(degerler);
        }
        public ActionResult KayitFormu(int id)
        {
            TBLUYELER uye = new TBLUYELER();
            if (id != -1)
            {
                uye = db.TBLUYELER.Find(id);
            }
            var illiste = db.TBLSEHIRLER.ToList();
            var ilceliste = db.TBLILCELER.ToList();
            ViewData["il"] = illiste;
            ViewData["ilce"] = ilceliste;
            return View(uye);
        }
        [HttpPost]
        public ActionResult KayitFormu(TBLUYELER t)
        {
            if (t.SEHIR_REFNO == 0)
            {
                ModelState.AddModelError("Şehir", "Lütfen şehir seçiniz.");
            }
            if (t.ILCE_REFNO == 0)
            {
                ModelState.AddModelError("İlçe", "Lütfen ilçe seçiniz.");
            }
            if (!ModelState.IsValid)
            {
                return View(t);
            }
            else
            {

                if (t.UYE_REFNO == 0)
                {
                    // Kayıt

                    db.TBLUYELER.Add(t);
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
            var uye = db.TBLUYELER.Find(id);
            db.TBLUYELER.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Ara(string txtAra)
        {
            return RedirectToAction("Index", new { ara = txtAra });
        }


        public JsonResult Ilce(int sehirrefno)
        {
            var ilce = db.TBLILCELER.Where(k => k.SEHIR_REFNO == sehirrefno).ToList();
            var ilceler = ilce.Select(x => new { x.ILCE_REFNO, x.ILCE_ADI, x.SEHIR_REFNO }).ToList();
            return Json(ilceler, JsonRequestBehavior.AllowGet);
        }
    }
}