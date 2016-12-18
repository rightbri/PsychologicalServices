using System;

namespace PsychologicalServices.Models.Common.Configuration
{
    public interface IConfigurationService
    {

        string AppSettingValue(string key);

        string ConnectionStringValue(string name);

        string ConnectionStringName { get; }
    }
}
