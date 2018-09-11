using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIGECO.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Simbolos(int id)
        {
            var db = new SIGECO_Entities();
            var consulta = db.vwSimboloDiente
                .Select(c => new { c.sNombreDiente, c.sDescripcion }).ToList();
            return Json(consulta, JsonRequestBehavior.AllowGet);
        }

    }
}