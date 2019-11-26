using PsychologicalServices.Models.Common;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Invoices
{
    public interface IInvoiceService
    {
        Invoice GetInvoice(int id);

        Invoice CreatePsychologistInvoice(int appointmentId);

        Invoice CreatePsychometristInvoice(PsychometristInvoiceCreationParameters parameters);

        Invoice CreateArbitrationInvoice(ArbitrationInvoiceCreationParameters parameters);

        Invoice CreateRawTestDataInvoice(RawTestDataInvoiceCreationParameters parameters);

        Invoice CreateConsultingInvoice(ConsultingInvoiceCreationParameters parameters);

        InvoiceDocument GetInvoiceDocument(int invoiceDocumentId);

        InvoiceSendResult SendInvoiceDocument(InvoiceSendParameters parameters);

        InvoiceConfiguration GetInvoiceConfiguration(int companyId);

        IEnumerable<InvoiceLineGroup> GetInvoiceLineGroups(Invoice invoice);

        IEnumerable<InvoiceStatus> GetInvoiceStatuses(bool? isActive = true);

        IEnumerable<InvoiceType> GetInvoiceTypes(bool? isActive = true);

        IEnumerable<InvoiceDocument> GetInvoiceDocuments(int invoiceId);

        IEnumerable<Invoice> GetInvoices(InvoiceSearchCriteria criteria);

        IEnumerable<InvoiceableAppointmentData> GetInvoiceableAppointmentData(InvoiceableAppointmentDataSearchCriteria criteria);

        IEnumerable<InvoiceableArbitrationData> GetInvoiceableArbitrationData(InvoiceableArbitrationDataSearchCriteria criteria);

        IEnumerable<InvoiceableRawTestDataData> GetInvoiceableRawTestDataData(InvoiceableRawTestDataSearchCriteria criteria);

        IEnumerable<InvoiceableConsultingAgreementData> GetInvoiceableConsultingAgreementData(InvoiceableConsultingAgreementSearchCriteria criteria);

        SaveResult<Invoice> SaveInvoice(Invoice invoice);

        SaveResult<InvoiceConfiguration> SaveInvoiceConfiguration(InvoiceConfiguration invoiceConfiguration);
    }
}
