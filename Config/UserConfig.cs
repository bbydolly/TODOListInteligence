using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODOListInteligence.Models;

namespace TODOListInteligence.Config
{
    internal class UserConfig
    {
        public string UserLanguage { get; set; }
        public string UserTheme { get; set; }
        public Dictionary<AreaType, List<string>> AreaKeywords { get; set; }

        // Métodos para cargar y guardar datos de sus palabras clave
    }
}
