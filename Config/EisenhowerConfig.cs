using System;

namespace TODOListInteligence.Config
{
    public static class EisenhowerConfig
    {
        //Número mínimo de selecciones para considerar un área como importante.
        //Ajustado profesionalmente al número de preguntas del cuestionario.
        public const int ImportanceThreshold = 3;

        /// Número mínimo de selecciones para considerar un área como urgente.
        /// Ajustado profesionalmente al número de preguntas del cuestionario.
        public const int UrgencyThreshold = 2;
    }

}