using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Claims
{
    public interface IClaimantParameters
    {
        int MinAge { get; }

        int MaxAge { get; }

        IEnumerable<Gender> ValidGenders { get; }
    }
}
