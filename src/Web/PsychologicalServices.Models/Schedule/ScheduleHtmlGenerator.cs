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

        public string GeneratePsychologistScheduleHtml(PsychologistScheduleModel model)
        {
            var psychologistScheduleTemplate = new PsychologistScheduleTemplate();

            psychologistScheduleTemplate.Session = new Dictionary<string, object>()
            {
                { "Model", model }
            };

            psychologistScheduleTemplate.Initialize();

            var html = psychologistScheduleTemplate.TransformText();

            return html;
        }
    }
}
