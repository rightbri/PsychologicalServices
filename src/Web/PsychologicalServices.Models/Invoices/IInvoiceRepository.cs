using PsychologicalServices.Models.Companies;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Invoices
{
    public interface IInvoiceRepository
    {
        InvoiceConfiguration GetInvoiceConfiguration(int companyId);

        PsychologistInvoiceCalculationData GetPsychologistInvoiceCalculationData(int companyId, int referralSourceId, int assessmentTypeId, int appointmentStatusId, int appointmentSequenceId);

        Invoice GetInvoice(int id);

        Invoice GetInvoiceForDocument(int invoiceDocumentId);

        InvoiceDocument GetInvoiceDocument(int invoiceDocumentId);

        InvoiceStatus GetInvoiceStatus(int id);

        InvoiceType GetInvoiceType(int id);

        InvoiceStatus GetInitialInvoiceStatus();

        IEnumerable<InvoiceStatus> GetInvoiceStatuses(bool? isActive = true);

        IEnumerable<InvoiceType> GetInvoiceTypes(bool? isActive = true);

        IEnumerable<InvoiceDocument> GetInvoiceDocuments(int invoiceId);

        IEnumerable<InvoiceDocumentSendLog> GetInvoiceDocumentSendLogs(int invoiceDocumentId);

        IEnumerable<Invoice> GetInvoices(InvoiceSearchCriteria criteria);

        int IncrementCompanyInvoiceCounter(int companyId);

        int GetInvoiceCount(int userId);
        
        int SaveInvoice(Invoice invoice);

        int SaveInvoiceConfiguration(InvoiceConfiguration invoiceConfiguration);

        decimal GetTaxRate();

        int LogInvoiceDocumentSent(int invoiceDocumentId, string recipients);
        
        IEnumerable<InvoiceableAppointmentData> GetInvoiceableAppointmentData(InvoiceableAppointmentDataSearchCriteria criteria);

        PsychometristInvoiceAmount GetPsychometristInvoiceAmount(int assessmentTypeId, int appointmentStatusId, int appointmentSequenceId, int companyId);
    }
}
