// Models
namespace AspNetMaker2019.Models {

	// Partial class
	public partial class prjSIGECO {

		// Set up menus
		public static void SetupMenus() {

			// Navbar menu
			var topMenu = new Menu("navbar", true, true);
			TopMenu = topMenu.ToScript();

			// Sidebar menu
			var sideMenu = new Menu("menu", true, false);
			sideMenu.AddMenuItem(26, "mci_Básicos", Language.MenuPhrase("26", "MenuText"), "", -1, "", true, false, true, "fa fa-sitemap", "", false);
			sideMenu.AddMenuItem(3, "mi_Catalogo", Language.MenuPhrase("3", "MenuText"), "Catalogolist", 26, "", true, false, false, "", "", false);
			sideMenu.AddMenuItem(17, "mi_Tratamiento", Language.MenuPhrase("17", "MenuText"), "Tratamientolist", 26, "", true, false, false, "", "", false);
			sideMenu.AddMenuItem(52, "mci_Pacientes", Language.MenuPhrase("52", "MenuText"), "", -1, "", true, false, true, "fa fa-users", "", false);
			sideMenu.AddMenuItem(10, "mi_Paciente", Language.MenuPhrase("10", "MenuText"), "Pacientelist", 52, "", true, false, false, "fa fa-user", "", false);
			sideMenu.AddMenuItem(78, "mci_Antecedentes", Language.MenuPhrase("78", "MenuText"), "", 52, "", true, false, true, "", "", false);
			sideMenu.AddMenuItem(1, "mi_AntecedenteDental", Language.MenuPhrase("1", "MenuText"), "AntecedenteDentallist", 78, "", true, false, false, "", "", false);
			sideMenu.AddMenuItem(2, "mi_AntecedenteFamiliar", Language.MenuPhrase("2", "MenuText"), "AntecedenteFamiliarlist", 78, "", true, false, false, "", "", false);
			sideMenu.AddMenuItem(79, "mci_Examenes", Language.MenuPhrase("79", "MenuText"), "", 52, "", true, false, true, "", "", false);
			sideMenu.AddMenuItem(6, "mi_ExamenComplementario", Language.MenuPhrase("6", "MenuText"), "ExamenComplementariolist", 79, "", true, false, false, "", "", false);
			sideMenu.AddMenuItem(82, "mci_Odontograma", Language.MenuPhrase("82", "MenuText"), "Odontograma/View", 79, "", true, false, true, "fa fa-table", "", false);
			sideMenu.AddMenuItem(83, "mci_Periodontorama", Language.MenuPhrase("83", "MenuText"), "", 79, "", true, false, true, "fa fa-table", "", false);
			sideMenu.AddMenuItem(84, "mci_Placagrama", Language.MenuPhrase("84", "MenuText"), "", 79, "", true, false, true, "fa fa-table", "", false);
			sideMenu.AddMenuItem(80, "mci_Tratamientos", Language.MenuPhrase("80", "MenuText"), "", 52, "", true, false, true, "", "", false);
			sideMenu.AddMenuItem(18, "mi_TratamientoRealizado", Language.MenuPhrase("18", "MenuText"), "TratamientoRealizadolist", 80, "", true, false, false, "", "", false);
			sideMenu.AddMenuItem(85, "mci_Citas", Language.MenuPhrase("85", "MenuText"), "", -1, "", true, false, true, "fa fa-calendar", "", false);
			sideMenu.AddMenuItem(4, "mi_Cita", Language.MenuPhrase("4", "MenuText"), "Citalist", 85, "", true, false, false, "fa fa-table", "", false);
			sideMenu.AddMenuItem(86, "mci_Calendario", Language.MenuPhrase("86", "MenuText"), "Calendar", 85, "", true, false, true, "fa fa-calendar", "", false);
			sideMenu.AddMenuItem(19, "mi_Usuario", Language.MenuPhrase("19", "MenuText"), "Usuariolist", -1, "", true, false, false, "", "", false);
			SideMenu = sideMenu.ToScript();
		}
	}
}
