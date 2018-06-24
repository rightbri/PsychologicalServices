using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Invoices
{
    public class InvoiceHtmlGenerator : IInvoiceHtmlGenerator
    {
        public string GetInvoiceHtml(Invoice invoice)
        {
            string html = null;

            switch (invoice.InvoiceType.InvoiceTypeId)
            {
                case InvoiceType.Psychologist:
                    var psychologistTemplate = 
                        new PsychologistInvoiceTemplate();

                    psychologistTemplate.Session = new Dictionary<string, object>()
                    {
                        { "Model", invoice }
                    };

                    psychologistTemplate.Initialize();

                    html = psychologistTemplate.TransformText();

                    break;
                case InvoiceType.Psychometrist:
                    var psychometristTemplate = 
                        new PsychometristInvoiceTemplate();

                    psychometristTemplate.Session = new Dictionary<string, object>()
                    {
                        { "Model", invoice }
                    };

                    psychometristTemplate.Initialize();

                    html = psychometristTemplate.TransformText();

                    break;
                case InvoiceType.Arbitration:
                    var arbitrationTemplate = new ArbitrationInvoiceTemplate();

                    arbitrationTemplate.Session = new Dictionary<string, object>()
                    {
                        { "Model", invoice }
                    };

                    arbitrationTemplate.Initialize();

                    html = arbitrationTemplate.TransformText();

                    break;
                case InvoiceType.RawTestData:
                    var rawTestDataTemplate = new RawTestDataInvoiceTemplate();

                    rawTestDataTemplate.Session = new Dictionary<string, object>()
                    {
                        { "Model", invoice }
                    };

                    rawTestDataTemplate.Initialize();

                    html = rawTestDataTemplate.TransformText();

                    break;
                default:
                    throw new NotImplementedException(
                        string.Format("Invoice HTML Generator not implemented for invoice type {0}", invoice.InvoiceType.InvoiceTypeId)
                    );
            }

            return html;
        }
    }
}
