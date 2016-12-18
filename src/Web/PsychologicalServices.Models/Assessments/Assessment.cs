using PsychologicalServices.Models.Appointments;
using PsychologicalServices.Models.Claims;
using PsychologicalServices.Models.Companies;
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

        public int AssessmentTypeId { get; set; }

        public int ReferralTypeId { get; set; }

        public int ReferralSourceId { get; set; }

        public int ReportStatusId { get; set; }

        public int? DocListWriterId { get; set; }

        public int? NotesWriterId { get; set; }

        public DateTime? MedicalFileReceivedDate { get; set; }

        public int? FileSize { get; set; }

        public string ReferralSourceContactEmail { get; set; }

        public int CompanyId { get; set; }

        public bool Deleted { get; set; }

        public AssessmentType AssessmentType { get; set; }

        public ReferralType ReferralType { get; set; }

        public ReferralSource ReferralSource { get; set; }

        public ReportStatus ReportStatus { get; set; }

        public User DocListWriter { get; set; }

        public User NotesWriter { get; set; }

        public Company Company { get; set; }

        public IEnumerable<Claim> Claims { get; set; }

        public IEnumerable<Appointment> Appointments { get; set; }

        public IEnumerable<IssueInDispute> IssuesInDispute { get; set; }

        public bool IsNew()
        {
            return AssessmentId == 0;
        }
    }
}
