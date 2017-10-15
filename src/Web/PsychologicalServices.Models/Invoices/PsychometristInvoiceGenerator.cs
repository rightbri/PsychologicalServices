using System;
using System.Collections.Generic;
using System.Linq;
using PsychologicalServices.Models.Appointments;
using PsychologicalServices.Models.Users;
using PsychologicalServices.Models.Common.Utility;

namespace PsychologicalServices.Models.Invoices
{
    public class PsychometristInvoiceGenerator : IPsychometristInvoiceGenerator
    {
        private readonly IAppointmentRepository _appointmentRepository = null;
        private readonly IInvoiceRepository _invoiceRepository = null;
        private readonly IUserRepository _userRepository = null;
        private readonly IDate _dateService = null;

        public PsychometristInvoiceGenerator(
            IAppointmentRepository appointmentRepository,
            IInvoiceRepository invoiceRepository,
            IUserRepository userRepository,
            IDate dateService
        )
        {
            _appointmentRepository = appointmentRepository;
            _invoiceRepository = invoiceRepository;
            _userRepository = userRepository;
            _dateService = dateService;
        }

        public Invoice CreateInvoice(User psychometrist, DateTimeOffset invoiceDate)
        {
            var invoiceSearchCriteria = new InvoiceSearchCriteria
            {
                PayableToId = psychometrist.UserId,
                InvoiceTypeId = InvoiceType.Psychometrist,
                InvoiceDate = invoiceDate,
            };

            if (_invoiceRepository.GetInvoices(invoiceSearchCriteria).Any())
            {
                throw new InvalidOperationException("An invoice already exists for this psychometrist and invoice date.");
            }
            
            var invoiceType = new InvoiceType
            {
                InvoiceTypeId = InvoiceType.Psychometrist,
            };

            var appointments = GetInvoiceableAppointments(psychometrist.UserId, invoiceDate, psychometrist.Company.Timezone)
                .Select(appointment =>
                {
                    return new InvoiceAppointment
                    {
                        Appointment = appointment,
                        Lines = GetInvoiceLines(appointment),
                    };
                });

            var invoice = new Invoice
            {
                Identifier = string.Format("{0}-{1:00#}", psychometrist.UserId, _invoiceRepository.GetInvoiceCount(psychometrist.UserId) + 1),
                InvoiceDate = invoiceDate,
                InvoiceRate = 1.0m,
                InvoiceStatus = _invoiceRepository.GetInitialInvoiceStatus(),
                InvoiceType = invoiceType,
                PayableTo = psychometrist,
                Appointments = appointments,
                TaxRate = _invoiceRepository.GetTaxRate(),
                UpdateDate = _dateService.UtcNow,
            };

            invoice.Total = GetInvoiceTotal(invoice);

            return invoice;
        }

        public IEnumerable<InvoiceAppointment> GetInvoiceAppointments(Invoice invoice)
        {
            if (invoice.InvoiceType.InvoiceTypeId != InvoiceType.Psychometrist)
            {
                throw new InvalidOperationException("Invoice must be a psychometrist invoice");
            }

            var psychometrist = _userRepository.GetUserById(invoice.PayableTo.UserId);

            var appointments = GetInvoiceableAppointments(psychometrist.UserId, invoice.InvoiceDate, psychometrist.Company.Timezone)
                .Select(appointment => new InvoiceAppointment
                {
                    Appointment = appointment,
                    Lines = GetInvoiceLines(appointment)
                        .Union(invoice.Appointments
                            .Where(invoiceAppointment => invoiceAppointment.Appointment.AppointmentId == appointment.AppointmentId)
                            .SelectMany(invoiceAppointment => invoiceAppointment.Lines.Where(line => line.IsCustom))
                        ),
                });

            return appointments.ToList();
        }

        public int GetInvoiceTotal(Invoice invoice)
        {
            var total = 0.0m;

            var subtotal = 0.0m;

            foreach (var invoiceAppointment in invoice.Appointments)
            {
                var appointmentTotal = invoiceAppointment.Lines.Select(line => line.Amount).Sum();

                var appointment = invoiceAppointment.Appointment;

                subtotal += appointmentTotal;
            }

            total = subtotal * (1 + invoice.TaxRate);

            return Convert.ToInt32(total);
        }

        private List<InvoiceLine> GetInvoiceLines(Appointment appointment)
        {
            var lines = new List<InvoiceLine>();

            var description = 
                string.Format("{0} Assessment - {1}{2}",
                    appointment.Assessment.AssessmentType.Description,
                    appointment.AppointmentStatus.Name,
                    appointment.IsCompletion ? " (Completion)" : ""
                );

            var amount = GetAppointmentAmount(appointment);
            
            lines.Add(new InvoiceLine { Amount = amount, Description = description });

            var psychometrist = _userRepository.GetUserById(appointment.Psychometrist.UserId);

            var travelFee = psychometrist.TravelFees
                .Where(fee =>
                    fee.City.CityId == appointment.Location.City.CityId &&
                    fee.Amount > 0)
                .SingleOrDefault();
            if (null != travelFee)
            {
                lines.Add(
                    new InvoiceLine { Amount = travelFee.Amount, Description = string.Format("Travel to {0}", appointment.Location.City.Name) }
                );
            }

            return lines;
        }

        private int GetAppointmentAmount(
            Appointment appointment
        )
        {
            var appointmentSequenceId =
                appointment.IsCompletion
                ? AppointmentSequence.Subsequent
                : AppointmentSequence.First;
            
            var psychometristInvoiceAmount = _invoiceRepository.GetPsychometristInvoiceAmount(
                appointment.Assessment.AssessmentType.AssessmentTypeId,
                appointment.AppointmentStatus.AppointmentStatusId,
                appointmentSequenceId,
                appointment.Assessment.Company.CompanyId
            );

            return null != psychometristInvoiceAmount
                ? psychometristInvoiceAmount.InvoiceAmount
                : 0;
        }

        private IEnumerable<Appointment> GetInvoiceableAppointments(int psychometristId, DateTimeOffset invoiceDate, string timezone)
        {
            var criteria = new AppointmentSearchCriteria
            {
                PsychometristId = psychometristId,
                AppointmentTimeStart = invoiceDate.StartOfMonth(timezone),
                AppointmentTimeEnd = invoiceDate.EndOfMonth(timezone),
            };

            var appointments = _appointmentRepository.GetAppointmentsForPsychometristInvoice(criteria)
                .Where(appointment => appointment.AppointmentStatus.CanInvoice);

            return appointments;
        }
    }
}
