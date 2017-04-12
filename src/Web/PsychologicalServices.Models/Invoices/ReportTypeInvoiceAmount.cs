using PsychologicalServices.Models.Reports;
using System;

namespace PsychologicalServices.Models.Invoices
{
    public class ReportTypeInvoiceAmount
    {
        public ReportType ReportType { get; set; }

        public int InvoiceAmount { get; set; }
    }
}
