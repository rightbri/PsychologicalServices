using log4net;
using PsychologicalServices.Models.Appointments;
using PsychologicalServices.Models.Common;
using PsychologicalServices.Models.Common.Utility;
using PsychologicalServices.Models.Companies;
using PsychologicalServices.Models.Users;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;

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
        private readonly IMailService _mailService = null;

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
            ITimezoneService timezoneService,
            IMailService mailService
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
            _mailService = mailService;
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

        public PsychologistInvoiceSendResult SendPsychologistInvoiceDocument(PsychologistInvoiceSendParameters parameters)
        {
            var result = new PsychologistInvoiceSendResult();

            var model = GetPsychologistInvoiceSendModel(parameters.InvoiceDocumentId);

            if (model.IsValid)
            {
                var from = model.CompanyEmail;
                var to = model.InvoicesContactEmail;
                var subject = "Invoice";
                var body = $"Please see the attached invoice regarding the services for {model.ClaimantName}.";

                var message = new MailMessage(from, to, subject, body);

                message.CC.Add(model.PsychologistEmail);

                message.Attachments.Add(
                    new Attachment(new MemoryStream(model.Document.Content), model.Document.FileName)
                );

                var mailResult = _mailService.Send(message);
                
                if (!string.IsNullOrWhiteSpace(mailResult.ErrorDetails))
                {
                    result.Errors.Add(mailResult.ErrorDetails);
                }

                var logId = _invoiceRepository.LogInvoiceDocumentSent(model.Document.InvoiceDocumentId, model.InvoicesContactEmail);

                result.SendLogs = _invoiceRepository.GetInvoiceDocumentSendLogs(model.Document.InvoiceDocumentId);

                result.Success = mailResult.MailSent && !mailResult.IsError;
            }
            else
            {
                result.Errors.AddRange(model.Errors);
            }
            
            return result;
        }

        private PsychologistInvoiceSendModel GetPsychologistInvoiceSendModel(int invoiceDocumentId)
        {
            var model = new PsychologistInvoiceSendModel();

            var errors = new List<string>();

            InvoiceDocument document = null;
            Invoice invoice = null;
            Appointment appointment = null;
            Claims.Claimant claimant = null;

            document = _invoiceRepository.GetInvoiceDocument(invoiceDocumentId);

            var hasDocument = null != document;

            if (!hasDocument)
            {
                errors.Add("The selected invoice document does not exist");
            }
            else
            {
                model.Document = document;

                invoice = _invoiceRepository.GetInvoiceForDocument(invoiceDocumentId);
            }

            var hasInvoice = hasDocument && null != invoice;
            var hasPsychologistInvoice = hasInvoice && null != invoice.InvoiceType && invoice.InvoiceType.InvoiceTypeId == InvoiceType.Psychologist;

            if (!hasPsychologistInvoice)
            {
                errors.Add("The selected invoice document is not from a psychologist invoice");
            }

            var hasAppointments = hasPsychologistInvoice &&
                (null != invoice.Appointments && invoice.Appointments.Any());

            if (hasAppointments)
            {
                appointment = invoice.Appointments.First().Appointment;
            }
            else
            {
                errors.Add("The selected invoice has no appointment");
            }

            var hasAssessment = hasAppointments && null != appointment && null != appointment.Assessment;

            var hasReferralSource = hasAssessment && null != appointment.Assessment.ReferralSource;

            var hasInvoiceContactEmail = hasReferralSource &&
                (null != appointment.Assessment.ReferralSource && !string.IsNullOrWhiteSpace(appointment.Assessment.ReferralSource.InvoicesContactEmail));

            if (hasInvoiceContactEmail)
            {
                model.InvoicesContactEmail = appointment.Assessment.ReferralSource.InvoicesContactEmail;
            }
            else
            {
                errors.Add("The referral source has no invoices contact email address");
            }

            var hasClaims = hasAssessment && null != appointment.Assessment.Claims && appointment.Assessment.Claims.Any();

            if (!hasClaims)
            {
                errors.Add("The related assessment has no claim/claimant");
            }
            else
            {
                claimant = appointment.Assessment.Claims.First().Claimant;
            }

            var hasClaimant = null != claimant;

            if (hasClaimant)
            {
                model.ClaimantName = $"{claimant.FirstName} {claimant.LastName}";
            }

            var hasCompanyEmail = hasAssessment && null != appointment.Assessment.Company && !string.IsNullOrWhiteSpace(appointment.Assessment.Company.Email);

            if (hasCompanyEmail)
            {
                model.CompanyEmail = appointment.Assessment.Company.Email;
            }
            else
            {
                errors.Add("The related assessment has no company email");
            }

            var hasPsychologistEmail = hasAppointments && null != appointment.Psychologist && !string.IsNullOrWhiteSpace(appointment.Psychologist.Email);

            if (hasPsychologistEmail)
            {
                model.PsychologistEmail = appointment.Psychologist.Email;
            }
            else
            {
                errors.Add("The psychologist has no email");
            }

            model.Errors = errors;

            return model;
        }
    }
}
