using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.PhoneLogs
{
    public interface IPhoneLogRepository
    {
        PhoneLog Get(int id);

        IEnumerable<PhoneLog> Get(PhoneLogSearchCriteria criteria);

        int Save(PhoneLog phoneLog);
    }
}
