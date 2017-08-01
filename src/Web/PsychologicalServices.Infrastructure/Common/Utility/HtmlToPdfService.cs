using log4net;
using PsychologicalServices.Models.Common.Configuration;
using PsychologicalServices.Models.Common.Utility;
using System;
using System.Collections.Generic;
using System.IO;

namespace PsychologicalServices.Infrastructure.Common.Utility
{
    public class HtmlToPdfService : IHtmlToPdfService
    {
        private readonly IConfigurationService _configurationService = null;
        private readonly IHtmlToPdfExecutablePathService _htmlToPdfExecutablePathService = null;
        private readonly IRunProcess _runProcess = null;
        private readonly ITempDirectoryFactory _tempDirectoryFactory = null;
        private readonly IFileWriter _fileWriter = null;
        private readonly IFileReader _fileReader = null;
        private readonly ILog _log = null;

        public HtmlToPdfService(
            IConfigurationService configurationService,
            IHtmlToPdfExecutablePathService htmlToPdfExecutablePathService,
            IRunProcess runProcess,
            ITempDirectoryFactory tempDirectoryFactory,
            IFileWriter fileWriter,
            IFileReader fileReader,
            ILog log
        )
        {
            _configurationService = configurationService;
            _htmlToPdfExecutablePathService = htmlToPdfExecutablePathService;
            _runProcess = runProcess;
            _tempDirectoryFactory = tempDirectoryFactory;
            _fileWriter = fileWriter;
            _fileReader = fileReader;
            _log = log;
        }

        public byte[] GetPdf(string html, HtmlToPdfParameters parameters = null)
        {
            byte[] output = null;

            using (var tempDirectory = _tempDirectoryFactory.Create())
            {
                var htmlFilePath = Path.Combine(tempDirectory.FullPath, string.Format("{0}.html", Path.GetRandomFileName()));

                _fileWriter.WriteText(html, htmlFilePath);

                var pdfFilePath = Path.Combine(tempDirectory.FullPath, string.Format("{0}.pdf", Path.GetRandomFileName()));

                var startInfo = new System.Diagnostics.ProcessStartInfo
                {
                    Arguments = string.Format("{0} \"{1}\" \"{2}\"", GetArguments(parameters), htmlFilePath, pdfFilePath),
                    FileName = _htmlToPdfExecutablePathService.ExecutablePath,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                };

                try
                {
                    var info = _runProcess.Run(startInfo);

                    if (info.Timeout)
                    {
                        _log.InfoFormat("Pdf generation timed out. Arguments: {0}", startInfo.Arguments);
                    }

                    if (!string.IsNullOrWhiteSpace(info.StandardOutput))
                    {
                        _log.InfoFormat("Standard out: {0}", info.StandardOutput);
                    }

                    if (!string.IsNullOrWhiteSpace(info.StandardError))
                    {
                        _log.InfoFormat("Standard error: {0}", info.StandardError);
                    }

                    var pdfFileInfo = new FileInfo(pdfFilePath);
                    if (pdfFileInfo.Exists)
                    {
                        output = _fileReader.ReadBytes(pdfFilePath);
                    }
                }
                catch (Exception ex)
                {
                    _log.Error("An error occurred while generating the pdf file.", ex);
                }
            }
            
            return output;
        }

        private string GetArguments(HtmlToPdfParameters parameters)
        {
            if (null == parameters)
            {
                return "";
            }

            var arguments = new List<string>();

            if (!string.IsNullOrWhiteSpace(parameters.PageSize))
            {
                arguments.Add(string.Format("--page-size {0}", parameters.PageSize));
            }

            if (!string.IsNullOrWhiteSpace(parameters.Proxy))
            {
                arguments.Add(string.Format("--proxy {0}", parameters.Proxy));
            }

            if (parameters.JavascriptDelay.HasValue)
            {
                arguments.Add(string.Format("--javascript-delay {0}", parameters.JavascriptDelay.Value));
            }

            if (parameters.MarginTop.HasValue)
            {
                arguments.Add(string.Format("--margin-top {0}", parameters.MarginTop.Value));
            }

            if (parameters.MarginRight.HasValue)
            {
                arguments.Add(string.Format("--margin-right {0}", parameters.MarginRight.Value));
            }

            if (parameters.MarginBottom.HasValue)
            {
                arguments.Add(string.Format("--margin-bottom {0}", parameters.MarginBottom.Value));
            }

            if (parameters.MarginLeft.HasValue)
            {
                arguments.Add(string.Format("--margin-left {0}", parameters.MarginLeft.Value));
            }
            return string.Join(" ", arguments);
        }
    }
}
