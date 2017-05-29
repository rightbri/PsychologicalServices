using System;

namespace PsychologicalServices.Infrastructure.Common.Utility
{
    public class ProcessRunInfo
    {
        public int ExitCode { get; set; }
        public string StandardError { get; set; }
        public string StandardOutput { get; set; }
        public bool Timeout { get; set; }
    }
}
