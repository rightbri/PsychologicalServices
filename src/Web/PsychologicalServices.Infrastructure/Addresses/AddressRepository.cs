using PsychologicalServices.Data;
using PsychologicalServices.Data.EntityClasses;
using PsychologicalServices.Data.Linq;
using PsychologicalServices.Infrastructure.Common.Repository;
using PsychologicalServices.Models.Addresses;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Infrastructure.Addresses
{
    public class AddressRepository : RepositoryBase, IAddressRepository
    {
        public AddressRepository(
            IDataAccessAdapterFactory adapterFactory
        ) : base(adapterFactory)
        {
        }

        #region Prefetch Paths

        private static readonly Func<IPathEdgeRootParser<AddressEntity>, IPathEdgeRootParser<AddressEntity>>
            AddressPath =
                (aPath => aPath
                    .Prefetch<AddressAddressTypeEntity>(address => address.AddressAddressTypes)
                        .SubPath(addressAddressTypePath => addressAddressTypePath
                            .Prefetch<AddressTypeEntity>(addressAddressType => addressAddressType.AddressType)
                        )
                    .Prefetch<CityEntity>(address => address.City)
                );

        #endregion

        public Address GetAddress(int id)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return meta.Address
                    .WithPath(AddressPath)
                    .Where(address => address.AddressId == id)
                    .SingleOrDefault()
                    .ToAddress();
            }
        }

        public AddressType GetAddressType(int id)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return meta.AddressType
                    .Where(addressType => addressType.AddressTypeId == id)
                    .SingleOrDefault()
                    .ToAddressType();
            }
        }
        
        public IEnumerable<Address> GetAddresses(AddressSearchCriteria criteria)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var addresses = meta.Address
                    .WithPath(AddressPath);

                if (null != criteria)
                {
                    if (!string.IsNullOrWhiteSpace(criteria.Name))
                    {
                        addresses = addresses.Where(address => address.Name.Contains(criteria.Name));
                    }

                    if (!string.IsNullOrWhiteSpace(criteria.Street))
                    {
                        addresses = addresses.Where(address => address.Street.Contains(criteria.Street));
                    }

                    if (!string.IsNullOrWhiteSpace(criteria.City))
                    {
                        addresses = addresses.Where(address => address.City.Name.Contains(criteria.City));
                    }

                    if (null != criteria.AddressTypeIds && criteria.AddressTypeIds.Any())
                    {
                        addresses = addresses.Where(address => 
                            address.AddressAddressTypes.Any(addressAddressType =>
                                criteria.AddressTypeIds.Contains(addressAddressType.AddressTypeId)
                            )
                        );
                    }

                    if (criteria.IsActive.HasValue)
                    {
                        addresses = addresses.Where(address => address.IsActive == criteria.IsActive.Value);
                    }

                    if (!string.IsNullOrWhiteSpace(criteria.SearchTerm))
                    {
                        addresses = addresses
                            .Where(address => address.Name.Contains(criteria.SearchTerm) ||
                                address.Street.Contains(criteria.SearchTerm) ||
                                address.City.Name.Contains(criteria.SearchTerm));
                    }
                }

                return Execute<AddressEntity>(
                        (ILLBLGenProQuery)
                        addresses
                        .OrderBy(address => address.Name)
                    )
                    .Select(address => address.ToAddress())
                    .ToList();
            }
        }

        public IEnumerable<AddressType> GetAddressTypes(bool? isActive = true)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return Execute<AddressTypeEntity>(
                        (ILLBLGenProQuery)
                        meta.AddressType
                        .Where(addressType => isActive == null || addressType.IsActive == isActive.Value)
                        .OrderBy(addressType => addressType.Name)
                    )
                    .Select(addressType => addressType.ToAddressType())
                    .ToList();
            }
        }

        public int SaveAddress(Address address)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var uow = new UnitOfWork2();

                var isNew = address.IsNew();

                var addressEntity = new AddressEntity
                {
                    IsNew = isNew,
                    AddressId = address.AddressId,
                };

                if (!isNew)
                {
                    var prefetch = new PrefetchPath2(EntityType.AddressEntity);

                    prefetch.Add(AddressEntity.PrefetchPathAddressAddressTypes);

                    adapter.FetchEntity(addressEntity, prefetch);
                }

                addressEntity.Street = address.Street;
                addressEntity.Suite = address.Suite;
                addressEntity.CityId = address.City.CityId;
                addressEntity.PostalCode = address.PostalCode;
                addressEntity.Name = address.Name;
                addressEntity.IsActive = address.IsActive;

                #region address types

                var addressTypesToRemove = addressEntity.AddressAddressTypes
                    .Where(addressAddressType =>
                        !address.AddressTypes.Any(addressType =>
                            addressType.AddressTypeId == addressAddressType.AddressTypeId
                        )
                    );

                foreach (var addressType in addressTypesToRemove)
                {
                    uow.AddForDelete(addressType);
                }

                var addressTypesToAdd = address.AddressTypes
                    .Where(addressType =>
                        !addressEntity.AddressAddressTypes.Any(addressAddressType =>
                            addressAddressType.AddressTypeId == addressType.AddressTypeId
                        )
                    );

                addressEntity.AddressAddressTypes.AddRange(
                    addressTypesToAdd.Select(addressType =>
                    new AddressAddressTypeEntity
                    {
                        AddressTypeId = addressType.AddressTypeId,
                    })
                );

                #endregion

                uow.AddForSave(addressEntity);

                uow.Commit(adapter);

                return addressEntity.AddressId;
            }
        }
        
        public int SaveAddressType(AddressType addressType)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var isNew = addressType.IsNew();

                var addressTypeEntity = new AddressTypeEntity
                {
                    IsNew = isNew,
                    AddressTypeId = addressType.AddressTypeId,
                };

                if (!isNew)
                {
                    adapter.FetchEntity(addressTypeEntity);
                }

                addressTypeEntity.Name = addressType.Name;
                addressTypeEntity.IsActive = addressType.IsActive;
                
                var saved = adapter.SaveEntity(addressTypeEntity, false);

                return addressTypeEntity.AddressTypeId;
            }
        }
    }
}
