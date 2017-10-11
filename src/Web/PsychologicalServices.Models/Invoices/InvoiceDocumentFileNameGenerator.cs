using PsychologicalServices.Models.Appointments;
using PsychologicalServices.Models.Users;
using System.Linq;

namespace PsychologicalServices.Models.Invoices
{
    public class InvoiceDocumentFileNameGenerator : IInvoiceDocumentFileNameGenerator
    {
        private readonly IAppointmentRepository _appointmentRepository = null;
        private readonly IUserRepository _userRepository = null;

        public InvoiceDocumentFileNameGenerator(
            IAppointmentRepository appointmentRepository,
            IUserRepository userRepository
        )
        {
            _appointmentRepository = appointmentRepository;
            _userRepository = userRepository;
        }

        public string GetFileName(Invoice invoice)
        {
            if (invoice.InvoiceType.InvoiceTypeId == InvoiceType.Psychologist)
            {
                //Last, First AssessmentType INVOICE ReferralSource Month Year

                if (invoice.Appointments.Any())
                {
                    var appointment = _appointmentRepository.GetAppointment(invoice.Appointments.First().Appointment.AppointmentId);

                    var claimant = appointment.Assessment.Claims.Any()
                        ? appointment.Assessment.Claims.First().Claimant
                        : null;

                    var assessmentType = appointment.Assessment.AssessmentType;

                    var referralSource = appointment.Assessment.ReferralSource;

                    return $"{claimant?.LastName}, {claimant?.FirstName} {assessmentType.Name} INVOICE {referralSource.Name} {appointment.AppointmentTime.ToString("MMM")} {appointment.AppointmentTime.Year}";
                }
            }
            else if (invoice.InvoiceType.InvoiceTypeId == InvoiceType.Psychometrist)
            {
                var psychometrist = _userRepository.GetUserById(invoice.PayableTo.UserId);

                return $"{invoice.InvoiceDate.ToString("MMM")} {invoice.InvoiceDate.Year} {psychometrist.FirstName} INVOICE";
            }

            return $"{invoice.Identifier} INVOICE {invoice.InvoiceDate.ToString("MMM dd YYYY")}";
        }
    }
}
