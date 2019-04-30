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
		[Route("AntecedenteDentallist/{nAntecedenteDentalID?}")]
		[Route("Home/AntecedenteDentallist/{nAntecedenteDentalID?}")]
		public async Task<IActionResult> AntecedenteDentallist()
		{

			// Create page object
			AntecedenteDental_List = new _AntecedenteDental_List(this);
			AntecedenteDental_List.Cache = _cache;

			// Run the page
			return await AntecedenteDental_List.Run();
		}

		// add
		[Route("AntecedenteDentaladd/{nAntecedenteDentalID?}")]
		[Route("Home/AntecedenteDentaladd/{nAntecedenteDentalID?}")]
		public async Task<IActionResult> AntecedenteDentaladd()
		{

			// Create page object
			AntecedenteDental_Add = new _AntecedenteDental_Add(this);

			// Run the page
			return await AntecedenteDental_Add.Run();
		}

		// view
		[Route("AntecedenteDentalview/{nAntecedenteDentalID?}")]
		[Route("Home/AntecedenteDentalview/{nAntecedenteDentalID?}")]
		public async Task<IActionResult> AntecedenteDentalview()
		{

			// Create page object
			AntecedenteDental_View = new _AntecedenteDental_View(this);

			// Run the page
			return await AntecedenteDental_View.Run();
		}

		// edit
		[Route("AntecedenteDentaledit/{nAntecedenteDentalID?}")]
		[Route("Home/AntecedenteDentaledit/{nAntecedenteDentalID?}")]
		public async Task<IActionResult> AntecedenteDentaledit()
		{

			// Create page object
			AntecedenteDental_Edit = new _AntecedenteDental_Edit(this);

			// Run the page
			return await AntecedenteDental_Edit.Run();
		}

		// delete
		[Route("AntecedenteDentaldelete/{nAntecedenteDentalID?}")]
		[Route("Home/AntecedenteDentaldelete/{nAntecedenteDentalID?}")]
		public async Task<IActionResult> AntecedenteDentaldelete()
		{

			// Create page object
			AntecedenteDental_Delete = new _AntecedenteDental_Delete(this);

			// Run the page
			return await AntecedenteDental_Delete.Run();
		}
	}
}
