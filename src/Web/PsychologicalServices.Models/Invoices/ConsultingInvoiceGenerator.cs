using System;
using System.Collections.Generic;
using System.Linq;
using PsychologicalServices.Models.Common.Utility;
using PsychologicalServices.Models.Consulting;

namespace PsychologicalServices.Models.Invoices
{
    public class ConsultingInvoiceGenerator : IConsultingInvoiceGenerator
    {
        private readonly IInvoiceRepository _invoiceRepository = null;
        private readonly IConsultingRepository _repository = null;
        private readonly ITimezoneService _timezoneService = null;
        private readonly IDate _dateService = null;

        public ConsultingInvoiceGenerator(
            IInvoiceRepository invoiceRepository,
            IConsultingRepository repository,
            ITimezoneService timezoneService,
            IDate dateService
        )
        {
            _invoiceRepository = invoiceRepository;
            _repository = repository;
            _timezoneService = timezoneService;
            _dateService = dateService;
        }

        public Invoice CreateInvoice(
            ConsultingAgreement consultingAgreement,
            int year,
            int month
        )
        {
            var lineGroups = new List<InvoiceLineGroup>
            {
                {
                    new InvoiceLineGroup
                    {
                        Description = !string.IsNullOrWhiteSpace(consultingAgreement.BillReferenceNumber)
                            ? $"Consulting Services - P.O. {consultingAgreement.BillReferenceNumber}"
                            : "Consulting Services",
                        Sort = 1,
                        Lines = new List<InvoiceLine>
                        {
                            new InvoiceLine
                            {
                                Description = $"Services rendered on...",
                                Amount = 0,
                                IsCustom = true,
                            }
                        },
                        ConsultingAgreement = consultingAgreement,
                    }
                }
            };

            var timezoneInfo = _timezoneService.GetTimeZoneInfo(consultingAgreement.Company.Timezone);

            var invoiceDate = _dateService.UtcNow;
            var invoicePeriodBeginDate = _timezoneService.GetDateTimeOffset(new DateTime(year, month, 1), timezoneInfo);
            var invoicePeriodEndDate = _timezoneService.GetDateTimeOffset(new DateTime(year, month, 1).AddMonths(1).AddSeconds(-1), timezoneInfo);

            var invoice = new Invoice
            {
                Identifier = $"{invoiceDate:yy-MM-}{_invoiceRepository.IncrementCompanyInvoiceCounter(consultingAgreement.Company.CompanyId):00#}",
                InvoiceDate = invoiceDate,
                InvoicePeriodBegin = invoicePeriodBeginDate,
                InvoicePeriodEnd = invoicePeriodEndDate,
                InvoiceStatus = _invoiceRepository.GetInitialInvoiceStatus(),
                InvoiceType = new InvoiceType
                {
                    InvoiceTypeId = InvoiceType.Consulting,
                },
                PayableTo = consultingAgreement.Psychologist,
                LineGroups = lineGroups,
                TaxRate = _invoiceRepository.GetTaxRate(),
                UpdateDate = _dateService.UtcNow,
            };

            invoice.Total = GetInvoiceTotal(invoice);

            return invoice;
        }

        public IEnumerable<InvoiceLineGroup> GetInvoiceLineGroups(Invoice invoice)
        {
            if (invoice.InvoiceType.InvoiceTypeId != InvoiceType.Consulting)
            {

                throw new InvalidOperationException("Invoice must be a consulting invoice");
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
