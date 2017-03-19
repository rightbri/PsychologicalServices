using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Rights
{
    public interface IRightService
    {
        IEnumerable<Right> GetRights(bool? isActive = true);
    }
}
