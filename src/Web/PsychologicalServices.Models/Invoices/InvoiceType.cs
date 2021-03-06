﻿using System;

namespace PsychologicalServices.Models.Invoices
{
    public class InvoiceType
    {
        public const int Psychologist = 1;
        public const int Psychometrist = 2;
        public const int Arbitration = 3;
        public const int RawTestData = 4;
        public const int Consulting = 5;

        public int InvoiceTypeId { get; set; }

        public string Name { get; set; }

        public bool CanSend { get; set; }

        public bool IsActive { get; set; }
    }
}
