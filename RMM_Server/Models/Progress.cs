using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMM_Server.Models
{
    // This is the model for participant table in dB
    public class Progress
    {
        public int progress { get; set; }
        public int research_id { get; set; }
        public string student_id { get; set; }
    }
}
