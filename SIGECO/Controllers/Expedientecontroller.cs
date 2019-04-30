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
		[Route("Expedientelist/{nExpedienteID?}")]
		[Route("Home/Expedientelist/{nExpedienteID?}")]
		public async Task<IActionResult> Expedientelist()
		{

			// Create page object
			Expediente_List = new _Expediente_List(this);
			Expediente_List.Cache = _cache;

			// Run the page
			return await Expediente_List.Run();
		}

		// add
		[Route("Expedienteadd/{nExpedienteID?}")]
		[Route("Home/Expedienteadd/{nExpedienteID?}")]
		public async Task<IActionResult> Expedienteadd()
		{

			// Create page object
			Expediente_Add = new _Expediente_Add(this);

			// Run the page
			return await Expediente_Add.Run();
		}

		// view
		[Route("Expedienteview/{nExpedienteID?}")]
		[Route("Home/Expedienteview/{nExpedienteID?}")]
		public async Task<IActionResult> Expedienteview()
		{

			// Create page object
			Expediente_View = new _Expediente_View(this);

			// Run the page
			return await Expediente_View.Run();
		}

		// edit
		[Route("Expedienteedit/{nExpedienteID?}")]
		[Route("Home/Expedienteedit/{nExpedienteID?}")]
		public async Task<IActionResult> Expedienteedit()
		{

			// Create page object
			Expediente_Edit = new _Expediente_Edit(this);

			// Run the page
			return await Expediente_Edit.Run();
		}

		// delete
		[Route("Expedientedelete/{nExpedienteID?}")]
		[Route("Home/Expedientedelete/{nExpedienteID?}")]
		public async Task<IActionResult> Expedientedelete()
		{

			// Create page object
			Expediente_Delete = new _Expediente_Delete(this);

			// Run the page
			return await Expediente_Delete.Run();
		}
	}
}
