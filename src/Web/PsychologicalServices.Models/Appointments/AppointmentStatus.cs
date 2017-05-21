using PsychologicalServices.Models.Referrals;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Appointments
{
    public class AppointmentStatus
    {
        public int AppointmentStatusId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool NotifyReferralSource { get; set; }

        public bool CanInvoice { get; set; }

        public bool IsActive { get; set; }

        public IEnumerable<AppointmentStatusSetting> AppointmentStatusSettings { get; set; }

        public bool IsNew()
        {
            return AppointmentStatusId == 0;
        }
    }
}
