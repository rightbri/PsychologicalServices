using System;

namespace PsychologicalServices.Models.Invoices
{
    public class InvoiceableAppointmentData
    {
        public int Year { get; set; }

        public int Month { get; set; }

        public int AssessmentId { get; set; }

        public int AppointmentId { get; set; }

        public DateTimeOffset AppointmentTime { get; set; }

        public string AppointmentStatus { get; set; }

        public string PayableTo { get; set; }

        public int PayableToId { get; set; }

        public int InvoiceTypeId { get; set; }

        public string AssessmentType { get; set; }

        public string ReferralSource { get; set; }

        public string Claimant { get; set; }
    }
}
