// ASP.NET Maker 2019
// Copyright (c) e.World Technology Limited. All rights reserved.

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
using static AspNetMaker2019.Models.prjSIGECO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;

// Models
namespace AspNetMaker2019.Models {

	// Partial class
	public partial class prjSIGECO {

		/// <summary>
		/// Cita_Edit
		/// </summary>

		public static _Cita_Edit Cita_Edit {
			get => HttpData.Get<_Cita_Edit>("Cita_Edit");
			set => HttpData["Cita_Edit"] = value;
		}

		/// <summary>
		/// Page class for Cita
		/// </summary>

		public class _Cita_Edit : _Cita_EditBase
		{

			// Construtor
			public _Cita_Edit(Controller controller = null) : base(controller) {
			}
		}

		/// <summary>
		/// Page base class
		/// </summary>

		public class _Cita_EditBase : _Cita, IAspNetMakerPage
		{

			// Page ID
			public string PageID = "edit";

			// Project ID
			public string ProjectID = "{9B083C8B-EE2F-4356-BE8D-9A26D5707365}";

			// Table name
			public string TableName = "Cita";

			// Page object name
			public string PageObjName = "Cita_Edit";

			// Page headings
			public string Heading = "";
			public string Subheading = "";
			public string PageHeader = "";
			public string PageFooter = "";

			// Token
			public string Token; // DN
			public int TokenTimeout = 0;
			public bool CheckToken = Config.CheckToken;

			// Action result // DN
			public IActionResult ActionResult;

			// Cache // DN
			public IMemoryCache Cache;

			// Page terminated // DN
			private bool _terminated = false;

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
			public string PageUrl => CurrentPageName() + "?";

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
				if (!Empty(footer)) // Fotoer exists, display
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
			public _Cita_EditBase(Controller controller = null) { // DN
				if (controller != null)
					Controller = controller;

				// Initialize
				CurrentPage = this;
				TokenTimeout = SessionTimeoutTime();

				// Language object
				Language = Language ?? new Lang();

				// Table object (Cita)
				if (Cita == null || Cita is _Cita)
					Cita = this;

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
					dynamic doc = CreateInstance(classname, new object[] { Cita, "" }); // DN
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
								if (pageName == "Citaview")
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
				key += UrlEncode(Convert.ToString(ar["nCitaID"]));
				return key;
			}

			// Hide fields for Add/Edit
			protected void HideFieldsForAddEdit() {
				if (IsAdd || IsCopy || IsGridAdd)
					nCitaID.Visible = false;
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
							return Terminate(GetUrl("Citalist"));
						else
							return Terminate(GetUrl("login"));
					}
				}

				// Create form object
				CurrentForm = new HttpForm();
				CurrentAction = Param("action"); // Set up current action
				nCitaID.Visible = false;
				nExpedienteID.SetVisibility();
				sMotivoCita.SetVisibility();
				dFechaHoraCita.SetVisibility();
				dHora.SetVisibility();
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
					if (RouteValues.TryGetValue("nCitaID", out rv)) { // DN
						nCitaID.FormValue = Convert.ToString(rv);
						RecordKeys["nCitaID"] = nCitaID.FormValue;
					} else if (CurrentForm.HasValue("x_nCitaID")) {
						nCitaID.FormValue = CurrentForm.GetValue("x_nCitaID");
						RecordKeys["nCitaID"] = nCitaID.FormValue;
					} else if (IsApi() && !Empty(keyValues)) {
						RecordKeys["nCitaID"] = Convert.ToString(keyValues[0]);
					}
				} else {
					CurrentAction = "show"; // Default action is display

					// Load key from QueryString
					bool loadByQuery = false;
					string[] keyValues = null;
					object rv;
					if (IsApi() && RouteValues.TryGetValue("key", out object k))
						keyValues = k.ToString().Split('/');
					if (RouteValues.TryGetValue("nCitaID", out rv)) { // DN
						nCitaID.QueryValue = Convert.ToString(rv);
						RecordKeys["nCitaID"] = nCitaID.QueryValue;
						loadByQuery = true;
					} else if (!Empty(Get("nCitaID"))) {
						nCitaID.QueryValue = Get("nCitaID");
						RecordKeys["nCitaID"] = nCitaID.QueryValue;
						loadByQuery = true;
					} else if (IsApi() && !Empty(keyValues)) {
						nCitaID.QueryValue = Convert.ToString(keyValues[0]);
						RecordKeys["nCitaID"] = nCitaID.QueryValue;
						loadByQuery = true;
					} else {
						nCitaID.CurrentValue = System.DBNull.Value;
					}
				}

			// Load current record
			loaded = await LoadRow();

			// Process form if post back
			if (postBack) {
				await LoadFormValues(); // Get form values
				if (IsApi() && RouteValues.TryGetValue("key", out object k)) {
					var keyValues = k.ToString().Split('/');
					nCitaID.FormValue = Convert.ToString(keyValues[0]);
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
							return Terminate("Citalist"); // No matching record, return to list
						}
						break;
					case "update": // Update // DN
						CloseRecordset(); // DN
						string returnUrl = ReturnUrl;
						if (GetPageName(returnUrl) == "Citalist")
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

				// Check field name 'nExpedienteID' first before field var 'x_nExpedienteID'
				val = CurrentForm.GetValue("nExpedienteID", "x_nExpedienteID");
				if (!nExpedienteID.IsDetailKey) {
					if (IsApi() && val == null)
						nExpedienteID.Visible = false; // Disable update for API request
					else
						nExpedienteID.FormValue = val;
				}

				// Check field name 'sMotivoCita' first before field var 'x_sMotivoCita'
				val = CurrentForm.GetValue("sMotivoCita", "x_sMotivoCita");
				if (!sMotivoCita.IsDetailKey) {
					if (IsApi() && val == null)
						sMotivoCita.Visible = false; // Disable update for API request
					else
						sMotivoCita.FormValue = val;
				}

				// Check field name 'dFechaHoraCita' first before field var 'x_dFechaHoraCita'
				val = CurrentForm.GetValue("dFechaHoraCita", "x_dFechaHoraCita");
				if (!dFechaHoraCita.IsDetailKey) {
					if (IsApi() && val == null)
						dFechaHoraCita.Visible = false; // Disable update for API request
					else
						dFechaHoraCita.FormValue = val;
					dFechaHoraCita.CurrentValue = UnformatDateTime(dFechaHoraCita.CurrentValue, 0);
				}

				// Check field name 'dHora' first before field var 'x_dHora'
				val = CurrentForm.GetValue("dHora", "x_dHora");
				if (!dHora.IsDetailKey) {
					if (IsApi() && val == null)
						dHora.Visible = false; // Disable update for API request
					else
						dHora.FormValue = val;
					dHora.CurrentValue = UnformatDateTime(dHora.CurrentValue, 4);
				}

				// Check field name 'nEstadoID' first before field var 'x_nEstadoID'
				val = CurrentForm.GetValue("nEstadoID", "x_nEstadoID");
				if (!nEstadoID.IsDetailKey) {
					if (IsApi() && val == null)
						nEstadoID.Visible = false; // Disable update for API request
					else
						nEstadoID.FormValue = val;
				}

				// Check field name 'nCitaID' first before field var 'x_nCitaID'
				val = CurrentForm.GetValue("nCitaID", "x_nCitaID");
				if (!nCitaID.IsDetailKey)
					nCitaID.FormValue = val;
			}

			#pragma warning restore 1998

			// Restore form values
			public void RestoreFormValues() {
				nCitaID.CurrentValue = nCitaID.FormValue;
				nExpedienteID.CurrentValue = nExpedienteID.FormValue;
				sMotivoCita.CurrentValue = sMotivoCita.FormValue;
				dFechaHoraCita.CurrentValue = dFechaHoraCita.FormValue;
				dFechaHoraCita.CurrentValue = UnformatDateTime(dFechaHoraCita.CurrentValue, 0);
				dHora.CurrentValue = dHora.FormValue;
				dHora.CurrentValue = UnformatDateTime(dHora.CurrentValue, 4);
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
				nCitaID.SetDbValue(row["nCitaID"]);
				nExpedienteID.SetDbValue(row["nExpedienteID"]);
				sMotivoCita.SetDbValue(row["sMotivoCita"]);
				dFechaHoraCita.SetDbValue(row["dFechaHoraCita"]);
				dHora.SetDbValue(ConvertToDateTime(row["dHora"]));
				nEstadoID.SetDbValue(row["nEstadoID"]);
				dFechaCreacion.SetDbValue(row["dFechaCreacion"]);
				dFechaModificacion.SetDbValue(row["dFechaModificacion"]);
			}

			#pragma warning restore 162, 168, 1998

			// Return a row with default values
			protected Dictionary<string, object> NewRow() {
				var row = new Dictionary<string, object>();
				row.Add("nCitaID", System.DBNull.Value);
				row.Add("nExpedienteID", System.DBNull.Value);
				row.Add("sMotivoCita", System.DBNull.Value);
				row.Add("dFechaHoraCita", System.DBNull.Value);
				row.Add("dHora", System.DBNull.Value);
				row.Add("nEstadoID", System.DBNull.Value);
				row.Add("dFechaCreacion", System.DBNull.Value);
				row.Add("dFechaModificacion", System.DBNull.Value);
				return row;
			}

			#pragma warning disable 618, 1998

			// Load old record
			protected async Task<bool> LoadOldRecord(DatabaseConnectionBase<SqlConnection, SqlCommand, SqlDataReader, SqlDbType> cnn = null) {
				bool validKey = true;
				if (!Empty(GetKey("nCitaID")))
					nCitaID.CurrentValue = GetKey("nCitaID"); // nCitaID
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
				// nCitaID
				// nExpedienteID
				// sMotivoCita
				// dFechaHoraCita
				// dHora
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
							rswrk = Connection.GetRows(sqlWrk);
						if (rswrk != null && rswrk.Count > 0) { // Lookup values found
							var listwrk = rswrk[0].Values.ToList();
							listwrk[1] = Convert.ToString(FormatNumber(listwrk[1], 0, -2, -2, -2));
							listwrk[2] = Convert.ToString(FormatNumber(listwrk[2], 0, -2, -2, -2));
							listwrk[3] = Convert.ToString(FormatNumber(listwrk[3], 0, -2, -2, -2));
							nExpedienteID.ViewValue = nExpedienteID.DisplayValue(listwrk);
						} else {
							nExpedienteID.ViewValue = nExpedienteID.CurrentValue;
						}
						}
					} else {
						nExpedienteID.ViewValue = System.DBNull.Value;
					}

					// sMotivoCita
					sMotivoCita.ViewValue = sMotivoCita.CurrentValue;

					// dFechaHoraCita
					dFechaHoraCita.ViewValue = dFechaHoraCita.CurrentValue;
					dFechaHoraCita.ViewValue = FormatDateTime(dFechaHoraCita.ViewValue, 0);

					// dHora
					dHora.ViewValue = dHora.CurrentValue;
					dHora.ViewValue = FormatDateTime(dHora.ViewValue, 4);

					// nEstadoID
					curVal = Convert.ToString(nEstadoID.CurrentValue);
					if (!Empty(curVal)) {
						nEstadoID.ViewValue = nEstadoID.LookupCacheOption(curVal);
						if (nEstadoID.ViewValue == null) { // Lookup from database
						filterWrk = "[nValorCatalogoID]" + SearchString("=", curVal.Trim(), Config.DataTypeNumber, "");
							lookupFilter = () => "nCatalogoID=15";
							sqlWrk = nEstadoID.Lookup.GetSql(false, filterWrk, lookupFilter, this);
							rswrk = Connection.GetRows(sqlWrk);
						if (rswrk != null && rswrk.Count > 0) { // Lookup values found
							var listwrk = rswrk[0].Values.ToList();
							listwrk[1] = Convert.ToString(FormatNumber(listwrk[1], 0, -2, -2, -2));
							listwrk[2] = Convert.ToString(FormatNumber(listwrk[2], 0, -2, -2, -2));
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

					// sMotivoCita
					sMotivoCita.HrefValue = "";
					sMotivoCita.TooltipValue = "";

					// dFechaHoraCita
					dFechaHoraCita.HrefValue = "";
					dFechaHoraCita.TooltipValue = "";

					// dHora
					dHora.HrefValue = "";
					dHora.TooltipValue = "";

					// nEstadoID
					nEstadoID.HrefValue = "";
					nEstadoID.TooltipValue = "";
				} else if (RowType == Config.RowTypeEdit) { // Edit row

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
					rswrk = Connection.GetRows(sqlWrk);
					if (rswrk != null && rswrk.Count > 0) { // Lookup values found
						var listwrk = rswrk[0].Values.ToList();
						listwrk[1] = Convert.ToString(HtmlEncode(FormatNumber(listwrk[1], 0, -2, -2, -2)));
						listwrk[2] = Convert.ToString(HtmlEncode(listwrk[2]));
						listwrk[3] = Convert.ToString(HtmlEncode(listwrk[3]));
						nExpedienteID.ViewValue = String.Concat(nExpedienteID.ViewValue, nExpedienteID.DisplayValue(listwrk));
						foreach (var d in rswrk) {
							var keys = d.Keys.ToList();
							d[keys[1]] = FormatNumber(d[keys[1]], 0, -2, -2, -2);
						}
					} else {
						nExpedienteID.ViewValue = nExpedienteID.PleaseSelectText;
					}
					nExpedienteID.EditValue = rswrk;
					}

					// sMotivoCita
					sMotivoCita.EditAttrs["class"] = "form-control";
					sMotivoCita.EditValue = sMotivoCita.CurrentValue; // DN
					sMotivoCita.PlaceHolder = RemoveHtml(sMotivoCita.Caption);

					// dFechaHoraCita
					dFechaHoraCita.EditAttrs["class"] = "form-control";
					dFechaHoraCita.EditValue = FormatDateTime(dFechaHoraCita.CurrentValue, 8); // DN
					dFechaHoraCita.PlaceHolder = RemoveHtml(dFechaHoraCita.Caption);

					// dHora
					dHora.EditAttrs["class"] = "form-control";
					dHora.EditValue = FormatDateTime(dHora.CurrentValue, 4); // DN
					dHora.PlaceHolder = RemoveHtml(dHora.Caption);

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
					lookupFilter = () => "nCatalogoID=15";
					sqlWrk = nEstadoID.Lookup.GetSql(true, filterWrk, lookupFilter, this);
					rswrk = Connection.GetRows(sqlWrk);
					if (rswrk != null && rswrk.Count > 0) { // Lookup values found
						var listwrk = rswrk[0].Values.ToList();
						listwrk[1] = Convert.ToString(HtmlEncode(FormatNumber(listwrk[1], 0, -2, -2, -2)));
						listwrk[2] = Convert.ToString(HtmlEncode(listwrk[2]));
						nEstadoID.ViewValue = String.Concat(nEstadoID.ViewValue, nEstadoID.DisplayValue(listwrk));
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
					// nExpedienteID

					nExpedienteID.HrefValue = "";

					// sMotivoCita
					sMotivoCita.HrefValue = "";

					// dFechaHoraCita
					dFechaHoraCita.HrefValue = "";

					// dHora
					dHora.HrefValue = "";

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
				if (nCitaID.Required) {
					if (!nCitaID.IsDetailKey && Empty(nCitaID.FormValue))
						FormError = AddMessage(FormError, nCitaID.RequiredErrorMessage.Replace("%s", nCitaID.Caption));
				}
				if (nExpedienteID.Required) {
					if (!nExpedienteID.IsDetailKey && Empty(nExpedienteID.FormValue))
						FormError = AddMessage(FormError, nExpedienteID.RequiredErrorMessage.Replace("%s", nExpedienteID.Caption));
				}
				if (sMotivoCita.Required) {
					if (!sMotivoCita.IsDetailKey && Empty(sMotivoCita.FormValue))
						FormError = AddMessage(FormError, sMotivoCita.RequiredErrorMessage.Replace("%s", sMotivoCita.Caption));
				}
				if (dFechaHoraCita.Required) {
					if (!dFechaHoraCita.IsDetailKey && Empty(dFechaHoraCita.FormValue))
						FormError = AddMessage(FormError, dFechaHoraCita.RequiredErrorMessage.Replace("%s", dFechaHoraCita.Caption));
				}
				if (!CheckDate(dFechaHoraCita.FormValue))
					FormError = AddMessage(FormError, dFechaHoraCita.ErrorMessage);
				if (dHora.Required) {
					if (!dHora.IsDetailKey && Empty(dHora.FormValue))
						FormError = AddMessage(FormError, dHora.RequiredErrorMessage.Replace("%s", dHora.Caption));
				}
				if (!CheckTime(dHora.FormValue))
					FormError = AddMessage(FormError, dHora.ErrorMessage);
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

				// nExpedienteID
				nExpedienteID.SetDbValue(rsnew, nExpedienteID.CurrentValue, 0, nExpedienteID.ReadOnly);

				// sMotivoCita
				sMotivoCita.SetDbValue(rsnew, sMotivoCita.CurrentValue, "", sMotivoCita.ReadOnly);

				// dFechaHoraCita
				dFechaHoraCita.SetDbValue(rsnew, UnformatDateTime(dFechaHoraCita.CurrentValue, 0), DateTime.Now, dFechaHoraCita.ReadOnly);

				// dHora
				dHora.SetDbValue(rsnew, UnformatDateTime(dHora.CurrentValue, 4), DateTime.Now, dHora.ReadOnly);

				// nEstadoID
				nEstadoID.SetDbValue(rsnew, nEstadoID.CurrentValue, 0, nEstadoID.ReadOnly);

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

			// Set up Breadcrumb
			protected void SetupBreadcrumb() {
				var breadcrumb = new Breadcrumb();
				string url = CurrentUrl();
				breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("Citalist")), "", TableVar, true);
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
						case "x_nEstadoID":
							lookupFilter = () => "nCatalogoID=15";
							break;
						default:
							break;
					}

					// Always call to Lookup.GetSql so that user can setup Lookup.Options in Lookup_Selecting server event
					var sql = fld.Lookup.GetSql(false, "", lookupFilter, this);

					// Set up lookup cache
					if (fld.UseLookupCache && !Empty(sql) && fld.Lookup.Options.Count == 0) {
						int totalCnt = await TryGetRecordCount(sql);
						if (totalCnt > fld.LookupCacheCount) // Total count > cache count, do not cache
							return;
						var ar = new Dictionary<string, Dictionary<string, object>>();
						var values = new List<object>();
						var conn = GetConnection();
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
