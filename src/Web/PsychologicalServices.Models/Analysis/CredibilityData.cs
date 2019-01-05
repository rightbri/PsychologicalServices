using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Analysis
{
    public class CredibilityData
    {
        public IEnumerable<CredibilityDetail> CredibilityDetailData { get; set; }

        public IEnumerable<CredibilityByYearSummary> CredibilityByYearSummaryData { get; set; }

        public IEnumerable<NotCredibleByYearSummary> NotCredibleByYearSummaryData { get; set; }

        public IEnumerable<CredibilityByPsychometristSummary> CredibilityByPsychometristSummaryData { get; set; }
    }
}
