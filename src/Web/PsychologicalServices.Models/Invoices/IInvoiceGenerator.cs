using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Invoices
{
    public interface IInvoiceGenerator
    {
        Invoice CreatePsychologistInvoice(int appointmentId);

        Invoice CreatePsychometristInvoice(PsychometristInvoiceCreationParameters parameters);

        Invoice CreateArbitrationInvoice(ArbitrationInvoiceCreationParameters parameters);

        Invoice CreateRawTestDataInvoice(RawTestDataInvoiceCreationParameters parameters);

        IEnumerable<InvoiceLineGroup> GetInvoiceLineGroups(Invoice invoice);

        int GetInvoiceTotal(Invoice invoice);
    }
}
