using System;

namespace PsychologicalServices.Infrastructure.Common.Repository
{
    public interface IDataConnectionParametersFactory
    {
        IDataConnectionParameters GetDataConnectionParameters();
    }
}
