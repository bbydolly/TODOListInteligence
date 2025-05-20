using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TODOListInteligence.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;

namespace TODOListInteligence.Storage
{
    public static class UserConfigStorage
    {
        private static string FilePath =>
            Path.Combine(FileSystem.AppDataDirectory, "userconfig.json");

        public static void Save()
        {
            var dto = CopyFromSingleton();
            var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
            Debug.WriteLine(FilePath);
        }

        public static void Load()
        {
            if (File.Exists(FilePath))
            {
                var json = File.ReadAllText(FilePath);
                var loadedConfig = JsonSerializer.Deserialize<UserConfigDTO>(json);
                if (loadedConfig != null)
                {
                    // Copia los datos cargados al singleton
                    CopyToSingleton(loadedConfig);
                }
            }
        }

        private static void CopyToSingleton(UserConfigDTO loaded)
        {
            var singleton = UserConfig.Instance;
            singleton.Name = loaded.Name;
            singleton.Email = loaded.Email;
            singleton.Password = loaded.Password;
            singleton.UserLanguage = loaded.UserLanguage;
            singleton.UserTheme = loaded.UserTheme;
            singleton.UserAnswers = loaded.UserAnswers ?? new List<UserAnswer>();
            singleton.AreaKeywords = loaded.AreaKeywords ?? new Dictionary<AreaType, List<string>>();
            singleton.Importance = loaded.Importance ?? new Dictionary<AreaType, int>();
            singleton.Urgency = loaded.Urgency ?? new Dictionary<AreaType, int>();
            singleton.ImportancePercent = loaded.ImportancePercent ?? new Dictionary<AreaType, double>();
            singleton.UrgencyPercent = loaded.UrgencyPercent ?? new Dictionary<AreaType, double>();
            singleton.UserTasks = loaded.UserTasks ?? new List<UserTask> { };
            singleton.UrgentAndImportantTasks = loaded.UrgentAndImportantTasks
                ?? new ObservableCollection<UserTask>();
            singleton.ImportantButNotUrgentTasks = loaded.ImportantButNotUrgentTasks ?? new ObservableCollection<UserTask>();
            singleton.UrgentButNotImportantTasks = loaded.UrgentButNotImportantTasks ?? new ObservableCollection<UserTask>();
            singleton.NeitherUrgentNorImportantTasks = loaded.NeitherUrgentNorImportantTasks ?? new ObservableCollection<UserTask>();
        }

        private static UserConfigDTO CopyFromSingleton()
        {
            var instance = UserConfig.Instance;
            UserConfigDTO dto = new UserConfigDTO();

            if (instance == null) return dto;

            dto.Name = instance.Name;
            dto.Email = instance.Email;
            dto.Password = instance.Password;
            dto.UserLanguage = instance.UserLanguage;
            dto.UserTheme = instance.UserTheme;
            dto.UserAnswers = instance.UserAnswers;
            dto.AreaKeywords = instance.AreaKeywords;
            dto.Importance = instance.Importance;
            dto.Urgency = instance.Urgency;
            dto.ImportancePercent = instance.ImportancePercent;
            dto.UrgencyPercent = instance.UrgencyPercent;
            dto.UserTasks = instance.UserTasks;
            dto.UrgentAndImportantTasks = instance.UrgentAndImportantTasks;
            dto.ImportantButNotUrgentTasks = instance.ImportantButNotUrgentTasks;
            dto.UrgentButNotImportantTasks = instance.UrgentButNotImportantTasks;
            dto.NeitherUrgentNorImportantTasks = instance.NeitherUrgentNorImportantTasks;

            return dto;
        }
    }
}
