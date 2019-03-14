using System;
using System.Collections.Generic;

namespace Coloc.Models
{
    public partial class Tasks
    {
        public Tasks()
        {
            UserTasks = new HashSet<UserTasks>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int TodoId { get; set; }

        public Todos Todo { get; set; }
        public ICollection<UserTasks> UserTasks { get; set; }
    }
}
