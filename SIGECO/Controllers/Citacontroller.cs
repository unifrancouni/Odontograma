// ASP.NET Maker 2019
// Copyright (c) 2019 e.World Technology Limited. All rights reserved.

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
using System.Collections.Generic;
using AspNetMaker2019.Models;
using static AspNetMaker2019.Models.prjSIGECO;

// Controllers
namespace AspNetMaker2019.Controllers
{

	// Partial class
	public partial class HomeController : Controller
	{

		// list
		[Route("Citalist/{nCitaID?}")]
		[Route("Home/Citalist/{nCitaID?}")]
		public async Task<IActionResult> Citalist()
		{

			// Create page object
			Cita_List = new _Cita_List(this);
			Cita_List.Cache = _cache;

			// Run the page
			return await Cita_List.Run();
		}

		// add
		[Route("Citaadd/{nCitaID?}")]
		[Route("Home/Citaadd/{nCitaID?}")]
		public async Task<IActionResult> Citaadd()
		{

			// Create page object
			Cita_Add = new _Cita_Add(this);

			// Run the page
			return await Cita_Add.Run();
		}

		// view
		[Route("Citaview/{nCitaID?}")]
		[Route("Home/Citaview/{nCitaID?}")]
		public async Task<IActionResult> Citaview()
		{

			// Create page object
			Cita_View = new _Cita_View(this);

			// Run the page
			return await Cita_View.Run();
		}

		// edit
		[Route("Citaedit/{nCitaID?}")]
		[Route("Home/Citaedit/{nCitaID?}")]
		public async Task<IActionResult> Citaedit()
		{

			// Create page object
			Cita_Edit = new _Cita_Edit(this);

			// Run the page
			return await Cita_Edit.Run();
		}

		// delete
		[Route("Citadelete/{nCitaID?}")]
		[Route("Home/Citadelete/{nCitaID?}")]
		public async Task<IActionResult> Citadelete()
		{

			// Create page object
			Cita_Delete = new _Cita_Delete(this);

			// Run the page
			return await Cita_Delete.Run();
		}
	}
}
