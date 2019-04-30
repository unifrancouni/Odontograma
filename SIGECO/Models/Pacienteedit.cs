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
		/// Paciente_Edit
		/// </summary>

		public static _Paciente_Edit Paciente_Edit {
			get => HttpData.Get<_Paciente_Edit>("Paciente_Edit");
			set => HttpData["Paciente_Edit"] = value;
		}

		/// <summary>
		/// Page class for Paciente
		/// </summary>

		public class _Paciente_Edit : _Paciente_EditBase
		{

			// Construtor
			public _Paciente_Edit(Controller controller = null) : base(controller) {
			}
		}

		/// <summary>
		/// Page base class
		/// </summary>

		public class _Paciente_EditBase : _Paciente, IAspNetMakerPage
		{

			// Page ID
			public string PageID = "edit";

			// Project ID
			public string ProjectID = "{9B083C8B-EE2F-4356-BE8D-9A26D5707365}";

			// Table name
			public string TableName = "Paciente";

			// Page object name
			public string PageObjName = "Paciente_Edit";

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
			public _Paciente_EditBase(Controller controller = null) { // DN
				if (controller != null)
					Controller = controller;

				// Initialize
				CurrentPage = this;

				// Language object
				Language = Language ?? new Lang();

				// Table object (Paciente)
				if (Paciente == null || Paciente is _Paciente)
					Paciente = this;

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
					dynamic doc = CreateInstance(classname, new object[] { Paciente, "" }); // DN
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
								if (pageName == "Pacienteview")
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
				key += UrlEncode(Convert.ToString(ar["nPacienteID"]));
				return key;
			}

			// Hide fields for Add/Edit
			protected void HideFieldsForAddEdit() {
				if (IsAdd || IsCopy || IsGridAdd)
					nPacienteID.Visible = false;
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
							return Terminate(GetUrl("Pacientelist"));
						else
							return Terminate(GetUrl("login"));
					}
				}

				// Create form object
				CurrentForm = new HttpForm();
				CurrentAction = Param("action"); // Set up current action
				nPacienteID.Visible = false;
				nCodigo.SetVisibility();
				sNombre.SetVisibility();
				sApellido1.SetVisibility();
				sApellido2.SetVisibility();
				nGeneroID.SetVisibility();
				sLugarNacimiento.SetVisibility();
				dFechaNacimiento.SetVisibility();
				sDireccion.SetVisibility();
				sCedula.SetVisibility();
				sTelefono.SetVisibility();
				sEmergenciaNombre.SetVisibility();
				sEmergenciaParentesco.SetVisibility();
				sEmergenciaTelefono.SetVisibility();
				nActivo.SetVisibility();
				dFechaCreacion.Visible = false;
				dFechaModificacion.Visible = false;
				HideFieldsForAddEdit();
				nCodigo.Required = false;

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
				await SetupLookupOptions(nGeneroID);

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
					if (RouteValues.TryGetValue("nPacienteID", out rv)) { // DN
						nPacienteID.FormValue = Convert.ToString(rv);
						RecordKeys["nPacienteID"] = nPacienteID.FormValue;
					} else if (CurrentForm.HasValue("x_nPacienteID")) {
						nPacienteID.FormValue = CurrentForm.GetValue("x_nPacienteID");
						RecordKeys["nPacienteID"] = nPacienteID.FormValue;
					} else if (IsApi() && !Empty(keyValues)) {
						RecordKeys["nPacienteID"] = Convert.ToString(keyValues[0]);
					}
				} else {
					CurrentAction = "show"; // Default action is display

					// Load key from QueryString
					bool loadByQuery = false;
					string[] keyValues = null;
					object rv;
					if (IsApi() && RouteValues.TryGetValue("key", out object k))
						keyValues = k.ToString().Split('/');
					if (RouteValues.TryGetValue("nPacienteID", out rv)) { // DN
						nPacienteID.QueryValue = Convert.ToString(rv);
						RecordKeys["nPacienteID"] = nPacienteID.QueryValue;
						loadByQuery = true;
					} else if (!Empty(Get("nPacienteID"))) {
						nPacienteID.QueryValue = Get("nPacienteID");
						RecordKeys["nPacienteID"] = nPacienteID.QueryValue;
						loadByQuery = true;
					} else if (IsApi() && !Empty(keyValues)) {
						nPacienteID.QueryValue = Convert.ToString(keyValues[0]);
						RecordKeys["nPacienteID"] = nPacienteID.QueryValue;
						loadByQuery = true;
					} else {
						nPacienteID.CurrentValue = System.DBNull.Value;
					}
				}

			// Load current record
			loaded = await LoadRow();

			// Process form if post back
			if (postBack) {
				await LoadFormValues(); // Get form values
				if (IsApi() && RouteValues.TryGetValue("key", out object k)) {
					var keyValues = k.ToString().Split('/');
					nPacienteID.FormValue = Convert.ToString(keyValues[0]);
				}

				// Set up detail parameters
				SetupDetailParms();
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
							return Terminate("Pacientelist"); // No matching record, return to list
						}

						// Set up detail parameters
						SetupDetailParms();
						break;
					case "update": // Update // DN
						CloseRecordset(); // DN
						string returnUrl = "";
						if (!Empty(CurrentDetailTable)) // Master/detail edit
							returnUrl = GetViewUrl(Config.TableShowDetail + "=" + CurrentDetailTable); // Master/Detail view page
						else
							returnUrl = ReturnUrl;
						if (GetPageName(returnUrl) == "Pacientelist")
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

							// Set up detail parameters
							SetupDetailParms();
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

				// Check field name 'nCodigo' first before field var 'x_nCodigo'
				val = CurrentForm.GetValue("nCodigo", "x_nCodigo");
				if (!nCodigo.IsDetailKey) {
					if (IsApi() && val == null)
						nCodigo.Visible = false; // Disable update for API request
					else
						nCodigo.FormValue = val;
				}

				// Check field name 'sNombre' first before field var 'x_sNombre'
				val = CurrentForm.GetValue("sNombre", "x_sNombre");
				if (!sNombre.IsDetailKey) {
					if (IsApi() && val == null)
						sNombre.Visible = false; // Disable update for API request
					else
						sNombre.FormValue = val;
				}

				// Check field name 'sApellido1' first before field var 'x_sApellido1'
				val = CurrentForm.GetValue("sApellido1", "x_sApellido1");
				if (!sApellido1.IsDetailKey) {
					if (IsApi() && val == null)
						sApellido1.Visible = false; // Disable update for API request
					else
						sApellido1.FormValue = val;
				}

				// Check field name 'sApellido2' first before field var 'x_sApellido2'
				val = CurrentForm.GetValue("sApellido2", "x_sApellido2");
				if (!sApellido2.IsDetailKey) {
					if (IsApi() && val == null)
						sApellido2.Visible = false; // Disable update for API request
					else
						sApellido2.FormValue = val;
				}

				// Check field name 'nGeneroID' first before field var 'x_nGeneroID'
				val = CurrentForm.GetValue("nGeneroID", "x_nGeneroID");
				if (!nGeneroID.IsDetailKey) {
					if (IsApi() && val == null)
						nGeneroID.Visible = false; // Disable update for API request
					else
						nGeneroID.FormValue = val;
				}

				// Check field name 'sLugarNacimiento' first before field var 'x_sLugarNacimiento'
				val = CurrentForm.GetValue("sLugarNacimiento", "x_sLugarNacimiento");
				if (!sLugarNacimiento.IsDetailKey) {
					if (IsApi() && val == null)
						sLugarNacimiento.Visible = false; // Disable update for API request
					else
						sLugarNacimiento.FormValue = val;
				}

				// Check field name 'dFechaNacimiento' first before field var 'x_dFechaNacimiento'
				val = CurrentForm.GetValue("dFechaNacimiento", "x_dFechaNacimiento");
				if (!dFechaNacimiento.IsDetailKey) {
					if (IsApi() && val == null)
						dFechaNacimiento.Visible = false; // Disable update for API request
					else
						dFechaNacimiento.FormValue = val;
					dFechaNacimiento.CurrentValue = UnformatDateTime(dFechaNacimiento.CurrentValue, 0);
				}

				// Check field name 'sDireccion' first before field var 'x_sDireccion'
				val = CurrentForm.GetValue("sDireccion", "x_sDireccion");
				if (!sDireccion.IsDetailKey) {
					if (IsApi() && val == null)
						sDireccion.Visible = false; // Disable update for API request
					else
						sDireccion.FormValue = val;
				}

				// Check field name 'sCedula' first before field var 'x_sCedula'
				val = CurrentForm.GetValue("sCedula", "x_sCedula");
				if (!sCedula.IsDetailKey) {
					if (IsApi() && val == null)
						sCedula.Visible = false; // Disable update for API request
					else
						sCedula.FormValue = val;
				}

				// Check field name 'sTelefono' first before field var 'x_sTelefono'
				val = CurrentForm.GetValue("sTelefono", "x_sTelefono");
				if (!sTelefono.IsDetailKey) {
					if (IsApi() && val == null)
						sTelefono.Visible = false; // Disable update for API request
					else
						sTelefono.FormValue = val;
				}

				// Check field name 'sEmergenciaNombre' first before field var 'x_sEmergenciaNombre'
				val = CurrentForm.GetValue("sEmergenciaNombre", "x_sEmergenciaNombre");
				if (!sEmergenciaNombre.IsDetailKey) {
					if (IsApi() && val == null)
						sEmergenciaNombre.Visible = false; // Disable update for API request
					else
						sEmergenciaNombre.FormValue = val;
				}

				// Check field name 'sEmergenciaParentesco' first before field var 'x_sEmergenciaParentesco'
				val = CurrentForm.GetValue("sEmergenciaParentesco", "x_sEmergenciaParentesco");
				if (!sEmergenciaParentesco.IsDetailKey) {
					if (IsApi() && val == null)
						sEmergenciaParentesco.Visible = false; // Disable update for API request
					else
						sEmergenciaParentesco.FormValue = val;
				}

				// Check field name 'sEmergenciaTelefono' first before field var 'x_sEmergenciaTelefono'
				val = CurrentForm.GetValue("sEmergenciaTelefono", "x_sEmergenciaTelefono");
				if (!sEmergenciaTelefono.IsDetailKey) {
					if (IsApi() && val == null)
						sEmergenciaTelefono.Visible = false; // Disable update for API request
					else
						sEmergenciaTelefono.FormValue = val;
				}

				// Check field name 'nActivo' first before field var 'x_nActivo'
				val = CurrentForm.GetValue("nActivo", "x_nActivo");
				if (!nActivo.IsDetailKey) {
					if (IsApi() && val == null)
						nActivo.Visible = false; // Disable update for API request
					else
						nActivo.FormValue = val;
				}

				// Check field name 'nPacienteID' first before field var 'x_nPacienteID'
				val = CurrentForm.GetValue("nPacienteID", "x_nPacienteID");
				if (!nPacienteID.IsDetailKey)
					nPacienteID.FormValue = val;
			}

			#pragma warning restore 1998

			// Restore form values
			public void RestoreFormValues() {
				nPacienteID.CurrentValue = nPacienteID.FormValue;
				nCodigo.CurrentValue = nCodigo.FormValue;
				sNombre.CurrentValue = sNombre.FormValue;
				sApellido1.CurrentValue = sApellido1.FormValue;
				sApellido2.CurrentValue = sApellido2.FormValue;
				nGeneroID.CurrentValue = nGeneroID.FormValue;
				sLugarNacimiento.CurrentValue = sLugarNacimiento.FormValue;
				dFechaNacimiento.CurrentValue = dFechaNacimiento.FormValue;
				dFechaNacimiento.CurrentValue = UnformatDateTime(dFechaNacimiento.CurrentValue, 0);
				sDireccion.CurrentValue = sDireccion.FormValue;
				sCedula.CurrentValue = sCedula.FormValue;
				sTelefono.CurrentValue = sTelefono.FormValue;
				sEmergenciaNombre.CurrentValue = sEmergenciaNombre.FormValue;
				sEmergenciaParentesco.CurrentValue = sEmergenciaParentesco.FormValue;
				sEmergenciaTelefono.CurrentValue = sEmergenciaTelefono.FormValue;
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
				nPacienteID.SetDbValue(row["nPacienteID"]);
				nCodigo.SetDbValue(row["nCodigo"]);
				sNombre.SetDbValue(row["sNombre"]);
				sApellido1.SetDbValue(row["sApellido1"]);
				sApellido2.SetDbValue(row["sApellido2"]);
				nGeneroID.SetDbValue(row["nGeneroID"]);
				sLugarNacimiento.SetDbValue(row["sLugarNacimiento"]);
				dFechaNacimiento.SetDbValue(row["dFechaNacimiento"]);
				sDireccion.SetDbValue(row["sDireccion"]);
				sCedula.SetDbValue(row["sCedula"]);
				sTelefono.SetDbValue(row["sTelefono"]);
				sEmergenciaNombre.SetDbValue(row["sEmergenciaNombre"]);
				sEmergenciaParentesco.SetDbValue(row["sEmergenciaParentesco"]);
				sEmergenciaTelefono.SetDbValue(row["sEmergenciaTelefono"]);
				nActivo.SetDbValue((ConvertToBool(row["nActivo"]) ? "1" : "0"));
				dFechaCreacion.SetDbValue(row["dFechaCreacion"]);
				dFechaModificacion.SetDbValue(row["dFechaModificacion"]);
			}

			#pragma warning restore 162, 168, 1998

			// Return a row with default values
			protected Dictionary<string, object> NewRow() {
				var row = new Dictionary<string, object>();
				row.Add("nPacienteID", System.DBNull.Value);
				row.Add("nCodigo", System.DBNull.Value);
				row.Add("sNombre", System.DBNull.Value);
				row.Add("sApellido1", System.DBNull.Value);
				row.Add("sApellido2", System.DBNull.Value);
				row.Add("nGeneroID", System.DBNull.Value);
				row.Add("sLugarNacimiento", System.DBNull.Value);
				row.Add("dFechaNacimiento", System.DBNull.Value);
				row.Add("sDireccion", System.DBNull.Value);
				row.Add("sCedula", System.DBNull.Value);
				row.Add("sTelefono", System.DBNull.Value);
				row.Add("sEmergenciaNombre", System.DBNull.Value);
				row.Add("sEmergenciaParentesco", System.DBNull.Value);
				row.Add("sEmergenciaTelefono", System.DBNull.Value);
				row.Add("nActivo", System.DBNull.Value);
				row.Add("dFechaCreacion", System.DBNull.Value);
				row.Add("dFechaModificacion", System.DBNull.Value);
				return row;
			}

			#pragma warning disable 618, 1998

			// Load old record
			protected async Task<bool> LoadOldRecord(DatabaseConnectionBase<SqlConnection, SqlCommand, SqlDataReader, SqlDbType> cnn = null) {
				bool validKey = true;
				if (!Empty(GetKey("nPacienteID")))
					nPacienteID.CurrentValue = GetKey("nPacienteID"); // nPacienteID
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
				// nPacienteID
				// nCodigo
				// sNombre
				// sApellido1
				// sApellido2
				// nGeneroID
				// sLugarNacimiento
				// dFechaNacimiento
				// sDireccion
				// sCedula
				// sTelefono
				// sEmergenciaNombre
				// sEmergenciaParentesco
				// sEmergenciaTelefono
				// nActivo
				// dFechaCreacion
				// dFechaModificacion

				if (RowType == Config.RowTypeView) { // View row

					// nCodigo
					nCodigo.ViewValue = nCodigo.CurrentValue;
					nCodigo.ViewValue = FormatNumber(nCodigo.ViewValue, 0, -2, -2, -2);

					// sNombre
					sNombre.ViewValue = sNombre.CurrentValue;

					// sApellido1
					sApellido1.ViewValue = sApellido1.CurrentValue;

					// sApellido2
					sApellido2.ViewValue = sApellido2.CurrentValue;

					// nGeneroID
					curVal = Convert.ToString(nGeneroID.CurrentValue);
					if (!Empty(curVal)) {
						nGeneroID.ViewValue = nGeneroID.LookupCacheOption(curVal);
						if (nGeneroID.ViewValue == null) { // Lookup from database
							filterWrk = "[nValorCatalogoID]" + SearchString("=", curVal.Trim(), Config.DataTypeNumber, "");
							lookupFilter = () => "nCatalogoID=7";
							sqlWrk = nGeneroID.Lookup.GetSql(false, filterWrk, lookupFilter, this);
							rswrk = await Connection.GetRowsAsync(sqlWrk);
							if (rswrk != null && rswrk.Count > 0) { // Lookup values found
								var listwrk = rswrk[0].Values.ToList();
								listwrk[1] = Convert.ToString(FormatNumber(listwrk[1], 0, -2, -2, -2));
								listwrk[2] = Convert.ToString(listwrk[2]);
								nGeneroID.ViewValue = nGeneroID.DisplayValue(listwrk);
							} else {
								nGeneroID.ViewValue = nGeneroID.CurrentValue;
							}
						}
					} else {
						nGeneroID.ViewValue = System.DBNull.Value;
					}

					// sLugarNacimiento
					sLugarNacimiento.ViewValue = sLugarNacimiento.CurrentValue;

					// dFechaNacimiento
					dFechaNacimiento.ViewValue = dFechaNacimiento.CurrentValue;
					dFechaNacimiento.ViewValue = FormatDateTime(dFechaNacimiento.ViewValue, 0);

					// sDireccion
					sDireccion.ViewValue = sDireccion.CurrentValue;

					// sCedula
					sCedula.ViewValue = sCedula.CurrentValue;

					// sTelefono
					sTelefono.ViewValue = sTelefono.CurrentValue;

					// sEmergenciaNombre
					sEmergenciaNombre.ViewValue = sEmergenciaNombre.CurrentValue;

					// sEmergenciaParentesco
					sEmergenciaParentesco.ViewValue = sEmergenciaParentesco.CurrentValue;

					// sEmergenciaTelefono
					sEmergenciaTelefono.ViewValue = sEmergenciaTelefono.CurrentValue;

					// nActivo
					if (ConvertToBool(nActivo.CurrentValue)) {
						nActivo.ViewValue = (nActivo.TagCaption(1) != "") ? nActivo.TagCaption(1) : "Yes";
					} else {
						nActivo.ViewValue = (nActivo.TagCaption(2) != "") ? nActivo.TagCaption(2) : "No";
					}

					// nCodigo
					nCodigo.HrefValue = "";
					nCodigo.TooltipValue = "";

					// sNombre
					sNombre.HrefValue = "";
					sNombre.TooltipValue = "";

					// sApellido1
					sApellido1.HrefValue = "";
					sApellido1.TooltipValue = "";

					// sApellido2
					sApellido2.HrefValue = "";
					sApellido2.TooltipValue = "";

					// nGeneroID
					nGeneroID.HrefValue = "";
					nGeneroID.TooltipValue = "";

					// sLugarNacimiento
					sLugarNacimiento.HrefValue = "";
					sLugarNacimiento.TooltipValue = "";

					// dFechaNacimiento
					dFechaNacimiento.HrefValue = "";
					dFechaNacimiento.TooltipValue = "";

					// sDireccion
					sDireccion.HrefValue = "";
					sDireccion.TooltipValue = "";

					// sCedula
					sCedula.HrefValue = "";
					sCedula.TooltipValue = "";

					// sTelefono
					sTelefono.HrefValue = "";
					sTelefono.TooltipValue = "";

					// sEmergenciaNombre
					sEmergenciaNombre.HrefValue = "";
					sEmergenciaNombre.TooltipValue = "";

					// sEmergenciaParentesco
					sEmergenciaParentesco.HrefValue = "";
					sEmergenciaParentesco.TooltipValue = "";

					// sEmergenciaTelefono
					sEmergenciaTelefono.HrefValue = "";
					sEmergenciaTelefono.TooltipValue = "";

					// nActivo
					nActivo.HrefValue = "";
					nActivo.TooltipValue = "";
				} else if (RowType == Config.RowTypeEdit) { // Edit row

					// nCodigo
					nCodigo.EditAttrs["class"] = "form-control";
					nCodigo.EditValue = nCodigo.CurrentValue;
					nCodigo.EditValue = FormatNumber(nCodigo.EditValue, 0, -2, -2, -2);

					// sNombre
					sNombre.EditAttrs["class"] = "form-control";
					if (Config.RemoveXss)
						sNombre.CurrentValue = HtmlDecode(sNombre.CurrentValue);
					sNombre.EditValue = sNombre.CurrentValue; // DN
					sNombre.PlaceHolder = RemoveHtml(sNombre.Caption);

					// sApellido1
					sApellido1.EditAttrs["class"] = "form-control";
					if (Config.RemoveXss)
						sApellido1.CurrentValue = HtmlDecode(sApellido1.CurrentValue);
					sApellido1.EditValue = sApellido1.CurrentValue; // DN
					sApellido1.PlaceHolder = RemoveHtml(sApellido1.Caption);

					// sApellido2
					sApellido2.EditAttrs["class"] = "form-control";
					if (Config.RemoveXss)
						sApellido2.CurrentValue = HtmlDecode(sApellido2.CurrentValue);
					sApellido2.EditValue = sApellido2.CurrentValue; // DN
					sApellido2.PlaceHolder = RemoveHtml(sApellido2.Caption);

					// nGeneroID
					curVal = Convert.ToString(nGeneroID.CurrentValue).Trim();
					if (curVal != "")
						nGeneroID.ViewValue = nGeneroID.LookupCacheOption(curVal);
					else
						nGeneroID.ViewValue = nGeneroID.Lookup != null && IsList(nGeneroID.Lookup.Options) ? curVal : null;
					if (nGeneroID.ViewValue != null) { // Load from cache
						nGeneroID.EditValue = nGeneroID.Lookup.Options.Values.ToList();
						if (SameString(nGeneroID.ViewValue, ""))
							nGeneroID.ViewValue = Language.Phrase("PleaseSelect");
					} else { // Lookup from database
						if (curVal == "") {
							filterWrk = "0=1";
						} else {
							filterWrk = "[nValorCatalogoID]" + SearchString("=", Convert.ToString(nGeneroID.CurrentValue), Config.DataTypeNumber, "");
						}
					lookupFilter = () => "nCatalogoID=7";
					sqlWrk = nGeneroID.Lookup.GetSql(true, filterWrk, lookupFilter, this);
					rswrk = await Connection.GetRowsAsync(sqlWrk);
					if (rswrk != null && rswrk.Count > 0) { // Lookup values found
						var listwrk = rswrk[0].Values.ToList();
						listwrk[1] = Convert.ToString(HtmlEncode(FormatNumber(listwrk[1], 0, -2, -2, -2)));
						listwrk[2] = Convert.ToString(HtmlEncode(listwrk[2]));
						nGeneroID.ViewValue = nGeneroID.DisplayValue(listwrk);
						foreach (var d in rswrk) {
							var keys = d.Keys.ToList();
							d[keys[1]] = FormatNumber(d[keys[1]], 0, -2, -2, -2);
						}
					} else {
						nGeneroID.ViewValue = nGeneroID.PleaseSelectText;
					}
					nGeneroID.EditValue = rswrk;
					}

					// sLugarNacimiento
					sLugarNacimiento.EditAttrs["class"] = "form-control";
					if (Config.RemoveXss)
						sLugarNacimiento.CurrentValue = HtmlDecode(sLugarNacimiento.CurrentValue);
					sLugarNacimiento.EditValue = sLugarNacimiento.CurrentValue; // DN
					sLugarNacimiento.PlaceHolder = RemoveHtml(sLugarNacimiento.Caption);

					// dFechaNacimiento
					dFechaNacimiento.EditAttrs["class"] = "form-control";
					dFechaNacimiento.EditValue = FormatDateTime(dFechaNacimiento.CurrentValue, 8); // DN
					dFechaNacimiento.PlaceHolder = RemoveHtml(dFechaNacimiento.Caption);

					// sDireccion
					sDireccion.EditAttrs["class"] = "form-control";
					if (Config.RemoveXss)
						sDireccion.CurrentValue = HtmlDecode(sDireccion.CurrentValue);
					sDireccion.EditValue = sDireccion.CurrentValue; // DN
					sDireccion.PlaceHolder = RemoveHtml(sDireccion.Caption);

					// sCedula
					sCedula.EditAttrs["class"] = "form-control";
					if (Config.RemoveXss)
						sCedula.CurrentValue = HtmlDecode(sCedula.CurrentValue);
					sCedula.EditValue = sCedula.CurrentValue; // DN
					sCedula.PlaceHolder = RemoveHtml(sCedula.Caption);

					// sTelefono
					sTelefono.EditAttrs["class"] = "form-control";
					if (Config.RemoveXss)
						sTelefono.CurrentValue = HtmlDecode(sTelefono.CurrentValue);
					sTelefono.EditValue = sTelefono.CurrentValue; // DN
					sTelefono.PlaceHolder = RemoveHtml(sTelefono.Caption);

					// sEmergenciaNombre
					sEmergenciaNombre.EditAttrs["class"] = "form-control";
					if (Config.RemoveXss)
						sEmergenciaNombre.CurrentValue = HtmlDecode(sEmergenciaNombre.CurrentValue);
					sEmergenciaNombre.EditValue = sEmergenciaNombre.CurrentValue; // DN
					sEmergenciaNombre.PlaceHolder = RemoveHtml(sEmergenciaNombre.Caption);

					// sEmergenciaParentesco
					sEmergenciaParentesco.EditAttrs["class"] = "form-control";
					if (Config.RemoveXss)
						sEmergenciaParentesco.CurrentValue = HtmlDecode(sEmergenciaParentesco.CurrentValue);
					sEmergenciaParentesco.EditValue = sEmergenciaParentesco.CurrentValue; // DN
					sEmergenciaParentesco.PlaceHolder = RemoveHtml(sEmergenciaParentesco.Caption);

					// sEmergenciaTelefono
					sEmergenciaTelefono.EditAttrs["class"] = "form-control";
					if (Config.RemoveXss)
						sEmergenciaTelefono.CurrentValue = HtmlDecode(sEmergenciaTelefono.CurrentValue);
					sEmergenciaTelefono.EditValue = sEmergenciaTelefono.CurrentValue; // DN
					sEmergenciaTelefono.PlaceHolder = RemoveHtml(sEmergenciaTelefono.Caption);

					// nActivo
					nActivo.EditValue = nActivo.Options(false);

					// Edit refer script
					// nCodigo

					nCodigo.HrefValue = "";
					nCodigo.TooltipValue = "";

					// sNombre
					sNombre.HrefValue = "";

					// sApellido1
					sApellido1.HrefValue = "";

					// sApellido2
					sApellido2.HrefValue = "";

					// nGeneroID
					nGeneroID.HrefValue = "";

					// sLugarNacimiento
					sLugarNacimiento.HrefValue = "";

					// dFechaNacimiento
					dFechaNacimiento.HrefValue = "";

					// sDireccion
					sDireccion.HrefValue = "";

					// sCedula
					sCedula.HrefValue = "";

					// sTelefono
					sTelefono.HrefValue = "";

					// sEmergenciaNombre
					sEmergenciaNombre.HrefValue = "";

					// sEmergenciaParentesco
					sEmergenciaParentesco.HrefValue = "";

					// sEmergenciaTelefono
					sEmergenciaTelefono.HrefValue = "";

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
				if (nPacienteID.Required) {
					if (!nPacienteID.IsDetailKey && Empty(nPacienteID.FormValue))
						FormError = AddMessage(FormError, nPacienteID.RequiredErrorMessage.Replace("%s", nPacienteID.Caption));
				}
				if (nCodigo.Required) {
					if (!nCodigo.IsDetailKey && Empty(nCodigo.FormValue))
						FormError = AddMessage(FormError, nCodigo.RequiredErrorMessage.Replace("%s", nCodigo.Caption));
				}
				if (sNombre.Required) {
					if (!sNombre.IsDetailKey && Empty(sNombre.FormValue))
						FormError = AddMessage(FormError, sNombre.RequiredErrorMessage.Replace("%s", sNombre.Caption));
				}
				if (sApellido1.Required) {
					if (!sApellido1.IsDetailKey && Empty(sApellido1.FormValue))
						FormError = AddMessage(FormError, sApellido1.RequiredErrorMessage.Replace("%s", sApellido1.Caption));
				}
				if (sApellido2.Required) {
					if (!sApellido2.IsDetailKey && Empty(sApellido2.FormValue))
						FormError = AddMessage(FormError, sApellido2.RequiredErrorMessage.Replace("%s", sApellido2.Caption));
				}
				if (nGeneroID.Required) {
					if (!nGeneroID.IsDetailKey && Empty(nGeneroID.FormValue))
						FormError = AddMessage(FormError, nGeneroID.RequiredErrorMessage.Replace("%s", nGeneroID.Caption));
				}
				if (sLugarNacimiento.Required) {
					if (!sLugarNacimiento.IsDetailKey && Empty(sLugarNacimiento.FormValue))
						FormError = AddMessage(FormError, sLugarNacimiento.RequiredErrorMessage.Replace("%s", sLugarNacimiento.Caption));
				}
				if (dFechaNacimiento.Required) {
					if (!dFechaNacimiento.IsDetailKey && Empty(dFechaNacimiento.FormValue))
						FormError = AddMessage(FormError, dFechaNacimiento.RequiredErrorMessage.Replace("%s", dFechaNacimiento.Caption));
				}
				if (!CheckDate(dFechaNacimiento.FormValue))
					FormError = AddMessage(FormError, dFechaNacimiento.ErrorMessage);
				if (sDireccion.Required) {
					if (!sDireccion.IsDetailKey && Empty(sDireccion.FormValue))
						FormError = AddMessage(FormError, sDireccion.RequiredErrorMessage.Replace("%s", sDireccion.Caption));
				}
				if (sCedula.Required) {
					if (!sCedula.IsDetailKey && Empty(sCedula.FormValue))
						FormError = AddMessage(FormError, sCedula.RequiredErrorMessage.Replace("%s", sCedula.Caption));
				}
				if (sTelefono.Required) {
					if (!sTelefono.IsDetailKey && Empty(sTelefono.FormValue))
						FormError = AddMessage(FormError, sTelefono.RequiredErrorMessage.Replace("%s", sTelefono.Caption));
				}
				if (sEmergenciaNombre.Required) {
					if (!sEmergenciaNombre.IsDetailKey && Empty(sEmergenciaNombre.FormValue))
						FormError = AddMessage(FormError, sEmergenciaNombre.RequiredErrorMessage.Replace("%s", sEmergenciaNombre.Caption));
				}
				if (sEmergenciaParentesco.Required) {
					if (!sEmergenciaParentesco.IsDetailKey && Empty(sEmergenciaParentesco.FormValue))
						FormError = AddMessage(FormError, sEmergenciaParentesco.RequiredErrorMessage.Replace("%s", sEmergenciaParentesco.Caption));
				}
				if (sEmergenciaTelefono.Required) {
					if (!sEmergenciaTelefono.IsDetailKey && Empty(sEmergenciaTelefono.FormValue))
						FormError = AddMessage(FormError, sEmergenciaTelefono.RequiredErrorMessage.Replace("%s", sEmergenciaTelefono.Caption));
				}
				if (nActivo.Required) {
					if (Empty(nActivo.FormValue))
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

				// Validate detail grid
				var detailTblVar = CurrentDetailTables;
				if (detailTblVar.Contains("Expediente") && Expediente.DetailEdit) {
					Expediente_Grid = Expediente_Grid ?? new _Expediente_Grid(); // Get detail page object
					await Expediente_Grid.ValidateGridForm();
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

				// sNombre
				sNombre.SetDbValue(rsnew, sNombre.CurrentValue, "", sNombre.ReadOnly);

				// sApellido1
				sApellido1.SetDbValue(rsnew, sApellido1.CurrentValue, "", sApellido1.ReadOnly);

				// sApellido2
				sApellido2.SetDbValue(rsnew, sApellido2.CurrentValue, System.DBNull.Value, sApellido2.ReadOnly);

				// nGeneroID
				nGeneroID.SetDbValue(rsnew, nGeneroID.CurrentValue, 0, nGeneroID.ReadOnly);

				// sLugarNacimiento
				sLugarNacimiento.SetDbValue(rsnew, sLugarNacimiento.CurrentValue, "", sLugarNacimiento.ReadOnly);

				// dFechaNacimiento
				dFechaNacimiento.SetDbValue(rsnew, UnformatDateTime(dFechaNacimiento.CurrentValue, 0), DateTime.Now, dFechaNacimiento.ReadOnly);

				// sDireccion
				sDireccion.SetDbValue(rsnew, sDireccion.CurrentValue, System.DBNull.Value, sDireccion.ReadOnly);

				// sCedula
				sCedula.SetDbValue(rsnew, sCedula.CurrentValue, "", sCedula.ReadOnly);

				// sTelefono
				sTelefono.SetDbValue(rsnew, sTelefono.CurrentValue, System.DBNull.Value, sTelefono.ReadOnly);

				// sEmergenciaNombre
				sEmergenciaNombre.SetDbValue(rsnew, sEmergenciaNombre.CurrentValue, System.DBNull.Value, sEmergenciaNombre.ReadOnly);

				// sEmergenciaParentesco
				sEmergenciaParentesco.SetDbValue(rsnew, sEmergenciaParentesco.CurrentValue, System.DBNull.Value, sEmergenciaParentesco.ReadOnly);

				// sEmergenciaTelefono
				sEmergenciaTelefono.SetDbValue(rsnew, sEmergenciaTelefono.CurrentValue, System.DBNull.Value, sEmergenciaTelefono.ReadOnly);

				// nActivo
				nActivo.SetDbValue(rsnew, ConvertToBool(nActivo.CurrentValue, "1", "0"), 0, nActivo.ReadOnly); // DN1204

				// Begin transaction
				if (!Empty(CurrentDetailTable))
					Connection.BeginTrans();

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

						// Update detail records
						var detailTblVar = CurrentDetailTables;
						if (result) {
							if (detailTblVar.Contains("Expediente") && Expediente.DetailEdit) {
								Expediente_Grid = Expediente_Grid ?? new _Expediente_Grid(); // Get detail page object
								Security.LoadCurrentUserLevel(ProjectID + "Expediente"); // Load user level of detail table
								result = await Expediente_Grid.GridUpdate();
								Security.LoadCurrentUserLevel(ProjectID + TableName); // Restore user level of master table
							}
						}

						// Commit/Rollback transaction
						if (!Empty(CurrentDetailTable)) {
							if (result) {
								Connection.CommitTrans(); // Commit transaction
							} else {
								Connection.RollbackTrans(); // Rollback transaction
							}
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

			// Set up detail parms based on QueryString
			protected void SetupDetailParms() {
				StringValues detailTblVar = "";

				// Get the keys for master table
				if (Query.TryGetValue(Config.TableShowDetail, out detailTblVar)) { // Value may be empty
					CurrentDetailTable = detailTblVar;
				} else {
					detailTblVar = CurrentDetailTable;
				}
				if (!Empty(detailTblVar)) {
					var detailTblVars = new List<string>(detailTblVar.ToString().Split(','));
					if (detailTblVars.Contains("Expediente")) {
						Expediente_Grid = Expediente_Grid ?? new _Expediente_Grid();
						if (Expediente_Grid.DetailEdit) {
							Expediente_Grid.CurrentMode = "edit";
							Expediente_Grid.CurrentAction = "gridedit";

							// Save current master table to detail table
							Expediente_Grid.CurrentMasterTable = TableVar;
							Expediente_Grid.StartRecordNumber = 1;
							Expediente_Grid.nPacienteID.IsDetailKey = true;
							Expediente_Grid.nPacienteID.CurrentValue = nPacienteID.CurrentValue;
							Expediente_Grid.nPacienteID.SessionValue = Expediente_Grid.nPacienteID.CurrentValue;
						}
					}
				}
			}

			// Set up Breadcrumb
			protected void SetupBreadcrumb() {
				var breadcrumb = new Breadcrumb();
				string url = CurrentUrl();
				breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("Pacientelist")), "", TableVar, true);
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
						case "x_nGeneroID":
							lookupFilter = () => "nCatalogoID=7";
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
									case "x_nGeneroID":

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
