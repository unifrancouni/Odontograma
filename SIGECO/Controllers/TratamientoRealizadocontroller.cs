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
		[Route("TratamientoRealizadolist/{nTratamientoRealizadoID?}")]
		[Route("Home/TratamientoRealizadolist/{nTratamientoRealizadoID?}")]
		public async Task<IActionResult> TratamientoRealizadolist()
		{

			// Create page object
			TratamientoRealizado_List = new _TratamientoRealizado_List(this);
			TratamientoRealizado_List.Cache = _cache;

			// Run the page
			return await TratamientoRealizado_List.Run();
		}

		// add
		[Route("TratamientoRealizadoadd/{nTratamientoRealizadoID?}")]
		[Route("Home/TratamientoRealizadoadd/{nTratamientoRealizadoID?}")]
		public async Task<IActionResult> TratamientoRealizadoadd()
		{

			// Create page object
			TratamientoRealizado_Add = new _TratamientoRealizado_Add(this);

			// Run the page
			return await TratamientoRealizado_Add.Run();
		}

		// view
		[Route("TratamientoRealizadoview/{nTratamientoRealizadoID?}")]
		[Route("Home/TratamientoRealizadoview/{nTratamientoRealizadoID?}")]
		public async Task<IActionResult> TratamientoRealizadoview()
		{

			// Create page object
			TratamientoRealizado_View = new _TratamientoRealizado_View(this);

			// Run the page
			return await TratamientoRealizado_View.Run();
		}

		// edit
		[Route("TratamientoRealizadoedit/{nTratamientoRealizadoID?}")]
		[Route("Home/TratamientoRealizadoedit/{nTratamientoRealizadoID?}")]
		public async Task<IActionResult> TratamientoRealizadoedit()
		{

			// Create page object
			TratamientoRealizado_Edit = new _TratamientoRealizado_Edit(this);

			// Run the page
			return await TratamientoRealizado_Edit.Run();
		}

		// delete
		[Route("TratamientoRealizadodelete/{nTratamientoRealizadoID?}")]
		[Route("Home/TratamientoRealizadodelete/{nTratamientoRealizadoID?}")]
		public async Task<IActionResult> TratamientoRealizadodelete()
		{

			// Create page object
			TratamientoRealizado_Delete = new _TratamientoRealizado_Delete(this);

			// Run the page
			return await TratamientoRealizado_Delete.Run();
		}
	}
}
