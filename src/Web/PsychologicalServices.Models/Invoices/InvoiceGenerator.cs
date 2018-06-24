using PsychologicalServices.Models.Appointments;
using PsychologicalServices.Models.Arbitrations;
using PsychologicalServices.Models.Assessments;
using PsychologicalServices.Models.Common.Utility;
using PsychologicalServices.Models.Companies;
using PsychologicalServices.Models.RawTestData;
using PsychologicalServices.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalServices.Models.Invoices
{
    public class InvoiceGenerator : IInvoiceGenerator
    {
        private readonly IAppointmentRepository _appointmentRepository = null;
        private readonly IAssessmentRepository _assessmentRepository = null;
        private readonly IArbitrationRepository _arbitrationRepository = null;
        private readonly IRawTestDataRepository _rawTestDataRepository = null;
        private readonly IPsychologistInvoiceGenerator _psychologistInvoiceGenerator = null;
        private readonly IPsychometristInvoiceGenerator _psychometristInvoiceGenerator = null;
        private readonly IArbitrationInvoiceGenerator _arbitrationInvoiceGenerator = null;
        private readonly IRawTestDataInvoiceGenerator _rawTestDataInvoiceGenerator = null;
        private readonly IUserService _userService = null;
        private readonly IInvoiceRepository _invoiceRepository = null;
        private readonly ICompanyRepository _companyRepository = null;
        private readonly ITimezoneService _timezoneService = null;

        public InvoiceGenerator(
            IAppointmentRepository appointmentRepository,
            IAssessmentRepository assessmentRepository,
            IArbitrationRepository arbitrationRepository,
            IRawTestDataRepository rawTestDataRepository,
            IPsychologistInvoiceGenerator psychologistInvoiceGenerator,
            IPsychometristInvoiceGenerator psychometristInvoiceGenerator,
            IArbitrationInvoiceGenerator arbitrationInvoiceGenerator,
            IRawTestDataInvoiceGenerator rawTestDataInvoiceGenerator,
            IUserService userService,
            IInvoiceRepository invoiceRepository,
            ICompanyRepository companyRepository,
            ITimezoneService timezoneService
        )
        {
            _appointmentRepository = appointmentRepository;
            _assessmentRepository = assessmentRepository;
            _arbitrationRepository = arbitrationRepository;
            _rawTestDataRepository = rawTestDataRepository;
            _psychologistInvoiceGenerator = psychologistInvoiceGenerator;
            _psychometristInvoiceGenerator = psychometristInvoiceGenerator;
            _arbitrationInvoiceGenerator = arbitrationInvoiceGenerator;
            _rawTestDataInvoiceGenerator = rawTestDataInvoiceGenerator;
            _userService = userService;
            _invoiceRepository = invoiceRepository;
            _companyRepository = companyRepository;
            _timezoneService = timezoneService;
        }

        public Invoice CreatePsychologistInvoice(int appointmentId)
        {
            var appointment = _appointmentRepository.GetAppointmentForPsychologistInvoice(appointmentId);

            var invoice = _psychologistInvoiceGenerator.CreateInvoice(appointment);

            var invoiceId = _invoiceRepository.SaveInvoice(invoice);

            return _invoiceRepository.GetInvoice(invoiceId);
        }

        public Invoice CreatePsychometristInvoice(PsychometristInvoiceCreationParameters parameters)
        {
            var user = _userService.GetUserById(parameters.PsychometristId);

            var company = _companyRepository.GetCompany(parameters.CompanyId);

            var invoiceDate = new DateTimeOffset(parameters.Year, parameters.Month, 1, 0, 0, 0, _timezoneService.GetTimeZoneInfo(company.Timezone).BaseUtcOffset).EndOfMonth(company.Timezone);

            var invoice = _psychometristInvoiceGenerator.CreateInvoice(user, invoiceDate);

            var invoiceId = _invoiceRepository.SaveInvoice(invoice);

            return _invoiceRepository.GetInvoice(invoiceId);
        }

        public Invoice CreateArbitrationInvoice(ArbitrationInvoiceCreationParameters parameters)
        {
            var arbitration = _arbitrationRepository.GetArbitration(parameters.ArbitrationId);

            if (null == arbitration)
            {
                throw new ArgumentOutOfRangeException("parameters.ArbitrationId", $"Cannot find arbitration with id {parameters.ArbitrationId}");
            }

            var invoice = _arbitrationInvoiceGenerator.CreateInvoice(arbitration);

            var invoiceId = _invoiceRepository.SaveInvoice(invoice);

            return _invoiceRepository.GetInvoice(invoiceId);
        }

        public Invoice CreateRawTestDataInvoice(RawTestDataInvoiceCreationParameters parameters)
        {
            var rawTestData = _rawTestDataRepository.GetRawTestData(parameters.RawTestDataId);

            if (null == rawTestData)
            {
                throw new ArgumentOutOfRangeException("parameters.RawTestDataId", $"Cannot find raw test data with id {parameters.RawTestDataId}");
            }

            var invoice = _rawTestDataInvoiceGenerator.CreateInvoice(rawTestData);

            var invoiceId = _invoiceRepository.SaveInvoice(invoice);

            return _invoiceRepository.GetInvoice(invoiceId);
        }

        public IEnumerable<InvoiceLineGroup> GetInvoiceLineGroups(Invoice invoice)
        {
            IEnumerable<InvoiceLineGroup> invoiceLineGroups = null;

            if (invoice.InvoiceType.InvoiceTypeId == InvoiceType.Psychologist)
            {
                invoiceLineGroups = _psychologistInvoiceGenerator.GetInvoiceLineGroups(invoice);
            }
            else if (invoice.InvoiceType.InvoiceTypeId == InvoiceType.Psychometrist)
            {
                invoiceLineGroups = _psychometristInvoiceGenerator.GetInvoiceLineGroups(invoice);
            }
            else if (invoice.InvoiceType.InvoiceTypeId == InvoiceType.Arbitration)
            {
                invoiceLineGroups = _arbitrationInvoiceGenerator.GetInvoiceLineGroups(invoice);
            }
            else if (invoice.InvoiceType.InvoiceTypeId == InvoiceType.RawTestData)
            {
                invoiceLineGroups = _rawTestDataInvoiceGenerator.GetInvoiceLineGroups(invoice);
            }
            else
            {
                throw new ArgumentOutOfRangeException("invoice", $"Invoice type {invoice.InvoiceType.InvoiceTypeId} is not supported");
            }

            return invoiceLineGroups;
        }

        public int GetInvoiceTotal(Invoice invoice)
        {
            var total = 0;

            switch (invoice.InvoiceType.InvoiceTypeId)
            {
                case InvoiceType.Psychometrist:
                    total = _psychometristInvoiceGenerator.GetInvoiceTotal(invoice);
                    break;
                case InvoiceType.Psychologist:
                    total = _psychologistInvoiceGenerator.GetInvoiceTotal(invoice);
                    break;
                case InvoiceType.Arbitration:
                    total = _arbitrationInvoiceGenerator.GetInvoiceTotal(invoice);
                    break;
                case InvoiceType.RawTestData:
                    total = _rawTestDataInvoiceGenerator.GetInvoiceTotal(invoice);
                    break;
                default:
                    break;
            }

            return total;
        }
    }
}
