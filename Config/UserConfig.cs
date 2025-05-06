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
        //  Lazy<UserConfig> asegura que la instancia se crea solo cuando se usa por primera vez, es decir, cuando es necesaria
        private static readonly Lazy<UserConfig> lazyUserConfig = new(()=>new UserConfig());
        //Propiedad pública que da acceso a la instancia única (singleton) de UserConfig
        public static UserConfig Instance => lazyUserConfig.Value;
        public string UserLanguage { get; set; }
        public string UserTheme { get; set; } //light o dark
        //A futuro pretendo desarrollar un propio diccionario por Área de palabras clave
        //para que el usuario pueda integrar su propio vocabulario que puede no estar contenido
        //en la lista de palabras clave que he diseñado
        public Dictionary<AreaType, List<string>> AreaKeywords { get; set; }

        public UserConfig() 
        {
            UserLanguage = "es";
            UserTheme = "light";
            AreaKeywords = new Dictionary<AreaType, List<string>>();
            UserAnswers = new List<UserAnswer>();
        }

        // Métodos para cargar y guardar datos de sus palabras clave

        //Necesito guardar la colección de respuestas del usuario
        public List<UserAnswer> UserAnswers { get; set; }

    }
}
