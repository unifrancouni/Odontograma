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
		/// AntecedenteDental
		/// </summary>

		public static _AntecedenteDental AntecedenteDental {
			get => HttpData.GetOrCreate<_AntecedenteDental>("AntecedenteDental");
			set => HttpData["AntecedenteDental"] = value;
		}

		/// <summary>
		/// Table class for AntecedenteDental
		/// </summary>

		public class _AntecedenteDental: DbTable {
			public int RowCnt = 0; // DN
			public bool UseSessionForListSql = true;

			// Column CSS classes
			public string LeftColumnClass = "col-sm-2 col-form-label ew-label";
			public string RightColumnClass = "col-sm-10";
			public string OffsetColumnClass = "col-sm-10 offset-sm-2";
			public string TableLeftColumnClass = "w-col-2";
			public readonly DbField<SqlDbType> nAntecedenteDentalID;
			public readonly DbField<SqlDbType> nExpedienteID;
			public readonly DbField<SqlDbType> dFechaUltimaVisitaDentista;
			public readonly DbField<SqlDbType> sMotivoVisita;
			public readonly DbField<SqlDbType> sExperienciaAsistencial;
			public readonly DbField<SqlDbType> nTratamientoQuirurgico;
			public readonly DbField<SqlDbType> nTratamientoRestauracion;
			public readonly DbField<SqlDbType> nTratamientoPeridoncia;
			public readonly DbField<SqlDbType> nTratamientoEndodoncia;
			public readonly DbField<SqlDbType> nTratamientoOrtodoncia;
			public readonly DbField<SqlDbType> nTratamientoProtesis;
			public readonly DbField<SqlDbType> nColocadoAnestesia;
			public readonly DbField<SqlDbType> nReaccionAlergicaAnestesia;
			public readonly DbField<SqlDbType> sReaccionAlergicaAnestesia;
			public readonly DbField<SqlDbType> sDescripcionTejidosBlandos;
			public readonly DbField<SqlDbType> sHistoriaEnfermedadActual;
			public readonly DbField<SqlDbType> nEstadoID;
			public readonly DbField<SqlDbType> dFechaCreacion;
			public readonly DbField<SqlDbType> dFechaModificacion;

			// Constructor
			public _AntecedenteDental() {

				// Language object // DN
				Language = Language ?? new Lang();
				TableVar = "AntecedenteDental";
				Name = "AntecedenteDental";
				Type = "TABLE";

				// Update Table
				UpdateTable = "[dbo].[AntecedenteDental]";
				DbId = "DB"; // DN
				ExportAll = true;
				ExportPageBreakCount = 0; // Page break per every n record (PDF only)
				ExportPageOrientation = "portrait"; // Page orientation (PDF only)
				ExportPageSize = "a4"; // Page size (PDF only)
				ExportExcelPageOrientation = ""; // Page orientation (EPPlus only)
				ExportExcelPageSize = ""; // Page size (EPPlus only)
				ExportColumnWidths = new float[] {  }; // Column widths (PDF only) // DN
				DetailAdd = false; // Allow detail add
				DetailEdit = false; // Allow detail edit
				DetailView = false; // Allow detail view
				ShowMultipleDetails = false; // Show multiple details
				GridAddRowCount = 5;
				AllowAddDeleteRow = true; // Allow add/delete row
				UserIdAllowSecurity = 0; // User ID Allow
				BasicSearch = new BasicSearch(TableVar);

				// nAntecedenteDentalID
				nAntecedenteDentalID = new DbField<SqlDbType> {
					TableVar = "AntecedenteDental",
					TableName = "AntecedenteDental",
					FieldVar = "x_nAntecedenteDentalID",
					Name = "nAntecedenteDentalID",
					Expression = "[nAntecedenteDentalID]",
					BasicSearchExpression = "CAST([nAntecedenteDentalID] AS NVARCHAR)",
					Type = 3,
					DbType = SqlDbType.Int,
					DateTimeFormat = -1,
					VirtualExpression = "[nAntecedenteDentalID]",
					IsVirtual = false,
					ForceSelection = false,
					SelectMultiple = false,
					VirtualSearch = false,
					ViewTag = "FORMATTED TEXT",
					HtmlTag = "NO",
					IsAutoIncrement = true, // Autoincrement field
					IsPrimaryKey = true, // Primary key field
					Nullable = false, // NOT NULL field
					Sortable = false, // Allow sort
					DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
					IsUpload = false
				};
				nAntecedenteDentalID.Init(this); // DN
				Fields.Add("nAntecedenteDentalID", nAntecedenteDentalID);

				// nExpedienteID
				nExpedienteID = new DbField<SqlDbType> {
					TableVar = "AntecedenteDental",
					TableName = "AntecedenteDental",
					FieldVar = "x_nExpedienteID",
					Name = "nExpedienteID",
					Expression = "[nExpedienteID]",
					BasicSearchExpression = "CAST([nExpedienteID] AS NVARCHAR)",
					Type = 3,
					DbType = SqlDbType.Int,
					DateTimeFormat = -1,
					VirtualExpression = "[nExpedienteID]",
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
				nExpedienteID.Init(this); // DN
				switch (CurrentLanguage) {
					case "en":
						nExpedienteID.Lookup = new Lookup<DbField>("nExpedienteID", "vwPacienteExpediente", true, "nExpedienteID", new List<string> {"nCodigoExpediente", "sNombre", "sApellido1", "sCedula"}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "[nCodigoExpediente] ASC", "");
						break;
					default:
						nExpedienteID.Lookup = new Lookup<DbField>("nExpedienteID", "vwPacienteExpediente", true, "nExpedienteID", new List<string> {"nCodigoExpediente", "sNombre", "sApellido1", "sCedula"}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "[nCodigoExpediente] ASC", "");
						break;
				}
				Fields.Add("nExpedienteID", nExpedienteID);

				// dFechaUltimaVisitaDentista
				dFechaUltimaVisitaDentista = new DbField<SqlDbType> {
					TableVar = "AntecedenteDental",
					TableName = "AntecedenteDental",
					FieldVar = "x_dFechaUltimaVisitaDentista",
					Name = "dFechaUltimaVisitaDentista",
					Expression = "[dFechaUltimaVisitaDentista]",
					BasicSearchExpression = CastDateFieldForLike("[dFechaUltimaVisitaDentista]", 0, "DB"),
					Type = 133,
					DbType = SqlDbType.DateTime,
					DateTimeFormat = 0,
					VirtualExpression = "[dFechaUltimaVisitaDentista]",
					IsVirtual = false,
					ForceSelection = false,
					SelectMultiple = false,
					VirtualSearch = false,
					ViewTag = "FORMATTED TEXT",
					HtmlTag = "TEXT",
					Sortable = true, // Allow sort
					DefaultErrorMessage = Language.Phrase("IncorrectDate").Replace("%s", DateFormat),
					IsUpload = false
				};
				dFechaUltimaVisitaDentista.Init(this); // DN
				Fields.Add("dFechaUltimaVisitaDentista", dFechaUltimaVisitaDentista);

				// sMotivoVisita
				sMotivoVisita = new DbField<SqlDbType> {
					TableVar = "AntecedenteDental",
					TableName = "AntecedenteDental",
					FieldVar = "x_sMotivoVisita",
					Name = "sMotivoVisita",
					Expression = "[sMotivoVisita]",
					BasicSearchExpression = "[sMotivoVisita]",
					Type = 200,
					DbType = SqlDbType.VarChar,
					DateTimeFormat = -1,
					VirtualExpression = "[sMotivoVisita]",
					IsVirtual = false,
					ForceSelection = false,
					SelectMultiple = false,
					VirtualSearch = false,
					ViewTag = "FORMATTED TEXT",
					HtmlTag = "TEXTAREA",
					Sortable = true, // Allow sort
					IsUpload = false
				};
				sMotivoVisita.Init(this); // DN
				Fields.Add("sMotivoVisita", sMotivoVisita);

				// sExperienciaAsistencial
				sExperienciaAsistencial = new DbField<SqlDbType> {
					TableVar = "AntecedenteDental",
					TableName = "AntecedenteDental",
					FieldVar = "x_sExperienciaAsistencial",
					Name = "sExperienciaAsistencial",
					Expression = "[sExperienciaAsistencial]",
					BasicSearchExpression = "[sExperienciaAsistencial]",
					Type = 200,
					DbType = SqlDbType.VarChar,
					DateTimeFormat = -1,
					VirtualExpression = "[sExperienciaAsistencial]",
					IsVirtual = false,
					ForceSelection = false,
					SelectMultiple = false,
					VirtualSearch = false,
					ViewTag = "FORMATTED TEXT",
					HtmlTag = "TEXTAREA",
					Sortable = true, // Allow sort
					IsUpload = false
				};
				sExperienciaAsistencial.Init(this); // DN
				Fields.Add("sExperienciaAsistencial", sExperienciaAsistencial);

				// nTratamientoQuirurgico
				nTratamientoQuirurgico = new DbField<SqlDbType> {
					TableVar = "AntecedenteDental",
					TableName = "AntecedenteDental",
					FieldVar = "x_nTratamientoQuirurgico",
					Name = "nTratamientoQuirurgico",
					Expression = "[nTratamientoQuirurgico]",
					BasicSearchExpression = "[nTratamientoQuirurgico]",
					Type = 11,
					DbType = SqlDbType.Bit,
					DateTimeFormat = -1,
					VirtualExpression = "[nTratamientoQuirurgico]",
					IsVirtual = false,
					ForceSelection = false,
					SelectMultiple = false,
					VirtualSearch = false,
					ViewTag = "FORMATTED TEXT",
					HtmlTag = "SELECT",
					Required = true, // Required field
					Sortable = true, // Allow sort
					UsePleaseSelect = true, // Use PleaseSelect by default
					PleaseSelectText = Language.Phrase("PleaseSelect"), // PleaseSelect text
					DataType = Config.DataTypeBoolean,
					OptionCount = 2,
					DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
					IsUpload = false
				};
				nTratamientoQuirurgico.Init(this); // DN
				switch (CurrentLanguage) {
					case "en":
						nTratamientoQuirurgico.Lookup = new Lookup<DbField>("nTratamientoQuirurgico", "AntecedenteDental", false, "", new List<string> {"", "", "", ""}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "");
						break;
					default:
						nTratamientoQuirurgico.Lookup = new Lookup<DbField>("nTratamientoQuirurgico", "AntecedenteDental", false, "", new List<string> {"", "", "", ""}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "");
						break;
				}
				Fields.Add("nTratamientoQuirurgico", nTratamientoQuirurgico);

				// nTratamientoRestauracion
				nTratamientoRestauracion = new DbField<SqlDbType> {
					TableVar = "AntecedenteDental",
					TableName = "AntecedenteDental",
					FieldVar = "x_nTratamientoRestauracion",
					Name = "nTratamientoRestauracion",
					Expression = "[nTratamientoRestauracion]",
					BasicSearchExpression = "[nTratamientoRestauracion]",
					Type = 11,
					DbType = SqlDbType.Bit,
					DateTimeFormat = -1,
					VirtualExpression = "[nTratamientoRestauracion]",
					IsVirtual = false,
					ForceSelection = false,
					SelectMultiple = false,
					VirtualSearch = false,
					ViewTag = "FORMATTED TEXT",
					HtmlTag = "SELECT",
					Required = true, // Required field
					Sortable = true, // Allow sort
					UsePleaseSelect = true, // Use PleaseSelect by default
					PleaseSelectText = Language.Phrase("PleaseSelect"), // PleaseSelect text
					DataType = Config.DataTypeBoolean,
					OptionCount = 2,
					DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
					IsUpload = false
				};
				nTratamientoRestauracion.Init(this); // DN
				switch (CurrentLanguage) {
					case "en":
						nTratamientoRestauracion.Lookup = new Lookup<DbField>("nTratamientoRestauracion", "AntecedenteDental", false, "", new List<string> {"", "", "", ""}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "");
						break;
					default:
						nTratamientoRestauracion.Lookup = new Lookup<DbField>("nTratamientoRestauracion", "AntecedenteDental", false, "", new List<string> {"", "", "", ""}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "");
						break;
				}
				Fields.Add("nTratamientoRestauracion", nTratamientoRestauracion);

				// nTratamientoPeridoncia
				nTratamientoPeridoncia = new DbField<SqlDbType> {
					TableVar = "AntecedenteDental",
					TableName = "AntecedenteDental",
					FieldVar = "x_nTratamientoPeridoncia",
					Name = "nTratamientoPeridoncia",
					Expression = "[nTratamientoPeridoncia]",
					BasicSearchExpression = "[nTratamientoPeridoncia]",
					Type = 11,
					DbType = SqlDbType.Bit,
					DateTimeFormat = -1,
					VirtualExpression = "[nTratamientoPeridoncia]",
					IsVirtual = false,
					ForceSelection = false,
					SelectMultiple = false,
					VirtualSearch = false,
					ViewTag = "FORMATTED TEXT",
					HtmlTag = "SELECT",
					Required = true, // Required field
					Sortable = true, // Allow sort
					UsePleaseSelect = true, // Use PleaseSelect by default
					PleaseSelectText = Language.Phrase("PleaseSelect"), // PleaseSelect text
					DataType = Config.DataTypeBoolean,
					OptionCount = 2,
					DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
					IsUpload = false
				};
				nTratamientoPeridoncia.Init(this); // DN
				switch (CurrentLanguage) {
					case "en":
						nTratamientoPeridoncia.Lookup = new Lookup<DbField>("nTratamientoPeridoncia", "AntecedenteDental", false, "", new List<string> {"", "", "", ""}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "");
						break;
					default:
						nTratamientoPeridoncia.Lookup = new Lookup<DbField>("nTratamientoPeridoncia", "AntecedenteDental", false, "", new List<string> {"", "", "", ""}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "");
						break;
				}
				Fields.Add("nTratamientoPeridoncia", nTratamientoPeridoncia);

				// nTratamientoEndodoncia
				nTratamientoEndodoncia = new DbField<SqlDbType> {
					TableVar = "AntecedenteDental",
					TableName = "AntecedenteDental",
					FieldVar = "x_nTratamientoEndodoncia",
					Name = "nTratamientoEndodoncia",
					Expression = "[nTratamientoEndodoncia]",
					BasicSearchExpression = "[nTratamientoEndodoncia]",
					Type = 11,
					DbType = SqlDbType.Bit,
					DateTimeFormat = -1,
					VirtualExpression = "[nTratamientoEndodoncia]",
					IsVirtual = false,
					ForceSelection = false,
					SelectMultiple = false,
					VirtualSearch = false,
					ViewTag = "FORMATTED TEXT",
					HtmlTag = "SELECT",
					Required = true, // Required field
					Sortable = true, // Allow sort
					UsePleaseSelect = true, // Use PleaseSelect by default
					PleaseSelectText = Language.Phrase("PleaseSelect"), // PleaseSelect text
					DataType = Config.DataTypeBoolean,
					OptionCount = 2,
					DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
					IsUpload = false
				};
				nTratamientoEndodoncia.Init(this); // DN
				switch (CurrentLanguage) {
					case "en":
						nTratamientoEndodoncia.Lookup = new Lookup<DbField>("nTratamientoEndodoncia", "AntecedenteDental", false, "", new List<string> {"", "", "", ""}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "");
						break;
					default:
						nTratamientoEndodoncia.Lookup = new Lookup<DbField>("nTratamientoEndodoncia", "AntecedenteDental", false, "", new List<string> {"", "", "", ""}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "");
						break;
				}
				Fields.Add("nTratamientoEndodoncia", nTratamientoEndodoncia);

				// nTratamientoOrtodoncia
				nTratamientoOrtodoncia = new DbField<SqlDbType> {
					TableVar = "AntecedenteDental",
					TableName = "AntecedenteDental",
					FieldVar = "x_nTratamientoOrtodoncia",
					Name = "nTratamientoOrtodoncia",
					Expression = "[nTratamientoOrtodoncia]",
					BasicSearchExpression = "[nTratamientoOrtodoncia]",
					Type = 11,
					DbType = SqlDbType.Bit,
					DateTimeFormat = -1,
					VirtualExpression = "[nTratamientoOrtodoncia]",
					IsVirtual = false,
					ForceSelection = false,
					SelectMultiple = false,
					VirtualSearch = false,
					ViewTag = "FORMATTED TEXT",
					HtmlTag = "SELECT",
					Required = true, // Required field
					Sortable = true, // Allow sort
					UsePleaseSelect = true, // Use PleaseSelect by default
					PleaseSelectText = Language.Phrase("PleaseSelect"), // PleaseSelect text
					DataType = Config.DataTypeBoolean,
					OptionCount = 2,
					DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
					IsUpload = false
				};
				nTratamientoOrtodoncia.Init(this); // DN
				switch (CurrentLanguage) {
					case "en":
						nTratamientoOrtodoncia.Lookup = new Lookup<DbField>("nTratamientoOrtodoncia", "AntecedenteDental", false, "", new List<string> {"", "", "", ""}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "");
						break;
					default:
						nTratamientoOrtodoncia.Lookup = new Lookup<DbField>("nTratamientoOrtodoncia", "AntecedenteDental", false, "", new List<string> {"", "", "", ""}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "");
						break;
				}
				Fields.Add("nTratamientoOrtodoncia", nTratamientoOrtodoncia);

				// nTratamientoProtesis
				nTratamientoProtesis = new DbField<SqlDbType> {
					TableVar = "AntecedenteDental",
					TableName = "AntecedenteDental",
					FieldVar = "x_nTratamientoProtesis",
					Name = "nTratamientoProtesis",
					Expression = "[nTratamientoProtesis]",
					BasicSearchExpression = "[nTratamientoProtesis]",
					Type = 11,
					DbType = SqlDbType.Bit,
					DateTimeFormat = -1,
					VirtualExpression = "[nTratamientoProtesis]",
					IsVirtual = false,
					ForceSelection = false,
					SelectMultiple = false,
					VirtualSearch = false,
					ViewTag = "FORMATTED TEXT",
					HtmlTag = "SELECT",
					Required = true, // Required field
					Sortable = true, // Allow sort
					UsePleaseSelect = true, // Use PleaseSelect by default
					PleaseSelectText = Language.Phrase("PleaseSelect"), // PleaseSelect text
					DataType = Config.DataTypeBoolean,
					OptionCount = 2,
					DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
					IsUpload = false
				};
				nTratamientoProtesis.Init(this); // DN
				switch (CurrentLanguage) {
					case "en":
						nTratamientoProtesis.Lookup = new Lookup<DbField>("nTratamientoProtesis", "AntecedenteDental", false, "", new List<string> {"", "", "", ""}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "");
						break;
					default:
						nTratamientoProtesis.Lookup = new Lookup<DbField>("nTratamientoProtesis", "AntecedenteDental", false, "", new List<string> {"", "", "", ""}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "");
						break;
				}
				Fields.Add("nTratamientoProtesis", nTratamientoProtesis);

				// nColocadoAnestesia
				nColocadoAnestesia = new DbField<SqlDbType> {
					TableVar = "AntecedenteDental",
					TableName = "AntecedenteDental",
					FieldVar = "x_nColocadoAnestesia",
					Name = "nColocadoAnestesia",
					Expression = "[nColocadoAnestesia]",
					BasicSearchExpression = "[nColocadoAnestesia]",
					Type = 11,
					DbType = SqlDbType.Bit,
					DateTimeFormat = -1,
					VirtualExpression = "[nColocadoAnestesia]",
					IsVirtual = false,
					ForceSelection = false,
					SelectMultiple = false,
					VirtualSearch = false,
					ViewTag = "FORMATTED TEXT",
					HtmlTag = "SELECT",
					Required = true, // Required field
					Sortable = true, // Allow sort
					UsePleaseSelect = true, // Use PleaseSelect by default
					PleaseSelectText = Language.Phrase("PleaseSelect"), // PleaseSelect text
					DataType = Config.DataTypeBoolean,
					OptionCount = 2,
					DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
					IsUpload = false
				};
				nColocadoAnestesia.Init(this); // DN
				switch (CurrentLanguage) {
					case "en":
						nColocadoAnestesia.Lookup = new Lookup<DbField>("nColocadoAnestesia", "AntecedenteDental", false, "", new List<string> {"", "", "", ""}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "");
						break;
					default:
						nColocadoAnestesia.Lookup = new Lookup<DbField>("nColocadoAnestesia", "AntecedenteDental", false, "", new List<string> {"", "", "", ""}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "");
						break;
				}
				Fields.Add("nColocadoAnestesia", nColocadoAnestesia);

				// nReaccionAlergicaAnestesia
				nReaccionAlergicaAnestesia = new DbField<SqlDbType> {
					TableVar = "AntecedenteDental",
					TableName = "AntecedenteDental",
					FieldVar = "x_nReaccionAlergicaAnestesia",
					Name = "nReaccionAlergicaAnestesia",
					Expression = "[nReaccionAlergicaAnestesia]",
					BasicSearchExpression = "[nReaccionAlergicaAnestesia]",
					Type = 11,
					DbType = SqlDbType.Bit,
					DateTimeFormat = -1,
					VirtualExpression = "[nReaccionAlergicaAnestesia]",
					IsVirtual = false,
					ForceSelection = false,
					SelectMultiple = false,
					VirtualSearch = false,
					ViewTag = "FORMATTED TEXT",
					HtmlTag = "SELECT",
					Required = true, // Required field
					Sortable = true, // Allow sort
					UsePleaseSelect = true, // Use PleaseSelect by default
					PleaseSelectText = Language.Phrase("PleaseSelect"), // PleaseSelect text
					DataType = Config.DataTypeBoolean,
					OptionCount = 2,
					DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
					IsUpload = false
				};
				nReaccionAlergicaAnestesia.Init(this); // DN
				switch (CurrentLanguage) {
					case "en":
						nReaccionAlergicaAnestesia.Lookup = new Lookup<DbField>("nReaccionAlergicaAnestesia", "AntecedenteDental", false, "", new List<string> {"", "", "", ""}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "");
						break;
					default:
						nReaccionAlergicaAnestesia.Lookup = new Lookup<DbField>("nReaccionAlergicaAnestesia", "AntecedenteDental", false, "", new List<string> {"", "", "", ""}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "");
						break;
				}
				Fields.Add("nReaccionAlergicaAnestesia", nReaccionAlergicaAnestesia);

				// sReaccionAlergicaAnestesia
				sReaccionAlergicaAnestesia = new DbField<SqlDbType> {
					TableVar = "AntecedenteDental",
					TableName = "AntecedenteDental",
					FieldVar = "x_sReaccionAlergicaAnestesia",
					Name = "sReaccionAlergicaAnestesia",
					Expression = "[sReaccionAlergicaAnestesia]",
					BasicSearchExpression = "[sReaccionAlergicaAnestesia]",
					Type = 200,
					DbType = SqlDbType.VarChar,
					DateTimeFormat = -1,
					VirtualExpression = "[sReaccionAlergicaAnestesia]",
					IsVirtual = false,
					ForceSelection = false,
					SelectMultiple = false,
					VirtualSearch = false,
					ViewTag = "FORMATTED TEXT",
					HtmlTag = "TEXTAREA",
					Sortable = true, // Allow sort
					IsUpload = false
				};
				sReaccionAlergicaAnestesia.Init(this); // DN
				Fields.Add("sReaccionAlergicaAnestesia", sReaccionAlergicaAnestesia);

				// sDescripcionTejidosBlandos
				sDescripcionTejidosBlandos = new DbField<SqlDbType> {
					TableVar = "AntecedenteDental",
					TableName = "AntecedenteDental",
					FieldVar = "x_sDescripcionTejidosBlandos",
					Name = "sDescripcionTejidosBlandos",
					Expression = "[sDescripcionTejidosBlandos]",
					BasicSearchExpression = "[sDescripcionTejidosBlandos]",
					Type = 200,
					DbType = SqlDbType.VarChar,
					DateTimeFormat = -1,
					VirtualExpression = "[sDescripcionTejidosBlandos]",
					IsVirtual = false,
					ForceSelection = false,
					SelectMultiple = false,
					VirtualSearch = false,
					ViewTag = "FORMATTED TEXT",
					HtmlTag = "TEXTAREA",
					Sortable = true, // Allow sort
					IsUpload = false
				};
				sDescripcionTejidosBlandos.Init(this); // DN
				Fields.Add("sDescripcionTejidosBlandos", sDescripcionTejidosBlandos);

				// sHistoriaEnfermedadActual
				sHistoriaEnfermedadActual = new DbField<SqlDbType> {
					TableVar = "AntecedenteDental",
					TableName = "AntecedenteDental",
					FieldVar = "x_sHistoriaEnfermedadActual",
					Name = "sHistoriaEnfermedadActual",
					Expression = "[sHistoriaEnfermedadActual]",
					BasicSearchExpression = "[sHistoriaEnfermedadActual]",
					Type = 200,
					DbType = SqlDbType.VarChar,
					DateTimeFormat = -1,
					VirtualExpression = "[sHistoriaEnfermedadActual]",
					IsVirtual = false,
					ForceSelection = false,
					SelectMultiple = false,
					VirtualSearch = false,
					ViewTag = "FORMATTED TEXT",
					HtmlTag = "TEXTAREA",
					Sortable = true, // Allow sort
					IsUpload = false
				};
				sHistoriaEnfermedadActual.Init(this); // DN
				Fields.Add("sHistoriaEnfermedadActual", sHistoriaEnfermedadActual);

				// nEstadoID
				nEstadoID = new DbField<SqlDbType> {
					TableVar = "AntecedenteDental",
					TableName = "AntecedenteDental",
					FieldVar = "x_nEstadoID",
					Name = "nEstadoID",
					Expression = "[nEstadoID]",
					BasicSearchExpression = "CAST([nEstadoID] AS NVARCHAR)",
					Type = 3,
					DbType = SqlDbType.Int,
					DateTimeFormat = -1,
					VirtualExpression = "[nEstadoID]",
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
				nEstadoID.Init(this); // DN
				switch (CurrentLanguage) {
					case "en":
						nEstadoID.Lookup = new Lookup<DbField>("nEstadoID", "ValorCatalogo", true, "nValorCatalogoID", new List<string> {"nCodigo", "sDescripcion", "", ""}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "[nCodigo] ASC", "");
						break;
					default:
						nEstadoID.Lookup = new Lookup<DbField>("nEstadoID", "ValorCatalogo", true, "nValorCatalogoID", new List<string> {"nCodigo", "sDescripcion", "", ""}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "[nCodigo] ASC", "");
						break;
				}
				nEstadoID.GetSelectFilter = () => "nCatalogoID=10";
				Fields.Add("nEstadoID", nEstadoID);

				// dFechaCreacion
				dFechaCreacion = new DbField<SqlDbType> {
					TableVar = "AntecedenteDental",
					TableName = "AntecedenteDental",
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
					Required = true, // Required field
					Sortable = false, // Allow sort
					DefaultErrorMessage = Language.Phrase("IncorrectDate").Replace("%s", DateFormat),
					IsUpload = false
				};
				dFechaCreacion.Init(this); // DN
				Fields.Add("dFechaCreacion", dFechaCreacion);

				// dFechaModificacion
				dFechaModificacion = new DbField<SqlDbType> {
					TableVar = "AntecedenteDental",
					TableName = "AntecedenteDental",
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
				get => _sqlFrom ?? "[dbo].[AntecedenteDental]";
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
					nAntecedenteDentalID.SetDbValue(await Connection.GetLastInsertIdAsync());
					row["nAntecedenteDentalID"] = nAntecedenteDentalID.DbValue;
				}
				return result;
			}

			// Insert
			public int Insert(Dictionary<string, object> row) => InsertAsync(row).GetAwaiter().GetResult();

			// Update

			#pragma warning disable 168, 219

			public async Task<int> UpdateAsync(Dictionary<string, object> row, object where = null, Dictionary<string, object> rsold = null, bool curfilter = true) {
				int result;
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
				string sql = "DELETE FROM " + UpdateTable + " WHERE ";
				string filter = curfilter ? CurrentFilter : "";
				if (IsDictionary(where))
					whereClause = ArrayToFilter((IDictionary<string, object>)where);
				else
					whereClause = (string)where;
				AddFilter(ref filter, whereClause);
				if (row != null) {
					DbField fld;
					fld = FieldByName("nAntecedenteDentalID");
					AddFilter(ref filter, fld.Expression + "=" + QuotedValue(row["nAntecedenteDentalID"], FieldByName("nAntecedenteDentalID").DataType, DbId));
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
				nAntecedenteDentalID.SetDbValue(row["nAntecedenteDentalID"], false);
				nExpedienteID.SetDbValue(row["nExpedienteID"], false);
				dFechaUltimaVisitaDentista.SetDbValue(row["dFechaUltimaVisitaDentista"], false);
				sMotivoVisita.SetDbValue(row["sMotivoVisita"], false);
				sExperienciaAsistencial.SetDbValue(row["sExperienciaAsistencial"], false);
				nTratamientoQuirurgico.SetDbValue((ConvertToBool(row["nTratamientoQuirurgico"]) ? "1" : "0"), false);
				nTratamientoRestauracion.SetDbValue((ConvertToBool(row["nTratamientoRestauracion"]) ? "1" : "0"), false);
				nTratamientoPeridoncia.SetDbValue((ConvertToBool(row["nTratamientoPeridoncia"]) ? "1" : "0"), false);
				nTratamientoEndodoncia.SetDbValue((ConvertToBool(row["nTratamientoEndodoncia"]) ? "1" : "0"), false);
				nTratamientoOrtodoncia.SetDbValue((ConvertToBool(row["nTratamientoOrtodoncia"]) ? "1" : "0"), false);
				nTratamientoProtesis.SetDbValue((ConvertToBool(row["nTratamientoProtesis"]) ? "1" : "0"), false);
				nColocadoAnestesia.SetDbValue((ConvertToBool(row["nColocadoAnestesia"]) ? "1" : "0"), false);
				nReaccionAlergicaAnestesia.SetDbValue((ConvertToBool(row["nReaccionAlergicaAnestesia"]) ? "1" : "0"), false);
				sReaccionAlergicaAnestesia.SetDbValue(row["sReaccionAlergicaAnestesia"], false);
				sDescripcionTejidosBlandos.SetDbValue(row["sDescripcionTejidosBlandos"], false);
				sHistoriaEnfermedadActual.SetDbValue(row["sHistoriaEnfermedadActual"], false);
				nEstadoID.SetDbValue(row["nEstadoID"], false);
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
						return "AntecedenteDentallist";
					}
				}
				set {
					Session[Config.ProjectName + "_" + TableVar + "_" + Config.TableReturnUrl] = value;
				}
			}

			// Get modal caption
			public string GetModalCaption(string pageName) {
				if (SameString(pageName, "AntecedenteDentalview"))
					return Language.Phrase("View");
				else if (SameString(pageName, "AntecedenteDentaledit"))
					return Language.Phrase("Edit");
				else if (SameString(pageName, "AntecedenteDentaladd"))
					return Language.Phrase("Add");
				else
					return "";
			}

			// List URL
			public string ListUrl => "AntecedenteDentallist";

			// View URL
			public string ViewUrl => GetViewUrl();

			// View URL
			public string GetViewUrl(string parm = "") {
				string url = "";
				if (!Empty(parm))
					url = KeyUrl("AntecedenteDentalview", UrlParm(parm));
				else
					url = KeyUrl("AntecedenteDentalview", UrlParm(Config.TableShowDetail + "="));
				return AddMasterUrl(url);
			}

			// Add URL
			public string AddUrl { get; set; } = "AntecedenteDentaladd";

			// Add URL
			public string GetAddUrl(string parm = "") {
				string url = "";
				if (!Empty(parm))
					url = "AntecedenteDentaladd?" + UrlParm(parm);
				else
					url = "AntecedenteDentaladd";
				return AppPath(AddMasterUrl(url));
			}

			// Edit URL
			public string EditUrl => GetEditUrl();

			// Edit URL (with parameter)
			public string GetEditUrl(string parm = "") {
				string url = "";
				url = KeyUrl("AntecedenteDentaledit", UrlParm(parm));
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
				url = KeyUrl("AntecedenteDentaladd", UrlParm(parm));
				return AppPath(AddMasterUrl(url)); // DN
			}

			// Inline copy URL
			public string InlineCopyUrl =>
				AppPath(AddMasterUrl(KeyUrl(CurrentPageName(), UrlParm("action=copy")))); // DN

			// Delete URL
			public string DeleteUrl =>
				AppPath(KeyUrl("AntecedenteDentaldelete", UrlParm())); // DN

			// Add master URL
			public string AddMasterUrl(string url) {
				return url;
			}

			// Get primary key as JSON
			public string KeyToJson() {
				string json = "";
				json += "nAntecedenteDentalID:" + ConvertToJson(nAntecedenteDentalID.CurrentValue, "number", true);
				return "{" + json + "}";
			}

			// Add key value to URL
			public string KeyUrl(string url, string parm = "") { // DN
				if (!IsDBNull(nAntecedenteDentalID.CurrentValue)) {
					url += "/" + nAntecedenteDentalID.CurrentValue;
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
					if (RouteValues.TryGetValue("nAntecedenteDentalID", out rv)) { // nAntecedenteDentalID
						key = Convert.ToString(rv);
					} else if (IsApi() && !Empty(keyValues)) {
						key = keyValues[0];
					} else {
						key = Param("nAntecedenteDentalID");
					}
					keysList.Add(key);
				}

				// Check keys
				foreach (var keys in keysList) {
					if (!IsNumeric(keys)) // nAntecedenteDentalID
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
					nAntecedenteDentalID.CurrentValue = keys;
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
			private string _sqlKeyFilter => "[nAntecedenteDentalID] = @nAntecedenteDentalID@";

			#pragma warning disable 168

			// Get record filter
			public string GetRecordFilter(Dictionary<string, object> row = null)
			{
				string keyFilter = _sqlKeyFilter;
				object val, result;
				val = !Empty(row) ? (row.TryGetValue("nAntecedenteDentalID", out result) ? result : null) : nAntecedenteDentalID.CurrentValue;
				if (!IsNumeric(val))
					return "0=1"; // Invalid key
				if (val == null)
					return "0=1"; // Invalid key
				else
					keyFilter = keyFilter.Replace("@nAntecedenteDentalID@", AdjustSql(val, DbId)); // Replace key value
				return keyFilter;
			}

			#pragma warning restore 168

			// Load row values from recordset
			public void LoadListRowValues(DbDataReader rs) {
				nAntecedenteDentalID.SetDbValue(rs["nAntecedenteDentalID"]);
				nExpedienteID.SetDbValue(rs["nExpedienteID"]);
				dFechaUltimaVisitaDentista.SetDbValue(rs["dFechaUltimaVisitaDentista"]);
				sMotivoVisita.SetDbValue(rs["sMotivoVisita"]);
				sExperienciaAsistencial.SetDbValue(rs["sExperienciaAsistencial"]);
				nTratamientoQuirurgico.SetDbValue(ConvertToBool(rs["nTratamientoQuirurgico"]) ? "1" : "0");
				nTratamientoRestauracion.SetDbValue(ConvertToBool(rs["nTratamientoRestauracion"]) ? "1" : "0");
				nTratamientoPeridoncia.SetDbValue(ConvertToBool(rs["nTratamientoPeridoncia"]) ? "1" : "0");
				nTratamientoEndodoncia.SetDbValue(ConvertToBool(rs["nTratamientoEndodoncia"]) ? "1" : "0");
				nTratamientoOrtodoncia.SetDbValue(ConvertToBool(rs["nTratamientoOrtodoncia"]) ? "1" : "0");
				nTratamientoProtesis.SetDbValue(ConvertToBool(rs["nTratamientoProtesis"]) ? "1" : "0");
				nColocadoAnestesia.SetDbValue(ConvertToBool(rs["nColocadoAnestesia"]) ? "1" : "0");
				nReaccionAlergicaAnestesia.SetDbValue(ConvertToBool(rs["nReaccionAlergicaAnestesia"]) ? "1" : "0");
				sReaccionAlergicaAnestesia.SetDbValue(rs["sReaccionAlergicaAnestesia"]);
				sDescripcionTejidosBlandos.SetDbValue(rs["sDescripcionTejidosBlandos"]);
				sHistoriaEnfermedadActual.SetDbValue(rs["sHistoriaEnfermedadActual"]);
				nEstadoID.SetDbValue(rs["nEstadoID"]);
				dFechaCreacion.SetDbValue(rs["dFechaCreacion"]);
				dFechaModificacion.SetDbValue(rs["dFechaModificacion"]);
			}

			#pragma warning disable 1998

			// Render list row values
			public async Task RenderListRow() {

				// Call Row Rendering event
				Row_Rendering();

				// Common render codes
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

				// nAntecedenteDentalID
				nAntecedenteDentalID.ViewValue = nAntecedenteDentalID.CurrentValue;

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

				// dFechaCreacion
				dFechaCreacion.ViewValue = dFechaCreacion.CurrentValue;
				dFechaCreacion.ViewValue = FormatDateTime(dFechaCreacion.ViewValue, 0);

				// dFechaModificacion
				dFechaModificacion.ViewValue = dFechaModificacion.CurrentValue;
				dFechaModificacion.ViewValue = FormatDateTime(dFechaModificacion.ViewValue, 0);

				// nAntecedenteDentalID
				nAntecedenteDentalID.HrefValue = "";
				nAntecedenteDentalID.TooltipValue = "";

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

				// nAntecedenteDentalID
				nAntecedenteDentalID.EditAttrs["class"] = "form-control";
				nAntecedenteDentalID.EditValue = nAntecedenteDentalID.CurrentValue;

				// nExpedienteID
				nExpedienteID.EditAttrs["class"] = "form-control";

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
				// dFechaCreacion

				dFechaCreacion.EditAttrs["class"] = "form-control";
				dFechaCreacion.EditValue = FormatDateTime(dFechaCreacion.CurrentValue, 8); // DN
				dFechaCreacion.PlaceHolder = RemoveHtml(dFechaCreacion.Caption);

				// dFechaModificacion
				dFechaModificacion.EditAttrs["class"] = "form-control";
				dFechaModificacion.EditValue = FormatDateTime(dFechaModificacion.CurrentValue, 8); // DN
				dFechaModificacion.PlaceHolder = RemoveHtml(dFechaModificacion.Caption);

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
							doc.ExportCaption(nExpedienteID);
							doc.ExportCaption(dFechaUltimaVisitaDentista);
							doc.ExportCaption(sMotivoVisita);
							doc.ExportCaption(sExperienciaAsistencial);
							doc.ExportCaption(nTratamientoQuirurgico);
							doc.ExportCaption(nTratamientoRestauracion);
							doc.ExportCaption(nTratamientoPeridoncia);
							doc.ExportCaption(nTratamientoEndodoncia);
							doc.ExportCaption(nTratamientoOrtodoncia);
							doc.ExportCaption(nTratamientoProtesis);
							doc.ExportCaption(nColocadoAnestesia);
							doc.ExportCaption(nReaccionAlergicaAnestesia);
							doc.ExportCaption(sReaccionAlergicaAnestesia);
							doc.ExportCaption(sDescripcionTejidosBlandos);
							doc.ExportCaption(sHistoriaEnfermedadActual);
							doc.ExportCaption(nEstadoID);
						} else {
							doc.ExportCaption(nExpedienteID);
							doc.ExportCaption(dFechaUltimaVisitaDentista);
							doc.ExportCaption(sMotivoVisita);
							doc.ExportCaption(sExperienciaAsistencial);
							doc.ExportCaption(nTratamientoQuirurgico);
							doc.ExportCaption(nTratamientoRestauracion);
							doc.ExportCaption(nTratamientoPeridoncia);
							doc.ExportCaption(nTratamientoEndodoncia);
							doc.ExportCaption(nTratamientoOrtodoncia);
							doc.ExportCaption(nTratamientoProtesis);
							doc.ExportCaption(nColocadoAnestesia);
							doc.ExportCaption(nReaccionAlergicaAnestesia);
							doc.ExportCaption(sReaccionAlergicaAnestesia);
							doc.ExportCaption(sDescripcionTejidosBlandos);
							doc.ExportCaption(sHistoriaEnfermedadActual);
							doc.ExportCaption(nEstadoID);
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
								await doc.ExportField(nExpedienteID);
								await doc.ExportField(dFechaUltimaVisitaDentista);
								await doc.ExportField(sMotivoVisita);
								await doc.ExportField(sExperienciaAsistencial);
								await doc.ExportField(nTratamientoQuirurgico);
								await doc.ExportField(nTratamientoRestauracion);
								await doc.ExportField(nTratamientoPeridoncia);
								await doc.ExportField(nTratamientoEndodoncia);
								await doc.ExportField(nTratamientoOrtodoncia);
								await doc.ExportField(nTratamientoProtesis);
								await doc.ExportField(nColocadoAnestesia);
								await doc.ExportField(nReaccionAlergicaAnestesia);
								await doc.ExportField(sReaccionAlergicaAnestesia);
								await doc.ExportField(sDescripcionTejidosBlandos);
								await doc.ExportField(sHistoriaEnfermedadActual);
								await doc.ExportField(nEstadoID);
							} else {
								await doc.ExportField(nExpedienteID);
								await doc.ExportField(dFechaUltimaVisitaDentista);
								await doc.ExportField(sMotivoVisita);
								await doc.ExportField(sExperienciaAsistencial);
								await doc.ExportField(nTratamientoQuirurgico);
								await doc.ExportField(nTratamientoRestauracion);
								await doc.ExportField(nTratamientoPeridoncia);
								await doc.ExportField(nTratamientoEndodoncia);
								await doc.ExportField(nTratamientoOrtodoncia);
								await doc.ExportField(nTratamientoProtesis);
								await doc.ExportField(nColocadoAnestesia);
								await doc.ExportField(nReaccionAlergicaAnestesia);
								await doc.ExportField(sReaccionAlergicaAnestesia);
								await doc.ExportField(sDescripcionTejidosBlandos);
								await doc.ExportField(sHistoriaEnfermedadActual);
								await doc.ExportField(nEstadoID);
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
