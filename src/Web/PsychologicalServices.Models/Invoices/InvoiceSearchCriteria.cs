using System;

namespace PsychologicalServices.Models.Invoices
{
    public class InvoiceSearchCriteria
    {
        public int? AppointmentId { get; set; }

        public string Identifier { get; set; }

        public DateTimeOffset? InvoiceDate { get; set; }

        public DateTimeOffset? InvoiceMonth { get; set; }

        public int? InvoiceStatusId { get; set; }

        public int? InvoiceTypeId { get; set; }

        public int? PayableToId { get; set; }

        public bool? NeedsRefresh { get; set; }

        public int CompanyId { get; set; }
    }
}
