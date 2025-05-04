using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODOListInteligence.Models;

namespace TODOListInteligence.Config
{
    public class AppConfig
    {
        public string Language { get; set; } = "es";
        public string Theme { get; set; } = "claro";

        private static AppConfig _instance;
        public static AppConfig Instance => _instance ??= new AppConfig();

        // Palabras clave por área (español + inglés)
        public static readonly List<string> WorkKeywords = new()
        {
            // Español
            "trabajo", "curro", "empleo", "oficina", "proyecto", "reunión", "informe", "jefe", "compañero", "entrega", "tarea", "objetivo", "ascenso", "salario", "nómina", "jornada", "horario", "rrhh", "mail", "presentación", "cliente", "proveedor", "agenda", "teletrabajo", "remoto", "contrato", "despacho", "reporte", "plan", "evaluación",
            // Inglés
            "work", "job", "office", "project", "meeting", "report", "boss", "coworker", "deadline", "deliverable", "task", "objective", "goal", "raise", "payroll", "shift", "schedule", "hr", "email", "client", "provider", "remote", "telework", "contract", "desk", "brief", "plan", "review", "promotion", "assignment"
        };

        public static readonly List<string> FamilyKeywords = new()
        {
            // Español
            "familia", "padres", "madre", "padre", "hijos", "hija", "hijo", "hermano", "hermana", "abuelo", "abuela", "nieto", "nieta", "tío", "tía", "primo", "prima", "suegro", "suegra", "yerno", "nuera", "cuñado", "cuñada", "boda", "aniversario", "comida familiar", "reunión familiar", "hogar", "casa", "familia política",
            // Inglés
            "family", "parents", "mother", "mom", "father", "dad", "son", "daughter", "sibling", "brother", "sister", "grandparent", "grandfather", "grandma", "grandchild", "uncle", "aunt", "cousin", "in-law", "spouse", "husband", "wife", "wedding", "anniversary", "family dinner", "family meeting", "home", "household", "stepfamily", "relative"
        };

        public static readonly List<string> HealthKeywords = new()
        {
            // Español
            "salud", "médico", "doctora", "doctor", "cita médica", "hospital", "clínica", "farmacia", "receta", "medicación", "pastilla", "vacuna", "análisis", "sangre", "chequeo", "revisión", "seguro médico", "póliza", "dieta", "ejercicio", "deporte", "gimnasio", "fisio", "fisioterapia", "terapia", "psicólogo", "psicóloga", "dentista", "consulta", "urgencias",
            // Inglés
            "health", "doctor", "physician", "appointment", "hospital", "clinic", "pharmacy", "prescription", "medication", "pill", "vaccine", "checkup", "blood test", "analysis", "insurance", "policy", "diet", "exercise", "sport", "gym", "physiotherapy", "therapy", "psychologist", "dentist", "consultation", "er", "emergency", "nurse", "medical", "wellness"
        };

        public static readonly List<string> LeisureKeywords = new()
        {
            // Español
            "ocio", "tiempo libre", "relax", "descanso", "cine", "película", "serie", "tv", "televisión", "música", "concierto", "teatro", "viaje", "excursión", "paseo", "parque", "playa", "piscina", "hobby", "afición", "lectura", "libro", "videojuego", "juego", "bar", "pub", "discoteca", "fiesta", "evento", "picnic",
            // Inglés
            "leisure", "free time", "relax", "rest", "cinema", "movie", "series", "tv", "music", "concert", "theater", "travel", "trip", "excursion", "walk", "park", "beach", "pool", "hobby", "reading", "book", "videogame", "game", "bar", "pub", "club", "party", "event", "picnic", "outing"
        };

        public static readonly List<string> FriendsKeywords = new()
        {
            // Español
            "amigos", "amigo", "amiga", "colega", "compañero", "compi", "quedada", "salida", "fiesta", "evento", "reunión", "cita", "charla", "conversación", "grupo", "pandilla", "contacto", "amistad", "parce", "pana", "banda", "peña", "bro", "bff", "mejor amigo", "mejor amiga", "socios", "aliado", "conocido", "confidente",
            // Inglés
            "friends", "friend", "buddy", "mate", "pal", "dude", "bro", "bff", "bestie", "hangout", "meetup", "party", "event", "reunion", "chat", "talk", "group", "squad", "clique", "acquaintance", "friendship", "partner", "companion", "peer", "homie", "crew", "team", "get-together", "social", "contact"
        };

        // Devuelve todas las palabras clave agrupadas por área
        public Dictionary<AreaType, List<string>> GetAllKeywords()
        {
            return new Dictionary<AreaType, List<string>>
            {
                { AreaType.Work, WorkKeywords },
                { AreaType.Family, FamilyKeywords },
                { AreaType.Health, HealthKeywords },
                { AreaType.Leisure, LeisureKeywords },
                { AreaType.Friends, FriendsKeywords }
            };
        }

        // Método que me permite recorrer mis colecciones y si encuentra coincidencia con la tarea que ha agregado el usuario
        // 
        public AreaType? DetectArea(string taskDescription)
        {
            var allKeywords = GetAllKeywords();
            foreach (var area in allKeywords.Keys)
            {
                foreach (var keyword in allKeywords[area])
                {
                    if (taskDescription.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                        return area; // Returns the area of the first match found
                }
            }
            return null; // No match found
        }

    }
}
