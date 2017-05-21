using System;

namespace PsychologicalServices.Models.Invoices
{
    public class PsychometristInvoiceCreationParameters
    {
        public int CompanyId { get; set; }

        public DateTime InvoiceMonth { get; set; }
    }
}
