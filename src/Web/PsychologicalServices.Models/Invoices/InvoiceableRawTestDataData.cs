using System;

namespace PsychologicalServices.Models.Invoices
{
    public class InvoiceableRawTestDataData
    {
        public int RawTestDataId { get; set; }

        public string Claimant { get; set; }

        public string PayableTo { get; set; }

        public int PayableToId { get; set; }

        public string ReferralSource { get; set; }

        public DateTimeOffset? RequestReceivedDate { get; set; }
    }
}
