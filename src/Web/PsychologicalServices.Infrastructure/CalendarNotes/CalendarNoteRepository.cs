using PsychologicalServices.Data;
using PsychologicalServices.Data.EntityClasses;
using PsychologicalServices.Data.Linq;
using PsychologicalServices.Infrastructure.Common.Repository;
using PsychologicalServices.Models.CalendarNotes;
using PsychologicalServices.Models.Common.Utility;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Infrastructure.CalendarNotes
{
    public class CalendarNoteRepository : RepositoryBase, ICalendarNoteRepository
    {
        private readonly IDate _now = null;

        public CalendarNoteRepository(
            IDataAccessAdapterFactory dataAccessAdapterFactory,
            IDate now
        ) : base(dataAccessAdapterFactory)
        {
            _now = now;
        }

        #region Prefetch Paths

        private static readonly Func<IPathEdgeRootParser<CalendarNoteEntity>, IPathEdgeRootParser<CalendarNoteEntity>>
            CalendarNotePath =
                (calendarNotePath => calendarNotePath
                    .Prefetch<CompanyEntity>(calendarNote => calendarNote.Company)
                    .Prefetch<NoteEntity>(calendarNote => calendarNote.Note)
                        .SubPath(notePath => notePath
                            .Prefetch<UserEntity>(note => note.CreateUser)
                            .Prefetch<UserEntity>(note => note.UpdateUser)
                            .Prefetch<UserNoteEntity>(note => note.UserNotes)
                                .SubPath(userNotePath => userNotePath
                                    .Prefetch<UserEntity>(userNote => userNote.User)
                                )
                        )
                );

        #endregion

        public CalendarNote GetCalendarNote(int id)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return meta.CalendarNote
                    .WithPath(CalendarNotePath)
                    .Where(calendarNote => calendarNote.CalendarNoteId == id)
                    .SingleOrDefault()
                    .ToCalendarNote();
            }
        }

        public IEnumerable<CalendarNote> GetCalendarNotes(CalendarNoteSearchCriteria criteria)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var calendarNotes = meta.CalendarNote.WithPath(CalendarNotePath);

                if (criteria.FromDate.HasValue)
                {
                    calendarNotes = calendarNotes.Where(calendarNote => calendarNote.FromDate <= criteria.ToDate);
                }

                if (criteria.ToDate.HasValue)
                {
                    calendarNotes = calendarNotes.Where(calendarNote => calendarNote.ToDate >= criteria.FromDate);
                }

                if (criteria.CompanyId.HasValue)
                {
                    calendarNotes = calendarNotes.Where(calendarNote => calendarNote.CompanyId == criteria.CompanyId);
                }

                return Execute<CalendarNoteEntity>(
                        (ILLBLGenProQuery)
                        calendarNotes
                    )
                    .Select(calendarNote => calendarNote.ToCalendarNote())
                    .ToList();
            }
        }

        public int SaveCalendarNote(CalendarNote calendarNote)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var isNew = calendarNote.IsNew();

                var calendarNoteEntity = new CalendarNoteEntity
                {
                    IsNew = isNew,
                    CalendarNoteId = calendarNote.CalendarNoteId,
                };

                if (!isNew)
                {
                    var prefetch = new PrefetchPath2(EntityType.CalendarNoteEntity);

                    prefetch.Add(CalendarNoteEntity.PrefetchPathNote);

                    adapter.FetchEntity(calendarNoteEntity, prefetch);
                }
                else
                {
                    calendarNoteEntity.Note = new NoteEntity
                        {
                            CreateUserId = calendarNote.Note.CreateUser.UserId,
                            CreateDate = _now.UtcNow,
                        };
                }

                calendarNoteEntity.FromDate = calendarNote.FromDate;
                calendarNoteEntity.ToDate = calendarNote.ToDate;
                calendarNoteEntity.CompanyId = calendarNote.Company.CompanyId;
                calendarNoteEntity.Note.Note = calendarNote.Note.NoteText;
                calendarNoteEntity.Note.UpdateUserId = calendarNote.Note.UpdateUser.UserId;
                calendarNoteEntity.Note.UpdateDate = _now.UtcNow;

                adapter.SaveEntity(calendarNoteEntity, false);

                return calendarNoteEntity.CalendarNoteId;
            }
        }

        public bool DeleteCalendarNote(int id)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var calendarNote = new CalendarNoteEntity
                {
                    CalendarNoteId = id,
                };

                var fetched = adapter.FetchEntity(calendarNote);

                if (!fetched)
                {
                    return false;
                }

                var calendarNoteDeleted = adapter.DeleteEntity(new CalendarNoteEntity
                {
                    CalendarNoteId = calendarNote.CalendarNoteId,
                });

                var noteDeleted = adapter.DeleteEntity(new NoteEntity
                {
                    NoteId = calendarNote.NoteId,
                });

                var success = calendarNoteDeleted && noteDeleted;

                return success;
            }
        }
    }
}
