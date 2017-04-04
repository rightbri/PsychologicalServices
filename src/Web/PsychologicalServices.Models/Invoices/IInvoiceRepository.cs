using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Invoices
{
    public interface IInvoiceRepository
    {
        Invoice GetInvoice(int id);

        InvoiceStatus GetInvoiceStatus(int id);

        IEnumerable<InvoiceStatus> GetInvoiceStatuses(bool? isActive = true);

        IEnumerable<Invoice> GetInvoices(InvoiceSearchCriteria criteria);

        IEnumerable<InvoiceAmount> GetInvoiceAmounts(int companyId, int referralSourceId);

        int GetInvoiceCount(int year, int month);

        int SaveInvoice(Invoice invoice);
    }
}
