using PsychologicalServices.Models.Users;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Schedule
{
    public interface IScheduleService
    {
        IEnumerable<User> Search(ScheduleSearchCriteria criteria);

        IEnumerable<SendScheduleResult> SendSchedule(ScheduleSendParameters parameters);
    }
}
