using System;

namespace PsychologicalServices.Models.Invoices
{
    public class InvoiceSearchCriteria
    {
        public int? AppointmentId { get; set; }

        public string Identifier { get; set; }

        public DateTime? InvoiceDate { get; set; }

        public DateTime? InvoiceMonth { get; set; }

        public int? InvoiceStatusId { get; set; }

        public int? InvoiceTypeId { get; set; }

        public int? PayableToId { get; set; }

        public int? CompanyId { get; set; }
    }
}
