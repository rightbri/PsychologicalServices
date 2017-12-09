using System;

namespace PsychologicalServices.Models.Events
{
    public class EventSearchCriteria
    {
        public string Description { get; set; }

        public string Location { get; set; }
        
        public bool? IsExpired { get; set; }

        public bool? IsActive { get; set; }
    }
}
