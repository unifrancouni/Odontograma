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
		[Route("Periodontogramalist/{nPeriodontogramaID?}")]
		[Route("Home/Periodontogramalist/{nPeriodontogramaID?}")]
		public async Task<IActionResult> Periodontogramalist()
		{

			// Create page object
			Periodontograma_List = new _Periodontograma_List(this);
			Periodontograma_List.Cache = _cache;

			// Run the page
			return await Periodontograma_List.Run();
		}

		// add
		[Route("Periodontogramaadd/{nPeriodontogramaID?}")]
		[Route("Home/Periodontogramaadd/{nPeriodontogramaID?}")]
		public async Task<IActionResult> Periodontogramaadd()
		{

			// Create page object
			Periodontograma_Add = new _Periodontograma_Add(this);

			// Run the page
			return await Periodontograma_Add.Run();
		}

		// view
		[Route("Periodontogramaview/{nPeriodontogramaID?}")]
		[Route("Home/Periodontogramaview/{nPeriodontogramaID?}")]
		public async Task<IActionResult> Periodontogramaview()
		{

			// Create page object
			Periodontograma_View = new _Periodontograma_View(this);

			// Run the page
			return await Periodontograma_View.Run();
		}

		// edit
		[Route("Periodontogramaedit/{nPeriodontogramaID?}")]
		[Route("Home/Periodontogramaedit/{nPeriodontogramaID?}")]
		public async Task<IActionResult> Periodontogramaedit()
		{

			// Create page object
			Periodontograma_Edit = new _Periodontograma_Edit(this);

			// Run the page
			return await Periodontograma_Edit.Run();
		}

		// delete
		[Route("Periodontogramadelete/{nPeriodontogramaID?}")]
		[Route("Home/Periodontogramadelete/{nPeriodontogramaID?}")]
		public async Task<IActionResult> Periodontogramadelete()
		{

			// Create page object
			Periodontograma_Delete = new _Periodontograma_Delete(this);

			// Run the page
			return await Periodontograma_Delete.Run();
		}
	}
}
