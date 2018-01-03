using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.DiagnosisFoundResponses
{
    public class DiagnosisFoundResponseService : IDiagnosisFoundResponseService
    {
        private readonly IDiagnosisFoundResponseRepository _diagnosisFoundResponseRepository = null;

        public DiagnosisFoundResponseService(
            IDiagnosisFoundResponseRepository diagnosisFoundResponseRepository
        )
        {
            _diagnosisFoundResponseRepository = diagnosisFoundResponseRepository;
        }

        public IEnumerable<DiagnosisFoundResponse> GetDiagnosisFoundResponses(bool? isActive = true)
        {
            var diagnosisFoundResponses = _diagnosisFoundResponseRepository.GetDiagnosisFoundResponses(isActive);

            return diagnosisFoundResponses;
        }
    }
}
