using PsychologicalServices.Data;
using PsychologicalServices.Data.EntityClasses;
using PsychologicalServices.Data.Linq;
using PsychologicalServices.Infrastructure.Common.Repository;
using PsychologicalServices.Models.Common.Utility;
using PsychologicalServices.Models.PhoneLogs;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Infrastructure.PhoneLog
{
    public class PhoneLogRepository : RepositoryBase, IPhoneLogRepository
    {
        private readonly IDate _date = null;

        public PhoneLogRepository(
            IDataAccessAdapterFactory adapterFactory,
            IDate date
        ) : base(adapterFactory)
        {
            _date = date;
        }

        #region PrefetchPaths

        private static readonly Func<IPathEdgeRootParser<PhoneLogEntity>, IPathEdgeRootParser<PhoneLogEntity>>
            PhoneLogPath =
                (phoneLogPath => phoneLogPath
                    .Prefetch<NoteEntity>(phoneLog => phoneLog.Note)
                    .Prefetch<UserEntity>(phoneLog => phoneLog.CreateUser)
                    .Prefetch<UserEntity>(phoneLog => phoneLog.UpdateUser)
                );

        #endregion

        public Models.PhoneLogs.PhoneLog Get(int id)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var model = meta.PhoneLog
                    .WithPath(PhoneLogPath)
                    .Where(pl => pl.PhoneLogId == id)
                    .SingleOrDefault()
                    .ToModel();

                return model;
            }
        }

        public IEnumerable<Models.PhoneLogs.PhoneLog> Get(PhoneLogSearchCriteria criteria)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var entities = meta.PhoneLog
                    .WithPath(PhoneLogPath);

                if (null != criteria)
                {
                    if (criteria.StartCallTime.HasValue)
                    {
                        entities = entities.Where(item => item.CallTime >= criteria.StartCallTime.Value);
                    }

                    if (criteria.EndCallTime.HasValue)
                    {
                        entities = entities.Where(item => item.CallTime <= criteria.EndCallTime.Value);
                    }

                    if (!string.IsNullOrWhiteSpace(criteria.CompanyName))
                    {
                        entities = entities.Where(item => item.CompanyName.Contains(criteria.CompanyName));
                    }

                    if (!string.IsNullOrWhiteSpace(criteria.ClaimantLastName))
                    {
                        entities = entities.Where(item => item.ClaimantLastName.Contains(criteria.ClaimantLastName));
                    }

                    if (!string.IsNullOrWhiteSpace(criteria.ClaimantFirstName))
                    {
                        entities = entities.Where(item => item.ClaimantFirstName.Contains(criteria.ClaimantFirstName));
                    }
                }

                return Execute<PhoneLogEntity>(
                        (ILLBLGenProQuery)
                        entities
                    )
                    .Select(item => item.ToModel())
                    .ToList();
            }
        }

        public int Save(Models.PhoneLogs.PhoneLog model)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var uow = new UnitOfWork2();

                var isNew = model.IsNew();

                var entity = new PhoneLogEntity
                {
                    IsNew = isNew,
                    PhoneLogId = model.PhoneLogId,
                };

                if (!isNew)
                {
                    var prefetch = new PrefetchPath2(EntityType.PhoneLogEntity);

                    prefetch.Add(PhoneLogEntity.PrefetchPathNote);

                    adapter.FetchEntity(entity, prefetch);
                }
                else
                {
                    entity.CreateDate = _date.UtcNow;
                    entity.CreateUserId = model.CreateUser.UserId;
                }

                entity.CallTime = model.CallTime;

                if (string.IsNullOrWhiteSpace(model.CompanyName))
                    entity.SetNewFieldValue((int)PhoneLogFieldIndex.CompanyName, null);
                else
                    entity.CompanyName = model.CompanyName;

                if (string.IsNullOrWhiteSpace(model.CallerName))
                    entity.SetNewFieldValue((int)PhoneLogFieldIndex.CallerName, null);
                else
                    entity.CallerName = model.CallerName;

                if (string.IsNullOrWhiteSpace(model.ClaimantFirstName))
                    entity.SetNewFieldValue((int)PhoneLogFieldIndex.ClaimantFirstName, null);
                else
                    entity.ClaimantFirstName = model.ClaimantFirstName;

                if (string.IsNullOrWhiteSpace(model.ClaimantLastName))
                    entity.SetNewFieldValue((int)PhoneLogFieldIndex.ClaimantLastName, null);
                else
                    entity.ClaimantLastName = model.ClaimantLastName;

                entity.UpdateUserId = model.UpdateUser.UserId;
                entity.UpdateDate = _date.UtcNow;

                model.Note = model.Note ?? new Models.Notes.Note
                {
                    CreateDate = _date.UtcNow,
                    CreateUser = model.CreateUser,
                };

                if (entity.Note == null)
                {
                    entity.Note = new NoteEntity
                    {
                        Note = model.Note.NoteText,
                        CreateUserId = model.Note.CreateUser.UserId,
                        UpdateUserId = model.Note.UpdateUser.UserId,
                    };
                }
                else if (model.Note.NoteText != entity.Note.Note)
                {
                    entity.Note.Note = model.Note.NoteText;
                    entity.Note.UpdateUserId = model.Note.UpdateUser.UserId;
                    entity.Note.UpdateDate = _date.UtcNow;
                }

                uow.AddForSave(entity);

                uow.Commit(adapter);

                return entity.PhoneLogId;
            }
        }

        public bool Delete(int id)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var success = adapter.DeleteEntity(
                    new PhoneLogEntity(id)
                );

                return success;
            }
        }
    }
}
