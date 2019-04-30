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
		[Route("Odontogramalist/{nOdontogramaID?}")]
		[Route("Home/Odontogramalist/{nOdontogramaID?}")]
		public async Task<IActionResult> Odontogramalist()
		{

			// Create page object
			Odontograma_List = new _Odontograma_List(this);
			Odontograma_List.Cache = _cache;

			// Run the page
			return await Odontograma_List.Run();
		}

		// add
		[Route("Odontogramaadd/{nOdontogramaID?}")]
		[Route("Home/Odontogramaadd/{nOdontogramaID?}")]
		public async Task<IActionResult> Odontogramaadd()
		{

			// Create page object
			Odontograma_Add = new _Odontograma_Add(this);

			// Run the page
			return await Odontograma_Add.Run();
		}

		// view
		[Route("Odontogramaview/{nOdontogramaID?}")]
		[Route("Home/Odontogramaview/{nOdontogramaID?}")]
		public async Task<IActionResult> Odontogramaview()
		{

			// Create page object
			Odontograma_View = new _Odontograma_View(this);

			// Run the page
			return await Odontograma_View.Run();
		}

		// edit
		[Route("Odontogramaedit/{nOdontogramaID?}")]
		[Route("Home/Odontogramaedit/{nOdontogramaID?}")]
		public async Task<IActionResult> Odontogramaedit()
		{

			// Create page object
			Odontograma_Edit = new _Odontograma_Edit(this);

			// Run the page
			return await Odontograma_Edit.Run();
		}

		// delete
		[Route("Odontogramadelete/{nOdontogramaID?}")]
		[Route("Home/Odontogramadelete/{nOdontogramaID?}")]
		public async Task<IActionResult> Odontogramadelete()
		{

			// Create page object
			Odontograma_Delete = new _Odontograma_Delete(this);

			// Run the page
			return await Odontograma_Delete.Run();
		}
	}
}
