using System;

namespace PsychologicalServices.Models.Invoices
{
    public class InvoiceableAppointmentDataSearchCriteria
    {
        public int CompanyId { get; set; }

        public int? InvoiceTypeId { get; set; }

        public DateTimeOffset? StartDateSearch { get; set; }

        public DateTimeOffset? EndDateSearch { get; set; }
    }
}
