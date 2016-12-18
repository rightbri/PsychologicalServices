using System;
using System.Collections.Generic;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace PsychologicalServices.Infrastructure.Common.Repository
{
    public interface IRepository
    {

        UnitOfWork2 CreateUnitOfWork();

        void CommitUnitOfWork(UnitOfWork2 unitOfWork);

        void Commit(Transaction transaction);
    }
}
