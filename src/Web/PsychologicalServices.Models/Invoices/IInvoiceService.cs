using PsychologicalServices.Models.Common;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Invoices
{
    public interface IInvoiceService
    {
        Invoice GetInvoice(int id);

        Invoice CreatePsychologistInvoice(int appointmentId);

        Invoice CreatePsychometristInvoice(PsychometristInvoiceCreationParameters parameters);

        InvoiceDocument GetInvoiceDocument(int invoiceDocumentId);

        PsychologistInvoiceSendResult SendPsychologistInvoiceDocument(PsychologistInvoiceSendParameters parameters);

        InvoiceConfiguration GetInvoiceConfiguration(int companyId);

        IEnumerable<InvoiceAppointment> GetInvoiceAppointments(Invoice invoice);

        IEnumerable<InvoiceStatus> GetInvoiceStatuses(bool? isActive = true);

        IEnumerable<InvoiceType> GetInvoiceTypes(bool? isActive = true);

        IEnumerable<InvoiceDocument> GetInvoiceDocuments(int invoiceId);

        IEnumerable<Invoice> GetInvoices(InvoiceSearchCriteria criteria);

        IEnumerable<InvoiceableAppointmentData> GetInvoiceableAppointmentData(InvoiceableAppointmentDataSearchCriteria criteria);

        SaveResult<Invoice> SaveInvoice(Invoice invoice);

        SaveResult<InvoiceConfiguration> SaveInvoiceConfiguration(InvoiceConfiguration invoiceConfiguration);
    }
}
