using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TODOListInteligence.Models;
using System.IO;

namespace TODOListInteligence.Storage
{
    public static class UserConfigStorage
    {
        private static string FilePath =>
            Path.Combine(FileSystem.AppDataDirectory, "userconfig.json");

        public static void Save()
        {
            var json = JsonSerializer.Serialize(UserConfig.Instance, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }

        public static void Load()
        {
            if (File.Exists(FilePath))
            {
                var json = File.ReadAllText(FilePath);
                var loadedConfig = JsonSerializer.Deserialize<UserConfig>(json);
                if (loadedConfig != null)
                {
                    // Copia los datos cargados al singleton
                    CopyToSingleton(loadedConfig);
                }
            }
        }

        private static void CopyToSingleton(UserConfig loaded)
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
        }
    }
}
