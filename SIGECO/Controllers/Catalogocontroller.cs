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
		[Route("Catalogolist/{nCatalogoID?}")]
		[Route("Home/Catalogolist/{nCatalogoID?}")]
		public async Task<IActionResult> Catalogolist()
		{

			// Create page object
			Catalogo_List = new _Catalogo_List(this);
			Catalogo_List.Cache = _cache;

			// Run the page
			return await Catalogo_List.Run();
		}

		// add
		[Route("Catalogoadd/{nCatalogoID?}")]
		[Route("Home/Catalogoadd/{nCatalogoID?}")]
		public async Task<IActionResult> Catalogoadd()
		{

			// Create page object
			Catalogo_Add = new _Catalogo_Add(this);

			// Run the page
			return await Catalogo_Add.Run();
		}

		// view
		[Route("Catalogoview/{nCatalogoID?}")]
		[Route("Home/Catalogoview/{nCatalogoID?}")]
		public async Task<IActionResult> Catalogoview()
		{

			// Create page object
			Catalogo_View = new _Catalogo_View(this);

			// Run the page
			return await Catalogo_View.Run();
		}

		// edit
		[Route("Catalogoedit/{nCatalogoID?}")]
		[Route("Home/Catalogoedit/{nCatalogoID?}")]
		public async Task<IActionResult> Catalogoedit()
		{

			// Create page object
			Catalogo_Edit = new _Catalogo_Edit(this);

			// Run the page
			return await Catalogo_Edit.Run();
		}

		// delete
		[Route("Catalogodelete/{nCatalogoID?}")]
		[Route("Home/Catalogodelete/{nCatalogoID?}")]
		public async Task<IActionResult> Catalogodelete()
		{

			// Create page object
			Catalogo_Delete = new _Catalogo_Delete(this);

			// Run the page
			return await Catalogo_Delete.Run();
		}
	}
}
