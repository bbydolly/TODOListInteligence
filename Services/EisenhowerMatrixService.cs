using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODOListInteligence.Models;

namespace TODOListInteligence.Config
{

    public static class EisenhowerMatrixService
    {

        public static string ClassifyTask(UserConfig user, string taskDescription)
        {
            // 1. Detecta el área de la tarea
            AreaType? area = AppConfig.Instance.DetectArea(taskDescription);
            if (area == null)
                return "No clasificada (no se detectó área)";

            // 2. Consulta los diccionarios del usuario
            bool isImportant = user.Importance.TryGetValue(area.Value, out int impCount) && impCount >= EisenhowerConfig.ImportanceThreshold;
            bool isUrgent = user.Urgency.TryGetValue(area.Value, out int urgCount) && urgCount >= EisenhowerConfig.UrgencyThreshold;

            // 3. Clasifica según Eisenhower
            if (isImportant && isUrgent)
                return "Cuadrante 1: Importante y Urgente (Hazlo ahora)";
            else if (isImportant)
                return "Cuadrante 2: Importante, no Urgente (Planifica)";
            else if (isUrgent)
                return "Cuadrante 3: Urgente, no Importante (Delega)";
            else
                return "Cuadrante 4: No Importante ni Urgente (Elimina o pospone)";
        }
    }
}

