using PsychologicalServices.Models.Appointments;
using PsychologicalServices.Models.Assessments;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Invoices
{
    public class Invoice
    {
        public int InvoiceId { get; set; }

        public string Identifier { get; set; }

        public DateTime InvoiceDate { get; set; }

        public Appointment Appointment { get; set; }

        public InvoiceStatus InvoiceStatus { get; set; }

        public DateTime UpdateDate { get; set; }

        public decimal TaxRate { get; set; }

        public decimal Total { get; set; }

        public IEnumerable<InvoiceLine> Lines { get; set; }

        public IEnumerable<InvoiceStatusChange> StatusChanges { get; set; }

        public byte[] Document { get; set; }

        public bool IsNew()
        {
            return InvoiceId == 0;
        }
    }
}
