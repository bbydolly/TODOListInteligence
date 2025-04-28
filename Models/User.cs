
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOListInteligence.Models
{
    class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        // Las siguientes colecciones se usan para llevar un registro de respuesta, puntuacion 
        // con respecto a las preguntas del cuestionario que están asignadas a urgente o importante
        // Servirán para realizar los cálculos en el algoritmo de clasificación de tareasa según la matriz
        // de Heisenwoher
        //public Dictionary<string, int> Important { set; get; } = new();
        //public Dictionary<string, int> Urgent { set; get; } = new();
    }
}