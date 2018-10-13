using Newtonsoft.Json.Linq;
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
        public ActionResult Simbolos()
        {
            var db = new SIGECO_Entities();
            var consulta = db.spGetSimbolos()
                .Select(c => c).ToList();
            return Json(consulta, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult OdontogramaDetalle(int id)
        {
            var db = new SIGECO_Entities();
            var consulta = db.vwOdontogramaDetalle
                .Select(c => new { c.nOdontogramaDetalleID, c.tipo, c.sNombreDiente, c.sDescripcion }).ToList();
            return Json(consulta, JsonRequestBehavior.AllowGet);
        }

        public class Odontograma
        {
            public int odi;
            public string d;
            public string nd;

            public Odontograma(int odi, string d, string nd)
            {
                this.odi = odi;
                this.d = d;
                this.nd = nd;
            }

        }

        [HttpPost]
        public ActionResult SaveOdontogramaDetalle(string json)
        {
            var db = new SIGECO_Entities();
            

            List<Odontograma> odontograma = new List<Odontograma>();

            var objects = JArray.Parse(json); //Leer JSON que entra por POST
            foreach (JObject root in objects) //Recorrer JSON e insertarlos en el ArrayList
            {

                var odi = root.GetValue("nOdontogramaDetalleID");
                var d = root.GetValue("sDescripcion");
                var nd = root.GetValue("sNombreDiente");

                int odis = int.Parse(odi.ToString());
                string ds = d.ToString();
                string nds = nd.ToString();

                Odontograma o = new Odontograma(odis, ds, nds);
                odontograma.Add(o);
                
            }

            // ALGORITMO GENERAL
            //Los que vengan con nOdontogramaDetalleID: 0, insert
            //Los que vengan con nOdontogramaDetalleID: x, update
            //Los que no vengan, pero estén en la BD: logical delete

            // ALGORITMO EN C# :
            // 1- Recorrer lista de simbolos SQL de odontogramadetalle (active=1)
            // 2- Si el id existe en el array, actualizar el diente del arraylist hacia la BD
            // 3- Si el id solo existe en la BD, eliminar el registro logicamente (set active=0)
            // 4- Recorrer aparte los del arraylist e insertarlos si no existen en la BD
            // 5- No puede pasar que un registro oid!=0 este en el arraylist y no en la BD, 
            //    porque para existir en el arraylist con un id, tuvo que extraerse de la BD con anterioridad.
            //    Sin embargo, para evitar cualquier inconsistencia, se creará un nuevo id para este.


            var consulta = db.vwOdontogramaDetalle.Select(c => c).ToList();
            foreach (var i in consulta)
            {
                Odontograma item = odontograma.Where(c => c.d.Equals(i.sDescripcion) && c.nd.Equals(i.sNombreDiente) && c.odi == i.nOdontogramaDetalleID).FirstOrDefault();
                //Si existe en el array...
                if (item != null)
                {
                    //Actualizar sNombreDiente en la BD con el odi especifico
                    string strSQL = string.Format("Exec spGrabarOdontogramaDetalle {0}, '{1}', '{2}', 0; ", item.odi, item.nd, item.d);
                    db.Database.ExecuteSqlCommand(strSQL);
                }
                else
                {
                    //Desactivar el simbolo con el odi especifico
                    string strSQL = string.Format("Exec spGrabarOdontogramaDetalle {0}, '{1}', '{2}', 1; ", i.nOdontogramaDetalleID, i.sNombreDiente, i.sDescripcion);
                    db.Database.ExecuteSqlCommand(strSQL);
                }
            }

            //Recorrer arraylist
            foreach (var i in odontograma)
            {
                //Si no existe en la BD...
                if (consulta.Where(c => c.nOdontogramaDetalleID == i.odi && c.sDescripcion.Equals(i.d) && c.sNombreDiente.Equals(i.nd)).ToList().Count == 0) {
                    //Insertar registro nuevo
                    string strSQL = string.Format("Exec spGrabarOdontogramaDetalle {0}, '{1}', '{2}', 0; ", i.odi, i.nd, i.d);
                    db.Database.ExecuteSqlCommand(strSQL);
                }
            }

            return Json(1);
        }

    }
}