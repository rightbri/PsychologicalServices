using PsychologicalServices.Models.Appointments;
using PsychologicalServices.Models.Assessments;
using PsychologicalServices.Models.Users;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Invoices
{
    public class Invoice
    {
        public int InvoiceId { get; set; }

        public string Identifier { get; set; }

        public DateTime InvoiceDate { get; set; }

        public InvoiceStatus InvoiceStatus { get; set; }

        public InvoiceType InvoiceType { get; set; }

        public User PayableTo { get; set; }

        public DateTime UpdateDate { get; set; }

        public decimal TaxRate { get; set; }

        public int Total { get; set; }

        public IEnumerable<InvoiceAppointment> Appointments { get; set; }

        public IEnumerable<InvoiceStatusChange> StatusChanges { get; set; }

        public IEnumerable<InvoiceDocument> Documents { get; set; }

        public bool IsNew()
        {
            return InvoiceId == 0;
        }
    }
}
