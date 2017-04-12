using System;

namespace PsychologicalServices.Models.Invoices
{
    public class InvoiceDocument
    {
        public int InvoiceId { get; set; }

        public byte[] Document { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
