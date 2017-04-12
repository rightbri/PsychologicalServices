using PsychologicalServices.Models.Common.Configuration;
using System;
using System.IO;
using System.Linq;

namespace PsychologicalServices.Infrastructure.Common.Utility
{
    public class HtmlToPdfExecutablePathService : IHtmlToPdfExecutablePathService
    {
        private readonly IConfigurationService _configurationService = null;

        public HtmlToPdfExecutablePathService(
            IConfigurationService configurationService
        )
        {
            _configurationService = configurationService;
        }

        public string ExecutablePath
        {
            get
            {
                var executableName = _configurationService.AppSettingValue("HtmlToPdf.ExecutablePath");

                var directoryInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
                if (directoryInfo.Exists)
                {
                    var fileInfos = directoryInfo.GetFiles(executableName, SearchOption.AllDirectories);

                    var fileInfo = fileInfos.FirstOrDefault();

                    if (null != fileInfo)
                    {
                        return fileInfo.FullName;
                    }
                }

                return executableName;
            }
        }
    }
}