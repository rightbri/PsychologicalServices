using System;

namespace PsychologicalServices.Models.Invoices
{
    public interface IInvoiceSender
    {
        InvoiceSendResult SendInvoiceDocument(IInvoiceSendModel model);
    }
}
