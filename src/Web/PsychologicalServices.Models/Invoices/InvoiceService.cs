using log4net;
using PsychologicalServices.Models.Appointments;
using PsychologicalServices.Models.Assessments;
using PsychologicalServices.Models.Common;
using PsychologicalServices.Models.Common.Utility;
using PsychologicalServices.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Invoices
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IAppointmentRepository _appointmentRepository = null;
        private readonly IUserService _userService = null;
        private readonly IInvoiceRepository _invoiceRepository = null;
        private readonly IInvoiceValidator _invoiceValidator = null;
        private readonly IInvoiceGenerator _invoiceGenerator = null;
        private readonly IMailService _mailService = null;
        private readonly IDate _date = null;
        private readonly ILog _log = null;

        public InvoiceService(
            IAppointmentRepository appointmentRepository,
            IUserService userService,
            IInvoiceRepository invoiceRepository,
            IInvoiceValidator invoiceValidator,
            IInvoiceGenerator invoiceGenerator,
            IMailService mailService,
            IDate date,
            ILog log
        )
        {
            _appointmentRepository = appointmentRepository;
            _userService = userService;
            _invoiceRepository = invoiceRepository;
            _invoiceValidator = invoiceValidator;
            _invoiceGenerator = invoiceGenerator;
            _mailService = mailService;
            _date = date;
            _log = log;
        }
        
        public Invoice GetInvoice(int id)
        {
            var invoice = _invoiceRepository.GetInvoice(id);

            return invoice;
        }

        public Invoice NewInvoice(Appointment appointment)
        {
            var invoice = _invoiceGenerator.CreatePsychologistInvoice(appointment);

            return invoice;
        }

        public InvoiceDocument GetInvoiceDocument(int invoiceDocumentId)
        {
            var invoiceDocument = _invoiceRepository.GetInvoiceDocument(invoiceDocumentId);

            return invoiceDocument;
        }

        public IEnumerable<InvoiceAppointment> GetInvoiceAppointments(Invoice invoice)
        {
            var invoiceAppointments = _invoiceGenerator.GetInvoiceAppointments(invoice);

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

        public IEnumerable<Invoice> CreatePsychometristInvoices(int companyId, DateTime invoiceMonth)
        {
            var users = _userService.GetPsychometrists(companyId);

            var lastDayOfMonth = new DateTime(invoiceMonth.Year, invoiceMonth.Month, 1).AddMonths(1).AddDays(-1);

            var invoices = new List<Invoice>();

            invoices.AddRange(
                GetInvoices(
                new InvoiceSearchCriteria
                {
                    InvoiceTypeId = InvoiceType.Psychometrist,
                    InvoiceDate = lastDayOfMonth,
                    CompanyId = companyId,
                })
            );

            var appointments = _appointmentRepository.GetAppointments(
                new AppointmentSearchCriteria
                {
                    CompanyId = companyId,
                    AppointmentTimeStart = new DateTime(invoiceMonth.Year, invoiceMonth.Month, 1),
                    AppointmentTimeEnd = new DateTime(invoiceMonth.Year, invoiceMonth.Month, 1).AddMonths(1).AddSeconds(-1),
                });

            //generate new invoices for psychometrists that don't already have an invoice but have invoiceable appointments for the month
            var usersWithoutInvoices = users.Where(user =>
                appointments.Any(appointment =>
                    appointment.AppointmentStatus.CanInvoice &&
                    appointment.Psychometrist.UserId == user.UserId
                ) &&
                !invoices.Any(invoice => invoice.PayableTo.UserId == user.UserId));

            foreach (var user in usersWithoutInvoices)
            {
                var invoice = _invoiceGenerator.CreatePsychometristInvoice(user, lastDayOfMonth);

                var invoiceId = _invoiceRepository.SaveInvoice(invoice);

                invoices.Add(
                    _invoiceRepository.GetInvoice(invoiceId)
                );
            }

            return invoices;
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
                    invoice.Total = _invoiceGenerator.GetInvoiceTotal(invoice);

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
