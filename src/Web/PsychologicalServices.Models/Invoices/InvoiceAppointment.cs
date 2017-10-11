using PsychologicalServices.Models.Appointments;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Invoices
{
    public class InvoiceAppointment
    {
        public int InvoiceAppointmentId { get; set; }

        public Appointment Appointment { get; set; }

        public IEnumerable<InvoiceLine> Lines { get; set; }
    }
}
