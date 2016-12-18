using PsychologicalServices.Models.Common.Configuration;
using System;
using System.Configuration;

namespace PsychologicalServices.Infrastructure.Common.Configuration
{
    public class ConfigurationService : IConfigurationService
    {
        public string AppSettingValue(string key)
        {
            var value = ConfigurationManager.AppSettings[key];

            return value;
        }

        public string ConnectionStringValue(string name)
        {
            var setting = ConfigurationManager.ConnectionStrings[name];
            
            if (null != setting)
            {
                return setting.ConnectionString;
            }

            return null;
        }

        public string ConnectionStringName
        {
            get { return "PsychologicalServices"; }
        }
    }
}
