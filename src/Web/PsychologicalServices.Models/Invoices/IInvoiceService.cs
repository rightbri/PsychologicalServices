﻿using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Invoices
{
    public interface IInvoiceService
    {
        Invoice GetInvoice(int id);

        Invoice NewInvoice(int appointmentId);

        IEnumerable<InvoiceStatus> GetInvoiceStatuses(bool? isActive = true);

        IEnumerable<Invoice> GetInvoices(InvoiceSearchCriteria criteria);

        SaveResult<Invoice> SaveInvoice(Invoice invoice);
    }
}
