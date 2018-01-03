using PsychologicalServices.Models.Appointments;
using PsychologicalServices.Models.Arbitrations;
using PsychologicalServices.Models.Claims;
using PsychologicalServices.Models.Colors;
using PsychologicalServices.Models.Companies;
using PsychologicalServices.Models.Credibilities;
using PsychologicalServices.Models.DiagnosisFoundResponses;
using PsychologicalServices.Models.Notes;
using PsychologicalServices.Models.Referrals;
using PsychologicalServices.Models.Reports;
using PsychologicalServices.Models.Users;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Assessments
{
    public class Assessment
    {
        public int AssessmentId { get; set; }

        public DateTimeOffset? MedicalFileReceivedDate { get; set; }

        public int? FileSize { get; set; }

        public string ReferralSourceFileNumber { get; set; }

        public string ReferralSourceContactEmail { get; set; }

        public bool IsLargeFile { get; set; }
        
        public AssessmentType AssessmentType { get; set; }

        public ReferralType ReferralType { get; set; }

        public ReferralSource ReferralSource { get; set; }

        public ReportStatus ReportStatus { get; set; }

        public User DocListWriter { get; set; }

        public User NotesWriter { get; set; }

        public Company Company { get; set; }

        public Note Summary { get; set; }

        public IEnumerable<Claim> Claims { get; set; }

        public IEnumerable<Appointment> Appointments { get; set; }

        public IEnumerable<MedRehab> MedRehabs { get; set; }

        public IEnumerable<AssessmentNote> AssessmentNotes { get; set; }
        
        public IEnumerable<Color> Colors { get; set; }

        public IEnumerable<Models.Attributes.AttributeValue> Attributes { get; set; }

        public IEnumerable<Report> Reports { get; set; }

        public IEnumerable<Arbitration> Arbitrations { get; set; }

        public DateTimeOffset CreateDate { get; set; }

        public User CreateUser { get; set; }

        public DateTimeOffset UpdateDate { get; set; }

        public User UpdateUser { get; set; }

        public bool? PsychologistFoundInFavorOfClaimant { get; set; }

        public Credibility NeurocognitiveCredibility { get; set; }

        public Credibility PsychologicalCredibility { get; set; }

        public DiagnosisFoundResponse DiagnosisFoundResponse { get; set; }

        public bool IsNew()
        {
            return AssessmentId == 0;
        }
    }
}
