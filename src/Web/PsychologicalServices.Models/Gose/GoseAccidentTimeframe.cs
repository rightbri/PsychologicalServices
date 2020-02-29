using System;

namespace PsychologicalServices.Models.Gose
{
    public class GoseAccidentTimeframe
    {
        public int GoseAccidentTimeframeId { get; set; }

        public string Description { get; set; }

        public int Months { get; set; }

        public bool Basic { get; set; }

        public bool Intermediate { get; set; }

        public bool Advanced { get; set; }
    }
}
