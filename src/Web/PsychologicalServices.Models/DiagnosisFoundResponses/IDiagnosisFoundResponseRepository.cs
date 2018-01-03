using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.DiagnosisFoundResponses
{
    public interface IDiagnosisFoundResponseRepository
    {
        IEnumerable<DiagnosisFoundResponse> GetDiagnosisFoundResponses(bool? isActive = true);
    }
}
