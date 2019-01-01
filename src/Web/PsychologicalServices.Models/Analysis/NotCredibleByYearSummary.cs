using System;

namespace PsychologicalServices.Models.Analysis
{
    public class NotCredibleByYearSummary
    {
        public string Type { get; set; }

        public int Year { get; set; }

        public int Count { get; set; }

        public decimal WithReader { get; set; }

        public decimal WithoutReader { get; set; }

        public decimal WithTranslator { get; set; }

        public decimal WithoutTranslator { get; set; }

        public decimal WithReaderRate { get; set; }

        public decimal WithoutReaderRate { get; set; }

        public decimal WithTranslatorRate { get; set; }

        public decimal WithoutTranslatorRate { get; set; }
    }
}
