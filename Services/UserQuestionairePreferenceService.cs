using TODOListInteligence.Config;
using TODOListInteligence.Models;

namespace TODOListInteligence.Services
{
    public class UserQuestionairePreferenceService
    {
        public static void ProcessQuestionnaire(
           UserConfig user,
            List<UserAnswer> answers,
            string userLanguage)
        {
            user.InitDictionaries();

            var optionToArea = userLanguage == "es"
                ? QuestionnaireMapping.OptionToAreaEs
                : QuestionnaireMapping.OptionToAreaEn;

            foreach (var answer in answers)
            {
                if (!optionToArea.TryGetValue(answer.SelectedOption, out var area))
                    continue;

                    // Normalizo el tipo a minúsculas para comparar
                        string type = answer.QuestionType.ToLowerInvariant();
                        // incremento el valor de un área si se ha seleccionado en una respuesta
                        if (type == "importancia" || type == "importance")
                            user.Importance[area]++;
                        else if (type == "urgencia" || type == "urgency")
                            user.Urgency[area]++;
            }
        }
    
    }
}
