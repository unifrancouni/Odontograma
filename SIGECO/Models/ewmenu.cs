// Models
namespace AspNetMaker2019.Models {

	// Partial class
	public partial class prjSIGECO {

		// Menu language
		public static Lang MenuLanguage;

		// Set up menus
		public static void SetupMenus() {

			// Menu Language
			if (Language != null && Language.LanguageFolder == Config.LanguageFolder)
				MenuLanguage = Language;
			else
				MenuLanguage = new Lang();

			// Navbar menu
			var topMenu = new Menu("navbar", true, true);
			TopMenu = topMenu.ToScript();

			// Sidebar menu
			var sideMenu = new Menu("menu", true, false);
			sideMenu.AddMenuItem(26, "mci_Básicos", MenuLanguage.MenuPhrase("26", "MenuText"), "", -1, "", true, false, true, "fa fa-sitemap", "", false);
			sideMenu.AddMenuItem(3, "mi_Catalogo", MenuLanguage.MenuPhrase("3", "MenuText"), "Catalogolist", 26, "", IsLoggedIn() || AllowList("{9B083C8B-EE2F-4356-BE8D-9A26D5707365}Catalogo"), false, false, "", "", false);
			sideMenu.AddMenuItem(17, "mi_Tratamiento", MenuLanguage.MenuPhrase("17", "MenuText"), "Tratamientolist", 26, "", IsLoggedIn() || AllowList("{9B083C8B-EE2F-4356-BE8D-9A26D5707365}Tratamiento"), false, false, "", "", false);
			sideMenu.AddMenuItem(52, "mci_Pacientes", MenuLanguage.MenuPhrase("52", "MenuText"), "", -1, "", true, false, true, "fa fa-users", "", false);
			sideMenu.AddMenuItem(10, "mi_Paciente", MenuLanguage.MenuPhrase("10", "MenuText"), "Pacientelist", 52, "", IsLoggedIn() || AllowList("{9B083C8B-EE2F-4356-BE8D-9A26D5707365}Paciente"), false, false, "fa fa-user", "", false);
			sideMenu.AddMenuItem(78, "mci_Antecedentes", MenuLanguage.MenuPhrase("78", "MenuText"), "", 52, "", true, false, true, "", "", false);
			sideMenu.AddMenuItem(1, "mi_AntecedenteDental", MenuLanguage.MenuPhrase("1", "MenuText"), "AntecedenteDentallist", 78, "", IsLoggedIn() || AllowList("{9B083C8B-EE2F-4356-BE8D-9A26D5707365}AntecedenteDental"), false, false, "", "", false);
			sideMenu.AddMenuItem(2, "mi_AntecedenteFamiliar", MenuLanguage.MenuPhrase("2", "MenuText"), "AntecedenteFamiliarlist", 78, "", IsLoggedIn() || AllowList("{9B083C8B-EE2F-4356-BE8D-9A26D5707365}AntecedenteFamiliar"), false, false, "", "", false);
			sideMenu.AddMenuItem(79, "mci_Examenes", MenuLanguage.MenuPhrase("79", "MenuText"), "", 52, "", true, false, true, "", "", false);
			sideMenu.AddMenuItem(6, "mi_ExamenComplementario", MenuLanguage.MenuPhrase("6", "MenuText"), "ExamenComplementariolist", 79, "", IsLoggedIn() || AllowList("{9B083C8B-EE2F-4356-BE8D-9A26D5707365}ExamenComplementario"), false, false, "", "", false);
			sideMenu.AddMenuItem(8, "mi_Odontograma", MenuLanguage.MenuPhrase("8", "MenuText"), "Odontogramalist", 79, "", IsLoggedIn() || AllowList("{9B083C8B-EE2F-4356-BE8D-9A26D5707365}Odontograma"), false, false, "", "", false);
			//sideMenu.AddMenuItem(11, "mi_Periodontograma", MenuLanguage.MenuPhrase("11", "MenuText"), "Periodontogramalist", 79, "", IsLoggedIn() || AllowList("{9B083C8B-EE2F-4356-BE8D-9A26D5707365}Periodontograma"), false, false, "", "", false);
			sideMenu.AddMenuItem(13, "mi_Placagrama", MenuLanguage.MenuPhrase("13", "MenuText"), "Placagramalist", 79, "", IsLoggedIn() || AllowList("{9B083C8B-EE2F-4356-BE8D-9A26D5707365}Placagrama"), false, false, "", "", false);
			sideMenu.AddMenuItem(80, "mci_Tratamientos", MenuLanguage.MenuPhrase("80", "MenuText"), "", 52, "", true, false, true, "", "", false);
			sideMenu.AddMenuItem(18, "mi_TratamientoRealizado", MenuLanguage.MenuPhrase("18", "MenuText"), "TratamientoRealizadolist", 80, "", IsLoggedIn() || AllowList("{9B083C8B-EE2F-4356-BE8D-9A26D5707365}TratamientoRealizado"), false, false, "", "", false);
			sideMenu.AddMenuItem(89, "mi_PlanTratamiento", MenuLanguage.MenuPhrase("89", "MenuText"), "PlanTratamientolist", 80, "", IsLoggedIn() || AllowList("{9B083C8B-EE2F-4356-BE8D-9A26D5707365}PlanTratamiento"), false, false, "", "", false);
			sideMenu.AddMenuItem(85, "mci_Citas", MenuLanguage.MenuPhrase("85", "MenuText"), "", -1, "", true, false, true, "fa fa-calendar", "", false);
			sideMenu.AddMenuItem(4, "mi_Cita", MenuLanguage.MenuPhrase("4", "MenuText"), "Citalist", 85, "", IsLoggedIn() || AllowList("{9B083C8B-EE2F-4356-BE8D-9A26D5707365}Cita"), false, false, "fa fa-table", "", false);
			sideMenu.AddMenuItem(86, "mci_Calendario", MenuLanguage.MenuPhrase("86", "MenuText"), "Calendar\" target=\"_blank", 85, "", IsLoggedIn() || AllowList("{9B083C8B-EE2F-4356-BE8D-9A26D5707365}Placagrama"), false, true, "fa fa-calendar", "", false);
			sideMenu.AddMenuItem(19, "mi_Usuario", MenuLanguage.MenuPhrase("19", "MenuText"), "Usuariolist", -1, "", IsLoggedIn() || AllowList("{9B083C8B-EE2F-4356-BE8D-9A26D5707365}Usuario"), false, false, "", "", false);
			SideMenu = sideMenu.ToScript();
		}
	}
}
