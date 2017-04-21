using PsychologicalServices.Models.Appointments;
using System;

namespace PsychologicalServices.Models.Referrals
{
    public class AppointmentStatusSetting
    {
        public AppointmentStatus AppointmentStatus { get; set; }

        public decimal InvoiceRate { get; set; }
    }
}
