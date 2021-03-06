﻿using System;

namespace PsychologicalServices.Models.Schedule
{
    public interface IScheduleHtmlGenerator
    {
        string GeneratePsychometristScheduleHtml(PsychometristScheduleModel model);

        string GeneratePsychologistScheduleHtml(PsychologistScheduleModel model);
    }
}
