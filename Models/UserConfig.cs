using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TODOListInteligence.Models
{

    public class UserConfig
    {
        // Singleton
        private static readonly Lazy<UserConfig> lazyInstance = new(() => new UserConfig());
        public static UserConfig Instance => lazyInstance.Value;

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

        public ICommand DeleteTaskCommand { get; }


        // Constructor privado para singleton
        private UserConfig()
        {
            UserLanguage = "es";
            UserTheme = "light";
            Name = "";
            Email = "";
            Password = "";
            UserAnswers = new List<UserAnswer>();
            AreaKeywords = new Dictionary<AreaType, List<string>>();
            Importance = new Dictionary<AreaType, int>();
            Urgency = new Dictionary<AreaType, int>();
            ImportancePercent = new Dictionary<AreaType, double>();
            UrgencyPercent = new Dictionary<AreaType, double>();
            UserTasks = new List<UserTask>();
            TasksByArea = new Dictionary<AreaType, List<UserTask>>();
            foreach (AreaType area in Enum.GetValues(typeof(AreaType)))
            {
                TasksByArea[area] = new List<UserTask>();
            }
            DeleteTaskCommand = new Command<UserTask>(OnDeleteTask);

            InitDictionaries();
        }

        // Métodos de inicialización y cálculo
        public void InitDictionaries()
        {
            foreach (AreaType area in Enum.GetValues(typeof(AreaType)))
            {
                Importance[area] = 0;
                Urgency[area] = 0;
                ImportancePercent[area] = 0;
                UrgencyPercent[area] = 0;
            }
        }

        public void CalculatePercents()
        {
            int totalImportance = Importance.Values.Sum();
            int totalUrgency = Urgency.Values.Sum();

            foreach (AreaType area in Enum.GetValues(typeof(AreaType)))
            {
                ImportancePercent[area] = totalImportance > 0 ? (double)Importance[area] / totalImportance : 0;
                UrgencyPercent[area] = totalUrgency > 0 ? (double)Urgency[area] / totalUrgency : 0;
            }
        }

        public bool IsAreaImportant(AreaType area, double threshold = 0.4)
            => ImportancePercent.TryGetValue(area, out var val) && val >= threshold;

        public bool IsAreaUrgent(AreaType area, double threshold = 0.3)
            => UrgencyPercent.TryGetValue(area, out var val) && val >= threshold;


        private void OnDeleteTask(UserTask task)
        {
            UrgentAndImportantTasks.Remove(task);
            ImportantButNotUrgentTasks.Remove(task);
            UrgentButNotImportantTasks.Remove(task);
            NeitherUrgentNorImportantTasks.Remove(task);
        }
    }

}

