using System;
using System.Net.Mail;

namespace PsychologicalServices.Models.Common.Utility
{
    public interface IMailService
    {
        void Send(MailMessage message);
    }
}
