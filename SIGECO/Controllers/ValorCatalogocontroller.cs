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
		[Route("ValorCatalogolist/{nValorCatalogoID?}")]
		[Route("Home/ValorCatalogolist/{nValorCatalogoID?}")]
		public async Task<IActionResult> ValorCatalogolist()
		{

			// Create page object
			ValorCatalogo_List = new _ValorCatalogo_List(this);
			ValorCatalogo_List.Cache = _cache;

			// Run the page
			return await ValorCatalogo_List.Run();
		}

		// add
		[Route("ValorCatalogoadd/{nValorCatalogoID?}")]
		[Route("Home/ValorCatalogoadd/{nValorCatalogoID?}")]
		public async Task<IActionResult> ValorCatalogoadd()
		{

			// Create page object
			ValorCatalogo_Add = new _ValorCatalogo_Add(this);

			// Run the page
			return await ValorCatalogo_Add.Run();
		}

		// view
		[Route("ValorCatalogoview/{nValorCatalogoID?}")]
		[Route("Home/ValorCatalogoview/{nValorCatalogoID?}")]
		public async Task<IActionResult> ValorCatalogoview()
		{

			// Create page object
			ValorCatalogo_View = new _ValorCatalogo_View(this);

			// Run the page
			return await ValorCatalogo_View.Run();
		}

		// edit
		[Route("ValorCatalogoedit/{nValorCatalogoID?}")]
		[Route("Home/ValorCatalogoedit/{nValorCatalogoID?}")]
		public async Task<IActionResult> ValorCatalogoedit()
		{

			// Create page object
			ValorCatalogo_Edit = new _ValorCatalogo_Edit(this);

			// Run the page
			return await ValorCatalogo_Edit.Run();
		}

		// delete
		[Route("ValorCatalogodelete/{nValorCatalogoID?}")]
		[Route("Home/ValorCatalogodelete/{nValorCatalogoID?}")]
		public async Task<IActionResult> ValorCatalogodelete()
		{

			// Create page object
			ValorCatalogo_Delete = new _ValorCatalogo_Delete(this);

			// Run the page
			return await ValorCatalogo_Delete.Run();
		}
	}
}
