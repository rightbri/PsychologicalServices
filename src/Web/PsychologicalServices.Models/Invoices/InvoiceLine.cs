﻿using System;

namespace PsychologicalServices.Models.Invoices
{
    public class InvoiceLine
    {
        public int InvoiceLineId { get; set; }

        public string Description { get; set; }

        public int Amount { get; set; }

        public bool IsCustom { get; set; }

        public int OriginalAmount { get; set; }
    }
}
