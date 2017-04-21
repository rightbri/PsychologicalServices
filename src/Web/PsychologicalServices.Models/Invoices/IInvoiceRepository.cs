using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Invoices
{
    public interface IInvoiceRepository
    {
        Invoice GetInvoice(int id);

        InvoiceDocument GetInvoiceDocument(int invoiceDocumentId);

        InvoiceStatus GetInvoiceStatus(int id);

        InvoiceStatus GetInitialInvoiceStatus();

        IEnumerable<InvoiceStatus> GetInvoiceStatuses(bool? isActive = true);

        IEnumerable<InvoiceDocument> GetInvoiceDocuments(int invoiceId);

        IEnumerable<Invoice> GetInvoices(InvoiceSearchCriteria criteria);

        int GetInvoiceCount(int year, int month);
        
        int SaveInvoice(Invoice invoice);

        void SaveInvoiceDocument(Invoice invoice);

        decimal GetTaxRate();

        decimal GetAdditionalReportAmount(int referralSourceId, int reportTypeId);
    }
}
