using PsychologicalServices.Data;
using PsychologicalServices.Data.EntityClasses;
using PsychologicalServices.Data.Linq;
using PsychologicalServices.Infrastructure.Common.Repository;
using PsychologicalServices.Models.Contacts;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Infrastructure.Contacts
{
    public class ContactRepository : RepositoryBase, IContactRepository
    {
        public ContactRepository(
            IDataAccessAdapterFactory adapterFactory
        ) : base(adapterFactory)
        {
        }

        #region Prefetch Paths

        private static readonly Func<IPathEdgeRootParser<ContactEntity>, IPathEdgeRootParser<ContactEntity>>
            ContactPath =
                (contactPath => contactPath
                    .Prefetch<ContactTypeEntity>(contact => contact.ContactType)
                    .Prefetch<EmployerEntity>(contact => contact.Employer)
                        .SubPath(employerPath => employerPath
                            .Prefetch<EmployerTypeEntity>(employer => employer.EmployerType)
                        )
                    .Prefetch<AddressEntity>(contact => contact.Address)
                        .SubPath(addressPath => addressPath
                            .Prefetch<CityEntity>(address => address.City)
                        )
                );

        #endregion

        public Contact GetContactByEmail(string email)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return meta.Contact
                    .WithPath(ContactPath)
                    .Where(contact => contact.Email == email)
                    .SingleOrDefault()
                    .ToContact();
            }
        }

        public Contact GetContactById(int id)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return meta.Contact
                    .WithPath(ContactPath)
                    .Where(contact => contact.ContactId == id)
                    .SingleOrDefault()
                    .ToContact();
            }
        }

        public ContactType GetContactType(int id)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return meta.ContactType
                    .Where(contactType => contactType.ContactTypeId == id)
                    .SingleOrDefault()
                    .ToContactType();
            }
        }

        public IEnumerable<Contact> GetContacts(ContactSearchCriteria criteria)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var contacts = meta.Contact
                    .WithPath(ContactPath);

                if (null != criteria)
                {
                    if (criteria.ContactId.HasValue)
                    {
                        contacts = contacts.Where(contact => contact.ContactId == criteria.ContactId.Value);
                    }

                    if (!string.IsNullOrWhiteSpace(criteria.FirstName))
                    {
                        contacts = contacts.Where(contact => contact.FirstName.Contains(criteria.FirstName));
                    }

                    if (!string.IsNullOrWhiteSpace(criteria.LastName))
                    {
                        contacts = contacts.Where(contact => contact.LastName.Contains(criteria.LastName));
                    }

                    if (!string.IsNullOrWhiteSpace(criteria.Email))
                    {
                        contacts = contacts.Where(contact => contact.Email.Contains(criteria.Email));
                    }

                    if (criteria.ContactTypeId.HasValue)
                    {
                        contacts = contacts.Where(contact => contact.ContactTypeId == criteria.ContactTypeId);
                    }

                    if (criteria.EmployerId.HasValue)
                    {
                        contacts = contacts.Where(contact => contact.EmployerId == criteria.EmployerId);
                    }

                    if (criteria.AddressId.HasValue)
                    {
                        contacts = contacts.Where(contact => contact.AddressId == criteria.AddressId);
                    }

                    if (criteria.IsActive.HasValue)
                    {
                        contacts = contacts.Where(employer => employer.IsActive == criteria.IsActive);
                    }
                }

                return Execute<ContactEntity>(
                        (ILLBLGenProQuery)
                        contacts
                    )
                    .Select(contact => contact.ToContact())
                    .ToList();
            }
        }

        public IEnumerable<ContactType> GetContactTypes(bool? isActive = true)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return Execute<ContactTypeEntity>(
                        (ILLBLGenProQuery)
                        meta.ContactType
                        .Where(contactType => isActive == null || contactType.IsActive == isActive)
                    )
                    .Select(contactType => contactType.ToContactType())
                    .ToList();
            }
        }

        public int SaveContact(Contact contact)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var uow = new UnitOfWork2();

                var isNew = contact.IsNew();

                var entity = new ContactEntity
                {
                    IsNew = isNew,
                    ContactId = contact.ContactId,
                };

                if (!isNew)
                {
                    adapter.FetchEntity(entity);
                }

                entity.FirstName = contact.FirstName;
                entity.LastName = contact.LastName;
                entity.Email = contact.Email;
                entity.ContactTypeId = contact.ContactType.ContactTypeId;

                if (null == contact.Employer)
                {
                    entity.SetNewFieldValue((int)ContactFieldIndex.EmployerId, null);
                }
                else
                {
                    entity.EmployerId = contact.Employer.EmployerId;
                }
                
                if (null == contact.Address)
                {
                    entity.SetNewFieldValue((int)ContactFieldIndex.AddressId, null);
                }
                else
                {
                    entity.AddressId = contact.Address.AddressId;
                }
                
                entity.IsActive = contact.IsActive;
                
                uow.AddForSave(entity);

                uow.Commit(adapter);

                return entity.ContactId;
            }
        }

        public int SaveContactType(ContactType contactType)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var isNew = contactType.IsNew();

                var entity = new ContactTypeEntity
                {
                    IsNew = isNew,
                    ContactTypeId = contactType.ContactTypeId,
                };

                if (!isNew)
                {
                    adapter.FetchEntity(entity);
                }

                entity.Name = contactType.Name;
                entity.IsActive = contactType.IsActive;

                adapter.SaveEntity(entity);

                return entity.ContactTypeId;
            }
        }
    }
}
