using PsychologicalServices.Models.Appointments;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Invoices
{
    public interface IInvoiceGenerator
    {
        Invoice CreateInvoice(Appointment appointment);

        IEnumerable<InvoiceLine> GetInvoiceLines(Appointment appointment);

        decimal GetInvoiceTotal(Invoice invoice);
    }
}
