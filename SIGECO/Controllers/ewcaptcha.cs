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

// Captcha Controller
namespace AspNetMaker2019.Controllers
{

	/// <summary>
	/// Captcha controller class
	/// </summary>

	public class CaptchaController : Controller
	{
		public CaptchaController()
		{
			UseSession = true;
		}

		// ewcaptcha
		[Route("ewcaptcha")]
		[Route("Home/ewcaptcha")]
		public IActionResult ewcaptcha()
		{
			NoCache();
			Session["CAPTCHA"] = Random(6);
			using (var captcha = new CaptchaImage(Session.GetString("CAPTCHA"), 200, 50, "Century Schoolbook")) {
				var ms = new System.IO.MemoryStream();
				captcha.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
				ms.Seek(0, System.IO.SeekOrigin.Begin);
				return File(ms, "image/jpeg");
			}
		}
	}
}
