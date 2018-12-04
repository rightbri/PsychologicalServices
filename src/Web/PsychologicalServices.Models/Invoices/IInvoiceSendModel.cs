using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Invoices
{
    public interface IInvoiceSendModel
    {
        string SenderEmail { get; }

        string RecipientEmail { get; }

        string CourtesyCopyEmail { get; }

        string ReplyToEmail { get; }

        string EmailBody { get; }

        string EmailSubject { get; }

        InvoiceDocument InvoiceDocument { get; }

        bool IsValid { get; }

        IEnumerable<string> Errors { get; }
    }
}
