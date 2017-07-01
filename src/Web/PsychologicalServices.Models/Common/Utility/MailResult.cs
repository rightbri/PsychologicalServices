using System;

namespace PsychologicalServices.Models.Common.Utility
{
    public class MailResult
    {
        public bool MailSent { get; set; }

        public bool IsError { get; set; }

        public string ErrorDetails { get; set; }
    }
}
