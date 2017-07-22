using log4net;
using PsychologicalServices.Models.Common.Utility;
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
        private readonly IScheduleHtmlGenerator _scheduleHtmlGenerator = null;
        private readonly IMailService _mailService = null;
        private readonly ITimezoneService _timezoneService = null;
        private readonly ILog _log = null;

        public ScheduleService(
            IUserRepository userRepository,
            IScheduleHtmlGenerator scheduleHtmlGenerator,
            IMailService mailService,
            ITimezoneService timezoneService,
            ILog log
        )
        {
            _userRepository = userRepository;
            _scheduleHtmlGenerator = scheduleHtmlGenerator;
            _mailService = mailService;
            _timezoneService = timezoneService;
            _log = log;
        }

        public IEnumerable<User> Search(ScheduleSearchCriteria criteria)
        {
            var users = _userRepository.GetPsychometristSchedules(criteria);

            return users;
        }

        public IEnumerable<SendScheduleResult> SendSchedule(ScheduleSendParameters parameters)
        {
            var users = Search(parameters.Criteria);

            var results = new List<SendScheduleResult>();

            foreach (var user in users)
            {
                var result = new SendScheduleResult
                {
                    User = user,
                };

                try
                {
                    var subject = string.Format("Assessment schedule: {0:MMMM d, yyyy} - {1:MMMM d, yyyy}", parameters.Criteria.StartDate, parameters.Criteria.EndDate);

                    var model = new ScheduleModel
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
    }
}
