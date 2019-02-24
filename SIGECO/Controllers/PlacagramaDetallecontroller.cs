// ASP.NET Maker 2019
// Copyright (c) e.World Technology Limited. All rights reserved.

using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using AspNetMaker2019.Models;
using static AspNetMaker2019.Models.prjSIGECO;
using Newtonsoft.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

// Controllers
namespace AspNetMaker2019.Controllers
{

	// Partial class
	public class PlacagramaDetalleController : Controller
	{

        public ActionResult List(int id)
		{
            MicroDB.MicroDB db = new MicroDB.MicroDB();

            //Para sacar el json de una consulta X, tool
            /*string strSQL2 = string.Format("select distinct s2.sDescripcion as simbolo1, s1.sDescripcion as simbolo2 "+
            "from Simbolo s1, Simbolo s2 "+
           " where s2.sDescripcion = 'diente_ausente' "+
           " and s1.sDescripcion not like '%abrev%'");
            var o2 = db.ExecuteReader(strSQL2);*/

            ViewBag.Id = id;
            ViewBag.nCodigoExpediente = "";
            ViewBag.NombrePaciente = "";
            ViewBag.sCedula = "";
            ViewBag.dFechaPlacagrama = "";

            string strSQL = string.Format("SELECT * FROM vwPlacagramaInfoPaciente WHERE nPlacagramaID = {0}", id);
            var o = db.ExecuteReaderList(strSQL);

            if (o != null)
            {
                if (o.Count > 0)
                {
                    DateTime dt = Convert.ToDateTime(o[0]["dFechaPlacagrama"]);

                    ViewBag.nCodigoExpediente = o[0]["nCodigoExpediente"];
                    ViewBag.NombrePaciente = o[0]["NombrePaciente"];
                    ViewBag.sCedula = o[0]["sCedula"];
                    ViewBag.dFechaPlacagrama = dt.ToString("dd/MM/yyyy");
                }
            }
            
            return View();
		}

        public class DetalleID
        {
            public string id;
        }

        [HttpPost]
        public ActionResult Detalle([FromBody] DetalleID id)
        {
            MicroDB.MicroDB db = new MicroDB.MicroDB();

            object detalle = db.ExecuteReader("select nPlacagramaID, nPlacagramaDetalleID, tipo, sNombreDiente, sDescripcion " +
                "from vwPlacagramaDetalle where nPlacagramaID=" + id.id);

            return Json(detalle);
        }


        [HttpPost]
        public ActionResult Simbolos()
        {
            MicroDB.MicroDB db = new MicroDB.MicroDB();

            object simbolos = db.ExecuteReader("Exec spGetSimbolos 1");

            return Json(simbolos);
        }
         
        public class Odontograma
        {
            public int oid;
            public int odi;
            public string d;
            public string nd;

            public Odontograma(int oid, int odi, string d, string nd)
            {
                this.oid = oid;
                this.odi = odi;
                this.d = d;
                this.nd = nd;
            }

        }

        public class JsonModel
        {
            public string oId;
            public string detail;
        }

        [HttpPost]
        public ActionResult SavePlacagramaDetalle([FromBody] JsonModel jsonModel)
        {

            MicroDB.MicroDB db = new MicroDB.MicroDB();

            int oids = (jsonModel!=null)?int.Parse(jsonModel.oId.ToString()):0;

            List<Odontograma> odontograma = new List<Odontograma>();

            var objects = JArray.Parse(jsonModel.detail); //Leer JSON que entra por POST
            foreach (JObject root in objects) //Recorrer JSON e insertarlos en el ArrayList
            {
                var oid = root.GetValue("nPlacagramaID");
                var odi = root.GetValue("nPlacagramaDetalleID");
                var d = root.GetValue("sDescripcion");
                var nd = root.GetValue("sNombreDiente");

                int odis = int.Parse(odi.ToString());
                string ds = d.ToString();
                string nds = nd.ToString();

                Odontograma o = new Odontograma(oids, odis, ds, nds);
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


            var consulta = db.ExecuteReaderList("select * from vwPlacagramaDetalle where nPlacagramaID="+oids);
            foreach (var i in consulta)
            {
                Odontograma item = odontograma.Where(c => c.d.Equals(i["sDescripcion"]) && c.nd.Equals(i["sNombreDiente"]) && c.odi == int.Parse(i["nPlacagramaDetalleID"].ToString())).FirstOrDefault();
                //Si existe en el array...
                if (item != null)
                {     
                    //Actualizar sNombreDiente en la BD con el odi especifico
                    string strSQL = string.Format("Exec spGrabarPlacagramaDetalle {0}, {1}, '{2}', '{3}', 0; ", item.oid, item.odi, item.nd, item.d);
                    db.ExecuteSqlCommand(strSQL);
                }
                else
                {
                    //Desactivar el simbolo con el odi especifico
                    string strSQL = string.Format("Exec spGrabarPlacagramaDetalle {0}, {1}, '{2}', '{3}', 1; ", i["nPlacagramaID"], i["nPlacagramaDetalleID"], i["sNombreDiente"], i["sDescripcion"]);
                    db.ExecuteSqlCommand(strSQL);
                }
            }

            //Recorrer arraylist
            foreach (var i in odontograma)
            {
                //Si no existe en la BD...
                if (consulta.Where(c => int.Parse(c["nPlacagramaDetalleID"].ToString()) == i.odi && c["sDescripcion"].Equals(i.d) && c["sNombreDiente"].Equals(i.nd)).ToList().Count == 0) {
                    //Insertar registro nuevo
                    string strSQL = string.Format("Exec spGrabarPlacagramaDetalle {0}, {1}, '{2}', '{3}', 0; ", i.oid, i.odi, i.nd, i.d);
                    db.ExecuteSqlCommand(strSQL);
                }
            }

            return Json(1);
        }


    }
}
