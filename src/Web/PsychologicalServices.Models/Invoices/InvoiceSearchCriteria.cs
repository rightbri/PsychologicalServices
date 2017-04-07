using System;

namespace PsychologicalServices.Models.Invoices
{
    public class InvoiceSearchCriteria
    {
        public int? AppointmentId { get; set; }

        public string Identifier { get; set; }

        public DateTime? InvoiceDate { get; set; }

        public int? InvoiceStatusId { get; set; }
    }
}
