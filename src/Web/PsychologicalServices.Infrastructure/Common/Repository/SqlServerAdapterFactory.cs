using PsychologicalServices.Data.DatabaseSpecific;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System;

namespace PsychologicalServices.Infrastructure.Common.Repository
{
    public class SqlServerAdapterFactory : IDataAccessAdapterFactory
    {
        private readonly string _connectionString;
        private readonly int _commandTimeout;

        public SqlServerAdapterFactory(IDataConnectionParametersFactory connectionParametersFactory)
        {
            if (connectionParametersFactory == null)
            {
                throw new ArgumentNullException("connectionParametersFactory");
            }

            var parameters = connectionParametersFactory.GetDataConnectionParameters();

            _connectionString = parameters.ConnectionString;
            _commandTimeout = parameters.CommandTimeout;
        }

        public IDataAccessAdapter CreateAdapter()
        {
            return new DataAccessAdapter(_connectionString)
            {
                CommandTimeOut = _commandTimeout
            };
        }

        public IDataAccessAdapter CreateAdapter(string connectionString)
        {
            return string.IsNullOrEmpty(connectionString)
                       ? CreateAdapter()
                       : new DataAccessAdapter(connectionString)
                           {
                               CommandTimeOut = _commandTimeout
                           };
        }

        public void CommitUnitOfWork(UnitOfWork2 unitOfWork)
        {
            using (var adapter = ((IDataAccessAdapterFactory)this).CreateAdapter())
            {
                unitOfWork.Commit(adapter);
            }
        }
    }
}
