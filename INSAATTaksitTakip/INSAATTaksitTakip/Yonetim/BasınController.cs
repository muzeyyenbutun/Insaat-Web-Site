using INSAATTaksitTakip.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INSAATTaksitTakip.Yonetim
{
    public class BasınController : Controller
    {
        INSAATBITIRMEEntities2 db = new INSAATBITIRMEEntities2();
        // GET: Basın
        public ActionResult Index(int sayfa = 1)
        {
            var bs = db.TBLBASIN.ToList().ToPagedList(sayfa, 4);
            if (Request["ara"] != null)
            {
                var kelime = Request["ara"].ToString();
                bs = db.TBLBASIN.Where(e => e.BASLIK.Contains(kelime)).ToList().ToPagedList(sayfa, 4);
            }
            else
            {
                bs = db.TBLBASIN.ToList().ToPagedList(sayfa, 4);
            }
            return View(bs);
        }

        public ActionResult KayitFormu(int id)
        {
            TBLBASIN bs = new TBLBASIN();
            if (id != -1)
            {
                bs = db.TBLBASIN.Find(id);
            }
            return View(bs);
        }

        [HttpPost]
        public ActionResult KayitFormu(TBLBASIN bs)
        {
            if (!ModelState.IsValid)
            {
                return View(bs);
            }
            else
            {

                if (bs.BASIN_REFNO == 0)
                {
                    // Kayıt

                    db.TBLBASIN.Add(bs);
                }
                else
                {
                    // Güncelle
                    db.Entry(bs).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

        }

        public ActionResult Sil(int id)
        {
            var bs = db.TBLBASIN.Find(id);
            db.TBLBASIN.Remove(bs);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Ara(string txtAra)
        {
            return RedirectToAction("Index", new { ara = txtAra });
        }
    }
}
