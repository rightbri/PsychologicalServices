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
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalServices.Infrastructure.CalendarNotes
{
    public class CalendarNoteRepository : RepositoryBase, ICalendarNoteRepository
    {
        private readonly INow _now = null;

        public CalendarNoteRepository(
            IDataAccessAdapterFactory dataAccessAdapterFactory,
            INow now
        ) : base(dataAccessAdapterFactory)
        {
            _now = now;
        }

        #region Prefetch Paths

        private static readonly Func<IPathEdgeRootParser<CalendarNoteEntity>, IPathEdgeRootParser<CalendarNoteEntity>>
            CalendarNotePath =
                (calendarNotePath => calendarNotePath
                    .Prefetch<NoteEntity>(calendarNote => calendarNote.Note)
                        .SubPath(notePath => notePath
                            .Prefetch<UserEntity>(note => note.CreateUser)
                            .Prefetch<UserEntity>(note => note.UpdateUser)
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

        public IEnumerable<CalendarNote> GetCalendarNotes(DateTime? fromDate, DateTime? toDate, bool includeDeleted = false)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var calendarNotes = meta.CalendarNote.WithPath(CalendarNotePath);

                if (fromDate.HasValue)
                {
                    calendarNotes = calendarNotes.Where(calendarNote => calendarNote.FromDate <= toDate.Value);
                }

                if (toDate.HasValue)
                {
                    calendarNotes = calendarNotes.Where(calendarNote => calendarNote.ToDate >= fromDate.Value);
                }

                if (!includeDeleted)
                {
                    calendarNotes = calendarNotes.Where(calendarNote => !calendarNote.Note.Deleted);
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
                    var prefetch = new PrefetchPath2(EntityType.NoteEntity);

                    prefetch.Add(CalendarNoteEntity.PrefetchPathNote);

                    adapter.FetchEntity(calendarNoteEntity, prefetch);
                }
                else
                {
                    calendarNoteEntity.Note = new NoteEntity
                        {
                            CreateUserId = calendarNote.Note.CreateUserId,
                            CreateDate = _now.DateTimeNow,
                        };
                }

                calendarNoteEntity.FromDate = calendarNote.FromDate;
                calendarNoteEntity.ToDate = calendarNote.ToDate;
                calendarNoteEntity.Note.Note = calendarNote.Note.NoteText;
                calendarNoteEntity.Note.UpdateUserId = calendarNote.Note.UpdateUserId;
                calendarNoteEntity.Note.UpdateDate = _now.DateTimeNow;

                adapter.SaveEntity(calendarNoteEntity, false);

                return calendarNoteEntity.CalendarNoteId;
            }
        }
    }
}
