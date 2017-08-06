using PsychologicalServices.Models.Users;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Schedule
{
    public interface IScheduleService
    {
        IEnumerable<User> SearchPsychometristSchedules(PsychometristScheduleSearchCriteria criteria);

        IEnumerable<PsychometristScheduleSendResult> SendPsychometristSchedule(PsychometristScheduleSendParameters parameters);

        PsychologistScheduleResult GetPsychologistSchedule(PsychologistScheduleParameters parameters);
    }
}
