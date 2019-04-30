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
		/// AntecedenteDental_Add
		/// </summary>

		public static _AntecedenteDental_Add AntecedenteDental_Add {
			get => HttpData.Get<_AntecedenteDental_Add>("AntecedenteDental_Add");
			set => HttpData["AntecedenteDental_Add"] = value;
		}

		/// <summary>
		/// Page class for AntecedenteDental
		/// </summary>

		public class _AntecedenteDental_Add : _AntecedenteDental_AddBase
		{

			// Construtor
			public _AntecedenteDental_Add(Controller controller = null) : base(controller) {
			}
		}

		/// <summary>
		/// Page base class
		/// </summary>

		public class _AntecedenteDental_AddBase : _AntecedenteDental, IAspNetMakerPage
		{

			// Page ID
			public string PageID = "add";

			// Project ID
			public string ProjectID = "{9B083C8B-EE2F-4356-BE8D-9A26D5707365}";

			// Table name
			public string TableName = "AntecedenteDental";

			// Page object name
			public string PageObjName = "AntecedenteDental_Add";

			// Page headings
			public string Heading = "";
			public string Subheading = "";
			public string PageHeader = "";
			public string PageFooter = "";

			// Token
			public string Token; // DN
			public bool CheckToken = Config.CheckToken;

			// Action result // DN
			public IActionResult ActionResult;

			// Cache // DN
			public IMemoryCache Cache;

			// Page terminated // DN
			private bool _terminated = false;

			// Page URL
			private string _pageUrl = "";

			// Page action result
			public IActionResult PageResult() {
				if (ActionResult != null)
					return ActionResult;
				SetupMenus();
				return Controller.View();
			}

			// Page heading
			public string PageHeading {
				get {
					if (!Empty(Heading))
						return Heading;
					else if (!Empty(Caption))
						return Caption;
					else
						return "";
				}
			}

			// Page subheading
			public string PageSubheading {
				get {
					if (!Empty(Subheading))
						return Subheading;
					if (!Empty(TableName))
						return Language.Phrase(PageID);
					return "";
				}
			}

			// Page name
			public string PageName => CurrentPageName();

			// Page URL
			public string PageUrl {
				get {
					if (_pageUrl == "") {
						_pageUrl = CurrentPageName() + "?";
					}
					return _pageUrl;
				}
			}

			// Private properties
			private string _message = "";
			private string _failureMessage = "";
			private string _successMessage = "";
			private string _warningMessage = "";

			// Message
			public string Message {
				get => Session.TryGetValue(Config.SessionMessage, out string message) ? message : _message;
				set {
					_message = AddMessage(Message, value);
					Session[Config.SessionMessage] = _message;
				}
			}

			// Failure Message
			public string FailureMessage {
				get => Session.TryGetValue(Config.SessionFailureMessage, out string failureMessage) ? failureMessage : _failureMessage;
				set {
					_failureMessage = AddMessage(FailureMessage, value);
					Session[Config.SessionFailureMessage] = _failureMessage;
				}
			}

			// Success Message
			public string SuccessMessage {
				get => Session.TryGetValue(Config.SessionSuccessMessage, out string successMessage) ? successMessage : _successMessage;
				set {
					_successMessage = AddMessage(SuccessMessage, value);
					Session[Config.SessionSuccessMessage] = _successMessage;
				}
			}

			// Warning Message
			public string WarningMessage {
				get => Session.TryGetValue(Config.SessionWarningMessage, out string warningMessage) ? warningMessage : _warningMessage;
				set {
					_warningMessage = AddMessage(WarningMessage, value);
					Session[Config.SessionWarningMessage] = _warningMessage;
				}
			}

			// Clear message
			public void ClearMessage() {
				_message = "";
				Session[Config.SessionMessage] = _message;
			}

			// Clear failure message
			public void ClearFailureMessage() {
				_failureMessage = "";
				Session[Config.SessionFailureMessage] = _failureMessage;
			}

			// Clear success message
			public void ClearSuccessMessage() {
				_successMessage = "";
				Session[Config.SessionSuccessMessage] = _successMessage;
			}

			// Clear warning message
			public void ClearWarningMessage() {
				_warningMessage = "";
				Session[Config.SessionWarningMessage] = _warningMessage;
			}

			// Clear all messages
			public void ClearMessages() {
				ClearMessage();
				ClearFailureMessage();
				ClearSuccessMessage();
				ClearWarningMessage();
			}

			// Get message
			public string GetMessage() { // DN
				bool hidden = false;
				string html = "";

				// Message
				string message = Message;
				Message_Showing(ref message, "");
				if (!Empty(message)) { // Message in Session, display
					if (!hidden)
						message = "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + message;
					html += "<div class=\"alert alert-info alert-dismissible ew-info\"><i class=\"icon fa fa-info\"></i>" + message + "</div>";
					Session[Config.SessionMessage] = ""; // Clear message in Session
				}

				// Warning message
				string warningMessage = WarningMessage;
				Message_Showing(ref warningMessage, "warning");
				if (!Empty(warningMessage)) { // Message in Session, display
					if (!hidden)
						warningMessage = "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + warningMessage;
					html += "<div class=\"alert alert-warning alert-dismissible ew-warning\"><i class=\"icon fa fa-warning\"></i>" + warningMessage + "</div>";
					Session[Config.SessionWarningMessage] = ""; // Clear message in Session
				}

				// Success message
				string successMessage = SuccessMessage;
				Message_Showing(ref successMessage, "success");
				if (!Empty(successMessage)) { // Message in Session, display
					if (!hidden)
						successMessage = "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + successMessage;
					html += "<div class=\"alert alert-success alert-dismissible ew-success\"><i class=\"icon fa fa-check\"></i>" + successMessage + "</div>";
					Session[Config.SessionSuccessMessage] = ""; // Clear message in Session
				}

				// Failure message
				string errorMessage = FailureMessage;
				Message_Showing(ref errorMessage, "failure");
				if (!Empty(errorMessage)) { // Message in Session, display
					if (!hidden)
						errorMessage = "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + errorMessage;
					html += "<div class=\"alert alert-danger alert-dismissible ew-error\"><i class=\"icon fa fa-ban\"></i>" + errorMessage + "</div>";
					Session[Config.SessionFailureMessage] = ""; // Clear message in Session
				}
				return "<div class=\"ew-message-dialog\"" + (hidden ? " d-none" : "") + ">" + html + "</div>"; // DN
			}

			// Show message as IHtmlContent // DN
			public IHtmlContent ShowMessages() => new HtmlString(GetMessage());

			// Get messages
			public Dictionary<string, string> GetMessages() {
				var d = new Dictionary<string, string>();

				// Message
				string message = Message;
				if (!Empty(message)) { // Message in Session, display
					d.Add("message", message);
					Session[Config.SessionMessage] = ""; // Clear message in Session
				}

				// Warning message
				string warningMessage = WarningMessage;
				if (!Empty(warningMessage)) { // Message in Session, display
					d.Add("warningMessage", warningMessage);
					Session[Config.SessionWarningMessage] = ""; // Clear message in Session
				}

				// Success message
				string successMessage = SuccessMessage;
				if (!Empty(successMessage)) { // Message in Session, display
					d.Add("successMessage", successMessage);
					Session[Config.SessionSuccessMessage] = ""; // Clear message in Session
				}

				// Failure message
				string failureMessage = FailureMessage;
				if (!Empty(failureMessage)) { // Message in Session, display
					d.Add("failureMessage", failureMessage);
					Session[Config.SessionFailureMessage] = ""; // Clear message in Session
				}
				return d;
			}

			// Show Page Header
			public IHtmlContent ShowPageHeader() {
				string header = PageHeader;
				Page_DataRendering(ref header);
				if (!Empty(header)) // Header exists, display
					return new HtmlString("<p id=\"ew-page-header\">" + header + "</p>");
				return null;
			}

			// Show Page Footer
			public IHtmlContent ShowPageFooter() {
				string footer = PageFooter;
				Page_DataRendered(ref footer);
				if (!Empty(footer)) // Footer exists, display
					return new HtmlString("<p id=\"ew-page-footer\">" + footer + "</p>");
				return null;
			}

			// Validate page request
			public bool IsPageRequest => true;

			// Valid post
			protected async Task<bool> ValidPost() => !CheckToken || !IsPost() || IsApi() || await Antiforgery.IsRequestValidAsync(HttpContext);

			// Create token
			public void CreateToken() {
				Token = Token ?? Antiforgery.GetTokens(HttpContext).RequestToken; // Always create token, required by API file/lookup request
				CurrentToken = Token; // Save to global variable
			}

			// Constructor
			public _AntecedenteDental_AddBase(Controller controller = null) { // DN
				if (controller != null)
					Controller = controller;

				// Initialize
				CurrentPage = this;

				// Language object
				Language = Language ?? new Lang();

				// Table object (AntecedenteDental)
				if (AntecedenteDental == null || AntecedenteDental is _AntecedenteDental)
					AntecedenteDental = this;

				// Table object (Usuario)
				Usuario = Usuario ?? new _Usuario();

				// Start time
				StartTime = Environment.TickCount;

				// Debug message
				LoadDebugMessage();

				// Open connection
				Conn = Connection; // DN

				// User table object (Usuario)
				UserTable = UserTable ?? new _Usuario();
				UserTableConn = UserTableConn ?? GetConnection(UserTable.DbId);
			}

			#pragma warning disable 1998

			// Export view result
			public async Task<IActionResult> ExportView() { // DN
				if (!Empty(CustomExport) && CustomExport == Export && Config.Export.TryGetValue(CustomExport, out string classname)) {
					IActionResult result = null;
					string content = await GetViewOutput();
					if (Empty(ExportFileName))
						ExportFileName = TableVar;
					dynamic doc = CreateInstance(classname, new object[] { AntecedenteDental, "" }); // DN
					doc.Text.Append(content);
					result = doc.Export();
					DeleteTempImages(); // Delete temp images
					return result;
				}
				return null;
			}

			#pragma warning restore 1998

			/// <summary>
			/// Terminate page
			/// </summary>
			/// <param name="url">URL to rediect to</param>
			/// <returns>Page result</returns>

			public IActionResult Terminate(string url = "") { // DN
				if (_terminated) // DN
					return null;

				// Page Unload event
				Page_Unload();

				// Global Page Unloaded event
				Page_Unloaded();
				if (!IsApi())
					Page_Redirecting(ref url);

				// Close connection
				CloseConnections(true);

				// Gargage collection
				Collect(); // DN

				// Terminate
				_terminated = true; // DN

				// Return for API
				if (IsApi()) {
					bool res = !Empty(url);
					if (!res) { // Show error
						var showError = new Dictionary<string, string> { { "success", "false" }, { "version", Config.ProductVersion } };
						foreach (var (key, value) in GetMessages())
							showError.Add(key, value);
						return Controller.Json(showError);
					}
				} else if (ActionResult != null) { // Check action result
					return ActionResult;
				}

				// Go to URL if specified
				if (!Empty(url)) {
					if (!Config.Debug)
						ResponseClear();
					if (!Response.HasStarted) {

						// Handle modal response
						if (IsModal) { // Show as modal
							var row = new Dictionary<string, string> { {"url", GetUrl(url)}, {"modal", "1"} };
							string pageName = GetPageName(url);
							if (pageName != ListUrl) { // Not List page
								row.Add("caption", GetModalCaption(pageName));
								if (pageName == "AntecedenteDentalview")
									row.Add("view", "1");
							} else { // List page should not be shown as modal => error
								row.Add("error", FailureMessage);
								ClearFailureMessage();
							}
							return Controller.Json(row);
						} else {
							SaveDebugMessage();
							return Controller.LocalRedirect(AppPath(url));
						}
					}
				}
				return null;
			}

			// Get all records from datareader
			protected async Task<List<Dictionary<string, object>>> GetRecordsFromRecordset(DbDataReader rs)
			{
				var rows = new List<Dictionary<string, object>>();
				while (rs != null && await rs.ReadAsync()) {
					await LoadRowValues(rs); // Set up DbValue/CurrentValue
					rows.Add(GetRecordFromDictionary(GetDictionary(rs)));
				}
				return rows;
			}

			// Get the first record from datareader
			protected async Task<Dictionary<string, object>> GetRecordFromRecordset(DbDataReader rs)
			{
				if (rs != null) {
					await LoadRowValues(rs); // Set up DbValue/CurrentValue
					return GetRecordFromDictionary(GetDictionary(rs));
				}
				return null;
			}

			// Get the first record from the list of records
			protected Dictionary<string, object> GetRecordFromRecordset(List<Dictionary<string, object>> ar) => GetRecordFromDictionary(ar[0]);

			// Get record from Dictionary
			protected Dictionary<string, object> GetRecordFromDictionary(Dictionary<string, object> ar) {
				var row = new Dictionary<string, object>();
				foreach (var (key, value) in ar) {
					if (Fields.TryGetValue(key, out DbField fld)) {
						if (fld.Visible || fld.IsPrimaryKey) { // Primary key or Visible
							if (fld.HtmlTag == "FILE") { // Upload field
								if (Empty(value)) {
									row[key] = null;
								} else {
									if (fld.DataType == Config.DataTypeBlob) {
										string url = FullUrl(GetPageName(Config.ApiUrl) + "/" + Config.ApiFileAction + "/" + fld.TableVar + "/" + fld.Param + "/" + GetRecordKeyValue(ar)); // Query string format
										row[key] = new Dictionary<string, object> { { "mimeType", ContentType((byte[])value) }, { "url", url } };
									} else if (!fld.UploadMultiple || !Convert.ToString(value).Contains(Config.MultipleUploadSeparator)) { // Single file
										row[key] = new Dictionary<string, object> { { "mimeType", ContentType(Convert.ToString(value)) }, { "url", FullUrl(fld.HrefPath + Convert.ToString(value)) } };
									} else { // Multiple files
										var files = Convert.ToString(value).Split(Config.MultipleUploadSeparator);
										row[key] = files.Where(file => !Empty(file)).Select(file => new Dictionary<string, object> { { "type", ContentType(file) }, { "url", FullUrl(fld.HrefPath + file) } });
									}
								}
							} else {
								row[key] = Convert.ToString(value);
							}
						}
					}
				}
				return row;
			}

			// Get record key value from array
			protected string GetRecordKeyValue(Dictionary<string, object> ar) {
				string key = "";
				key += UrlEncode(Convert.ToString(ar["nAntecedenteDentalID"]));
				return key;
			}

			// Hide fields for Add/Edit
			protected void HideFieldsForAddEdit() {
				if (IsAdd || IsCopy || IsGridAdd)
					nAntecedenteDentalID.Visible = false;
			}

			// Properties
			public string FormClassName = "ew-horizontal ew-form ew-add-form";
			public bool IsModal = false;
			public bool IsMobileOrModal = false;
			public string DbMasterFilter = "";
			public string DbDetailFilter = "";
			public int StartRecord;
			public DbDataReader OldRecordset = null;
			public DbDataReader Recordset = null; // Reserved // DN
			public bool CopyRecord;

			/// <summary>
			/// Page run
			/// </summary>
			/// <returns>Page result</returns>

			public async Task<IActionResult> Run() {

				// Header
				Header(Config.Cache);

				// Is modal
				IsModal = Param<bool>("modal");

				// User profile
				Profile = new UserProfile();

				// Security
				Security = new AdvancedSecurity(); // DN
				bool validRequest = false;

				// Check security for API request
				if (IsApi() && !Security.IsLoggedIn) {
					var authResult = await HttpContext.AuthenticateAsync(JwtBearerDefaults.AuthenticationScheme);
					if (authResult.Succeeded && authResult.Principal.Identity.IsAuthenticated)
						Security.LoginUser(ClaimValue(ClaimTypes.Name), ClaimValue("userid"), ClaimValue("parentuserid"), ConvertToInt(ClaimValue("userlevelid")));
				}
				if (!validRequest) {
					if (!Security.IsLoggedIn)
						await Security.AutoLogin();
					if (Security.IsLoggedIn)
						Security.TablePermission_Loading();
					Security.LoadCurrentUserLevel(ProjectID + TableName);
					if (Security.IsLoggedIn)
						Security.TablePermission_Loaded();
					if (!Security.CanAdd) {
						Security.SaveLastUrl();
						FailureMessage = DeniedMessage(); // Set no permission
						if (IsApi())
							return new JsonBoolResult(new { success = false, error = DeniedMessage(), version = Config.ProductVersion }, false);
						if (Security.CanList)
							return Terminate(GetUrl("AntecedenteDentallist"));
						else
							return Terminate(GetUrl("login"));
					}
				}

				// Create form object
				CurrentForm = new HttpForm();
				CurrentAction = Param("action"); // Set up current action
				nAntecedenteDentalID.Visible = false;
				nExpedienteID.SetVisibility();
				dFechaUltimaVisitaDentista.SetVisibility();
				sMotivoVisita.SetVisibility();
				sExperienciaAsistencial.SetVisibility();
				nTratamientoQuirurgico.SetVisibility();
				nTratamientoRestauracion.SetVisibility();
				nTratamientoPeridoncia.SetVisibility();
				nTratamientoEndodoncia.SetVisibility();
				nTratamientoOrtodoncia.SetVisibility();
				nTratamientoProtesis.SetVisibility();
				nColocadoAnestesia.SetVisibility();
				nReaccionAlergicaAnestesia.SetVisibility();
				sReaccionAlergicaAnestesia.SetVisibility();
				sDescripcionTejidosBlandos.SetVisibility();
				sHistoriaEnfermedadActual.SetVisibility();
				nEstadoID.SetVisibility();
				dFechaCreacion.Visible = false;
				dFechaModificacion.Visible = false;
				HideFieldsForAddEdit();

				// Do not use lookup cache
				SetUseLookupCache(false);

				// Global Page Loading event
				Page_Loading();

				// Page Load event
				Page_Load();

				// Check token
				if (!await ValidPost())
					End(Language.Phrase("InvalidPostRequest"));

				// Create token
				CreateToken();

				// Set up lookup cache
				await SetupLookupOptions(nExpedienteID);
				await SetupLookupOptions(nEstadoID);

				// Check modal
				if (IsModal)
					SkipHeaderFooter = true;
				IsMobileOrModal = IsMobile() || IsModal;
				FormClassName = "ew-form ew-add-form ew-horizontal";
				bool postBack = false;

				// Set up current action
				if (IsApi()) {
					CurrentAction = "insert"; // Add record directly
					postBack = true;
				} else if (!Empty(Post("action"))) {
					CurrentAction = Post("action"); // Get form action
					postBack = true;
				} else { // Not post back

					// Load key from QueryString
					CopyRecord = true;
					string[] keyValues = null;
					object rv;
					if (IsApi() && RouteValues.TryGetValue("key", out object k))
						keyValues = k.ToString().Split('/');
					if (RouteValues.TryGetValue("nAntecedenteDentalID", out rv)) { // DN
						nAntecedenteDentalID.QueryValue = Convert.ToString(rv);
						SetKey("nAntecedenteDentalID", nAntecedenteDentalID.CurrentValue); // Set up key
					} else if (!Empty(Get("nAntecedenteDentalID"))) {
						nAntecedenteDentalID.QueryValue = Get("nAntecedenteDentalID");
						SetKey("nAntecedenteDentalID", nAntecedenteDentalID.CurrentValue); // Set up key
					} else if (IsApi() && !Empty(keyValues)) {
						nAntecedenteDentalID.QueryValue = Convert.ToString(keyValues[0]);
						SetKey("nAntecedenteDentalID", nAntecedenteDentalID.CurrentValue); // Set up key
					} else {
						SetKey("nAntecedenteDentalID", ""); // Clear key
						CopyRecord = false;
					}
					if (CopyRecord) {
						CurrentAction = "copy"; // Copy record
					} else {
						CurrentAction = "show"; // Display blank record
					}
				}

				// Load old record / default values
				bool loaded = await LoadOldRecord();

				// Load form values
				if (postBack) {
					await LoadFormValues(); // Load form values
				}

				// Validate form if post back
				if (postBack) {
					if (!await ValidateForm()) {
						EventCancelled = true; // Event cancelled
						RestoreFormValues(); // Restore form values
						FailureMessage = FormError;
						if (IsApi())
							return Terminate();
						else
							CurrentAction = "show"; // Form error, reset action
					}
				}

				// Perform current action
				switch (CurrentAction) {
					case "copy": // Copy an existing record
						using (OldRecordset) {} // Dispose
						if (!loaded) { // Record not loaded
							if (Empty(FailureMessage))
								FailureMessage = Language.Phrase("NoRecord"); // No record found
							return Terminate("AntecedenteDentallist"); // No matching record, return to List page // DN
						}
						break;
					case "insert": // Add new record // DN
						SendEmail = true; // Send email on add success
						var rsold = Connection.GetRow(OldRecordset);
						using (OldRecordset) {} // Dispose
						var res = await AddRow(rsold);
						if (res) { // Add successful
							if (Empty(SuccessMessage))
								SuccessMessage = Language.Phrase("AddSuccess"); // Set up success message
							string returnUrl = "";
							returnUrl = ReturnUrl;
							if (GetPageName(returnUrl) == "AntecedenteDentallist")
								returnUrl = AddMasterUrl(ListUrl); // List page, return to List page with correct master key if necessary
							else if (GetPageName(returnUrl) == "AntecedenteDentalview")
								returnUrl = ViewUrl; // View page, return to View page with key URL directly
							if (IsApi()) // Return to caller
								return res;
							else
								return Terminate(returnUrl);
						} else if (IsApi()) { // API request, return
							return Terminate();
						} else {
							EventCancelled = true; // Event cancelled
							RestoreFormValues(); // Add failed, restore form values
						}
						break;
				}

				// Set up Breadcrumb
				SetupBreadcrumb();

				// Render row based on row type
				RowType = Config.RowTypeAdd; // Render add type

				// Render row
				ResetAttributes();
				await RenderRow();
				return PageResult();
			}

			// Confirm page
			public bool ConfirmPage = false; // DN

			#pragma warning disable 1998

			// Get upload files
			public async Task GetUploadFiles()
			{

				// Get upload data
			}

			#pragma warning restore 1998

			// Load default values
			protected void LoadDefaultValues() {
				nAntecedenteDentalID.CurrentValue = System.DBNull.Value;
				nAntecedenteDentalID.OldValue = nAntecedenteDentalID.CurrentValue;
				nExpedienteID.CurrentValue = System.DBNull.Value;
				nExpedienteID.OldValue = nExpedienteID.CurrentValue;
				dFechaUltimaVisitaDentista.CurrentValue = System.DBNull.Value;
				dFechaUltimaVisitaDentista.OldValue = dFechaUltimaVisitaDentista.CurrentValue;
				sMotivoVisita.CurrentValue = System.DBNull.Value;
				sMotivoVisita.OldValue = sMotivoVisita.CurrentValue;
				sExperienciaAsistencial.CurrentValue = System.DBNull.Value;
				sExperienciaAsistencial.OldValue = sExperienciaAsistencial.CurrentValue;
				nTratamientoQuirurgico.CurrentValue = System.DBNull.Value;
				nTratamientoQuirurgico.OldValue = nTratamientoQuirurgico.CurrentValue;
				nTratamientoRestauracion.CurrentValue = System.DBNull.Value;
				nTratamientoRestauracion.OldValue = nTratamientoRestauracion.CurrentValue;
				nTratamientoPeridoncia.CurrentValue = System.DBNull.Value;
				nTratamientoPeridoncia.OldValue = nTratamientoPeridoncia.CurrentValue;
				nTratamientoEndodoncia.CurrentValue = System.DBNull.Value;
				nTratamientoEndodoncia.OldValue = nTratamientoEndodoncia.CurrentValue;
				nTratamientoOrtodoncia.CurrentValue = System.DBNull.Value;
				nTratamientoOrtodoncia.OldValue = nTratamientoOrtodoncia.CurrentValue;
				nTratamientoProtesis.CurrentValue = System.DBNull.Value;
				nTratamientoProtesis.OldValue = nTratamientoProtesis.CurrentValue;
				nColocadoAnestesia.CurrentValue = System.DBNull.Value;
				nColocadoAnestesia.OldValue = nColocadoAnestesia.CurrentValue;
				nReaccionAlergicaAnestesia.CurrentValue = System.DBNull.Value;
				nReaccionAlergicaAnestesia.OldValue = nReaccionAlergicaAnestesia.CurrentValue;
				sReaccionAlergicaAnestesia.CurrentValue = System.DBNull.Value;
				sReaccionAlergicaAnestesia.OldValue = sReaccionAlergicaAnestesia.CurrentValue;
				sDescripcionTejidosBlandos.CurrentValue = System.DBNull.Value;
				sDescripcionTejidosBlandos.OldValue = sDescripcionTejidosBlandos.CurrentValue;
				sHistoriaEnfermedadActual.CurrentValue = System.DBNull.Value;
				sHistoriaEnfermedadActual.OldValue = sHistoriaEnfermedadActual.CurrentValue;
				nEstadoID.CurrentValue = System.DBNull.Value;
				nEstadoID.OldValue = nEstadoID.CurrentValue;
				dFechaCreacion.CurrentValue = System.DBNull.Value;
				dFechaCreacion.OldValue = dFechaCreacion.CurrentValue;
				dFechaModificacion.CurrentValue = System.DBNull.Value;
				dFechaModificacion.OldValue = dFechaModificacion.CurrentValue;
			}

			#pragma warning disable 1998

			// Load form values
			protected async Task LoadFormValues() {
				string val;

				// Check field name 'nExpedienteID' first before field var 'x_nExpedienteID'
				val = CurrentForm.GetValue("nExpedienteID", "x_nExpedienteID");
				if (!nExpedienteID.IsDetailKey) {
					if (IsApi() && val == null)
						nExpedienteID.Visible = false; // Disable update for API request
					else
						nExpedienteID.FormValue = val;
				}

				// Check field name 'dFechaUltimaVisitaDentista' first before field var 'x_dFechaUltimaVisitaDentista'
				val = CurrentForm.GetValue("dFechaUltimaVisitaDentista", "x_dFechaUltimaVisitaDentista");
				if (!dFechaUltimaVisitaDentista.IsDetailKey) {
					if (IsApi() && val == null)
						dFechaUltimaVisitaDentista.Visible = false; // Disable update for API request
					else
						dFechaUltimaVisitaDentista.FormValue = val;
					dFechaUltimaVisitaDentista.CurrentValue = UnformatDateTime(dFechaUltimaVisitaDentista.CurrentValue, 0);
				}

				// Check field name 'sMotivoVisita' first before field var 'x_sMotivoVisita'
				val = CurrentForm.GetValue("sMotivoVisita", "x_sMotivoVisita");
				if (!sMotivoVisita.IsDetailKey) {
					if (IsApi() && val == null)
						sMotivoVisita.Visible = false; // Disable update for API request
					else
						sMotivoVisita.FormValue = val;
				}

				// Check field name 'sExperienciaAsistencial' first before field var 'x_sExperienciaAsistencial'
				val = CurrentForm.GetValue("sExperienciaAsistencial", "x_sExperienciaAsistencial");
				if (!sExperienciaAsistencial.IsDetailKey) {
					if (IsApi() && val == null)
						sExperienciaAsistencial.Visible = false; // Disable update for API request
					else
						sExperienciaAsistencial.FormValue = val;
				}

				// Check field name 'nTratamientoQuirurgico' first before field var 'x_nTratamientoQuirurgico'
				val = CurrentForm.GetValue("nTratamientoQuirurgico", "x_nTratamientoQuirurgico");
				if (!nTratamientoQuirurgico.IsDetailKey) {
					if (IsApi() && val == null)
						nTratamientoQuirurgico.Visible = false; // Disable update for API request
					else
						nTratamientoQuirurgico.FormValue = val;
				}

				// Check field name 'nTratamientoRestauracion' first before field var 'x_nTratamientoRestauracion'
				val = CurrentForm.GetValue("nTratamientoRestauracion", "x_nTratamientoRestauracion");
				if (!nTratamientoRestauracion.IsDetailKey) {
					if (IsApi() && val == null)
						nTratamientoRestauracion.Visible = false; // Disable update for API request
					else
						nTratamientoRestauracion.FormValue = val;
				}

				// Check field name 'nTratamientoPeridoncia' first before field var 'x_nTratamientoPeridoncia'
				val = CurrentForm.GetValue("nTratamientoPeridoncia", "x_nTratamientoPeridoncia");
				if (!nTratamientoPeridoncia.IsDetailKey) {
					if (IsApi() && val == null)
						nTratamientoPeridoncia.Visible = false; // Disable update for API request
					else
						nTratamientoPeridoncia.FormValue = val;
				}

				// Check field name 'nTratamientoEndodoncia' first before field var 'x_nTratamientoEndodoncia'
				val = CurrentForm.GetValue("nTratamientoEndodoncia", "x_nTratamientoEndodoncia");
				if (!nTratamientoEndodoncia.IsDetailKey) {
					if (IsApi() && val == null)
						nTratamientoEndodoncia.Visible = false; // Disable update for API request
					else
						nTratamientoEndodoncia.FormValue = val;
				}

				// Check field name 'nTratamientoOrtodoncia' first before field var 'x_nTratamientoOrtodoncia'
				val = CurrentForm.GetValue("nTratamientoOrtodoncia", "x_nTratamientoOrtodoncia");
				if (!nTratamientoOrtodoncia.IsDetailKey) {
					if (IsApi() && val == null)
						nTratamientoOrtodoncia.Visible = false; // Disable update for API request
					else
						nTratamientoOrtodoncia.FormValue = val;
				}

				// Check field name 'nTratamientoProtesis' first before field var 'x_nTratamientoProtesis'
				val = CurrentForm.GetValue("nTratamientoProtesis", "x_nTratamientoProtesis");
				if (!nTratamientoProtesis.IsDetailKey) {
					if (IsApi() && val == null)
						nTratamientoProtesis.Visible = false; // Disable update for API request
					else
						nTratamientoProtesis.FormValue = val;
				}

				// Check field name 'nColocadoAnestesia' first before field var 'x_nColocadoAnestesia'
				val = CurrentForm.GetValue("nColocadoAnestesia", "x_nColocadoAnestesia");
				if (!nColocadoAnestesia.IsDetailKey) {
					if (IsApi() && val == null)
						nColocadoAnestesia.Visible = false; // Disable update for API request
					else
						nColocadoAnestesia.FormValue = val;
				}

				// Check field name 'nReaccionAlergicaAnestesia' first before field var 'x_nReaccionAlergicaAnestesia'
				val = CurrentForm.GetValue("nReaccionAlergicaAnestesia", "x_nReaccionAlergicaAnestesia");
				if (!nReaccionAlergicaAnestesia.IsDetailKey) {
					if (IsApi() && val == null)
						nReaccionAlergicaAnestesia.Visible = false; // Disable update for API request
					else
						nReaccionAlergicaAnestesia.FormValue = val;
				}

				// Check field name 'sReaccionAlergicaAnestesia' first before field var 'x_sReaccionAlergicaAnestesia'
				val = CurrentForm.GetValue("sReaccionAlergicaAnestesia", "x_sReaccionAlergicaAnestesia");
				if (!sReaccionAlergicaAnestesia.IsDetailKey) {
					if (IsApi() && val == null)
						sReaccionAlergicaAnestesia.Visible = false; // Disable update for API request
					else
						sReaccionAlergicaAnestesia.FormValue = val;
				}

				// Check field name 'sDescripcionTejidosBlandos' first before field var 'x_sDescripcionTejidosBlandos'
				val = CurrentForm.GetValue("sDescripcionTejidosBlandos", "x_sDescripcionTejidosBlandos");
				if (!sDescripcionTejidosBlandos.IsDetailKey) {
					if (IsApi() && val == null)
						sDescripcionTejidosBlandos.Visible = false; // Disable update for API request
					else
						sDescripcionTejidosBlandos.FormValue = val;
				}

				// Check field name 'sHistoriaEnfermedadActual' first before field var 'x_sHistoriaEnfermedadActual'
				val = CurrentForm.GetValue("sHistoriaEnfermedadActual", "x_sHistoriaEnfermedadActual");
				if (!sHistoriaEnfermedadActual.IsDetailKey) {
					if (IsApi() && val == null)
						sHistoriaEnfermedadActual.Visible = false; // Disable update for API request
					else
						sHistoriaEnfermedadActual.FormValue = val;
				}

				// Check field name 'nEstadoID' first before field var 'x_nEstadoID'
				val = CurrentForm.GetValue("nEstadoID", "x_nEstadoID");
				if (!nEstadoID.IsDetailKey) {
					if (IsApi() && val == null)
						nEstadoID.Visible = false; // Disable update for API request
					else
						nEstadoID.FormValue = val;
				}

				// Check field name 'nAntecedenteDentalID' first before field var 'x_nAntecedenteDentalID'
				val = CurrentForm.GetValue("nAntecedenteDentalID", "x_nAntecedenteDentalID");
			}

			#pragma warning restore 1998

			// Restore form values
			public void RestoreFormValues() {
				nExpedienteID.CurrentValue = nExpedienteID.FormValue;
				dFechaUltimaVisitaDentista.CurrentValue = dFechaUltimaVisitaDentista.FormValue;
				dFechaUltimaVisitaDentista.CurrentValue = UnformatDateTime(dFechaUltimaVisitaDentista.CurrentValue, 0);
				sMotivoVisita.CurrentValue = sMotivoVisita.FormValue;
				sExperienciaAsistencial.CurrentValue = sExperienciaAsistencial.FormValue;
				nTratamientoQuirurgico.CurrentValue = nTratamientoQuirurgico.FormValue;
				nTratamientoRestauracion.CurrentValue = nTratamientoRestauracion.FormValue;
				nTratamientoPeridoncia.CurrentValue = nTratamientoPeridoncia.FormValue;
				nTratamientoEndodoncia.CurrentValue = nTratamientoEndodoncia.FormValue;
				nTratamientoOrtodoncia.CurrentValue = nTratamientoOrtodoncia.FormValue;
				nTratamientoProtesis.CurrentValue = nTratamientoProtesis.FormValue;
				nColocadoAnestesia.CurrentValue = nColocadoAnestesia.FormValue;
				nReaccionAlergicaAnestesia.CurrentValue = nReaccionAlergicaAnestesia.FormValue;
				sReaccionAlergicaAnestesia.CurrentValue = sReaccionAlergicaAnestesia.FormValue;
				sDescripcionTejidosBlandos.CurrentValue = sDescripcionTejidosBlandos.FormValue;
				sHistoriaEnfermedadActual.CurrentValue = sHistoriaEnfermedadActual.FormValue;
				nEstadoID.CurrentValue = nEstadoID.FormValue;
			}

			// Load row based on key values
			public async Task<bool> LoadRow() {
				string filter = GetRecordFilter();

				// Call Row Selecting event
				Row_Selecting(ref filter);

				// Load SQL based on filter
				CurrentFilter = filter;
				string sql = CurrentSql;
				bool res = false;
				try {
					using (var rsrow = await Connection.OpenDataReaderAsync(sql)) {
						if (rsrow != null && await rsrow.ReadAsync()) {
							await LoadRowValues(rsrow);
							res = true;
						} else {
							return false;
						}
					}
				} catch {
					if (Config.Debug)
						throw;
				}
				return res;
			}

			#pragma warning disable 162, 168, 1998

			// Load row values from recordset
			public async Task LoadRowValues(DbDataReader dr = null) {
				Dictionary<string, object> row;
				object v;
				if (dr != null && dr.HasRows)
					row = Connection.GetRow(dr); // DN
				else
					row = NewRow();

				// Call Row Selected event
				Row_Selected(row);
				if (dr == null || !dr.HasRows)
					return;
				nAntecedenteDentalID.SetDbValue(row["nAntecedenteDentalID"]);
				nExpedienteID.SetDbValue(row["nExpedienteID"]);
				dFechaUltimaVisitaDentista.SetDbValue(row["dFechaUltimaVisitaDentista"]);
				sMotivoVisita.SetDbValue(row["sMotivoVisita"]);
				sExperienciaAsistencial.SetDbValue(row["sExperienciaAsistencial"]);
				nTratamientoQuirurgico.SetDbValue((ConvertToBool(row["nTratamientoQuirurgico"]) ? "1" : "0"));
				nTratamientoRestauracion.SetDbValue((ConvertToBool(row["nTratamientoRestauracion"]) ? "1" : "0"));
				nTratamientoPeridoncia.SetDbValue((ConvertToBool(row["nTratamientoPeridoncia"]) ? "1" : "0"));
				nTratamientoEndodoncia.SetDbValue((ConvertToBool(row["nTratamientoEndodoncia"]) ? "1" : "0"));
				nTratamientoOrtodoncia.SetDbValue((ConvertToBool(row["nTratamientoOrtodoncia"]) ? "1" : "0"));
				nTratamientoProtesis.SetDbValue((ConvertToBool(row["nTratamientoProtesis"]) ? "1" : "0"));
				nColocadoAnestesia.SetDbValue((ConvertToBool(row["nColocadoAnestesia"]) ? "1" : "0"));
				nReaccionAlergicaAnestesia.SetDbValue((ConvertToBool(row["nReaccionAlergicaAnestesia"]) ? "1" : "0"));
				sReaccionAlergicaAnestesia.SetDbValue(row["sReaccionAlergicaAnestesia"]);
				sDescripcionTejidosBlandos.SetDbValue(row["sDescripcionTejidosBlandos"]);
				sHistoriaEnfermedadActual.SetDbValue(row["sHistoriaEnfermedadActual"]);
				nEstadoID.SetDbValue(row["nEstadoID"]);
				dFechaCreacion.SetDbValue(row["dFechaCreacion"]);
				dFechaModificacion.SetDbValue(row["dFechaModificacion"]);
			}

			#pragma warning restore 162, 168, 1998

			// Return a row with default values
			protected Dictionary<string, object> NewRow() {
				LoadDefaultValues();
				var row = new Dictionary<string, object>();
				row.Add("nAntecedenteDentalID", nAntecedenteDentalID.CurrentValue);
				row.Add("nExpedienteID", nExpedienteID.CurrentValue);
				row.Add("dFechaUltimaVisitaDentista", dFechaUltimaVisitaDentista.CurrentValue);
				row.Add("sMotivoVisita", sMotivoVisita.CurrentValue);
				row.Add("sExperienciaAsistencial", sExperienciaAsistencial.CurrentValue);
				row.Add("nTratamientoQuirurgico", nTratamientoQuirurgico.CurrentValue);
				row.Add("nTratamientoRestauracion", nTratamientoRestauracion.CurrentValue);
				row.Add("nTratamientoPeridoncia", nTratamientoPeridoncia.CurrentValue);
				row.Add("nTratamientoEndodoncia", nTratamientoEndodoncia.CurrentValue);
				row.Add("nTratamientoOrtodoncia", nTratamientoOrtodoncia.CurrentValue);
				row.Add("nTratamientoProtesis", nTratamientoProtesis.CurrentValue);
				row.Add("nColocadoAnestesia", nColocadoAnestesia.CurrentValue);
				row.Add("nReaccionAlergicaAnestesia", nReaccionAlergicaAnestesia.CurrentValue);
				row.Add("sReaccionAlergicaAnestesia", sReaccionAlergicaAnestesia.CurrentValue);
				row.Add("sDescripcionTejidosBlandos", sDescripcionTejidosBlandos.CurrentValue);
				row.Add("sHistoriaEnfermedadActual", sHistoriaEnfermedadActual.CurrentValue);
				row.Add("nEstadoID", nEstadoID.CurrentValue);
				row.Add("dFechaCreacion", dFechaCreacion.CurrentValue);
				row.Add("dFechaModificacion", dFechaModificacion.CurrentValue);
				return row;
			}

			#pragma warning disable 618, 1998

			// Load old record
			protected async Task<bool> LoadOldRecord(DatabaseConnectionBase<SqlConnection, SqlCommand, SqlDataReader, SqlDbType> cnn = null) {
				bool validKey = true;
				if (!Empty(GetKey("nAntecedenteDentalID")))
					nAntecedenteDentalID.CurrentValue = GetKey("nAntecedenteDentalID"); // nAntecedenteDentalID
				else
					validKey = false;

				// Load old record
				OldRecordset = null;
				if (validKey) {
					CurrentFilter = GetRecordFilter();
					string sql = CurrentSql;
					try {
						if (cnn != null) {
							OldRecordset = await cnn.OpenDataReaderAsync(sql);
						 } else {
							OldRecordset = await Connection.OpenDataReaderAsync(sql);
						 }
						if (OldRecordset != null)
							await OldRecordset.ReadAsync();
					} catch {
						OldRecordset = null;
					}
				}
				await LoadRowValues(OldRecordset); // Load row values
				return validKey;
			}

			#pragma warning restore 618, 1998

			#pragma warning disable 1998

			// Render row values based on field settings
			public async Task RenderRow() {

				// Call Row_Rendering event
				Row_Rendering();

				// Common render codes for all row types
				// nAntecedenteDentalID
				// nExpedienteID
				// dFechaUltimaVisitaDentista
				// sMotivoVisita
				// sExperienciaAsistencial
				// nTratamientoQuirurgico
				// nTratamientoRestauracion
				// nTratamientoPeridoncia
				// nTratamientoEndodoncia
				// nTratamientoOrtodoncia
				// nTratamientoProtesis
				// nColocadoAnestesia
				// nReaccionAlergicaAnestesia
				// sReaccionAlergicaAnestesia
				// sDescripcionTejidosBlandos
				// sHistoriaEnfermedadActual
				// nEstadoID
				// dFechaCreacion
				// dFechaModificacion

				if (RowType == Config.RowTypeView) { // View row

					// nExpedienteID
					curVal = Convert.ToString(nExpedienteID.CurrentValue);
					if (!Empty(curVal)) {
						nExpedienteID.ViewValue = nExpedienteID.LookupCacheOption(curVal);
						if (nExpedienteID.ViewValue == null) { // Lookup from database
							filterWrk = "[nExpedienteID]" + SearchString("=", curVal.Trim(), Config.DataTypeNumber, "");
							sqlWrk = nExpedienteID.Lookup.GetSql(false, filterWrk, null, this);
							rswrk = await Connection.GetRowsAsync(sqlWrk);
							if (rswrk != null && rswrk.Count > 0) { // Lookup values found
								var listwrk = rswrk[0].Values.ToList();
								listwrk[1] = Convert.ToString(FormatNumber(listwrk[1], 0, -2, -2, -2));
								listwrk[2] = Convert.ToString(listwrk[2]);
								listwrk[3] = Convert.ToString(listwrk[3]);
								listwrk[4] = Convert.ToString(listwrk[4]);
								nExpedienteID.ViewValue = nExpedienteID.DisplayValue(listwrk);
							} else {
								nExpedienteID.ViewValue = nExpedienteID.CurrentValue;
							}
						}
					} else {
						nExpedienteID.ViewValue = System.DBNull.Value;
					}

					// dFechaUltimaVisitaDentista
					dFechaUltimaVisitaDentista.ViewValue = dFechaUltimaVisitaDentista.CurrentValue;
					dFechaUltimaVisitaDentista.ViewValue = FormatDateTime(dFechaUltimaVisitaDentista.ViewValue, 0);

					// sMotivoVisita
					sMotivoVisita.ViewValue = sMotivoVisita.CurrentValue;

					// sExperienciaAsistencial
					sExperienciaAsistencial.ViewValue = sExperienciaAsistencial.CurrentValue;

					// nTratamientoQuirurgico
					if (ConvertToBool(nTratamientoQuirurgico.CurrentValue)) {
						nTratamientoQuirurgico.ViewValue = (nTratamientoQuirurgico.TagCaption(2) != "") ? nTratamientoQuirurgico.TagCaption(2) : "Si";
					} else {
						nTratamientoQuirurgico.ViewValue = (nTratamientoQuirurgico.TagCaption(1) != "") ? nTratamientoQuirurgico.TagCaption(1) : "No";
					}

					// nTratamientoRestauracion
					if (ConvertToBool(nTratamientoRestauracion.CurrentValue)) {
						nTratamientoRestauracion.ViewValue = (nTratamientoRestauracion.TagCaption(2) != "") ? nTratamientoRestauracion.TagCaption(2) : "Si";
					} else {
						nTratamientoRestauracion.ViewValue = (nTratamientoRestauracion.TagCaption(1) != "") ? nTratamientoRestauracion.TagCaption(1) : "No";
					}

					// nTratamientoPeridoncia
					if (ConvertToBool(nTratamientoPeridoncia.CurrentValue)) {
						nTratamientoPeridoncia.ViewValue = (nTratamientoPeridoncia.TagCaption(2) != "") ? nTratamientoPeridoncia.TagCaption(2) : "Si";
					} else {
						nTratamientoPeridoncia.ViewValue = (nTratamientoPeridoncia.TagCaption(1) != "") ? nTratamientoPeridoncia.TagCaption(1) : "No";
					}

					// nTratamientoEndodoncia
					if (ConvertToBool(nTratamientoEndodoncia.CurrentValue)) {
						nTratamientoEndodoncia.ViewValue = (nTratamientoEndodoncia.TagCaption(2) != "") ? nTratamientoEndodoncia.TagCaption(2) : "Si";
					} else {
						nTratamientoEndodoncia.ViewValue = (nTratamientoEndodoncia.TagCaption(1) != "") ? nTratamientoEndodoncia.TagCaption(1) : "No";
					}

					// nTratamientoOrtodoncia
					if (ConvertToBool(nTratamientoOrtodoncia.CurrentValue)) {
						nTratamientoOrtodoncia.ViewValue = (nTratamientoOrtodoncia.TagCaption(2) != "") ? nTratamientoOrtodoncia.TagCaption(2) : "Si";
					} else {
						nTratamientoOrtodoncia.ViewValue = (nTratamientoOrtodoncia.TagCaption(1) != "") ? nTratamientoOrtodoncia.TagCaption(1) : "No";
					}

					// nTratamientoProtesis
					if (ConvertToBool(nTratamientoProtesis.CurrentValue)) {
						nTratamientoProtesis.ViewValue = (nTratamientoProtesis.TagCaption(2) != "") ? nTratamientoProtesis.TagCaption(2) : "Si";
					} else {
						nTratamientoProtesis.ViewValue = (nTratamientoProtesis.TagCaption(1) != "") ? nTratamientoProtesis.TagCaption(1) : "No";
					}

					// nColocadoAnestesia
					if (ConvertToBool(nColocadoAnestesia.CurrentValue)) {
						nColocadoAnestesia.ViewValue = (nColocadoAnestesia.TagCaption(2) != "") ? nColocadoAnestesia.TagCaption(2) : "Si";
					} else {
						nColocadoAnestesia.ViewValue = (nColocadoAnestesia.TagCaption(1) != "") ? nColocadoAnestesia.TagCaption(1) : "No";
					}

					// nReaccionAlergicaAnestesia
					if (ConvertToBool(nReaccionAlergicaAnestesia.CurrentValue)) {
						nReaccionAlergicaAnestesia.ViewValue = (nReaccionAlergicaAnestesia.TagCaption(2) != "") ? nReaccionAlergicaAnestesia.TagCaption(2) : "Si";
					} else {
						nReaccionAlergicaAnestesia.ViewValue = (nReaccionAlergicaAnestesia.TagCaption(1) != "") ? nReaccionAlergicaAnestesia.TagCaption(1) : "No";
					}

					// sReaccionAlergicaAnestesia
					sReaccionAlergicaAnestesia.ViewValue = sReaccionAlergicaAnestesia.CurrentValue;

					// sDescripcionTejidosBlandos
					sDescripcionTejidosBlandos.ViewValue = sDescripcionTejidosBlandos.CurrentValue;

					// sHistoriaEnfermedadActual
					sHistoriaEnfermedadActual.ViewValue = sHistoriaEnfermedadActual.CurrentValue;

					// nEstadoID
					curVal = Convert.ToString(nEstadoID.CurrentValue);
					if (!Empty(curVal)) {
						nEstadoID.ViewValue = nEstadoID.LookupCacheOption(curVal);
						if (nEstadoID.ViewValue == null) { // Lookup from database
							filterWrk = "[nValorCatalogoID]" + SearchString("=", curVal.Trim(), Config.DataTypeNumber, "");
							lookupFilter = () => "nCatalogoID=10";
							sqlWrk = nEstadoID.Lookup.GetSql(false, filterWrk, lookupFilter, this);
							rswrk = await Connection.GetRowsAsync(sqlWrk);
							if (rswrk != null && rswrk.Count > 0) { // Lookup values found
								var listwrk = rswrk[0].Values.ToList();
								listwrk[1] = Convert.ToString(FormatNumber(listwrk[1], 0, -2, -2, -2));
								listwrk[2] = Convert.ToString(listwrk[2]);
								nEstadoID.ViewValue = nEstadoID.DisplayValue(listwrk);
							} else {
								nEstadoID.ViewValue = nEstadoID.CurrentValue;
							}
						}
					} else {
						nEstadoID.ViewValue = System.DBNull.Value;
					}

					// nExpedienteID
					nExpedienteID.HrefValue = "";
					nExpedienteID.TooltipValue = "";

					// dFechaUltimaVisitaDentista
					dFechaUltimaVisitaDentista.HrefValue = "";
					dFechaUltimaVisitaDentista.TooltipValue = "";

					// sMotivoVisita
					sMotivoVisita.HrefValue = "";
					sMotivoVisita.TooltipValue = "";

					// sExperienciaAsistencial
					sExperienciaAsistencial.HrefValue = "";
					sExperienciaAsistencial.TooltipValue = "";

					// nTratamientoQuirurgico
					nTratamientoQuirurgico.HrefValue = "";
					nTratamientoQuirurgico.TooltipValue = "";

					// nTratamientoRestauracion
					nTratamientoRestauracion.HrefValue = "";
					nTratamientoRestauracion.TooltipValue = "";

					// nTratamientoPeridoncia
					nTratamientoPeridoncia.HrefValue = "";
					nTratamientoPeridoncia.TooltipValue = "";

					// nTratamientoEndodoncia
					nTratamientoEndodoncia.HrefValue = "";
					nTratamientoEndodoncia.TooltipValue = "";

					// nTratamientoOrtodoncia
					nTratamientoOrtodoncia.HrefValue = "";
					nTratamientoOrtodoncia.TooltipValue = "";

					// nTratamientoProtesis
					nTratamientoProtesis.HrefValue = "";
					nTratamientoProtesis.TooltipValue = "";

					// nColocadoAnestesia
					nColocadoAnestesia.HrefValue = "";
					nColocadoAnestesia.TooltipValue = "";

					// nReaccionAlergicaAnestesia
					nReaccionAlergicaAnestesia.HrefValue = "";
					nReaccionAlergicaAnestesia.TooltipValue = "";

					// sReaccionAlergicaAnestesia
					sReaccionAlergicaAnestesia.HrefValue = "";
					sReaccionAlergicaAnestesia.TooltipValue = "";

					// sDescripcionTejidosBlandos
					sDescripcionTejidosBlandos.HrefValue = "";
					sDescripcionTejidosBlandos.TooltipValue = "";

					// sHistoriaEnfermedadActual
					sHistoriaEnfermedadActual.HrefValue = "";
					sHistoriaEnfermedadActual.TooltipValue = "";

					// nEstadoID
					nEstadoID.HrefValue = "";
					nEstadoID.TooltipValue = "";
				} else if (RowType == Config.RowTypeAdd) { // Add row

					// nExpedienteID
					curVal = Convert.ToString(nExpedienteID.CurrentValue).Trim();
					if (curVal != "")
						nExpedienteID.ViewValue = nExpedienteID.LookupCacheOption(curVal);
					else
						nExpedienteID.ViewValue = nExpedienteID.Lookup != null && IsList(nExpedienteID.Lookup.Options) ? curVal : null;
					if (nExpedienteID.ViewValue != null) { // Load from cache
						nExpedienteID.EditValue = nExpedienteID.Lookup.Options.Values.ToList();
						if (SameString(nExpedienteID.ViewValue, ""))
							nExpedienteID.ViewValue = Language.Phrase("PleaseSelect");
					} else { // Lookup from database
						if (curVal == "") {
							filterWrk = "0=1";
						} else {
							filterWrk = "[nExpedienteID]" + SearchString("=", Convert.ToString(nExpedienteID.CurrentValue), Config.DataTypeNumber, "");
						}
					sqlWrk = nExpedienteID.Lookup.GetSql(true, filterWrk, null, this);
					rswrk = await Connection.GetRowsAsync(sqlWrk);
					if (rswrk != null && rswrk.Count > 0) { // Lookup values found
						var listwrk = rswrk[0].Values.ToList();
						listwrk[1] = Convert.ToString(HtmlEncode(FormatNumber(listwrk[1], 0, -2, -2, -2)));
						listwrk[2] = Convert.ToString(HtmlEncode(listwrk[2]));
						listwrk[3] = Convert.ToString(HtmlEncode(listwrk[3]));
						listwrk[4] = Convert.ToString(HtmlEncode(listwrk[4]));
						nExpedienteID.ViewValue = nExpedienteID.DisplayValue(listwrk);
						foreach (var d in rswrk) {
							var keys = d.Keys.ToList();
							d[keys[1]] = FormatNumber(d[keys[1]], 0, -2, -2, -2);
						}
					} else {
						nExpedienteID.ViewValue = nExpedienteID.PleaseSelectText;
					}
					nExpedienteID.EditValue = rswrk;
					}

					// dFechaUltimaVisitaDentista
					dFechaUltimaVisitaDentista.EditAttrs["class"] = "form-control";
					dFechaUltimaVisitaDentista.EditValue = FormatDateTime(dFechaUltimaVisitaDentista.CurrentValue, 8); // DN
					dFechaUltimaVisitaDentista.PlaceHolder = RemoveHtml(dFechaUltimaVisitaDentista.Caption);

					// sMotivoVisita
					sMotivoVisita.EditAttrs["class"] = "form-control";
					sMotivoVisita.EditValue = sMotivoVisita.CurrentValue; // DN
					sMotivoVisita.PlaceHolder = RemoveHtml(sMotivoVisita.Caption);

					// sExperienciaAsistencial
					sExperienciaAsistencial.EditAttrs["class"] = "form-control";
					sExperienciaAsistencial.EditValue = sExperienciaAsistencial.CurrentValue; // DN
					sExperienciaAsistencial.PlaceHolder = RemoveHtml(sExperienciaAsistencial.Caption);

					// nTratamientoQuirurgico
					nTratamientoQuirurgico.EditAttrs["class"] = "form-control";
					nTratamientoQuirurgico.EditValue = nTratamientoQuirurgico.Options(true);

					// nTratamientoRestauracion
					nTratamientoRestauracion.EditAttrs["class"] = "form-control";
					nTratamientoRestauracion.EditValue = nTratamientoRestauracion.Options(true);

					// nTratamientoPeridoncia
					nTratamientoPeridoncia.EditAttrs["class"] = "form-control";
					nTratamientoPeridoncia.EditValue = nTratamientoPeridoncia.Options(true);

					// nTratamientoEndodoncia
					nTratamientoEndodoncia.EditAttrs["class"] = "form-control";
					nTratamientoEndodoncia.EditValue = nTratamientoEndodoncia.Options(true);

					// nTratamientoOrtodoncia
					nTratamientoOrtodoncia.EditAttrs["class"] = "form-control";
					nTratamientoOrtodoncia.EditValue = nTratamientoOrtodoncia.Options(true);

					// nTratamientoProtesis
					nTratamientoProtesis.EditAttrs["class"] = "form-control";
					nTratamientoProtesis.EditValue = nTratamientoProtesis.Options(true);

					// nColocadoAnestesia
					nColocadoAnestesia.EditAttrs["class"] = "form-control";
					nColocadoAnestesia.EditValue = nColocadoAnestesia.Options(true);

					// nReaccionAlergicaAnestesia
					nReaccionAlergicaAnestesia.EditAttrs["class"] = "form-control";
					nReaccionAlergicaAnestesia.EditValue = nReaccionAlergicaAnestesia.Options(true);

					// sReaccionAlergicaAnestesia
					sReaccionAlergicaAnestesia.EditAttrs["class"] = "form-control";
					sReaccionAlergicaAnestesia.EditValue = sReaccionAlergicaAnestesia.CurrentValue; // DN
					sReaccionAlergicaAnestesia.PlaceHolder = RemoveHtml(sReaccionAlergicaAnestesia.Caption);

					// sDescripcionTejidosBlandos
					sDescripcionTejidosBlandos.EditAttrs["class"] = "form-control";
					sDescripcionTejidosBlandos.EditValue = sDescripcionTejidosBlandos.CurrentValue; // DN
					sDescripcionTejidosBlandos.PlaceHolder = RemoveHtml(sDescripcionTejidosBlandos.Caption);

					// sHistoriaEnfermedadActual
					sHistoriaEnfermedadActual.EditAttrs["class"] = "form-control";
					sHistoriaEnfermedadActual.EditValue = sHistoriaEnfermedadActual.CurrentValue; // DN
					sHistoriaEnfermedadActual.PlaceHolder = RemoveHtml(sHistoriaEnfermedadActual.Caption);

					// nEstadoID
					curVal = Convert.ToString(nEstadoID.CurrentValue).Trim();
					if (curVal != "")
						nEstadoID.ViewValue = nEstadoID.LookupCacheOption(curVal);
					else
						nEstadoID.ViewValue = nEstadoID.Lookup != null && IsList(nEstadoID.Lookup.Options) ? curVal : null;
					if (nEstadoID.ViewValue != null) { // Load from cache
						nEstadoID.EditValue = nEstadoID.Lookup.Options.Values.ToList();
						if (SameString(nEstadoID.ViewValue, ""))
							nEstadoID.ViewValue = Language.Phrase("PleaseSelect");
					} else { // Lookup from database
						if (curVal == "") {
							filterWrk = "0=1";
						} else {
							filterWrk = "[nValorCatalogoID]" + SearchString("=", Convert.ToString(nEstadoID.CurrentValue), Config.DataTypeNumber, "");
						}
					lookupFilter = () => "nCatalogoID=10";
					sqlWrk = nEstadoID.Lookup.GetSql(true, filterWrk, lookupFilter, this);
					rswrk = await Connection.GetRowsAsync(sqlWrk);
					if (rswrk != null && rswrk.Count > 0) { // Lookup values found
						var listwrk = rswrk[0].Values.ToList();
						listwrk[1] = Convert.ToString(HtmlEncode(FormatNumber(listwrk[1], 0, -2, -2, -2)));
						listwrk[2] = Convert.ToString(HtmlEncode(listwrk[2]));
						nEstadoID.ViewValue = nEstadoID.DisplayValue(listwrk);
						foreach (var d in rswrk) {
							var keys = d.Keys.ToList();
							d[keys[1]] = FormatNumber(d[keys[1]], 0, -2, -2, -2);
						}
					} else {
						nEstadoID.ViewValue = nEstadoID.PleaseSelectText;
					}
					nEstadoID.EditValue = rswrk;
					}

					// Add refer script
					// nExpedienteID

					nExpedienteID.HrefValue = "";

					// dFechaUltimaVisitaDentista
					dFechaUltimaVisitaDentista.HrefValue = "";

					// sMotivoVisita
					sMotivoVisita.HrefValue = "";

					// sExperienciaAsistencial
					sExperienciaAsistencial.HrefValue = "";

					// nTratamientoQuirurgico
					nTratamientoQuirurgico.HrefValue = "";

					// nTratamientoRestauracion
					nTratamientoRestauracion.HrefValue = "";

					// nTratamientoPeridoncia
					nTratamientoPeridoncia.HrefValue = "";

					// nTratamientoEndodoncia
					nTratamientoEndodoncia.HrefValue = "";

					// nTratamientoOrtodoncia
					nTratamientoOrtodoncia.HrefValue = "";

					// nTratamientoProtesis
					nTratamientoProtesis.HrefValue = "";

					// nColocadoAnestesia
					nColocadoAnestesia.HrefValue = "";

					// nReaccionAlergicaAnestesia
					nReaccionAlergicaAnestesia.HrefValue = "";

					// sReaccionAlergicaAnestesia
					sReaccionAlergicaAnestesia.HrefValue = "";

					// sDescripcionTejidosBlandos
					sDescripcionTejidosBlandos.HrefValue = "";

					// sHistoriaEnfermedadActual
					sHistoriaEnfermedadActual.HrefValue = "";

					// nEstadoID
					nEstadoID.HrefValue = "";
				}
				if (RowType == Config.RowTypeAdd || RowType == Config.RowTypeEdit || RowType == Config.RowTypeSearch) // Add/Edit/Search row
					SetupFieldTitles();

				// Call Row Rendered event
				if (RowType != Config.RowTypeAggregateInit)
					Row_Rendered();
			}

			#pragma warning restore 1998

			#pragma warning disable 1998

			// Validate form
			protected async Task<bool> ValidateForm() {

				// Initialize form error message
				FormError = "";

				// Check if validation required
				if (!Config.ServerValidate)
					return (FormError == "");
				if (nAntecedenteDentalID.Required) {
					if (!nAntecedenteDentalID.IsDetailKey && Empty(nAntecedenteDentalID.FormValue))
						FormError = AddMessage(FormError, nAntecedenteDentalID.RequiredErrorMessage.Replace("%s", nAntecedenteDentalID.Caption));
				}
				if (nExpedienteID.Required) {
					if (!nExpedienteID.IsDetailKey && Empty(nExpedienteID.FormValue))
						FormError = AddMessage(FormError, nExpedienteID.RequiredErrorMessage.Replace("%s", nExpedienteID.Caption));
				}
				if (dFechaUltimaVisitaDentista.Required) {
					if (!dFechaUltimaVisitaDentista.IsDetailKey && Empty(dFechaUltimaVisitaDentista.FormValue))
						FormError = AddMessage(FormError, dFechaUltimaVisitaDentista.RequiredErrorMessage.Replace("%s", dFechaUltimaVisitaDentista.Caption));
				}
				if (!CheckDate(dFechaUltimaVisitaDentista.FormValue))
					FormError = AddMessage(FormError, dFechaUltimaVisitaDentista.ErrorMessage);
				if (sMotivoVisita.Required) {
					if (!sMotivoVisita.IsDetailKey && Empty(sMotivoVisita.FormValue))
						FormError = AddMessage(FormError, sMotivoVisita.RequiredErrorMessage.Replace("%s", sMotivoVisita.Caption));
				}
				if (sExperienciaAsistencial.Required) {
					if (!sExperienciaAsistencial.IsDetailKey && Empty(sExperienciaAsistencial.FormValue))
						FormError = AddMessage(FormError, sExperienciaAsistencial.RequiredErrorMessage.Replace("%s", sExperienciaAsistencial.Caption));
				}
				if (nTratamientoQuirurgico.Required) {
					if (!nTratamientoQuirurgico.IsDetailKey && Empty(nTratamientoQuirurgico.FormValue))
						FormError = AddMessage(FormError, nTratamientoQuirurgico.RequiredErrorMessage.Replace("%s", nTratamientoQuirurgico.Caption));
				}
				if (nTratamientoRestauracion.Required) {
					if (!nTratamientoRestauracion.IsDetailKey && Empty(nTratamientoRestauracion.FormValue))
						FormError = AddMessage(FormError, nTratamientoRestauracion.RequiredErrorMessage.Replace("%s", nTratamientoRestauracion.Caption));
				}
				if (nTratamientoPeridoncia.Required) {
					if (!nTratamientoPeridoncia.IsDetailKey && Empty(nTratamientoPeridoncia.FormValue))
						FormError = AddMessage(FormError, nTratamientoPeridoncia.RequiredErrorMessage.Replace("%s", nTratamientoPeridoncia.Caption));
				}
				if (nTratamientoEndodoncia.Required) {
					if (!nTratamientoEndodoncia.IsDetailKey && Empty(nTratamientoEndodoncia.FormValue))
						FormError = AddMessage(FormError, nTratamientoEndodoncia.RequiredErrorMessage.Replace("%s", nTratamientoEndodoncia.Caption));
				}
				if (nTratamientoOrtodoncia.Required) {
					if (!nTratamientoOrtodoncia.IsDetailKey && Empty(nTratamientoOrtodoncia.FormValue))
						FormError = AddMessage(FormError, nTratamientoOrtodoncia.RequiredErrorMessage.Replace("%s", nTratamientoOrtodoncia.Caption));
				}
				if (nTratamientoProtesis.Required) {
					if (!nTratamientoProtesis.IsDetailKey && Empty(nTratamientoProtesis.FormValue))
						FormError = AddMessage(FormError, nTratamientoProtesis.RequiredErrorMessage.Replace("%s", nTratamientoProtesis.Caption));
				}
				if (nColocadoAnestesia.Required) {
					if (!nColocadoAnestesia.IsDetailKey && Empty(nColocadoAnestesia.FormValue))
						FormError = AddMessage(FormError, nColocadoAnestesia.RequiredErrorMessage.Replace("%s", nColocadoAnestesia.Caption));
				}
				if (nReaccionAlergicaAnestesia.Required) {
					if (!nReaccionAlergicaAnestesia.IsDetailKey && Empty(nReaccionAlergicaAnestesia.FormValue))
						FormError = AddMessage(FormError, nReaccionAlergicaAnestesia.RequiredErrorMessage.Replace("%s", nReaccionAlergicaAnestesia.Caption));
				}
				if (sReaccionAlergicaAnestesia.Required) {
					if (!sReaccionAlergicaAnestesia.IsDetailKey && Empty(sReaccionAlergicaAnestesia.FormValue))
						FormError = AddMessage(FormError, sReaccionAlergicaAnestesia.RequiredErrorMessage.Replace("%s", sReaccionAlergicaAnestesia.Caption));
				}
				if (sDescripcionTejidosBlandos.Required) {
					if (!sDescripcionTejidosBlandos.IsDetailKey && Empty(sDescripcionTejidosBlandos.FormValue))
						FormError = AddMessage(FormError, sDescripcionTejidosBlandos.RequiredErrorMessage.Replace("%s", sDescripcionTejidosBlandos.Caption));
				}
				if (sHistoriaEnfermedadActual.Required) {
					if (!sHistoriaEnfermedadActual.IsDetailKey && Empty(sHistoriaEnfermedadActual.FormValue))
						FormError = AddMessage(FormError, sHistoriaEnfermedadActual.RequiredErrorMessage.Replace("%s", sHistoriaEnfermedadActual.Caption));
				}
				if (nEstadoID.Required) {
					if (!nEstadoID.IsDetailKey && Empty(nEstadoID.FormValue))
						FormError = AddMessage(FormError, nEstadoID.RequiredErrorMessage.Replace("%s", nEstadoID.Caption));
				}
				if (dFechaCreacion.Required) {
					if (!dFechaCreacion.IsDetailKey && Empty(dFechaCreacion.FormValue))
						FormError = AddMessage(FormError, dFechaCreacion.RequiredErrorMessage.Replace("%s", dFechaCreacion.Caption));
				}
				if (dFechaModificacion.Required) {
					if (!dFechaModificacion.IsDetailKey && Empty(dFechaModificacion.FormValue))
						FormError = AddMessage(FormError, dFechaModificacion.RequiredErrorMessage.Replace("%s", dFechaModificacion.Caption));
				}

				// Return validate result
				bool valid = Empty(FormError);

				// Call Form_CustomValidate event
				string formCustomError = "";
				valid = valid && Form_CustomValidate(ref formCustomError);
				FormError = AddMessage(FormError, formCustomError);
				return valid;
			}

			#pragma warning restore 1998

			// Save data to memory cache
			public void SetCache<T>(string key, T value, int span) => Cache.Set<T>(key, value, new MemoryCacheEntryOptions()
				.SetSlidingExpiration(TimeSpan.FromMilliseconds(span))); // Keep in cache for this time, reset time if accessed

			// Gete data from memory cache
			public void GetCache<T>(string key) => Cache.Get<T>(key);

			// Add record

			#pragma warning disable 168, 219

			protected async Task<JsonBoolResult> AddRow(Dictionary<string, object> rsold = null) { // DN
				bool result = false;
				var rsnew = new Dictionary<string, object>();

				// Load db values from rsold
				LoadDbValues(rsold);
				if (rsold != null) {
				}
				try {

					// nExpedienteID
					nExpedienteID.SetDbValue(rsnew, nExpedienteID.CurrentValue, 0, false);

					// dFechaUltimaVisitaDentista
					dFechaUltimaVisitaDentista.SetDbValue(rsnew, UnformatDateTime(dFechaUltimaVisitaDentista.CurrentValue, 0), System.DBNull.Value, false);

					// sMotivoVisita
					sMotivoVisita.SetDbValue(rsnew, sMotivoVisita.CurrentValue, System.DBNull.Value, false);

					// sExperienciaAsistencial
					sExperienciaAsistencial.SetDbValue(rsnew, sExperienciaAsistencial.CurrentValue, System.DBNull.Value, false);

					// nTratamientoQuirurgico
					nTratamientoQuirurgico.SetDbValue(rsnew, SameString(nTratamientoQuirurgico.CurrentValue, "1") ? "1" : "0", System.DBNull.Value, Empty(nTratamientoQuirurgico.CurrentValue)); // DN1204

					// nTratamientoRestauracion
					nTratamientoRestauracion.SetDbValue(rsnew, SameString(nTratamientoRestauracion.CurrentValue, "1") ? "1" : "0", System.DBNull.Value, Empty(nTratamientoRestauracion.CurrentValue)); // DN1204

					// nTratamientoPeridoncia
					nTratamientoPeridoncia.SetDbValue(rsnew, SameString(nTratamientoPeridoncia.CurrentValue, "1") ? "1" : "0", System.DBNull.Value, Empty(nTratamientoPeridoncia.CurrentValue)); // DN1204

					// nTratamientoEndodoncia
					nTratamientoEndodoncia.SetDbValue(rsnew, SameString(nTratamientoEndodoncia.CurrentValue, "1") ? "1" : "0", System.DBNull.Value, Empty(nTratamientoEndodoncia.CurrentValue)); // DN1204

					// nTratamientoOrtodoncia
					nTratamientoOrtodoncia.SetDbValue(rsnew, SameString(nTratamientoOrtodoncia.CurrentValue, "1") ? "1" : "0", System.DBNull.Value, Empty(nTratamientoOrtodoncia.CurrentValue)); // DN1204

					// nTratamientoProtesis
					nTratamientoProtesis.SetDbValue(rsnew, SameString(nTratamientoProtesis.CurrentValue, "1") ? "1" : "0", System.DBNull.Value, Empty(nTratamientoProtesis.CurrentValue)); // DN1204

					// nColocadoAnestesia
					nColocadoAnestesia.SetDbValue(rsnew, SameString(nColocadoAnestesia.CurrentValue, "1") ? "1" : "0", System.DBNull.Value, Empty(nColocadoAnestesia.CurrentValue)); // DN1204

					// nReaccionAlergicaAnestesia
					nReaccionAlergicaAnestesia.SetDbValue(rsnew, SameString(nReaccionAlergicaAnestesia.CurrentValue, "1") ? "1" : "0", System.DBNull.Value, Empty(nReaccionAlergicaAnestesia.CurrentValue)); // DN1204

					// sReaccionAlergicaAnestesia
					sReaccionAlergicaAnestesia.SetDbValue(rsnew, sReaccionAlergicaAnestesia.CurrentValue, System.DBNull.Value, Empty(sReaccionAlergicaAnestesia.CurrentValue));

					// sDescripcionTejidosBlandos
					sDescripcionTejidosBlandos.SetDbValue(rsnew, sDescripcionTejidosBlandos.CurrentValue, System.DBNull.Value, Empty(sDescripcionTejidosBlandos.CurrentValue));

					// sHistoriaEnfermedadActual
					sHistoriaEnfermedadActual.SetDbValue(rsnew, sHistoriaEnfermedadActual.CurrentValue, System.DBNull.Value, Empty(sHistoriaEnfermedadActual.CurrentValue));

					// nEstadoID
					nEstadoID.SetDbValue(rsnew, nEstadoID.CurrentValue, 0, false);
				} catch (Exception e) {
					if (Config.Debug)
						throw;
					FailureMessage = e.Message;
					return JsonBoolResult.FalseResult;
				}

				// Call Row Inserting event
				bool insertRow = Row_Inserting(rsold, rsnew);
				if (insertRow) {
					try {
						await InsertAsync(rsnew);
						result = true;
					} catch (Exception e) {
						if (Config.Debug)
							throw;
						FailureMessage = e.Message;
						result = false;
					}
				} else {
					if (SuccessMessage != "" || FailureMessage != "") {

						// Use the message, do nothing
					} else if (CancelMessage != "") {
						FailureMessage = CancelMessage;
						CancelMessage = "";
					} else {
						FailureMessage = Language.Phrase("InsertCancelled");
					}
					result = false;
				}

				// Call Row Inserted event
				if (result)
					Row_Inserted(rsold, rsnew);

				// Write JSON for API request
				var d = new Dictionary<string, object>();
				d.Add("success", result);
				if (IsApi() && result) {
					var row = GetRecordFromDictionary(rsnew);
					d.Add(TableVar, row);
					d.Add("version", Config.ProductVersion);
					return new JsonBoolResult(d, result);
				}
				return new JsonBoolResult(d, result);
			}

			// Set up Breadcrumb
			protected void SetupBreadcrumb() {
				var breadcrumb = new Breadcrumb();
				string url = CurrentUrl();
				breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("AntecedenteDentallist")), "", TableVar, true);
				string pageId = IsCopy ? "Copy" : "Add";
				breadcrumb.Add("add", pageId, url);
				CurrentBreadcrumb = breadcrumb;
			}

			// Setup lookup options
			public async Task SetupLookupOptions(DbField fld)
			{
				Func<string> lookupFilter = null;
				if (!Empty(fld.Lookup) && fld.Lookup.Options.Count == 0) {

					// Set up lookup SQL
					switch (fld.FieldVar) {
						case "x_nEstadoID":
							lookupFilter = () => "nCatalogoID=10";
							break;
						default:
							break;
					}

					// Always call to Lookup.GetSql so that user can setup Lookup.Options in Lookup_Selecting server event
					var sql = fld.Lookup.GetSql(false, "", lookupFilter, this);

					// Set up lookup cache
					if (fld.UseLookupCache && !Empty(sql) && fld.Lookup.ParentFields.Count == 0 && fld.Lookup.Options.Count == 0) {
						int totalCnt = await TryGetRecordCount(sql);
						if (totalCnt > fld.LookupCacheCount) // Total count > cache count, do not cache
							return;
						var ar = new Dictionary<string, Dictionary<string, object>>();
						var values = new List<object>();
						var conn = await GetConnectionAsync();
						List<Dictionary<string, object>> rs = await conn.GetRowsAsync(sql);
						if (rs != null) {
							foreach (var row in rs) {

								// Format the field values
								switch (fld.FieldVar) {
									case "x_nExpedienteID":

										//row[1] = FormatNumber(row[1], 0, -2, -2, -2);
										//row["df"] = row[1];

										values = row.Values.ToList();
										row["df"] = FormatNumber(values[1], 0, -2, -2, -2);
									break;
								}

								// Format the field values
								switch (fld.FieldVar) {
									case "x_nEstadoID":

										//row[1] = FormatNumber(row[1], 0, -2, -2, -2);
										//row["df"] = row[1];

										values = row.Values.ToList();
										row["df"] = FormatNumber(values[1], 0, -2, -2, -2);
									break;
								}
								if (!ar.ContainsKey(row.Values.First().ToString()))
									ar.Add(row.Values.First().ToString(), row);
							}
						}
						fld.Lookup.Options = ar;
					}
				}
			}

			// Close recordset
			public void CloseRecordset() {
				using (Recordset) {} // Dispose
			}

			// Page Load event
			public virtual void Page_Load() {

				//Log("Page Load");
			}

			// Page Unload event
			public virtual void Page_Unload() {

				//Log("Page Unload");
			}

			// Page Redirecting event
			public virtual void Page_Redirecting(ref string url) {

				//url = newurl;
			}

			// Message Showing event
			// type = ""|"success"|"failure"|"warning"

			public virtual void Message_Showing(ref string msg, string type) {

				// Note: Do not change msg outside the following 4 cases.
				if (type == "success") {

					//msg = "your success message";
				} else if (type == "failure") {

					//msg = "your failure message";
				} else if (type == "warning") {

					//msg = "your warning message";
				} else {

					//msg = "your message";
				}
			}

			// Page Load event
			public virtual void Page_Render() {

				//Log("Page Render");
			}

			// Page Data Rendering event
			public virtual void Page_DataRendering(ref string header) {

				// Example:
				//header = "your header";

			}

			// Page Data Rendered event
			public virtual void Page_DataRendered(ref string footer) {

				// Example:
				//footer = "your footer";

			}

			// Form Custom Validate event
			public virtual bool Form_CustomValidate(ref string customError) {

				//Return error message in customError
				return true;
			}
		}
	}
}
