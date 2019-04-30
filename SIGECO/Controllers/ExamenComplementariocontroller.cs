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
		[Route("ExamenComplementariolist/{nExamenComplementarioID?}")]
		[Route("Home/ExamenComplementariolist/{nExamenComplementarioID?}")]
		public async Task<IActionResult> ExamenComplementariolist()
		{

			// Create page object
			ExamenComplementario_List = new _ExamenComplementario_List(this);
			ExamenComplementario_List.Cache = _cache;

			// Run the page
			return await ExamenComplementario_List.Run();
		}

		// add
		[Route("ExamenComplementarioadd/{nExamenComplementarioID?}")]
		[Route("Home/ExamenComplementarioadd/{nExamenComplementarioID?}")]
		public async Task<IActionResult> ExamenComplementarioadd()
		{

			// Create page object
			ExamenComplementario_Add = new _ExamenComplementario_Add(this);

			// Run the page
			return await ExamenComplementario_Add.Run();
		}

		// view
		[Route("ExamenComplementarioview/{nExamenComplementarioID?}")]
		[Route("Home/ExamenComplementarioview/{nExamenComplementarioID?}")]
		public async Task<IActionResult> ExamenComplementarioview()
		{

			// Create page object
			ExamenComplementario_View = new _ExamenComplementario_View(this);

			// Run the page
			return await ExamenComplementario_View.Run();
		}

		// edit
		[Route("ExamenComplementarioedit/{nExamenComplementarioID?}")]
		[Route("Home/ExamenComplementarioedit/{nExamenComplementarioID?}")]
		public async Task<IActionResult> ExamenComplementarioedit()
		{

			// Create page object
			ExamenComplementario_Edit = new _ExamenComplementario_Edit(this);

			// Run the page
			return await ExamenComplementario_Edit.Run();
		}

		// delete
		[Route("ExamenComplementariodelete/{nExamenComplementarioID?}")]
		[Route("Home/ExamenComplementariodelete/{nExamenComplementarioID?}")]
		public async Task<IActionResult> ExamenComplementariodelete()
		{

			// Create page object
			ExamenComplementario_Delete = new _ExamenComplementario_Delete(this);

			// Run the page
			return await ExamenComplementario_Delete.Run();
		}
	}
}
