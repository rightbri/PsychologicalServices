using System;

namespace PsychologicalServices.Models.Invoices
{
    public class PsychometristInvoiceCreationParameters
    {
        public int CompanyId { get; set; }

        public int PsychometristId { get; set; }

        public int Year { get; set; }

        public int Month { get; set; }
    }
}
