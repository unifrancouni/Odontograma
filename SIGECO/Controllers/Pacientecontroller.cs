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
		[Route("Pacientelist/{nPacienteID?}")]
		[Route("Home/Pacientelist/{nPacienteID?}")]
		public async Task<IActionResult> Pacientelist()
		{

			// Create page object
			Paciente_List = new _Paciente_List(this);
			Paciente_List.Cache = _cache;

			// Run the page
			return await Paciente_List.Run();
		}

		// add
		[Route("Pacienteadd/{nPacienteID?}")]
		[Route("Home/Pacienteadd/{nPacienteID?}")]
		public async Task<IActionResult> Pacienteadd()
		{

			// Create page object
			Paciente_Add = new _Paciente_Add(this);

			// Run the page
			return await Paciente_Add.Run();
		}

		// view
		[Route("Pacienteview/{nPacienteID?}")]
		[Route("Home/Pacienteview/{nPacienteID?}")]
		public async Task<IActionResult> Pacienteview()
		{

			// Create page object
			Paciente_View = new _Paciente_View(this);

			// Run the page
			return await Paciente_View.Run();
		}

		// edit
		[Route("Pacienteedit/{nPacienteID?}")]
		[Route("Home/Pacienteedit/{nPacienteID?}")]
		public async Task<IActionResult> Pacienteedit()
		{

			// Create page object
			Paciente_Edit = new _Paciente_Edit(this);

			// Run the page
			return await Paciente_Edit.Run();
		}

		// delete
		[Route("Pacientedelete/{nPacienteID?}")]
		[Route("Home/Pacientedelete/{nPacienteID?}")]
		public async Task<IActionResult> Pacientedelete()
		{

			// Create page object
			Paciente_Delete = new _Paciente_Delete(this);

			// Run the page
			return await Paciente_Delete.Run();
		}
	}
}
