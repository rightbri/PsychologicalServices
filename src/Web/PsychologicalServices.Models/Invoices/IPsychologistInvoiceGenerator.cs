using PsychologicalServices.Models.Appointments;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Invoices
{
    public interface IPsychologistInvoiceGenerator
    {
        Invoice CreateInvoice(Appointment appointment);

        IEnumerable<InvoiceAppointment> GetInvoiceAppointments(Invoice invoice);

        int GetInvoiceTotal(Invoice invoice);
    }
}
