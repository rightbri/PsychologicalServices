using System;

namespace PsychologicalServices.Models.Invoices
{
    public class InvoiceLine
    {
        public int InvoiceLineId { get; set; }

        public int InvoiceAppointmentId { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public bool IsCustom { get; set; }
    }
}
