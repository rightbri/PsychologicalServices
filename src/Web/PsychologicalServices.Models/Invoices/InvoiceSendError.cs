using System;

namespace PsychologicalServices.Models.Invoices
{
    public class InvoiceSendError
    {
        public InvoiceSendError(
            string message,
            InvoiceSendErrorType type
        )
        {
            Message = message;
            Type = type;
        }

        public string Message { get; private set; }

        public InvoiceSendErrorType Type { get; private set; }
    }
}
