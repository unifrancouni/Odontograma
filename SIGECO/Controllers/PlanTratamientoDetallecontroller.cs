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
		[Route("PlanTratamientoDetallelist/{nPlanTratamientoDetalleID?}")]
		[Route("Home/PlanTratamientoDetallelist/{nPlanTratamientoDetalleID?}")]
		public async Task<IActionResult> PlanTratamientoDetallelist()
		{

			// Create page object
			PlanTratamientoDetalle_List = new _PlanTratamientoDetalle_List(this);
			PlanTratamientoDetalle_List.Cache = _cache;

			// Run the page
			return await PlanTratamientoDetalle_List.Run();
		}

		// add
		[Route("PlanTratamientoDetalleadd/{nPlanTratamientoDetalleID?}")]
		[Route("Home/PlanTratamientoDetalleadd/{nPlanTratamientoDetalleID?}")]
		public async Task<IActionResult> PlanTratamientoDetalleadd()
		{

			// Create page object
			PlanTratamientoDetalle_Add = new _PlanTratamientoDetalle_Add(this);

			// Run the page
			return await PlanTratamientoDetalle_Add.Run();
		}

		// view
		[Route("PlanTratamientoDetalleview/{nPlanTratamientoDetalleID?}")]
		[Route("Home/PlanTratamientoDetalleview/{nPlanTratamientoDetalleID?}")]
		public async Task<IActionResult> PlanTratamientoDetalleview()
		{

			// Create page object
			PlanTratamientoDetalle_View = new _PlanTratamientoDetalle_View(this);

			// Run the page
			return await PlanTratamientoDetalle_View.Run();
		}

		// edit
		[Route("PlanTratamientoDetalleedit/{nPlanTratamientoDetalleID?}")]
		[Route("Home/PlanTratamientoDetalleedit/{nPlanTratamientoDetalleID?}")]
		public async Task<IActionResult> PlanTratamientoDetalleedit()
		{

			// Create page object
			PlanTratamientoDetalle_Edit = new _PlanTratamientoDetalle_Edit(this);

			// Run the page
			return await PlanTratamientoDetalle_Edit.Run();
		}

		// delete
		[Route("PlanTratamientoDetalledelete/{nPlanTratamientoDetalleID?}")]
		[Route("Home/PlanTratamientoDetalledelete/{nPlanTratamientoDetalleID?}")]
		public async Task<IActionResult> PlanTratamientoDetalledelete()
		{

			// Create page object
			PlanTratamientoDetalle_Delete = new _PlanTratamientoDetalle_Delete(this);

			// Run the page
			return await PlanTratamientoDetalle_Delete.Run();
		}
	}
}
