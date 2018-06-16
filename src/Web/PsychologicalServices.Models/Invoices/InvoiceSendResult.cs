using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Invoices
{
    public class InvoiceSendResult
    {
        public InvoiceSendResult(
            bool success,
            IEnumerable<InvoiceSendError> errors,
            IEnumerable<InvoiceDocumentSendLog> sendLogs
        )
        {
            Success = success;
            Errors = new List<InvoiceSendError>(errors);
            SendLogs = sendLogs;
        }

        public bool Success { get; private set; }

        public List<InvoiceSendError> Errors { get; private set; } 

        public IEnumerable<InvoiceDocumentSendLog> SendLogs { get; private set; }

        public static InvoiceSendResult Error(string message, InvoiceSendErrorType type)
        {
            return new InvoiceSendResult(false, new[] { new InvoiceSendError(message, type) }, null);
        }
    }
}
