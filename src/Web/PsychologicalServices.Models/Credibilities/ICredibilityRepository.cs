using System.Collections.Generic;

namespace PsychologicalServices.Models.Credibilities
{
    public interface ICredibilityRepository
    {
        IEnumerable<Credibility> GetCredibilities(bool? isActive = true);
    }
}
