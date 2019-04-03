using System;
using System.Collections.Generic;

namespace Coloc.Models
{
    public partial class Logbooks
    {
        public int Id { get; set; }
        public string AspNetUserId { get; set; }
        public DateTime? Moment { get; set; }
        public string Eventdescription { get; set; }

        public AspNetUsers AspNetUser { get; set; }
    }
}
