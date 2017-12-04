using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Credibilities
{
    public interface ICredibilityService
    {
        IEnumerable<Credibility> GetCredibilities(bool? isActive = true);
    }
}
