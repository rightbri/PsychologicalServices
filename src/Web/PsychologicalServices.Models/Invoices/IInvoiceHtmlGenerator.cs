using System;

namespace PsychologicalServices.Models.Invoices
{
    public interface IInvoiceHtmlGenerator
    {
        string GetInvoiceHtml(Invoice invoice);
    }
}
