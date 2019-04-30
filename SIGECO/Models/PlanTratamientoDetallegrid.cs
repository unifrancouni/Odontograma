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
		/// PlanTratamientoDetalle_Grid
		/// </summary>

		public static _PlanTratamientoDetalle_Grid PlanTratamientoDetalle_Grid {
			get => HttpData.Get<_PlanTratamientoDetalle_Grid>("PlanTratamientoDetalle_Grid");
			set => HttpData["PlanTratamientoDetalle_Grid"] = value;
		}

		/// <summary>
		/// Page class for PlanTratamientoDetalle
		/// </summary>

		public class _PlanTratamientoDetalle_Grid : _PlanTratamientoDetalle_GridBase
		{

			// Construtor
			public _PlanTratamientoDetalle_Grid(Controller controller = null) : base(controller) {
			}
		}

		/// <summary>
		/// Page base class
		/// </summary>

		public class _PlanTratamientoDetalle_GridBase : _PlanTratamientoDetalle, IAspNetMakerPage
		{

			// Page ID
			public string PageID = "grid";

			// Project ID
			public string ProjectID = "{9B083C8B-EE2F-4356-BE8D-9A26D5707365}";

			// Table name
			public string TableName = "PlanTratamientoDetalle";

			// Page object name
			public string PageObjName = "PlanTratamientoDetalle_Grid";

			// Grid form hidden field names
			public string FormName = "fPlanTratamientoDetallegrid";
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
			public _PlanTratamientoDetalle_GridBase(Controller controller = null) { // DN
				if (controller != null)
					Controller = controller;

				// Initialize
				FormActionName += "_" + FormName;
				FormKeyName += "_" + FormName;
				FormOldKeyName += "_" + FormName;
				FormBlankRowName += "_" + FormName;
				FormKeyCountName += "_" + FormName;

				// Language object
				Language = Language ?? new Lang();

				// Table object (PlanTratamientoDetalle)
				if (PlanTratamientoDetalle == null || PlanTratamientoDetalle is _PlanTratamientoDetalle)
					PlanTratamientoDetalle = this;
				AddUrl = "PlanTratamientoDetalleadd";

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

				// Other options
				OtherOptions["addedit"] = new ListOptions { Tag = "div", TagClassName = "ew-add-edit-option" };
			}

			#pragma warning disable 1998

			// Export view result
			public async Task<IActionResult> ExportView() { // DN
				if (!Empty(CustomExport) && CustomExport == Export && Config.Export.TryGetValue(CustomExport, out string classname)) {
					IActionResult result = null;
					string content = await GetViewOutput();
					if (Empty(ExportFileName))
						ExportFileName = TableVar;
					dynamic doc = CreateInstance(classname, new object[] { PlanTratamientoDetalle, "" }); // DN
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
				if (Empty(url))
					return null;
				if (!IsApi())
					Page_Redirecting(ref url);

				// Close connection
				CloseConnections(false);

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
				key += UrlEncode(Convert.ToString(ar["nPlanTratamientoDetalleID"]));
				return key;
			}

			// Hide fields for Add/Edit
			protected void HideFieldsForAddEdit() {
				if (IsAdd || IsCopy || IsGridAdd)
					nPlanTratamientoDetalleID.Visible = false;
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

			#pragma warning disable 169

			public bool ShowOtherOptions = false;
			private DatabaseConnectionBase<SqlConnection, SqlCommand, SqlDataReader, SqlDbType> _connection;

			#pragma warning restore 169

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

				// Create form object
				CurrentForm = new HttpForm();

				// Get grid add count
				int gridaddcnt = Get<int>(Config.TableGridAddRowCount);
				if (gridaddcnt > 0)
					GridAddRowCount = gridaddcnt;

				// Set up list options
				await SetupListOptions();
				nPlanTratamientoDetalleID.Visible = false;
				nPlanTratamientoID.Visible = false;
				nTratamientoID.SetVisibility();
				dFechaTratamiento.SetVisibility();
				nCosto.SetVisibility();
				nMonedaID.SetVisibility();
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

				// Set up master detail parameters
				SetupMasterParms();

				// Setup other options
				SetupOtherOptions();

				// Set up lookup cache
				await SetupLookupOptions(nTratamientoID);
				await SetupLookupOptions(nMonedaID);

				// Search filters
				string filter = "";

				// Get command
				Command = Get("cmd").ToLower();
				if (IsPageRequest) { // Validate request

					// Handle reset command
					ResetCommand();

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

					// Show grid delete link for grid add / grid edit
					if (AllowAddDeleteRow) {
						if (IsGridAdd || IsGridEdit) {
							var item = ListOptions["griddelete"];
							if (item != null)
								item.Visible = true;
						}
					}

					// Set up sorting order
					SetupSortOrder();
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

				// Build filter
				filter = "";
				if (!Security.CanList)
					filter = "(0=1)"; // Filter all records

				// Restore master/detail filter
				DbMasterFilter = MasterFilter; // Restore master filter
				DbDetailFilter = DetailFilter; // Restore detail filter
				AddFilter(ref filter, DbDetailFilter);
				AddFilter(ref filter, SearchWhere);

				// Load master record
				if (CurrentMode != "add" && !Empty(MasterFilter) && CurrentMasterTable == "PlanTratamiento") {
					using (var rsmaster = await PlanTratamiento.LoadRs(DbMasterFilter)) {
						MasterRecordExists = (rsmaster != null && await rsmaster.ReadAsync());
						if (!MasterRecordExists) {
							FailureMessage = Language.Phrase("NoRecord"); // Set no record found
							return Terminate("PlanTratamientolist"); // Return to master page
						} else {
							PlanTratamiento.LoadListRowValues(rsmaster);
						}
					}
					PlanTratamiento.RowType = Config.RowTypeMaster; // Master row
					await PlanTratamiento.RenderListRow(); // Note: Do it outside "using" // DN
				}

				// Set up filter
				if (Command == "json") {
					UseSessionForListSql = false; // Do not use session for ListSql
					CurrentFilter = filter;
				} else {
					SessionWhere = filter;
					CurrentFilter = "";
				}
				if (IsGridAdd) {
					if (CurrentMode == "copy") {
						TotalRecords = await ListRecordCount();
						Recordset = await LoadRecordset(StartRecord - 1, TotalRecords);
						StartRecord = 1;
						DisplayRecords = TotalRecords;
					} else {
						CurrentFilter = "0=1";
						StartRecord = 1;
						DisplayRecords = GridAddRowCount;
					}
					TotalRecords = DisplayRecords;
					StopRecord = DisplayRecords;
				} else {
					TotalRecords = await ListRecordCount();
					StopRecord = DisplayRecords;
					StartRecord = 1;
				DisplayRecords = TotalRecords; // Display all records

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

				// Normal return
				if (IsApi()) {
					if (!Connection.SelectOffset) // DN
						for (var i = 1; i <= StartRecord - 1; i++) // Move to first record
							await Recordset.ReadAsync();
					using (Recordset) {
						return Controller.Json(new Dictionary<string, object> { {"success", true}, {TableVar, await GetRecordsFromRecordset(Recordset)}, {"totalRecordCount", TotalRecords}, {"version", Config.ProductVersion} });
					}
				}
				return null;
			}

			// Exit inline mode
			protected void ClearInlineMode() {
				LastAction = CurrentAction; // Save last action
				CurrentAction = ""; // Clear action
				Session[Config.SessionInlineMode] = ""; // Clear inline mode
			}

			// Switch to Grid Add mode
			protected void GridAddMode() {
				CurrentAction = "gridadd";
				Session[Config.SessionInlineMode] = "gridadd"; // Enabled grid add
				HideFieldsForAddEdit();
			}

			// Switch to Grid Edit mode
			protected void GridEditMode() {
				CurrentAction = "gridedit";
				Session[Config.SessionInlineMode] = "gridedit"; // Enabled grid edit
				HideFieldsForAddEdit();
			}

			// Perform update to grid
			public async Task<bool> GridUpdate() {
				bool gridUpdate = true;

				// Get old recordset
				CurrentFilter = BuildKeyFilter();
				if (Empty(CurrentFilter))
					CurrentFilter = "0=1";
				string sql = CurrentSql;
				List<Dictionary<string, object>> rsold = await Connection.GetRowsAsync(sql);

				// Call Grid Updating event
				if (!Grid_Updating(rsold)) {
					if (Empty(FailureMessage))
						FailureMessage = Language.Phrase("GridEditCancelled"); // Set grid edit cancelled message
					return false;
				}
				string key = "";

				// Update row index and get row key
				CurrentForm.Index = -1;
				int rowcnt = CurrentForm.GetInt(FormKeyCountName);
				if (!IsNumeric(rowcnt))
					rowcnt = 0;

				// Update all rows based on key
				try {
					for (int rowindex = 1; rowindex <= rowcnt; rowindex++) {
						CurrentForm.Index = rowindex;
						string rowkey = CurrentForm.GetValue(FormKeyName);
						string rowaction = CurrentForm.GetValue(FormActionName);

						// Load all values and keys
						if (rowaction != "insertdelete") { // Skip insert then deleted rows
							await LoadFormValues(); // Get form values
							if (Empty(rowaction) || rowaction == "edit" || rowaction == "delete") {
								gridUpdate = SetupKeyValues(rowkey); // Set up key values
							} else {
								gridUpdate = true;
							}

							// Skip empty row
							if (rowaction == "insert" && EmptyRow()) {

								// No action required
							// Validate form and insert/update/delete record

							} else if (gridUpdate) {
								if (rowaction == "delete") {
									CurrentFilter = GetRecordFilter();
									gridUpdate = await DeleteRows(); // Delete this row
								} else if (!await ValidateForm()) {
									gridUpdate = false; // Form error, reset action
									FailureMessage = FormError;
								} else {
									if (rowaction == "insert") {
										gridUpdate = await AddRow(); // Insert this row
									} else {
										if (!Empty(rowkey)) {
											SendEmail = false; // Do not send email on update success
											gridUpdate = await EditRow(); // Update this row
										}
									} // End update
								}
							}
							if (gridUpdate) {
								if (!Empty(key))
									key += ", ";
								key += rowkey;
							} else {
								break;
							}
						}
					}
				} catch (Exception e) {
					FailureMessage = e.Message;
					gridUpdate = false;
				}
				if (gridUpdate) {

					// Get new recordset
					List<Dictionary<string, object>> rsnew = await Connection.GetRowsAsync(sql, true); // Use main connection (faster) // DN

					// Call Grid_Updated event
					Grid_Updated(rsold, rsnew);
					ClearInlineMode(); // Clear inline edit mode
				} else {
					if (Empty(FailureMessage))
						FailureMessage = Language.Phrase("UpdateFailed"); // Set update failed message
				}
				return gridUpdate;
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
					PlanTratamientoDetalle.nPlanTratamientoDetalleID.FormValue = arKeyFlds[0];
					if (!IsNumeric(PlanTratamientoDetalle.nPlanTratamientoDetalleID.FormValue))
						return false;
				}
				return true;
			}

			// Perform Grid Add

			#pragma warning disable 168, 219

			public async Task<bool> GridInsert() {
				int addcnt = 0;
				bool gridInsert = false;

				// Call Grid Inserting event
				if (!Grid_Inserting()) {
					if (Empty(FailureMessage))
						FailureMessage = Language.Phrase("GridAddCancelled"); // Set grid add cancelled message
					return false;
				}

				// Init key filter
				string wrkFilter = "";
				string key = "";

				// Get row count
				CurrentForm.Index = -1;
				int rowcnt = CurrentForm.GetInt(FormKeyCountName);

				// Insert all rows
				try {
					for (int rowindex = 1; rowindex <= rowcnt; rowindex++) {

						// Load current row values
						CurrentForm.Index = rowindex;
						string rowaction = CurrentForm.GetValue(FormActionName);
						if (!Empty(rowaction) && rowaction != "insert")
							continue; // Skip
						if (rowaction == "insert") {
							RowOldKey = CurrentForm.GetValue(FormOldKeyName);
							await LoadOldRecord(); // Load old record
						}
						await LoadFormValues(); // Get form values
						if (!EmptyRow()) {
							addcnt++;
							SendEmail = false; // Do not send email on insert success

							// Validate form
							if (!await ValidateForm()) {
								gridInsert = false; // Form error, reset action
								FailureMessage = FormError;
							} else {
								gridInsert = await AddRow(Connection.GetRow(OldRecordset)); // Insert this row
							}
							if (gridInsert) {
								if (!Empty(key))
									key += Config.CompositeKeySeparator;
								key += nPlanTratamientoDetalleID.CurrentValue;

								// Add filter for this record
								string filter = GetRecordFilter();
								if (!Empty(wrkFilter))
									wrkFilter += " OR ";
								wrkFilter += filter;
							} else {
								break;
							}
						}
					}
					if (addcnt == 0) { // No record inserted
						ClearInlineMode(); // Clear grid add mode and return
						return true;
					}
				} catch (Exception e) {
					FailureMessage = e.Message;
					gridInsert = false;
				}
				if (gridInsert) {

					// Get new recordset
					CurrentFilter = wrkFilter;
					string sql = CurrentSql;
					List<Dictionary<string, object>> rsnew = await Connection.GetRowsAsync(sql, true); // Use main connection (faster) // DN

					// Call Grid_Inserted event
					Grid_Inserted(rsnew);
					ClearInlineMode(); // Clear grid add mode
				} else {
					if (Empty(FailureMessage))
						FailureMessage = Language.Phrase("InsertFailed"); // Set insert failed message
				}
				return gridInsert;
			}

			#pragma warning restore 168, 219

			// Check if empty row
			public bool EmptyRow() {
				if (CurrentForm.HasValue("x_nTratamientoID") && CurrentForm.HasValue("o_nTratamientoID") && !SameString(nTratamientoID.CurrentValue, nTratamientoID.OldValue))
					return false;
				if (CurrentForm.HasValue("x_dFechaTratamiento") && CurrentForm.HasValue("o_dFechaTratamiento") && !SameString(FormatDateTime(dFechaTratamiento.CurrentValue, 0), FormatDateTime(dFechaTratamiento.OldValue, 0)))
					return false;
				if (CurrentForm.HasValue("x_nCosto") && CurrentForm.HasValue("o_nCosto") && !SameString(nCosto.CurrentValue, nCosto.OldValue))
					return false;
				if (CurrentForm.HasValue("x_nMonedaID") && CurrentForm.HasValue("o_nMonedaID") && !SameString(nMonedaID.CurrentValue, nMonedaID.OldValue))
					return false;
				return true;
			}

			// Validate grid form
			public async Task<bool> ValidateGridForm() {

				// Get row count
				CurrentForm.Index = -1;
				int rowcnt = CurrentForm.GetInt(FormKeyCountName);

				// Validate all records
				for (int rowindex = 1; rowindex <= rowcnt; rowindex++) {

					// Load current row values
					CurrentForm.Index = rowindex;
					string rowaction = CurrentForm.GetValue(FormActionName);
					if (rowaction != "delete" && rowaction != "insertdelete") {
						await LoadFormValues(); // Get form values
						if (rowaction == "insert" && EmptyRow()) {

							// Ignore
						} else if (!await ValidateForm()) {
							return false;
						}
					}
				}
				return true;
			}

			// Get all form values of the grid
			public List<Dictionary<string, string>> GetGridFormValues() {

				// Get row count
				CurrentForm.Index = -1;
				int rowcnt = CurrentForm.GetInt(FormKeyCountName);
				if (!IsNumeric(rowcnt))
					rowcnt = 0;
				var rows = new List<Dictionary<string, string>>();

				// Loop through all records
				for (int rowindex = 1; rowindex <= rowcnt; rowindex++) {

					// Load current row values
					CurrentForm.Index = rowindex;
					string rowaction = CurrentForm.GetValue(FormActionName);
					if (rowaction != "delete" && rowaction != "insertdelete") {
						LoadFormValues().GetAwaiter().GetResult(); // Load form values (sync)
						if (rowaction == "insert" && EmptyRow()) {

							// Ignore
						} else {
							rows.Add(GetFormValues()); // Return row as array
						}
					}
				}
				return rows; // Return as array of array
			}

			// Restore form values for current row
			public async Task RestoreCurrentRowFormValues(object index) {

				// Get row based on current index
				CurrentForm.Index = ConvertToInt(index);
				await LoadFormValues(); // Load form values
			}

			// Set up sort parameters
			protected void SetupSortOrder() {

				// Check for "order" parameter
				if (!Empty(Get("order"))) {
					CurrentOrder = Get("order");
					CurrentOrderType = Get("ordertype");
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

					// Reset master/detail keys
					if (SameText(Command, "resetall")) {
						CurrentMasterTable = ""; // Clear master table
						DbMasterFilter = "";
						DbDetailFilter = "";
						nPlanTratamientoID.SessionValue = "";
					}

					// Reset sorting order
					if (SameText(Command, "resetsort")) {
						string orderBy = "";
						SessionOrderBy = orderBy;
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

				// "griddelete"
				if (AllowAddDeleteRow) {
					item = ListOptions.Add("griddelete");
					item.CssClass = "text-nowrap";
					item.OnLeft = true;
					item.Visible = false; // Default hidden
				}

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

				// Drop down button for ListOptions
				ListOptions.UseDropDownButton = false;
				ListOptions.DropDownButtonPhrase = Language.Phrase("ButtonListOptions");
				ListOptions.UseButtonGroup = false;
				if (ListOptions.UseButtonGroup && IsMobile())
					ListOptions.UseDropDownButton = true;
				ListOptions.ButtonClass = ""; // Class for button group
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
				string keyName = "";

				// Set up row action and key
				if (IsNumeric(RowIndex) && CurrentMode != "view") {
					CurrentForm.Index = ConvertToInt(RowIndex);
					var actionName = FormActionName.Replace("k_", "k" + Convert.ToString(RowIndex) + "_");
					var oldKeyName = FormOldKeyName.Replace("k_", "k" + Convert.ToString(RowIndex) + "_");
					keyName = FormKeyName.Replace("k_", "k" + Convert.ToString(RowIndex) + "_");
					var BlankRowName = FormBlankRowName.Replace("k_", "k" + Convert.ToString(RowIndex) + "_");
					if (!Empty(RowAction))
						MultiSelectKey += "<input type=\"hidden\" name=\"" + actionName + "\" id=\"" + actionName + "\" value=\"" + RowAction + "\">";
					if (CurrentForm.HasValue(FormOldKeyName))
						RowOldKey = CurrentForm.GetValue(FormOldKeyName);
					if (!Empty(RowOldKey))
						MultiSelectKey += "<input type=\"hidden\" name=\"" + oldKeyName + "\" id=\"" + oldKeyName + "\" value=\"" + HtmlEncode(RowOldKey) + "\">";
					if (RowAction == "delete") {
						string rowkey = CurrentForm.GetValue(FormKeyName);
						SetupKeyValues(rowkey);
					}
					if (RowAction == "insert" && IsConfirm && EmptyRow())
						MultiSelectKey += "<input type=\"hidden\" name=\"" + BlankRowName + "\" id=\"" + BlankRowName + "\" value=\"1\">";
				}

				// "delete"
				if (AllowAddDeleteRow) {
					if (CurrentMode == "add" || CurrentMode == "copy" || CurrentMode == "edit") {
						var options = ListOptions;
						options.UseButtonGroup = true; // Use button group for grid delete button
						listOption = options["griddelete"];
						if (!Security.CanDelete && IsNumeric(RowIndex) && (RowAction == "" || RowAction == "edit")) { // Do not allow delete existing record
							listOption.Body = "&nbsp;";
						} else {
							listOption.Body = "<a class=\"ew-grid-link ew-grid-delete\" title=\"" + HtmlTitle(Language.Phrase("DeleteLink")) + "\" data-caption=\"" + HtmlTitle(Language.Phrase("DeleteLink")) + "\" onclick=\"return ew.deleteGridRow(this, " + RowIndex + ");\">" + Language.Phrase("DeleteLink") + "</a>";
						}
					}
				}
				if (CurrentMode == "view") { // View mode

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
				} // End View mode
				if (CurrentMode == "edit" && IsNumeric(RowIndex)) {
					MultiSelectKey += "<input type=\"hidden\" name=\"" + keyName + "\" id=\"" + keyName + "\" value=\"" + nPlanTratamientoDetalleID.CurrentValue + "\">";
				}
				RenderListOptionsExt();

				// Call ListOptions_Rendered event
				ListOptions_Rendered();
			}

			// Set record key
			public void SetRecordKey(ref string key, DbDataReader dr) {
				if (dr == null)
					return;
				var row = Connection.GetRow(dr); // DN
				key = "";
				if (!Empty(key))
					key += Config.CompositeKeySeparator;
				key += row["nPlanTratamientoDetalleID"];
			}

			#pragma warning restore 168, 219, 1998

			// Set up other options
			protected void SetupOtherOptions() {
				ListOptions option;
				ListOption item;
				option = OtherOptions["addedit"];
				option.UseDropDownButton = false;
				option.DropDownButtonPhrase = Language.Phrase("ButtonAddEdit");
				option.UseButtonGroup = true;
				option.ButtonClass = ""; // Class for button group
				item = option.Add(option.GroupOptionName);
				item.Body = "";
				item.Visible = false;

				// Add
				if (CurrentMode == "view") { // Check view mode
					item = option.Add("add");
					string addcaption = HtmlTitle(Language.Phrase("AddLink"));
					AddUrl = GetAddUrl();
					item.Body = "<a class=\"ew-add-edit ew-add\" title=\"" + addcaption + "\" data-caption=\"" + addcaption + "\" href=\"" + HtmlEncode(AppPath(AddUrl)) + "\">" + Language.Phrase("AddLink") + "</a>";
					item.Visible = (AddUrl != "" && Security.CanAdd);
				}
			}

			// Render other options
			public void RenderOtherOptions() {
				ListOptions option;
				ListOption item;
				var options = OtherOptions;
				if ((CurrentMode == "add" || CurrentMode == "copy" || CurrentMode == "edit") && !IsConfirm) { // Check add/copy/edit mode
					if (AllowAddDeleteRow) {
						option = options["addedit"];
						option.UseDropDownButton = false;
						item = option.Add("addblankrow");
						item.Body = "<a class=\"ew-add-edit ew-add-blank-row\" title=\"" + HtmlTitle(Language.Phrase("AddBlankRow")) + "\" data-caption=\"" + HtmlTitle(Language.Phrase("AddBlankRow")) + "\" href=\"javascript:void(0);\" onclick=\"ew.addGridRow(this);\">" + Language.Phrase("AddBlankRow") + "</a>";
						item.Visible = Security.CanAdd;
						ShowOtherOptions = item.Visible;
					}
				}
				if (CurrentMode == "view") { // Check view mode
					option = options["addedit"];
					item = option.GetItem("add");
					if (!Empty(item) && item.Visible)
						ShowOtherOptions = true;
					else
						ShowOtherOptions = false;
				}
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
				nPlanTratamientoDetalleID.CurrentValue = System.DBNull.Value;
				nPlanTratamientoDetalleID.OldValue = nPlanTratamientoDetalleID.CurrentValue;
				nPlanTratamientoID.CurrentValue = System.DBNull.Value;
				nPlanTratamientoID.OldValue = nPlanTratamientoID.CurrentValue;
				nTratamientoID.CurrentValue = System.DBNull.Value;
				nTratamientoID.OldValue = nTratamientoID.CurrentValue;
				dFechaTratamiento.CurrentValue = System.DBNull.Value;
				dFechaTratamiento.OldValue = dFechaTratamiento.CurrentValue;
				nCosto.CurrentValue = System.DBNull.Value;
				nCosto.OldValue = nCosto.CurrentValue;
				nMonedaID.CurrentValue = System.DBNull.Value;
				nMonedaID.OldValue = nMonedaID.CurrentValue;
				dFechaCreacion.CurrentValue = System.DBNull.Value;
				dFechaCreacion.OldValue = dFechaCreacion.CurrentValue;
				dFechaModificacion.CurrentValue = System.DBNull.Value;
				dFechaModificacion.OldValue = dFechaModificacion.CurrentValue;
			}

			#pragma warning disable 1998

			// Load form values
			protected async Task LoadFormValues() {
				CurrentForm.FormName = FormName;
				string val;

				// Check field name 'nTratamientoID' first before field var 'x_nTratamientoID'
				val = CurrentForm.GetValue("nTratamientoID", "x_nTratamientoID");
				if (!nTratamientoID.IsDetailKey) {
					if (IsApi() && val == null)
						nTratamientoID.Visible = false; // Disable update for API request
					else
						nTratamientoID.FormValue = val;
				}
				if (CurrentForm.HasValue("o_nTratamientoID"))
					nTratamientoID.OldValue = CurrentForm.GetValue("o_nTratamientoID");

				// Check field name 'dFechaTratamiento' first before field var 'x_dFechaTratamiento'
				val = CurrentForm.GetValue("dFechaTratamiento", "x_dFechaTratamiento");
				if (!dFechaTratamiento.IsDetailKey) {
					if (IsApi() && val == null)
						dFechaTratamiento.Visible = false; // Disable update for API request
					else
						dFechaTratamiento.FormValue = val;
					dFechaTratamiento.CurrentValue = UnformatDateTime(dFechaTratamiento.CurrentValue, 0);
				}
				dFechaTratamiento.OldValue = UnformatDateTime(CurrentForm.GetValue("o_dFechaTratamiento"), 0);

				// Check field name 'nCosto' first before field var 'x_nCosto'
				val = CurrentForm.GetValue("nCosto", "x_nCosto");
				if (!nCosto.IsDetailKey) {
					if (IsApi() && val == null)
						nCosto.Visible = false; // Disable update for API request
					else
						nCosto.FormValue = val;
				}
				if (CurrentForm.HasValue("o_nCosto"))
					nCosto.OldValue = CurrentForm.GetValue("o_nCosto");

				// Check field name 'nMonedaID' first before field var 'x_nMonedaID'
				val = CurrentForm.GetValue("nMonedaID", "x_nMonedaID");
				if (!nMonedaID.IsDetailKey) {
					if (IsApi() && val == null)
						nMonedaID.Visible = false; // Disable update for API request
					else
						nMonedaID.FormValue = val;
				}
				if (CurrentForm.HasValue("o_nMonedaID"))
					nMonedaID.OldValue = CurrentForm.GetValue("o_nMonedaID");

				// Check field name 'nPlanTratamientoDetalleID' first before field var 'x_nPlanTratamientoDetalleID'
				val = CurrentForm.GetValue("nPlanTratamientoDetalleID", "x_nPlanTratamientoDetalleID");
				if (!nPlanTratamientoDetalleID.IsDetailKey && !IsGridAdd && !IsAdd)
					nPlanTratamientoDetalleID.FormValue = val;
			}

			#pragma warning restore 1998

			// Restore form values
			public void RestoreFormValues() {
				if (!IsGridAdd && !IsAdd)
					nPlanTratamientoDetalleID.CurrentValue = nPlanTratamientoDetalleID.FormValue;
				nTratamientoID.CurrentValue = nTratamientoID.FormValue;
				dFechaTratamiento.CurrentValue = dFechaTratamiento.FormValue;
				dFechaTratamiento.CurrentValue = UnformatDateTime(dFechaTratamiento.CurrentValue, 0);
				nCosto.CurrentValue = nCosto.FormValue;
				nMonedaID.CurrentValue = nMonedaID.FormValue;
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
				nPlanTratamientoDetalleID.SetDbValue(row["nPlanTratamientoDetalleID"]);
				nPlanTratamientoID.SetDbValue(row["nPlanTratamientoID"]);
				nTratamientoID.SetDbValue(row["nTratamientoID"]);
				dFechaTratamiento.SetDbValue(row["dFechaTratamiento"]);
				nCosto.SetDbValue(row["nCosto"]);
				nMonedaID.SetDbValue(row["nMonedaID"]);
				dFechaCreacion.SetDbValue(row["dFechaCreacion"]);
				dFechaModificacion.SetDbValue(row["dFechaModificacion"]);
			}

			#pragma warning restore 162, 168, 1998

			// Return a row with default values
			protected Dictionary<string, object> NewRow() {
				LoadDefaultValues();
				var row = new Dictionary<string, object>();
				row.Add("nPlanTratamientoDetalleID", nPlanTratamientoDetalleID.CurrentValue);
				row.Add("nPlanTratamientoID", nPlanTratamientoID.CurrentValue);
				row.Add("nTratamientoID", nTratamientoID.CurrentValue);
				row.Add("dFechaTratamiento", dFechaTratamiento.CurrentValue);
				row.Add("nCosto", nCosto.CurrentValue);
				row.Add("nMonedaID", nMonedaID.CurrentValue);
				row.Add("dFechaCreacion", dFechaCreacion.CurrentValue);
				row.Add("dFechaModificacion", dFechaModificacion.CurrentValue);
				return row;
			}

			#pragma warning disable 618, 1998

			// Load old record
			protected async Task<bool> LoadOldRecord(DatabaseConnectionBase<SqlConnection, SqlCommand, SqlDataReader, SqlDbType> cnn = null) {
				bool validKey = true;
				string[] arKeys = { RowOldKey };
				int cnt = arKeys.Length;
				if (cnt >= 1) {
					if (!Empty(arKeys[0]))
						nPlanTratamientoDetalleID.CurrentValue = arKeys[0]; // nPlanTratamientoDetalleID;
					else
						validKey = false;
				} else {
					validKey = false;
				}

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

				// Convert decimal values if posted back
				if (SameString(nCosto.FormValue, nCosto.CurrentValue) && IsNumeric(ConvertToFloatString(nCosto.CurrentValue)))
					nCosto.CurrentValue = ConvertToFloatString(nCosto.CurrentValue);

				// Call Row_Rendering event
				Row_Rendering();

				// Common render codes for all row types
				// nPlanTratamientoDetalleID

				nPlanTratamientoDetalleID.CellCssStyle = "white-space: nowrap;";

				// nPlanTratamientoID
				nPlanTratamientoID.CellCssStyle = "white-space: nowrap;";

				// nTratamientoID
				// dFechaTratamiento
				// nCosto
				// nMonedaID
				// dFechaCreacion

				dFechaCreacion.CellCssStyle = "white-space: nowrap;";

				// dFechaModificacion
				dFechaModificacion.CellCssStyle = "white-space: nowrap;";
				if (RowType == Config.RowTypeView) { // View row

					// nTratamientoID
					curVal = Convert.ToString(nTratamientoID.CurrentValue);
					if (!Empty(curVal)) {
						nTratamientoID.ViewValue = nTratamientoID.LookupCacheOption(curVal);
						if (nTratamientoID.ViewValue == null) { // Lookup from database
							filterWrk = "[nTratamientoID]" + SearchString("=", curVal.Trim(), Config.DataTypeNumber, "");
							sqlWrk = nTratamientoID.Lookup.GetSql(false, filterWrk, null, this);
							rswrk = await Connection.GetRowsAsync(sqlWrk);
							if (rswrk != null && rswrk.Count > 0) { // Lookup values found
								var listwrk = rswrk[0].Values.ToList();
								listwrk[1] = Convert.ToString(listwrk[1]);
								listwrk[2] = Convert.ToString(FormatNumber(listwrk[2], 2, -2, -2, -2));
								listwrk[3] = Convert.ToString(listwrk[3]);
								nTratamientoID.ViewValue = nTratamientoID.DisplayValue(listwrk);
							} else {
								nTratamientoID.ViewValue = nTratamientoID.CurrentValue;
							}
						}
					} else {
						nTratamientoID.ViewValue = System.DBNull.Value;
					}

					// dFechaTratamiento
					dFechaTratamiento.ViewValue = dFechaTratamiento.CurrentValue;
					dFechaTratamiento.ViewValue = FormatDateTime(dFechaTratamiento.ViewValue, 0);

					// nCosto
					nCosto.ViewValue = nCosto.CurrentValue;
					nCosto.ViewValue = FormatNumber(nCosto.ViewValue, 2, -2, -2, -2);

					// nMonedaID
					curVal = Convert.ToString(nMonedaID.CurrentValue);
					if (!Empty(curVal)) {
						nMonedaID.ViewValue = nMonedaID.LookupCacheOption(curVal);
						if (nMonedaID.ViewValue == null) { // Lookup from database
							filterWrk = "[nValorCatalogoID]" + SearchString("=", curVal.Trim(), Config.DataTypeNumber, "");
							sqlWrk = nMonedaID.Lookup.GetSql(false, filterWrk, null, this);
							rswrk = await Connection.GetRowsAsync(sqlWrk);
							if (rswrk != null && rswrk.Count > 0) { // Lookup values found
								var listwrk = rswrk[0].Values.ToList();
								listwrk[1] = Convert.ToString(listwrk[1]);
								nMonedaID.ViewValue = nMonedaID.DisplayValue(listwrk);
							} else {
								nMonedaID.ViewValue = nMonedaID.CurrentValue;
							}
						}
					} else {
						nMonedaID.ViewValue = System.DBNull.Value;
					}

					// nTratamientoID
					nTratamientoID.HrefValue = "";
					nTratamientoID.TooltipValue = "";

					// dFechaTratamiento
					dFechaTratamiento.HrefValue = "";
					dFechaTratamiento.TooltipValue = "";

					// nCosto
					nCosto.HrefValue = "";
					nCosto.TooltipValue = "";

					// nMonedaID
					nMonedaID.HrefValue = "";
					nMonedaID.TooltipValue = "";
				} else if (RowType == Config.RowTypeAdd) { // Add row

					// nTratamientoID
					curVal = Convert.ToString(nTratamientoID.CurrentValue).Trim();
					if (curVal != "")
						nTratamientoID.ViewValue = nTratamientoID.LookupCacheOption(curVal);
					else
						nTratamientoID.ViewValue = nTratamientoID.Lookup != null && IsList(nTratamientoID.Lookup.Options) ? curVal : null;
					if (nTratamientoID.ViewValue != null) { // Load from cache
						nTratamientoID.EditValue = nTratamientoID.Lookup.Options.Values.ToList();
						if (SameString(nTratamientoID.ViewValue, ""))
							nTratamientoID.ViewValue = Language.Phrase("PleaseSelect");
					} else { // Lookup from database
						if (curVal == "") {
							filterWrk = "0=1";
						} else {
							filterWrk = "[nTratamientoID]" + SearchString("=", Convert.ToString(nTratamientoID.CurrentValue), Config.DataTypeNumber, "");
						}
					sqlWrk = nTratamientoID.Lookup.GetSql(true, filterWrk, null, this);
					rswrk = await Connection.GetRowsAsync(sqlWrk);
					if (rswrk != null && rswrk.Count > 0) { // Lookup values found
						var listwrk = rswrk[0].Values.ToList();
						listwrk[1] = Convert.ToString(HtmlEncode(listwrk[1]));
						listwrk[2] = Convert.ToString(HtmlEncode(FormatNumber(listwrk[2], 2, -2, -2, -2)));
						listwrk[3] = Convert.ToString(HtmlEncode(listwrk[3]));
						nTratamientoID.ViewValue = nTratamientoID.DisplayValue(listwrk);
						foreach (var d in rswrk) {
							var keys = d.Keys.ToList();
							d[keys[2]] = FormatNumber(d[keys[2]], 2, -2, -2, -2);
						}
					} else {
						nTratamientoID.ViewValue = nTratamientoID.PleaseSelectText;
					}
					nTratamientoID.EditValue = rswrk;
					}

					// dFechaTratamiento
					dFechaTratamiento.EditAttrs["class"] = "form-control";
					dFechaTratamiento.EditValue = FormatDateTime(dFechaTratamiento.CurrentValue, 8); // DN
					dFechaTratamiento.PlaceHolder = RemoveHtml(dFechaTratamiento.Caption);

					// nCosto
					nCosto.EditAttrs["class"] = "form-control";
					nCosto.EditValue = nCosto.CurrentValue; // DN
					nCosto.PlaceHolder = RemoveHtml(nCosto.Caption);
					if (!Empty(nCosto.EditValue) && IsNumeric(nCosto.EditValue)) {
						nCosto.EditValue = FormatNumber(nCosto.EditValue, -2, -2, -2, -2);
						nCosto.OldValue = nCosto.EditValue;
					}

					// nMonedaID
					curVal = Convert.ToString(nMonedaID.CurrentValue).Trim();
					if (curVal != "")
						nMonedaID.ViewValue = nMonedaID.LookupCacheOption(curVal);
					else
						nMonedaID.ViewValue = nMonedaID.Lookup != null && IsList(nMonedaID.Lookup.Options) ? curVal : null;
					if (nMonedaID.ViewValue != null) { // Load from cache
						nMonedaID.EditValue = nMonedaID.Lookup.Options.Values.ToList();
						if (SameString(nMonedaID.ViewValue, ""))
							nMonedaID.ViewValue = Language.Phrase("PleaseSelect");
					} else { // Lookup from database
						if (curVal == "") {
							filterWrk = "0=1";
						} else {
							filterWrk = "[nValorCatalogoID]" + SearchString("=", Convert.ToString(nMonedaID.CurrentValue), Config.DataTypeNumber, "");
						}
					sqlWrk = nMonedaID.Lookup.GetSql(true, filterWrk, null, this);
					rswrk = await Connection.GetRowsAsync(sqlWrk);
					if (rswrk != null && rswrk.Count > 0) { // Lookup values found
						var listwrk = rswrk[0].Values.ToList();
						listwrk[1] = Convert.ToString(HtmlEncode(listwrk[1]));
						nMonedaID.ViewValue = nMonedaID.DisplayValue(listwrk);
					} else {
						nMonedaID.ViewValue = nMonedaID.PleaseSelectText;
					}
					nMonedaID.EditValue = rswrk;
					}

					// Add refer script
					// nTratamientoID

					nTratamientoID.HrefValue = "";

					// dFechaTratamiento
					dFechaTratamiento.HrefValue = "";

					// nCosto
					nCosto.HrefValue = "";

					// nMonedaID
					nMonedaID.HrefValue = "";
				} else if (RowType == Config.RowTypeEdit) { // Edit row

					// nTratamientoID
					curVal = Convert.ToString(nTratamientoID.CurrentValue).Trim();
					if (curVal != "")
						nTratamientoID.ViewValue = nTratamientoID.LookupCacheOption(curVal);
					else
						nTratamientoID.ViewValue = nTratamientoID.Lookup != null && IsList(nTratamientoID.Lookup.Options) ? curVal : null;
					if (nTratamientoID.ViewValue != null) { // Load from cache
						nTratamientoID.EditValue = nTratamientoID.Lookup.Options.Values.ToList();
						if (SameString(nTratamientoID.ViewValue, ""))
							nTratamientoID.ViewValue = Language.Phrase("PleaseSelect");
					} else { // Lookup from database
						if (curVal == "") {
							filterWrk = "0=1";
						} else {
							filterWrk = "[nTratamientoID]" + SearchString("=", Convert.ToString(nTratamientoID.CurrentValue), Config.DataTypeNumber, "");
						}
					sqlWrk = nTratamientoID.Lookup.GetSql(true, filterWrk, null, this);
					rswrk = await Connection.GetRowsAsync(sqlWrk);
					if (rswrk != null && rswrk.Count > 0) { // Lookup values found
						var listwrk = rswrk[0].Values.ToList();
						listwrk[1] = Convert.ToString(HtmlEncode(listwrk[1]));
						listwrk[2] = Convert.ToString(HtmlEncode(FormatNumber(listwrk[2], 2, -2, -2, -2)));
						listwrk[3] = Convert.ToString(HtmlEncode(listwrk[3]));
						nTratamientoID.ViewValue = nTratamientoID.DisplayValue(listwrk);
						foreach (var d in rswrk) {
							var keys = d.Keys.ToList();
							d[keys[2]] = FormatNumber(d[keys[2]], 2, -2, -2, -2);
						}
					} else {
						nTratamientoID.ViewValue = nTratamientoID.PleaseSelectText;
					}
					nTratamientoID.EditValue = rswrk;
					}

					// dFechaTratamiento
					dFechaTratamiento.EditAttrs["class"] = "form-control";
					dFechaTratamiento.EditValue = FormatDateTime(dFechaTratamiento.CurrentValue, 8); // DN
					dFechaTratamiento.PlaceHolder = RemoveHtml(dFechaTratamiento.Caption);

					// nCosto
					nCosto.EditAttrs["class"] = "form-control";
					nCosto.EditValue = nCosto.CurrentValue; // DN
					nCosto.PlaceHolder = RemoveHtml(nCosto.Caption);
					if (!Empty(nCosto.EditValue) && IsNumeric(nCosto.EditValue)) {
						nCosto.EditValue = FormatNumber(nCosto.EditValue, -2, -2, -2, -2);
						nCosto.OldValue = nCosto.EditValue;
					}

					// nMonedaID
					curVal = Convert.ToString(nMonedaID.CurrentValue).Trim();
					if (curVal != "")
						nMonedaID.ViewValue = nMonedaID.LookupCacheOption(curVal);
					else
						nMonedaID.ViewValue = nMonedaID.Lookup != null && IsList(nMonedaID.Lookup.Options) ? curVal : null;
					if (nMonedaID.ViewValue != null) { // Load from cache
						nMonedaID.EditValue = nMonedaID.Lookup.Options.Values.ToList();
						if (SameString(nMonedaID.ViewValue, ""))
							nMonedaID.ViewValue = Language.Phrase("PleaseSelect");
					} else { // Lookup from database
						if (curVal == "") {
							filterWrk = "0=1";
						} else {
							filterWrk = "[nValorCatalogoID]" + SearchString("=", Convert.ToString(nMonedaID.CurrentValue), Config.DataTypeNumber, "");
						}
					sqlWrk = nMonedaID.Lookup.GetSql(true, filterWrk, null, this);
					rswrk = await Connection.GetRowsAsync(sqlWrk);
					if (rswrk != null && rswrk.Count > 0) { // Lookup values found
						var listwrk = rswrk[0].Values.ToList();
						listwrk[1] = Convert.ToString(HtmlEncode(listwrk[1]));
						nMonedaID.ViewValue = nMonedaID.DisplayValue(listwrk);
					} else {
						nMonedaID.ViewValue = nMonedaID.PleaseSelectText;
					}
					nMonedaID.EditValue = rswrk;
					}

					// Edit refer script
					// nTratamientoID

					nTratamientoID.HrefValue = "";

					// dFechaTratamiento
					dFechaTratamiento.HrefValue = "";

					// nCosto
					nCosto.HrefValue = "";

					// nMonedaID
					nMonedaID.HrefValue = "";
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

				// Check if validation required
				if (!Config.ServerValidate)
					return (FormError == "");
				if (nPlanTratamientoDetalleID.Required) {
					if (!nPlanTratamientoDetalleID.IsDetailKey && Empty(nPlanTratamientoDetalleID.FormValue))
						FormError = AddMessage(FormError, nPlanTratamientoDetalleID.RequiredErrorMessage.Replace("%s", nPlanTratamientoDetalleID.Caption));
				}
				if (nPlanTratamientoID.Required) {
					if (!nPlanTratamientoID.IsDetailKey && Empty(nPlanTratamientoID.FormValue))
						FormError = AddMessage(FormError, nPlanTratamientoID.RequiredErrorMessage.Replace("%s", nPlanTratamientoID.Caption));
				}
				if (nTratamientoID.Required) {
					if (!nTratamientoID.IsDetailKey && Empty(nTratamientoID.FormValue))
						FormError = AddMessage(FormError, nTratamientoID.RequiredErrorMessage.Replace("%s", nTratamientoID.Caption));
				}
				if (dFechaTratamiento.Required) {
					if (!dFechaTratamiento.IsDetailKey && Empty(dFechaTratamiento.FormValue))
						FormError = AddMessage(FormError, dFechaTratamiento.RequiredErrorMessage.Replace("%s", dFechaTratamiento.Caption));
				}
				if (!CheckDate(dFechaTratamiento.FormValue))
					FormError = AddMessage(FormError, dFechaTratamiento.ErrorMessage);
				if (nCosto.Required) {
					if (!nCosto.IsDetailKey && Empty(nCosto.FormValue))
						FormError = AddMessage(FormError, nCosto.RequiredErrorMessage.Replace("%s", nCosto.Caption));
				}
				if (!CheckNumber(nCosto.FormValue))
					FormError = AddMessage(FormError, nCosto.ErrorMessage);
				if (nMonedaID.Required) {
					if (!nMonedaID.IsDetailKey && Empty(nMonedaID.FormValue))
						FormError = AddMessage(FormError, nMonedaID.RequiredErrorMessage.Replace("%s", nMonedaID.Caption));
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

			// Delete records (based on current filter)
			protected async Task<JsonBoolResult> DeleteRows() { // DN
				if (!Security.CanDelete) {
					FailureMessage = Language.Phrase("NoDeletePermission"); // No delete permission
					return JsonBoolResult.FalseResult; // No delete permission
				}
				bool result = true;
				List<Dictionary<string, object>> rsold = null;
				try {
					string sql = CurrentSql;
					using (var rs = await Connection.GetDataReaderAsync(sql)) {
						if (rs == null) {
							return JsonBoolResult.FalseResult;
						} else if (!rs.HasRows) {
							FailureMessage = Language.Phrase("NoRecord"); // No record found
							return JsonBoolResult.FalseResult;
						} else { // Clone old rows
							rsold = await Connection.GetRowsAsync(rs);
						}
					}
				} catch (Exception e) {
					if (Config.Debug)
						throw;
					FailureMessage = e.Message;
					return JsonBoolResult.FalseResult;
				}
				PlanTratamientoDetalle = PlanTratamientoDetalle ?? new _PlanTratamientoDetalle();
				var key = "";
				try {

					// Call Row Deleting event
					if (result)
						result = rsold.All(row => Row_Deleting(row));
					if (result) {
						foreach (var row in rsold) {
							var thisKey = "";
							if (!Empty(thisKey)) thisKey += Config.CompositeKeySeparator;
							thisKey += Convert.ToString(row["nPlanTratamientoDetalleID"]);
							if (Config.DeleteUploadFiles)
								DeleteUploadedFiles(row);
							try {
								await DeleteAsync(row);
							} catch (Exception e) {
								if (Config.Debug)
									throw;
								FailureMessage = e.Message; // Set up error message
								result = false;
								break;
							}
							if (!Empty(key))
								key += ", ";
							key += thisKey;
						}
					} 
					if (!result) {

						// Set up error message
						if (!Empty(SuccessMessage) || !Empty(FailureMessage)) {

							// Use the message, do nothing
						} else if (!Empty(CancelMessage)) {
							FailureMessage = CancelMessage;
							CancelMessage = "";
						} else {
							FailureMessage = Language.Phrase("DeleteCancelled");
						}
					}
				} catch (Exception e) {
					FailureMessage = e.Message;
					result = false;
				}

				// Call Row Deleted event
				if (result)
					rsold.ForEach(row => Row_Deleted(row));

				// Write JSON for API request (Support single row only)
				var d = new Dictionary<string, object>();
				d.Add("success", result);
				if (IsApi() && result) {
					var row = GetRecordFromRecordset(rsold);
					d.Add(TableVar, row);
					d.Add("version", Config.ProductVersion);
					return new JsonBoolResult(d, true);
				}
				return new JsonBoolResult(d, result);
			}

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

				// nTratamientoID
				nTratamientoID.SetDbValue(rsnew, nTratamientoID.CurrentValue, 0, nTratamientoID.ReadOnly);

				// dFechaTratamiento
				dFechaTratamiento.SetDbValue(rsnew, UnformatDateTime(dFechaTratamiento.CurrentValue, 0), DateTime.Now, dFechaTratamiento.ReadOnly);

				// nCosto
				nCosto.SetDbValue(rsnew, nCosto.CurrentValue, System.DBNull.Value, nCosto.ReadOnly);

				// nMonedaID
				nMonedaID.SetDbValue(rsnew, nMonedaID.CurrentValue, System.DBNull.Value, nMonedaID.ReadOnly);
				bool validMasterRecord;
				object keyValue, v;
				string masterFilter;

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

			// Add record

			#pragma warning disable 168, 219

			protected async Task<JsonBoolResult> AddRow(Dictionary<string, object> rsold = null) { // DN
				bool result = false;
				var rsnew = new Dictionary<string, object>();
				string masterFilter = "";

				// Set up foreign key field value from Session
				if (CurrentMasterTable == "PlanTratamiento") {
					nPlanTratamientoID.CurrentValue = nPlanTratamientoID.SessionValue;
				}
				bool validMasterRecord;

				// Load db values from rsold
				LoadDbValues(rsold);
				if (rsold != null) {
				}
				try {

					// nTratamientoID
					nTratamientoID.SetDbValue(rsnew, nTratamientoID.CurrentValue, 0, false);

					// dFechaTratamiento
					dFechaTratamiento.SetDbValue(rsnew, UnformatDateTime(dFechaTratamiento.CurrentValue, 0), DateTime.Now, false);

					// nCosto
					nCosto.SetDbValue(rsnew, nCosto.CurrentValue, System.DBNull.Value, false);

					// nMonedaID
					nMonedaID.SetDbValue(rsnew, nMonedaID.CurrentValue, System.DBNull.Value, false);

					// nPlanTratamientoID
					if (!Empty(nPlanTratamientoID.SessionValue)) {
						rsnew["nPlanTratamientoID"] = nPlanTratamientoID.SessionValue;
					}
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

				// Hide foreign keys
				string masterTblVar = CurrentMasterTable;
				if (masterTblVar == "PlanTratamiento") {
					nPlanTratamientoID.Visible = false;

					//if (PlanTratamiento.EventCancelled) EventCancelled = true;
					if (Get<bool>("mastereventcancelled"))
						EventCancelled = true;
				}
				DbMasterFilter = MasterFilter; // Get master filter
				DbDetailFilter = DetailFilter; // Get detail filter
			}

			// Setup lookup options
			public async Task SetupLookupOptions(DbField fld)
			{
				Func<string> lookupFilter = null;
				if (!Empty(fld.Lookup) && fld.Lookup.Options.Count == 0) {

					// Set up lookup SQL
					switch (fld.FieldVar) {
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
									case "x_nTratamientoID":

										//row[2] = FormatNumber(row[2], 2, -2, -2, -2);
										//row["df2"] = row[2];

										values = row.Values.ToList();
										row["df2"] = FormatNumber(values[2], 2, -2, -2, -2);
									break;
								}

								// Format the field values
								switch (fld.FieldVar) {
									case "x_nMonedaID":
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
