using PsychologicalServices.Models.Appointments;
using PsychologicalServices.Models.Assessments;

namespace PsychologicalServices.Models.Invoices
{
    public class PsychometristInvoiceAmount
    {
        public AssessmentType AssessmentType { get; set; }

        public AppointmentStatus AppointmentStatus { get; set; }

        public AppointmentSequence AppointmentSequence { get; set; }

        public int InvoiceAmount { get; set; }
    }
}
