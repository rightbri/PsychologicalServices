using System;
using System.Linq;

namespace PsychologicalServices.Models.Invoices
{
    public static class InvoiceExtensions
    {
        public static string ToPrimaryReportsInvoiceLineDescription(this Assessments.Assessment assessment)
        {
            var primaryReports = assessment.Reports.Where(report => !report.IsAdditional);

            if (!primaryReports.Any(report => report.IssuesInDispute.Any()))
            {
                if (primaryReports.Count() > 1)
                {
                    return $"{assessment.AssessmentType.Description} assessment - {primaryReports.Count()} reports addressing {string.Join(", ", primaryReports.SelectMany(report => report.IssuesInDispute).Select(issueInDispute => issueInDispute.Name))}";
                }
                else
                {
                    return $"{assessment.AssessmentType.Description} assessment addressing {string.Join(", ", primaryReports.SelectMany(report => report.IssuesInDispute).Select(issueInDispute => issueInDispute.Name))}";
                }
            }
            else
            {
                if (primaryReports.Count() > 1)
                {
                    return $"{assessment.AssessmentType.Description} assessment - {primaryReports.Count()} reports";
                }
                else
                {
                    return $"{assessment.AssessmentType.Description} assessment";
                }
            }
        }

        public static string ToExtraReportsInvoiceLineDescriptions(this Reports.Report report, string assessmentTypeDescription)
        {
            if (!report.IsAdditional)
            {
                return "";
            }

            return report.IssuesInDispute.Any()
                ? $"{assessmentTypeDescription} assessment - extra report addressing {string.Join(", ", report.IssuesInDispute.Select(issueInDispute => issueInDispute.Name))}"
                : $"{assessmentTypeDescription} assessment - extra report";
        }

        public static string ToCompletionFeeInvoiceLineDescription(this Appointments.Appointment appointment)
        {
            var baseDescription = $"Completion {appointment.Assessment.AssessmentType.Description} assessment";

            return appointment.AppointmentStatus.ClaimantSeen
                ? baseDescription
                : $"{baseDescription} - {appointment.AppointmentStatus.Name}";
        }

        public static bool IsDiscountedRate(this PsychologistInvoiceCalculationData data)
        {
            return data.InvoiceRate < 1.0m;
        }

        public static string ToInvoiceLineGroupDescription(this Appointments.Appointment appointment)
        {
            var claimant = appointment.Assessment.Claimant;
            
            return $@"{appointment.AppointmentTime.ToString("MMMM")} {appointment.AppointmentTime.Day}, {appointment.AppointmentTime.Year}, {appointment.Assessment.AssessmentType.Description} Assessment in {appointment.Location.City.Name} for {appointment.Assessment.ReferralSource.Name}/{claimant?.FirstName} {claimant?.LastName}";
        }
    }
}
