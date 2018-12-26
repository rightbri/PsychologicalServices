using System;

namespace PsychologicalServices.Models.Claims
{
    public class ClaimReference
    {
        public ClaimReference(
            string type,
            int id
        )
        {
            Type = type;
            Id = id;
        }

        public string Type { get; private set; }

        public int Id { get; private set; }
    }
}
