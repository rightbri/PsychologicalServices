using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Schedule
{
    public class ScheduleHtmlGenerator : IScheduleHtmlGenerator
    {
        public string GeneratePsychometristScheduleHtml(PsychometristScheduleModel model)
        {
            var psychometristScheduleTemplate =
                        new PsychometristScheduleTemplate();

            psychometristScheduleTemplate.Session = new Dictionary<string, object>()
                    {
                        { "Model", model }
                    };

            psychometristScheduleTemplate.Initialize();

            var html = psychometristScheduleTemplate.TransformText();

            return html;
        }

        public string GenerateWeekScheduleHtml(WeekScheduleModel model)
        {
            var weekScheduleTemplate = new WeekScheduleTemplate();

            weekScheduleTemplate.Session = new Dictionary<string, object>()
            {
                { "Model", model }
            };

            weekScheduleTemplate.Initialize();

            var html = weekScheduleTemplate.TransformText();

            return html;
        }
    }
}
