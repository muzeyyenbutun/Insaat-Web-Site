using INSAATTaksitTakip.Models;
using PagedList;
using System.Linq;
using System.Web.Mvc;

namespace INSAATTaksitTakip.Yonetim
{
    public class GenelBasvuruController : Controller
    {
        INSAATBITIRMEEntities2 db = new INSAATBITIRMEEntities2();
        // GET: GenelBasvuru
        public ActionResult Index(int sayfa = 1)
        {
            var degerler = db.TBLGENELBASVURU.ToList().ToPagedList(sayfa, 4);
            if (Request["ara"] != null)
            {
                var kelime = Request["ara"].ToString();
                degerler = db.TBLGENELBASVURU.Where(e => e.BASVURAN_OKUL.Contains(kelime)).ToList().ToPagedList(sayfa, 4);
            }
            else
            {
                degerler = db.TBLGENELBASVURU.ToList().ToPagedList(sayfa, 4);
            }
            return View(degerler);
        }

        public ActionResult Sil(int id)
        {
            var gb = db.TBLGENELBASVURU.Find(id);
            db.TBLGENELBASVURU.Remove(gb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Ara(string txtAra)
        {
            return RedirectToAction("Index", new { ara = txtAra });
        }
    }
}