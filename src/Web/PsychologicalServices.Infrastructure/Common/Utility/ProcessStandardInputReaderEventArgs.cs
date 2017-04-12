using System;
using System.IO;

namespace PsychologicalServices.Infrastructure.Common.Utility
{
    public class ProcessStandardInputReadyEventArgs : EventArgs
    {
        public ProcessStandardInputReadyEventArgs(StreamWriter writer)
        {
            StandardInput = writer;
        }

        public StreamWriter StandardInput { get; private set; }
    }
}
