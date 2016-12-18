using System;

namespace PsychologicalServices.Models.Rights
{
    public class Right
    {
        public int RightId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }
    }
}
