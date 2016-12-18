using SD.LLBLGen.Pro.ORMSupportClasses;
using System;

namespace PsychologicalServices.Infrastructure.Common.Repository
{
    public class Transaction
    {
        private readonly UnitOfWork2 _unitOfWork;

        protected internal Transaction(UnitOfWork2 unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Transaction() : this(new UnitOfWork2()) { }

        protected internal UnitOfWork2 UnitOfWork
        {
            get { return _unitOfWork; }
        }

        public object Implementation
        {
            get { return _unitOfWork; }
        }

        public void Commit(IRepository repository)
        {
            repository.CommitUnitOfWork(UnitOfWork);
        }
    }
}
