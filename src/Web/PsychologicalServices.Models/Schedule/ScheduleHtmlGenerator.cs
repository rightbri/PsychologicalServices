using PsychologicalServices.Models.Users;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Schedule
{
    public class ScheduleHtmlGenerator : IScheduleHtmlGenerator
    {
        public string GeneratePsychometristScheduleHtml(User user)
        {
            var psychometristScheduleTemplate =
                        new PsychometristScheduleTemplate();

            psychometristScheduleTemplate.Session = new Dictionary<string, object>()
                    {
                        { "Model", user }
                    };

            psychometristScheduleTemplate.Initialize();

            var html = psychometristScheduleTemplate.TransformText();

            return html;
        }
    }
}
