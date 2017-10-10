using log4net;
using PsychologicalServices.Models.Appointments;
using PsychologicalServices.Models.Common;
using PsychologicalServices.Models.Common.Utility;
using PsychologicalServices.Models.Companies;
using PsychologicalServices.Models.Users;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Invoices
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IAppointmentRepository _appointmentRepository = null;
        private readonly ICompanyRepository _companyRepository = null;
        private readonly IUserService _userService = null;
        private readonly IInvoiceRepository _invoiceRepository = null;
        private readonly IInvoiceValidator _invoiceValidator = null;
        private readonly IPsychologistInvoiceGenerator _psychologistInvoiceGenerator = null;
        private readonly IPsychometristInvoiceGenerator _psychometristInvoiceGenerator = null;
        private readonly IDate _date = null;
        private readonly ILog _log = null;
        private readonly ITimezoneService _timezoneService = null;

        public InvoiceService(
            IAppointmentRepository appointmentRepository,
            ICompanyRepository companyRepository,
            IUserService userService,
            IInvoiceRepository invoiceRepository,
            IInvoiceValidator invoiceValidator,
            IPsychologistInvoiceGenerator psychologistInvoiceGenerator,
            IPsychometristInvoiceGenerator psychometristInvoiceGenerator,
            IDate date,
            ILog log,
            ITimezoneService timezoneService
        )
        {
            _appointmentRepository = appointmentRepository;
            _companyRepository = companyRepository;
            _userService = userService;
            _invoiceRepository = invoiceRepository;
            _psychologistInvoiceGenerator = psychologistInvoiceGenerator;
            _psychometristInvoiceGenerator = psychometristInvoiceGenerator;
            _invoiceValidator = invoiceValidator;
            _date = date;
            _log = log;
            _timezoneService = timezoneService;
        }
        
        public Invoice GetInvoice(int id)
        {
            var invoice = _invoiceRepository.GetInvoice(id);

            return invoice;
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

        public InvoiceDocument GetInvoiceDocument(int invoiceDocumentId)
        {
            var invoiceDocument = _invoiceRepository.GetInvoiceDocument(invoiceDocumentId);

            return invoiceDocument;
        }

        public IEnumerable<InvoiceAppointment> GetInvoiceAppointments(Invoice invoice)
        {
            IEnumerable<InvoiceAppointment> invoiceAppointments = null;

            if (invoice.InvoiceType.InvoiceTypeId == InvoiceType.Psychologist)
            {
                invoiceAppointments = _psychologistInvoiceGenerator.GetInvoiceAppointments(invoice);
            }
            else if (invoice.InvoiceType.InvoiceTypeId == InvoiceType.Psychometrist)
            {
                invoiceAppointments = _psychometristInvoiceGenerator.GetInvoiceAppointments(invoice);
            }
            else
            {
                throw new ArgumentOutOfRangeException("invoice", $"Invoice type {invoice.InvoiceType.InvoiceTypeId} is not supported");
            }

            return invoiceAppointments;
        }
        
        public IEnumerable<InvoiceStatus> GetInvoiceStatuses(bool? isActive = true)
        {
            var invoiceStatuses = _invoiceRepository.GetInvoiceStatuses(isActive);

            return invoiceStatuses;
        }

        public IEnumerable<InvoiceType> GetInvoiceTypes(bool? isActive = true)
        {
            var invoiceTypes = _invoiceRepository.GetInvoiceTypes(isActive);

            return invoiceTypes;
        }

        public IEnumerable<InvoiceDocument> GetInvoiceDocuments(int invoiceId)
        {
            var invoiceDocuments = _invoiceRepository.GetInvoiceDocuments(invoiceId);

            return invoiceDocuments;
        }

        public IEnumerable<Invoice> GetInvoices(InvoiceSearchCriteria criteria)
        {
            var invoices = _invoiceRepository.GetInvoices(criteria);

            return invoices;
        }
        
        public IEnumerable<InvoiceableAppointmentData> GetInvoiceableAppointmentData(InvoiceableAppointmentDataSearchCriteria criteria)
        {
            var data = _invoiceRepository.GetInvoiceableAppointmentData(criteria);

            return data;
        }

        public SaveResult<Invoice> SaveInvoice(Invoice invoice)
        {
            var result = new SaveResult<Invoice>();

            try
            {
                var validation = _invoiceValidator.Validate(invoice);

                result.ValidationResult = validation;

                if (result.ValidationResult.IsValid)
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
                        default:
                            break;
                    }

                    invoice.Total = total;

                    var id = _invoiceRepository.SaveInvoice(invoice);

                    result.Item = _invoiceRepository.GetInvoice(id);
                    result.IsSaved = true;
                }
            }
            catch (Exception ex)
            {
                _log.Error("SaveInvoice", ex);
                result.IsError = true;
                result.ErrorDetails = ex.Message;
            }

            return result;
        }
    }
}
