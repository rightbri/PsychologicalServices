using log4net;
using PsychologicalServices.Models.Appointments;
using PsychologicalServices.Models.Arbitrations;
using PsychologicalServices.Models.CalendarNotes;
using PsychologicalServices.Models.Common.Utility;
using PsychologicalServices.Models.Companies;
using PsychologicalServices.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

namespace PsychologicalServices.Models.Schedule
{
    public class ScheduleService : IScheduleService
    {
        private readonly IUserRepository _userRepository = null;
        private readonly IAppointmentRepository _appointmentRepository = null;
        private readonly IArbitrationRepository _arbitrationRepository = null;
        private readonly ICalendarNoteRepository _calendarNoteRepository = null;
        private readonly ICompanyRepository _companyRepository = null;
        private readonly IScheduleHtmlGenerator _scheduleHtmlGenerator = null;
        private readonly IHtmlToPdfService _htmlToPdfService = null;
        private readonly IMailService _mailService = null;
        private readonly ITimezoneService _timezoneService = null;
        private readonly ILog _log = null;

        public ScheduleService(
            IUserRepository userRepository,
            IAppointmentRepository appointmentRepository,
            IArbitrationRepository arbitrationRepository,
            ICalendarNoteRepository calendarNoteRepository,
            ICompanyRepository companyRepository,
            IScheduleHtmlGenerator scheduleHtmlGenerator,
            IHtmlToPdfService htmlToPdfService,
            IMailService mailService,
            ITimezoneService timezoneService,
            ILog log
        )
        {
            _userRepository = userRepository;
            _appointmentRepository = appointmentRepository;
            _arbitrationRepository = arbitrationRepository;
            _calendarNoteRepository = calendarNoteRepository;
            _companyRepository = companyRepository;
            _scheduleHtmlGenerator = scheduleHtmlGenerator;
            _htmlToPdfService = htmlToPdfService;
            _mailService = mailService;
            _timezoneService = timezoneService;
            _log = log;
        }

        public IEnumerable<User> SearchPsychometristSchedules(PsychometristScheduleSearchCriteria criteria)
        {
            var users = _userRepository.GetPsychometristSchedules(criteria);

            return users;
        }

        public IEnumerable<PsychometristScheduleSendResult> SendPsychometristSchedule(PsychometristScheduleSendParameters parameters)
        {
            var users = SearchPsychometristSchedules(parameters.Criteria);

            var results = new List<PsychometristScheduleSendResult>();

            foreach (var user in users)
            {
                var result = new PsychometristScheduleSendResult
                {
                    User = user,
                };

                try
                {
                    var subject = string.Format("Assessment schedule: {0:MMMM d, yyyy} - {1:MMMM d, yyyy}", parameters.Criteria.StartDate, parameters.Criteria.EndDate);

                    var model = new PsychometristScheduleModel
                    {
                        User = user,
                        DisplayTimezoneId = user.Company.Timezone,
                        TimezoneService = _timezoneService,
                    };

                    var body = _scheduleHtmlGenerator.GeneratePsychometristScheduleHtml(model);

                    var recipients = null != parameters.Recipients && parameters.Recipients.Any()
                        ? string.Join(",", parameters.Recipients)
                        : user.Email;

                    var message = new MailMessage(user.Company.Email, recipients, subject, body)
                        {
                            IsBodyHtml = true,
                        };

                    if (!string.IsNullOrWhiteSpace(user.Company.ReplyToEmail))
                    {
                        message.ReplyToList.Add(user.Company.ReplyToEmail);
                    }

                    if (null != parameters.CourtesyCopy && parameters.CourtesyCopy.Any())
                    {
                        message.CC.Add(
                            string.Join(",", parameters.CourtesyCopy)
                        );
                    }

                    if (null != parameters.BlindCourtesyCopy && parameters.BlindCourtesyCopy.Any())
                    {
                        message.Bcc.Add(
                            string.Join(",", parameters.BlindCourtesyCopy)
                        );
                    }

                    var mailResult = _mailService.Send(message);
                    
                    result.Success = mailResult.MailSent;
                    result.IsError = mailResult.IsError;
                    result.ErrorDetails = mailResult.ErrorDetails;
                }
                catch (Exception ex)
                {
                    _log.Error(
                        string.Format(
                            "An error occurred while attempting to send a psychometrist schedule with criteria: psychometristId = {0}, companyId = {1}, startDate = {2}, endDate = {3} to recipients = {4}, cc = {5}, bcc = {6}",
                            parameters.Criteria.PsychometristId,
                            parameters.Criteria.CompanyId,
                            parameters.Criteria.StartDate,
                            parameters.Criteria.EndDate,
                            parameters.Recipients,
                            parameters.CourtesyCopy,
                            parameters.BlindCourtesyCopy
                        ), 
                    ex);

                    result.IsError = true;
                    result.ErrorDetails = ex.Message;
                }
                finally
                {
                    results.Add(result);
                }
            }

            return results;
        }

        public PsychologistScheduleResult GetPsychologistSchedule(PsychologistScheduleParameters parameters)
        {
            var psychologist = _userRepository.GetUserById(parameters.PsychologistId);

            var result = new PsychologistScheduleResult
            {
                Psychologist = psychologist,
                FromDate = parameters.FromDate.StartOfDay(psychologist.Company.Timezone),
                ToDate = parameters.ToDate.EndOfDay(psychologist.Company.Timezone),
            };

            var appointmentSearchCriteria = new AppointmentSearchCriteria
            {
                PsychologistId = parameters.PsychologistId,
                AppointmentTimeStart = result.FromDate,
                AppointmentTimeEnd = result.ToDate,
                AppointmentStatusIds = parameters.AppointmentStatusIds,
            };

            var arbitrationSearchCriteria = new ArbitrationSearchCriteria
            {
                CompanyId = result.Psychologist.Company.CompanyId,
                StartDate = result.FromDate,
                EndDate = result.ToDate,
            };

            var calendarNoteSearchCriteria = new CalendarNoteSearchCriteria
            {
                CompanyId = result.Psychologist.Company.CompanyId,
                FromDate = result.FromDate,
                ToDate = result.ToDate,
            };

            var unavailabilitySearchCriteria = new UnavailabilitySearchCriteria
            {
                CompanyId = result.Psychologist.Company.CompanyId,
                UnavailabilityStart = result.FromDate,
                UnavailabilityEnd = result.ToDate,
            };
            
            var model = new PsychologistScheduleModel
            {
                Appointments = _appointmentRepository.GetAppointments(appointmentSearchCriteria),
                Arbitrations = _arbitrationRepository.GetArbitrations(arbitrationSearchCriteria),
                CalendarNotes = _calendarNoteRepository.GetCalendarNotes(calendarNoteSearchCriteria),
                UsersWithUnavailability = _userRepository.GetUsersWithUnavailability(unavailabilitySearchCriteria),
                Psychologist = _userRepository.GetUserById(parameters.PsychologistId),
                FromDate = result.FromDate,
                ToDate = result.ToDate,
                DisplayTimezoneId = result.Psychologist.Company.Timezone,
                TimezoneService = _timezoneService,
            };

            var html = _scheduleHtmlGenerator.GeneratePsychologistScheduleHtml(model);

            var htmlToPdfParameters = new HtmlToPdfParameters
            {
                MarginTop = 5,
                MarginRight = 5,
                MarginBottom = 5,
                MarginLeft = 5,
                PageSize = "Legal",
            };

            result.Content = _htmlToPdfService.GetPdf(html, htmlToPdfParameters);

            return result;
        }
    }
}
