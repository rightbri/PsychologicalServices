using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Invoices
{
    public class PsychologistInvoiceSendResult
    {
        public PsychologistInvoiceSendResult()
        {
            Errors = new List<string>();
        }

        public bool Success { get; set; }

        public List<string> Errors { get; set; } 
    }
}
