using PsychologicalServices.Data.HelperClasses;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Infrastructure.Common.Repository
{
    public abstract class RepositoryBase : IRepository
    {
        public IDataAccessAdapterFactory AdapterFactory { get; private set; }
        
        public RepositoryBase(IDataAccessAdapterFactory adapterFactory)
        {
            AdapterFactory = adapterFactory;
        }

        public UnitOfWork2 CreateUnitOfWork()
        {
            return new UnitOfWork2();
        }

        public void CommitUnitOfWork(UnitOfWork2 unitOfWork)
        {
            AdapterFactory.CommitUnitOfWork(unitOfWork);
        }

        public void Commit(Transaction transaction)
        {
            CommitUnitOfWork(transaction.UnitOfWork);
        }

        protected static EntityCollection<T> Execute<T>(ILLBLGenProQuery query) where T : EntityBase2, IEntity2
        {
            return query.Execute<EntityCollection<T>>();
        }
    }
}
