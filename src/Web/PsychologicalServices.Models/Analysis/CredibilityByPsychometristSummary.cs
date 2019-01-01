using System;

namespace PsychologicalServices.Models.Analysis
{
    public class CredibilityByPsychometristSummary
    {
        public string Type { get; set; }

        public int Year { get; set; }

        public string Psychometrist { get; set; }

        public decimal Credible { get; set; }

        public decimal NotCredible { get; set; }

        public decimal Questionable { get; set; }

        public decimal CredibleRate { get; set; }

        public decimal NotCredibleRate { get; set; }

        public decimal QuestionableRate { get; set; }
    }
}
