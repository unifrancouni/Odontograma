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
		/// ValorCatalogo_Grid
		/// </summary>

		public static _ValorCatalogo_Grid ValorCatalogo_Grid {
			get => HttpData.Get<_ValorCatalogo_Grid>("ValorCatalogo_Grid");
			set => HttpData["ValorCatalogo_Grid"] = value;
		}

		/// <summary>
		/// Page class for ValorCatalogo
		/// </summary>

		public class _ValorCatalogo_Grid : _ValorCatalogo_GridBase
		{

			// Construtor
			public _ValorCatalogo_Grid(Controller controller = null) : base(controller) {
			}
		}

		/// <summary>
		/// Page base class
		/// </summary>

		public class _ValorCatalogo_GridBase : _ValorCatalogo, IAspNetMakerPage
		{

			// Page ID
			public string PageID = "grid";

			// Project ID
			public string ProjectID = "{9B083C8B-EE2F-4356-BE8D-9A26D5707365}";

			// Table name
			public string TableName = "ValorCatalogo";

			// Page object name
			public string PageObjName = "ValorCatalogo_Grid";

			// Grid form hidden field names
			public string FormName = "fValorCatalogogrid";
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
			public _ValorCatalogo_GridBase(Controller controller = null) { // DN
				if (controller != null)
					Controller = controller;

				// Initialize
				FormActionName += "_" + FormName;
				FormKeyName += "_" + FormName;
				FormOldKeyName += "_" + FormName;
				FormBlankRowName += "_" + FormName;
				FormKeyCountName += "_" + FormName;
				TokenTimeout = SessionTimeoutTime();

				// Language object
				Language = Language ?? new Lang();

				// Table object (ValorCatalogo)
				if (ValorCatalogo == null || ValorCatalogo is _ValorCatalogo)
					ValorCatalogo = this;
				AddUrl = "ValorCatalogoadd";

				// Start time
				StartTime = Environment.TickCount;

				// Debug message
				LoadDebugMessage();

				// Open connection
				Conn = Connection; // DN

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
				key += UrlEncode(Convert.ToString(ar["nValorCatalogoID"]));
				return key;
			}

			// Hide fields for Add/Edit
			protected void HideFieldsForAddEdit() {
				if (IsAdd || IsCopy || IsGridAdd)
					nValorCatalogoID.Visible = false;
				if (IsAddOrEdit)
					dFechaCreacion.Visible = false;
				if (IsAddOrEdit)
					dFechaModificacion.Visible = false;
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
			public dynamic Pager;
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

			/// <summary>
			/// Page run
			/// </summary>
			/// <returns>Page result</returns>

			public async Task<IActionResult> Run() {

				// Header
				Header(Config.Cache);

				// Create form object
				CurrentForm = new HttpForm();

				// Get grid add count
				int gridaddcnt = Get<int>(Config.TableGridAddRowCount);
				if (gridaddcnt > 0)
					GridAddRowCount = gridaddcnt;

				// Set up list options
				await SetupListOptions();
				nValorCatalogoID.Visible = false;
				nCatalogoID.Visible = false;
				nCodigo.SetVisibility();
				sDescripcion.SetVisibility();
				nActivo.SetVisibility();
				dFechaCreacion.Visible = false;
				dFechaModificacion.Visible = false;
				nValorCatalogoUsuario.Visible = false;
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
				await SetupLookupOptions(nCatalogoID);

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
				}

				// Load Sorting Order
				if (Command != "json")
					LoadSortOrder();

				// Build filter
				filter = "";

				// Restore master/detail filter
				DbMasterFilter = MasterFilter; // Restore master filter
				DbDetailFilter = DetailFilter; // Restore detail filter
				AddFilter(ref filter, DbDetailFilter);
				AddFilter(ref filter, SearchWhere);

				// Load master record
				if (CurrentMode != "add" && !Empty(MasterFilter) && CurrentMasterTable == "Catalogo") {
					using (var rsmaster = await Catalogo.LoadRs(DbMasterFilter)) {
						MasterRecordExists = (rsmaster != null && await rsmaster.ReadAsync());
						if (!MasterRecordExists) {
							FailureMessage = Language.Phrase("NoRecord"); // Set no record found
							return Terminate("Catalogolist"); // Return to master page
						} else {
							Catalogo.LoadListRowValues(rsmaster);
						}
					}
					Catalogo.RowType = Config.RowTypeMaster; // Master row
					await Catalogo.RenderListRow(); // Note: Do it outside "using" // DN
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
				var selectLimit = UseSelectLimit;
				if (selectLimit)
					Recordset = await LoadRecordset(StartRecord - 1, DisplayRecords);

				// Set no record found message
				if (Empty(CurrentAction) && TotalRecords == 0) {
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
					ValorCatalogo.nValorCatalogoID.FormValue = arKeyFlds[0];
					if (!IsNumeric(ValorCatalogo.nValorCatalogoID.FormValue))
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
								key += nValorCatalogoID.CurrentValue;

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
				if (CurrentForm.HasValue("x_nCodigo") && CurrentForm.HasValue("o_nCodigo") && !SameString(nCodigo.CurrentValue, nCodigo.OldValue))
					return false;
				if (CurrentForm.HasValue("x_sDescripcion") && CurrentForm.HasValue("o_sDescripcion") && !SameString(sDescripcion.CurrentValue, sDescripcion.OldValue))
					return false;
				if (CurrentForm.HasValue("x_nActivo") && CurrentForm.HasValue("o_nActivo") && !SameString(nActivo.CurrentValue, nActivo.OldValue))
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
						nCatalogoID.SessionValue = "";
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
				item.Visible = true;
				item.OnLeft = true;

				// "edit"
				item = ListOptions.Add("edit");
				item.CssClass = "text-nowrap";
				item.Visible = true;
				item.OnLeft = true;

				// "copy"
				item = ListOptions.Add("copy");
				item.CssClass = "text-nowrap";
				item.Visible = true;
				item.OnLeft = true;

				// "delete"
				item = ListOptions.Add("delete");
				item.CssClass = "text-nowrap";
				item.Visible = true;
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
						listOption.Body = "<a class=\"ew-grid-link ew-grid-delete\" title=\"" + HtmlTitle(Language.Phrase("DeleteLink")) + "\" data-caption=\"" + HtmlTitle(Language.Phrase("DeleteLink")) + "\" onclick=\"return ew.deleteGridRow(this, " + RowIndex + ");\">" + Language.Phrase("DeleteLink") + "</a>";
					}
				}
				if (CurrentMode == "view") { // View mode

				// "view"
				listOption = ListOptions["view"];
				string viewcaption = HtmlTitle(Language.Phrase("ViewLink"));
				isVisible = true;
				if (isVisible) {
					listOption.Body = "<a class=\"ew-row-link ew-view\" title=\"" + viewcaption + "\" data-caption=\"" + viewcaption + "\" href=\"" + HtmlEncode(AppPath(ViewUrl)) + "\">" + Language.Phrase("ViewLink") + "</a>";
				} else {
					listOption.Body = "";
				}

				// "edit"
				listOption = ListOptions["edit"];
				string editcaption = HtmlTitle(Language.Phrase("EditLink"));
				isVisible = true;
				if (isVisible) {
					listOption.Body = "<a class=\"ew-row-link ew-edit\" title=\"" + editcaption + "\" data-caption=\"" + editcaption + "\" href=\"" + HtmlEncode(AppPath(EditUrl)) + "\">" + Language.Phrase("EditLink") + "</a>";
				} else {
					listOption.Body = "";
				}

				// "copy"
				listOption = ListOptions["copy"];
				string copycaption = HtmlTitle(Language.Phrase("CopyLink"));
				isVisible = true;
				if (isVisible) {
					listOption.Body = "<a class=\"ew-row-link ew-copy\" title=\"" + copycaption + "\" data-caption=\"" + copycaption + "\" href=\"" + HtmlEncode(AppPath(CopyUrl)) + "\">" + Language.Phrase("CopyLink") + "</a>";
				} else {
					listOption.Body = "";
				}

				// "delete"
				listOption = ListOptions["delete"];
				isVisible = true;
				if (isVisible)
					listOption.Body = "<a class=\"ew-row-link ew-delete\"" + "" + " title=\"" + HtmlTitle(Language.Phrase("DeleteLink")) + "\" data-caption=\"" + HtmlTitle(Language.Phrase("DeleteLink")) + "\" href=\"" + HtmlEncode(AppPath(DeleteUrl)) + "\">" + Language.Phrase("DeleteLink") + "</a>";
				else
					listOption.Body = "";
				} // End View mode
				if (CurrentMode == "edit" && IsNumeric(RowIndex)) {
					MultiSelectKey += "<input type=\"hidden\" name=\"" + keyName + "\" id=\"" + keyName + "\" value=\"" + nValorCatalogoID.CurrentValue + "\">";
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
				key += row["nValorCatalogoID"];
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
					item.Visible = (AddUrl != "");
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
						item.Visible = true;
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
				nValorCatalogoUsuario.OldValue = nValorCatalogoUsuario.CurrentValue;
			}

			#pragma warning disable 1998

			// Load form values
			protected async Task LoadFormValues() {
				CurrentForm.FormName = FormName;
				string val;

				// Check field name 'nCodigo' first before field var 'x_nCodigo'
				val = CurrentForm.GetValue("nCodigo", "x_nCodigo");
				if (!nCodigo.IsDetailKey) {
					if (IsApi() && val == null)
						nCodigo.Visible = false; // Disable update for API request
					else
						nCodigo.FormValue = val;
				}
				if (CurrentForm.HasValue("o_nCodigo"))
					nCodigo.OldValue = CurrentForm.GetValue("o_nCodigo");

				// Check field name 'sDescripcion' first before field var 'x_sDescripcion'
				val = CurrentForm.GetValue("sDescripcion", "x_sDescripcion");
				if (!sDescripcion.IsDetailKey) {
					if (IsApi() && val == null)
						sDescripcion.Visible = false; // Disable update for API request
					else
						sDescripcion.FormValue = val;
				}
				if (CurrentForm.HasValue("o_sDescripcion"))
					sDescripcion.OldValue = CurrentForm.GetValue("o_sDescripcion");

				// Check field name 'nActivo' first before field var 'x_nActivo'
				val = CurrentForm.GetValue("nActivo", "x_nActivo");
				if (!nActivo.IsDetailKey) {
					if (IsApi() && val == null)
						nActivo.Visible = false; // Disable update for API request
					else
						nActivo.FormValue = val;
				}
				if (CurrentForm.HasValue("o_nActivo"))
					nActivo.OldValue = CurrentForm.GetValue("o_nActivo");

				// Check field name 'nValorCatalogoID' first before field var 'x_nValorCatalogoID'
				val = CurrentForm.GetValue("nValorCatalogoID", "x_nValorCatalogoID");
				if (!nValorCatalogoID.IsDetailKey && !IsGridAdd && !IsAdd)
					nValorCatalogoID.FormValue = val;
			}

			#pragma warning restore 1998

			// Restore form values
			public void RestoreFormValues() {
				if (!IsGridAdd && !IsAdd)
					nValorCatalogoID.CurrentValue = nValorCatalogoID.FormValue;
				nCodigo.CurrentValue = nCodigo.FormValue;
				sDescripcion.CurrentValue = sDescripcion.FormValue;
				nActivo.CurrentValue = nActivo.FormValue;
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
				string[] arKeys = { RowOldKey };
				int cnt = arKeys.Length;
				if (cnt >= 1) {
					if (!Empty(arKeys[0]))
						nValorCatalogoID.CurrentValue = arKeys[0]; // nValorCatalogoID;
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

				// Call Row_Rendering event
				Row_Rendering();

				// Common render codes for all row types
				// nValorCatalogoID

				nValorCatalogoID.CellCssStyle = "white-space: nowrap;";

				// nCatalogoID
				nCatalogoID.CellCssStyle = "white-space: nowrap;";

				// nCodigo
				// sDescripcion
				// nActivo
				// dFechaCreacion

				dFechaCreacion.CellCssStyle = "white-space: nowrap;";

				// dFechaModificacion
				dFechaModificacion.CellCssStyle = "white-space: nowrap;";

				// nValorCatalogoUsuario
				nValorCatalogoUsuario.CellCssStyle = "white-space: nowrap;";
				if (RowType == Config.RowTypeView) { // View row

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

					// nCodigo
					nCodigo.EditAttrs["class"] = "form-control";
					nCodigo.EditValue = nCodigo.CurrentValue; // DN
					nCodigo.PlaceHolder = RemoveHtml(nCodigo.Caption);

					// sDescripcion
					sDescripcion.EditAttrs["class"] = "form-control";
					sDescripcion.EditValue = sDescripcion.CurrentValue; // DN
					sDescripcion.PlaceHolder = RemoveHtml(sDescripcion.Caption);

					// nActivo
					nActivo.EditAttrs["class"] = "form-control";
					nActivo.EditValue = nActivo.Options(true);

					// Add refer script
					// nCodigo

					nCodigo.HrefValue = "";

					// sDescripcion
					sDescripcion.HrefValue = "";

					// nActivo
					nActivo.HrefValue = "";
				} else if (RowType == Config.RowTypeEdit) { // Edit row

					// nCodigo
					nCodigo.EditAttrs["class"] = "form-control";
					nCodigo.EditValue = nCodigo.CurrentValue; // DN
					nCodigo.PlaceHolder = RemoveHtml(nCodigo.Caption);

					// sDescripcion
					sDescripcion.EditAttrs["class"] = "form-control";
					sDescripcion.EditValue = sDescripcion.CurrentValue; // DN
					sDescripcion.PlaceHolder = RemoveHtml(sDescripcion.Caption);

					// nActivo
					nActivo.EditAttrs["class"] = "form-control";
					nActivo.EditValue = nActivo.Options(true);

					// Edit refer script
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

			// Delete records (based on current filter)
			protected async Task<JsonBoolResult> DeleteRows() { // DN
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
				ValorCatalogo = ValorCatalogo ?? new _ValorCatalogo();
				var key = "";
				try {

					// Call Row Deleting event
					if (result)
						result = rsold.All(row => Row_Deleting(row));
					if (result) {
						foreach (var row in rsold) {
							var thisKey = "";
							if (!Empty(thisKey)) thisKey += Config.CompositeKeySeparator;
							thisKey += Convert.ToString(row["nValorCatalogoID"]);
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

				// nCodigo
				nCodigo.SetDbValue(rsnew, nCodigo.CurrentValue, 0, nCodigo.ReadOnly);

				// sDescripcion
				sDescripcion.SetDbValue(rsnew, sDescripcion.CurrentValue, "", sDescripcion.ReadOnly);

				// nActivo
				nActivo.SetDbValue(rsnew, nActivo.CurrentValue, 0, nActivo.ReadOnly);
				bool validMasterRecord;
				object keyValue, v;
				string masterFilter;

				// Check referential integrity for master table 'Catalogo'
				validMasterRecord = true;
				masterFilter = SqlMasterFilter("Catalogo");
				keyValue = rsnew.TryGetValue("nCatalogoID", out v) ? v : rsold["nCatalogoID"];
				if (!Empty(keyValue)) {
					masterFilter = masterFilter.Replace("@nCatalogoID@", AdjustSql(keyValue));
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
				if (CurrentMasterTable == "Catalogo") {
					nCatalogoID.CurrentValue = nCatalogoID.SessionValue;
				}
				bool validMasterRecord;

				// Check referential integrity for master table 'Catalogo'
				validMasterRecord = true;
				masterFilter = SqlMasterFilter("Catalogo");
				if (!Empty(nCatalogoID.SessionValue)) {
					masterFilter = masterFilter.Replace("@nCatalogoID@", AdjustSql(nCatalogoID.SessionValue, "DB"));
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

					// nCodigo
					nCodigo.SetDbValue(rsnew, nCodigo.CurrentValue, 0, false);

					// sDescripcion
					sDescripcion.SetDbValue(rsnew, sDescripcion.CurrentValue, "", false);

					// nActivo
					nActivo.SetDbValue(rsnew, nActivo.CurrentValue, 0, false);

					// nCatalogoID
					if (!Empty(nCatalogoID.SessionValue)) {
						rsnew["nCatalogoID"] = nCatalogoID.SessionValue;
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
				if (masterTblVar == "Catalogo") {
					nCatalogoID.Visible = false;

					//if (Catalogo.EventCancelled) EventCancelled = true;
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
						case "x_nCatalogoID":
							lookupFilter = () => "nCatalogoUsuario=1";
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
