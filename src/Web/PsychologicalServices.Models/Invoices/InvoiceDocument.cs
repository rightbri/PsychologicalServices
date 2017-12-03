using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Invoices
{
    public class InvoiceDocument
    {
        public int InvoiceDocumentId { get; set; }

        public string FileName { get; set; }

        public byte[] Content { get; set; }

        public DateTimeOffset CreateDate { get; set; }

        public IEnumerable<InvoiceDocumentSendLog> SendLogs { get; set; }
    }
}
