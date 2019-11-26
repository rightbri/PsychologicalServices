using System;

namespace PsychologicalServices.Models.Invoices
{
    public class InvoiceableConsultingAgreementSearchCriteria
    {
        public int CompanyId { get; set; }

        public int Year { get; set; }

        public int Month { get; set; }
    }
}
