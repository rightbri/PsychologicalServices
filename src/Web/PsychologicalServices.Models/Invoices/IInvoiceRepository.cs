using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Invoices
{
    public interface IInvoiceRepository
    {
        IEnumerable<InvoiceAmount> GetInvoiceAmounts();

        void SaveInvoiceAmounts(IEnumerable<InvoiceAmount> invoiceAmounts);
    }
}
