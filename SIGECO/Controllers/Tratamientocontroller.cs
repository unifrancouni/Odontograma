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
		[Route("Tratamientolist/{nTratamientoID?}")]
		[Route("Home/Tratamientolist/{nTratamientoID?}")]
		public async Task<IActionResult> Tratamientolist()
		{

			// Create page object
			Tratamiento_List = new _Tratamiento_List(this);
			Tratamiento_List.Cache = _cache;

			// Run the page
			return await Tratamiento_List.Run();
		}

		// add
		[Route("Tratamientoadd/{nTratamientoID?}")]
		[Route("Home/Tratamientoadd/{nTratamientoID?}")]
		public async Task<IActionResult> Tratamientoadd()
		{

			// Create page object
			Tratamiento_Add = new _Tratamiento_Add(this);

			// Run the page
			return await Tratamiento_Add.Run();
		}

		// view
		[Route("Tratamientoview/{nTratamientoID?}")]
		[Route("Home/Tratamientoview/{nTratamientoID?}")]
		public async Task<IActionResult> Tratamientoview()
		{

			// Create page object
			Tratamiento_View = new _Tratamiento_View(this);

			// Run the page
			return await Tratamiento_View.Run();
		}

		// edit
		[Route("Tratamientoedit/{nTratamientoID?}")]
		[Route("Home/Tratamientoedit/{nTratamientoID?}")]
		public async Task<IActionResult> Tratamientoedit()
		{

			// Create page object
			Tratamiento_Edit = new _Tratamiento_Edit(this);

			// Run the page
			return await Tratamiento_Edit.Run();
		}

		// delete
		[Route("Tratamientodelete/{nTratamientoID?}")]
		[Route("Home/Tratamientodelete/{nTratamientoID?}")]
		public async Task<IActionResult> Tratamientodelete()
		{

			// Create page object
			Tratamiento_Delete = new _Tratamiento_Delete(this);

			// Run the page
			return await Tratamiento_Delete.Run();
		}
	}
}
