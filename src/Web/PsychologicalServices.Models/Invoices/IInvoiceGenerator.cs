﻿using PsychologicalServices.Models.Appointments;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Invoices
{
    public interface IInvoiceGenerator
    {
        Invoice CreatePsychologistInvoice(Appointment appointment);

        IEnumerable<InvoiceAppointment> GetInvoiceAppointments(Invoice invoice);

        int GetInvoiceTotal(Invoice invoice);
    }
}
