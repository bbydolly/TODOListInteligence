using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODOListInteligence.Config;
using TODOListInteligence.Models;

namespace TODOListInteligence.Services
{
    public class TaskDistributionService
    {
        public void DistributeTasksByAreaAndQuadrant(UserConfig userConfig)
        {
            //Debug para ver si contiene tareas la coleccion
            System.Diagnostics.Debug.WriteLine($"[DEBUG] Total tareas en UserTasks: {userConfig.UserTasks.Count}");

            // código de distribución 
            foreach (var task in userConfig.UserTasks)
            {
                if (task.IsDistributed)
                {

                    System.Diagnostics.Debug.WriteLine($"[DEBUG] Tarea ya distribuida: '{task.Title}'");
                    continue; // Salto si ya está distribuida
                }

                // 1. Detectar área usando SOLO el título (a futuro usaré la descripcción como complemento)
                AreaType? area = AppConfig.Instance.DetectArea(task.Title);
                if (area == null)
                {

                    System.Diagnostics.Debug.WriteLine($"[DEBUG] No se detectó área para tarea: '{task.Title}'");
                    continue;
                }

                // 2. Agrego la tarea al área correspondiente si no la contiene 
                if (!userConfig.TasksByArea[area.Value].Contains(task))
                {
                    userConfig.TasksByArea[area.Value].Add(task);

                }

                // 3. Decidir cuadrante: PRIORIDAD a la selección manual del usuario
                bool isImportant, isUrgent;

                if (task.IsImportant || task.IsUrgent)
                {
                    // El usuario ha marcado manualmente, se respeta su selección
                    isImportant = task.IsImportant;
                    isUrgent = task.IsUrgent;
                    System.Diagnostics.Debug.WriteLine($"[DEBUG] Selección manual para '{task.Title}': IsImportant={isImportant}, IsUrgent={isUrgent}");
                }
                else
                {
                    // No hay selección manual: aplica los porcentajes del cuestionario por área
                    isImportant = userConfig.IsAreaImportant(area.Value);
                    isUrgent = userConfig.IsAreaUrgent(area.Value);
                    System.Diagnostics.Debug.WriteLine($"[DEBUG] Selección automática para '{task.Title}': IsImportant={isImportant}, IsUrgent={isUrgent}");
                    // Actualiza los flags de la tarea (opcional, útil para la UI)
                    task.IsImportant = isImportant;
                    task.IsUrgent = isUrgent;
                }

                // 4. Agrego al cuadrante correspondiente (evito duplicados comprobando)
                if (isImportant && isUrgent)
                {
                    if (!userConfig.UrgentAndImportantTasks.Contains(task))
                    {
                        userConfig.UrgentAndImportantTasks.Add(task);
                        System.Diagnostics.Debug.WriteLine($"[DEBUG] Agregada a UrgentAndImportantTasks: {task.Title}");

                    }
                }
                else if (isImportant && !isUrgent)
                {
                    if (!userConfig.ImportantButNotUrgentTasks.Contains(task))
                    {
                        userConfig.ImportantButNotUrgentTasks.Add(task);
                        System.Diagnostics.Debug.WriteLine($"[DEBUG] Agregada a ImportantButNotUrgentTasks: {task.Title}");

                    }
                }
                else if (!isImportant && isUrgent)
                {
                    if (!userConfig.UrgentButNotImportantTasks.Contains(task))
                    {
                        userConfig.UrgentButNotImportantTasks.Add(task);
                        System.Diagnostics.Debug.WriteLine($"[DEBUG] Agregada a UrgentButNotImportantTasks: {task.Title}");
                    }
                }
                else
                {
                    if (!userConfig.NeitherUrgentNorImportantTasks.Contains(task))
                    {
                        userConfig.NeitherUrgentNorImportantTasks.Add(task);
                        System.Diagnostics.Debug.WriteLine($"[DEBUG] Agregada a NeitherUrgentNorImportantTasks: {task.Title}");
                    }
                }

                // 5. Marco la tarea como distribuida
                task.IsDistributed = true;
            }
        }
    }
}
