using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using INSAATTaksitTakip.Models;
using PagedList;
namespace INSAATTaksitTakip.Yonetim
{
    public class SayfaController : Controller
    {
        // GET: Sayfa
        INSAATBITIRMEEntities2 db = new INSAATBITIRMEEntities2();
        public ActionResult Index(int sayfa = 1)
        {
            var liste = db.TBLSAYFA.ToList().ToPagedList(sayfa, 4); ;
            if (Request["ara"] != null)
            {
                var txtAra = Request["ara"];
                liste = db.TBLSAYFA.Where(s => s.ADI.Contains(txtAra)).ToList().ToPagedList(sayfa, 4); ;
            }
            else
            {
                liste = db.TBLSAYFA.ToList().ToPagedList(sayfa, 4);
            }
            return View(liste);
        }
        public ActionResult Sil(int? id)
        {
            var s = db.TBLSAYFA.Find(id);
            db.TBLSAYFA.Remove(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Ara(string txtAra)
        {
            return RedirectToAction("Index", new { ara = txtAra });
        }
        [HttpPost]
        public ActionResult KayitFormu(TBLSAYFA s)
        {
            if (!ModelState.IsValid)
            {
                return View(s);
            }
            else
            {

                if (s.SAYFA_REFNO == 0)
                {
                    // Kayıt

                    db.TBLSAYFA.Add(s);
                }
                else
                {
                    // Güncelle
                    db.Entry(s).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

        }
        public ActionResult KayitFormu(int id)
        {
            TBLSAYFA s = new TBLSAYFA();
            if (id != -1)
            {
                s = db.TBLSAYFA.Find(id);
            }
            return View(s);
        }

    }
}