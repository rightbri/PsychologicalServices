
namespace PsychologicalServices.Models.Invoices
{
    public class PsychometristInvoiceAmount
    {
        public int AssessmentTypeId { get; set; }

        public int AppointmentStatusId { get; set; }

        public int AppointmentSequenceId { get; set; }

        public int CompanyId { get; set; }

        public int InvoiceAmount { get; set; }
    }
}
