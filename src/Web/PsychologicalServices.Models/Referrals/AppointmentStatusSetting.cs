using PsychologicalServices.Models.Appointments;
using PsychologicalServices.Models.Invoices;
using System;

namespace PsychologicalServices.Models.Referrals
{
    public class AppointmentStatusSetting
    {
        public AppointmentStatus AppointmentStatus { get; set; }

        public ReferralSource ReferralSource { get; set; }

        public InvoiceType InvoiceType { get; set; }

        public AppointmentSequence AppointmentSequence { get; set; }

        public decimal InvoiceRate { get; set; }

        public int InvoiceFee { get; set; }

        public bool ApplyTravelFee { get; set; }

        public bool ApplyLargeFileFee { get; set; }
    }
}
