using System;

namespace PsychologicalServices.Models.Invoices
{
    public interface IInvoiceSendModelFactory
    {
        IInvoiceSendModel GetInvoiceSendModel(Invoice invoice, InvoiceDocument invoiceDocument);
    }
}
