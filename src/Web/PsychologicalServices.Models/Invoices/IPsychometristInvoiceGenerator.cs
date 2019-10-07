using PsychologicalServices.Models.Users;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Invoices
{
    public interface IPsychometristInvoiceGenerator
    {
        Invoice CreateInvoice(
            User psychometrist,
            DateTimeOffset invoicePeriodBegin,
            DateTimeOffset invoicePeriodEnd
        );

        IEnumerable<InvoiceLineGroup> GetInvoiceLineGroups(Invoice invoice);

        int GetInvoiceTotal(Invoice invoice);
    }
}
