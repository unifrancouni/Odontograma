using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIGECO.Controllers
{
    public class PacienteController : Controller
    {

        public ActionResult Index()
        {
            var db = new SIGECO_Entities();
            var consulta = db.TableColumns
                .Where(c => c.TABLE_NAME.Equals("Paciente"))
                .Select(c => c).ToList();

            ViewBag.Title = "Pacientes";
            ViewBag.SubTitle = "Control de Pacientes";
            ViewBag.FormTitle = "Agregar Paciente";
            ViewBag.tblSchema = "dbo";
            ViewBag.tblName = "Paciente";

            return View("~/Views/GeneralForms/generalAdds.cshtml", consulta);
        }

    }
}