using PsychologicalServices.Data;
using PsychologicalServices.Data.EntityClasses;
using PsychologicalServices.Data.Linq;
using PsychologicalServices.Infrastructure.Common.Repository;
using PsychologicalServices.Models.Attributes;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Infrastructure.Attributes
{
    public class AttributeRepository : RepositoryBase, IAttributeRepository
    {
        public AttributeRepository(
            IDataAccessAdapterFactory adapterFactory
        ) : base(adapterFactory)
        {
        }

        #region Prefetch Paths

        private static readonly Func<IPathEdgeRootParser<AttributeEntity>, IPathEdgeRootParser<AttributeEntity>>
            AttributePath =
                (attributePath => attributePath
                    .Prefetch<AttributeTypeEntity>(attribute => attribute.AttributeType)
                    .Prefetch<CompanyAttributeEntity>(attribute => attribute.CompanyAttributes)
                        .SubPath(companyAttributePath => companyAttributePath
                            .Prefetch<CompanyEntity>(companyAttribute => companyAttribute.Company)
                        )
                );

        #endregion

        public Models.Attributes.Attribute GetAttribute(int id)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return meta.Attribute
                    .WithPath(AttributePath)
                    .Where(attribute => attribute.AttributeId == id)
                    .SingleOrDefault()
                    .ToAttribute();
            }
        }

        public AttributeType GetAttributeType(int id)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return meta.AttributeType
                    .Where(attributeType => attributeType.AttributeTypeId == id)
                    .SingleOrDefault()
                    .ToAttributeType();
            }
        }

        public IEnumerable<Models.Attributes.Attribute> SearchAttributes(AttributeSearchCriteria criteria)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var attributes = meta.Attribute
                    .WithPath(AttributePath);

                if (null != criteria)
                {
                    if (!string.IsNullOrWhiteSpace(criteria.Name))
                    {
                        attributes = attributes.Where(attribute => attribute.Name.Contains(criteria.Name));
                    }

                    if (null != criteria.AttributeTypeIds && criteria.AttributeTypeIds.Any())
                    {
                        attributes = attributes.Where(attribute => criteria.AttributeTypeIds.Contains(attribute.AttributeTypeId));
                    }

                    if (null != criteria.CompanyIds && criteria.CompanyIds.Any())
                    {
                        attributes = attributes
                            .Where(attribute => attribute.CompanyAttributes
                                .Any(companyAttribute => criteria.CompanyIds.Contains(companyAttribute.CompanyId))
                            );
                    }

                    if (criteria.IsActive.HasValue)
                    {
                        attributes = attributes.Where(attribute => attribute.IsActive == criteria.IsActive.Value);
                    }
                }

                return Execute<AttributeEntity>(
                        (ILLBLGenProQuery)
                        attributes
                        .OrderBy(attribute => attribute.Name)
                    )
                    .Select(attribute => attribute.ToAttribute())
                    .ToList();
            }
        }

        public IEnumerable<AttributeType> GetAttributeTypes(bool? isActive = true)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return Execute<AttributeTypeEntity>(
                    (ILLBLGenProQuery)
                    meta.AttributeType
                    .Where(attributeType => isActive == null || attributeType.IsActive == isActive)
                    .OrderBy(attributeType => attributeType.Name)
                )
                .Select(attributeType => attributeType.ToAttributeType())
                .ToList();
            }
        }

        public int SaveAttribute(Models.Attributes.Attribute attribute)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var uow = new UnitOfWork2();

                var isNew = attribute.IsNew();

                var attributeEntity = new AttributeEntity
                {
                    IsNew = isNew,
                    AttributeId = attribute.AttributeId,
                };

                if (!isNew)
                {
                    var prefetch = new PrefetchPath2(EntityType.AttributeEntity);

                    prefetch.Add(AttributeEntity.PrefetchPathCompanyAttributes);

                    adapter.FetchEntity(attributeEntity, prefetch);
                }

                attributeEntity.Name = attribute.Name;
                attributeEntity.AttributeTypeId = attribute.AttributeType.AttributeTypeId;
                attributeEntity.IsActive = attribute.IsActive;

                #region companies

                var companiesToAdd = attribute.Companies.Where(company =>
                        !attributeEntity.CompanyAttributes.Any(companyAttribute =>
                            companyAttribute.CompanyId == company.CompanyId
                        )
                    );

                var companiesToRemove = attributeEntity.CompanyAttributes.Where(companyAttribute =>
                    !attribute.Companies.Any(company =>
                        company.CompanyId == companyAttribute.CompanyId
                    )
                );

                foreach (var company in companiesToRemove)
                {
                    uow.AddForDelete(company);
                }

                attributeEntity.CompanyAttributes.AddRange(
                    companiesToAdd.Select(company => new CompanyAttributeEntity
                    {
                        CompanyId = company.CompanyId,
                    })
                );

                #endregion

                uow.AddForSave(attributeEntity);

                uow.Commit(adapter);

                return attributeEntity.AttributeId;
            }
        }

        public int SaveAttributeType(AttributeType attributeType)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var isNew = attributeType.IsNew();

                var attributeTypeEntity = new AttributeTypeEntity
                {
                    IsNew = isNew,
                    AttributeTypeId = attributeType.AttributeTypeId,
                };

                if (!isNew)
                {
                    adapter.FetchEntity(attributeTypeEntity);
                }

                attributeTypeEntity.Name = attributeType.Name;
                attributeTypeEntity.IsActive = attributeType.IsActive;

                var saved = adapter.SaveEntity(attributeTypeEntity, false);

                return attributeTypeEntity.AttributeTypeId;
            }
        }
    }
}
