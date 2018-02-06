using System;
using System.Collections.Generic;
using PsychologicalServices.Models.Assessments;

namespace PsychologicalServices.Models.Arbitrations
{
    public class ArbitrationService : IArbitrationService
    {
        public readonly IAssessmentRepository _assessmentRepository = null;
        public readonly IArbitrationRepository _arbitrationRepository = null;

        public ArbitrationService(
            IAssessmentRepository assessmentRepository,
            IArbitrationRepository arbitrationRepository
        )
        {
            _assessmentRepository = assessmentRepository;
            _arbitrationRepository = arbitrationRepository;
        }

        public Arbitration GetArbitration(int arbitrationId)
        {
            var arbitration = _arbitrationRepository.GetArbitration(arbitrationId);

            return arbitration;
        }

        public Arbitration GetNewArbitration(int assessmentId)
        {
            var assessment = _assessmentRepository.GetAssessment(assessmentId);

            return new Arbitration
            {
            };
        }

        public IEnumerable<Arbitration> GetArbitrations(ArbitrationSearchCriteria criteria)
        {
            var arbitrations = _arbitrationRepository.GetArbitrations(criteria);

            return arbitrations;
        }
    }
}
