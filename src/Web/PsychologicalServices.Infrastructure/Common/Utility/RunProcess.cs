using System;
using System.Diagnostics;
using System.Text;

namespace PsychologicalServices.Infrastructure.Common.Utility
{
    public class RunProcess : IRunProcess, IDisposable
    {
        protected System.Diagnostics.Process _process;
        protected bool _started;
        private bool _disposed;
        private StringBuilder _output;
        private StringBuilder _error;

        public event EventHandler<ProcessStandardInputReadyEventArgs> ProcessStandardInputReady;
        public event EventHandler<ProcessDataReceivedEventArgs> ProcessStandardOutputDataReceived;
        public event EventHandler<ProcessDataReceivedEventArgs> ProcessStandardErrorDataReceived;

        protected virtual void OnProcessStandardInputReady(ProcessStandardInputReadyEventArgs e)
        {
            var handler = ProcessStandardInputReady;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnProcessStandardOutputDataReceived(ProcessDataReceivedEventArgs e)
        {
            var handler = ProcessStandardOutputDataReceived;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnProcessStandardErrorDataReceived(ProcessDataReceivedEventArgs e)
        {
            var handler = ProcessStandardErrorDataReceived;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public virtual ProcessRunInfo Run(ProcessStartInfo startInfo)
        {
            var info = new ProcessRunInfo();

            using (_process = new System.Diagnostics.Process() { StartInfo = startInfo })
            {

                if (!startInfo.UseShellExecute)
                {
                    if (startInfo.RedirectStandardOutput)
                    {
                        _output = new StringBuilder();
                        _process.OutputDataReceived += StandardOutputHandler;
                    }

                    if (startInfo.RedirectStandardError)
                    {
                        _error = new StringBuilder();
                        _process.ErrorDataReceived += StandardErrorHandler;
                    }
                }

                _process.Start();
                _started = true;

                if (!startInfo.UseShellExecute && startInfo.RedirectStandardOutput)
                {
                    _process.BeginOutputReadLine();
                }

                if (!startInfo.UseShellExecute && startInfo.RedirectStandardError)
                {
                    _process.BeginErrorReadLine();
                }

                if (!startInfo.UseShellExecute && startInfo.RedirectStandardInput)
                {
                    OnProcessStandardInputReady(new ProcessStandardInputReadyEventArgs(_process.StandardInput));

                    _process.StandardInput.Close();
                }

                _process.WaitForExit();

                info.ExitCode = _process.HasExited ? _process.ExitCode : -1;
                info.StandardOutput = _output != null ? _output.ToString() : null;
                info.StandardError = _error != null ? _error.ToString() : null;
            }

            return info;
        }

        public void Kill()
        {
            if (_process != null && _started)
            {
                if (!_process.HasExited)
                {
                    _process.Kill();
                }

                _process.Close();
            }
        }

        private void StandardOutputHandler(object sendingProcess, DataReceivedEventArgs output)
        {
            if (!string.IsNullOrEmpty(output.Data))
            {
                OnProcessStandardOutputDataReceived(new ProcessDataReceivedEventArgs(output.Data));

                _output.AppendLine(output.Data);
            }
        }

        private void StandardErrorHandler(object sendingProcess, DataReceivedEventArgs error)
        {
            if (!string.IsNullOrEmpty(error.Data))
            {
                OnProcessStandardErrorDataReceived(new ProcessDataReceivedEventArgs(error.Data));

                _error.AppendLine(error.Data);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_process != null)
                    {
                        _process.Dispose();
                    }
                }

                _disposed = true;
                _started = false;
            }
        }
    }
}
