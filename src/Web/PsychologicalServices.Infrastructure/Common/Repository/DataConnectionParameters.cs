using System;

namespace PsychologicalServices.Infrastructure.Common.Repository
{
    public class DataConnectionParameters : IDataConnectionParameters
    {
        public string ConnectionString { get; private set; }

        public int CommandTimeout { get; private set; }

        public DataConnectionParameters(string connectionString, int commandTimeout)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException("connectionString");
            }

            if (commandTimeout < 0)
            {
                throw new ArgumentOutOfRangeException("commandTimeout", "Command timeout must be greater than zero.");
            }

            ConnectionString = connectionString;
            
            CommandTimeout = commandTimeout;
        }
    }
}
