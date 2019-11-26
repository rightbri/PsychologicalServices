using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Consulting
{
    public class ConsultingService : IConsultingService
    {
        private readonly IConsultingRepository _repository = null;

        public ConsultingService(
            IConsultingRepository repository
        )
        {
            _repository = repository;
        }

        public IEnumerable<ConsultingAgreement> GetConsultingAgreements(ConsultingAgreementSearchCriteria criteria)
        {
            var consultingAgreements = _repository.GetConsultingAgreements(criteria);

            return consultingAgreements;
        }
    }
}
