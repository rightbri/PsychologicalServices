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

        public IEnumerable<InvoiceAmount> GetInvoiceAmounts()
        {
            var invoiceAmounts = _invoiceRepository.GetInvoiceAmounts();

            return invoiceAmounts;
        }

        public SaveResult<IEnumerable<InvoiceAmount>> SaveInvoiceAmounts(IEnumerable<InvoiceAmount> invoiceAmounts)
        {
            var result = new SaveResult<IEnumerable<InvoiceAmount>>();

            try
            {
                _invoiceRepository.SaveInvoiceAmounts(invoiceAmounts);

                result.Item = _invoiceRepository.GetInvoiceAmounts();
                result.IsSaved = true;
            }
            catch (Exception ex)
            {
                //TODO: log errors
                result.IsError = true;
                result.ErrorDetails = ex.Message;
            }

            return result;
        }
    }
}
