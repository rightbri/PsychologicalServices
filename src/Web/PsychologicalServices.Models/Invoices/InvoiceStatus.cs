using System;

namespace PsychologicalServices.Models.Invoices
{
    public class InvoiceStatus
    {
        public int InvoiceStatusId { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }
    }
}
