using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Invoices
{
    public class InvoiceHtmlGenerator : IInvoiceHtmlGenerator
    {
        public string GetInvoiceHtml(Invoice invoice)
        {
            var template = new InvoiceTemplate();

            template.Session = new Dictionary<string, object>()
            {
                { "Model", invoice }
            };

            template.Initialize();

            return template.TransformText();
        }
    }
}
