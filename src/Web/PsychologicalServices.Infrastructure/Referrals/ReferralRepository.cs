﻿using PsychologicalServices.Data;
using PsychologicalServices.Data.EntityClasses;
using PsychologicalServices.Data.Linq;
using PsychologicalServices.Infrastructure.Common.Repository;
using PsychologicalServices.Models.Referrals;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Infrastructure.Referrals
{
    public class ReferralRepository : RepositoryBase, IReferralRepository
    {
        public ReferralRepository(
            IDataAccessAdapterFactory adapterFactory
        ) : base(adapterFactory)
        {
        }

        #region Prefetch Paths

        private static readonly Func<IPathEdgeRootParser<ReferralTypeEntity>, IPathEdgeRootParser<ReferralTypeEntity>>
            ReferralTypePath =
                (referralTypePath => referralTypePath
                    .Prefetch<ReferralTypeIssueInDisputeEntity>(referralType => referralType.ReferralTypeIssuesInDispute)
                        .SubPath(referralTypeIssueInDisputePath => referralTypeIssueInDisputePath
                            .Prefetch<IssueInDisputeEntity>(referralTypeIssueInDispute => referralTypeIssueInDispute.IssueInDispute)
                        )
                );

        #endregion

        public ReferralSource GetReferralSource(int id)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return meta.ReferralSource
                    .Where(referralSource => referralSource.ReferralSourceId == id)
                    .SingleOrDefault()
                    .ToReferralSource();
            }
        }

        public ReferralSourceType GetReferralSourceType(int id)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return meta.ReferralSourceType
                    .Where(referralSourceType => referralSourceType.ReferralSourceTypeId == id)
                    .SingleOrDefault()
                    .ToReferralSourceType();
            }
        }

        public ReferralType GetReferralType(int id)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return meta.ReferralType
                    .WithPath(ReferralTypePath)
                    .Where(referralType => referralType.ReferralTypeId == id)
                    .SingleOrDefault()
                    .ToReferralType();
            }
        }

        public IEnumerable<ReferralSource> GetReferralSources(ReferralSourceSearchCriteria criteria)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var sources = meta.ReferralSource.AsQueryable();

                if (null != criteria)
                {
                    if (!string.IsNullOrWhiteSpace(criteria.Name))
                    {
                        sources = sources
                            .Where(source => source.Name == criteria.Name);
                    }

                    if (criteria.ReferralSourceId.HasValue)
                    {
                        sources = sources
                            .Where(source => source.ReferralSourceId == criteria.ReferralSourceId.Value);
                    }

                    if (criteria.ReferralSourceTypeId.HasValue)
                    {
                        sources = sources
                            .Where(source => source.ReferralSourceTypeId == criteria.ReferralSourceTypeId.Value);
                    }
                }

                return Execute<ReferralSourceEntity>(
                        (ILLBLGenProQuery)
                        sources
                    )
                    .Select(source => source.ToReferralSource())
                    .ToList();
            }
        }

        public IEnumerable<ReferralSourceType> GetReferralSourceTypes(bool? isActive = true)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return Execute<ReferralSourceTypeEntity>(
                        (ILLBLGenProQuery)
                        meta.ReferralSourceType
                        .Where(referralSourceType => isActive == null || referralSourceType.IsActive == isActive.Value)
                    )
                    .Select(referralSourceType => referralSourceType.ToReferralSourceType())
                    .ToList();
            }
        }

        public IEnumerable<ReferralType> GetReferralTypes(bool? isActive = true)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return Execute<ReferralTypeEntity>(
                        (ILLBLGenProQuery)
                        meta.ReferralType
                        .WithPath(ReferralTypePath)
                        .Where(referralType => isActive == null || referralType.IsActive == isActive.Value)
                    )
                    .Select(referralType => referralType.ToReferralType())
                    .ToList();
            }
        }

        public int SaveReferralSource(ReferralSource referralSource)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var isNew = referralSource.IsNew();

                var entity = new ReferralSourceEntity
                {
                    IsNew = isNew,
                    ReferralSourceId = referralSource.ReferralSourceId,
                };

                if (!isNew)
                {
                    adapter.FetchEntity(entity);
                }

                entity.Name = referralSource.Name;
                entity.ReferralSourceTypeId = referralSource.ReferralSourceTypeId;
                entity.LargeFileSize = referralSource.LargeFileSize;
                entity.LargeFileFeeAmount = referralSource.LargeFileFeeAmount;
                entity.IsActive = referralSource.IsActive;

                adapter.SaveEntity(entity, false);

                return entity.ReferralSourceId;
            }
        }

        public int SaveReferralSourceType(ReferralSourceType referralSourceType)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var isNew = referralSourceType.IsNew();

                var entity = new ReferralSourceTypeEntity
                {
                    IsNew = isNew,
                    ReferralSourceTypeId = referralSourceType.ReferralSourceTypeId,
                };

                if (!isNew)
                {
                    adapter.FetchEntity(entity);
                }

                entity.Name = referralSourceType.Name;
                entity.IsActive = referralSourceType.IsActive;
                
                adapter.SaveEntity(entity, false);

                return entity.ReferralSourceTypeId;
            }
        }

        public int SaveReferralType(ReferralType referralType)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var isNew = referralType.IsNew();

                var entity = new ReferralTypeEntity
                {
                    IsNew = isNew,
                    ReferralTypeId = referralType.ReferralTypeId,
                };

                if (!isNew)
                {
                    var prefetch = new PrefetchPath2(EntityType.IssueInDisputeEntity);

                    prefetch.Add(ReferralTypeEntity.PrefetchPathReferralTypeIssuesInDispute);

                    adapter.FetchEntity(entity, prefetch);
                }

                entity.Name = referralType.Name;
                entity.IsActive = referralType.IsActive;

                var issuesInDisputeToRemove = entity.ReferralTypeIssuesInDispute.Where(referralTypeIssueInDispute => !referralType.IssuesInDispute.Any(issueInDispute => issueInDispute.IssueInDisputeId == referralTypeIssueInDispute.IssueInDisputeId));

                foreach (var referralTypeIssueInDispute in issuesInDisputeToRemove)
                {
                    entity.ReferralTypeIssuesInDispute.Remove(referralTypeIssueInDispute);
                }

                var issuesInDisputeToAdd = referralType.IssuesInDispute.Where(issueInDispute => !entity.ReferralTypeIssuesInDispute.Any(referralTypeIssueInDispute => referralTypeIssueInDispute.IssueInDisputeId == issueInDispute.IssueInDisputeId));

                entity.ReferralTypeIssuesInDispute.AddRange(
                    issuesInDisputeToAdd.Select(issueInDispute => new ReferralTypeIssueInDisputeEntity
                    {
                        IsNew = true,
                        ReferralTypeId = referralType.ReferralTypeId,
                        IssueInDisputeId = issueInDispute.IssueInDisputeId,
                    })
                );

                adapter.SaveEntity(entity, false);

                return entity.ReferralTypeId;
            }
        }
    }
}
