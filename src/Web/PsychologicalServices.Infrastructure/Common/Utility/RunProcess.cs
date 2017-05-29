using System;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace PsychologicalServices.Infrastructure.Common.Utility
{
    public class RunProcess : IRunProcess
    {
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

        public virtual ProcessRunInfo Run(ProcessStartInfo startInfo, int timeout = 30000)
        {
            var info = new ProcessRunInfo();

            using (var process = new System.Diagnostics.Process() { StartInfo = startInfo })
            {
                using (var outputWaitHandle = new AutoResetEvent(false))
                using (var errorWaitHandle = new AutoResetEvent(false))
                {
                    if (!startInfo.UseShellExecute)
                    {
                        if (startInfo.RedirectStandardOutput)
                        {
                            _output = new StringBuilder();

                            process.OutputDataReceived += (sender, output) =>
                            {
                                if (null == output.Data)
                                {
                                    outputWaitHandle.Set();
                                }
                                else
                                {
                                    OnProcessStandardOutputDataReceived(new ProcessDataReceivedEventArgs(output.Data));

                                    _output.AppendLine(output.Data);
                                }
                            };
                        }

                        if (startInfo.RedirectStandardError)
                        {
                            _error = new StringBuilder();

                            process.ErrorDataReceived += (sender, error) =>
                            {
                                if (null == error.Data)
                                {
                                    errorWaitHandle.Set();
                                }
                                else
                                {
                                    OnProcessStandardErrorDataReceived(new ProcessDataReceivedEventArgs(error.Data));

                                    _error.AppendLine(error.Data);
                                }
                            };
                        }
                    }

                    if (process.Start())
                    {
                        if (!startInfo.UseShellExecute && startInfo.RedirectStandardOutput)
                        {
                            process.BeginOutputReadLine();
                        }

                        if (!startInfo.UseShellExecute && startInfo.RedirectStandardError)
                        {
                            process.BeginErrorReadLine();
                        }

                        if (!startInfo.UseShellExecute && startInfo.RedirectStandardInput)
                        {
                            OnProcessStandardInputReady(new ProcessStandardInputReadyEventArgs(process.StandardInput));

                            process.StandardInput.Close();
                        }

                        if (process.WaitForExit(timeout) &&
                            (startInfo.UseShellExecute || !startInfo.RedirectStandardOutput || outputWaitHandle.WaitOne(timeout)) &&
                            (startInfo.UseShellExecute || !startInfo.RedirectStandardError || errorWaitHandle.WaitOne(timeout))
                        )
                        {
                            info.ExitCode = process.HasExited ? process.ExitCode : -1;
                        }
                        else
                        {
                            info.Timeout = true;
                        }

                        info.StandardOutput = _output != null ? _output.ToString() : null;
                        info.StandardError = _error != null ? _error.ToString() : null;
                    }
                }
            }

            return info;
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
    }
}
