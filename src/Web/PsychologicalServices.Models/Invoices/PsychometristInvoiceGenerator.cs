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

        public Invoice CreateInvoice(
            User psychometrist,
            DateTimeOffset invoicePeriodBegin,
            DateTimeOffset invoicePeriodEnd
        )
        {
            var invoiceSearchCriteria = new InvoiceSearchCriteria
            {
                CompanyId = psychometrist.Company.CompanyId,
                PayableToId = psychometrist.UserId,
                InvoiceTypeId = InvoiceType.Psychometrist,
                InvoiceDate = invoicePeriodEnd,
            };

            if (_invoiceRepository.GetInvoices(invoiceSearchCriteria).Any())
            {
                throw new InvalidOperationException("An invoice already exists for this psychometrist and invoice date.");
            }
            
            var invoiceType = new InvoiceType
            {
                InvoiceTypeId = InvoiceType.Psychometrist,
            };

            var lineGroups = GetInvoiceableAppointments(
                    psychometrist.UserId,
                    invoicePeriodBegin,
                    invoicePeriodEnd,
                    psychometrist.Company.Timezone
                )
                .OrderBy(appointment => appointment.AppointmentTime)
                .Select((appointment, index) =>
                {
                    return new InvoiceLineGroup
                    {
                        Description = appointment.ToInvoiceLineGroupDescription(),
                        Sort = index + 1,
                        Lines = GetInvoiceLines(appointment),
                        Appointment = appointment,
                    };
                });

            var invoice = new Invoice
            {
                Identifier = string.Format("{0}-{1:00#}", psychometrist.UserId, _invoiceRepository.GetInvoiceCount(psychometrist.UserId) + 1),
                InvoiceDate = invoicePeriodEnd,
                InvoicePeriodBegin = invoicePeriodBegin,
                InvoicePeriodEnd = invoicePeriodEnd,
                InvoiceStatus = _invoiceRepository.GetInitialInvoiceStatus(),
                InvoiceType = invoiceType,
                PayableTo = psychometrist,
                LineGroups = lineGroups,
                TaxRate = _invoiceRepository.GetTaxRate(),
                UpdateDate = _dateService.UtcNow,
            };

            invoice.Total = GetInvoiceTotal(invoice);

            return invoice;
        }

        public IEnumerable<InvoiceLineGroup> GetInvoiceLineGroups(Invoice invoice)
        {
            if (invoice.InvoiceType.InvoiceTypeId != InvoiceType.Psychometrist)
            {
                throw new InvalidOperationException("Invoice must be a psychometrist invoice");
            }

            var psychometrist = _userRepository.GetUserById(invoice.PayableTo.UserId);

            var lineGroups = GetInvoiceableAppointments(psychometrist.UserId, invoice.InvoicePeriodBegin, invoice.InvoicePeriodEnd, psychometrist.Company.Timezone)
                .OrderBy(appointment => appointment.AppointmentTime)
                .Select((appointment, index) =>
                {
                    var matchingLineGroup = invoice.LineGroups.SingleOrDefault(lg => null != lg.Appointment && lg.Appointment.AppointmentId == appointment.AppointmentId);
                    var matchingLineGroupId = null != matchingLineGroup ? matchingLineGroup.InvoiceLineGroupId : 0;
                    
                    var lineGroup = new InvoiceLineGroup
                    {
                        InvoiceLineGroupId = matchingLineGroupId,
                        Description = appointment.ToInvoiceLineGroupDescription(),
                        Sort = index + 1,
                        Appointment = appointment,
                        Lines = GetInvoiceLines(appointment)
                            .Union(
                                invoice.LineGroups
                                    .Where(lg => lg.Appointment.AppointmentId == appointment.AppointmentId)
                                    .SelectMany(lg => lg.Lines.Where(line => line.IsCustom))
                            ),
                    };

                    return lineGroup;
                })
                .Union(
                    invoice.LineGroups.Where(lineGroup => null == lineGroup.Appointment)
                );

            return lineGroups.ToList();
        }

        public int GetInvoiceTotal(Invoice invoice)
        {
            var total = 0.0m;

            var subtotal = 0.0m;

            foreach (var lineGroup in invoice.LineGroups)
            {
                var lineGroupTotal = lineGroup.Lines.Select(line => line.Amount).Sum();

                subtotal += lineGroupTotal;
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

        private IEnumerable<Appointment> GetInvoiceableAppointments(
            int psychometristId,
            DateTimeOffset invoicePeriodBegin,
            DateTimeOffset invoicePeriodEnd,
            string timezone
        )
        {
            var criteria = new AppointmentSearchCriteria
            {
                PsychometristId = psychometristId,
                AppointmentTimeStart = invoicePeriodEnd.InTimezone(timezone),
                AppointmentTimeEnd = invoicePeriodEnd.InTimezone(timezone),
            };

            var appointments = _appointmentRepository.GetAppointmentsForPsychometristInvoice(criteria)
                .Where(appointment => appointment.AppointmentStatus.CanInvoice);

            return appointments;
        }
    }
}
