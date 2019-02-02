using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIGECO.Controllers
{
    public class LayoutController : Controller
    {

        public PartialViewResult LeftSidebar()
        {
            //var db = new SIGECO.SIGECO_Entities();
            //var consulta = db.Menu.Select(c => c).ToList();
            return PartialView("~/Views/Shared/_left_sidebar.cshtml");
        }

    }
}