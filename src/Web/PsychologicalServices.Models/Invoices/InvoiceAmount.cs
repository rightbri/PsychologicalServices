﻿using System;

namespace PsychologicalServices.Models.Invoices
{
    public class InvoiceAmount
    {
        public int ReferralSourceId { get; set; }

        public int ReportTypeId { get; set; }

        public int Amount { get; set; }
    }
}
