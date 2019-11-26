using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Consulting
{
    public interface IConsultingService
    {
        IEnumerable<ConsultingAgreement> GetConsultingAgreements(ConsultingAgreementSearchCriteria criteria);
    }
}
