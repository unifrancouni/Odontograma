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
		[Route("AntecedenteFamiliarlist/{nAntecedenteFamiliarID?}")]
		[Route("Home/AntecedenteFamiliarlist/{nAntecedenteFamiliarID?}")]
		public async Task<IActionResult> AntecedenteFamiliarlist()
		{

			// Create page object
			AntecedenteFamiliar_List = new _AntecedenteFamiliar_List(this);
			AntecedenteFamiliar_List.Cache = _cache;

			// Run the page
			return await AntecedenteFamiliar_List.Run();
		}

		// add
		[Route("AntecedenteFamiliaradd/{nAntecedenteFamiliarID?}")]
		[Route("Home/AntecedenteFamiliaradd/{nAntecedenteFamiliarID?}")]
		public async Task<IActionResult> AntecedenteFamiliaradd()
		{

			// Create page object
			AntecedenteFamiliar_Add = new _AntecedenteFamiliar_Add(this);

			// Run the page
			return await AntecedenteFamiliar_Add.Run();
		}

		// view
		[Route("AntecedenteFamiliarview/{nAntecedenteFamiliarID?}")]
		[Route("Home/AntecedenteFamiliarview/{nAntecedenteFamiliarID?}")]
		public async Task<IActionResult> AntecedenteFamiliarview()
		{

			// Create page object
			AntecedenteFamiliar_View = new _AntecedenteFamiliar_View(this);

			// Run the page
			return await AntecedenteFamiliar_View.Run();
		}

		// edit
		[Route("AntecedenteFamiliaredit/{nAntecedenteFamiliarID?}")]
		[Route("Home/AntecedenteFamiliaredit/{nAntecedenteFamiliarID?}")]
		public async Task<IActionResult> AntecedenteFamiliaredit()
		{

			// Create page object
			AntecedenteFamiliar_Edit = new _AntecedenteFamiliar_Edit(this);

			// Run the page
			return await AntecedenteFamiliar_Edit.Run();
		}

		// delete
		[Route("AntecedenteFamiliardelete/{nAntecedenteFamiliarID?}")]
		[Route("Home/AntecedenteFamiliardelete/{nAntecedenteFamiliarID?}")]
		public async Task<IActionResult> AntecedenteFamiliardelete()
		{

			// Create page object
			AntecedenteFamiliar_Delete = new _AntecedenteFamiliar_Delete(this);

			// Run the page
			return await AntecedenteFamiliar_Delete.Run();
		}
	}
}
