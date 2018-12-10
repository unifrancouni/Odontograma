using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace SIGECO.Controllers
{
    public class GeneralController : Controller
    {
        [HttpPost]
        public ActionResult GetComboList(string sSelectName, string sFormName)
        {
            /*La variable sSelectName es igual al nombre del campo FK 
             * y este a su vez igual al nombre del catálogo de tabla Catalogo.
             * Para los que no usan ValoCatalogo Ej: nPacienteID, con la tabla sti.TableColumns
             * se puede extraer el nombre de la tabla a la que hace referencia, y así poder
             * listar los valores correspondientes.
             * La variable formName distingue la tabla para no confundir el campo FK, con el PK
             * de la tabla padre.
             */
            var db = new SIGECO_Entities();
            var consulta = db.spListarCatalogoPorCampoFK(sSelectName, sFormName);
            return Json(consulta, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Save(string jsonValores)
        {
            /*
             * JSON KeyValue Pairs of the Form
             */
            var db = new SIGECO_Entities();

            string parsedJson = "";
            int i = 0;

            JArray a = JArray.Parse(jsonValores);
            foreach (JObject o in a.Children<JObject>())
            {
                foreach (JProperty p in o.Properties())
                {
                    string val = (string)p.Value;
                    parsedJson += (val.Equals(""))?"NULL":val;
                    if (i%2 == 0)
                    {
                        parsedJson += ";";
                    }
                    i++;
                }
                parsedJson += "$";
            }

            string strSQL = string.Format("Exec spGenerateExecuteInsertStatement '{0}' ", parsedJson);

            db.Database.ExecuteSqlCommand(strSQL);

            return Json(parsedJson);
        }

    }
}