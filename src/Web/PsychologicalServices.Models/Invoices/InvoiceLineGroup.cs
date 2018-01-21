using PsychologicalServices.Models.Appointments;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Invoices
{
    public class InvoiceLineGroup
    {
        public int InvoiceLineGroupId { get; set; }

        public string Description { get; set; }

        public IEnumerable<InvoiceLine> Lines { get; set; }

        public Appointment Appointment { get; set; }
    }
}
