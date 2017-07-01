using System;

namespace PsychologicalServices.Models.Schedule
{
    public interface IScheduleHtmlGenerator
    {
        string GeneratePsychometristScheduleHtml(ScheduleModel model);
    }
}
