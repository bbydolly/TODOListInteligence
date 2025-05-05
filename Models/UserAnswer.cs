using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOListInteligence.Models
{
    public class UserAnswer
    {
        public int QuestionId { get; set; }
        public string SelectedOption { get; set; }
        public string QuestionType { get; set; } // "importancia" o "urgencia"
    }
}
