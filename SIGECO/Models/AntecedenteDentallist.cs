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
		/// AntecedenteDental_List
		/// </summary>

		public static _AntecedenteDental_List AntecedenteDental_List {
			get => HttpData.Get<_AntecedenteDental_List>("AntecedenteDental_List");
			set => HttpData["AntecedenteDental_List"] = value;
		}

		/// <summary>
		/// Page class for AntecedenteDental
		/// </summary>

		public class _AntecedenteDental_List : _AntecedenteDental_ListBase
		{

			// Construtor
			public _AntecedenteDental_List(Controller controller = null) : base(controller) {
			}
		}

		/// <summary>
		/// Page base class
		/// </summary>

		public class _AntecedenteDental_ListBase : _AntecedenteDental, IAspNetMakerPage
		{

			// Page ID
			public string PageID = "list";

			// Project ID
			public string ProjectID = "{9B083C8B-EE2F-4356-BE8D-9A26D5707365}";

			// Table name
			public string TableName = "AntecedenteDental";

			// Page object name
			public string PageObjName = "AntecedenteDental_List";

			// Grid form hidden field names
			public string FormName = "fAntecedenteDentallist";
			public string FormActionName = "k_action";
			public string FormKeyName = "k_key";
			public string FormOldKeyName = "k_oldkey";
			public string FormBlankRowName = "k_blankrow";
			public string FormKeyCountName = "key_count";

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

			// Export URLs
			public string ExportPrintUrl = "";
			public string ExportHtmlUrl = "";
			public string ExportExcelUrl = "";
			public string ExportWordUrl = "";
			public string ExportXmlUrl = "";
			public string ExportCsvUrl = "";
			public string ExportPdfUrl = "";

			// Update URLs
			public string InlineAddUrl = "";
			public string GridAddUrl = "";
			public string GridEditUrl = "";
			public string MultiDeleteUrl = "";
			public string MultiUpdateUrl = "";

			// Custom export
			public bool ExportExcelCustom = false;
			public bool ExportWordCustom = false;
			public bool ExportPdfCustom = false;
			public bool ExportEmailCustom = false;

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
			public _AntecedenteDental_ListBase(Controller controller = null) { // DN
				if (controller != null)
					Controller = controller;

				// Initialize
				CurrentPage = this;

				// Language object
				Language = Language ?? new Lang();

				// Table object (AntecedenteDental)
				if (AntecedenteDental == null || AntecedenteDental is _AntecedenteDental)
					AntecedenteDental = this;

				// Initialize URLs
				ExportPrintUrl = PageUrl + "export=print";
				ExportExcelUrl = PageUrl + "export=excel";
				ExportWordUrl = PageUrl + "export=word";
				ExportHtmlUrl = PageUrl + "export=html";
				ExportXmlUrl = PageUrl + "export=xml";
				ExportCsvUrl = PageUrl + "export=csv";
				ExportPdfUrl = PageUrl + "export=pdf";
				AddUrl = "AntecedenteDentaladd";
				InlineAddUrl = PageUrl + "action=add";
				GridAddUrl = PageUrl + "action=gridadd";
				GridEditUrl = PageUrl + "action=gridedit";
				MultiDeleteUrl = "AntecedenteDentaldelete";
				MultiUpdateUrl = "AntecedenteDentalupdate";

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

				// List options
				ListOptions = new ListOptions { TableVar = TableVar };

				// Export options
				ExportOptions = new ListOptions { Tag = "div", TagClassName = "ew-export-option" };

				// Import options
				ImportOptions = new ListOptions { Tag = "div", TagClassName = "ew-import-option" };

				// Other options
				OtherOptions["addedit"] = new ListOptions { Tag = "div", TagClassName = "ew-add-edit-option" };
				OtherOptions["detail"] = new ListOptions { Tag = "div", TagClassName = "ew-detail-option" };
				OtherOptions["action"] = new ListOptions { Tag = "div", TagClassName = "ew-action-option" };

				// Filter options
				FilterOptions = new ListOptions { Tag = "div", TagClassName = "ew-filter-option fAntecedenteDentallistsrch" };

				// List actions
				ListActions = new ListActions();
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
						SaveDebugMessage();
						return Controller.LocalRedirect(AppPath(url));
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

			// Class properties
			public ListOptions ListOptions; // List options
			public ListOptions ExportOptions; // Export options
			public ListOptions SearchOptions; // Search options
			public ListOptionsDictionary OtherOptions = new ListOptionsDictionary(); // Other options
			public ListOptions FilterOptions; // Filter options
			public ListOptions ImportOptions; // Import options
			public ListActions ListActions; // List actions
			public int SelectedCount = 0;
			public int SelectedIndex = 0;
			public int DisplayRecords = 20; // Number of display records
			public int StartRecord;
			public int StopRecord;
			public int TotalRecords = -1;
			public int RecordRange = 10;
			public string PageSizes = ""; // Page sizes (comma separated)
			public Pager _pager;
			public bool AutoHidePager = Config.AutoHidePager;
			public bool AutoHidePageSizeSelector = Config.AutoHidePageSizeSelector;
			public string DefaultSearchWhere = ""; // Default search WHERE clause
			public string SearchWhere = ""; // Search WHERE clause
			public int RecordCount = 0; // Record count
			public int EditRowCount;
			public int StartRowCount = 1;
			public Dictionary<int, dynamic> Attributes = new Dictionary<int, dynamic>(); // Row attributes and cell attributes
			public object RowIndex = 0; // Row index
			public int KeyCount = 0; // Key count
			public string RowAction = ""; // Row action
			public string RowOldKey = ""; // Row old key (for copy)
			public string MultiColumnClass = "col-sm";
			public string MultiColumnEditClass = "w-100";
			public int MultiColumnCount = 12;
			public int MultiColumnEditCount = 12;
			public string DbMasterFilter = ""; // Master filter
			public string DbDetailFilter = ""; // Detail filter
			public bool MasterRecordExists;
			public string MultiSelectKey = "";
			public bool RestoreSearch = false;
			public SubPages DetailPages;
			public DbDataReader Recordset;
			public DbDataReader OldRecordset;

			// Pager
			public Pager Pager {
				get {
					_pager = _pager ?? new PrevNextPager(StartRecord, RecordsPerPage, TotalRecords, PageSizes, RecordRange, AutoHidePager, AutoHidePageSizeSelector);
					return _pager;
				}
			}

			/// <summary>
			/// Page run
			/// </summary>
			/// <returns>Page result</returns>

			public async Task<IActionResult> Run() {

				// Header
				Header(Config.Cache);

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
					if (!Security.CanList) {
						Security.SaveLastUrl();
						FailureMessage = DeniedMessage(); // Set no permission
						if (IsApi())
							return new JsonBoolResult(new { success = false, error = DeniedMessage(), version = Config.ProductVersion }, false);
						return Terminate(GetUrl("Index"));
					}
				}

				// Get export parameters
				string custom = "";
				if (!Empty(Param("export"))) {
					Export = Param("export");
					custom = Param("custom");
				} else if (IsPost()) {
					if (!Empty(Post("exporttype")))
						Export = Post("exporttype");
					custom = Post("custom");
				} else if (Get("cmd") == "json") {
					Export = Get("cmd");
				} else {
					ExportReturnUrl = CurrentUrl();
				}
				ExportFileName = TableVar; // Get export file, used in header

				// Get custom export parameters
				if (IsExport() && !Empty(custom)) {
					CustomExport = Export;
					Export = "print";
				}
				CustomExportType = CustomExport;
				ExportType = Export; // Get export parameter, used in header

				// Update Export URLs
				if (Config.UseExcelExtension)
					ExportExcelCustom = false;
				if (ExportExcelCustom)
					ExportExcelUrl += "&amp;custom=1";
				if (ExportWordCustom)
					ExportWordUrl += "&amp;custom=1";
				if (ExportPdfCustom)
					ExportPdfUrl += "&amp;custom=1";
				CurrentAction = Param("action"); // Set up current action

				// Get grid add count
				int gridaddcnt = Get<int>(Config.TableGridAddRowCount);
				if (gridaddcnt > 0)
					GridAddRowCount = gridaddcnt;

				// Set up list options
				await SetupListOptions();

				// Setup export options
				SetupExportOptions();
				nAntecedenteDentalID.Visible = false;
				nExpedienteID.SetVisibility();
				dFechaUltimaVisitaDentista.SetVisibility();
				sMotivoVisita.SetVisibility();
				sExperienciaAsistencial.SetVisibility();
				nTratamientoQuirurgico.Visible = false;
				nTratamientoRestauracion.Visible = false;
				nTratamientoPeridoncia.Visible = false;
				nTratamientoEndodoncia.Visible = false;
				nTratamientoOrtodoncia.Visible = false;
				nTratamientoProtesis.Visible = false;
				nColocadoAnestesia.Visible = false;
				nReaccionAlergicaAnestesia.Visible = false;
				sReaccionAlergicaAnestesia.Visible = false;
				sDescripcionTejidosBlandos.Visible = false;
				sHistoriaEnfermedadActual.Visible = false;
				nEstadoID.SetVisibility();
				dFechaCreacion.Visible = false;
				dFechaModificacion.Visible = false;
				HideFieldsForAddEdit();

				// Global Page Loading event
				Page_Loading();

				// Page Load event
				Page_Load();

				// Check token
				if (!await ValidPost())
					End(Language.Phrase("InvalidPostRequest"));

				// Create token
				CreateToken();

				// Setup other options
				SetupOtherOptions();

				// Set up custom action (compatible with old version)
				ListActions.Add(CustomActions);

				// Show checkbox column if multiple action
				if (ListActions.Items.Any(kvp => kvp.Value.Select == Config.ActionMultiple && kvp.Value.Allowed))
					ListOptions["checkbox"].Visible = true;

				// Set up lookup cache
				await SetupLookupOptions(nExpedienteID);
				await SetupLookupOptions(nEstadoID);

				// Search filters
				string srchBasic = ""; // Basic search filter
				string filter = "";

				// Get command
				Command = Get("cmd").ToLower();
				if (IsPageRequest) { // Validate request

					// Process list action first
					var result = await ProcessListAction();
					if (result != null) // Ajax request
						return result;

					// Handle reset command
					ResetCommand();

					// Set up Breadcrumb
					if (!IsExport())
						SetupBreadcrumb();

					// Hide list options
					if (IsExport()) {
						ListOptions.HideAllOptions(new List<string> {"sequence"});
						ListOptions.UseDropDownButton = false; // Disable drop down button
						ListOptions.UseButtonGroup = false; // Disable button group
					} else if (IsGridAdd || IsGridEdit) {
						ListOptions.HideAllOptions();
						ListOptions.UseDropDownButton = false; // Disable drop down button
						ListOptions.UseButtonGroup = false; // Disable button group
					}

					// Hide options
					if (IsExport() || !Empty(CurrentAction)) {
						ExportOptions.HideAllOptions();
						FilterOptions.HideAllOptions();
						ImportOptions.HideAllOptions();
					}

					// Hide other options
					if (IsExport()) {
						foreach (var (key, value) in OtherOptions)
							value.HideAllOptions();
					}

					// Get default search criteria
					AddFilter(ref DefaultSearchWhere, BasicSearchWhere(true));

					// Get basic search values
					LoadBasicSearchValues();

					// Process filter list
					var filterResult = await ProcessFilterList();
					if (filterResult != null) {

						// Clean output buffer
						if (!Config.Debug)
							Response.Clear();
						return Controller.Json(filterResult);
					}

					// Restore search parms from Session if not searching / reset / export
					if ((IsExport() || Command != "search" && Command != "reset" && Command != "resetall") && Command != "json" && CheckSearchParms())
						RestoreSearchParms();

					// Call Recordset SearchValidated event
					Recordset_SearchValidated();

					// Set up sorting order
					SetupSortOrder();

					// Get basic search criteria
					if (Empty(SearchError))
						srchBasic = BasicSearchWhere();
				}

				// Restore display records
				if (Command != "json" && (RecordsPerPage == -1 || RecordsPerPage > 0)) {
					DisplayRecords = RecordsPerPage; // Restore from Session
				} else {
					DisplayRecords = 20; // Load default
					RecordsPerPage = DisplayRecords; // Save default to session
				}

				// Load Sorting Order
				if (Command != "json")
					LoadSortOrder();

				// Load search default if no existing search criteria
				if (!CheckSearchParms()) {

					// Load basic search from default
					BasicSearch.LoadDefault();
					if (!Empty(BasicSearch.Keyword))
						srchBasic = BasicSearchWhere();
				}

				// Build search criteria
				AddFilter(ref SearchWhere, srchBasic);

				// Call Recordset_Searching event
				Recordset_Searching(ref SearchWhere);

				// Save search criteria
				if (Command == "search" && !RestoreSearch) {
					SessionSearchWhere = SearchWhere; // Save to Session // *** rename as SessionSearchWhere property
					StartRecord = 1; // Reset start record counter
					StartRecordNumber = StartRecord;
				} else if (Command != "json") {
					SearchWhere = SessionSearchWhere;
				}

				// Build filter
				filter = "";
				if (!Security.CanList)
					filter = "(0=1)"; // Filter all records
				AddFilter(ref filter, DbDetailFilter);
				AddFilter(ref filter, SearchWhere);

				// Set up filter
				if (Command == "json") {
					UseSessionForListSql = false; // Do not use session for ListSql
					CurrentFilter = filter;
				} else {
					SessionWhere = filter;
					CurrentFilter = "";
				}

				// Export data only // DN
				if (Empty(CustomExport) && Config.Export.ContainsKey(Export)) {
					return await ExportData();
				} else if (!Empty(CustomExport) && CustomExport == Export && Config.Export.ContainsKey(CustomExport)) {
					return await ExportView();
				}
				if (IsGridAdd) {
					CurrentFilter = "0=1";
					StartRecord = 1;
					DisplayRecords = GridAddRowCount;
					TotalRecords = DisplayRecords;
					StopRecord = DisplayRecords;
				} else {
					TotalRecords = await ListRecordCount();
					StopRecord = DisplayRecords;
					StartRecord = 1;
				if (DisplayRecords <= 0 || (IsExport() && ExportAll)) // Display all records
					DisplayRecords = TotalRecords;
				if (!(IsExport() && ExportAll)) // Set up start record position
					SetupStartRec();

				// Recordset
				bool selectLimit = UseSelectLimit;
				if (selectLimit)
					Recordset = await LoadRecordset(StartRecord - 1, DisplayRecords);

				// Set no record found message
				if (Empty(CurrentAction) && TotalRecords == 0) {
					if (!Security.CanList)
						WarningMessage = DeniedMessage();
					if (SearchWhere == "0=101")
						WarningMessage = Language.Phrase("EnterSearchCriteria");
					else
						WarningMessage = Language.Phrase("NoRecord");
				}
				}

				// Search options
				SetupSearchOptions();

				// Normal return
				if (IsApi()) {
					if (!Connection.SelectOffset) // DN
						for (var i = 1; i <= StartRecord - 1; i++) // Move to first record
							await Recordset.ReadAsync();
					using (Recordset) {
						return Controller.Json(new Dictionary<string, object> { {"success", true}, {TableVar, await GetRecordsFromRecordset(Recordset)}, {"totalRecordCount", TotalRecords}, {"version", Config.ProductVersion} });
					}
				}
				return PageResult();
			}

			// Build filter for all keys
			protected string BuildKeyFilter() {
				string wrkFilter = "";

				// Update row index and get row key
				int rowindex = 1;
				CurrentForm.Index = rowindex;
				string thisKey = CurrentForm.GetValue(FormKeyName);
				while (!Empty(thisKey)) {
					if (SetupKeyValues(thisKey)) {
						string filter = GetRecordFilter();
						if (!Empty(wrkFilter))
							wrkFilter += " OR ";
						wrkFilter += filter;
					} else {
						wrkFilter = "0=1";
						break;
					}

					// Update row index and get row key
					rowindex++; // next row
					CurrentForm.Index = rowindex;
					thisKey = CurrentForm.GetValue(FormKeyName);
				}
				return wrkFilter;
			}

			// Set up key values
			protected bool SetupKeyValues(string key) {
				var arKeyFlds = key.Split(Convert.ToChar(Config.CompositeKeySeparator));
				if (arKeyFlds.Length >= 1) {
					AntecedenteDental.nAntecedenteDentalID.FormValue = arKeyFlds[0];
					if (!IsNumeric(AntecedenteDental.nAntecedenteDentalID.FormValue))
						return false;
				}
				return true;
			}

			// Check if empty row
			public bool EmptyRow() => false;

			#pragma warning disable 162, 1998

			// Get list of filters
			public async Task<string> GetFilterList() {
				string filterList = "";

				// Initialize
				var filters = new JObject(); // DN
				filters.Merge(JObject.Parse(nExpedienteID.AdvancedSearch.ToJson())); // Field nExpedienteID
				filters.Merge(JObject.Parse(dFechaUltimaVisitaDentista.AdvancedSearch.ToJson())); // Field dFechaUltimaVisitaDentista
				filters.Merge(JObject.Parse(sMotivoVisita.AdvancedSearch.ToJson())); // Field sMotivoVisita
				filters.Merge(JObject.Parse(sExperienciaAsistencial.AdvancedSearch.ToJson())); // Field sExperienciaAsistencial
				filters.Merge(JObject.Parse(nTratamientoQuirurgico.AdvancedSearch.ToJson())); // Field nTratamientoQuirurgico
				filters.Merge(JObject.Parse(nTratamientoRestauracion.AdvancedSearch.ToJson())); // Field nTratamientoRestauracion
				filters.Merge(JObject.Parse(nTratamientoPeridoncia.AdvancedSearch.ToJson())); // Field nTratamientoPeridoncia
				filters.Merge(JObject.Parse(nTratamientoEndodoncia.AdvancedSearch.ToJson())); // Field nTratamientoEndodoncia
				filters.Merge(JObject.Parse(nTratamientoOrtodoncia.AdvancedSearch.ToJson())); // Field nTratamientoOrtodoncia
				filters.Merge(JObject.Parse(nTratamientoProtesis.AdvancedSearch.ToJson())); // Field nTratamientoProtesis
				filters.Merge(JObject.Parse(nColocadoAnestesia.AdvancedSearch.ToJson())); // Field nColocadoAnestesia
				filters.Merge(JObject.Parse(nReaccionAlergicaAnestesia.AdvancedSearch.ToJson())); // Field nReaccionAlergicaAnestesia
				filters.Merge(JObject.Parse(sReaccionAlergicaAnestesia.AdvancedSearch.ToJson())); // Field sReaccionAlergicaAnestesia
				filters.Merge(JObject.Parse(sDescripcionTejidosBlandos.AdvancedSearch.ToJson())); // Field sDescripcionTejidosBlandos
				filters.Merge(JObject.Parse(sHistoriaEnfermedadActual.AdvancedSearch.ToJson())); // Field sHistoriaEnfermedadActual
				filters.Merge(JObject.Parse(nEstadoID.AdvancedSearch.ToJson())); // Field nEstadoID
				filters.Merge(JObject.Parse(AntecedenteDental.BasicSearch.ToJson()));

				// Return filter list in JSON
				if (filters.HasValues)
					filterList = "\"data\":" + filters.ToString();
				return (filterList != "") ? "{" + filterList + "}" : "null";
			}

			// Process filter list
			protected async Task<object> ProcessFilterList() {
				if (Post("cmd") == "resetfilter") {
					RestoreFilterList();
				}
				return null;
			}

			#pragma warning restore 162, 1998

			// Restore list of filters
			protected bool RestoreFilterList() {

				// Return if not reset filter
				if (Post("cmd") != "resetfilter")
					return false;
				Dictionary<string, string> filter = JsonConvert.DeserializeObject<Dictionary<string, string>>(Post("filter"));
				Command = "search";
				string sv;

				// Field nExpedienteID
				if (filter.TryGetValue("x_nExpedienteID", out sv)) {
					nExpedienteID.AdvancedSearch.SearchValue = sv;
					nExpedienteID.AdvancedSearch.SearchOperator = filter["z_nExpedienteID"];
					nExpedienteID.AdvancedSearch.SearchCondition = filter["v_nExpedienteID"];
					nExpedienteID.AdvancedSearch.SearchValue2 = filter["y_nExpedienteID"];
					nExpedienteID.AdvancedSearch.SearchOperator2 = filter["w_nExpedienteID"];
					nExpedienteID.AdvancedSearch.Save();
				}

				// Field dFechaUltimaVisitaDentista
				if (filter.TryGetValue("x_dFechaUltimaVisitaDentista", out sv)) {
					dFechaUltimaVisitaDentista.AdvancedSearch.SearchValue = sv;
					dFechaUltimaVisitaDentista.AdvancedSearch.SearchOperator = filter["z_dFechaUltimaVisitaDentista"];
					dFechaUltimaVisitaDentista.AdvancedSearch.SearchCondition = filter["v_dFechaUltimaVisitaDentista"];
					dFechaUltimaVisitaDentista.AdvancedSearch.SearchValue2 = filter["y_dFechaUltimaVisitaDentista"];
					dFechaUltimaVisitaDentista.AdvancedSearch.SearchOperator2 = filter["w_dFechaUltimaVisitaDentista"];
					dFechaUltimaVisitaDentista.AdvancedSearch.Save();
				}

				// Field sMotivoVisita
				if (filter.TryGetValue("x_sMotivoVisita", out sv)) {
					sMotivoVisita.AdvancedSearch.SearchValue = sv;
					sMotivoVisita.AdvancedSearch.SearchOperator = filter["z_sMotivoVisita"];
					sMotivoVisita.AdvancedSearch.SearchCondition = filter["v_sMotivoVisita"];
					sMotivoVisita.AdvancedSearch.SearchValue2 = filter["y_sMotivoVisita"];
					sMotivoVisita.AdvancedSearch.SearchOperator2 = filter["w_sMotivoVisita"];
					sMotivoVisita.AdvancedSearch.Save();
				}

				// Field sExperienciaAsistencial
				if (filter.TryGetValue("x_sExperienciaAsistencial", out sv)) {
					sExperienciaAsistencial.AdvancedSearch.SearchValue = sv;
					sExperienciaAsistencial.AdvancedSearch.SearchOperator = filter["z_sExperienciaAsistencial"];
					sExperienciaAsistencial.AdvancedSearch.SearchCondition = filter["v_sExperienciaAsistencial"];
					sExperienciaAsistencial.AdvancedSearch.SearchValue2 = filter["y_sExperienciaAsistencial"];
					sExperienciaAsistencial.AdvancedSearch.SearchOperator2 = filter["w_sExperienciaAsistencial"];
					sExperienciaAsistencial.AdvancedSearch.Save();
				}

				// Field nTratamientoQuirurgico
				if (filter.TryGetValue("x_nTratamientoQuirurgico", out sv)) {
					nTratamientoQuirurgico.AdvancedSearch.SearchValue = sv;
					nTratamientoQuirurgico.AdvancedSearch.SearchOperator = filter["z_nTratamientoQuirurgico"];
					nTratamientoQuirurgico.AdvancedSearch.SearchCondition = filter["v_nTratamientoQuirurgico"];
					nTratamientoQuirurgico.AdvancedSearch.SearchValue2 = filter["y_nTratamientoQuirurgico"];
					nTratamientoQuirurgico.AdvancedSearch.SearchOperator2 = filter["w_nTratamientoQuirurgico"];
					nTratamientoQuirurgico.AdvancedSearch.Save();
				}

				// Field nTratamientoRestauracion
				if (filter.TryGetValue("x_nTratamientoRestauracion", out sv)) {
					nTratamientoRestauracion.AdvancedSearch.SearchValue = sv;
					nTratamientoRestauracion.AdvancedSearch.SearchOperator = filter["z_nTratamientoRestauracion"];
					nTratamientoRestauracion.AdvancedSearch.SearchCondition = filter["v_nTratamientoRestauracion"];
					nTratamientoRestauracion.AdvancedSearch.SearchValue2 = filter["y_nTratamientoRestauracion"];
					nTratamientoRestauracion.AdvancedSearch.SearchOperator2 = filter["w_nTratamientoRestauracion"];
					nTratamientoRestauracion.AdvancedSearch.Save();
				}

				// Field nTratamientoPeridoncia
				if (filter.TryGetValue("x_nTratamientoPeridoncia", out sv)) {
					nTratamientoPeridoncia.AdvancedSearch.SearchValue = sv;
					nTratamientoPeridoncia.AdvancedSearch.SearchOperator = filter["z_nTratamientoPeridoncia"];
					nTratamientoPeridoncia.AdvancedSearch.SearchCondition = filter["v_nTratamientoPeridoncia"];
					nTratamientoPeridoncia.AdvancedSearch.SearchValue2 = filter["y_nTratamientoPeridoncia"];
					nTratamientoPeridoncia.AdvancedSearch.SearchOperator2 = filter["w_nTratamientoPeridoncia"];
					nTratamientoPeridoncia.AdvancedSearch.Save();
				}

				// Field nTratamientoEndodoncia
				if (filter.TryGetValue("x_nTratamientoEndodoncia", out sv)) {
					nTratamientoEndodoncia.AdvancedSearch.SearchValue = sv;
					nTratamientoEndodoncia.AdvancedSearch.SearchOperator = filter["z_nTratamientoEndodoncia"];
					nTratamientoEndodoncia.AdvancedSearch.SearchCondition = filter["v_nTratamientoEndodoncia"];
					nTratamientoEndodoncia.AdvancedSearch.SearchValue2 = filter["y_nTratamientoEndodoncia"];
					nTratamientoEndodoncia.AdvancedSearch.SearchOperator2 = filter["w_nTratamientoEndodoncia"];
					nTratamientoEndodoncia.AdvancedSearch.Save();
				}

				// Field nTratamientoOrtodoncia
				if (filter.TryGetValue("x_nTratamientoOrtodoncia", out sv)) {
					nTratamientoOrtodoncia.AdvancedSearch.SearchValue = sv;
					nTratamientoOrtodoncia.AdvancedSearch.SearchOperator = filter["z_nTratamientoOrtodoncia"];
					nTratamientoOrtodoncia.AdvancedSearch.SearchCondition = filter["v_nTratamientoOrtodoncia"];
					nTratamientoOrtodoncia.AdvancedSearch.SearchValue2 = filter["y_nTratamientoOrtodoncia"];
					nTratamientoOrtodoncia.AdvancedSearch.SearchOperator2 = filter["w_nTratamientoOrtodoncia"];
					nTratamientoOrtodoncia.AdvancedSearch.Save();
				}

				// Field nTratamientoProtesis
				if (filter.TryGetValue("x_nTratamientoProtesis", out sv)) {
					nTratamientoProtesis.AdvancedSearch.SearchValue = sv;
					nTratamientoProtesis.AdvancedSearch.SearchOperator = filter["z_nTratamientoProtesis"];
					nTratamientoProtesis.AdvancedSearch.SearchCondition = filter["v_nTratamientoProtesis"];
					nTratamientoProtesis.AdvancedSearch.SearchValue2 = filter["y_nTratamientoProtesis"];
					nTratamientoProtesis.AdvancedSearch.SearchOperator2 = filter["w_nTratamientoProtesis"];
					nTratamientoProtesis.AdvancedSearch.Save();
				}

				// Field nColocadoAnestesia
				if (filter.TryGetValue("x_nColocadoAnestesia", out sv)) {
					nColocadoAnestesia.AdvancedSearch.SearchValue = sv;
					nColocadoAnestesia.AdvancedSearch.SearchOperator = filter["z_nColocadoAnestesia"];
					nColocadoAnestesia.AdvancedSearch.SearchCondition = filter["v_nColocadoAnestesia"];
					nColocadoAnestesia.AdvancedSearch.SearchValue2 = filter["y_nColocadoAnestesia"];
					nColocadoAnestesia.AdvancedSearch.SearchOperator2 = filter["w_nColocadoAnestesia"];
					nColocadoAnestesia.AdvancedSearch.Save();
				}

				// Field nReaccionAlergicaAnestesia
				if (filter.TryGetValue("x_nReaccionAlergicaAnestesia", out sv)) {
					nReaccionAlergicaAnestesia.AdvancedSearch.SearchValue = sv;
					nReaccionAlergicaAnestesia.AdvancedSearch.SearchOperator = filter["z_nReaccionAlergicaAnestesia"];
					nReaccionAlergicaAnestesia.AdvancedSearch.SearchCondition = filter["v_nReaccionAlergicaAnestesia"];
					nReaccionAlergicaAnestesia.AdvancedSearch.SearchValue2 = filter["y_nReaccionAlergicaAnestesia"];
					nReaccionAlergicaAnestesia.AdvancedSearch.SearchOperator2 = filter["w_nReaccionAlergicaAnestesia"];
					nReaccionAlergicaAnestesia.AdvancedSearch.Save();
				}

				// Field sReaccionAlergicaAnestesia
				if (filter.TryGetValue("x_sReaccionAlergicaAnestesia", out sv)) {
					sReaccionAlergicaAnestesia.AdvancedSearch.SearchValue = sv;
					sReaccionAlergicaAnestesia.AdvancedSearch.SearchOperator = filter["z_sReaccionAlergicaAnestesia"];
					sReaccionAlergicaAnestesia.AdvancedSearch.SearchCondition = filter["v_sReaccionAlergicaAnestesia"];
					sReaccionAlergicaAnestesia.AdvancedSearch.SearchValue2 = filter["y_sReaccionAlergicaAnestesia"];
					sReaccionAlergicaAnestesia.AdvancedSearch.SearchOperator2 = filter["w_sReaccionAlergicaAnestesia"];
					sReaccionAlergicaAnestesia.AdvancedSearch.Save();
				}

				// Field sDescripcionTejidosBlandos
				if (filter.TryGetValue("x_sDescripcionTejidosBlandos", out sv)) {
					sDescripcionTejidosBlandos.AdvancedSearch.SearchValue = sv;
					sDescripcionTejidosBlandos.AdvancedSearch.SearchOperator = filter["z_sDescripcionTejidosBlandos"];
					sDescripcionTejidosBlandos.AdvancedSearch.SearchCondition = filter["v_sDescripcionTejidosBlandos"];
					sDescripcionTejidosBlandos.AdvancedSearch.SearchValue2 = filter["y_sDescripcionTejidosBlandos"];
					sDescripcionTejidosBlandos.AdvancedSearch.SearchOperator2 = filter["w_sDescripcionTejidosBlandos"];
					sDescripcionTejidosBlandos.AdvancedSearch.Save();
				}

				// Field sHistoriaEnfermedadActual
				if (filter.TryGetValue("x_sHistoriaEnfermedadActual", out sv)) {
					sHistoriaEnfermedadActual.AdvancedSearch.SearchValue = sv;
					sHistoriaEnfermedadActual.AdvancedSearch.SearchOperator = filter["z_sHistoriaEnfermedadActual"];
					sHistoriaEnfermedadActual.AdvancedSearch.SearchCondition = filter["v_sHistoriaEnfermedadActual"];
					sHistoriaEnfermedadActual.AdvancedSearch.SearchValue2 = filter["y_sHistoriaEnfermedadActual"];
					sHistoriaEnfermedadActual.AdvancedSearch.SearchOperator2 = filter["w_sHistoriaEnfermedadActual"];
					sHistoriaEnfermedadActual.AdvancedSearch.Save();
				}

				// Field nEstadoID
				if (filter.TryGetValue("x_nEstadoID", out sv)) {
					nEstadoID.AdvancedSearch.SearchValue = sv;
					nEstadoID.AdvancedSearch.SearchOperator = filter["z_nEstadoID"];
					nEstadoID.AdvancedSearch.SearchCondition = filter["v_nEstadoID"];
					nEstadoID.AdvancedSearch.SearchValue2 = filter["y_nEstadoID"];
					nEstadoID.AdvancedSearch.SearchOperator2 = filter["w_nEstadoID"];
					nEstadoID.AdvancedSearch.Save();
				}
				if (filter.TryGetValue(Config.TableBasicSearch, out string keyword))
					BasicSearch.SessionKeyword = keyword;
				if (filter.TryGetValue(Config.TableBasicSearchType, out string type))
					BasicSearch.SessionType = type;
				return true;
			}

			// Return basic search SQL
			protected string BasicSearchSql(List<string> keywords, string type) {
				string where = "";
				BuildBasicSearchSql(ref where, sMotivoVisita, keywords, type);
				BuildBasicSearchSql(ref where, sExperienciaAsistencial, keywords, type);
				BuildBasicSearchSql(ref where, sReaccionAlergicaAnestesia, keywords, type);
				BuildBasicSearchSql(ref where, sDescripcionTejidosBlandos, keywords, type);
				BuildBasicSearchSql(ref where, sHistoriaEnfermedadActual, keywords, type);
				return where;
			}

			// Build basic search SQL
			protected void BuildBasicSearchSql(ref string where, DbField fld, List<string> keywords, string type) {
				string defCond = (type == "OR") ? "OR" : "AND";
				var sqls = new List<string>(); // List for SQL parts
				var conds = new List<string>(); // List for search conditions
				int cnt = keywords.Count;
				int j = 0; // Number of SQL parts
				for (int i = 0; i < cnt; i++) {
					string keyword = keywords[i];
					keyword = keyword.Trim();
					string[] ar;
					if (!Empty(Config.BasicSearchIgnorePattern)) {
						keyword = Regex.Replace(keyword, Config.BasicSearchIgnorePattern, "\\");
						ar = keyword.Split('\\');
					} else {
						ar = new string[] { keyword };
					}
					foreach (var kw in ar) {
						if (!Empty(kw)) {
							string wrk = "";
							if (kw == "OR" && type == "") {
								if (j > 0)
									conds[j - 1] = "OR";
							} else if (kw == Config.NullValue) {
								wrk = fld.Expression + " IS NULL";
							} else if (kw == Config.NotNullValue) {
								wrk = fld.Expression + " IS NOT NULL";
							} else if (fld.IsVirtual) {
								wrk = fld.VirtualExpression + Like(QuotedValue("%" + kw + "%", Config.DataTypeString, DbId), DbId);
							} else if (fld.DataType != Config.DataTypeNumber || IsNumeric(kw)) {
								wrk = fld.BasicSearchExpression + Like(QuotedValue("%" + kw + "%", Config.DataTypeString, DbId), DbId);
							}
							if (!Empty(wrk)) {
								sqls.Add(wrk); // DN
								conds.Add(defCond); // DN
								j++;
							}
						}
					}
				}
				cnt = sqls.Count;
				bool quoted = false;
				string sql = "";
				if (cnt > 0) {
					for (int i = 0; i < cnt - 1; i++) {
						if (conds[i] == "OR") {
							if (!quoted)
								sql += "(";
							quoted = true;
						}
						sql += sqls[i];
						if (quoted && conds[i] != "OR") {
							sql += ")";
							quoted = false;
						}
						sql += " " + conds[i] + " ";
					}
					sql += sqls[cnt - 1];
					if (quoted)
						sql += ")";
				}
				if (!Empty(sql)) {
					if (!Empty(where))
						where += " OR ";
					where += "(" + sql + ")";
				}
			}

			// Return basic search WHERE clause based on search keyword and type
			protected string BasicSearchWhere(bool def = false) {
				string searchStr = "";
				if (!Security.CanSearch)
					return "";
				string searchKeyword = def ? BasicSearch.KeywordDefault : BasicSearch.Keyword;
				string searchType = def ? BasicSearch.TypeDefault : BasicSearch.Type;

				// Get search SQL
				if (!Empty(searchKeyword)) {
					var ar = BasicSearch.KeywordList(def);
					if ((searchType == "OR" || searchType == "AND") && ConvertToBool(BasicSearch.BasicSearchAnyFields)) {
						foreach (var keyword in ar) {
							if (keyword != "") {
								if (searchStr != "")
									searchStr += " " + searchType + " ";
								searchStr += "(" + BasicSearchSql(new List<string> { keyword }, searchType) + ")";
							}
						}
					} else {
						searchStr = BasicSearchSql(ar, searchType);
					}
					if (!def && (new List<string> {"", "reset", "resetall"}).Contains(Command))
						Command = "search";
				}
				if (!def && Command == "search") {
					BasicSearch.SessionKeyword = searchKeyword;
					BasicSearch.SessionType = searchType;
				}
				return searchStr;
			}

			// Check if search parm exists
			protected bool CheckSearchParms() {

				// Check basic search
				if (BasicSearch.IssetSession)
					return true;
				return false;
			}

			// Clear all search parameters
			protected void ResetSearchParms() {
				SearchWhere = "";
				SessionSearchWhere = SearchWhere;

				// Clear basic search parameters
				ResetBasicSearchParms();
			}

			// Load advanced search default values
			protected bool LoadAdvancedSearchDefault() {
				return false;
			}

			// Clear all basic search parameters
			protected void ResetBasicSearchParms() {
				BasicSearch.UnsetSession();
			}

			// Restore all search parameters
			protected void RestoreSearchParms() {
				RestoreSearch = true;

				// Restore basic search values
				BasicSearch.Load();
			}

			// Set up sort parameters
			protected void SetupSortOrder() {

				// Check for "order" parameter
				if (!Empty(Get("order"))) {
					CurrentOrder = Get("order");
					CurrentOrderType = Get("ordertype");
					UpdateSort(nExpedienteID); // nExpedienteID
					UpdateSort(dFechaUltimaVisitaDentista); // dFechaUltimaVisitaDentista
					UpdateSort(sMotivoVisita); // sMotivoVisita
					UpdateSort(sExperienciaAsistencial); // sExperienciaAsistencial
					UpdateSort(nEstadoID); // nEstadoID
					StartRecordNumber = 1; // Reset start position
				}
			}

			// Load sort order parameters
			protected void LoadSortOrder() {
				string orderBy = SessionOrderBy; // Get Order By from Session
				if (Empty(orderBy)) {
					if (!Empty(SqlOrderBy)) {
						orderBy = SqlOrderBy;
						SessionOrderBy = orderBy;
					}
				}
			}

			// Reset command
			// cmd=reset (Reset search parameters)
			// cmd=resetall (Reset search and master/detail parameters)
			// cmd=resetsort (Reset sort parameters)

			protected void ResetCommand() {

				// Get reset cmd
				if (Command.ToLower().StartsWith("reset")) {

					// Reset search criteria
					if (SameText(Command, "reset") || SameText(Command, "resetall"))
						ResetSearchParms();

					// Reset sorting order
					if (SameText(Command, "resetsort")) {
						string orderBy = "";
						SessionOrderBy = orderBy;
						nExpedienteID.Sort = "";
						dFechaUltimaVisitaDentista.Sort = "";
						sMotivoVisita.Sort = "";
						sExperienciaAsistencial.Sort = "";
						nEstadoID.Sort = "";
					}

					// Reset start position
					StartRecord = 1;
					StartRecordNumber = StartRecord;
				}
			}

			#pragma warning disable 1998

			// Set up list options
			protected async Task SetupListOptions() {
				ListOption item;

				// Add group option item
				item = ListOptions.Add(ListOptions.GroupOptionName);
				item.Body = "";
				item.OnLeft = true;
				item.Visible = false;

				// "view"
				item = ListOptions.Add("view");
				item.CssClass = "text-nowrap";
				item.Visible = Security.CanView;
				item.OnLeft = true;

				// "edit"
				item = ListOptions.Add("edit");
				item.CssClass = "text-nowrap";
				item.Visible = Security.CanEdit;
				item.OnLeft = true;

				// "copy"
				item = ListOptions.Add("copy");
				item.CssClass = "text-nowrap";
				item.Visible = Security.CanAdd;
				item.OnLeft = true;

				// "delete"
				item = ListOptions.Add("delete");
				item.CssClass = "text-nowrap";
				item.Visible = Security.CanDelete;
				item.OnLeft = true;

				// List actions
				item = ListOptions.Add("listactions");
				item.CssClass = "text-nowrap";
				item.OnLeft = true;
				item.Visible = false;
				item.ShowInButtonGroup = false;
				item.ShowInDropDown = false;

				// "checkbox"
				item = ListOptions.Add("checkbox");
				item.CssStyle = "white-space: nowrap; text-align: center; vertical-align: middle; margin: 0px;";
				item.Visible = false;
				item.OnLeft = true;
				item.Header = "<input type=\"checkbox\" name=\"key\" id=\"key\" onclick=\"ew.selectAllKey(this);\">";
				item.MoveTo(0);
				item.ShowInDropDown = false;
				item.ShowInButtonGroup = false;

				// Drop down button for ListOptions
				ListOptions.UseDropDownButton = false;
				ListOptions.DropDownButtonPhrase = Language.Phrase("ButtonListOptions");
				ListOptions.UseButtonGroup = false;
				if (ListOptions.UseButtonGroup && IsMobile())
					ListOptions.UseDropDownButton = true;
				ListOptions.ButtonClass = ""; // Class for button group

				// Call ListOptions_Load event
				ListOptions_Load();
				SetupListOptionsExt();
				item = ListOptions[ListOptions.GroupOptionName];
				item.Visible = ListOptions.GroupOptionVisible;
			}

			#pragma warning restore 1998

			// Render list options

			#pragma warning disable 168, 219, 1998

			public async Task RenderListOptions() {
				ListOption listOption;
				var isVisible = false; // DN
				ListOptions.LoadDefault();

				// Call ListOptions_Rendering event
				ListOptions_Rendering();

				// "view"
				listOption = ListOptions["view"];
				string viewcaption = HtmlTitle(Language.Phrase("ViewLink"));
				isVisible = Security.CanView;
				if (isVisible) {
					listOption.Body = "<a class=\"ew-row-link ew-view\" title=\"" + viewcaption + "\" data-caption=\"" + viewcaption + "\" href=\"" + HtmlEncode(AppPath(ViewUrl)) + "\">" + Language.Phrase("ViewLink") + "</a>";
				} else {
					listOption.Body = "";
				}

				// "edit"
				listOption = ListOptions["edit"];
				string editcaption = HtmlTitle(Language.Phrase("EditLink"));
				isVisible = Security.CanEdit;
				if (isVisible) {
					listOption.Body = "<a class=\"ew-row-link ew-edit\" title=\"" + editcaption + "\" data-caption=\"" + editcaption + "\" href=\"" + HtmlEncode(AppPath(EditUrl)) + "\">" + Language.Phrase("EditLink") + "</a>";
				} else {
					listOption.Body = "";
				}

				// "copy"
				listOption = ListOptions["copy"];
				string copycaption = HtmlTitle(Language.Phrase("CopyLink"));
				isVisible = Security.CanAdd;
				if (isVisible) {
					listOption.Body = "<a class=\"ew-row-link ew-copy\" title=\"" + copycaption + "\" data-caption=\"" + copycaption + "\" href=\"" + HtmlEncode(AppPath(CopyUrl)) + "\">" + Language.Phrase("CopyLink") + "</a>";
				} else {
					listOption.Body = "";
				}

				// "delete"
				listOption = ListOptions["delete"];
				isVisible = Security.CanDelete;
				if (isVisible)
					listOption.Body = "<a class=\"ew-row-link ew-delete\"" + "" + " title=\"" + HtmlTitle(Language.Phrase("DeleteLink")) + "\" data-caption=\"" + HtmlTitle(Language.Phrase("DeleteLink")) + "\" href=\"" + HtmlEncode(AppPath(DeleteUrl)) + "\">" + Language.Phrase("DeleteLink") + "</a>";
				else
					listOption.Body = "";

				// Set up list action buttons
				listOption = ListOptions["listactions"];
				if (listOption != null && !IsExport() && CurrentAction == "") {
					string body = "";
					var links = new List<string>();
					foreach (var (key, act) in ListActions.Items) {
						if (act.Select == Config.ActionSingle && act.Allowed) {
							var action = act.Action;
							string caption = act.Caption;
							var icon = (act.Icon != "") ? "<i class=\"" + HtmlEncode(act.Icon.Replace(" ew-icon", "")) + "\" data-caption=\"" + HtmlTitle(caption) + "\"></i> " : "";
							links.Add("<li><a class=\"dropdown-item ew-action ew-list-action\" data-action=\"" + HtmlEncode(action) + "\" data-caption=\"" + HtmlTitle(caption) + "\" href=\"\" onclick=\"ew.submitAction(event,jQuery.extend({key:" + KeyToJson() + "}," + act.ToJson(true) + ")); return false;\">" + icon + act.Caption + "</a></li>");
							if (links.Count == 1) // Single button
								body = "<a class=\"ew-action ew-list-action\" data-action=\"" + HtmlEncode(action) + "\" title=\"" + HtmlTitle(caption) + "\" data-caption=\"" + HtmlTitle(caption) + "\" href=\"\" onclick=\"ew.submitAction(event,jQuery.extend({key:" + KeyToJson() + "}," + act.ToJson(true) + ")); return false;\">" + Language.Phrase("ListActionButton") + "</a>";
						}
					}
					if (links.Count > 1) { // More than one buttons, use dropdown
						body = "<button class=\"dropdown-toggle btn btn-default ew-actions\" title=\"" + HtmlTitle(Language.Phrase("ListActionButton")) + "\" data-toggle=\"dropdown\">" + Language.Phrase("ListActionButton") + "</button>";
						string content = links.Aggregate("", (result, link) => result + "<li>" + link + "</li>");
						body += "<ul class=\"dropdown-menu" + (listOption.OnLeft ? "" : " dropdown-menu-right") + "\">" + content + "</ul>";
						body = "<div class=\"btn-group btn-group-sm\">" + body + "</div>";
					}
					if (links.Count > 0) {
						listOption.Body = body;
						listOption.Visible = true;
					}
				}

				// "checkbox2"
				listOption = ListOptions["checkbox"];
				listOption.Body = "<input type=\"checkbox\" name=\"key_m\" class=\"ew-multi-select\" value=\"" + HtmlEncode(nAntecedenteDentalID.CurrentValue) + "\" onclick=\"ew.clickMultiCheckbox(event);\">";
				RenderListOptionsExt();

				// Call ListOptions_Rendered event
				ListOptions_Rendered();
			}

			// Set up other options
			protected void SetupOtherOptions() {
				ListOptions option;
				ListOption item;
				var options = OtherOptions;
				option = options["addedit"];

				// Add
				item = option.Add("add");
				string addcaption = HtmlTitle(Language.Phrase("AddLink"));
				item.Body = "<a class=\"ew-add-edit ew-add\" title=\"" + addcaption + "\" data-caption=\"" + addcaption + "\" href=\"" + HtmlEncode(AppPath(AddUrl)) + "\">" + Language.Phrase("AddLink") + "</a>";
				item.Visible = (AddUrl != "" && Security.CanAdd);
				option = options["action"];

				// Set up options default
				foreach (var (key, opt) in options) {
					opt.UseDropDownButton = false;
					opt.UseButtonGroup = true;
					opt.ButtonClass = ""; // Class for button group
					item = opt.Add(opt.GroupOptionName);
					item.Body = "";
					item.Visible = false;
				}
				options["addedit"].DropDownButtonPhrase = Language.Phrase("ButtonAddEdit");
				options["detail"].DropDownButtonPhrase = Language.Phrase("ButtonDetails");
				options["action"].DropDownButtonPhrase = Language.Phrase("ButtonActions");

				// Filter button
				item = FilterOptions.Add("savecurrentfilter");
				item.Body = "<a class=\"ew-save-filter\" data-form=\"fAntecedenteDentallistsrch\" href=\"#\">" + Language.Phrase("SaveCurrentFilter") + "</a>";
				item.Visible = true;
				item = FilterOptions.Add("deletefilter");
				item.Body = "<a class=\"ew-delete-filter\" data-form=\"fAntecedenteDentallistsrch\" href=\"#\">" + Language.Phrase("DeleteFilter") + "</a>";
				item.Visible = true;
				FilterOptions.UseDropDownButton = true;
				FilterOptions.UseButtonGroup = !FilterOptions.UseDropDownButton;
				FilterOptions.DropDownButtonPhrase = Language.Phrase("Filters");

				// Add group option item
				item = FilterOptions.Add(FilterOptions.GroupOptionName);
				item.Body = "";
				item.Visible = false;
			}

			// Render other options
			public void RenderOtherOptions() {
				ListOptions option;
				ListOption item;
				var options = OtherOptions;
					option = options["action"];

					// Set up list action buttons
					foreach (var (key, act) in ListActions.Items.Where(kvp => kvp.Value.Select == Config.ActionMultiple)) {
						item = option.Add("custom_" + act.Action);
						string caption = act.Caption;
						var icon = (act.Icon != "") ? "<i class=\"" + HtmlEncode(act.Icon) + "\" data-caption=\"" + HtmlEncode(caption) + "\"></i> " + caption : caption;
						item.Body = "<a class=\"ew-action ew-list-action\" title=\"" + HtmlEncode(caption) + "\" data-caption=\"" + HtmlEncode(caption) + "\" href=\"\" onclick=\"ew.submitAction(event,jQuery.extend({f:document.fAntecedenteDentallist}," + act.ToJson(true) + ")); return false;\">" + icon + "</a>";
						item.Visible = act.Allowed;
					}

					// Hide grid edit and other options
					if (TotalRecords <= 0) {
						option = options["addedit"];
						item = option["gridedit"];
						if (item != null)
							item.Visible = false;
						option = options["action"];
						option.HideAllOptions();
					}
			}

			// Process list action
			public async Task<IActionResult> ProcessListAction() {
				string filter = GetFilterFromRecordKeys();
				string userAction = Post("useraction");
				if (filter != "" && userAction != "") {

					// Check permission first
					var actionCaption = userAction;
					foreach (var (key, act) in ListActions.Items) {
						if (SameString(key, userAction)) {
							actionCaption = act.Caption;
							if (!act.Allowed) {
								string errmsg = Language.Phrase("CustomActionNotAllowed").Replace("%s", actionCaption);
								if (Post("ajax") == userAction) // Ajax
									return Controller.Content("<p class=\"text-danger\">" + errmsg + "</p>", "text/plain", Encoding.UTF8);
								else
									FailureMessage = errmsg;
								return null;
							}
						}
					}
					CurrentFilter = filter;
					string sql = CurrentSql;
					var rsuser = await Connection.GetRowsAsync(sql);
					CurrentAction = userAction;

					// Call row custom action event
					if (rsuser != null) {
						Connection.BeginTrans();
						bool processed = true;
						SelectedCount = rsuser.Count();
						SelectedIndex = 0;
						foreach (var row in rsuser) {
							SelectedIndex++;
							processed = Row_CustomAction(userAction, row);
							if (!processed)
								break;
						}
						if (processed) {
							Connection.CommitTrans(); // Commit the changes
							if (Empty(SuccessMessage))
								SuccessMessage = Language.Phrase("CustomActionCompleted").Replace("%s", actionCaption); // Set up success message
							} else {
								Connection.RollbackTrans(); // Rollback changes

							// Set up error message
							if (!Empty(SuccessMessage) || !Empty(FailureMessage)) {

								// Use the message, do nothing
							} else if (!Empty(CancelMessage)) {
								FailureMessage = CancelMessage;
								CancelMessage = "";
							} else {
								FailureMessage = Language.Phrase("CustomActionFailed").Replace("%s", actionCaption);
							}
						}
					}
					CurrentAction = ""; // Clear action
					if (Post("ajax") == userAction) { // Ajax
						if (ActionResult != null) // Action result set by Row_CustomAction // DN
							return ActionResult;
						string msg = "";
						if (SuccessMessage != "") {
							msg = "<p class=\"text-success\">" + SuccessMessage + "</p>";
							ClearSuccessMessage(); // Clear message
						}
						if (FailureMessage != "") {
							msg = "<p class=\"text-danger\">" + FailureMessage + "</p>";
							ClearFailureMessage(); // Clear message
						}
						if (!Empty(msg))
							return Controller.Content(msg, "text/plain", Encoding.UTF8);
					}
				}
				return null; // Not ajax request
			}

			// Set up search options
			protected void SetupSearchOptions() {
				ListOption item;
				SearchOptions = new ListOptions();
				SearchOptions.Tag = "div";
				SearchOptions.TagClassName = "ew-search-option";

				// Search button
				item = SearchOptions.Add("searchtoggle");
				var searchToggleClass = !Empty(SearchWhere) ? " active" : " active";
				item.Body = "<button type=\"button\" class=\"btn btn-default ew-search-toggle" + searchToggleClass + "\" title=\"" + Language.Phrase("SearchPanel") + "\" data-caption=\"" + Language.Phrase("SearchPanel") + "\" data-toggle=\"button\" data-form=\"fAntecedenteDentallistsrch\">" + Language.Phrase("SearchLink") + "</button>";
				item.Visible = true;

				// Show all button
				item = SearchOptions.Add("showall");
				item.Body = "<a class=\"btn btn-default ew-show-all\" title=\"" + Language.Phrase("ShowAll") + "\" data-caption=\"" + Language.Phrase("ShowAll") + "\" href=\"" + AppPath(PageUrl) + "cmd=reset\">" + Language.Phrase("ShowAllBtn") + "</a>";
				item.Visible = (SearchWhere != DefaultSearchWhere && SearchWhere != "0=101");

				// Button group for search
				SearchOptions.UseDropDownButton = false;
				SearchOptions.UseButtonGroup = true;
				SearchOptions.DropDownButtonPhrase = Language.Phrase("ButtonSearch");

				// Add group option item
				item = SearchOptions.Add(SearchOptions.GroupOptionName);
				item.Body = "";
				item.Visible = false;

				// Hide search options
				if (IsExport() || !Empty(CurrentAction))
					SearchOptions.HideAllOptions();
				if (!Security.CanSearch) {
					SearchOptions.HideAllOptions();
					FilterOptions.HideAllOptions();
				}
			}

			// Set up list options
			protected void SetupListOptionsExt() {
			}

			// Render list options
			protected void RenderListOptionsExt() {
			}

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

			// Load basic search values // DN
			protected void LoadBasicSearchValues() {
				if (Query.TryGetValue(Config.TableBasicSearch, out StringValues keyword))
					BasicSearch.Keyword = keyword;
				if (!Empty(BasicSearch.Keyword) && Empty(Command))
					Command = "search";
				if (Query.TryGetValue(Config.TableBasicSearchType, out StringValues type))
					BasicSearch.Type = type;
			}

			// Load recordset // DN
			public async Task<DbDataReader> LoadRecordset(int offset = -1, int rowcnt = -1) {

				// Load list page SQL
				string sql = ListSql;

				// Load recordset (Recordset_Selected event not supported) // DN
				return await Connection.SelectLimit(sql, rowcnt, offset, !Empty(OrderBy) || !Empty(SessionOrderBy));
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
				var row = new Dictionary<string, object>();
				row.Add("nAntecedenteDentalID", System.DBNull.Value);
				row.Add("nExpedienteID", System.DBNull.Value);
				row.Add("dFechaUltimaVisitaDentista", System.DBNull.Value);
				row.Add("sMotivoVisita", System.DBNull.Value);
				row.Add("sExperienciaAsistencial", System.DBNull.Value);
				row.Add("nTratamientoQuirurgico", System.DBNull.Value);
				row.Add("nTratamientoRestauracion", System.DBNull.Value);
				row.Add("nTratamientoPeridoncia", System.DBNull.Value);
				row.Add("nTratamientoEndodoncia", System.DBNull.Value);
				row.Add("nTratamientoOrtodoncia", System.DBNull.Value);
				row.Add("nTratamientoProtesis", System.DBNull.Value);
				row.Add("nColocadoAnestesia", System.DBNull.Value);
				row.Add("nReaccionAlergicaAnestesia", System.DBNull.Value);
				row.Add("sReaccionAlergicaAnestesia", System.DBNull.Value);
				row.Add("sDescripcionTejidosBlandos", System.DBNull.Value);
				row.Add("sHistoriaEnfermedadActual", System.DBNull.Value);
				row.Add("nEstadoID", System.DBNull.Value);
				row.Add("dFechaCreacion", System.DBNull.Value);
				row.Add("dFechaModificacion", System.DBNull.Value);
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

				nAntecedenteDentalID.CellCssStyle = "white-space: nowrap;";

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

				dFechaCreacion.CellCssStyle = "white-space: nowrap;";

				// dFechaModificacion
				dFechaModificacion.CellCssStyle = "white-space: nowrap;";
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

					// nEstadoID
					nEstadoID.HrefValue = "";
					nEstadoID.TooltipValue = "";
				}

				// Call Row Rendered event
				if (RowType != Config.RowTypeAggregateInit)
					Row_Rendered();
			}

			#pragma warning restore 1998

			// Save data to memory cache
			public void SetCache<T>(string key, T value, int span) => Cache.Set<T>(key, value, new MemoryCacheEntryOptions()
				.SetSlidingExpiration(TimeSpan.FromMilliseconds(span))); // Keep in cache for this time, reset time if accessed

			// Gete data from memory cache
			public void GetCache<T>(string key) => Cache.Get<T>(key);

			// Get export HTML tag
			protected string GetExportTag(string type, bool custom = false) {
				if (SameText(type, "excel")) {
					if (custom)
						return "<a href=\"javascript:void(0);\" class=\"ew-export-link ew-excel\" title=\"" + HtmlEncode(Language.Phrase("ExportToExcelText")) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToExcelText")) + "\" onclick=\"ew.export(document.fAntecedenteDentallist,'" + AppPath(ExportExcelUrl) + "','excel',true);\">" + Language.Phrase("ExportToExcel") + "</a>";
					else
						return "<a href=\"" + AppPath(ExportExcelUrl) + "\" class=\"ew-export-link ew-excel\" title=\"" + HtmlEncode(Language.Phrase("ExportToExcelText")) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToExcelText")) + "\">" + Language.Phrase("ExportToExcel") + "</a>";
				} else if (SameText(type, "word")) {
					if (custom)
						return "<a href=\"javascript:void(0);\" class=\"ew-export-link ew-word\" title=\"" + HtmlEncode(Language.Phrase("ExportToWordText")) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToWordText")) + "\" onclick=\"ew.export(document.fAntecedenteDentallist,'" + AppPath(ExportWordUrl) + "','word',true);\">" + Language.Phrase("ExportToWord") + "</a>";
					else
						return "<a href=\"" + AppPath(ExportWordUrl) + "\" class=\"ew-export-link ew-word\" title=\"" + HtmlEncode(Language.Phrase("ExportToWordText")) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToWordText")) + "\">" + Language.Phrase("ExportToWord") + "</a>";
				} else if (SameText(type, "pdf")) {
					if (custom)
						return "<a href=\"javascript:void(0);\" class=\"ew-export-link ew-pdf\" title=\"" + HtmlEncode(Language.Phrase("ExportToPDFText")) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToPDFText")) + "\" onclick=\"ew.export(document.fAntecedenteDentallist,'" + AppPath(ExportPdfUrl) + "','pdf',true);\">" + Language.Phrase("ExportToPDF") + "</a>";
					else
						return "<a href=\"" + AppPath(ExportPdfUrl) + "\" class=\"ew-export-link ew-pdf\" title=\"" + HtmlEncode(Language.Phrase("ExportToPDFText")) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToPDFText")) + "\">" + Language.Phrase("ExportToPDF") + "</a>";
				} else if (SameText(type, "html")) {
					return "<a href=\"" + AppPath(ExportHtmlUrl) + "\" class=\"ew-export-link ew-html\" title=\"" + HtmlEncode(Language.Phrase("ExportToHtmlText")) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToHtmlText")) + "\">" + Language.Phrase("ExportToHtml") + "</a>";
				} else if (SameText(type, "xml")) {
					return "<a href=\"" + AppPath(ExportXmlUrl) + "\" class=\"ew-export-link ew-xml\" title=\"" + HtmlEncode(Language.Phrase("ExportToXmlText")) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToXmlText")) + "\">" + Language.Phrase("ExportToXml") + "</a>";
				} else if (SameText(type, "csv")) {
					return "<a href=\"" + AppPath(ExportCsvUrl) + "\" class=\"ew-export-link ew-csv\" title=\"" + HtmlEncode(Language.Phrase("ExportToCsvText")) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToCsvText")) + "\">" + Language.Phrase("ExportToCsv") + "</a>";
				} else if (SameText(type, "print")) {
					return "<a href=\"" + AppPath(ExportPrintUrl) + "\" class=\"ew-export-link ew-print\" title=\"" + HtmlEncode(Language.Phrase("PrinterFriendlyText")) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("PrinterFriendlyText")) + "\">" + Language.Phrase("PrinterFriendly") + "</a>";
				}
				return "";
			}

			// Set up export options
			protected void SetupExportOptions() {
				ListOption item;

				// Printer friendly
				item = ExportOptions.Add("print");
				item.Body = GetExportTag("print");
				item.Visible = true;

				// Export to Excel
				item = ExportOptions.Add("excel");
				item.Body = GetExportTag("excel");
				item.Visible = true;

				// Export to Word
				item = ExportOptions.Add("word");
				item.Body = GetExportTag("word");
				item.Visible = false;

				// Export to HTML
				item = ExportOptions.Add("html");
				item.Body = GetExportTag("html");
				item.Visible = false;

				// Export to XML
				item = ExportOptions.Add("xml");
				item.Body = GetExportTag("xml");
				item.Visible = false;

				// Export to CSV
				item = ExportOptions.Add("csv");
				item.Body = GetExportTag("csv");
				item.Visible = true;

				// Export to PDF
				item = ExportOptions.Add("pdf");
				item.Body = GetExportTag("pdf");
				item.Visible = false;

				// Export to Email
				item = ExportOptions.Add("email");
				var url = "";
				item.Body = "<button id=\"emf_AntecedenteDental\" class=\"ew-export-link ew-email\" title=\"" + Language.Phrase("ExportToEmailText") + "\" data-caption=\"" + Language.Phrase("ExportToEmailText") + "\" onclick=\"ew.emailDialogShow({lnk:'emf_AntecedenteDental',hdr:ew.language.phrase('ExportToEmailText'),f:document.fAntecedenteDentallist,sel:false" + url + "});\">" + Language.Phrase("ExportToEmail") + "</button>";
				item.Visible = false;

				// Drop down button for export
				ExportOptions.UseButtonGroup = true;
				ExportOptions.UseDropDownButton = false;
				if (ExportOptions.UseButtonGroup && IsMobile())
					ExportOptions.UseDropDownButton = true;
				ExportOptions.DropDownButtonPhrase = Language.Phrase("ButtonExport");

				// Add group option item
				item = ExportOptions.Add(ExportOptions.GroupOptionName);
				item.Body = "";
				item.Visible = false;
			}

			#pragma warning disable 168

			/// <summary>
			/// Export data
			/// </summary>

			public async Task<IActionResult> ExportData() {
				var selectLimit = true; // List page

				// Load recordset // DN
				DbDataReader rs = null;
				if (!selectLimit) { // View page
					if (Recordset == null) {
						Recordset = await LoadRecordset();
						await Recordset.ReadAsync(); // Move to the start record
					}
					rs = Recordset;
				}
				if (TotalRecords < 0)
					TotalRecords = await ListRecordCount();
				StartRecord = 1;

				// Export all
				if (ExportAll) {
					DisplayRecords = TotalRecords;
					StopRecord = TotalRecords;
				} else { // Export one page only
					SetupStartRec(); // Set up start record position

					// Set the last record to display
					if (DisplayRecords < 0) {
						StopRecord = TotalRecords;
					} else {
						StopRecord = StartRecord + DisplayRecords - 1;
					}
				}
				rs = await LoadRecordset(StartRecord - 1, (DisplayRecords <= 0) ? TotalRecords : DisplayRecords); // DN
				var doc = CreateExportDocument(this, "h");
				ExportDoc = doc;
				if (doc == null) { // DN
					FailureMessage = Language.Phrase("ExportClassNotFound"); // Export class not found
					return Controller.Content(GetMessage(), "text/html");
				}

				// Call Page Exporting server event
				ExportDoc.ExportCustom = !Page_Exporting();

				// Page header
				string header = PageHeader;
				Page_DataRendering(ref header);
				doc.Text.Append(header);

				// Export
				await ExportDocument(doc, rs, StartRecord, StopRecord, "");

				// Page footer
				string footer = PageFooter;
				Page_DataRendered(ref footer);
				doc.Text.Append(footer);

				// Close recordset
				using (rs) {} // Dispose

				// Call Page Exported server event
				Page_Exported();

				// Export header and footer
				await doc.ExportHeaderAndFooter();

				// Log debug message if enabled // DN
				if (Config.Debug)
					Log(GetDebugMessage());

				// Clean output buffer
				Response.Clear();

				// Output data
				if (IsExport("email")) {

					// Export-to-email disabled
					return null;
				}
				return doc.Export();
			}

			#pragma warning restore 168

			// Set up Breadcrumb
			protected void SetupBreadcrumb() {
				var breadcrumb = new Breadcrumb();
				string url = CurrentUrl();
				url = Regex.Replace(url, @"\?cmd=reset(all)?$", ""); // Remove cmd=reset / cmd=resetall
				breadcrumb.Add("list", TableVar, url, "", TableVar, true);
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

			// ListOptions Load event
			public virtual void ListOptions_Load() {

				// Example:
				//var opt = ListOptions.Add("new");
				//opt.Header = "xxx";
				//opt.OnLeft = true; // Link on left
				//opt.MoveTo(0); // Move to first column

			}

			// ListOptions Rendering event
			public virtual void ListOptions_Rendering() {

				//xxxGrid.DetailAdd = (...condition...); // Set to true or false conditionally
				//xxxGrid.DetailEdit = (...condition...); // Set to true or false conditionally
				//xxxGrid.DetailView = (...condition...); // Set to true or false conditionally

			}

			// ListOptions Rendered event
			public virtual void ListOptions_Rendered() {

				//Example:
				//ListOptions["new"].Body = "xxx";

			}

			// Row Custom Action event
			public virtual bool Row_CustomAction(string action, Dictionary<string, object> row) {

				// Return false to abort
				return true;
			}

			// Grid Inserting event
			public virtual bool Grid_Inserting() {

				// Enter your code here
				// To reject grid insert, set return value to FALSE

				return true;
			}

			// Grid Inserted event
			public virtual void Grid_Inserted(List<Dictionary<string, object>> rsnew) {

				//Log("Grid Inserted");
			}

			// Grid Updating event
			public virtual bool Grid_Updating(List<Dictionary<string, object>> rsold) {

				// Enter your code here
				// To reject grid update, set return value to FALSE

				return true;
			}

			// Grid Updated event
			public virtual void Grid_Updated(List<Dictionary<string, object>> rsold, List<Dictionary<string, object>> rsnew) {

				//Log("Grid Updated");
			}
		}
	}
}
