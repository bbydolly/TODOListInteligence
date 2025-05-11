using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public List<UserTask> UserTasks { get; set; }


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
    }

}

