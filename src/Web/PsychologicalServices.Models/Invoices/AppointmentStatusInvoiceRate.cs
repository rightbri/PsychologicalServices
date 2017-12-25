using PsychologicalServices.Models.Appointments;
using PsychologicalServices.Models.Referrals;
using System;

namespace PsychologicalServices.Models.Invoices
{
    public class AppointmentStatusInvoiceRate
    {
        public ReferralSource ReferralSource { get; set; }

        public AppointmentStatus AppointmentStatus { get; set; }

        public AppointmentSequence AppointmentSequence { get; set; }

        public decimal InvoiceRate { get; set; }

        public bool ApplyCompletionFee { get; set; }

        public bool ApplyLargeFileFee { get; set; }

        public bool ApplyTravelFee { get; set; }

        public bool ApplyIssueInDisputeFees { get; set; }

        public bool ApplyExtraReportFees { get; set; }
    }
}
