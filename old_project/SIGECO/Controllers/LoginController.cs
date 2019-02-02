using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIGECO.Controllers
{
    public class LoginController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Logout()
        {
            var db = new SIGECO_Entities();
            string sEmail = Session["Usuario"].ToString();
            if(Session["Usuario"]!=null)
                db.Database.ExecuteSqlCommand(string.Format("Exec spLogout '{0}' ", sEmail));
            Session["Usuario"] = "";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Autenticar(string sEmail, string sToken)
        {
            var db = new SIGECO_Entities();
            var consulta = db.vwUsuario.Where(c => c.sEmail.Equals(sEmail)).Select(c => c).ToList();
            int result = 0;
            result = (consulta.Count > 0) ? 1 : 0;

            if (result == 1)
            {
                Session["Usuario"] = sEmail;

                if (consulta.FirstOrDefault().nSesionIniciada == 0)
                {
                    //guardar token, sesion=1
                    db.Database.ExecuteSqlCommand(string.Format("Exec spSetToken '{0}', '{1}' ", sEmail, sToken));
                }
                else
                {
                    //si no tiene token, sesion=0 y salir
                    db.Database.ExecuteSqlCommand(string.Format("Exec spLogout '{0}' ", sEmail));
                    return Json("http://localhost:58409/Login/Logout");
                }

                return Json("http://localhost:58409/Home/Index");
            }

            return Json("http://localhost:58409/Login/Index");
        }

    }
}