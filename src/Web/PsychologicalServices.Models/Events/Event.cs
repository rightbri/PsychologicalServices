using System;

namespace PsychologicalServices.Models.Events
{
    public class Event
    {
        public int EventId { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public string Time { get; set; }

        public string Url { get; set; }

        public DateTimeOffset? Date { get; set; }

        public bool IsActive { get; set; }
    }
}
