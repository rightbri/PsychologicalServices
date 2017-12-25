using PsychologicalServices.Models.Referrals;
using System;

namespace PsychologicalServices.Models.Invoices
{
    public class ReferralSourceInvoiceConfiguration
    {
        public ReferralSource ReferralSource { get; set; }

        public int LargeFileSize { get; set; }

        public int LargeFileFee { get; set; }

        public int ExtraReportFee { get; set; }

        public int CompletionFee { get; set; }
    }
}
