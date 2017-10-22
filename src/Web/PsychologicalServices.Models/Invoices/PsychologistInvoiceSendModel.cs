using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Invoices
{
    public class PsychologistInvoiceSendModel
    {
        public string ClaimantName { get; set; }

        public string InvoicesContactEmail { get; set; }

        public string CompanyEmail { get; set; }

        public string PsychologistEmail { get; set; }

        public InvoiceDocument Document { get; set; }

        public bool IsValid
        {
            get
            {
                return !Errors.Any() &&
                    !string.IsNullOrWhiteSpace(ClaimantName) &&
                    !string.IsNullOrWhiteSpace(InvoicesContactEmail) &&
                    !string.IsNullOrWhiteSpace(CompanyEmail) &&
                    !string.IsNullOrWhiteSpace(PsychologistEmail) &&
                    null != Document &&
                    !string.IsNullOrWhiteSpace(Document.FileName) &&
                    null != Document.Content;
            }
        }

        public IEnumerable<string> Errors { get; set; }
    }
}
