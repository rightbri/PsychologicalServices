using PsychologicalServices.Models.Appointments;
using System;

namespace PsychologicalServices.Models.Invoices
{
    public interface IInvoiceGenerator
    {
        Invoice CreateInvoice(Appointment appointment);
    }
}
