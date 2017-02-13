using System;

namespace PsychologicalServices.Models.Common.Utility
{
    public interface IEmailAddressValidator
    {
        bool IsValid(string emailAddress);
    }
}
