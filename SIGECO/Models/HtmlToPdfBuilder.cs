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

		#pragma warning disable 612

		/// <summary>
		/// HTML to PDF builder class
		/// </summary>

		public class HtmlToPdfBuilder {

			// Properties
			private iTextSharp.text.Rectangle _size;
			private StyleSheet _styles;
			private List<float[]> _colWidths = new List<float[]>();
			public CssParser CssParser;
			private List<string> Pages;

			// Constructor
			public HtmlToPdfBuilder() {
				Pages = new List<string>();
				CssParser = new CssParser();
				_styles = new StyleSheet();
			}

			// Set paper size and orientation
			public void SetPaper(string size, string orientation) {
				try {
					_size = PageSize.GetRectangle(size);
					if (SameText(orientation, "landscape")) // Landscape
						_size = _size.Rotate();
				} catch {
					_size = PageSize.GetRectangle(size);
				}
			}

			// Set column widths
			public void AddColumnWidths(float[] widths) => _colWidths.Add(widths);

			// Load HTML
			public void LoadHtml(string html) {

				// Get the style block(s)
				string pattern = @"<style type=""text/css"">([\S\s]*)</style>"; // Note: MUST match ExportHeaderAndFooter()
				foreach (Match match in Regex.Matches(html, pattern, RegexOptions.IgnoreCase))
					AddStyles(match.Groups[1].Value);

				// Remove the style block(s)
				html = Regex.Replace(html, pattern, "");
				string[] StringSeparators = new string[] { Config.PageBreakHtml }; // Note: MUST match ExportPageBreak()
				Pages.AddRange(html.Split(StringSeparators, StringSplitOptions.None));
			}

			// Add styles by CSS string
			public void AddStyles(string content) {
				CssParser.Clear();
				CssParser.ParseString(content);
				AddStyles();
			}

			// Add styles to _styles
			private void AddStyles() {
				Dictionary<string, Dictionary<string, string>> css = CssParser.Css;
				foreach (var (key, value) in css) {
					if (key.StartsWith(".") && !key.Contains(" ")) { // Class name
						_styles.LoadStyle(key.Substring(1), new Hashtable(value));
					} else if (!key.Contains(".") && !key.Contains(" ")) { // Tag
						_styles.LoadTagStyle(key, new Hashtable(value));
					} else {

						// Not supported by iTextSharp
					}
				}
			}

			// Renders the PDF to an array of bytes
			public async Task<MemoryStream> RenderPdf() {

				// Document is built-in class available in iTextSharp
				var stream = new MemoryStream();
				var document = new Document(_size);
				var writer = PdfWriter.GetInstance(document, stream);

				// Open document
				document.Open();

				// Render each page that has been added
				foreach (string page in Pages) {
					document.NewPage();

					// Generate this page of text
					using (var ms = new MemoryStream()) {
						using (var sw = new StreamWriter(ms, Encoding.UTF8)) {
							await sw.WriteAsync(page); // Get the page output
						}

						// Read the created stream
						using (MemoryStream generate = new MemoryStream(ms.ToArray())) {
							using (StreamReader reader = new StreamReader(generate)) {
								var providers = new Hashtable();
								int i = -1;
								foreach (IElement el in HtmlWorker.ParseToList(reader, _styles, providers)) {
									if (el is iTextSharp.text.pdf.PdfPTable tbl) {
										i++;
										if (i < _colWidths.Count && _colWidths[i].Length == tbl.NumberOfColumns)
											tbl.SetWidths(_colWidths[i]);
									}
									document.Add(el);
								}
							}
						}
					}
				}

				// Close document
				document.Close();

				// Return the rendered PDF
				stream.Seek(0, SeekOrigin.Begin);
				return stream;
			}
		}

		#pragma warning restore 612

	}
}
