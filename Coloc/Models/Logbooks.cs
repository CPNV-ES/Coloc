using System;
using System.Collections.Generic;

namespace Coloc.Models
{
    public partial class Logbookss
    {
        public int Id { get; set; }
        public string AspNetUserId { get; set; }
        public DateTime? Moment { get; set; }
        public string EventDescription { get; set; }

        public AspNetUsers AspNetUser { get; set; }
    }
}
