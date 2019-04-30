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
		[Route("PlanTratamientolist/{nPlanTratamientoID?}")]
		[Route("Home/PlanTratamientolist/{nPlanTratamientoID?}")]
		public async Task<IActionResult> PlanTratamientolist()
		{

			// Create page object
			PlanTratamiento_List = new _PlanTratamiento_List(this);
			PlanTratamiento_List.Cache = _cache;

			// Run the page
			return await PlanTratamiento_List.Run();
		}

		// add
		[Route("PlanTratamientoadd/{nPlanTratamientoID?}")]
		[Route("Home/PlanTratamientoadd/{nPlanTratamientoID?}")]
		public async Task<IActionResult> PlanTratamientoadd()
		{

			// Create page object
			PlanTratamiento_Add = new _PlanTratamiento_Add(this);

			// Run the page
			return await PlanTratamiento_Add.Run();
		}

		// view
		[Route("PlanTratamientoview/{nPlanTratamientoID?}")]
		[Route("Home/PlanTratamientoview/{nPlanTratamientoID?}")]
		public async Task<IActionResult> PlanTratamientoview()
		{

			// Create page object
			PlanTratamiento_View = new _PlanTratamiento_View(this);

			// Run the page
			return await PlanTratamiento_View.Run();
		}

		// edit
		[Route("PlanTratamientoedit/{nPlanTratamientoID?}")]
		[Route("Home/PlanTratamientoedit/{nPlanTratamientoID?}")]
		public async Task<IActionResult> PlanTratamientoedit()
		{

			// Create page object
			PlanTratamiento_Edit = new _PlanTratamiento_Edit(this);

			// Run the page
			return await PlanTratamiento_Edit.Run();
		}

		// delete
		[Route("PlanTratamientodelete/{nPlanTratamientoID?}")]
		[Route("Home/PlanTratamientodelete/{nPlanTratamientoID?}")]
		public async Task<IActionResult> PlanTratamientodelete()
		{

			// Create page object
			PlanTratamiento_Delete = new _PlanTratamiento_Delete(this);

			// Run the page
			return await PlanTratamiento_Delete.Run();
		}
	}
}
