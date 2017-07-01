using System;
using System.Net.Mail;

namespace PsychologicalServices.Models.Common.Utility
{
    public interface IMailService
    {
        MailResult Send(MailMessage message);
    }
}
