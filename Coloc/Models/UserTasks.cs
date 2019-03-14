using System;
using System.Collections.Generic;

namespace Coloc.Models
{
    public partial class UserTasks
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public string UserId { get; set; }
        public DateTime BeginTask { get; set; }
        public DateTime EndTask { get; set; }
        public DateTime? FinishTask { get; set; }
        public byte State { get; set; }

        public Tasks Task { get; set; }
        public AspNetUsers User { get; set; }
    }
}
