using PsychologicalServices.Models.Users;
using System;

namespace PsychologicalServices.Models.Schedule
{
    public interface IScheduleHtmlGenerator
    {
        string GeneratePsychometristScheduleHtml(User user);
    }
}
