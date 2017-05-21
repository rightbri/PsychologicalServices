using PsychologicalServices.Models.Appointments;
using PsychologicalServices.Models.Referrals;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Invoices
{
    public class InvoiceAppointment
    {
        public int InvoiceAppointmentId { get; set; }

        public Appointment Appointment { get; set; }

        public IEnumerable<InvoiceLine> Lines { get; set; }

        public decimal InvoiceRate { get; set; }
    }
}
