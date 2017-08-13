using System;

namespace PsychologicalServices.Models.Users
{
    public class Unavailability
    {
        public int Id { get; set; }

        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset EndDate { get; set; }

        public User User { get; set; }
    }
}
