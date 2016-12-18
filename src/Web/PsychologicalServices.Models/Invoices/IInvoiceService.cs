using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Invoices
{
    public interface IInvoiceService
    {
        IEnumerable<InvoiceAmount> GetInvoiceAmounts();

        SaveResult<IEnumerable<InvoiceAmount>> SaveInvoiceAmounts(IEnumerable<InvoiceAmount> invoiceAmounts);
    }
}
