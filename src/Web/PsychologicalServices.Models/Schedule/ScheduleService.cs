﻿using log4net;
using PsychologicalServices.Models.Common.Utility;
using PsychologicalServices.Models.Users;
using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace PsychologicalServices.Models.Schedule
{
    public class ScheduleService : IScheduleService
    {
        private readonly IUserRepository _userRepository = null;
        private readonly IScheduleHtmlGenerator _scheduleHtmlGenerator = null;
        private readonly IMailService _mailService = null;
        private readonly ILog _log = null;

        public ScheduleService(
            IUserRepository userRepository,
            IScheduleHtmlGenerator scheduleHtmlGenerator,
            IMailService mailService,
            ILog log
        )
        {
            _userRepository = userRepository;
            _scheduleHtmlGenerator = scheduleHtmlGenerator;
            _mailService = mailService;
            _log = log;
        }

        public IEnumerable<User> Search(ScheduleSearchCriteria criteria)
        {
            var users = _userRepository.GetPsychometristSchedules(criteria);

            return users;
        }

        public IEnumerable<SendScheduleResult> SendSchedule(ScheduleSearchCriteria criteria)
        {
            var users = Search(criteria);

            var results = new List<SendScheduleResult>();

            foreach (var user in users)
            {
                var result = new SendScheduleResult
                {
                    User = user,
                };

                try
                {
                    var subject = string.Format("Assessment schedule: {0:MMMM d, yyyy} - {1:MMMM d, yyyy}", criteria.StartDate, criteria.EndDate);
                    
                    var body = _scheduleHtmlGenerator.GeneratePsychometristScheduleHtml(user);

                    var message = new MailMessage(user.Company.Email, user.Email, subject, body)
                        {
                            IsBodyHtml = true,
                        };

                    _mailService.Send(message);

                    result.Success = true;
                }
                catch (Exception ex)
                {
                    _log.Error(
                        string.Format("An error occurred while attempting to send a psychometrist schedule with criteria: psychometristId = {0}, companyId = {1}, startDate = {2}, endDate = {3}", criteria.PsychometristId, criteria.CompanyId, criteria.StartDate, criteria.EndDate), 
                        ex);
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
