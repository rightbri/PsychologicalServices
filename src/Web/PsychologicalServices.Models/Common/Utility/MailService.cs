using log4net;
using PsychologicalServices.Models.Common.Configuration;
using System;
using System.Net;
using System.Net.Mail;

namespace PsychologicalServices.Models.Common.Utility
{
    public class MailService : IMailService
    {
        private readonly IConfigurationService _configurationService = null;
        private readonly ILog _log = null;

        public MailService(
            IConfigurationService configurationService,
            ILog log
        )
        {
            _configurationService = configurationService;
            _log = log;
        }

        public MailResult Send(MailMessage message)
        {
            var result = new MailResult();

            try
            {
                int port;
                if (!int.TryParse(_configurationService.AppSettingValue("SmtpPort"), out port))
                {
                    port = 25;
                }

                bool enableSsl;
                if (!bool.TryParse(_configurationService.AppSettingValue("SmtpSsl"), out enableSsl))
                {
                    enableSsl = false;
                }

                using (var client = new SmtpClient
                {
                    Host = _configurationService.AppSettingValue("SmtpHost"),
                    Port = port,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(
                            _configurationService.AppSettingValue("SmtpClientUsername"),
                            _configurationService.AppSettingValue("SmtpClientPassword")
                        ),
                    EnableSsl = enableSsl,
                })
                {
                    client.Send(message);

                    result.MailSent = true;
                }
            }
            catch (Exception ex)
            {
                _log.Error("Send", ex);
                result.IsError = true;
                result.ErrorDetails = ex.Message;
            }
            
            return result;
        }
    }
}
