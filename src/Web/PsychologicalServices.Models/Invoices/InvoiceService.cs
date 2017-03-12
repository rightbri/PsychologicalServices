using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Invoices
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository = null;

        public InvoiceService(
            IInvoiceRepository invoiceRepository
        )
        {
            _invoiceRepository = invoiceRepository;
        }

    }
}
