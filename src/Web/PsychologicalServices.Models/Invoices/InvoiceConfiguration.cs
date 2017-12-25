using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Invoices
{
    public class InvoiceConfiguration
    {
        public int CompanyId { get; set; }

        public IEnumerable<AssessmentTypeInvoiceAmount> AssessmentTypeInvoiceAmounts { get; set; }

        public IEnumerable<IssueInDisputeInvoiceAmount> IssueInDisputeInvoiceAmounts { get; set; }

        public IEnumerable<ReferralSourceInvoiceConfiguration> ReferralSourceInvoiceConfigurations { get; set; }

        public IEnumerable<AppointmentStatusInvoiceRate> AppointmentStatusInvoiceRates { get; set; }

        public IEnumerable<PsychometristInvoiceAmount> PsychometristInvoiceAmounts { get; set; }
    }
}
