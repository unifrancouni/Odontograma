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
		[Route("Placagramalist/{nPlacagramaID?}")]
		[Route("Home/Placagramalist/{nPlacagramaID?}")]
		public async Task<IActionResult> Placagramalist()
		{

			// Create page object
			Placagrama_List = new _Placagrama_List(this);
			Placagrama_List.Cache = _cache;

			// Run the page
			return await Placagrama_List.Run();
		}

		// add
		[Route("Placagramaadd/{nPlacagramaID?}")]
		[Route("Home/Placagramaadd/{nPlacagramaID?}")]
		public async Task<IActionResult> Placagramaadd()
		{

			// Create page object
			Placagrama_Add = new _Placagrama_Add(this);

			// Run the page
			return await Placagrama_Add.Run();
		}

		// view
		[Route("Placagramaview/{nPlacagramaID?}")]
		[Route("Home/Placagramaview/{nPlacagramaID?}")]
		public async Task<IActionResult> Placagramaview()
		{

			// Create page object
			Placagrama_View = new _Placagrama_View(this);

			// Run the page
			return await Placagrama_View.Run();
		}

		// edit
		[Route("Placagramaedit/{nPlacagramaID?}")]
		[Route("Home/Placagramaedit/{nPlacagramaID?}")]
		public async Task<IActionResult> Placagramaedit()
		{

			// Create page object
			Placagrama_Edit = new _Placagrama_Edit(this);

			// Run the page
			return await Placagrama_Edit.Run();
		}

		// delete
		[Route("Placagramadelete/{nPlacagramaID?}")]
		[Route("Home/Placagramadelete/{nPlacagramaID?}")]
		public async Task<IActionResult> Placagramadelete()
		{

			// Create page object
			Placagrama_Delete = new _Placagrama_Delete(this);

			// Run the page
			return await Placagrama_Delete.Run();
		}
	}
}
