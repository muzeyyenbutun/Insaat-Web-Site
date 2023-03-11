using INSAATTaksitTakip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INSAATTaksitTakip.Controllers
{
    public class BaseController : Controller
    {
        INSAATBITIRMEEntities2 db = new INSAATBITIRMEEntities2();
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var name = filterContext.HttpContext.User.Identity.Name;
                var data = db.TBLKULLANICILAR.FirstOrDefault();
                var info = new TBLLOGIN {
                    LOGIN_FULLNAME = data.KULLANICI_ADI,
                    LOGIN_REFNO=data.KULLANICI_REFNO,
                    LOGIN_MAIL=data.MAIL
                };
                TempData["userInfo"] = info;

            }
            base.OnActionExecuted(filterContext);

        }
    }
}