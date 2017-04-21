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

        IEnumerable<InvoiceLine> GetInvoiceLines(Appointment appointment);

        IEnumerable<InvoiceStatus> GetInvoiceStatuses(bool? isActive = true);

        IEnumerable<InvoiceDocument> GetInvoiceDocuments(int invoiceId);

        IEnumerable<Invoice> GetInvoices(InvoiceSearchCriteria criteria);

        SaveResult<Invoice> SaveInvoice(Invoice invoice);
    }
}
