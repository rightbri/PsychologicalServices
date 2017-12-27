using System;

namespace PsychologicalServices.Models.Invoices
{
    public class InvoiceDefaults
    {
        public const int CompletionFee = 50000;
        public const int ExtraReportFee = 50000;
        public const int LargeFileFee = 25000;
        public const int LargeFileSize = 1000;
        public const int IssueInDisputeInvoiceAmount = 0;
        public const int SingleReportInvoiceAmount = 0;
        public const int ComboReportInvoiceAmount = 0;
        public const int PsychometristInvoiceAmount = 0;
        public const decimal InvoiceRate = 1.0m;
        public const bool ApplyCompletionFee = false;
        public const bool ApplyLargeFileFee = false;
        public const bool ApplyTravelFee = false;
        public const bool ApplyIssueInDisputeFees = false;
        public const bool ApplyExtraReportFees = false;
    }
}
