using PsychologicalServices.Models.Referrals;
using PsychologicalServices.Models.Reports;
using System;

namespace PsychologicalServices.Models.Invoices
{
    public class InvoiceAmount
    {
        public ReportType ReportType { get; set; }

        public int FirstReportAmount { get; set; }

        public int AdditionalReportAmount { get; set; }
    }
}
