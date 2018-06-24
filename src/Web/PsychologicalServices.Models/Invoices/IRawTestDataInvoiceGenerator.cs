using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Invoices
{
    public interface IRawTestDataInvoiceGenerator
    {
        Invoice CreateInvoice(RawTestData.RawTestData rawTestData);

        IEnumerable<InvoiceLineGroup> GetInvoiceLineGroups(Invoice invoice);

        int GetInvoiceTotal(Invoice invoice);
    }
}
