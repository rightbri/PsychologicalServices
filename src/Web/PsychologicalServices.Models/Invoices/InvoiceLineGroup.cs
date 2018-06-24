using PsychologicalServices.Models.Appointments;
using PsychologicalServices.Models.Arbitrations;
using PsychologicalServices.Models.RawTestData;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Invoices
{
    public class InvoiceLineGroup
    {
        public int InvoiceLineGroupId { get; set; }

        public string Description { get; set; }

        public int Sort { get; set; }

        public IEnumerable<InvoiceLine> Lines { get; set; }

        public Appointment Appointment { get; set; }

        public Arbitration Arbitration { get; set; }

        public RawTestData.RawTestData RawTestData { get; set; }
    }
}
