using PsychologicalServices.Models.Arbitrations;
using PsychologicalServices.Models.Users;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Invoices
{
    public interface IArbitrationInvoiceGenerator
    {
        Invoice CreateInvoice(Arbitration arbitration);

        IEnumerable<InvoiceLineGroup> GetInvoiceLineGroups(Invoice invoice);

        int GetInvoiceTotal(Invoice invoice);
    }
}
