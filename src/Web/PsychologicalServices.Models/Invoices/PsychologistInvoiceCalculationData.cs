using PsychologicalServices.Models.Companies;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Invoices
{
    public class PsychologistInvoiceCalculationData
    {
        public Company Company { get; set; }
        
        public decimal InvoiceRate { get; set; }

        public int SingleReportInvoiceAmount { get; set; }

        public int ComboReportInvoiceAmount { get; set; }

        public int LargeFileSize { get; set; }

        public int LargeFileFee { get; set; }

        public int ExtraReportFee { get; set; }

        public int CompletionFeeAmount { get; set; }

        public bool ApplyCompletionFee { get; set; }

        public bool ApplyLargeFileFee { get; set; }

        public bool ApplyTravelFee { get; set; }

        public bool ApplyIssueInDisputeFees { get; set; }

        public bool ApplyExtraReportFees { get; set; }

        public IEnumerable<IssueInDisputeInvoiceAmount> IssueInDisputeInvoiceAmounts { get; set; }

        public bool MissingAppointmentStatusInvoiceData { get; set; }

        public bool MissingAssessmentTypeInvoiceData { get; set; }

        public bool MissingReferralSourceInvoiceData { get; set; }
    }
}
