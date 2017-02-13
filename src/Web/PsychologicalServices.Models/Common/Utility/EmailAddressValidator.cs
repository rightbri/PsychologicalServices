using System;

namespace PsychologicalServices.Models.Common.Utility
{
    public class EmailAddressValidator : IEmailAddressValidator
    {
        public bool IsValid(string emailAddress)
        {
            var isValid = EmailAddressLibrary.EmailAddressValidator.Haacked(emailAddress);

            return isValid;
        }
    }
}
