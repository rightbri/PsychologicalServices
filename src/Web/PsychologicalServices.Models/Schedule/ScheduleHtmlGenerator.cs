using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Schedule
{
    public class ScheduleHtmlGenerator : IScheduleHtmlGenerator
    {
        public string GeneratePsychometristScheduleHtml(ScheduleModel model)
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
    }
}
