using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Appointments
{
    public class AppointmentSearchCriteria
    {
        public int? AppointmentId { get; set; }

        public int? LocationId { get; set; }

        public int? PsychometristId { get; set; }

        public int? PsychologistId { get; set; }

        public IEnumerable<int> AppointmentStatusIds { get; set; }

        public DateTime? AppointmentTimeStart { get; set; }

        public DateTime? AppointmentTimeEnd { get; set; }

        public int? CompanyId { get; set; }
    }
}
