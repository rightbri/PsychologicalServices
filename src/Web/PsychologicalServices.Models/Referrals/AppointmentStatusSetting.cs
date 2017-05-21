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

        public decimal InvoiceRate { get; set; }
    }
}
