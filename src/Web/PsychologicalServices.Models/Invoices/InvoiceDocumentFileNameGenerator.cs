using PsychologicalServices.Models.Appointments;
using PsychologicalServices.Models.Arbitrations;
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
                if (invoice.LineGroups.Any(lineGroup => null != lineGroup.Appointment))
                {
                    var appointment = _appointmentRepository.GetAppointment(invoice.LineGroups.First(lineGroup => null != lineGroup.Appointment).Appointment.AppointmentId);

                    var claimant = appointment.Assessment.Claims.Any()
                        ? appointment.Assessment.Claims.First().Claimant
                        : null;

                    var assessmentType = appointment.Assessment.AssessmentType;

                    var referralSource = appointment.Assessment.ReferralSource;

                    return $"{claimant?.LastName}, {claimant?.FirstName} {assessmentType.Name} INVOICE {referralSource.Name} {appointment.AppointmentTime:MMM yyyy}";
                }
            }
            else if (invoice.InvoiceType.InvoiceTypeId == InvoiceType.Psychometrist)
            {
                var psychometrist = _userRepository.GetUserById(invoice.PayableTo.UserId);

                return $"{invoice.InvoiceDate:MMM yyyy} {psychometrist.FirstName} INVOICE";
            }
            else if (invoice.InvoiceType.InvoiceTypeId == InvoiceType.Arbitration)
            {
                var arbitration = invoice.LineGroups.First(lineGroup => null != lineGroup.Arbitration).Arbitration;

                return $"{arbitration.Claimant.LastName} {arbitration.Claimant.FirstName} INVOICE {invoice.InvoiceDate:MMM dd yyyy}";
            }
            else if (invoice.InvoiceType.InvoiceTypeId == InvoiceType.RawTestData)
            {
                var rawTestData = invoice.LineGroups.First(lineGroup => null != lineGroup.RawTestData).RawTestData;

                return $"{rawTestData.Claimant.LastName} {rawTestData.Claimant.FirstName} INVOICE {invoice.InvoiceDate:MMM dd yyyy}";
            }

            return $"{invoice.Identifier} INVOICE {invoice.InvoiceDate:MMM dd yyyy}";
        }
    }
}
