using PsychologicalServices.Models.Assessments;
using PsychologicalServices.Models.Referrals;
using System;

namespace PsychologicalServices.Models.Invoices
{
    public class AssessmentTypeInvoiceAmount
    {
        public ReferralSource ReferralSource { get; set; }

        public AssessmentType AssessmentType { get; set; }

        public int SingleReportInvoiceAmount { get; set; }

        public int ComboReportInvoiceAmount { get; set; }
    }
}
