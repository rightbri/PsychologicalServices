using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Rights
{
    public interface IRightRepository
    {
        IEnumerable<Right> GetRights(bool? isActive = true);
    }
}
