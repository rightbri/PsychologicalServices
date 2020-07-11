using System;

namespace PsychologicalServices.Models.PhoneLogs
{
    public class PhoneLogNotFoundException : Exception
    {
        private const string MessageFormat = "Phone Log {0} was not found";

        public PhoneLogNotFoundException(int phoneLogId)
            : base(string.Format(MessageFormat, phoneLogId))
        {
        }
    }
}
