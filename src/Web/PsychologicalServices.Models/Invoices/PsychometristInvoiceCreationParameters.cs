using System;

namespace PsychologicalServices.Models.Invoices
{
    public class PsychometristInvoiceCreationParameters
    {
        public int CompanyId { get; set; }

        public int PsychometristId { get; set; }

        public DateTimeOffset InvoicePeriodBegin { get; set; }

        public DateTimeOffset InvoicePeriodEnd { get; set; }
    }
}
