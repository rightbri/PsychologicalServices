using System;

namespace PsychologicalServices.Infrastructure.Common.Repository
{
    public interface IDataConnectionParameters
    {
        string ConnectionString { get; }

        int CommandTimeout { get; }
    }
}
