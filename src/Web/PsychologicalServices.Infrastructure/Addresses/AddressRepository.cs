using PsychologicalServices.Data.EntityClasses;
using PsychologicalServices.Data.Linq;
using PsychologicalServices.Infrastructure.Common.Repository;
using PsychologicalServices.Models.Addresses;
using SD.LLBLGen.Pro.LinqSupportClasses;
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
                    .Prefetch<AddressTypeEntity>(address => address.AddressType)
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
                        addresses = addresses.Where(address => criteria.AddressTypeIds.Contains(address.AddressTypeId));
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
                var isNew = address.IsNew();

                var addressEntity = new AddressEntity
                {
                    IsNew = isNew,
                    AddressId = address.AddressId,
                };

                if (!isNew)
                {
                    adapter.FetchEntity(addressEntity);
                }

                addressEntity.Street = address.Street;
                addressEntity.Suite = address.Suite;
                addressEntity.CityId = address.City.CityId;
                addressEntity.PostalCode = address.PostalCode;
                addressEntity.AddressTypeId = address.AddressType.AddressTypeId;
                addressEntity.Name = address.Name;
                addressEntity.IsActive = address.IsActive;

                var saved = adapter.SaveEntity(addressEntity, false);

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
