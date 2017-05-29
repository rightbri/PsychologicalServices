using PsychologicalServices.Models.Common.Configuration;
using System;
using System.Net;
using System.Net.Mail;

namespace PsychologicalServices.Models.Common.Utility
{
    public class MailService : IMailService
    {
        private readonly IConfigurationService _configurationService = null;

        public MailService(
            IConfigurationService configurationService
        )
        {
            _configurationService = configurationService;
        }

        public void Send(MailMessage message)
        {
            int port;
            if (!int.TryParse(_configurationService.AppSettingValue("SmtpPort"), out port))
            {
                port = 25;
            }

            using (var client = new SmtpClient
                {
                    Host = _configurationService.AppSettingValue("SmtpHost"),
                    Port = port,
                    Credentials = new NetworkCredential(
                        _configurationService.AppSettingValue("SmtpClientUsername"),
                        _configurationService.AppSettingValue("SmtpClientPassword")
                    ),
                    UseDefaultCredentials = false,
                    //EnableSsl = true,
                })
            {
                //client.Port = 587;// 465;//

                client.Send(message);
            }
        }
    }
}
