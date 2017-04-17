using System;

namespace PsychologicalServices.Models.Invoices
{
    public class InvoiceDocument
    {
        public string FileName { get; set; }

        public byte[] Content { get; set; }
    }
}
