using System;

namespace PsychologicalServices.Models.Invoices
{
    public class InvoiceStatus
    {
        public const int Open = 1;
        public const int Submitted = 2;
        public const int Paid = 3;

        public int InvoiceStatusId { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public bool CanEdit { get; set; }

        public bool CanOpen { get; set; }

        public bool CanSubmit { get; set; }

        public bool CanMarkPaid { get; set; }
    }
}
