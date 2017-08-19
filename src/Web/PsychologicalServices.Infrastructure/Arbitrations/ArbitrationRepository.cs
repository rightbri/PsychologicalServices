using PsychologicalServices.Data.EntityClasses;
using PsychologicalServices.Data.Linq;
using PsychologicalServices.Infrastructure.Common.Repository;
using PsychologicalServices.Models.Arbitrations;
using SD.LLBLGen.Pro.LinqSupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalServices.Infrastructure.Arbitrations
{
    public class ArbitrationRepository : RepositoryBase, IArbitrationRepository
    {
        public ArbitrationRepository(
            IDataAccessAdapterFactory adapterFactory
        ) : base(adapterFactory)
        {
        }

        #region Prefetch Paths

        private static readonly Func<IPathEdgeRootParser<ArbitrationEntity>, IPathEdgeRootParser<ArbitrationEntity>>
            ArbitrationPath =
                (arbitrationPath => arbitrationPath
                    .Prefetch<ContactEntity>(arbitration => arbitration.DefenseLawyer)
                        .SubPath(contactPath => contactPath
                            .Prefetch<ContactTypeEntity>(contact => contact.ContactType)
                            .Prefetch<EmployerEntity>(contact => contact.Employer)
                            .Prefetch<AddressEntity>(contact => contact.Address)
                                .SubPath(addressPath => addressPath
                                    .Prefetch<CityEntity>(address => address.City)
                                )
                        )
                );

        #endregion

        //public IEnumerable<Arbitration> GetArbitrations(ArbitrationSearchCriteria criteria)
        //{
        //    using (var adapter = AdapterFactory.CreateAdapter())
        //    {
        //        var meta = new LinqMetaData(adapter);

        //        var calendarNotes = meta.CalendarNote.WithPath(CalendarNotePath);

        //        if (criteria.FromDate.HasValue)
        //        {
        //            calendarNotes = calendarNotes.Where(calendarNote => calendarNote.FromDate <= criteria.ToDate);
        //        }

        //        if (criteria.ToDate.HasValue)
        //        {
        //            calendarNotes = calendarNotes.Where(calendarNote => calendarNote.ToDate >= criteria.FromDate);
        //        }

        //        if (criteria.CompanyId.HasValue)
        //        {
        //            calendarNotes = calendarNotes.Where(calendarNote => calendarNote.CompanyId == criteria.CompanyId);
        //        }

        //        return Execute<CalendarNoteEntity>(
        //                (ILLBLGenProQuery)
        //                calendarNotes
        //            )
        //            .Select(calendarNote => calendarNote.ToCalendarNote())
        //            .ToList();
        //    }
        //}
    }
}
