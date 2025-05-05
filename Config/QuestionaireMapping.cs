using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODOListInteligence.Models;

namespace TODOListInteligence.Config
{
    //Clase que mapea las respuestas del cuestionario a un Área determinada en el enumerado AreaType (en en y es)
public static class QuestionnaireMapping
{
    // Español
    public static readonly Dictionary<string, AreaType> OptionToAreaEs = new(StringComparer.OrdinalIgnoreCase)
    {
        { "Familia", AreaType.Family },
        { "Trabajo", AreaType.Work },
        { "Salud", AreaType.Health },
        { "Amigos", AreaType.Friends },
        { "Ocio", AreaType.Leisure },
        { "Tiempo con la familia", AreaType.Family },
        { "Logros profesionales", AreaType.Work },
        { "Cuidar tu salud", AreaType.Health },
        { "Aprender cosas nuevas", AreaType.Leisure },
        { "Citas médicas", AreaType.Health },
        { "Reuniones familiares", AreaType.Family },
        { "Proyectos laborales", AreaType.Work },
        { "Tiempo para ti", AreaType.Leisure },
        { "Peticiones de la familia", AreaType.Family },
        { "Urgencias del trabajo", AreaType.Work },
        { "Invitaciones de amigos", AreaType.Friends },
        { "Actividades de ocio", AreaType.Leisure },
        { "Entregas laborales", AreaType.Work },
        { "Citas familiares", AreaType.Family },
        { "Revisiones médicas", AreaType.Health },
        { "Actividades sociales", AreaType.Friends },
        { "Las urgentes", AreaType.Work },
        { "Las importantes", AreaType.Family },
        { "Las que me gustan", AreaType.Leisure },
        { "Las que me piden otros", AreaType.Friends },
        { "Ejercicio físico", AreaType.Health },
        { "Reuniones de trabajo", AreaType.Work },
        { "Tiempo con amigos", AreaType.Friends },
        { "Estudio personal", AreaType.Leisure }
    };

    // Inglés
    public static readonly Dictionary<string, AreaType> OptionToAreaEn = new(StringComparer.OrdinalIgnoreCase)
    {
        { "Family", AreaType.Family },
        { "Work", AreaType.Work },
        { "Health", AreaType.Health },
        { "Friends", AreaType.Friends },
        { "Leisure", AreaType.Leisure },
        { "Time with family", AreaType.Family },
        { "Professional achievements", AreaType.Work },
        { "Taking care of your health", AreaType.Health },
        { "Learning new things", AreaType.Leisure },
        { "Medical appointments", AreaType.Health },
        { "Family meetings", AreaType.Family },
        { "Work projects", AreaType.Work },
        { "Time for yourself", AreaType.Leisure },
        { "Family requests", AreaType.Family },
        { "Work urgencies", AreaType.Work },
        { "Friends' invitations", AreaType.Friends },
        { "Leisure activities", AreaType.Leisure },
        { "Work deadlines", AreaType.Work },
        { "Family appointments", AreaType.Family },
        { "Medical check-ups", AreaType.Health },
        { "Social activities", AreaType.Friends },
        { "Urgent ones", AreaType.Work },
        { "Important ones", AreaType.Family },
        { "Ones I like", AreaType.Leisure },
        { "Ones others ask me to do", AreaType.Friends },
        { "Physical exercise", AreaType.Health },
        { "Work meetings", AreaType.Work },
        { "Time with friends", AreaType.Friends },
        { "Personal study", AreaType.Leisure }
    };
}
}
