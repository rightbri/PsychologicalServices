using PsychologicalServices.Models.Referrals;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Appointments
{
    public class AppointmentStatus
    {
        public const int OnHold = 1;
        public const int Confirmed = 2;
        public const int Canceled = 3;
        public const int Showed = 4;
        public const int NoShow = 5;
        public const int Incomplete = 6;
        public const int Complete = 7;
        public const int LateCancellation = 8;
        
        public int AppointmentStatusId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool NotifyReferralSource { get; set; }

        public bool CanInvoice { get; set; }

        public int Sort { get; set; }

        public bool IsActive { get; set; }

        public IEnumerable<AppointmentStatusSetting> AppointmentStatusSettings { get; set; }

        public bool IsNew()
        {
            return AppointmentStatusId == 0;
        }
    }
}
