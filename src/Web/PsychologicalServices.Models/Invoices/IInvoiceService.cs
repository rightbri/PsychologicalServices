using PsychologicalServices.Models.Appointments;
using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Invoices
{
    public interface IInvoiceService
    {
        Invoice GetInvoice(int id);

        Invoice NewInvoice(Appointment appointment);

        InvoiceDocument GetInvoiceDocument(int invoiceDocumentId);

        IEnumerable<InvoiceAppointment> GetInvoiceAppointments(Invoice invoice);

        IEnumerable<InvoiceStatus> GetInvoiceStatuses(bool? isActive = true);

        IEnumerable<InvoiceType> GetInvoiceTypes(bool? isActive = true);

        IEnumerable<InvoiceDocument> GetInvoiceDocuments(int invoiceId);

        IEnumerable<Invoice> GetInvoices(InvoiceSearchCriteria criteria);

        IEnumerable<Invoice> CreatePsychometristInvoices(int companyId, DateTime invoiceMonth);

        SaveResult<Invoice> SaveInvoice(Invoice invoice);
    }
}
