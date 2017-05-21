using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Invoices
{
    public interface IInvoiceRepository
    {
        Invoice GetInvoice(int id);

        InvoiceDocument GetInvoiceDocument(int invoiceDocumentId);

        InvoiceStatus GetInvoiceStatus(int id);

        InvoiceType GetInvoiceType(int id);

        InvoiceStatus GetInitialInvoiceStatus();

        IEnumerable<InvoiceStatus> GetInvoiceStatuses(bool? isActive = true);

        IEnumerable<InvoiceType> GetInvoiceTypes(bool? isActive = true);

        IEnumerable<InvoiceDocument> GetInvoiceDocuments(int invoiceId);

        IEnumerable<Invoice> GetInvoices(InvoiceSearchCriteria criteria);

        int GetInvoiceCount(int year, int month);

        int GetInvoiceCount(int userId);
        
        int SaveInvoice(Invoice invoice);

        decimal GetTaxRate();

        decimal GetAdditionalReportAmount(int referralSourceId, int reportTypeId);
    }
}
