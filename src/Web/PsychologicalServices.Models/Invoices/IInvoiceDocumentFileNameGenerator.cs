using System;

namespace PsychologicalServices.Models.Invoices
{
    public interface IInvoiceDocumentFileNameGenerator
    {
        string GetFileName(Invoice invoice);
    }
}
