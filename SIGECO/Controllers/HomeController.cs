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
            var consulta = db.vwOdontogramaDetalle
                .Select(c => new { c.nOdontogramaDetalleID, c.tipo, c.sNombreDiente, c.sDescripcion }).ToList();
            return Json(consulta, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveOdontogramaDetalle(int id, JsonResult json)
        {
            var db = new SIGECO_Entities();
            //Leer JSON que entra por POST

            //Los que vengan con nOdontogramaDetalleID: 0, insert
            //Los que vengan con nOdontogramaDetalleID: x, update
            //Los que no vengan, pero estén en la BD: logical delete

            return Json(0);
        }

    }
}