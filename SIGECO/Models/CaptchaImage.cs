// ASP.NET Maker 2019
// Copyright (c) 2019 e.World Technology Limited. All rights reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Ganss.XSS;
using ImageMagick;
using MimeDetective.InMemory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using static AspNetMaker2019.Models.prjSIGECO;

// Models
namespace AspNetMaker2019.Models {

	// Partial class
	public partial class prjSIGECO {

		/// <summary>
		/// Captcha Image class
		/// </summary>

		public class CaptchaImage : IDisposable
		{
			private bool _disposed = false;
			private string text;
			private int width;
			private int height;
			private string familyName;
			private Bitmap image;

			// For generating random numbers
			private Random random = new Random();

			// Constructor
			public CaptchaImage(string s, int width, int height)
			{
				this.text = s;
				this.SetDimensions(width, height);
				this.GenerateImage();
			}

			// Constructor (with text)
			public CaptchaImage(string s, int width, int height, string familyName)
			{
				this.text = s;
				this.SetDimensions(width, height);
				this.SetFamilyName(familyName);
				this.GenerateImage();
			}

			// Overrides Object.Finalize
			~CaptchaImage() => Dispose(false);

			// Text
			public string Text => this.text;

			// Image
			public Bitmap Image => this.image;

			// Width
			public int Width => this.width;

			// Height
			public int Height => this.height;

			// Releases all resources used by this object
			public void Dispose()
			{
				GC.SuppressFinalize(this);
				this.Dispose(true);
			}

			// Custom Dispose method to clean up unmanaged resources
			protected virtual void Dispose(bool disposing)
			{
				if (_disposed)
					return;
				if (disposing)
					this.image.Dispose(); // Dispose of the bitmap
				_disposed = true;
			}

			// Sets the image width and height
			private void SetDimensions(int width, int height)
			{

				// Check the width and height
				if (width <= 0)
					throw new ArgumentOutOfRangeException("width", width, "Argument out of range, must be greater than zero.");
				if (height <= 0)
					throw new ArgumentOutOfRangeException("height", height, "Argument out of range, must be greater than zero.");
				this.width = width;
				this.height = height;
			}

			// Sets the font used for the image text
			private void SetFamilyName(string familyName)
			{

				// If the named font is not installed, default to a system font
				try
				{
					using (var font = new System.Drawing.Font(this.familyName, 12F)) {
						this.familyName = familyName;
					}
				}
				catch
				{
					this.familyName = System.Drawing.FontFamily.GenericSerif.Name;
				}
			}

			// Creates the bitmap image
			private void GenerateImage()
			{

				// Create a new 32-bit bitmap image
				Bitmap bitmap = new Bitmap(this.width, this.height, PixelFormat.Format32bppArgb);

				// Create a graphics object for drawing
				Graphics g = Graphics.FromImage(bitmap);
				g.SmoothingMode = SmoothingMode.AntiAlias;
				var rect = new System.Drawing.Rectangle(0, 0, this.width, this.height);

				// Fill in the background
				HatchBrush hatchBrush = new HatchBrush(HatchStyle.SmallConfetti, System.Drawing.Color.LightGray, System.Drawing.Color.White);
				g.FillRectangle(hatchBrush, rect);

				// Set up the text font
				SizeF size;
				float fontSize = rect.Height + 1;
				System.Drawing.Font font;

				// Adjust the font size until the text fits within the image.
				do
				{
					fontSize--;
					font = new System.Drawing.Font(this.familyName, fontSize, FontStyle.Bold);
					size = g.MeasureString(this.text, font);
				} while (size.Width > rect.Width);

				// Set up the text format
				StringFormat format = new StringFormat();
				format.Alignment = StringAlignment.Center;
				format.LineAlignment = StringAlignment.Center;

				// Create a path using the text and warp it randomly
				GraphicsPath path = new GraphicsPath();
				path.AddString(this.text, font.FontFamily, (int) font.Style, font.Size, rect, format);
				float v = 4F;
				PointF[] points =
				{
					new PointF(this.random.Next(rect.Width) / v, this.random.Next(rect.Height) / v),
					new PointF(rect.Width - this.random.Next(rect.Width) / v, this.random.Next(rect.Height) / v),
					new PointF(this.random.Next(rect.Width) / v, rect.Height - this.random.Next(rect.Height) / v),
					new PointF(rect.Width - this.random.Next(rect.Width) / v, rect.Height - this.random.Next(rect.Height) / v)
				};
				Matrix matrix = new Matrix();
				matrix.Translate(0F, 0F);
				path.Warp(points, rect, matrix, WarpMode.Perspective, 0F);

				// Draw the text
				hatchBrush = new HatchBrush(HatchStyle.LargeConfetti, System.Drawing.Color.LightGray, System.Drawing.Color.DarkGray);
				g.FillPath(hatchBrush, path);

				// Add some random noise
				int m = Math.Max(rect.Width, rect.Height);
				for (int i = 0; i < (int)(rect.Width * rect.Height / 30F); i++)
				{
					int x = this.random.Next(rect.Width);
					int y = this.random.Next(rect.Height);
					int w = this.random.Next(m / 50);
					int h = this.random.Next(m / 50);
					g.FillEllipse(hatchBrush, x, y, w, h);
				}

				// Clean up
				font.Dispose();
				hatchBrush.Dispose();
				g.Dispose();

				// Set the image
				this.image = bitmap;
			}
		}
	}
}
