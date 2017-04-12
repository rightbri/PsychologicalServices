using System;
using System.Diagnostics;

namespace PsychologicalServices.Infrastructure.Common.Utility
{
    public interface IRunProcess
    {
        event EventHandler<ProcessStandardInputReadyEventArgs> ProcessStandardInputReady;

        event EventHandler<ProcessDataReceivedEventArgs> ProcessStandardOutputDataReceived;

        event EventHandler<ProcessDataReceivedEventArgs> ProcessStandardErrorDataReceived;

        ProcessRunInfo Run(ProcessStartInfo startInfo);

        void Kill();
    }
}
