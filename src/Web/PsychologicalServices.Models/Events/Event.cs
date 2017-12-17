using PsychologicalServices.Models.Companies;
using System;

namespace PsychologicalServices.Models.Events
{
    public class Event
    {
        public int EventId { get; set; }

        public Company Company { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public string Time { get; set; }

        public string Url { get; set; }

        public DateTimeOffset Expires { get; set; }

        public bool IsActive { get; set; }

        public bool IsNew()
        {
            return EventId == 0;
        }
    }
}
