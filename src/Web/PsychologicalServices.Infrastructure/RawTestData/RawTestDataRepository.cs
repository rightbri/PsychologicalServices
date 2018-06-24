using PsychologicalServices.Data;
using PsychologicalServices.Data.EntityClasses;
using PsychologicalServices.Data.Linq;
using PsychologicalServices.Infrastructure.Common.Repository;
using PsychologicalServices.Models.Common.Utility;
using PsychologicalServices.Models.RawTestData;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Infrastructure.RawTestData
{
    public class RawTestDataRepository : RepositoryBase, IRawTestDataRepository
    {
        private readonly IDate _date = null;

        public RawTestDataRepository(
            IDataAccessAdapterFactory adapterFactory,
            IDate date
        ) : base(adapterFactory)
        {
            _date = date;
        }

        #region Prefetch Paths

        private static readonly Func<IPathEdgeRootParser<RawTestDataEntity>, IPathEdgeRootParser<RawTestDataEntity>>
            RawTestDataPath =
                (rawTestDataPath => rawTestDataPath
                    .Prefetch<UserEntity>(rawTestData => rawTestData.Psychologist)
                    .Prefetch<ClaimantEntity>(rawTestData => rawTestData.Claimant)
                    .Prefetch<ReferralSourceEntity>(rawTestData => rawTestData.BillToReferralSource)
                    .Prefetch<CompanyEntity>(rawTestData => rawTestData.Company)
                    .Prefetch<RawTestDataStatusEntity>(rawTestData => rawTestData.RawTestDataStatus)
                    .Prefetch<NoteEntity>(rawTestData => rawTestData.Note)
                        .SubPath(notePath => notePath
                            .Prefetch<UserEntity>(note => note.CreateUser)
                            .Prefetch<UserEntity>(note => note.UpdateUser)
                        )
                );

        #endregion

        public Models.RawTestData.RawTestData GetRawTestData(int rawTestDataId)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return meta.RawTestData
                    .WithPath(RawTestDataPath)
                    .Where(rawTestData => rawTestData.RawTestDataId == rawTestDataId)
                    .SingleOrDefault()
                    .ToRawTestData();
            }
        }

        public IEnumerable<Models.RawTestData.RawTestData> GetRawTestDatas(RawTestDataSearchCriteria criteria)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var rawTestDatas = meta.RawTestData
                    .WithPath(RawTestDataPath);

                if (criteria.CompanyId.HasValue)
                {
                    rawTestDatas = rawTestDatas.Where(rawTestData => rawTestData.CompanyId == criteria.CompanyId);
                }

                if (criteria.ClaimantId.HasValue)
                {
                    rawTestDatas = rawTestDatas.Where(rawTestData => rawTestData.ClaimantId == criteria.ClaimantId);
                }

                if (null != criteria.RawTestDataStatusIds && criteria.RawTestDataStatusIds.Any())
                {
                    rawTestDatas = rawTestDatas.Where(rawTestData =>
                        rawTestData.RawTestDataStatusId == null ||
                        criteria.RawTestDataStatusIds.Contains(rawTestData.RawTestDataStatusId.Value)
                    );
                }

                return Execute<RawTestDataEntity>(
                        (ILLBLGenProQuery)
                        rawTestDatas
                    )
                    .Select(rawTestData => rawTestData.ToRawTestData())
                    .ToList();
            }
        }

        public IEnumerable<RawTestDataStatus> GetRawTestDataStatuses(bool? isActive = true)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return
                    Execute<RawTestDataStatusEntity>(
                        (ILLBLGenProQuery)
                        meta.RawTestDataStatus
                        .Where(rawTestDataStatus => isActive == null || rawTestDataStatus.IsActive == isActive.Value)
                    )
                    .Select(rawTestDataStatus => rawTestDataStatus.ToRawTestDataStatus())
                    .ToList();
            }
        }

        public int SaveRawTestData(Models.RawTestData.RawTestData rawTestData)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var uow = new UnitOfWork2();

                var isNew = rawTestData.IsNew();

                var entity = new RawTestDataEntity
                {
                    IsNew = isNew,
                    RawTestDataId = rawTestData.RawTestDataId,
                };

                if (!isNew)
                {
                    var prefetch = new PrefetchPath2(EntityType.RawTestDataEntity);

                    adapter.FetchEntity(entity, prefetch);
                }

                entity.CompanyId = rawTestData.Company.CompanyId;

                if (null != rawTestData.Claimant)
                {
                    entity.ClaimantId = rawTestData.Claimant.ClaimantId;
                }
                else
                {
                    entity.SetNewFieldValue((int)RawTestDataFieldIndex.ClaimantId, null);
                }

                if (null != rawTestData.BillToReferralSource)
                {
                    entity.BillToReferralSourceId = rawTestData.BillToReferralSource.ReferralSourceId;
                }
                else
                {
                    entity.SetNewFieldValue((int)RawTestDataFieldIndex.BillToReferralSourceId, null);
                }

                if (null != rawTestData.Psychologist)
                {
                    entity.PsychologistId = rawTestData.Psychologist.UserId;
                }
                else
                {
                    entity.SetNewFieldValue((int)RawTestDataFieldIndex.PsychologistId, null);
                }

                if (null != rawTestData.Status)
                {
                    entity.RawTestDataStatusId = rawTestData.Status.RawTestDataStatusId;
                }
                else
                {
                    entity.SetNewFieldValue((int)RawTestDataFieldIndex.RawTestDataStatusId, null);
                }

                if (rawTestData.RequestReceivedDate.HasValue)
                {
                    entity.RequestReceivedDate = rawTestData.RequestReceivedDate;
                }
                else
                {
                    entity.SetNewFieldValue((int)RawTestDataFieldIndex.RequestReceivedDate, null);
                }

                if (rawTestData.SignedAuthorizationReceivedDate.HasValue)
                {
                    entity.SignedAuthorizationReceivedDate = rawTestData.SignedAuthorizationReceivedDate;
                }
                else
                {
                    entity.SetNewFieldValue((int)RawTestDataFieldIndex.SignedAuthorizationReceivedDate, null);
                }

                if (rawTestData.DataSentDate.HasValue)
                {
                    entity.DataSentDate = rawTestData.DataSentDate;
                }
                else
                {
                    entity.SetNewFieldValue((int)RawTestDataFieldIndex.DataSentDate, null);
                }

                if (null != rawTestData.Note)
                {
                    if (null == entity.Note)
                    {
                        if (!string.IsNullOrWhiteSpace(rawTestData.Note.NoteText))
                        {
                            entity.Note = new NoteEntity
                            {
                                Note = rawTestData.Note.NoteText,
                                CreateUserId = rawTestData.Note.CreateUser.UserId,
                                UpdateUserId = rawTestData.Note.UpdateUser.UserId,
                            };
                        }
                    }
                    else if (entity.Note.Note != rawTestData.Note.NoteText)
                    {
                        entity.Note.Note = rawTestData.Note.NoteText;
                        entity.Note.UpdateUserId = rawTestData.Note.UpdateUser.UserId;
                        entity.Note.UpdateDate = _date.UtcNow;
                    }
                }

                uow.AddForSave(entity);

                uow.Commit(adapter);

                return entity.RawTestDataId;
            }
        }
    }
}
