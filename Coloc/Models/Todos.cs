using System;
using System.Collections.Generic;

namespace Coloc.Models
{
    public partial class Todos
    {
        public Todos()
        {
            Tasks = new HashSet<Tasks>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public ICollection<Tasks> Tasks { get; set; }
    }
}
