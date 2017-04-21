﻿using System;

namespace PsychologicalServices.Models.Invoices
{
    public class InvoiceDocument
    {
        public int InvoiceDocumentId { get; set; }

        public string FileName { get; set; }

        public byte[] Content { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
