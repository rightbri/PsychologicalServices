using System;
using System.Collections.Generic;
using System.Linq;
using PsychologicalServices.Models.Common.Utility;

namespace PsychologicalServices.Models.Invoices
{
    public class RawTestDataInvoiceGenerator : IRawTestDataInvoiceGenerator
    {
        private readonly IInvoiceRepository _invoiceRepository = null;
        private readonly IDate _dateService = null;

        public RawTestDataInvoiceGenerator(
            IInvoiceRepository invoiceRepository,
            IDate dateService
        )
        {
            _invoiceRepository = invoiceRepository;
            _dateService = dateService;
        }

        public Invoice CreateInvoice(RawTestData.RawTestData rawTestData)
        {
            var lineGroups = new List<InvoiceLineGroup>
            {
                {
                    new InvoiceLineGroup
                    {
                        Description = "Data Request",
                        Sort = 1,
                        Lines = new List<InvoiceLine>
                        {
                            new InvoiceLine
                            {
                                Description = "Services rendered on ...",
                                Amount = 25000,
                                IsCustom = true,
                            }
                        },
                        RawTestData = rawTestData,
                    }
                }
            };

            var invoiceDate = _dateService.UtcNow;
            var invoicePeriodDate = rawTestData.DataSentDate?? invoiceDate;

            var invoice = new Invoice
            {
                Identifier = $"{invoiceDate:yy-MM-}{_invoiceRepository.IncrementCompanyInvoiceCounter(rawTestData.Company.CompanyId):00#}",
                InvoiceDate = invoiceDate,
                InvoicePeriodBegin = invoicePeriodDate,
                InvoicePeriodEnd = invoicePeriodDate,
                InvoiceStatus = _invoiceRepository.GetInitialInvoiceStatus(),
                InvoiceType = new InvoiceType
                {
                    InvoiceTypeId = InvoiceType.RawTestData,
                },
                PayableTo = rawTestData.Psychologist,
                LineGroups = lineGroups,
                TaxRate = _invoiceRepository.GetTaxRate(),
                UpdateDate = _dateService.UtcNow,
            };

            invoice.Total = GetInvoiceTotal(invoice);
            
            return invoice;
        }

        public IEnumerable<InvoiceLineGroup> GetInvoiceLineGroups(Invoice invoice)
        {
            if (invoice.InvoiceType.InvoiceTypeId != InvoiceType.RawTestData)
            {
                throw new InvalidOperationException("Invoice must be a raw test data invoice");
            }

            return invoice.LineGroups;
        }

        public int GetInvoiceTotal(Invoice invoice)
        {
            var total = 0.0m;

            var subtotal = 0.0m;

            foreach (var lineGroup in invoice.LineGroups)
            {
                var lineGroupTotal = lineGroup.Lines.Select(line => line.Amount).Sum();

                subtotal += lineGroupTotal;
            }

            total = subtotal * (1 + invoice.TaxRate);

            return Convert.ToInt32(total);
        }
    }
}
