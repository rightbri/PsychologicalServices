using System;

namespace PsychologicalServices.Models.Invoices
{
    public class InvoiceableAppointmentDataSearchCriteria
    {
        public int CompanyId { get; set; }

        public int? InvoiceTypeId { get; set; }

        public DateTimeOffset? StartSearch { get; set; }
    }
}
