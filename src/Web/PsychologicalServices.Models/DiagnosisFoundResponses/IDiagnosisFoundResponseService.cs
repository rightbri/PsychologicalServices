using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.DiagnosisFoundResponses
{
    public interface IDiagnosisFoundResponseService
    {
        IEnumerable<DiagnosisFoundResponse> GetDiagnosisFoundResponses(bool? isActive = true);
    }
}
