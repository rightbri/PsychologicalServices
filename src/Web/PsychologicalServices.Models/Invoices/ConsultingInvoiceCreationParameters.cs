using System;

namespace PsychologicalServices.Models.Invoices
{
    public class ConsultingInvoiceCreationParameters
    {
        public int ConsultingAgreementId { get; set; }

        public int Year { get; set; }

        public int Month { get; set; }
    }
}
