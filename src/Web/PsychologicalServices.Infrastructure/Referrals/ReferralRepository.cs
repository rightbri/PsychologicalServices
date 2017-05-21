using PsychologicalServices.Data;
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

        private static readonly Func<IPathEdgeRootParser<ReferralSourceEntity>, IPathEdgeRootParser<ReferralSourceEntity>>
            ReferralSourcePath =
                (referralSourcePath => referralSourcePath
                    .Prefetch<ReferralSourceTypeEntity>(referralSource => referralSource.ReferralSourceType)
                    .Prefetch<AddressEntity>(referralSource => referralSource.Address)
                        .SubPath(addressPath => addressPath
                            .Prefetch<CityEntity>(address => address.City)
                        )
                    .Prefetch<ReportTypeInvoiceAmountEntity>(referralSource => referralSource.ReportTypeInvoiceAmounts)
                        .SubPath(reportTypeInvoiceAmountPath => reportTypeInvoiceAmountPath
                            .Prefetch<ReportTypeEntity>(reportTypeInvoiceAmount => reportTypeInvoiceAmount.ReportType)
                        )
                    .Prefetch<ReferralSourceAppointmentStatusSettingEntity>(referralSource => referralSource.ReferralSourceAppointmentStatusSettings)
                        .SubPath(referralSourceAppointmentStatusSettingPath => referralSourceAppointmentStatusSettingPath
                            .Prefetch<AppointmentStatusEntity>(referralSourceAppointmentStatusSetting => referralSourceAppointmentStatusSetting.AppointmentStatus)
                            .Prefetch<InvoiceTypeEntity>(referralSourceAppointmentStatusSetting => referralSourceAppointmentStatusSetting.InvoiceType)
                        )
                );
        
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
                    .WithPath(ReferralSourcePath)
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

                var sources = meta.ReferralSource
                    .WithPath(ReferralSourcePath);

                if (null != criteria)
                {
                    if (!string.IsNullOrWhiteSpace(criteria.Name))
                    {
                        sources = sources
                            .Where(source => source.Name.Contains(criteria.Name));
                    }

                    if (criteria.ReferralSourceId.HasValue)
                    {
                        sources = sources
                            .Where(source => source.ReferralSourceId == criteria.ReferralSourceId.Value);
                    }

                    if (null != criteria.ReferralSourceTypeIds && criteria.ReferralSourceTypeIds.Any())
                    {
                        sources = sources
                            .Where(source => criteria.ReferralSourceTypeIds.Contains(source.ReferralSourceTypeId));
                    }

                    if (criteria.IsActive.HasValue)
                    {
                        sources = sources
                            .Where(source => source.IsActive == criteria.IsActive.Value);
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
                        .Where(referralSourceType => isActive == null || referralSourceType.IsActive == isActive)
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
                var uow = new UnitOfWork2();

                var isNew = referralSource.IsNew();

                var entity = new ReferralSourceEntity
                {
                    IsNew = isNew,
                    ReferralSourceId = referralSource.ReferralSourceId,
                };

                if (!isNew)
                {
                    var prefetch = new PrefetchPath2(EntityType.ReferralSourceEntity);

                    prefetch.Add(ReferralSourceEntity.PrefetchPathReportTypeInvoiceAmounts);

                    adapter.FetchEntity(entity, prefetch);
                }

                entity.Name = referralSource.Name;
                entity.ReferralSourceTypeId = referralSource.ReferralSourceType.ReferralSourceTypeId;
                entity.LargeFileSize = referralSource.LargeFileSize;
                entity.LargeFileFeeAmount = referralSource.LargeFileFeeAmount;
                entity.IsActive = referralSource.IsActive;

                if (null == referralSource.Address)
                {
                    entity.SetNewFieldValue((int)ReferralSourceFieldIndex.AddressId, null);
                }
                else
                {
                    entity.AddressId = referralSource.Address.AddressId;
                }

                #region report type invoice amounts

                var reportTypeInvoiceAmountsToAdd = referralSource.ReportTypeInvoiceAmounts
                    .Where(reportTypeInvoiceAmount =>
                        !entity.ReportTypeInvoiceAmounts.Any(reportTypeInvoiceAmountEntity =>
                            reportTypeInvoiceAmountEntity.ReportTypeId == reportTypeInvoiceAmount.ReportType.ReportTypeId
                        )
                    );

                var reportTypeInvoiceAmountsToRemove = entity.ReportTypeInvoiceAmounts
                    .Where(reportTypeInvoiceAmountEntity =>
                        !referralSource.ReportTypeInvoiceAmounts.Any(reportTypeInvoiceAmount =>
                            reportTypeInvoiceAmount.ReportType.ReportTypeId == reportTypeInvoiceAmountEntity.ReportTypeId
                        )
                    );

                var reportTypeInvoiceAmountsToUpdate = referralSource.ReportTypeInvoiceAmounts
                    .Where(reportTypeInvoiceAmount =>
                        entity.ReportTypeInvoiceAmounts.Any(reportTypeInvoiceAmountEntity =>
                            reportTypeInvoiceAmountEntity.ReportTypeId == reportTypeInvoiceAmount.ReportType.ReportTypeId &&
                            reportTypeInvoiceAmountEntity.InvoiceAmount != reportTypeInvoiceAmount.InvoiceAmount
                        )
                    );

                foreach (var invoiceAmount in reportTypeInvoiceAmountsToRemove)
                {
                    uow.AddForDelete(invoiceAmount);
                }

                foreach (var invoiceAmount in reportTypeInvoiceAmountsToUpdate)
                {
                    var invoiceAmountEntity = entity.ReportTypeInvoiceAmounts
                        .Where(referralSourceInvoiceAmount => referralSourceInvoiceAmount.ReportTypeId == invoiceAmount.ReportType.ReportTypeId)
                        .SingleOrDefault();

                    if (null != invoiceAmountEntity)
                    {
                        invoiceAmountEntity.InvoiceAmount = invoiceAmount.InvoiceAmount;
                    }
                }

                entity.ReportTypeInvoiceAmounts.AddRange(
                    reportTypeInvoiceAmountsToAdd.Select(invoiceAmount =>
                    new ReportTypeInvoiceAmountEntity
                    {
                        InvoiceAmount = invoiceAmount.InvoiceAmount,
                        ReportTypeId = invoiceAmount.ReportType.ReportTypeId,
                    })
                );
                
                #endregion

                uow.AddForSave(entity);

                uow.Commit(adapter);

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
