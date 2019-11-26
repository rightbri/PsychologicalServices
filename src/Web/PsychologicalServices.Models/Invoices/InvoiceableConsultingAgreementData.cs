using System;

namespace PsychologicalServices.Models.Invoices
{
    public class InvoiceableConsultingAgreementData
    {
        public int ConsultingAgreementId { get; set; }

        public string PayableTo { get; set; }

        public int PayableToId { get; set; }

        public string ReferralSource { get; set; }

        public int Year { get; set; }

        public int Month { get; set; }

        public int? InvoiceId { get; set; }

        public bool CanCreateInvoice { get; set; }
    }
}
