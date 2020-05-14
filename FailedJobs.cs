using System;
using System.Collections.Generic;

namespace AspnetMvcTutorial
{
    public partial class FailedJobs
    {
        public ulong Id { get; set; }
        public string Connection { get; set; }
        public string Queue { get; set; }
        public string Payload { get; set; }
        public string Exception { get; set; }
        public DateTime FailedAt { get; set; }
    }
}
