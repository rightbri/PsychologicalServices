using PsychologicalServices.Models.Users;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Invoices
{
    public interface IPsychometristInvoiceGenerator
    {
        Invoice CreateInvoice(User psychometrist, DateTimeOffset invoiceDate);

        IEnumerable<InvoiceAppointment> GetInvoiceAppointments(Invoice invoice);

        int GetInvoiceTotal(Invoice invoice);
    }
}
