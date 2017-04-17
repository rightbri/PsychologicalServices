using System;

namespace PsychologicalServices.Models.Assessments
{
    public class AssessmentSearchCriteria
    {
        public int? AssessmentId { get; set; }

        public int? AssesmentTypeId { get; set; }

        public int? ReferralTypeId { get; set; }

        public int? ReferralSourceId { get; set; }

        public int? ReportStatusId { get; set; }

        public int? ClaimantId { get; set; }

        public int? DocListWriterId { get; set; }

        public int? NotesWriterId { get; set; }

        public DateTime? MedicalFileReceivedDateStart { get; set; }

        public DateTime? MedicalFileReceivedDateEnd { get; set; }

        public int? FileSizeMin { get; set; }

        public int? FileSizeMax { get; set; }

        public string ReferralSourceContactEmail { get; set; }

        public int? CompanyId { get; set; }
    }
}
