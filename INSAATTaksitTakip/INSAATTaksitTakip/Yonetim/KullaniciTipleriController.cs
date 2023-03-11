using INSAATTaksitTakip.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INSAATTaksitTakip.Yonetim
{
    public class KullaniciTipleriController : Controller
    {
        INSAATBITIRMEEntities2 db = new INSAATBITIRMEEntities2();
        // GET: KullaniciTipleri
        public ActionResult Index(int sayfa = 1)
        {
            var kt = db.TBLKULLANICITIPLERI.ToList().ToPagedList(sayfa, 4);
            if (Request["ara"] != null)
            {
                var kelime = Request["ara"].ToString();
                kt = db.TBLKULLANICITIPLERI.Where(e => e.KULLANICI_TIPI_ADI.Contains(kelime)).ToList().ToPagedList(sayfa, 4);
            }
            else
            {
                kt = db.TBLKULLANICITIPLERI.ToList().ToPagedList(sayfa, 4);
            }
            return View(kt);
        }
        public ActionResult KayitFormu(int id)
        {
            TBLKULLANICITIPLERI kt = new TBLKULLANICITIPLERI();
            if (id != -1)
            {
                kt = db.TBLKULLANICITIPLERI.Find(id);
            }
            return View(kt);
        }

        [HttpPost]
        public ActionResult KayitFormu(TBLKULLANICITIPLERI kt)
        {
            if (!ModelState.IsValid)
            {
                return View(kt);
            }
            else
            {

                if (kt.KULLANICI_TIPI_REFNO == 0)
                {
                    // Kayıt

                    db.TBLKULLANICITIPLERI.Add(kt);
                }
                else
                {
                    // Güncelle
                    db.Entry(kt).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

        }
        public ActionResult Sil(int id)
        {
            var kt = db.TBLKULLANICITIPLERI.Find(id);
            db.TBLKULLANICITIPLERI.Remove(kt);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Ara(string txtAra)
        {
            return RedirectToAction("Index", new { ara = txtAra });
        }
    }
}