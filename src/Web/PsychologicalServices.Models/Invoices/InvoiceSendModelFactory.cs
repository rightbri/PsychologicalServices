using System;

namespace PsychologicalServices.Models.Invoices
{
    public class InvoiceSendModelFactory : IInvoiceSendModelFactory
    {
        public IInvoiceSendModel GetInvoiceSendModel(Invoice invoice, InvoiceDocument invoiceDocument)
        {
            IInvoiceSendModel model = null;

            if (null == invoice)
            {
                throw new ArgumentNullException("invoice");
            }

            if (null == invoiceDocument)
            {
                throw new ArgumentNullException("invoiceDocument");
            }

            switch (invoice.InvoiceType.InvoiceTypeId)
            {
                case InvoiceType.Psychologist:
                    model = new PsychologistInvoiceSendModel(invoiceDocument, invoice);
                    break;
                case InvoiceType.Arbitration:
                    model = new ArbitrationInvoiceSendModel(invoiceDocument, invoice);
                    break;
                case InvoiceType.RawTestData:
                    model = new RawTestDataInvoiceSendModel(invoiceDocument, invoice);
                    break;
                default:
                    break;
            }

            return model;
        }
    }
}
