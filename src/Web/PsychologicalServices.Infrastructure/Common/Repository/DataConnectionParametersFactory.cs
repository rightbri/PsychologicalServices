using PsychologicalServices.Models.Common.Configuration;
using System;

namespace PsychologicalServices.Infrastructure.Common.Repository
{
    public class DataConnectionParametersFactory : IDataConnectionParametersFactory
    {
        private readonly IConfigurationService _configurationService = null;

        public DataConnectionParametersFactory(
            IConfigurationService configurationService
        )
        {
            _configurationService = configurationService;
        }

        public IDataConnectionParameters GetDataConnectionParameters()
        {
            var connectionString = _configurationService.ConnectionStringValue(_configurationService.ConnectionStringName);
            
            int commandTimeout;
            if (!int.TryParse(_configurationService.AppSettingValue("Data.CommandTimeout"), out commandTimeout))
            {
                commandTimeout = 30;
            }

            return new DataConnectionParameters(connectionString, commandTimeout);
        }
    }
}
