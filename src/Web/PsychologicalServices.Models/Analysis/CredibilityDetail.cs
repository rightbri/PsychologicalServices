using System;

namespace PsychologicalServices.Models.Analysis
{
    public class CredibilityDetail
    {
        public int AssessmentTypeId { get; set; }

        public string AssessmentTypeName { get; set; }

        public bool CountNeurocognitiveCredibility { get; set; }

        public bool CountPsychologicalCredibility { get; set; }

        public bool NeurocognitiveCredibilityCredible { get; set; }

        public bool NeurocognitiveCredibilityNotCredible { get; set; }

        public bool NeurocognitiveCredibilityQuestionable { get; set; }

        public bool PsychologicalCredibilityCredible { get; set; }

        public bool PsychologicalCredibilityNotCredible { get; set; }

        public bool PsychologicalCredibilityQuestionable { get; set; }

        public bool DiagnosisFoundYes { get; set; }

        public bool DiagnosisFoundNo { get; set; }

        public bool DiagnosisFoundRuleOut { get; set; }

        public bool PsychologistFoundInFavorOfClaimantYes { get; set; }

        public bool PsychologistFoundInFavorOfClaimantNo { get; set; }

        public bool PsychologistFoundInFavorOfClaimantUnknown { get; set; }
    }
}
