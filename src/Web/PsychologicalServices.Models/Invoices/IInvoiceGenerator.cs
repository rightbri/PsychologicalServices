using PsychologicalServices.Models.Appointments;
using PsychologicalServices.Models.Users;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Invoices
{
    public interface IInvoiceGenerator
    {
        Invoice CreatePsychologistInvoice(Appointment appointment);

        Invoice CreatePsychometristInvoice(User psychometrist, DateTime invoiceDate);

        IEnumerable<InvoiceAppointment> GetInvoiceAppointments(Invoice invoice);

        int GetInvoiceTotal(Invoice invoice);
    }
}
