using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui; // Necesario para Application
using Microsoft.Maui.Controls;
using TODOListInteligence.Models; // Necesario para Application.Current y AppTheme

namespace TODOListInteligence.Helpers
{
    internal class AppSettings
    {
        public static void ApplyCulture()
        {
            string userLang = UserConfig.Instance.UserLanguage ?? "es";
            CultureInfo culture = new CultureInfo(userLang);
            Thread.CurrentThread.CurrentUICulture = culture;
        }

        public static void ApplyTheme()
        {
            // Obtengo el tema preferido del usuario ("light" o "dark").
            // Si no está definido, usa "light" como predeterminado.
            string theme = UserConfig.Instance.UserTheme ?? "light";

            // Comprueba que Application.Current no sea null antes de asignar el tema.
            if (Application.Current != null)
            {
                Application.Current.UserAppTheme = theme == "dark" ? AppTheme.Dark : AppTheme.Light;
            } //AppTheme es parte de la API de MAUI
        }
    }
}

