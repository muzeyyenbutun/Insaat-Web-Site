using INSAATTaksitTakip.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INSAATTaksitTakip.Yonetim
{
    public class KullanicilarController : Controller
    {
        INSAATBITIRMEEntities2 db = new INSAATBITIRMEEntities2();
        // GET: Kullanicilar
        public ActionResult Index(int sayfa = 1)
        {
            var k = db.TBLKULLANICILAR.ToList().ToPagedList(sayfa, 4);
            if (Request["ara"] != null)
            {
                var kelime = Request["ara"].ToString();
                k = db.TBLKULLANICILAR.Where(e => e.KULLANICI_ADI.Contains(kelime)).ToList().ToPagedList(sayfa, 4);
            }
            else
            {
                k = db.TBLKULLANICILAR.ToList().ToPagedList(sayfa, 4);
            }
            return View(k);
        }
        public ActionResult KayitFormu(int id)
        {
            TBLKULLANICILAR k = new TBLKULLANICILAR();
            if (id != -1)
            {
                k = db.TBLKULLANICILAR.Find(id);
            }
            var kultipi = db.TBLKULLANICITIPLERI.ToList();
            ViewData["kultipi"] = kultipi;
            return View(k);
        }

        [HttpPost]
        public ActionResult KayitFormu(TBLKULLANICILAR k)
        {
            if (!ModelState.IsValid)
            {
                return View(k);
            }
            else
            {

                if (k.KULLANICI_REFNO == 0)
                {
                    // Kayıt

                    db.TBLKULLANICILAR.Add(k);
                }
                else
                {
                    // Güncelle
                    db.Entry(k).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

        }
        public ActionResult Sil(int id)
        {
            var k = db.TBLKULLANICILAR.Find(id);
            db.TBLKULLANICILAR.Remove(k);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Ara(string txtAra)
        {
            return RedirectToAction("Index", new { ara = txtAra });
        }
    }
}