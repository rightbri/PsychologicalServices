using SD.LLBLGen.Pro.ORMSupportClasses;
using System;

namespace PsychologicalServices.Infrastructure.Common.Repository
{
    public interface IDataAccessAdapterFactory
    {
        IDataAccessAdapter CreateAdapter();
        
        IDataAccessAdapter CreateAdapter(string connectionString);

        void CommitUnitOfWork(UnitOfWork2 unitOfWork);
    }
}
