using System;

namespace PsychologicalServices.Models.Invoices
{
    public class InvoiceableArbitrationData
    {
        public int ArbitrationId { get; set; }

        public string Title { get; set; }

        public string Claimant { get; set; }

        public string PayableTo { get; set; }

        public int PayableToId { get; set; }

        public DateTimeOffset? StartDate { get; set; }

        public DateTimeOffset? AvailableDate { get; set; }
    }
}
