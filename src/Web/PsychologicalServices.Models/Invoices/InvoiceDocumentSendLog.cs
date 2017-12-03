using System;

namespace PsychologicalServices.Models.Invoices
{
    public class InvoiceDocumentSendLog
    {
        public int InvoiceDocumentSendLogId { get; set; }

        public int InvoiceDocumentId { get; set; }

        public string Recipients { get; set; }

        public DateTimeOffset SentDate { get; set; }
    }
}
