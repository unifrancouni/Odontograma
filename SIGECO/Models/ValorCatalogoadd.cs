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
		/// ValorCatalogo_Add
		/// </summary>

		public static _ValorCatalogo_Add ValorCatalogo_Add {
			get => HttpData.Get<_ValorCatalogo_Add>("ValorCatalogo_Add");
			set => HttpData["ValorCatalogo_Add"] = value;
		}

		/// <summary>
		/// Page class for ValorCatalogo
		/// </summary>

		public class _ValorCatalogo_Add : _ValorCatalogo_AddBase
		{

			// Construtor
			public _ValorCatalogo_Add(Controller controller = null) : base(controller) {
			}
		}

		/// <summary>
		/// Page base class
		/// </summary>

		public class _ValorCatalogo_AddBase : _ValorCatalogo, IAspNetMakerPage
		{

			// Page ID
			public string PageID = "add";

			// Project ID
			public string ProjectID = "{9B083C8B-EE2F-4356-BE8D-9A26D5707365}";

			// Table name
			public string TableName = "ValorCatalogo";

			// Page object name
			public string PageObjName = "ValorCatalogo_Add";

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
			public _ValorCatalogo_AddBase(Controller controller = null) { // DN
				if (controller != null)
					Controller = controller;

				// Initialize
				CurrentPage = this;

				// Language object
				Language = Language ?? new Lang();

				// Table object (ValorCatalogo)
				if (ValorCatalogo == null || ValorCatalogo is _ValorCatalogo)
					ValorCatalogo = this;

				// Table object (Catalogo)
				Catalogo = Catalogo ?? new _Catalogo();

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
					dynamic doc = CreateInstance(classname, new object[] { ValorCatalogo, "" }); // DN
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
								if (pageName == "ValorCatalogoview")
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
				key += UrlEncode(Convert.ToString(ar["nValorCatalogoID"]));
				return key;
			}

			// Hide fields for Add/Edit
			protected void HideFieldsForAddEdit() {
				if (IsAdd || IsCopy || IsGridAdd)
					nValorCatalogoID.Visible = false;
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
							return Terminate(GetUrl("ValorCatalogolist"));
						else
							return Terminate(GetUrl("login"));
					}
				}

				// Create form object
				CurrentForm = new HttpForm();
				CurrentAction = Param("action"); // Set up current action
				nValorCatalogoID.Visible = false;
				nCatalogoID.SetVisibility();
				nCodigo.SetVisibility();
				sDescripcion.SetVisibility();
				nActivo.SetVisibility();
				dFechaCreacion.Visible = false;
				dFechaModificacion.Visible = false;
				nValorCatalogoUsuario.Visible = false;
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
				await SetupLookupOptions(nCatalogoID);

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
					if (RouteValues.TryGetValue("nValorCatalogoID", out rv)) { // DN
						nValorCatalogoID.QueryValue = Convert.ToString(rv);
						SetKey("nValorCatalogoID", nValorCatalogoID.CurrentValue); // Set up key
					} else if (!Empty(Get("nValorCatalogoID"))) {
						nValorCatalogoID.QueryValue = Get("nValorCatalogoID");
						SetKey("nValorCatalogoID", nValorCatalogoID.CurrentValue); // Set up key
					} else if (IsApi() && !Empty(keyValues)) {
						nValorCatalogoID.QueryValue = Convert.ToString(keyValues[0]);
						SetKey("nValorCatalogoID", nValorCatalogoID.CurrentValue); // Set up key
					} else {
						SetKey("nValorCatalogoID", ""); // Clear key
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

				// Set up master/detail parameters
				// NOTE: must be after loadOldRecord to prevent master key values overwritten

				SetupMasterParms();

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
							return Terminate("ValorCatalogolist"); // No matching record, return to List page // DN
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
							if (GetPageName(returnUrl) == "ValorCatalogolist")
								returnUrl = AddMasterUrl(ListUrl); // List page, return to List page with correct master key if necessary
							else if (GetPageName(returnUrl) == "ValorCatalogoview")
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
				nValorCatalogoID.CurrentValue = System.DBNull.Value;
				nValorCatalogoID.OldValue = nValorCatalogoID.CurrentValue;
				nCatalogoID.CurrentValue = System.DBNull.Value;
				nCatalogoID.OldValue = nCatalogoID.CurrentValue;
				nCodigo.CurrentValue = System.DBNull.Value;
				nCodigo.OldValue = nCodigo.CurrentValue;
				sDescripcion.CurrentValue = System.DBNull.Value;
				sDescripcion.OldValue = sDescripcion.CurrentValue;
				nActivo.CurrentValue = System.DBNull.Value;
				nActivo.OldValue = nActivo.CurrentValue;
				dFechaCreacion.CurrentValue = System.DBNull.Value;
				dFechaCreacion.OldValue = dFechaCreacion.CurrentValue;
				dFechaModificacion.CurrentValue = System.DBNull.Value;
				dFechaModificacion.OldValue = dFechaModificacion.CurrentValue;
				nValorCatalogoUsuario.CurrentValue = nValorCatalogoUsuario.GetDefault();
			}

			#pragma warning disable 1998

			// Load form values
			protected async Task LoadFormValues() {
				string val;

				// Check field name 'nCatalogoID' first before field var 'x_nCatalogoID'
				val = CurrentForm.GetValue("nCatalogoID", "x_nCatalogoID");
				if (!nCatalogoID.IsDetailKey) {
					if (IsApi() && val == null)
						nCatalogoID.Visible = false; // Disable update for API request
					else
						nCatalogoID.FormValue = val;
				}

				// Check field name 'nCodigo' first before field var 'x_nCodigo'
				val = CurrentForm.GetValue("nCodigo", "x_nCodigo");
				if (!nCodigo.IsDetailKey) {
					if (IsApi() && val == null)
						nCodigo.Visible = false; // Disable update for API request
					else
						nCodigo.FormValue = val;
				}

				// Check field name 'sDescripcion' first before field var 'x_sDescripcion'
				val = CurrentForm.GetValue("sDescripcion", "x_sDescripcion");
				if (!sDescripcion.IsDetailKey) {
					if (IsApi() && val == null)
						sDescripcion.Visible = false; // Disable update for API request
					else
						sDescripcion.FormValue = val;
				}

				// Check field name 'nActivo' first before field var 'x_nActivo'
				val = CurrentForm.GetValue("nActivo", "x_nActivo");
				if (!nActivo.IsDetailKey) {
					if (IsApi() && val == null)
						nActivo.Visible = false; // Disable update for API request
					else
						nActivo.FormValue = val;
				}

				// Check field name 'nValorCatalogoID' first before field var 'x_nValorCatalogoID'
				val = CurrentForm.GetValue("nValorCatalogoID", "x_nValorCatalogoID");
			}

			#pragma warning restore 1998

			// Restore form values
			public void RestoreFormValues() {
				nCatalogoID.CurrentValue = nCatalogoID.FormValue;
				nCodigo.CurrentValue = nCodigo.FormValue;
				sDescripcion.CurrentValue = sDescripcion.FormValue;
				nActivo.CurrentValue = nActivo.FormValue;
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
				nValorCatalogoID.SetDbValue(row["nValorCatalogoID"]);
				nCatalogoID.SetDbValue(row["nCatalogoID"]);
				nCodigo.SetDbValue(row["nCodigo"]);
				sDescripcion.SetDbValue(row["sDescripcion"]);
				nActivo.SetDbValue(row["nActivo"]);
				dFechaCreacion.SetDbValue(row["dFechaCreacion"]);
				dFechaModificacion.SetDbValue(row["dFechaModificacion"]);
				nValorCatalogoUsuario.SetDbValue((ConvertToBool(row["nValorCatalogoUsuario"]) ? "1" : "0"));
			}

			#pragma warning restore 162, 168, 1998

			// Return a row with default values
			protected Dictionary<string, object> NewRow() {
				LoadDefaultValues();
				var row = new Dictionary<string, object>();
				row.Add("nValorCatalogoID", nValorCatalogoID.CurrentValue);
				row.Add("nCatalogoID", nCatalogoID.CurrentValue);
				row.Add("nCodigo", nCodigo.CurrentValue);
				row.Add("sDescripcion", sDescripcion.CurrentValue);
				row.Add("nActivo", nActivo.CurrentValue);
				row.Add("dFechaCreacion", dFechaCreacion.CurrentValue);
				row.Add("dFechaModificacion", dFechaModificacion.CurrentValue);
				row.Add("nValorCatalogoUsuario", nValorCatalogoUsuario.CurrentValue);
				return row;
			}

			#pragma warning disable 618, 1998

			// Load old record
			protected async Task<bool> LoadOldRecord(DatabaseConnectionBase<SqlConnection, SqlCommand, SqlDataReader, SqlDbType> cnn = null) {
				bool validKey = true;
				if (!Empty(GetKey("nValorCatalogoID")))
					nValorCatalogoID.CurrentValue = GetKey("nValorCatalogoID"); // nValorCatalogoID
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
				// nValorCatalogoID
				// nCatalogoID
				// nCodigo
				// sDescripcion
				// nActivo
				// dFechaCreacion
				// dFechaModificacion
				// nValorCatalogoUsuario

				if (RowType == Config.RowTypeView) { // View row

					// nCatalogoID
					curVal = Convert.ToString(nCatalogoID.CurrentValue);
					if (!Empty(curVal)) {
						nCatalogoID.ViewValue = nCatalogoID.LookupCacheOption(curVal);
						if (nCatalogoID.ViewValue == null) { // Lookup from database
							filterWrk = "[nCatalogoID]" + SearchString("=", curVal.Trim(), Config.DataTypeNumber, "");
							lookupFilter = () => "nCatalogoUsuario=1";
							sqlWrk = nCatalogoID.Lookup.GetSql(false, filterWrk, lookupFilter, this);
							rswrk = await Connection.GetRowsAsync(sqlWrk);
							if (rswrk != null && rswrk.Count > 0) { // Lookup values found
								var listwrk = rswrk[0].Values.ToList();
								listwrk[1] = Convert.ToString(FormatNumber(listwrk[1], 0, -2, -2, -2));
								listwrk[2] = Convert.ToString(listwrk[2]);
								nCatalogoID.ViewValue = nCatalogoID.DisplayValue(listwrk);
							} else {
								nCatalogoID.ViewValue = nCatalogoID.CurrentValue;
							}
						}
					} else {
						nCatalogoID.ViewValue = System.DBNull.Value;
					}

					// nCodigo
					nCodigo.ViewValue = nCodigo.CurrentValue;
					nCodigo.ViewValue = FormatNumber(nCodigo.ViewValue, 0, -2, -2, -2);

					// sDescripcion
					sDescripcion.ViewValue = sDescripcion.CurrentValue;

					// nActivo
					if (!Empty(nActivo.CurrentValue)) {
							nActivo.ViewValue = nActivo.OptionCaption(Convert.ToString(nActivo.CurrentValue));
					} else {
						nActivo.ViewValue = System.DBNull.Value;
					}

					// nCatalogoID
					nCatalogoID.HrefValue = "";
					nCatalogoID.TooltipValue = "";

					// nCodigo
					nCodigo.HrefValue = "";
					nCodigo.TooltipValue = "";

					// sDescripcion
					sDescripcion.HrefValue = "";
					sDescripcion.TooltipValue = "";

					// nActivo
					nActivo.HrefValue = "";
					nActivo.TooltipValue = "";
				} else if (RowType == Config.RowTypeAdd) { // Add row

					// nCatalogoID
					if (!Empty(nCatalogoID.SessionValue)) {
						nCatalogoID.CurrentValue = nCatalogoID.SessionValue;
					curVal = Convert.ToString(nCatalogoID.CurrentValue);
					if (!Empty(curVal)) {
						nCatalogoID.ViewValue = nCatalogoID.LookupCacheOption(curVal);
						if (nCatalogoID.ViewValue == null) { // Lookup from database
							filterWrk = "[nCatalogoID]" + SearchString("=", curVal.Trim(), Config.DataTypeNumber, "");
							lookupFilter = () => "nCatalogoUsuario=1";
							sqlWrk = nCatalogoID.Lookup.GetSql(false, filterWrk, lookupFilter, this);
							rswrk = await Connection.GetRowsAsync(sqlWrk);
							if (rswrk != null && rswrk.Count > 0) { // Lookup values found
								var listwrk = rswrk[0].Values.ToList();
								listwrk[1] = Convert.ToString(FormatNumber(listwrk[1], 0, -2, -2, -2));
								listwrk[2] = Convert.ToString(listwrk[2]);
								nCatalogoID.ViewValue = nCatalogoID.DisplayValue(listwrk);
							} else {
								nCatalogoID.ViewValue = nCatalogoID.CurrentValue;
							}
						}
					} else {
						nCatalogoID.ViewValue = System.DBNull.Value;
					}
					} else {
					curVal = Convert.ToString(nCatalogoID.CurrentValue).Trim();
					if (curVal != "")
						nCatalogoID.ViewValue = nCatalogoID.LookupCacheOption(curVal);
					else
						nCatalogoID.ViewValue = nCatalogoID.Lookup != null && IsList(nCatalogoID.Lookup.Options) ? curVal : null;
					if (nCatalogoID.ViewValue != null) { // Load from cache
						nCatalogoID.EditValue = nCatalogoID.Lookup.Options.Values.ToList();
						if (SameString(nCatalogoID.ViewValue, ""))
							nCatalogoID.ViewValue = Language.Phrase("PleaseSelect");
					} else { // Lookup from database
						if (curVal == "") {
							filterWrk = "0=1";
						} else {
							filterWrk = "[nCatalogoID]" + SearchString("=", Convert.ToString(nCatalogoID.CurrentValue), Config.DataTypeNumber, "");
						}
					lookupFilter = () => "nCatalogoUsuario=1";
					sqlWrk = nCatalogoID.Lookup.GetSql(true, filterWrk, lookupFilter, this);
					rswrk = await Connection.GetRowsAsync(sqlWrk);
					if (rswrk != null && rswrk.Count > 0) { // Lookup values found
						var listwrk = rswrk[0].Values.ToList();
						listwrk[1] = Convert.ToString(HtmlEncode(FormatNumber(listwrk[1], 0, -2, -2, -2)));
						listwrk[2] = Convert.ToString(HtmlEncode(listwrk[2]));
						nCatalogoID.ViewValue = nCatalogoID.DisplayValue(listwrk);
						foreach (var d in rswrk) {
							var keys = d.Keys.ToList();
							d[keys[1]] = FormatNumber(d[keys[1]], 0, -2, -2, -2);
						}
					} else {
						nCatalogoID.ViewValue = nCatalogoID.PleaseSelectText;
					}
					nCatalogoID.EditValue = rswrk;
					}
					}

					// nCodigo
					nCodigo.EditAttrs["class"] = "form-control";
					nCodigo.EditValue = nCodigo.CurrentValue; // DN
					nCodigo.PlaceHolder = RemoveHtml(nCodigo.Caption);

					// sDescripcion
					sDescripcion.EditAttrs["class"] = "form-control";
					if (Config.RemoveXss)
						sDescripcion.CurrentValue = HtmlDecode(sDescripcion.CurrentValue);
					sDescripcion.EditValue = sDescripcion.CurrentValue; // DN
					sDescripcion.PlaceHolder = RemoveHtml(sDescripcion.Caption);

					// nActivo
					nActivo.EditAttrs["class"] = "form-control";
					nActivo.EditValue = nActivo.Options(true);

					// Add refer script
					// nCatalogoID

					nCatalogoID.HrefValue = "";

					// nCodigo
					nCodigo.HrefValue = "";

					// sDescripcion
					sDescripcion.HrefValue = "";

					// nActivo
					nActivo.HrefValue = "";
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
				if (nValorCatalogoID.Required) {
					if (!nValorCatalogoID.IsDetailKey && Empty(nValorCatalogoID.FormValue))
						FormError = AddMessage(FormError, nValorCatalogoID.RequiredErrorMessage.Replace("%s", nValorCatalogoID.Caption));
				}
				if (nCatalogoID.Required) {
					if (!nCatalogoID.IsDetailKey && Empty(nCatalogoID.FormValue))
						FormError = AddMessage(FormError, nCatalogoID.RequiredErrorMessage.Replace("%s", nCatalogoID.Caption));
				}
				if (nCodigo.Required) {
					if (!nCodigo.IsDetailKey && Empty(nCodigo.FormValue))
						FormError = AddMessage(FormError, nCodigo.RequiredErrorMessage.Replace("%s", nCodigo.Caption));
				}
				if (!CheckInteger(nCodigo.FormValue))
					FormError = AddMessage(FormError, nCodigo.ErrorMessage);
				if (sDescripcion.Required) {
					if (!sDescripcion.IsDetailKey && Empty(sDescripcion.FormValue))
						FormError = AddMessage(FormError, sDescripcion.RequiredErrorMessage.Replace("%s", sDescripcion.Caption));
				}
				if (nActivo.Required) {
					if (!nActivo.IsDetailKey && Empty(nActivo.FormValue))
						FormError = AddMessage(FormError, nActivo.RequiredErrorMessage.Replace("%s", nActivo.Caption));
				}
				if (dFechaCreacion.Required) {
					if (!dFechaCreacion.IsDetailKey && Empty(dFechaCreacion.FormValue))
						FormError = AddMessage(FormError, dFechaCreacion.RequiredErrorMessage.Replace("%s", dFechaCreacion.Caption));
				}
				if (dFechaModificacion.Required) {
					if (!dFechaModificacion.IsDetailKey && Empty(dFechaModificacion.FormValue))
						FormError = AddMessage(FormError, dFechaModificacion.RequiredErrorMessage.Replace("%s", dFechaModificacion.Caption));
				}
				if (nValorCatalogoUsuario.Required) {
					if (Empty(nValorCatalogoUsuario.FormValue))
						FormError = AddMessage(FormError, nValorCatalogoUsuario.RequiredErrorMessage.Replace("%s", nValorCatalogoUsuario.Caption));
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
				string masterFilter = "";
				bool validMasterRecord;

				// Check referential integrity for master table 'Catalogo'
				validMasterRecord = true;
				masterFilter = SqlMasterFilter("Catalogo");
				if (!Empty(nCatalogoID.CurrentValue)) {
					masterFilter = masterFilter.Replace("@nCatalogoID@", AdjustSql(nCatalogoID.CurrentValue, "DB"));
				} else {
					validMasterRecord = false;
				}
				if (validMasterRecord) {
					using (var rsmaster = await Connection.GetDataReaderAsync(Catalogo.GetSql(masterFilter))) { // DN
						validMasterRecord = (rsmaster != null && rsmaster.HasRows);
					}
				}
				if (!validMasterRecord) {
					FailureMessage = Language.Phrase("RelatedRecordRequired").Replace("%t", "Catalogo");
					return JsonBoolResult.FalseResult;
				}

				// Load db values from rsold
				LoadDbValues(rsold);
				if (rsold != null) {
				}
				try {

					// nCatalogoID
					nCatalogoID.SetDbValue(rsnew, nCatalogoID.CurrentValue, 0, false);

					// nCodigo
					nCodigo.SetDbValue(rsnew, nCodigo.CurrentValue, 0, false);

					// sDescripcion
					sDescripcion.SetDbValue(rsnew, sDescripcion.CurrentValue, "", false);

					// nActivo
					nActivo.SetDbValue(rsnew, nActivo.CurrentValue, 0, false);
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

			// Set up master/detail based on QueryString
			protected void SetupMasterParms() {
				bool validMaster = false;
				StringValues masterTblVar = "";

				// Get the keys for master table
				if (Query.TryGetValue(Config.TableShowMaster, out masterTblVar)) { // Do not use Get()
					if (Empty(masterTblVar)) {
						validMaster = true;
						DbMasterFilter = "";
						DbDetailFilter = "";
					}
					if (masterTblVar == "Catalogo") {
						validMaster = true;
						if (!Empty(Get("fk_nCatalogoID"))) {
							Catalogo.nCatalogoID.QueryValue = Get("fk_nCatalogoID");
							nCatalogoID.QueryValue = Catalogo.nCatalogoID.QueryValue;
							nCatalogoID.SessionValue = nCatalogoID.QueryValue;
							if (!IsNumeric(Catalogo.nCatalogoID.QueryValue)) validMaster = false;
						} else {
							validMaster = false;
						}
					}
				} else if (Form.TryGetValue(Config.TableShowMaster, out masterTblVar)) {
					if (masterTblVar == "") {
						validMaster = true;
						DbMasterFilter = "";
						DbDetailFilter = "";
					}
					if (masterTblVar == "Catalogo") {
						validMaster = true;
					if (Post("fk_nCatalogoID") != "") {
						Catalogo.nCatalogoID.FormValue = Post("fk_nCatalogoID");
						nCatalogoID.FormValue = Catalogo.nCatalogoID.FormValue;
						nCatalogoID.SessionValue = nCatalogoID.FormValue;
						if (!IsNumeric(Catalogo.nCatalogoID.FormValue)) validMaster = false;
					} else {
						validMaster = false;
					}
				}
				}
				if (validMaster) {

					// Save current master table
					CurrentMasterTable = masterTblVar;

					// Clear previous master key from Session
					if (masterTblVar != "Catalogo") {
						if (Empty(nCatalogoID.CurrentValue)) 
							nCatalogoID.SessionValue = "";
					}
				}
				DbMasterFilter = MasterFilter; // Get master filter
				DbDetailFilter = DetailFilter; // Get detail filter
			}

			// Set up Breadcrumb
			protected void SetupBreadcrumb() {
				var breadcrumb = new Breadcrumb();
				string url = CurrentUrl();
				breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("ValorCatalogolist")), "", TableVar, true);
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
						case "x_nCatalogoID":
							lookupFilter = () => "nCatalogoUsuario=1";
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
									case "x_nCatalogoID":

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
