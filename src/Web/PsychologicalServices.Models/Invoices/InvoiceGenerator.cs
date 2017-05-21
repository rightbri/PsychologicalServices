using PsychologicalServices.Models.Appointments;
using PsychologicalServices.Models.Common.Utility;
using PsychologicalServices.Models.Referrals;
using PsychologicalServices.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Invoices
{
    public class InvoiceGenerator : IInvoiceGenerator
    {
        private readonly IInvoiceRepository _invoiceRepository = null;
        private readonly IAppointmentRepository _appointmentRepository = null;
        private readonly IReferralRepository _referralRepository = null;
        private readonly IUserRepository _userRepository = null;
        private readonly IDate _date = null;

        public InvoiceGenerator(
            IInvoiceRepository invoiceRepository,
            IAppointmentRepository appointmentRepository,
            IReferralRepository referralRepository,
            IUserRepository userRepository,
            IDate date
        )
        {
            _invoiceRepository = invoiceRepository;
            _appointmentRepository = appointmentRepository;
            _referralRepository = referralRepository;
            _userRepository = userRepository;
            _date = date;
        }

        public Invoice CreatePsychologistInvoice(Appointment appointment)
        {
            if (!appointment.AppointmentStatus.CanInvoice)
            {
                throw new InvalidOperationException("An invoice cannot be opened without an invoiceable appointment.");
            }

            if (_invoiceRepository.GetInvoices(new InvoiceSearchCriteria
                {
                    AppointmentId = appointment.AppointmentId
                }).Any()
            )
            {
                throw new InvalidOperationException("An invoice already exists for this appointment.");
            }

            var invoice = new Invoice
            {
                Identifier = string.Format("{0:yy-MM-}{1:00#}",
                    appointment.AppointmentTime,
                    _invoiceRepository.GetInvoiceCount(appointment.AppointmentTime.Year, appointment.AppointmentTime.Month) + 1
                ),
                InvoiceDate = appointment.AppointmentTime.Date,
                InvoiceStatus = _invoiceRepository.GetInitialInvoiceStatus(),
                InvoiceType = new InvoiceType
                {
                    InvoiceTypeId = InvoiceType.Psychologist,
                },
                PayableTo = appointment.Psychologist,
                Appointments = new List<InvoiceAppointment>(new[]
                    {
                        new InvoiceAppointment
                        {
                            Appointment = appointment,
                            Lines = GetPsychologistInvoiceLines(appointment),
                            InvoiceRate = GetAppointmentStatusInvoiceRate(appointment),
                        }
                    }),
                TaxRate = _invoiceRepository.GetTaxRate(),
                UpdateDate = _date.UtcNow,
            };

            invoice.Total = GetInvoiceTotal(invoice);

            return invoice;
        }

        public Invoice CreatePsychometristInvoice(User psychometrist, DateTime invoiceDate)
        {
            if (_invoiceRepository.GetInvoices(new InvoiceSearchCriteria
            {
                PayableToId = psychometrist.UserId,
                InvoiceTypeId = InvoiceType.Psychometrist,
                InvoiceDate = invoiceDate,
            }).Any()
            )
            {
                throw new InvalidOperationException("An invoice already exists for this psychometrist and invoice date.");
            }

            var criteria = new AppointmentSearchCriteria
            {
                PsychometristId = psychometrist.UserId,
                AppointmentTimeStart = invoiceDate.FirstDayOfMonth(),
                AppointmentTimeEnd = invoiceDate.EndOfMonth(),
            };

            var appointments = _appointmentRepository.GetAppointments(criteria)
                .Where(appointment => appointment.AppointmentStatus.CanInvoice)
                .Select(appointment => new InvoiceAppointment
                {
                    Appointment = appointment,
                    Lines = GetPsychometristInvoiceLines(appointment),
                    InvoiceRate = GetAppointmentStatusInvoiceRate(appointment),
                });

            var invoice = new Invoice
            {
                Identifier = string.Format("{0}-{1:00#}", psychometrist.UserId, _invoiceRepository.GetInvoiceCount(psychometrist.UserId) + 1),
                InvoiceDate = invoiceDate,
                InvoiceStatus = _invoiceRepository.GetInitialInvoiceStatus(),
                InvoiceType = new InvoiceType
                {
                    InvoiceTypeId = InvoiceType.Psychometrist,
                },
                PayableTo = psychometrist,
                Appointments = appointments,
                TaxRate = _invoiceRepository.GetTaxRate(),
                UpdateDate = _date.UtcNow,
            };

            invoice.Total = GetInvoiceTotal(invoice);

            return invoice;
        }

        public IEnumerable<InvoiceAppointment> GetInvoiceAppointments(Invoice invoice)
        {
            var invoiceAppointments = new List<InvoiceAppointment>();
            var incompleteStatusId = 6;
            
            foreach (var invoiceAppointment in invoice.Appointments)
            {
                switch (invoice.InvoiceType.InvoiceTypeId)
                {
                    case InvoiceType.Psychologist:
                        invoiceAppointments.Add(
                            new InvoiceAppointment
                            {
                                InvoiceAppointmentId = invoiceAppointment.InvoiceAppointmentId,
                                Appointment = invoiceAppointment.Appointment,
                                Lines = GetPsychologistInvoiceLines(invoiceAppointment.Appointment)
                                    .Union(invoiceAppointment.Lines.Where(line => line.IsCustom)),
                                InvoiceRate = GetAppointmentStatusInvoiceRate(invoiceAppointment.Appointment),
                            });
                        break;
                    case InvoiceType.Psychometrist:
                        invoiceAppointments.Add(
                            new InvoiceAppointment
                            {
                                InvoiceAppointmentId = invoiceAppointment.InvoiceAppointmentId,
                                Appointment = invoiceAppointment.Appointment,
                                Lines = GetPsychometristInvoiceLines(invoiceAppointment.Appointment,
                                    //is completion?
                                    invoice.Appointments.Any(ia =>
                                        ia.Appointment.Assessment.AssessmentId == invoiceAppointment.Appointment.Assessment.AssessmentId &&
                                        ia.Appointment.AppointmentTime < invoiceAppointment.Appointment.AppointmentTime &&
                                        ia.Appointment.AppointmentStatus.AppointmentStatusId == incompleteStatusId
                                    )
                                ).Union(invoiceAppointment.Lines.Where(line => line.IsCustom)),
                                InvoiceRate = GetAppointmentStatusInvoiceRate(invoiceAppointment.Appointment),
                            }
                        );
                        break;
                    default:
                        break;
                }
            }
            
            return invoiceAppointments;
        }

        private List<InvoiceLine> GetPsychometristInvoiceLines(Appointment appointment, bool isCompletion = false)
        {
            var normalRate = 1.0m;
            var completionRate = 0.5m;
            var lines = new List<InvoiceLine>();

            var description = appointment.Assessment.AssessmentType.Description;
            decimal amount = appointment.Assessment.AssessmentType.InvoiceAmount;
            decimal invoiceRate = GetAppointmentStatusInvoiceRate(appointment);
            
            if (isCompletion)
            {
                invoiceRate = completionRate;
            }

            if (invoiceRate != normalRate)
            {
                amount = amount * invoiceRate;

                description = description + " - " + appointment.AppointmentStatus.Name;
            }

            lines.Add(new InvoiceLine { Amount = amount, Description = description });

            var travelFee = appointment.Psychometrist.TravelFees
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

        private List<InvoiceLine> GetPsychologistInvoiceLines(Appointment appointment, bool isCompletion = false)
        {
            /*
             *  Appointment
             *      Psychologist
             *          TravelFees
             *              City
             *      Location
             *          City
             *      Assessment
             *          ReferralSource
             *          Reports
             *              ReportType
             *              IssuesInDispute
             *      
             */
            var lines = new List<InvoiceLine>();

            var psychologist = _userRepository.GetUserById(appointment.Psychologist.UserId);

            var referralSource = _referralRepository.GetReferralSource(appointment.Assessment.ReferralSource.ReferralSourceId);

            foreach (var report in appointment.Assessment.Reports)
            {
                var reportAmount = referralSource.ReportTypeInvoiceAmounts.SingleOrDefault(invoiceAmount => invoiceAmount.ReportType.ReportTypeId == report.ReportType.ReportTypeId);

                var description =
                    string.Format("{0}{1} Assessment Report Addressing {2}",
                        report.IsAdditional ? "Additional " : "",
                        report.ReportType.Name,
                        string.Join(", ", report.IssuesInDispute.Select(issueInDispute => issueInDispute.Name))
                    );

                var amount = report.IsAdditional
                    ? _invoiceRepository.GetAdditionalReportAmount(referralSource.ReferralSourceId, report.ReportType.ReportTypeId)
                    : (null != reportAmount
                        ? reportAmount.InvoiceAmount
                    //report type invoice amount not configured for referral source
                        : 0
                    );

                lines.Add(new InvoiceLine { Description = description, Amount = amount });

                foreach (var issueInDispute in report.IssuesInDispute)
                {
                    if (issueInDispute.AdditionalFee > 0)
                    {
                        lines.Add(
                            new InvoiceLine
                            {
                                Description = string.Format("Addressing {0}", issueInDispute.Name),
                                Amount = issueInDispute.AdditionalFee,
                            }
                        );
                    }
                }
            }

            var travelFee = psychologist.TravelFees.SingleOrDefault(tf => tf.City.CityId == appointment.Location.City.CityId);
            if (null != travelFee && travelFee.Amount > 0)
            {
                lines.Add(
                    new InvoiceLine
                    {
                        Description = string.Format("Travel to {0}", travelFee.City.Name),
                        Amount = travelFee.Amount
                    }
                );
            }

            if (appointment.Assessment.IsLargeFile || appointment.Assessment.FileSize >= referralSource.LargeFileSize)
            {
                lines.Add(
                    new InvoiceLine
                    {
                        Description = "Large File Fee",
                        Amount = referralSource.LargeFileFeeAmount
                    }
                );
            }

            return lines;
        }

        public decimal GetInvoiceTotal(Invoice invoice)
        {
            var total = 0.0m;

            var subtotal = 0.0m;

            foreach (var invoiceAppointment in invoice.Appointments)
            {
                var appointmentTotal = invoiceAppointment.Lines.Select(line => line.Amount).Sum();
                
                var appointment = invoiceAppointment.Appointment;

                var appointmentStatusSetting =
                        appointment.AppointmentStatus.AppointmentStatusSettings
                            .SingleOrDefault(setting =>
                                setting.InvoiceType.InvoiceTypeId == invoice.InvoiceType.InvoiceTypeId &&
                                setting.ReferralSource.ReferralSourceId == appointment.Assessment.ReferralSource.ReferralSourceId);

                if (null != appointmentStatusSetting)
                {
                    appointmentTotal = appointmentTotal * appointmentStatusSetting.InvoiceRate;
                }

                subtotal += appointmentTotal;
            }

            total = subtotal * (1 + invoice.TaxRate);

            return total;
        }

        private decimal GetAppointmentStatusInvoiceRate(Appointment appointment)
        {
            var rate = 1.0m;

            var statusSetting = appointment.AppointmentStatus.AppointmentStatusSettings
                .SingleOrDefault(appointmentStatusSetting => appointmentStatusSetting.ReferralSource.ReferralSourceId == appointment.Assessment.ReferralSource.ReferralSourceId);

            if (null != statusSetting)
            {
                rate = statusSetting.InvoiceRate;
            }

            return rate;
        }
    }
}
