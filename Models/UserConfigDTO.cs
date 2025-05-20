using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace TODOListInteligence.Models
{
    public class UserConfigDTO
    {
        // Datos personales
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        // Configuración
        public string UserLanguage { get; set; }
        public string UserTheme { get; set; } // "light" o "dark"

        // Respuestas del cuestionario
        public List<UserAnswer> UserAnswers { get; set; }

        // Palabras clave personalizadas por área
        public Dictionary<AreaType, List<string>> AreaKeywords { get; set; }

        // Puntuaciones por área
        public Dictionary<AreaType, int> Importance { get; set; }
        public Dictionary<AreaType, int> Urgency { get; set; }
        public Dictionary<AreaType, double> ImportancePercent { get; set; }
        public Dictionary<AreaType, double> UrgencyPercent { get; set; }

        //tareas del usuario
        public List<UserTask> UserTasks { get; set; }


        //colecciones para cada cuadrante.
        //es una colección especial que notifica automáticamente a la interfaz de usuario cada vez que se agrega, elimina o cambia un elemento.
        public ObservableCollection<UserTask> UrgentAndImportantTasks { get; set; } = new();    // Quadrant 1: Urgent & Important
        public ObservableCollection<UserTask> ImportantButNotUrgentTasks { get; set; } = new(); // Quadrant 2: Important but Not Urgent
        public ObservableCollection<UserTask> UrgentButNotImportantTasks { get; set; } = new(); // Quadrant 3: Urgent but Not Important
        public ObservableCollection<UserTask> NeitherUrgentNorImportantTasks { get; set; } = new(); // Quadrant 4: Neither Urgent nor Important

        //Diccionario que me agrupa por área todas las tareas para poder filtrarlas a futuro
        public Dictionary<AreaType, List<UserTask>> TasksByArea { get; set; }
    }
}
