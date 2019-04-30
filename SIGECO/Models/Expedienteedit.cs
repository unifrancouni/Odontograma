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
		/// Expediente_Edit
		/// </summary>

		public static _Expediente_Edit Expediente_Edit {
			get => HttpData.Get<_Expediente_Edit>("Expediente_Edit");
			set => HttpData["Expediente_Edit"] = value;
		}

		/// <summary>
		/// Page class for Expediente
		/// </summary>

		public class _Expediente_Edit : _Expediente_EditBase
		{

			// Construtor
			public _Expediente_Edit(Controller controller = null) : base(controller) {
			}
		}

		/// <summary>
		/// Page base class
		/// </summary>

		public class _Expediente_EditBase : _Expediente, IAspNetMakerPage
		{

			// Page ID
			public string PageID = "edit";

			// Project ID
			public string ProjectID = "{9B083C8B-EE2F-4356-BE8D-9A26D5707365}";

			// Table name
			public string TableName = "Expediente";

			// Page object name
			public string PageObjName = "Expediente_Edit";

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
			public _Expediente_EditBase(Controller controller = null) { // DN
				if (controller != null)
					Controller = controller;

				// Initialize
				CurrentPage = this;

				// Language object
				Language = Language ?? new Lang();

				// Table object (Expediente)
				if (Expediente == null || Expediente is _Expediente)
					Expediente = this;

				// Table object (Paciente)
				Paciente = Paciente ?? new _Paciente();

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
					dynamic doc = CreateInstance(classname, new object[] { Expediente, "" }); // DN
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
								if (pageName == "Expedienteview")
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
				key += UrlEncode(Convert.ToString(ar["nExpedienteID"]));
				return key;
			}

			// Hide fields for Add/Edit
			protected void HideFieldsForAddEdit() {
				if (IsAdd || IsCopy || IsGridAdd)
					nExpedienteID.Visible = false;
			}
			public int DisplayRecords = 1; // Number of display records
			public int StartRecord;
			public int StopRecord;
			public int TotalRecords = -1;
			public int RecordRange = 10;
			public int RecordCount;
			public Dictionary<string, string> RecordKeys = new Dictionary<string, string>();
			public string FormClassName = "ew-horizontal ew-form ew-edit-form";
			public bool IsModal = false;
			public bool IsMobileOrModal = false;
			public string DbMasterFilter = "";
			public string DbDetailFilter = "";
			public DbDataReader Recordset; // DN
			public DbDataReader OldRecordset;

			#pragma warning disable 219

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
					if (!Security.CanEdit) {
						Security.SaveLastUrl();
						FailureMessage = DeniedMessage(); // Set no permission
						if (IsApi())
							return new JsonBoolResult(new { success = false, error = DeniedMessage(), version = Config.ProductVersion }, false);
						if (Security.CanList)
							return Terminate(GetUrl("Expedientelist"));
						else
							return Terminate(GetUrl("login"));
					}
				}

				// Create form object
				CurrentForm = new HttpForm();
				CurrentAction = Param("action"); // Set up current action
				nExpedienteID.Visible = false;
				nPacienteID.SetVisibility();
				nCodigoExpediente.SetVisibility();
				dFechaExpediente.SetVisibility();
				sACPPESA.SetVisibility();
				nGrupoSanguineoID.SetVisibility();
				nAAAMA.SetVisibility();
				sAAAMA.SetVisibility();
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
				await SetupLookupOptions(nPacienteID);
				await SetupLookupOptions(nGrupoSanguineoID);
				await SetupLookupOptions(nEstadoID);

				// Check modal
				if (IsModal)
					SkipHeaderFooter = true;
				IsMobileOrModal = IsMobile() || IsModal;
				FormClassName = "ew-form ew-edit-form ew-horizontal";
				bool loaded = false;
				bool postBack = false;

				// Set up current action and primary key
				if (IsApi()) {
					CurrentAction = "update"; // Update record directly
					postBack = true;
				} else if (!Empty(Post("action"))) {
					CurrentAction = Post("action"); // Get action code
					if (!IsShow) // Not reload record, handle as postback
						postBack = true;

					// Load key from form
					string[] keyValues = null;
					object rv;
					if (IsApi() && RouteValues.TryGetValue("key", out object k))
						keyValues = k.ToString().Split('/');
					if (RouteValues.TryGetValue("nExpedienteID", out rv)) { // DN
						nExpedienteID.FormValue = Convert.ToString(rv);
						RecordKeys["nExpedienteID"] = nExpedienteID.FormValue;
					} else if (CurrentForm.HasValue("x_nExpedienteID")) {
						nExpedienteID.FormValue = CurrentForm.GetValue("x_nExpedienteID");
						RecordKeys["nExpedienteID"] = nExpedienteID.FormValue;
					} else if (IsApi() && !Empty(keyValues)) {
						RecordKeys["nExpedienteID"] = Convert.ToString(keyValues[0]);
					}
				} else {
					CurrentAction = "show"; // Default action is display

					// Load key from QueryString
					bool loadByQuery = false;
					string[] keyValues = null;
					object rv;
					if (IsApi() && RouteValues.TryGetValue("key", out object k))
						keyValues = k.ToString().Split('/');
					if (RouteValues.TryGetValue("nExpedienteID", out rv)) { // DN
						nExpedienteID.QueryValue = Convert.ToString(rv);
						RecordKeys["nExpedienteID"] = nExpedienteID.QueryValue;
						loadByQuery = true;
					} else if (!Empty(Get("nExpedienteID"))) {
						nExpedienteID.QueryValue = Get("nExpedienteID");
						RecordKeys["nExpedienteID"] = nExpedienteID.QueryValue;
						loadByQuery = true;
					} else if (IsApi() && !Empty(keyValues)) {
						nExpedienteID.QueryValue = Convert.ToString(keyValues[0]);
						RecordKeys["nExpedienteID"] = nExpedienteID.QueryValue;
						loadByQuery = true;
					} else {
						nExpedienteID.CurrentValue = System.DBNull.Value;
					}
				}

				// Set up master detail parameters
				SetupMasterParms();

			// Load current record
			loaded = await LoadRow();

			// Process form if post back
			if (postBack) {
				await LoadFormValues(); // Get form values
				if (IsApi() && RouteValues.TryGetValue("key", out object k)) {
					var keyValues = k.ToString().Split('/');
					nExpedienteID.FormValue = Convert.ToString(keyValues[0]);
				}
			}

			// Validate form if post back
			if (postBack) {
				if (!await ValidateForm()) {
					FailureMessage = FormError;
					EventCancelled = true; // Event cancelled
					RestoreFormValues();
					if (IsApi())
						return Terminate();
					else
						CurrentAction = ""; // Form error, reset action
				}
			}

			// Perform current action
			switch (CurrentAction) {
					case "show": // Get a record to display
						if (!loaded) { // Load record based on key
							if (Empty(FailureMessage))
								FailureMessage = Language.Phrase("NoRecord"); // No record found
							return Terminate("Expedientelist"); // No matching record, return to list
						}
						break;
					case "update": // Update // DN
						CloseRecordset(); // DN
						string returnUrl = ReturnUrl;
						if (GetPageName(returnUrl) == "Expedientelist")
							returnUrl = AddMasterUrl(ListUrl); // List page, return to List page with correct master key if necessary
						SendEmail = true; // Send email on update success
						var res = await EditRow();
						if (res) { // Update record based on key
							if (Empty(SuccessMessage))
								SuccessMessage = Language.Phrase("UpdateSuccess"); // Update success
							if (IsApi()) {
								return res;
							} else {
								return Terminate(returnUrl); // Return to caller
							}
						} else if (IsApi()) { // API request, return
							return Terminate();
						} else if (FailureMessage == Language.Phrase("NoRecord")) {
							return Terminate(returnUrl); // Return to caller
						} else {
							EventCancelled = true; // Event cancelled
							RestoreFormValues(); // Restore form values if update failed
						}
						break;
				}

				// Set up Breadcrumb
				SetupBreadcrumb();

				// Render the record
				RowType = Config.RowTypeEdit; // Render as Edit
				ResetAttributes();
				await RenderRow();
				return PageResult();
			}

			#pragma warning restore 219

			// Set up starting record parameters
			public void SetupStartRec() {
				int pageNo;

				// Exit if DisplayRecords = 0
				if (DisplayRecords == 0)
					return;
				if (IsPageRequest) { // Validate request

					// Check for a "start" parameter
					if (IsNumeric(Get(Config.TableStartRec))) {
						StartRecord = Get<int>(Config.TableStartRec);
						StartRecordNumber = StartRecord;
					} else if (IsNumeric(Get(Config.TablePageNumber))) {
						pageNo = Get<int>(Config.TablePageNumber);
						StartRecord = (pageNo - 1) * DisplayRecords + 1;
						if (StartRecord <= 0) {
							StartRecord = 1;
						} else if (StartRecord >= ((TotalRecords - 1) / DisplayRecords) * DisplayRecords + 1) {
							StartRecord = ((TotalRecords - 1) / DisplayRecords) * DisplayRecords + 1;
						}
						StartRecordNumber = StartRecord;
					}
				}
				StartRecord = StartRecordNumber;

				// Check if correct start record counter
				if (StartRecord <= 0) { // Avoid invalid start record counter
					StartRecord = 1; // Reset start record counter
					StartRecordNumber = StartRecord;
				} else if (StartRecord > TotalRecords) { // Avoid starting record > total records
					StartRecord = ((TotalRecords - 1) / DisplayRecords) * DisplayRecords + 1; // Point to last page first record
					StartRecordNumber = StartRecord;
				} else if ((StartRecord - 1) % DisplayRecords != 0) {
					StartRecord = ((StartRecord - 1) / DisplayRecords) * DisplayRecords + 1; // Point to page boundary
					StartRecordNumber = StartRecord;
				}
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

			#pragma warning disable 1998

			// Load form values
			protected async Task LoadFormValues() {
				string val;

				// Check field name 'nPacienteID' first before field var 'x_nPacienteID'
				val = CurrentForm.GetValue("nPacienteID", "x_nPacienteID");
				if (!nPacienteID.IsDetailKey) {
					if (IsApi() && val == null)
						nPacienteID.Visible = false; // Disable update for API request
					else
						nPacienteID.FormValue = val;
				}

				// Check field name 'nCodigoExpediente' first before field var 'x_nCodigoExpediente'
				val = CurrentForm.GetValue("nCodigoExpediente", "x_nCodigoExpediente");
				if (!nCodigoExpediente.IsDetailKey) {
					if (IsApi() && val == null)
						nCodigoExpediente.Visible = false; // Disable update for API request
					else
						nCodigoExpediente.FormValue = val;
				}

				// Check field name 'dFechaExpediente' first before field var 'x_dFechaExpediente'
				val = CurrentForm.GetValue("dFechaExpediente", "x_dFechaExpediente");
				if (!dFechaExpediente.IsDetailKey) {
					if (IsApi() && val == null)
						dFechaExpediente.Visible = false; // Disable update for API request
					else
						dFechaExpediente.FormValue = val;
					dFechaExpediente.CurrentValue = UnformatDateTime(dFechaExpediente.CurrentValue, 0);
				}

				// Check field name 'sACPPESA' first before field var 'x_sACPPESA'
				val = CurrentForm.GetValue("sACPPESA", "x_sACPPESA");
				if (!sACPPESA.IsDetailKey) {
					if (IsApi() && val == null)
						sACPPESA.Visible = false; // Disable update for API request
					else
						sACPPESA.FormValue = val;
				}

				// Check field name 'nGrupoSanguineoID' first before field var 'x_nGrupoSanguineoID'
				val = CurrentForm.GetValue("nGrupoSanguineoID", "x_nGrupoSanguineoID");
				if (!nGrupoSanguineoID.IsDetailKey) {
					if (IsApi() && val == null)
						nGrupoSanguineoID.Visible = false; // Disable update for API request
					else
						nGrupoSanguineoID.FormValue = val;
				}

				// Check field name 'nAAAMA' first before field var 'x_nAAAMA'
				val = CurrentForm.GetValue("nAAAMA", "x_nAAAMA");
				if (!nAAAMA.IsDetailKey) {
					if (IsApi() && val == null)
						nAAAMA.Visible = false; // Disable update for API request
					else
						nAAAMA.FormValue = val;
				}

				// Check field name 'sAAAMA' first before field var 'x_sAAAMA'
				val = CurrentForm.GetValue("sAAAMA", "x_sAAAMA");
				if (!sAAAMA.IsDetailKey) {
					if (IsApi() && val == null)
						sAAAMA.Visible = false; // Disable update for API request
					else
						sAAAMA.FormValue = val;
				}

				// Check field name 'nEstadoID' first before field var 'x_nEstadoID'
				val = CurrentForm.GetValue("nEstadoID", "x_nEstadoID");
				if (!nEstadoID.IsDetailKey) {
					if (IsApi() && val == null)
						nEstadoID.Visible = false; // Disable update for API request
					else
						nEstadoID.FormValue = val;
				}

				// Check field name 'nExpedienteID' first before field var 'x_nExpedienteID'
				val = CurrentForm.GetValue("nExpedienteID", "x_nExpedienteID");
				if (!nExpedienteID.IsDetailKey)
					nExpedienteID.FormValue = val;
			}

			#pragma warning restore 1998

			// Restore form values
			public void RestoreFormValues() {
				nExpedienteID.CurrentValue = nExpedienteID.FormValue;
				nPacienteID.CurrentValue = nPacienteID.FormValue;
				nCodigoExpediente.CurrentValue = nCodigoExpediente.FormValue;
				dFechaExpediente.CurrentValue = dFechaExpediente.FormValue;
				dFechaExpediente.CurrentValue = UnformatDateTime(dFechaExpediente.CurrentValue, 0);
				sACPPESA.CurrentValue = sACPPESA.FormValue;
				nGrupoSanguineoID.CurrentValue = nGrupoSanguineoID.FormValue;
				nAAAMA.CurrentValue = nAAAMA.FormValue;
				sAAAMA.CurrentValue = sAAAMA.FormValue;
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
				nExpedienteID.SetDbValue(row["nExpedienteID"]);
				nPacienteID.SetDbValue(row["nPacienteID"]);
				nCodigoExpediente.SetDbValue(row["nCodigoExpediente"]);
				dFechaExpediente.SetDbValue(row["dFechaExpediente"]);
				sACPPESA.SetDbValue(row["sACPPESA"]);
				nGrupoSanguineoID.SetDbValue(row["nGrupoSanguineoID"]);
				nAAAMA.SetDbValue((ConvertToBool(row["nAAAMA"]) ? "1" : "0"));
				sAAAMA.SetDbValue(row["sAAAMA"]);
				nEstadoID.SetDbValue(row["nEstadoID"]);
				dFechaCreacion.SetDbValue(row["dFechaCreacion"]);
				dFechaModificacion.SetDbValue(row["dFechaModificacion"]);
			}

			#pragma warning restore 162, 168, 1998

			// Return a row with default values
			protected Dictionary<string, object> NewRow() {
				var row = new Dictionary<string, object>();
				row.Add("nExpedienteID", System.DBNull.Value);
				row.Add("nPacienteID", System.DBNull.Value);
				row.Add("nCodigoExpediente", System.DBNull.Value);
				row.Add("dFechaExpediente", System.DBNull.Value);
				row.Add("sACPPESA", System.DBNull.Value);
				row.Add("nGrupoSanguineoID", System.DBNull.Value);
				row.Add("nAAAMA", System.DBNull.Value);
				row.Add("sAAAMA", System.DBNull.Value);
				row.Add("nEstadoID", System.DBNull.Value);
				row.Add("dFechaCreacion", System.DBNull.Value);
				row.Add("dFechaModificacion", System.DBNull.Value);
				return row;
			}

			#pragma warning disable 618, 1998

			// Load old record
			protected async Task<bool> LoadOldRecord(DatabaseConnectionBase<SqlConnection, SqlCommand, SqlDataReader, SqlDbType> cnn = null) {
				bool validKey = true;
				if (!Empty(GetKey("nExpedienteID")))
					nExpedienteID.CurrentValue = GetKey("nExpedienteID"); // nExpedienteID
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
				// nExpedienteID
				// nPacienteID
				// nCodigoExpediente
				// dFechaExpediente
				// sACPPESA
				// nGrupoSanguineoID
				// nAAAMA
				// sAAAMA
				// nEstadoID
				// dFechaCreacion
				// dFechaModificacion

				if (RowType == Config.RowTypeView) { // View row

					// nPacienteID
					curVal = Convert.ToString(nPacienteID.CurrentValue);
					if (!Empty(curVal)) {
						nPacienteID.ViewValue = nPacienteID.LookupCacheOption(curVal);
						if (nPacienteID.ViewValue == null) { // Lookup from database
							filterWrk = "[nPacienteID]" + SearchString("=", curVal.Trim(), Config.DataTypeNumber, "");
							sqlWrk = nPacienteID.Lookup.GetSql(false, filterWrk, null, this);
							rswrk = await Connection.GetRowsAsync(sqlWrk);
							if (rswrk != null && rswrk.Count > 0) { // Lookup values found
								var listwrk = rswrk[0].Values.ToList();
								listwrk[1] = Convert.ToString(FormatNumber(listwrk[1], 0, -2, -2, -2));
								listwrk[2] = Convert.ToString(listwrk[2]);
								nPacienteID.ViewValue = nPacienteID.DisplayValue(listwrk);
							} else {
								nPacienteID.ViewValue = nPacienteID.CurrentValue;
							}
						}
					} else {
						nPacienteID.ViewValue = System.DBNull.Value;
					}

					// nCodigoExpediente
					nCodigoExpediente.ViewValue = nCodigoExpediente.CurrentValue;
					nCodigoExpediente.ViewValue = FormatNumber(nCodigoExpediente.ViewValue, 0, -2, -2, -2);

					// dFechaExpediente
					dFechaExpediente.ViewValue = dFechaExpediente.CurrentValue;
					dFechaExpediente.ViewValue = FormatDateTime(dFechaExpediente.ViewValue, 0);

					// sACPPESA
					sACPPESA.ViewValue = sACPPESA.CurrentValue;

					// nGrupoSanguineoID
					curVal = Convert.ToString(nGrupoSanguineoID.CurrentValue);
					if (!Empty(curVal)) {
						nGrupoSanguineoID.ViewValue = nGrupoSanguineoID.LookupCacheOption(curVal);
						if (nGrupoSanguineoID.ViewValue == null) { // Lookup from database
							filterWrk = "[nValorCatalogoID]" + SearchString("=", curVal.Trim(), Config.DataTypeNumber, "");
							lookupFilter = () => "nCatalogoID=8";
							sqlWrk = nGrupoSanguineoID.Lookup.GetSql(false, filterWrk, lookupFilter, this);
							rswrk = await Connection.GetRowsAsync(sqlWrk);
							if (rswrk != null && rswrk.Count > 0) { // Lookup values found
								var listwrk = rswrk[0].Values.ToList();
								listwrk[1] = Convert.ToString(FormatNumber(listwrk[1], 0, -2, -2, -2));
								listwrk[2] = Convert.ToString(listwrk[2]);
								nGrupoSanguineoID.ViewValue = nGrupoSanguineoID.DisplayValue(listwrk);
							} else {
								nGrupoSanguineoID.ViewValue = nGrupoSanguineoID.CurrentValue;
							}
						}
					} else {
						nGrupoSanguineoID.ViewValue = System.DBNull.Value;
					}

					// nAAAMA
					if (ConvertToBool(nAAAMA.CurrentValue)) {
						nAAAMA.ViewValue = (nAAAMA.TagCaption(1) != "") ? nAAAMA.TagCaption(1) : "Activo";
					} else {
						nAAAMA.ViewValue = (nAAAMA.TagCaption(2) != "") ? nAAAMA.TagCaption(2) : "Inactivo";
					}

					// sAAAMA
					sAAAMA.ViewValue = sAAAMA.CurrentValue;

					// nEstadoID
					curVal = Convert.ToString(nEstadoID.CurrentValue);
					if (!Empty(curVal)) {
						nEstadoID.ViewValue = nEstadoID.LookupCacheOption(curVal);
						if (nEstadoID.ViewValue == null) { // Lookup from database
							filterWrk = "[nValorCatalogoID]" + SearchString("=", curVal.Trim(), Config.DataTypeNumber, "");
							lookupFilter = () => "nCatalogoID=9";
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

					// nPacienteID
					nPacienteID.HrefValue = "";
					nPacienteID.TooltipValue = "";

					// nCodigoExpediente
					nCodigoExpediente.HrefValue = "";
					nCodigoExpediente.TooltipValue = "";

					// dFechaExpediente
					dFechaExpediente.HrefValue = "";
					dFechaExpediente.TooltipValue = "";

					// sACPPESA
					sACPPESA.HrefValue = "";
					sACPPESA.TooltipValue = "";

					// nGrupoSanguineoID
					nGrupoSanguineoID.HrefValue = "";
					nGrupoSanguineoID.TooltipValue = "";

					// nAAAMA
					nAAAMA.HrefValue = "";
					nAAAMA.TooltipValue = "";

					// sAAAMA
					sAAAMA.HrefValue = "";
					sAAAMA.TooltipValue = "";

					// nEstadoID
					nEstadoID.HrefValue = "";
					nEstadoID.TooltipValue = "";
				} else if (RowType == Config.RowTypeEdit) { // Edit row

					// nPacienteID
					if (!Empty(nPacienteID.SessionValue)) {
						nPacienteID.CurrentValue = nPacienteID.SessionValue;
					curVal = Convert.ToString(nPacienteID.CurrentValue);
					if (!Empty(curVal)) {
						nPacienteID.ViewValue = nPacienteID.LookupCacheOption(curVal);
						if (nPacienteID.ViewValue == null) { // Lookup from database
							filterWrk = "[nPacienteID]" + SearchString("=", curVal.Trim(), Config.DataTypeNumber, "");
							sqlWrk = nPacienteID.Lookup.GetSql(false, filterWrk, null, this);
							rswrk = await Connection.GetRowsAsync(sqlWrk);
							if (rswrk != null && rswrk.Count > 0) { // Lookup values found
								var listwrk = rswrk[0].Values.ToList();
								listwrk[1] = Convert.ToString(FormatNumber(listwrk[1], 0, -2, -2, -2));
								listwrk[2] = Convert.ToString(listwrk[2]);
								nPacienteID.ViewValue = nPacienteID.DisplayValue(listwrk);
							} else {
								nPacienteID.ViewValue = nPacienteID.CurrentValue;
							}
						}
					} else {
						nPacienteID.ViewValue = System.DBNull.Value;
					}
					} else {
					curVal = Convert.ToString(nPacienteID.CurrentValue).Trim();
					if (curVal != "")
						nPacienteID.ViewValue = nPacienteID.LookupCacheOption(curVal);
					else
						nPacienteID.ViewValue = nPacienteID.Lookup != null && IsList(nPacienteID.Lookup.Options) ? curVal : null;
					if (nPacienteID.ViewValue != null) { // Load from cache
						nPacienteID.EditValue = nPacienteID.Lookup.Options.Values.ToList();
						if (SameString(nPacienteID.ViewValue, ""))
							nPacienteID.ViewValue = Language.Phrase("PleaseSelect");
					} else { // Lookup from database
						if (curVal == "") {
							filterWrk = "0=1";
						} else {
							filterWrk = "[nPacienteID]" + SearchString("=", Convert.ToString(nPacienteID.CurrentValue), Config.DataTypeNumber, "");
						}
					sqlWrk = nPacienteID.Lookup.GetSql(true, filterWrk, null, this);
					rswrk = await Connection.GetRowsAsync(sqlWrk);
					if (rswrk != null && rswrk.Count > 0) { // Lookup values found
						var listwrk = rswrk[0].Values.ToList();
						listwrk[1] = Convert.ToString(HtmlEncode(FormatNumber(listwrk[1], 0, -2, -2, -2)));
						listwrk[2] = Convert.ToString(HtmlEncode(listwrk[2]));
						nPacienteID.ViewValue = nPacienteID.DisplayValue(listwrk);
						foreach (var d in rswrk) {
							var keys = d.Keys.ToList();
							d[keys[1]] = FormatNumber(d[keys[1]], 0, -2, -2, -2);
						}
					} else {
						nPacienteID.ViewValue = nPacienteID.PleaseSelectText;
					}
					nPacienteID.EditValue = rswrk;
					}
					}

					// nCodigoExpediente
					nCodigoExpediente.EditAttrs["class"] = "form-control";
					nCodigoExpediente.EditValue = nCodigoExpediente.CurrentValue; // DN
					nCodigoExpediente.PlaceHolder = RemoveHtml(nCodigoExpediente.Caption);

					// dFechaExpediente
					dFechaExpediente.EditAttrs["class"] = "form-control";
					dFechaExpediente.EditValue = FormatDateTime(dFechaExpediente.CurrentValue, 8); // DN
					dFechaExpediente.PlaceHolder = RemoveHtml(dFechaExpediente.Caption);

					// sACPPESA
					sACPPESA.EditAttrs["class"] = "form-control";
					if (Config.RemoveXss)
						sACPPESA.CurrentValue = HtmlDecode(sACPPESA.CurrentValue);
					sACPPESA.EditValue = sACPPESA.CurrentValue; // DN
					sACPPESA.PlaceHolder = RemoveHtml(sACPPESA.Caption);

					// nGrupoSanguineoID
					curVal = Convert.ToString(nGrupoSanguineoID.CurrentValue).Trim();
					if (curVal != "")
						nGrupoSanguineoID.ViewValue = nGrupoSanguineoID.LookupCacheOption(curVal);
					else
						nGrupoSanguineoID.ViewValue = nGrupoSanguineoID.Lookup != null && IsList(nGrupoSanguineoID.Lookup.Options) ? curVal : null;
					if (nGrupoSanguineoID.ViewValue != null) { // Load from cache
						nGrupoSanguineoID.EditValue = nGrupoSanguineoID.Lookup.Options.Values.ToList();
						if (SameString(nGrupoSanguineoID.ViewValue, ""))
							nGrupoSanguineoID.ViewValue = Language.Phrase("PleaseSelect");
					} else { // Lookup from database
						if (curVal == "") {
							filterWrk = "0=1";
						} else {
							filterWrk = "[nValorCatalogoID]" + SearchString("=", Convert.ToString(nGrupoSanguineoID.CurrentValue), Config.DataTypeNumber, "");
						}
					lookupFilter = () => "nCatalogoID=8";
					sqlWrk = nGrupoSanguineoID.Lookup.GetSql(true, filterWrk, lookupFilter, this);
					rswrk = await Connection.GetRowsAsync(sqlWrk);
					if (rswrk != null && rswrk.Count > 0) { // Lookup values found
						var listwrk = rswrk[0].Values.ToList();
						listwrk[1] = Convert.ToString(HtmlEncode(FormatNumber(listwrk[1], 0, -2, -2, -2)));
						listwrk[2] = Convert.ToString(HtmlEncode(listwrk[2]));
						nGrupoSanguineoID.ViewValue = nGrupoSanguineoID.DisplayValue(listwrk);
						foreach (var d in rswrk) {
							var keys = d.Keys.ToList();
							d[keys[1]] = FormatNumber(d[keys[1]], 0, -2, -2, -2);
						}
					} else {
						nGrupoSanguineoID.ViewValue = nGrupoSanguineoID.PleaseSelectText;
					}
					nGrupoSanguineoID.EditValue = rswrk;
					}

					// nAAAMA
					nAAAMA.EditAttrs["class"] = "form-control";
					nAAAMA.EditValue = nAAAMA.Options(true);

					// sAAAMA
					sAAAMA.EditAttrs["class"] = "form-control";
					if (Config.RemoveXss)
						sAAAMA.CurrentValue = HtmlDecode(sAAAMA.CurrentValue);
					sAAAMA.EditValue = sAAAMA.CurrentValue; // DN
					sAAAMA.PlaceHolder = RemoveHtml(sAAAMA.Caption);

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
					lookupFilter = () => "nCatalogoID=9";
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

					// Edit refer script
					// nPacienteID

					nPacienteID.HrefValue = "";

					// nCodigoExpediente
					nCodigoExpediente.HrefValue = "";

					// dFechaExpediente
					dFechaExpediente.HrefValue = "";

					// sACPPESA
					sACPPESA.HrefValue = "";

					// nGrupoSanguineoID
					nGrupoSanguineoID.HrefValue = "";

					// nAAAMA
					nAAAMA.HrefValue = "";

					// sAAAMA
					sAAAMA.HrefValue = "";

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
				if (nExpedienteID.Required) {
					if (!nExpedienteID.IsDetailKey && Empty(nExpedienteID.FormValue))
						FormError = AddMessage(FormError, nExpedienteID.RequiredErrorMessage.Replace("%s", nExpedienteID.Caption));
				}
				if (nPacienteID.Required) {
					if (!nPacienteID.IsDetailKey && Empty(nPacienteID.FormValue))
						FormError = AddMessage(FormError, nPacienteID.RequiredErrorMessage.Replace("%s", nPacienteID.Caption));
				}
				if (nCodigoExpediente.Required) {
					if (!nCodigoExpediente.IsDetailKey && Empty(nCodigoExpediente.FormValue))
						FormError = AddMessage(FormError, nCodigoExpediente.RequiredErrorMessage.Replace("%s", nCodigoExpediente.Caption));
				}
				if (!CheckInteger(nCodigoExpediente.FormValue))
					FormError = AddMessage(FormError, nCodigoExpediente.ErrorMessage);
				if (dFechaExpediente.Required) {
					if (!dFechaExpediente.IsDetailKey && Empty(dFechaExpediente.FormValue))
						FormError = AddMessage(FormError, dFechaExpediente.RequiredErrorMessage.Replace("%s", dFechaExpediente.Caption));
				}
				if (!CheckDate(dFechaExpediente.FormValue))
					FormError = AddMessage(FormError, dFechaExpediente.ErrorMessage);
				if (sACPPESA.Required) {
					if (!sACPPESA.IsDetailKey && Empty(sACPPESA.FormValue))
						FormError = AddMessage(FormError, sACPPESA.RequiredErrorMessage.Replace("%s", sACPPESA.Caption));
				}
				if (nGrupoSanguineoID.Required) {
					if (!nGrupoSanguineoID.IsDetailKey && Empty(nGrupoSanguineoID.FormValue))
						FormError = AddMessage(FormError, nGrupoSanguineoID.RequiredErrorMessage.Replace("%s", nGrupoSanguineoID.Caption));
				}
				if (nAAAMA.Required) {
					if (!nAAAMA.IsDetailKey && Empty(nAAAMA.FormValue))
						FormError = AddMessage(FormError, nAAAMA.RequiredErrorMessage.Replace("%s", nAAAMA.Caption));
				}
				if (sAAAMA.Required) {
					if (!sAAAMA.IsDetailKey && Empty(sAAAMA.FormValue))
						FormError = AddMessage(FormError, sAAAMA.RequiredErrorMessage.Replace("%s", sAAAMA.Caption));
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

			// Update record based on key values

			#pragma warning disable 168, 219

			protected async Task<JsonBoolResult> EditRow() { // DN
				bool result = false;
				Dictionary<string, object> rsold = null;
				var rsnew = new Dictionary<string, object>();
				var filter = GetRecordFilter();
				filter = ApplyUserIDFilters(filter);
				if (!Empty(nCodigoExpediente.CurrentValue)) { // Check field with unique index
					string filterChk = "([nCodigoExpediente] = " + AdjustSql(nCodigoExpediente.CurrentValue, DbId) + ")";
					filterChk = filterChk + " AND NOT (" + filter + ")";
					CurrentFilter = filterChk;
					string sqlchk = CurrentSql;
					try {
						using (var rschk = await Connection.GetDataReaderAsync(sqlchk)) {
							if (rschk != null && await rschk.ReadAsync()) {
								var idxErrMsg = Language.Phrase("DupIndex").Replace("%f", Expediente.nCodigoExpediente.Caption);
								idxErrMsg = idxErrMsg.Replace("%v", Convert.ToString(Expediente.nCodigoExpediente.CurrentValue));
								FailureMessage = idxErrMsg;
								return JsonBoolResult.FalseResult;
							}
						}
					} catch (Exception e) {
						if (Config.Debug)
							throw;
						FailureMessage = e.Message;
						return JsonBoolResult.FalseResult;
					}
				}
				CurrentFilter = filter;
				string sql = CurrentSql;
				try {
					using (var rsedit = await Connection.GetDataReaderAsync(sql)) {
						if (rsedit == null || !await rsedit.ReadAsync()) {
							FailureMessage = Language.Phrase("NoRecord"); // Set no record message
							return JsonBoolResult.FalseResult;
						}
						rsold = Connection.GetRow(rsedit);
						LoadDbValues(rsold);
					}
				} catch (Exception e) {
					if (Config.Debug)
						throw;
					FailureMessage = e.Message;
					return JsonBoolResult.FalseResult;
				}

				// nPacienteID
				nPacienteID.SetDbValue(rsnew, nPacienteID.CurrentValue, 0, nPacienteID.ReadOnly);

				// nCodigoExpediente
				nCodigoExpediente.SetDbValue(rsnew, nCodigoExpediente.CurrentValue, 0, nCodigoExpediente.ReadOnly);

				// dFechaExpediente
				dFechaExpediente.SetDbValue(rsnew, UnformatDateTime(dFechaExpediente.CurrentValue, 0), DateTime.Now, dFechaExpediente.ReadOnly);

				// sACPPESA
				sACPPESA.SetDbValue(rsnew, sACPPESA.CurrentValue, System.DBNull.Value, sACPPESA.ReadOnly);

				// nGrupoSanguineoID
				nGrupoSanguineoID.SetDbValue(rsnew, nGrupoSanguineoID.CurrentValue, 0, nGrupoSanguineoID.ReadOnly);

				// nAAAMA
				nAAAMA.SetDbValue(rsnew, SameString(nAAAMA.CurrentValue, "1") ? "1" : "0", 0, nAAAMA.ReadOnly); // DN1204

				// sAAAMA
				sAAAMA.SetDbValue(rsnew, sAAAMA.CurrentValue, System.DBNull.Value, sAAAMA.ReadOnly);

				// nEstadoID
				nEstadoID.SetDbValue(rsnew, nEstadoID.CurrentValue, 0, nEstadoID.ReadOnly);
				bool validMasterRecord;
				object keyValue, v;
				string masterFilter;

				// Check referential integrity for master table 'Paciente'
				validMasterRecord = true;
				masterFilter = SqlMasterFilter("Paciente");
				keyValue = rsnew.TryGetValue("nPacienteID", out v) ? v : rsold["nPacienteID"];
				if (!Empty(keyValue)) {
					masterFilter = masterFilter.Replace("@nPacienteID@", AdjustSql(keyValue));
				} else {
					validMasterRecord = false;
				}
				if (validMasterRecord) {
					using (var rsmaster = await Connection.GetDataReaderAsync(Paciente.GetSql(masterFilter))) { // DN
						validMasterRecord = (rsmaster != null && rsmaster.HasRows);
					}
				}
				if (!validMasterRecord) {
					FailureMessage = Language.Phrase("RelatedRecordRequired").Replace("%t", "Paciente");
					return JsonBoolResult.FalseResult;
				}

				// Call Row Updating event
				bool updateRow = Row_Updating(rsold, rsnew);
				if (updateRow) {
					try {
						if (rsnew.Count > 0)
							result = await UpdateAsync(rsnew, "", rsold) > 0;
						else
							result = true;
						if (result) {
						}
					} catch (Exception e) {
						if (Config.Debug)
							throw;
						FailureMessage = e.Message;
						return JsonBoolResult.FalseResult;
					}
				} else {
					if (!Empty(SuccessMessage) || !Empty(FailureMessage)) {

						// Use the message, do nothing
					} else if (!Empty(CancelMessage)) {
						FailureMessage = CancelMessage;
						CancelMessage = "";
					} else {
						FailureMessage = Language.Phrase("UpdateCancelled");
					}
					result = false;
				}

				// Call Row_Updated event
				if (result)
					Row_Updated(rsold, rsnew);

				// Write JSON for API request
				var d = new Dictionary<string, object>();
				d.Add("success", result);
				if (IsApi() && result) {
					var row = GetRecordFromDictionary(rsnew);
					d.Add(TableVar, row);
					d.Add("version", Config.ProductVersion);
					return new JsonBoolResult(d, true);
				}
				return new JsonBoolResult(d, result);
			}

			// Save data to memory cache
			public void SetCache<T>(string key, T value, int span) => Cache.Set<T>(key, value, new MemoryCacheEntryOptions()
				.SetSlidingExpiration(TimeSpan.FromMilliseconds(span))); // Keep in cache for this time, reset time if accessed

			// Gete data from memory cache
			public void GetCache<T>(string key) => Cache.Get<T>(key);

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
					if (masterTblVar == "Paciente") {
						validMaster = true;
						if (!Empty(Get("fk_nPacienteID"))) {
							Paciente.nPacienteID.QueryValue = Get("fk_nPacienteID");
							nPacienteID.QueryValue = Paciente.nPacienteID.QueryValue;
							nPacienteID.SessionValue = nPacienteID.QueryValue;
							if (!IsNumeric(Paciente.nPacienteID.QueryValue)) validMaster = false;
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
					if (masterTblVar == "Paciente") {
						validMaster = true;
					if (Post("fk_nPacienteID") != "") {
						Paciente.nPacienteID.FormValue = Post("fk_nPacienteID");
						nPacienteID.FormValue = Paciente.nPacienteID.FormValue;
						nPacienteID.SessionValue = nPacienteID.FormValue;
						if (!IsNumeric(Paciente.nPacienteID.FormValue)) validMaster = false;
					} else {
						validMaster = false;
					}
				}
				}
				if (validMaster) {

					// Save current master table
					CurrentMasterTable = masterTblVar;
					SessionWhere = DetailFilter;

					// Clear previous master key from Session
					if (masterTblVar != "Paciente") {
						if (Empty(nPacienteID.CurrentValue)) 
							nPacienteID.SessionValue = "";
					}
				}
				DbMasterFilter = MasterFilter; // Get master filter
				DbDetailFilter = DetailFilter; // Get detail filter
			}

			// Set up Breadcrumb
			protected void SetupBreadcrumb() {
				var breadcrumb = new Breadcrumb();
				string url = CurrentUrl();
				breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("Expedientelist")), "", TableVar, true);
				string pageId = "edit";
				breadcrumb.Add("edit", pageId, url);
				CurrentBreadcrumb = breadcrumb;
			}

			// Setup lookup options
			public async Task SetupLookupOptions(DbField fld)
			{
				Func<string> lookupFilter = null;
				if (!Empty(fld.Lookup) && fld.Lookup.Options.Count == 0) {

					// Set up lookup SQL
					switch (fld.FieldVar) {
						case "x_nGrupoSanguineoID":
							lookupFilter = () => "nCatalogoID=8";
							break;
						case "x_nEstadoID":
							lookupFilter = () => "nCatalogoID=9";
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
									case "x_nPacienteID":

										//row[1] = FormatNumber(row[1], 0, -2, -2, -2);
										//row["df"] = row[1];

										values = row.Values.ToList();
										row["df"] = FormatNumber(values[1], 0, -2, -2, -2);
									break;
								}

								// Format the field values
								switch (fld.FieldVar) {
									case "x_nGrupoSanguineoID":

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
