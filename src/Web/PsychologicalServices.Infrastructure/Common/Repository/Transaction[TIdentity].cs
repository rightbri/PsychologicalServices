using SD.LLBLGen.Pro.ORMSupportClasses;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Infrastructure.Common.Repository
{
    public class Transaction<TIdentity> : Transaction
    {
        private IEntity2 _entity;
        private Func<IEntity2, TIdentity> _identityFunction;

        public Transaction() { }

        protected internal Transaction(UnitOfWork2 unitOfWork, IEntity2 entity, Func<IEntity2, TIdentity> identityFunction)
            : base(unitOfWork)
        {
            _entity = entity;
            _identityFunction = identityFunction;
        }

        public virtual TIdentity Identity
        {
            get
            {
                if (_identityFunction == null)
                {
                    throw new InvalidOperationException("Cannot retrieve the identity without first setting an identity function.");
                }
                return _identityFunction(_entity);
            }
        }

        protected internal IEntity2 Entity
        {
            get { return _entity; }
            set { _entity = value; }
        }

        protected internal Func<IEntity2, TIdentity> IdentityFunction
        {
            get { return _identityFunction; }
            set { _identityFunction = value; }
        }
    }
}
