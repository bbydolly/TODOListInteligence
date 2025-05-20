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
            var culture = userLang switch
            {
                "en" => new CultureInfo("en-US"),
                "es" => new CultureInfo("es-ES"),
                _ => new CultureInfo("es-ES")
            };

            Thread.CurrentThread.CurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            CultureInfo.DefaultThreadCurrentCulture = culture;
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

