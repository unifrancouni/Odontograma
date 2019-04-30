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

// Models (Table)
namespace AspNetMaker2019.Models {

	// Partial class
	public partial class prjSIGECO {

		/// <summary>
		/// Paciente
		/// </summary>

		public static _Paciente Paciente {
			get => HttpData.GetOrCreate<_Paciente>("Paciente");
			set => HttpData["Paciente"] = value;
		}

		/// <summary>
		/// Table class for Paciente
		/// </summary>

		public class _Paciente: DbTable {
			public int RowCnt = 0; // DN
			public bool UseSessionForListSql = true;

			// Column CSS classes
			public string LeftColumnClass = "col-sm-2 col-form-label ew-label";
			public string RightColumnClass = "col-sm-10";
			public string OffsetColumnClass = "col-sm-10 offset-sm-2";
			public string TableLeftColumnClass = "w-col-2";
			public readonly DbField<SqlDbType> nPacienteID;
			public readonly DbField<SqlDbType> nCodigo;
			public readonly DbField<SqlDbType> sNombre;
			public readonly DbField<SqlDbType> sApellido1;
			public readonly DbField<SqlDbType> sApellido2;
			public readonly DbField<SqlDbType> nGeneroID;
			public readonly DbField<SqlDbType> sLugarNacimiento;
			public readonly DbField<SqlDbType> dFechaNacimiento;
			public readonly DbField<SqlDbType> sDireccion;
			public readonly DbField<SqlDbType> sCedula;
			public readonly DbField<SqlDbType> sTelefono;
			public readonly DbField<SqlDbType> sEmergenciaNombre;
			public readonly DbField<SqlDbType> sEmergenciaParentesco;
			public readonly DbField<SqlDbType> sEmergenciaTelefono;
			public readonly DbField<SqlDbType> nActivo;
			public readonly DbField<SqlDbType> dFechaCreacion;
			public readonly DbField<SqlDbType> dFechaModificacion;

			// Constructor
			public _Paciente() {

				// Language object // DN
				Language = Language ?? new Lang();
				TableVar = "Paciente";
				Name = "Paciente";
				Type = "TABLE";

				// Update Table
				UpdateTable = "[dbo].[Paciente]";
				DbId = "DB"; // DN
				ExportAll = true;
				ExportPageBreakCount = 0; // Page break per every n record (PDF only)
				ExportPageOrientation = "portrait"; // Page orientation (PDF only)
				ExportPageSize = "a4"; // Page size (PDF only)
				ExportExcelPageOrientation = ""; // Page orientation (EPPlus only)
				ExportExcelPageSize = ""; // Page size (EPPlus only)
				ExportColumnWidths = new float[] {  }; // Column widths (PDF only) // DN
				DetailAdd = true; // Allow detail add
				DetailEdit = false; // Allow detail edit
				DetailView = false; // Allow detail view
				ShowMultipleDetails = false; // Show multiple details
				GridAddRowCount = 5;
				AllowAddDeleteRow = true; // Allow add/delete row
				UserIdAllowSecurity = 0; // User ID Allow
				BasicSearch = new BasicSearch(TableVar);

				// nPacienteID
				nPacienteID = new DbField<SqlDbType> {
					TableVar = "Paciente",
					TableName = "Paciente",
					FieldVar = "x_nPacienteID",
					Name = "nPacienteID",
					Expression = "[nPacienteID]",
					BasicSearchExpression = "CAST([nPacienteID] AS NVARCHAR)",
					Type = 3,
					DbType = SqlDbType.Int,
					DateTimeFormat = -1,
					VirtualExpression = "[nPacienteID]",
					IsVirtual = false,
					ForceSelection = false,
					SelectMultiple = false,
					VirtualSearch = false,
					ViewTag = "FORMATTED TEXT",
					HtmlTag = "NO",
					IsAutoIncrement = true, // Autoincrement field
					IsPrimaryKey = true, // Primary key field
					IsForeignKey = true, // Foreign key field
					Nullable = false, // NOT NULL field
					Sortable = false, // Allow sort
					DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
					IsUpload = false
				};
				nPacienteID.Init(this); // DN
				Fields.Add("nPacienteID", nPacienteID);

				// nCodigo
				nCodigo = new DbField<SqlDbType> {
					TableVar = "Paciente",
					TableName = "Paciente",
					FieldVar = "x_nCodigo",
					Name = "nCodigo",
					Expression = "[nCodigo]",
					BasicSearchExpression = "CAST([nCodigo] AS NVARCHAR)",
					Type = 3,
					DbType = SqlDbType.Int,
					DateTimeFormat = -1,
					VirtualExpression = "[nCodigo]",
					IsVirtual = false,
					ForceSelection = false,
					SelectMultiple = false,
					VirtualSearch = false,
					ViewTag = "FORMATTED TEXT",
					HtmlTag = "TEXT",
					Nullable = false, // NOT NULL field
					Required = true, // Required field
					Sortable = true, // Allow sort
					DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
					IsUpload = false
				};
				nCodigo.Init(this); // DN
				Fields.Add("nCodigo", nCodigo);

				// sNombre
				sNombre = new DbField<SqlDbType> {
					TableVar = "Paciente",
					TableName = "Paciente",
					FieldVar = "x_sNombre",
					Name = "sNombre",
					Expression = "[sNombre]",
					BasicSearchExpression = "[sNombre]",
					Type = 200,
					DbType = SqlDbType.VarChar,
					DateTimeFormat = -1,
					VirtualExpression = "[sNombre]",
					IsVirtual = false,
					ForceSelection = false,
					SelectMultiple = false,
					VirtualSearch = false,
					ViewTag = "FORMATTED TEXT",
					HtmlTag = "TEXT",
					Nullable = false, // NOT NULL field
					Required = true, // Required field
					Sortable = true, // Allow sort
					IsUpload = false
				};
				sNombre.Init(this); // DN
				Fields.Add("sNombre", sNombre);

				// sApellido1
				sApellido1 = new DbField<SqlDbType> {
					TableVar = "Paciente",
					TableName = "Paciente",
					FieldVar = "x_sApellido1",
					Name = "sApellido1",
					Expression = "[sApellido1]",
					BasicSearchExpression = "[sApellido1]",
					Type = 200,
					DbType = SqlDbType.VarChar,
					DateTimeFormat = -1,
					VirtualExpression = "[sApellido1]",
					IsVirtual = false,
					ForceSelection = false,
					SelectMultiple = false,
					VirtualSearch = false,
					ViewTag = "FORMATTED TEXT",
					HtmlTag = "TEXT",
					Nullable = false, // NOT NULL field
					Required = true, // Required field
					Sortable = true, // Allow sort
					IsUpload = false
				};
				sApellido1.Init(this); // DN
				Fields.Add("sApellido1", sApellido1);

				// sApellido2
				sApellido2 = new DbField<SqlDbType> {
					TableVar = "Paciente",
					TableName = "Paciente",
					FieldVar = "x_sApellido2",
					Name = "sApellido2",
					Expression = "[sApellido2]",
					BasicSearchExpression = "[sApellido2]",
					Type = 200,
					DbType = SqlDbType.VarChar,
					DateTimeFormat = -1,
					VirtualExpression = "[sApellido2]",
					IsVirtual = false,
					ForceSelection = false,
					SelectMultiple = false,
					VirtualSearch = false,
					ViewTag = "FORMATTED TEXT",
					HtmlTag = "TEXT",
					Sortable = true, // Allow sort
					IsUpload = false
				};
				sApellido2.Init(this); // DN
				Fields.Add("sApellido2", sApellido2);

				// nGeneroID
				nGeneroID = new DbField<SqlDbType> {
					TableVar = "Paciente",
					TableName = "Paciente",
					FieldVar = "x_nGeneroID",
					Name = "nGeneroID",
					Expression = "[nGeneroID]",
					BasicSearchExpression = "CAST([nGeneroID] AS NVARCHAR)",
					Type = 3,
					DbType = SqlDbType.Int,
					DateTimeFormat = -1,
					VirtualExpression = "[nGeneroID]",
					IsVirtual = false,
					ForceSelection = false,
					SelectMultiple = false,
					VirtualSearch = false,
					ViewTag = "FORMATTED TEXT",
					HtmlTag = "SELECT",
					Nullable = false, // NOT NULL field
					Required = true, // Required field
					Sortable = true, // Allow sort
					UsePleaseSelect = true, // Use PleaseSelect by default
					PleaseSelectText = Language.Phrase("PleaseSelect"), // PleaseSelect text
					DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
					IsUpload = false
				};
				nGeneroID.Init(this); // DN
				switch (CurrentLanguage) {
					case "en":
						nGeneroID.Lookup = new Lookup<DbField>("nGeneroID", "ValorCatalogo", true, "nValorCatalogoID", new List<string> {"nCodigo", "sDescripcion", "", ""}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "[nCodigo] ASC", "");
						break;
					default:
						nGeneroID.Lookup = new Lookup<DbField>("nGeneroID", "ValorCatalogo", true, "nValorCatalogoID", new List<string> {"nCodigo", "sDescripcion", "", ""}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "[nCodigo] ASC", "");
						break;
				}
				nGeneroID.GetSelectFilter = () => "nCatalogoID=7";
				Fields.Add("nGeneroID", nGeneroID);

				// sLugarNacimiento
				sLugarNacimiento = new DbField<SqlDbType> {
					TableVar = "Paciente",
					TableName = "Paciente",
					FieldVar = "x_sLugarNacimiento",
					Name = "sLugarNacimiento",
					Expression = "[sLugarNacimiento]",
					BasicSearchExpression = "[sLugarNacimiento]",
					Type = 200,
					DbType = SqlDbType.VarChar,
					DateTimeFormat = -1,
					VirtualExpression = "[sLugarNacimiento]",
					IsVirtual = false,
					ForceSelection = false,
					SelectMultiple = false,
					VirtualSearch = false,
					ViewTag = "FORMATTED TEXT",
					HtmlTag = "TEXT",
					Nullable = false, // NOT NULL field
					Required = true, // Required field
					Sortable = true, // Allow sort
					IsUpload = false
				};
				sLugarNacimiento.Init(this); // DN
				Fields.Add("sLugarNacimiento", sLugarNacimiento);

				// dFechaNacimiento
				dFechaNacimiento = new DbField<SqlDbType> {
					TableVar = "Paciente",
					TableName = "Paciente",
					FieldVar = "x_dFechaNacimiento",
					Name = "dFechaNacimiento",
					Expression = "[dFechaNacimiento]",
					BasicSearchExpression = CastDateFieldForLike("[dFechaNacimiento]", 0, "DB"),
					Type = 133,
					DbType = SqlDbType.DateTime,
					DateTimeFormat = 0,
					VirtualExpression = "[dFechaNacimiento]",
					IsVirtual = false,
					ForceSelection = false,
					SelectMultiple = false,
					VirtualSearch = false,
					ViewTag = "FORMATTED TEXT",
					HtmlTag = "TEXT",
					Nullable = false, // NOT NULL field
					Required = true, // Required field
					Sortable = true, // Allow sort
					DefaultErrorMessage = Language.Phrase("IncorrectDate").Replace("%s", DateFormat),
					IsUpload = false
				};
				dFechaNacimiento.Init(this); // DN
				Fields.Add("dFechaNacimiento", dFechaNacimiento);

				// sDireccion
				sDireccion = new DbField<SqlDbType> {
					TableVar = "Paciente",
					TableName = "Paciente",
					FieldVar = "x_sDireccion",
					Name = "sDireccion",
					Expression = "[sDireccion]",
					BasicSearchExpression = "[sDireccion]",
					Type = 200,
					DbType = SqlDbType.VarChar,
					DateTimeFormat = -1,
					VirtualExpression = "[sDireccion]",
					IsVirtual = false,
					ForceSelection = false,
					SelectMultiple = false,
					VirtualSearch = false,
					ViewTag = "FORMATTED TEXT",
					HtmlTag = "TEXT",
					Sortable = false, // Allow sort
					IsUpload = false
				};
				sDireccion.Init(this); // DN
				Fields.Add("sDireccion", sDireccion);

				// sCedula
				sCedula = new DbField<SqlDbType> {
					TableVar = "Paciente",
					TableName = "Paciente",
					FieldVar = "x_sCedula",
					Name = "sCedula",
					Expression = "[sCedula]",
					BasicSearchExpression = "[sCedula]",
					Type = 200,
					DbType = SqlDbType.VarChar,
					DateTimeFormat = -1,
					VirtualExpression = "[sCedula]",
					IsVirtual = false,
					ForceSelection = false,
					SelectMultiple = false,
					VirtualSearch = false,
					ViewTag = "FORMATTED TEXT",
					HtmlTag = "TEXT",
					Nullable = false, // NOT NULL field
					Required = true, // Required field
					Sortable = true, // Allow sort
					IsUpload = false
				};
				sCedula.Init(this); // DN
				Fields.Add("sCedula", sCedula);

				// sTelefono
				sTelefono = new DbField<SqlDbType> {
					TableVar = "Paciente",
					TableName = "Paciente",
					FieldVar = "x_sTelefono",
					Name = "sTelefono",
					Expression = "[sTelefono]",
					BasicSearchExpression = "[sTelefono]",
					Type = 200,
					DbType = SqlDbType.VarChar,
					DateTimeFormat = -1,
					VirtualExpression = "[sTelefono]",
					IsVirtual = false,
					ForceSelection = false,
					SelectMultiple = false,
					VirtualSearch = false,
					ViewTag = "FORMATTED TEXT",
					HtmlTag = "TEXT",
					Sortable = true, // Allow sort
					IsUpload = false
				};
				sTelefono.Init(this); // DN
				Fields.Add("sTelefono", sTelefono);

				// sEmergenciaNombre
				sEmergenciaNombre = new DbField<SqlDbType> {
					TableVar = "Paciente",
					TableName = "Paciente",
					FieldVar = "x_sEmergenciaNombre",
					Name = "sEmergenciaNombre",
					Expression = "[sEmergenciaNombre]",
					BasicSearchExpression = "[sEmergenciaNombre]",
					Type = 200,
					DbType = SqlDbType.VarChar,
					DateTimeFormat = -1,
					VirtualExpression = "[sEmergenciaNombre]",
					IsVirtual = false,
					ForceSelection = false,
					SelectMultiple = false,
					VirtualSearch = false,
					ViewTag = "FORMATTED TEXT",
					HtmlTag = "TEXT",
					Sortable = true, // Allow sort
					IsUpload = false
				};
				sEmergenciaNombre.Init(this); // DN
				Fields.Add("sEmergenciaNombre", sEmergenciaNombre);

				// sEmergenciaParentesco
				sEmergenciaParentesco = new DbField<SqlDbType> {
					TableVar = "Paciente",
					TableName = "Paciente",
					FieldVar = "x_sEmergenciaParentesco",
					Name = "sEmergenciaParentesco",
					Expression = "[sEmergenciaParentesco]",
					BasicSearchExpression = "[sEmergenciaParentesco]",
					Type = 200,
					DbType = SqlDbType.VarChar,
					DateTimeFormat = -1,
					VirtualExpression = "[sEmergenciaParentesco]",
					IsVirtual = false,
					ForceSelection = false,
					SelectMultiple = false,
					VirtualSearch = false,
					ViewTag = "FORMATTED TEXT",
					HtmlTag = "TEXT",
					Sortable = true, // Allow sort
					IsUpload = false
				};
				sEmergenciaParentesco.Init(this); // DN
				Fields.Add("sEmergenciaParentesco", sEmergenciaParentesco);

				// sEmergenciaTelefono
				sEmergenciaTelefono = new DbField<SqlDbType> {
					TableVar = "Paciente",
					TableName = "Paciente",
					FieldVar = "x_sEmergenciaTelefono",
					Name = "sEmergenciaTelefono",
					Expression = "[sEmergenciaTelefono]",
					BasicSearchExpression = "[sEmergenciaTelefono]",
					Type = 200,
					DbType = SqlDbType.VarChar,
					DateTimeFormat = -1,
					VirtualExpression = "[sEmergenciaTelefono]",
					IsVirtual = false,
					ForceSelection = false,
					SelectMultiple = false,
					VirtualSearch = false,
					ViewTag = "FORMATTED TEXT",
					HtmlTag = "TEXT",
					Sortable = true, // Allow sort
					IsUpload = false
				};
				sEmergenciaTelefono.Init(this); // DN
				Fields.Add("sEmergenciaTelefono", sEmergenciaTelefono);

				// nActivo
				nActivo = new DbField<SqlDbType> {
					TableVar = "Paciente",
					TableName = "Paciente",
					FieldVar = "x_nActivo",
					Name = "nActivo",
					Expression = "[nActivo]",
					BasicSearchExpression = "[nActivo]",
					Type = 11,
					DbType = SqlDbType.Bit,
					DateTimeFormat = -1,
					VirtualExpression = "[nActivo]",
					IsVirtual = false,
					ForceSelection = false,
					SelectMultiple = false,
					VirtualSearch = false,
					ViewTag = "FORMATTED TEXT",
					HtmlTag = "CHECKBOX",
					Nullable = false, // NOT NULL field
					Sortable = false, // Allow sort
					DataType = Config.DataTypeBoolean,
					OptionCount = 2,
					IsUpload = false
				};
				nActivo.Init(this); // DN
				switch (CurrentLanguage) {
					case "en":
						nActivo.Lookup = new Lookup<DbField>("nActivo", "Paciente", false, "", new List<string> {"", "", "", ""}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "");
						break;
					default:
						nActivo.Lookup = new Lookup<DbField>("nActivo", "Paciente", false, "", new List<string> {"", "", "", ""}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "");
						break;
				}
				Fields.Add("nActivo", nActivo);

				// dFechaCreacion
				dFechaCreacion = new DbField<SqlDbType> {
					TableVar = "Paciente",
					TableName = "Paciente",
					FieldVar = "x_dFechaCreacion",
					Name = "dFechaCreacion",
					Expression = "[dFechaCreacion]",
					BasicSearchExpression = CastDateFieldForLike("[dFechaCreacion]", 0, "DB"),
					Type = 133,
					DbType = SqlDbType.DateTime,
					DateTimeFormat = 0,
					VirtualExpression = "[dFechaCreacion]",
					IsVirtual = false,
					ForceSelection = false,
					SelectMultiple = false,
					VirtualSearch = false,
					ViewTag = "FORMATTED TEXT",
					HtmlTag = "TEXT",
					Sortable = false, // Allow sort
					DefaultErrorMessage = Language.Phrase("IncorrectDate").Replace("%s", DateFormat),
					IsUpload = false
				};
				dFechaCreacion.Init(this); // DN
				dFechaCreacion.GetAutoUpdateValue = () => CurrentDateTime();
				Fields.Add("dFechaCreacion", dFechaCreacion);

				// dFechaModificacion
				dFechaModificacion = new DbField<SqlDbType> {
					TableVar = "Paciente",
					TableName = "Paciente",
					FieldVar = "x_dFechaModificacion",
					Name = "dFechaModificacion",
					Expression = "[dFechaModificacion]",
					BasicSearchExpression = CastDateFieldForLike("[dFechaModificacion]", 0, "DB"),
					Type = 133,
					DbType = SqlDbType.DateTime,
					DateTimeFormat = 0,
					VirtualExpression = "[dFechaModificacion]",
					IsVirtual = false,
					ForceSelection = false,
					SelectMultiple = false,
					VirtualSearch = false,
					ViewTag = "FORMATTED TEXT",
					HtmlTag = "TEXT",
					Sortable = false, // Allow sort
					DefaultErrorMessage = Language.Phrase("IncorrectDate").Replace("%s", DateFormat),
					IsUpload = false
				};
				dFechaModificacion.Init(this); // DN
				dFechaModificacion.GetAutoUpdateValue = () => CurrentDateTime();
				Fields.Add("dFechaModificacion", dFechaModificacion);
			}

			// Set Field Visibility
			public override bool GetFieldVisibility(string fldname) {
				var fld = FieldByName(fldname);
				return fld.Visible; // Returns original value
			}

			// Invoke method // DN
			public object Invoke(string name, object[] parameters = null) {
				MethodInfo mi = this.GetType().GetMethod(name);
				if (mi != null) {
					if (IsAsyncMethod(mi)) {
						return InvokeAsync(mi, parameters).GetAwaiter().GetResult();
					} else {
						return mi.Invoke(this, parameters);
					}
				}
				return null;
			}

			// Invoke async method // DN
			public async Task<object> InvokeAsync(MethodInfo mi, object[] parameters = null) {
				if (mi != null) {
					dynamic awaitable = mi.Invoke(this, parameters);
					await awaitable;
					return awaitable.GetAwaiter().GetResult();
				}
				return null;
			}

			#pragma warning disable 1998

			// Invoke async method // DN
			public async Task<object> InvokeAsync(string name, object[] parameters = null) => InvokeAsync(this.GetType().GetMethod(name), parameters);

			#pragma warning restore 1998

			// Check if Invoke async method // DN
			public bool IsAsyncMethod(MethodInfo mi) {
				if (mi != null) {
					Type attType = typeof(AsyncStateMachineAttribute);
					var attrib = (AsyncStateMachineAttribute)mi.GetCustomAttribute(attType);
					return (attrib != null);
				}
				return false;
			}

			// Check if Invoke async method // DN
			public bool IsAsyncMethod(string name) => IsAsyncMethod(this.GetType().GetMethod(name));

			#pragma warning disable 618

			// Connection
			public virtual DatabaseConnectionBase<SqlConnection, SqlCommand, SqlDataReader, SqlDbType> Connection => GetConnection(DbId);

			#pragma warning restore 618

			// Set left column class (must be predefined col-*-* classes of Bootstrap grid system)
			public void SetLeftColumnClass(string columnClass) {
				Match m = Regex.Match(columnClass, @"^col\-(\w+)\-(\d+)$");
				if (m.Success) {
					LeftColumnClass = columnClass + " col-form-label ew-label";
					RightColumnClass = "col-" + m.Groups[1].Value + "-" + Convert.ToString(12 - ConvertToInt(m.Groups[2].Value));
					OffsetColumnClass = RightColumnClass + " " + columnClass.Replace("col-", "offset-");
					TableLeftColumnClass = Regex.Replace(columnClass, @"/^col-\w+-(\d+)$/", "w-col-$1"); // Change to w-col-*
				}
			}

			// Single column sort
			public void UpdateSort(DbField fld) {
				string lastSort, sortField, thisSort;
				if (CurrentOrder == fld.Name) {
					sortField = fld.Expression;
					lastSort = fld.Sort;
					if (CurrentOrderType == "ASC" || CurrentOrderType == "DESC") {
						thisSort = CurrentOrderType;
					} else {
						thisSort = (lastSort == "ASC") ? "DESC" : "ASC";
					}
					fld.Sort = thisSort;
					SessionOrderBy = sortField + " " + thisSort; // Save to Session
				} else {
					fld.Sort = "";
				}
			}

			// Current detail table name
			public string CurrentDetailTable {
				get => Session.GetString(Config.ProjectName + "_" + TableVar + "_" + Config.TableDetailTable);
				set => Session[Config.ProjectName + "_" + TableVar + "_" + Config.TableDetailTable] = value;
			}

			// List of current detail table names
			public List<string> CurrentDetailTables => CurrentDetailTable.Split(',').ToList();

			// Get detail URL
			public string DetailUrl {
				get {
					string detailUrl = "";
					if (CurrentDetailTable == "Expediente") {
						detailUrl = Expediente.ListUrl + "?" + Config.TableShowMaster + "=" + TableVar;
						detailUrl += "&fk_nPacienteID=" + UrlEncode(nPacienteID.CurrentValue);
					}
					if (Empty(detailUrl))
						detailUrl = "Pacientelist";
					return detailUrl;
				}
			}

			// WHERE // DN
			private string _sqlWhere = null;
			public string SqlWhere {
				get {
					string where = "";
					return _sqlWhere ?? where;
				}
				set {
					_sqlWhere = value;
				}
			}

			// Group By
			private string _sqlGroupBy = null;
			public string SqlGroupBy {
				get => _sqlGroupBy ?? "";
				set => _sqlGroupBy = value;
			}

			// Having
			private string _sqlHaving = null;
			public string SqlHaving {
				get => _sqlHaving ?? "";
				set => _sqlHaving = value;
			}

			// Apply User ID filters
			public string ApplyUserIDFilters(string filter) {
				return filter;
			}

			// Check if User ID security allows view all
			public bool UserIDAllow(string id = "") {
				int allow = Config.UserIdAllow;
				switch (id) {
					case "add":
					case "copy":
					case "gridadd":
					case "register":
					case "addopt":
						return ((allow & 1) == 1);
					case "edit":
					case "gridedit":
					case "update":
					case "changepwd":
					case "forgotpwd":
						return ((allow & 4) == 4);
					case "delete":
						return ((allow & 2) == 2);
					case "view":
						return ((allow & 32) == 32);
					case "search":
						return ((allow & 64) == 64);
					default:
						return ((allow & 8) == 8);
				}
			}

			// Get record count by reading data reader
			public async Task<int> GetRecordCount(string sql) { // use by Lookup // DN
				try {
					var cnt = 0;
					using (var dr = await Connection.OpenDataReaderAsync(sql)) {
						while (await dr.ReadAsync())
							cnt++;
					}
					return cnt;
				} catch {
					if (Config.Debug)
						throw;
					return -1;
				}
			}

			// Try to get record count by SELECT COUNT(*)
			public async Task<int> TryGetRecordCount(string sql) {
				string orderBy = OrderBy;
				sql = Regex.Replace(sql, @"/\*BeginOrderBy\*/[\s\S]+/\*EndOrderBy\*/", "", RegexOptions.IgnoreCase).Trim(); // Remove ORDER BY clause (MSSQL)
				if (!string.IsNullOrEmpty(orderBy) && sql.EndsWith(orderBy))
					sql = sql.Substring(0, sql.Length - orderBy.Length); // Remove ORDER BY clause
				try {
					string sqlcnt;
					if ((new List<string> { "TABLE", "VIEW", "LINKTABLE" }).Contains(Type) && sql.StartsWith(SqlSelect)) { // Handle Custom Field
						sqlcnt = "SELECT COUNT(*) FROM " + SqlFrom + sql.Substring(SqlSelect.Length);
					} else {
						sqlcnt = "SELECT COUNT(*) FROM (" + sql + ") EW_COUNT_TABLE";
					}
					return Convert.ToInt32(await Connection.ExecuteScalarAsync(sqlcnt));
				} catch {
					return await GetRecordCount(sql);
				}
			}

			// Get ORDER BY clause
			public string OrderBy {
				get {
					string sort = SessionOrderBy;
					return BuildSelectSql("", "", "", "", SqlOrderBy, "", sort);
				}
			}

			// SELECT
			private string _sqlSelect = null;
			public string SqlSelect { // Select
				get => _sqlSelect ?? "SELECT * FROM " + SqlFrom;
				set => _sqlSelect = value;
			}

			// Table level SQL
			// FROM

			private string _sqlFrom = null;
			public string SqlFrom {
				get => _sqlFrom ?? "[dbo].[Paciente]";
				set => _sqlFrom = value;
			}

			// Order By
			private string _sqlOrderBy = null;
			public string SqlOrderBy {
				get => _sqlOrderBy ?? "";
				set => _sqlOrderBy = value;
			}

			// Get SQL
			public string GetSql(string where, string orderBy = "") => BuildSelectSql(SqlSelect, SqlWhere, SqlGroupBy, SqlHaving, SqlOrderBy, where, orderBy);

			// Table SQL
			public string CurrentSql {
				get {
					string filter = CurrentFilter;
					string sort = SessionOrderBy;
					return GetSql(filter, sort);
				}
			}

			// Table SQL with List page filter
			public string ListSql {
				get {
					string sort = "";
					string select = "";
					string filter = UseSessionForListSql ? SessionWhere : "";
					AddFilter(ref filter, CurrentFilter);
					Recordset_Selecting(ref filter);
					select = SqlSelect;
					sort = UseSessionForListSql ? SessionOrderBy : "";
					return BuildSelectSql(select, SqlWhere, SqlGroupBy, SqlHaving, SqlOrderBy, filter, sort);
				}
			}

			// Get record count based on filter (for detail record count in master table pages)
			public async Task<int> LoadRecordCount(string filter) => await TryGetRecordCount(GetSql(filter));

			// Get record count (for current List page)
			public async Task<int> ListRecordCount() => await TryGetRecordCount(ListSql);

			// Insert
			public async Task<int> InsertAsync(Dictionary<string, object> row) {
				int result;
				var r = row.Where(kvp => {
					var fld = FieldByName(kvp.Key);
					return (fld != null && !fld.IsCustom);
				}).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
				var fields = r.Select(kvp => Fields[kvp.Key]);
				var names = String.Join(",", fields.Select(fld => fld.Expression));
				var values = String.Join(",", fields.Select(fld => SqlParameter(fld)));
				if (Empty(names))
					return -1;
				string sql = "INSERT INTO " + UpdateTable + " (" + names + ") VALUES (" + values + ")";
				using (var command = Connection.GetCommand(sql)) {
					foreach (var (key, value) in r) {
						var fld = (DbField<SqlDbType>)Fields[key]; // DN
						try {
							command.Parameters.Add(fld.FieldVar, fld.DbType).Value = ParameterValue(fld, value);
						} catch {
							if (Config.Debug)
								throw;
						}
					}
					result = await command.ExecuteNonQueryAsync();
				}
				if (result > 0) {

					// Get insert ID
					nPacienteID.SetDbValue(await Connection.GetLastInsertIdAsync());
					row["nPacienteID"] = nPacienteID.DbValue;
				}
				return result;
			}

			// Insert
			public int Insert(Dictionary<string, object> row) => InsertAsync(row).GetAwaiter().GetResult();

			// Update

			#pragma warning disable 168, 219

			public async Task<int> UpdateAsync(Dictionary<string, object> row, object where = null, Dictionary<string, object> rsold = null, bool curfilter = true) {
				int result;
				bool cascadeUpdate = false;
				DbDataReader drwrk;
				var rskey = new Dictionary<string, object>();
				int updateResult;
				var rscascade = new Dictionary<string, object>();
				string whereClause = "";
				row = row.Where(kvp => {
					var fld = FieldByName(kvp.Key);
					return fld != null && !fld.IsCustom;
				}).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
				var fields = row.Select(kvp => Fields[kvp.Key]);
				var values = String.Join(",", fields.Select(fld => fld.Expression + "=" + SqlParameter(fld)));
				if (Empty(values))
					return -1;
				string sql = "UPDATE " + UpdateTable + " SET " + values;
				string filter = curfilter ? CurrentFilter : "";
				if (IsDictionary(where))
					whereClause = ArrayToFilter((IDictionary<string, object>)where);
				else
					whereClause = (string)where;
				AddFilter(ref filter, whereClause);
				if (!Empty(filter))
					sql += " WHERE " + filter;
				using (var command = Connection.GetCommand(sql)) {
					foreach (var (key, value) in row) {
						var fld = (DbField<SqlDbType>)Fields[key]; // DN
						try {
							command.Parameters.Add(fld.FieldVar, fld.DbType).Value = ParameterValue(fld, value);
						} catch {
							if (Config.Debug)
								throw;
						}
					}
					result = await command.ExecuteNonQueryAsync();
				}
				return result;
			}

			#pragma warning restore 168, 219

			// Update
			public int Update(Dictionary<string, object> row, object where = null, Dictionary<string, object> rsold = null, bool curfilter = true)
				=> UpdateAsync(row, where, rsold, curfilter).GetAwaiter().GetResult();

			// Convert to parameter name for use in SQL
			public string SqlParameter(DbField fld) {
				string symbol = GetSqlParamSymbol(DbId);
				string value = symbol;
				if (symbol != "?")
					value += fld.FieldVar;
				return value;
			}

			// Convert value to object for parameter
			public object ParameterValue(DbField fld, object value) {
				if (((DbField<SqlDbType>)fld).DbType == SqlDbType.Bit) {
					return ConvertToBool(value);
				}
				return value;
			}

			#pragma warning disable 168, 1998

			// Delete
			public async Task<int> DeleteAsync(Dictionary<string, object> row, object where = null, bool curfilter = true) {
				bool delete = true;
				string whereClause = "";
				DbDataReader drwrk;
				List<Dictionary<string, object>> dtlrows;
				string sql = "DELETE FROM " + UpdateTable + " WHERE ";
				string filter = curfilter ? CurrentFilter : "";
				if (IsDictionary(where))
					whereClause = ArrayToFilter((IDictionary<string, object>)where);
				else
					whereClause = (string)where;
				AddFilter(ref filter, whereClause);
				if (row != null) {
					DbField fld;
					fld = FieldByName("nPacienteID");
					AddFilter(ref filter, fld.Expression + "=" + QuotedValue(row["nPacienteID"], FieldByName("nPacienteID").DataType, DbId));
				}
				if (!Empty(filter))
					sql += filter;
				else
					sql += "0=1"; // Avoid delete
				int result = -1;
				if (delete)
					result = await Connection.ExecuteAsync(sql);
				return result;
			}

			#pragma warning restore 168, 1998

			// Delete
			public int Delete(Dictionary<string, object> row, object where = null, bool curfilter = true) =>
				DeleteAsync(row, where, curfilter).GetAwaiter().GetResult();

			// Load DbValue from recordset
			public void LoadDbValues(Dictionary<string, object> row) {
				if (row == null)
					return;
				nPacienteID.SetDbValue(row["nPacienteID"], false);
				nCodigo.SetDbValue(row["nCodigo"], false);
				sNombre.SetDbValue(row["sNombre"], false);
				sApellido1.SetDbValue(row["sApellido1"], false);
				sApellido2.SetDbValue(row["sApellido2"], false);
				nGeneroID.SetDbValue(row["nGeneroID"], false);
				sLugarNacimiento.SetDbValue(row["sLugarNacimiento"], false);
				dFechaNacimiento.SetDbValue(row["dFechaNacimiento"], false);
				sDireccion.SetDbValue(row["sDireccion"], false);
				sCedula.SetDbValue(row["sCedula"], false);
				sTelefono.SetDbValue(row["sTelefono"], false);
				sEmergenciaNombre.SetDbValue(row["sEmergenciaNombre"], false);
				sEmergenciaParentesco.SetDbValue(row["sEmergenciaParentesco"], false);
				sEmergenciaTelefono.SetDbValue(row["sEmergenciaTelefono"], false);
				nActivo.SetDbValue((ConvertToBool(row["nActivo"]) ? "1" : "0"), false);
				dFechaCreacion.SetDbValue(row["dFechaCreacion"], false);
				dFechaModificacion.SetDbValue(row["dFechaModificacion"], false);
			}
			public void DeleteUploadedFiles(Dictionary<string, object> row) {
				LoadDbValues(row);
			}

			// Return URL
			public string ReturnUrl {
				get {
					string name = Config.ProjectName + "_" + TableVar + "_" + Config.TableReturnUrl;

					// Get referer URL automatically
					if (!Empty(ReferUrl()) && ReferPage() != CurrentPageName() &&
						ReferPage() != "login") {// Referer not same page or login page
							Session[name] = ReferUrl(); // Save to Session
					}
					if (!Empty(Session[name])) {
						return Session.GetString(name);
					} else {
						return "Pacientelist";
					}
				}
				set {
					Session[Config.ProjectName + "_" + TableVar + "_" + Config.TableReturnUrl] = value;
				}
			}

			// Get modal caption
			public string GetModalCaption(string pageName) {
				if (SameString(pageName, "Pacienteview"))
					return Language.Phrase("View");
				else if (SameString(pageName, "Pacienteedit"))
					return Language.Phrase("Edit");
				else if (SameString(pageName, "Pacienteadd"))
					return Language.Phrase("Add");
				else
					return "";
			}

			// List URL
			public string ListUrl => "Pacientelist";

			// View URL
			public string ViewUrl => GetViewUrl();

			// View URL
			public string GetViewUrl(string parm = "") {
				string url = "";
				if (!Empty(parm))
					url = KeyUrl("Pacienteview", UrlParm(parm));
				else
					url = KeyUrl("Pacienteview", UrlParm(Config.TableShowDetail + "="));
				return AddMasterUrl(url);
			}

			// Add URL
			public string AddUrl { get; set; } = "Pacienteadd";

			// Add URL
			public string GetAddUrl(string parm = "") {
				string url = "";
				if (!Empty(parm))
					url = "Pacienteadd?" + UrlParm(parm);
				else
					url = "Pacienteadd";
				return AppPath(AddMasterUrl(url));
			}

			// Edit URL
			public string EditUrl => GetEditUrl();

			// Edit URL (with parameter)
			public string GetEditUrl(string parm = "") {
				string url = "";
				if (!Empty(parm))
					url = KeyUrl("Pacienteedit", UrlParm(parm));
				else
					url = KeyUrl("Pacienteedit", UrlParm(Config.TableShowDetail + "="));
				return AppPath(AddMasterUrl(url)); // DN
			}

			// Inline edit URL
			public string InlineEditUrl =>
				AppPath(AddMasterUrl(KeyUrl(CurrentPageName(), UrlParm("action=edit")))); // DN

			// Copy URL
			public string CopyUrl => GetCopyUrl();

			// Copy URL
			public string GetCopyUrl(string parm = "") {
				string url = "";
				if (!Empty(parm))
					url = KeyUrl("Pacienteadd", UrlParm(parm));
				else
					url = KeyUrl("Pacienteadd", UrlParm(Config.TableShowDetail + "="));
				return AppPath(AddMasterUrl(url)); // DN
			}

			// Inline copy URL
			public string InlineCopyUrl =>
				AppPath(AddMasterUrl(KeyUrl(CurrentPageName(), UrlParm("action=copy")))); // DN

			// Delete URL
			public string DeleteUrl =>
				AppPath(KeyUrl("Pacientedelete", UrlParm())); // DN

			// Add master URL
			public string AddMasterUrl(string url) {
				return url;
			}

			// Get primary key as JSON
			public string KeyToJson() {
				string json = "";
				json += "nPacienteID:" + ConvertToJson(nPacienteID.CurrentValue, "number", true);
				return "{" + json + "}";
			}

			// Add key value to URL
			public string KeyUrl(string url, string parm = "") { // DN
				if (!IsDBNull(nPacienteID.CurrentValue)) {
					url += "/" + nPacienteID.CurrentValue;
				} else {
					return "javascript:ew.alert(ew.language.phrase('InvalidRecord'));";
				}
				if (Empty(parm))
					return url;
				else
					return url + "?" + parm;
			}

			// Sort URL (already URL-encoded)
			public string SortUrl(DbField fld) {
				if (!Empty(CurrentAction) || !Empty(Export) ||
					(new List<int> {141, 201, 203, 128, 204, 205}).Contains(fld.Type)) { // Unsortable data type
					return "";
				} else if (fld.Sortable) {
					string urlParm = UrlParm("order=" + UrlEncode(fld.Name) + "&amp;ordertype=" + fld.ReverseSort());
					return AddMasterUrl(CurrentPageName() + "?" + urlParm);
				}
				return "";
			}

			#pragma warning disable 168

			// Get record keys
			public List<string> GetRecordKeys() {
				var result = new List<string>();
				StringValues sv;
				var keysList = new List<string>();
				if (Form.TryGetValue("key_m", out sv) || Query.TryGetValue("key_m", out sv)) {
					keysList = sv.ToList();
				} else if (RouteValues.Count > 0 || Query.Count > 0 || Form.Count > 0) { // DN
					string key = "";
					string[] keyValues = null;
					object rv;
					if (IsApi() && RouteValues.TryGetValue("key", out object k))
						keyValues = k.ToString().Split('/');
					if (RouteValues.TryGetValue("nPacienteID", out rv)) { // nPacienteID
						key = Convert.ToString(rv);
					} else if (IsApi() && !Empty(keyValues)) {
						key = keyValues[0];
					} else {
						key = Param("nPacienteID");
					}
					keysList.Add(key);
				}

				// Check keys
				foreach (var keys in keysList) {
					if (!IsNumeric(keys)) // nPacienteID
						continue;
					result.Add(keys);
				}
				return result;
			}

			#pragma warning restore 168

			// Get filter from record keys
			public string GetFilterFromRecordKeys() {
				List<string> recordKeys = GetRecordKeys();
				string keyFilter = "";
				foreach (var keys in recordKeys) {
					if (!Empty(keyFilter))
						keyFilter += " OR ";
					nPacienteID.CurrentValue = keys;
					keyFilter += "(" + GetRecordFilter() + ")";
				}
				return keyFilter;
			}

			#pragma warning disable 618

			// Load rows based on filter // DN
			public async Task<DbDataReader> LoadRs(string filter, DatabaseConnectionBase<SqlConnection, SqlCommand, SqlDataReader, SqlDbType> conn = null) {

				// Set up filter (SQL WHERE clause) and get return SQL
				string sql = GetSql(filter);
				try {
					var dr = await (conn ?? Connection).OpenDataReaderAsync(sql);
					if (dr?.HasRows ?? false)
						return dr;
				} catch {}
				return null;
			}

			#pragma warning restore 618

			// Record filter WHERE clause
			private string _sqlKeyFilter => "[nPacienteID] = @nPacienteID@";

			#pragma warning disable 168

			// Get record filter
			public string GetRecordFilter(Dictionary<string, object> row = null)
			{
				string keyFilter = _sqlKeyFilter;
				object val, result;
				val = !Empty(row) ? (row.TryGetValue("nPacienteID", out result) ? result : null) : nPacienteID.CurrentValue;
				if (!IsNumeric(val))
					return "0=1"; // Invalid key
				if (val == null)
					return "0=1"; // Invalid key
				else
					keyFilter = keyFilter.Replace("@nPacienteID@", AdjustSql(val, DbId)); // Replace key value
				return keyFilter;
			}

			#pragma warning restore 168

			// Load row values from recordset
			public void LoadListRowValues(DbDataReader rs) {
				nPacienteID.SetDbValue(rs["nPacienteID"]);
				nCodigo.SetDbValue(rs["nCodigo"]);
				sNombre.SetDbValue(rs["sNombre"]);
				sApellido1.SetDbValue(rs["sApellido1"]);
				sApellido2.SetDbValue(rs["sApellido2"]);
				nGeneroID.SetDbValue(rs["nGeneroID"]);
				sLugarNacimiento.SetDbValue(rs["sLugarNacimiento"]);
				dFechaNacimiento.SetDbValue(rs["dFechaNacimiento"]);
				sDireccion.SetDbValue(rs["sDireccion"]);
				sCedula.SetDbValue(rs["sCedula"]);
				sTelefono.SetDbValue(rs["sTelefono"]);
				sEmergenciaNombre.SetDbValue(rs["sEmergenciaNombre"]);
				sEmergenciaParentesco.SetDbValue(rs["sEmergenciaParentesco"]);
				sEmergenciaTelefono.SetDbValue(rs["sEmergenciaTelefono"]);
				nActivo.SetDbValue(ConvertToBool(rs["nActivo"]) ? "1" : "0");
				dFechaCreacion.SetDbValue(rs["dFechaCreacion"]);
				dFechaModificacion.SetDbValue(rs["dFechaModificacion"]);
			}

			#pragma warning disable 1998

			// Render list row values
			public async Task RenderListRow() {

				// Call Row Rendering event
				Row_Rendering();

				// Common render codes
				// nPacienteID
				// nCodigo
				// sNombre
				// sApellido1
				// sApellido2
				// nGeneroID
				// sLugarNacimiento
				// dFechaNacimiento
				// sDireccion

				sDireccion.CellCssStyle = "white-space: nowrap;";

				// sCedula
				// sTelefono
				// sEmergenciaNombre
				// sEmergenciaParentesco
				// sEmergenciaTelefono
				// nActivo
				// dFechaCreacion

				dFechaCreacion.CellCssStyle = "white-space: nowrap;";

				// dFechaModificacion
				dFechaModificacion.CellCssStyle = "white-space: nowrap;";

				// nPacienteID
				nPacienteID.ViewValue = nPacienteID.CurrentValue;

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

				// dFechaCreacion
				dFechaCreacion.ViewValue = dFechaCreacion.CurrentValue;
				dFechaCreacion.ViewValue = FormatDateTime(dFechaCreacion.ViewValue, 0);

				// dFechaModificacion
				dFechaModificacion.ViewValue = dFechaModificacion.CurrentValue;
				dFechaModificacion.ViewValue = FormatDateTime(dFechaModificacion.ViewValue, 0);

				// nPacienteID
				nPacienteID.HrefValue = "";
				nPacienteID.TooltipValue = "";

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

				// dFechaCreacion
				dFechaCreacion.HrefValue = "";
				dFechaCreacion.TooltipValue = "";

				// dFechaModificacion
				dFechaModificacion.HrefValue = "";
				dFechaModificacion.TooltipValue = "";

				// Call Row Rendered event
				Row_Rendered();

				// Save data for Custom Template
				Rows.Add(CustomTemplateFieldValues());
			}

			#pragma warning restore 1998

			#pragma warning disable 1998

			// Render edit row values
			public async Task RenderEditRow() {

				// Call Row Rendering event
				Row_Rendering();

				// nPacienteID
				nPacienteID.EditAttrs["class"] = "form-control";
				nPacienteID.EditValue = nPacienteID.CurrentValue;

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
				nGeneroID.EditAttrs["class"] = "form-control";

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

				// dFechaCreacion
				// dFechaModificacion
				// Call Row Rendered event

				Row_Rendered();
			}

			#pragma warning restore 1998

			// Aggregate list row values
			public void AggregateListRowValues() {
			}

			#pragma warning disable 1998

			// Aggregate list row (for rendering)
			public async Task AggregateListRow() {

				// Call Row Rendered event
				Row_Rendered();
			}

			#pragma warning restore 1998

			// Export document
			public dynamic ExportDoc;

			// Export data in HTML/CSV/Word/Excel/Email/PDF format
			public async Task ExportDocument(dynamic doc, DbDataReader dataReader, int startRec, int stopRec, string exportType = "") {
				if (dataReader == null || doc == null)
					return;
				if (!doc.ExportCustom) {

					// Write header
					doc.ExportTableHeader();
					if (doc.Horizontal) { // Horizontal format, write header
						doc.BeginExportRow();
						if (exportType == "view") {
							doc.ExportCaption(nCodigo);
							doc.ExportCaption(sNombre);
							doc.ExportCaption(sApellido1);
							doc.ExportCaption(sApellido2);
							doc.ExportCaption(nGeneroID);
							doc.ExportCaption(sLugarNacimiento);
							doc.ExportCaption(dFechaNacimiento);
							doc.ExportCaption(sDireccion);
							doc.ExportCaption(sCedula);
							doc.ExportCaption(sTelefono);
							doc.ExportCaption(sEmergenciaNombre);
							doc.ExportCaption(sEmergenciaParentesco);
							doc.ExportCaption(sEmergenciaTelefono);
							doc.ExportCaption(nActivo);
						} else {
							doc.ExportCaption(nCodigo);
							doc.ExportCaption(sNombre);
							doc.ExportCaption(sApellido1);
							doc.ExportCaption(sApellido2);
							doc.ExportCaption(nGeneroID);
							doc.ExportCaption(sLugarNacimiento);
							doc.ExportCaption(dFechaNacimiento);
							doc.ExportCaption(sDireccion);
							doc.ExportCaption(sCedula);
							doc.ExportCaption(sTelefono);
							doc.ExportCaption(sEmergenciaNombre);
							doc.ExportCaption(sEmergenciaParentesco);
							doc.ExportCaption(sEmergenciaTelefono);
							doc.ExportCaption(nActivo);
						}
						doc.EndExportRow();
					}
				}

				// Move to first record
				// For List page only. For View page, the recordset is alreay at the start record. // DN

				int recCnt = startRec - 1;
				if (exportType != "view") {
					if (Connection.SelectOffset) {
						await dataReader.ReadAsync();
					} else {
						for (int i = 0; i < startRec; i++) // Move to the start record and use do-while loop
							await dataReader.ReadAsync();
					}
				}
				int rowcnt = 0; // DN
				do { // DN
					recCnt++;
					if (recCnt >= startRec) {
						rowcnt = recCnt - startRec + 1;

						// Page break
						if (ExportPageBreakCount > 0) {
							if (rowcnt > 1 && (rowcnt - 1) % ExportPageBreakCount == 0)
								doc.ExportPageBreak();
						}
						LoadListRowValues(dataReader);

						// Render row
						RowType = Config.RowTypeView; // Render view
						ResetAttributes();
						await RenderListRow();
						if (!doc.ExportCustom) {
							doc.BeginExportRow(rowcnt); // Allow CSS styles if enabled
							if (exportType == "view") {
								await doc.ExportField(nCodigo);
								await doc.ExportField(sNombre);
								await doc.ExportField(sApellido1);
								await doc.ExportField(sApellido2);
								await doc.ExportField(nGeneroID);
								await doc.ExportField(sLugarNacimiento);
								await doc.ExportField(dFechaNacimiento);
								await doc.ExportField(sDireccion);
								await doc.ExportField(sCedula);
								await doc.ExportField(sTelefono);
								await doc.ExportField(sEmergenciaNombre);
								await doc.ExportField(sEmergenciaParentesco);
								await doc.ExportField(sEmergenciaTelefono);
								await doc.ExportField(nActivo);
							} else {
								await doc.ExportField(nCodigo);
								await doc.ExportField(sNombre);
								await doc.ExportField(sApellido1);
								await doc.ExportField(sApellido2);
								await doc.ExportField(nGeneroID);
								await doc.ExportField(sLugarNacimiento);
								await doc.ExportField(dFechaNacimiento);
								await doc.ExportField(sDireccion);
								await doc.ExportField(sCedula);
								await doc.ExportField(sTelefono);
								await doc.ExportField(sEmergenciaNombre);
								await doc.ExportField(sEmergenciaParentesco);
								await doc.ExportField(sEmergenciaTelefono);
								await doc.ExportField(nActivo);
							}
							doc.EndExportRow(rowcnt);
						}
					}

					// Call Row Export server event
					if (doc.ExportCustom)
						Row_Export(dataReader);
				} while (recCnt < stopRec && await dataReader.ReadAsync()); // DN
				if (!doc.ExportCustom)
					doc.ExportTableFooter();
			}

			#pragma warning disable 219

			// Lookup data from table
			public async Task<JsonBoolResult> Lookup() {
				Language = Language ?? new Lang(Config.LanguageFolder, Post("language"));
				bool validRequest = true;
				if (Security == null)
					Security = new AdvancedSecurity();
				validRequest = Security.IsLoggedIn; // Logged in
				if (validRequest) {
					Security.UserID_Loading();
					await Security.LoadUserID();
					Security.UserID_Loaded();
				}

				// Reject invalid request
				if (!validRequest)
					return JsonBoolResult.FalseResult;

				// Load lookup parameters
				bool distinct = Post<bool>("distinct");
				string linkField = Post("linkField");
				StringValues sv;
				var displayFields = Form.TryGetValue("displayFields[]", out sv) ? sv.ToList() : new List<string>();
				var parentFields = Form.TryGetValue("parentFields[]", out sv) ? sv.ToList() : new List<string>();
				var childFields = Form.TryGetValue("childFields[]", out sv) ? sv.ToList() : new List<string>();
				var filterFields = Form.TryGetValue("filterFields[]", out sv) ? sv.ToList() : new List<string>();
				var filterFieldVars = Form.TryGetValue("filterFieldVars[]", out sv) ? sv.ToList() : new List<string>();
				var filterOperators = Form.TryGetValue("filterOperators[]", out sv) ? sv.ToList() : new List<string>();
				var autoFillSourceFields = Form.TryGetValue("autoFillSourceFields[]", out sv) ? sv.ToList() : new List<string>();
				bool formatAutoFill = false;
				string lookupType = Post("ajax");
				int pageSize = -1;
				int offset = -1;
				string searchValue = "";
				if (SameText(lookupType, "modal")) {
					searchValue = Post("sv");
					if (Empty(Post("recperpage")))
						pageSize = 10;
					else
						pageSize = Post<int>("recperpage");
					offset = Post<int>("start");
				} else if (SameText(lookupType, "autosuggest")) {
					searchValue = Get("q");
					pageSize = IsNumeric(Param("n")) ? Param<int>("n") : -1;
					if (pageSize <= 0)
						pageSize = Config.AutoSuggestMaxEntries;
					int start = IsNumeric(Param("start")) ? Param<int>("start") : -1;
					int page = IsNumeric(Param("page")) ? Param<int>("page") : -1;
					offset = start >= 0 ? start : (page > 0 && pageSize > 0 ? (page - 1) * pageSize : 0);
				}
				string userSelect = Decrypt(Post("s"));
				string userFilter = Decrypt(Post("f"));
				string userOrderBy = Decrypt(Post("o"));

				// Selected records from modal, skip parent/filter fields and show all records
				StringValues keys;
				if (Form.TryGetValue("keys[]", out keys)) { // Selected records from modal
					parentFields = new List<string>();
					filterFields = new List<string>();
					filterFieldVars = new List<string>();
					offset = -1;
					pageSize = -1;
				}

				// Create lookup object and output JSON
				var lookup = new Lookup<DbField>(linkField, TableVar, distinct, linkField, displayFields, parentFields, childFields, filterFields, filterFieldVars, autoFillSourceFields);
				for (int i = 0; i < filterFields.Count; i++) { // Set up filter operators
					if (!Empty(filterOperators[i]))
						lookup.SetFilterOperator(filterFields[i], filterOperators[i]);
				}
				lookup.LookupType = lookupType; // Lookup type
				if (!StringValues.IsNullOrEmpty(keys)) { // Selected records from modal
					lookup.FilterValues.Add(string.Join(",", keys.ToArray()));
				} else { // Lookup values
					lookup.FilterValues.Add(Post<string>("v0") ?? Post("lookupValue"));
				}
				int cnt = IsList(filterFields) ? filterFields.Count : 0;
				for (int i = 1; i <= cnt; i++)
					lookup.FilterValues.Add(UrlDecode(Post("v" + i)));
				lookup.SearchValue = searchValue;
				lookup.PageSize = pageSize;
				lookup.Offset = offset;
				if (userSelect != "")
					lookup.UserSelect = userSelect;
				if (userFilter != "")
					lookup.UserFilter = userFilter;
				if (userOrderBy != "")
					lookup.UserOrderBy = userOrderBy;
				return await lookup.ToJson();
			}

			#pragma warning restore 219

			// Table filter
			private string _tableFilter = null;
			public string TableFilter {
				get => _tableFilter ?? "";
				set => _tableFilter = value;
			}

			// TblBasicSearchDefault
			private string _tableBasicSearchDefault = null;
			public string TableBasicSearchDefault {
				get => _tableBasicSearchDefault ?? "";
				set => _tableBasicSearchDefault = value;
			}

			#pragma warning disable 1998

			// Get file data
			public async Task<IActionResult> GetFileData(string fldparm, string key, bool resize, int width = -1, int height = -1) {
				if (width < 0)
					width = Config.ThumbnailDefaultWidth;
				if (height < 0)
					height = Config.ThumbnailDefaultHeight;

				// No binary fields
				return JsonBoolResult.FalseResult; // Incorrect key
			}

			#pragma warning restore 1998

			// Table level events
			// Recordset Selecting event

			public void Recordset_Selecting(ref string filter) {

				// Enter your code here
			}

			// Recordset Search Validated event
			public void Recordset_SearchValidated() {

				// Enter your code here
			}

			// Recordset Searching event
			public void Recordset_Searching(ref string filter) {

				// Enter your code here
			}

			// Row_Selecting event
			public void Row_Selecting(ref string filter) {

				// Enter your code here
			}

			// Row Selected event
			public void Row_Selected(Dictionary<string, object> row) {

				//Log("Row Selected");
			}

			// Row Inserting event
			public bool Row_Inserting(Dictionary<string, object> rsold, Dictionary<string, object> rsnew) {

				// Enter your code here
				// To cancel, set return value to False and error message to CancelMessage

				return true;
			}

			// Row Inserted event
			public void Row_Inserted(Dictionary<string, object> rsold, Dictionary<string, object> rsnew) {

				//Log("Row Inserted");
			}

			// Row Updating event
			public bool Row_Updating(Dictionary<string, object> rsold, Dictionary<string, object> rsnew) {

				// Enter your code here
				// To cancel, set return value to False and error message to CancelMessage

				return true;
			}

			// Row Updated event
			public void Row_Updated(Dictionary<string, object> rsold, Dictionary<string, object> rsnew) {

				//Log("Row Updated");
			}

			// Row Update Conflict event
			public bool Row_UpdateConflict(Dictionary<string, object> rsold, Dictionary<string, object> rsnew) {

				// Enter your code here
				// To ignore conflict, set return value to false

				return true;
			}

			// Row Export event
			// ExportDoc = export document object

			public virtual void Row_Export(DbDataReader rs) {

				//ExportDoc.Text.Append("<div>" + MyField.ViewValue +"</div>"); // Build HTML with field value: rs["MyField"] or MyField.ViewValue
			}

			// Page Exporting event
			// ExportDoc = export document object

			public virtual bool Page_Exporting() {

				//ExportDoc.Text.Append("<p>" + "my header" + "</p>"); // Export header
				//return false; // Return FALSE to skip default export and use Row_Export event

				return true; // Return TRUE to use default export and skip Row_Export event
			}

			// Page Exported event
			// ExportDoc = export document object

			public virtual void Page_Exported() {

				//ExportDoc.Text.Append("my footer"); // Export footer
				//Log("Text: {Text}", ExportDoc.Text);

			}

			// Recordset Deleting event
			public bool Row_Deleting(Dictionary<string, object> rs) {

				// Enter your code here
				// To cancel, set return value to False and error message to CancelMessage

				return true;
			}

			// Row Deleted event
			public void Row_Deleted(Dictionary<string, object> rs) {

				//Log("Row Deleted");
			}

			// Email Sending event
			public virtual bool Email_Sending(Email email, dynamic args) {

				//Log(email);
				return true;
			}

			// Lookup Selecting event
			public void Lookup_Selecting(DbField fld, ref string filter) {

				// Enter your code here
			}

			// Row Rendering event
			public void Row_Rendering() {

				// Enter your code here
			}

			// Row Rendered event
			public void Row_Rendered() {

				//VarDump(<FieldName>); // View field properties
			}

			// User ID Filtering event
			public void UserID_Filtering(ref string filter) {

				// Enter your code here
			}
		}
	}
}
