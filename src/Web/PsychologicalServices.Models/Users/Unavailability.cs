using System;

namespace PsychologicalServices.Models.Users
{
    public class Unavailability
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public User User { get; set; }
    }
}
