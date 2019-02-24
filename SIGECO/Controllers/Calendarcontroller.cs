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
	public class CalendarController : Controller
	{

        public ActionResult Index()
		{
            return View();
		}

        [HttpPost]
        public ActionResult DetalleCitas()
        {
            MicroDB.MicroDB db = new MicroDB.MicroDB();

            string strSQL = string.Format("SELECT * FROM vwCita");
            var o = db.ExecuteReader(strSQL);

            return Json(o);
        }
    }
}
