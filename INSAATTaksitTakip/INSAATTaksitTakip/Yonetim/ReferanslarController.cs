using INSAATTaksitTakip.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INSAATTaksitTakip.Yonetim
{
    public class ReferanslarController : Controller
    {
        INSAATBITIRMEEntities2 db = new INSAATBITIRMEEntities2();
        // GET: Referanslar
        public ActionResult Index(int sayfa = 1)
        {
            var r = db.TBLREFERANSLAR.ToList().ToPagedList(sayfa, 4);
            if (Request["ara"] != null)
            {
                var kelime = Request["ara"].ToString();
                r = db.TBLREFERANSLAR.Where(e => e.ACIKLAMA.Contains(kelime)).ToList().ToPagedList(sayfa, 4);
            }
            else
            {
                r = db.TBLREFERANSLAR.ToList().ToPagedList(sayfa, 4);
            }
            return View(r);
        }
        public ActionResult KayitFormu(int id)
        {
            TBLREFERANSLAR r = new TBLREFERANSLAR();
            if (id != -1)
            {
                r = db.TBLREFERANSLAR.Find(id);
            }
            return View(r);
        }

        [HttpPost]
        public ActionResult KayitFormu(TBLREFERANSLAR r)
        {
            if (!ModelState.IsValid)
            {
                return View(r);
            }
            else
            {

                if (r.REFERANS_REFNO == 0)
                {
                    // Kayıt

                    db.TBLREFERANSLAR.Add(r);
                }
                else
                {
                    // Güncelle
                    db.Entry(r).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

        }

        public ActionResult Sil(int id)
        {
            var r = db.TBLREFERANSLAR.Find(id);
            db.TBLREFERANSLAR.Remove(r);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Ara(string txtAra)
        {
            return RedirectToAction("Index", new { ara = txtAra });
        }
    }
}