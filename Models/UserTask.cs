using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOListInteligence.Models
{
    public class UserTask
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsUrgent { get; set; }
        public bool IsImportant { get; set; }
        public bool IsDistributed { get; set; } = false;

        public UserTask()
        {

        }

        public UserTask(string title, string description, bool IsUrgent, bool IsImportant)
        {
            Title = title;
            Description = description;
            this.IsUrgent = IsUrgent;
            this.IsImportant = IsImportant;
            IsDistributed = false;
        }
    }

    
}
