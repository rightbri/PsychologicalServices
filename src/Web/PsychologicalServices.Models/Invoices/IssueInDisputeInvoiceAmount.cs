using PsychologicalServices.Models.Claims;

namespace PsychologicalServices.Models.Invoices
{
    public class IssueInDisputeInvoiceAmount
    {
        public IssueInDispute IssueInDispute { get; set; }

        public int InvoiceAmount { get; set; }
    }
}
