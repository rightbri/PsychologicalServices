using System;

namespace PsychologicalServices.Infrastructure.Common.Utility
{
    public class ProcessDataReceivedEventArgs : EventArgs
    {
        public ProcessDataReceivedEventArgs(string data)
        {
            Data = data;
        }

        public string Data { get; private set; }
    }
}
