using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Consulting
{
    public interface IConsultingRepository
    {
        ConsultingAgreement GetConsultingAgreement(int consultingAgreementId);

        IEnumerable<ConsultingAgreement> GetConsultingAgreements(ConsultingAgreementSearchCriteria criteria);
    }
}
