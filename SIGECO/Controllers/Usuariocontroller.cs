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
		[Route("Usuariolist/{nUsuarioId?}")]
		[Route("Home/Usuariolist/{nUsuarioId?}")]
		public async Task<IActionResult> Usuariolist()
		{

			// Create page object
			Usuario_List = new _Usuario_List(this);
			Usuario_List.Cache = _cache;

			// Run the page
			return await Usuario_List.Run();
		}

		// add
		[Route("Usuarioadd/{nUsuarioId?}")]
		[Route("Home/Usuarioadd/{nUsuarioId?}")]
		public async Task<IActionResult> Usuarioadd()
		{

			// Create page object
			Usuario_Add = new _Usuario_Add(this);

			// Run the page
			return await Usuario_Add.Run();
		}

		// view
		[Route("Usuarioview/{nUsuarioId?}")]
		[Route("Home/Usuarioview/{nUsuarioId?}")]
		public async Task<IActionResult> Usuarioview()
		{

			// Create page object
			Usuario_View = new _Usuario_View(this);

			// Run the page
			return await Usuario_View.Run();
		}

		// edit
		[Route("Usuarioedit/{nUsuarioId?}")]
		[Route("Home/Usuarioedit/{nUsuarioId?}")]
		public async Task<IActionResult> Usuarioedit()
		{

			// Create page object
			Usuario_Edit = new _Usuario_Edit(this);

			// Run the page
			return await Usuario_Edit.Run();
		}

		// delete
		[Route("Usuariodelete/{nUsuarioId?}")]
		[Route("Home/Usuariodelete/{nUsuarioId?}")]
		public async Task<IActionResult> Usuariodelete()
		{

			// Create page object
			Usuario_Delete = new _Usuario_Delete(this);

			// Run the page
			return await Usuario_Delete.Run();
		}
	}
}
