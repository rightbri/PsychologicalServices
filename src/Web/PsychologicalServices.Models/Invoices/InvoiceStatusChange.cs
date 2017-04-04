using System;

namespace PsychologicalServices.Models.Invoices
{
    public class InvoiceStatusChange
    {
        public int InvoiceStatusChangeId { get; set; }

        public InvoiceStatus InvoiceStatus { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
