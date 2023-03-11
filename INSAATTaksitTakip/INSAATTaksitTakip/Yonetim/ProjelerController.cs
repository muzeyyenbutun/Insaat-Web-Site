using INSAATTaksitTakip.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INSAATTaksitTakip.Yonetim
{
    public class ProjelerController : Controller
    {
        INSAATBITIRMEEntities2 db = new INSAATBITIRMEEntities2();
        // GET: Projeler
        public ActionResult Index(int sayfa=1)
        {
            var liste = db.TBLPROJELER.ToList().ToPagedList(sayfa, 4); ;
            if (Request["ara"] != null)
            {
                var txtAra = Request["ara"];
                liste = db.TBLPROJELER.Where(s => s.PROJE_ADI.Contains(txtAra)).ToList().ToPagedList(sayfa, 4); ;
            }
            return View(liste);
        }
        public ActionResult Sil(int id)
        {
            var p = db.TBLPROJELER.Find(id);
            db.TBLPROJELER.Remove(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Ara(string txtAra)
        {
            return RedirectToAction("Index", new { ara = txtAra });
        }
        [HttpPost]
        public ActionResult KayitFormu(TBLPROJELER p)
        {
            if (!ModelState.IsValid)
            {
                return View(p);
            }
            else
            {

                if (p.PROJE_REFNO == 0)
                {
                    // Kayıt

                    db.TBLPROJELER.Add(p);
                }
                else
                {
                    // Güncelle
                    db.Entry(p).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

        }
        public ActionResult KayitFormu(int id)
        {
            TBLPROJELER p = new TBLPROJELER();
            if (id != -1)
            {
                p = db.TBLPROJELER.Find(id);
            }
            var sehir = db.TBLSEHIRLER.ToList();
            ViewData["sehir"] = sehir;
            var ılce = db.TBLILCELER.ToList();
            ViewData["ılce"] = ılce;
            return View(p);
        }
        [HttpPost]
        public JsonResult IlIlce(int? ilID, string tip)
        {

            List<SelectListItem> sonuc = new List<SelectListItem>();
            //bu işlem başarılı bir şekilde gerçekleşti mi onun kontrolunnü yapıyorum
            bool basariliMi = true;
            try
            {
                switch (tip)
                {
                    case "ilGetir":
                        //veritabanımızdaki iller tablomuzdan illerimizi sonuc değişkenimze atıyoruz
                        foreach (var il in db.TBLSEHIRLER.ToList())
                        {
                            sonuc.Add(new SelectListItem
                            {
                                Text = il.SEHIR_ADI,
                                Value = il.SEHIR_REFNO.ToString()
                            });
                        }
                        break;
                    case "ilceGetir":
                        //ilcelerimizi getireceğiz ilimizi selecten seçilen ilID sine göre 
                        foreach (var ilce in db.TBLILCELER.Where(il => il.SEHIR_REFNO == ilID).ToList())
                        {
                            sonuc.Add(new SelectListItem
                            {
                                Text = ilce.ILCE_ADI,
                                Value = ilce.ILCE_REFNO.ToString()
                            });
                        }
                        break;

                    default:
                        break;

                }
            }
            catch (Exception)
            {
                //hata ile karşılaşırsak buraya düşüyor
                basariliMi = false;
                sonuc = new List<SelectListItem>();
                sonuc.Add(new SelectListItem
                {
                    Text = "Bir hata oluştu :(",
                    Value = "Default"
                });

            }
            //Oluşturduğum sonucları json olarak geriye gönderiyorum
            return Json(new { ok = basariliMi, text = sonuc });
        }
      [HttpPost]
      [ValidateAntiForgeryToken]
     public ActionResult ResimYukle(TBLPROJELER Medya,HttpPostedFileBase dosya)
        {
            if (dosya!=null)
            {
                string ResimAdi = System.IO.Path.GetFileName(dosya.FileName);
                string adres = Server.MapPath("~/ProjeResimleri/"+ResimAdi);
                dosya.SaveAs(adres);
                Medya.MEDYA = Request.Form["MEDYA"];
                Medya.MEDYA = ResimAdi;
            }
            if (ModelState.IsValid)
            {
                db.TBLPROJELER.Add(Medya);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Medya);
        }
    }
}
