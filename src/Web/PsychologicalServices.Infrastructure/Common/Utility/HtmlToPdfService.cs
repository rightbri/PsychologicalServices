using log4net;
using PsychologicalServices.Models.Common.Configuration;
using System;
using System.IO;

namespace PsychologicalServices.Infrastructure.Common.Utility
{
    public class HtmlToPdfService : IHtmlToPdfService
    {
        private readonly IConfigurationService _configurationService = null;
        private readonly IRunProcess _runProcess = null;
        private readonly ITempDirectory _tempDirectory = null;
        private readonly IFileWriter _fileWriter = null;
        private readonly IFileReader _fileReader = null;
        private readonly IHtmlToPdfExecutablePathService _executablePathService = null;
        private readonly ILog _log = null;

        public HtmlToPdfService(
            IConfigurationService configurationService,
            IRunProcess runProcess,
            ITempDirectory tempDirectory,
            IFileWriter fileWriter,
            IFileReader fileReader,
            IHtmlToPdfExecutablePathService executablePathService,
            ILog log
        )
        {
            _configurationService = configurationService;
            _runProcess = runProcess;
            _tempDirectory = tempDirectory;
            _fileWriter = fileWriter;
            _fileReader = fileReader;
            _executablePathService = executablePathService;
            _log = log;
        }

        public byte[] GetPdf(string html)
        {
            byte[] output = null;

            var pageSize = _configurationService.AppSettingValue("HtmlToPdf.PageSize");
            if (string.IsNullOrWhiteSpace(pageSize))
            {
                pageSize = "Letter";
            }

            var proxy = _configurationService.AppSettingValue("HtmlToPdf.Proxy");
            if (string.IsNullOrWhiteSpace(proxy))
            {
                proxy = "None";
            }

            using (_tempDirectory)
            {
                var htmlFilePath = Path.Combine(_tempDirectory.FullPath, string.Format("{0}.html", Path.GetRandomFileName()));

                _fileWriter.WriteText(html, htmlFilePath);

                var pdfFilePath = Path.Combine(_tempDirectory.FullPath, string.Format("{0}.pdf", Path.GetRandomFileName()));

                var startInfo = new System.Diagnostics.ProcessStartInfo
                {
                    Arguments = string.Format("--page-size {0} -p {1} \"{2}\" \"{3}\"", pageSize, proxy, htmlFilePath, pdfFilePath),
                    FileName = _executablePathService.ExecutablePath,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                };

                try
                {
                    var info = _runProcess.Run(startInfo);

                    if (info.ExitCode == 0)
                    {
                        if (!string.IsNullOrWhiteSpace(info.StandardOutput))
                        {
                            _log.Info(info.StandardOutput);
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrWhiteSpace(info.StandardError) || !string.IsNullOrWhiteSpace(info.StandardOutput))
                        {
                            _log.ErrorFormat("{0}{1}{2}", info.StandardError, Environment.NewLine, info.StandardOutput);
                        }
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
    }
}
