using PsychologicalServices.Models.Addresses;
using PsychologicalServices.Models.Appointments;
using PsychologicalServices.Models.Assessments;
using PsychologicalServices.Models.Notes;
using PsychologicalServices.Models.Reports;
using PsychologicalServices.Models.Users;
using System;

namespace PsychologicalServices.Models.Companies
{
    public class Company
    {
        public int CompanyId { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public Address Address { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

        public string ReplyToEmail { get; set; }

        public string TaxId { get; set; }

        public string Timezone { get; set; }

        public TimeSpan NewAppointmentTime { get; set; }

        public Address NewAppointmentLocation { get; set; }

        public User NewAppointmentPsychologist { get; set; }

        public User NewAppointmentPsychometrist { get; set; }

        public AppointmentStatus NewAppointmentStatus { get; set; }

        public AssessmentType NewAssessmentAssessmentType { get; set; }

        public ReportStatus NewAssessmentReportStatus { get; set; }

        public Note NewAssessmentSummary { get; set; }

        public bool IsNew()
        {
            return CompanyId == 0;
        }
    }
}
