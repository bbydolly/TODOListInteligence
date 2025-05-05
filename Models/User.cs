
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOListInteligence.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        // Las siguientes colecciones se usan para llevar un registro de respuesta, puntuacion 
        // con respecto a las preguntas del cuestionario que están asignadas a urgente o importante
        // Servirán para realizar los cálculos en el algoritmo de clasificación de tareasa según la matriz
        // de Heisenwoher
       
       public Dictionary<AreaType, int> Importance {get; set;} = new ();

       public Dictionary<AreaType, int> Urgency {get; set;} = new ();

       public User(){
         
            
       }
       public void InitDictionarys(){
        // recorro los dos diccionarios para establecer los valores a 0
            foreach(AreaType area in Enum.GetValues(typeof(AreaType))){
                Importance[area]=0;
                Urgency[area]=0;
            }
       }
    }
}