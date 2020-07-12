using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.PhoneLogs
{
    public interface IPhoneLogService
    {
        PhoneLog Get(int id);

        IEnumerable<PhoneLog> Get(PhoneLogSearchCriteria criteria);

        SaveResult<PhoneLog> Save(PhoneLog phoneLog);

        DeleteResult Delete(int id);
    }
}
