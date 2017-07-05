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

            var invoiceType = new InvoiceType
            {
                InvoiceTypeId = InvoiceType.Psychologist,
            };

            var invoice = new Invoice
            {
                Identifier = string.Format("{0:yy-MM-}{1:00#}",
                    appointment.AppointmentTime,
                    _invoiceRepository.GetInvoiceCount(appointment.AppointmentTime.Year, appointment.AppointmentTime.Month) + 1
                ),
                InvoiceDate = appointment.AppointmentTime.Date,
                InvoiceStatus = _invoiceRepository.GetInitialInvoiceStatus(),
                InvoiceType = invoiceType,
                PayableTo = appointment.Psychologist,
                Appointments = new List<InvoiceAppointment>(new[]
                    {
                        new InvoiceAppointment
                        {
                            Appointment = appointment,
                            Lines = GetPsychologistInvoiceLines(appointment),
                            InvoiceRate = GetAppointmentStatusInvoiceRate(
                                appointment,
                                invoiceType,
                                appointment.AppointmentSequence(appointment.Assessment.Appointments)
                            ),
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

            var invoiceType = new InvoiceType
            {
                InvoiceTypeId = InvoiceType.Psychometrist,
            };
            
            var appointments = _appointmentRepository.GetAppointments(criteria)
                .Where(appointment => appointment.AppointmentStatus.CanInvoice)
                .Select(appointment =>
                {
                    var invoiceRate =
                        GetAppointmentStatusInvoiceRate(
                            appointment,
                            invoiceType,
                            appointment.AppointmentSequence(appointment.Assessment.Appointments)
                        );

                    return new InvoiceAppointment
                    {
                        Appointment = appointment,
                        Lines = GetPsychometristInvoiceLines(
                            appointment,
                            invoiceRate,
                            appointment.IsCompletion(appointment.Assessment.Appointments)
                        ),
                        InvoiceRate = invoiceRate,
                    };
                });

            var invoice = new Invoice
            {
                Identifier = string.Format("{0}-{1:00#}", psychometrist.UserId, _invoiceRepository.GetInvoiceCount(psychometrist.UserId) + 1),
                InvoiceDate = invoiceDate,
                InvoiceStatus = _invoiceRepository.GetInitialInvoiceStatus(),
                InvoiceType = invoiceType,
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
            
            foreach (var invoiceAppointment in invoice.Appointments)
            {
                var invoiceRate =
                    GetAppointmentStatusInvoiceRate(
                        invoiceAppointment.Appointment,
                        invoice.InvoiceType,
                        invoiceAppointment.Appointment.AppointmentSequence(invoice.Appointments.Select(ia => ia.Appointment))
                    );
                
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
                                InvoiceRate = invoiceRate,
                            });
                        break;
                    case InvoiceType.Psychometrist:
                        invoiceAppointments.Add(
                            new InvoiceAppointment
                            {
                                InvoiceAppointmentId = invoiceAppointment.InvoiceAppointmentId,
                                Appointment = invoiceAppointment.Appointment,
                                Lines = GetPsychometristInvoiceLines(
                                    invoiceAppointment.Appointment,
                                    invoiceRate,
                                    invoiceAppointment.Appointment.IsCompletion(invoice.Appointments.Select(ia => ia.Appointment))
                                ).Union(invoiceAppointment.Lines.Where(line => line.IsCustom)),
                                InvoiceRate = invoiceRate,
                            }
                        );
                        break;
                    default:
                        break;
                }
            }
            
            return invoiceAppointments;
        }

        private List<InvoiceLine> GetPsychometristInvoiceLines(Appointment appointment, decimal invoiceRate, bool isCompletion)
        {
            var normalRate = 100;
            var completionRate = 50;
            var lines = new List<InvoiceLine>();

            var description = appointment.Assessment.AssessmentType.Description;
            var amount = appointment.Assessment.AssessmentType.InvoiceAmount;
            
            if (isCompletion)
            {
                invoiceRate = completionRate;
            }

            if (invoiceRate != normalRate)
            {
                amount = amount * Convert.ToInt16(invoiceRate * 100);

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

        private List<InvoiceLine> GetPsychologistInvoiceLines(Appointment appointment)
        {
            var lines = new List<InvoiceLine>();

            var psychologist = _userRepository.GetUserById(appointment.Psychologist.UserId);

            var referralSource = _referralRepository.GetReferralSource(appointment.Assessment.ReferralSource.ReferralSourceId);

            foreach (var report in appointment.Assessment.Reports)
            {
                var reportAmount = referralSource.ReportTypeInvoiceAmounts.SingleOrDefault(invoiceAmount => invoiceAmount.ReportType.ReportTypeId == report.ReportType.ReportTypeId);

                var description =
                    string.Format("{0}{1} Assessment Report",
                        report.IsAdditional ? "Additional " : "",
                        report.ReportType.Name
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

        public int GetInvoiceTotal(Invoice invoice)
        {
            var total = 0.0m;

            var subtotal = 0.0m;

            foreach (var invoiceAppointment in invoice.Appointments)
            {
                decimal appointmentTotal = invoiceAppointment.Lines.Select(line => line.Amount).Sum();
                
                var appointment = invoiceAppointment.Appointment;

                //TODO: fix this .. it is wrong
                var appointmentStatusSetting =
                        appointment.AppointmentStatus.AppointmentStatusSettings
                            .SingleOrDefault(setting =>
                                setting.InvoiceType.InvoiceTypeId == invoice.InvoiceType.InvoiceTypeId &&
                                setting.ReferralSource.ReferralSourceId == appointment.Assessment.ReferralSource.ReferralSourceId
                            );

                if (null != appointmentStatusSetting)
                {
                    appointmentTotal = appointmentTotal * appointmentStatusSetting.InvoiceRate;
                }

                subtotal += appointmentTotal;
            }

            var taxRate = Convert.ToInt32(invoice.TaxRate * 100);

            total = subtotal * (100 + invoice.TaxRate);

            return Convert.ToInt32(total / 100);
        }

        private decimal GetAppointmentStatusInvoiceRate(Appointment appointment, InvoiceType invoiceType, AppointmentSequence appointmentSequence)
        {
            var rate = 100;

            var referralSource = _referralRepository.GetReferralSource(appointment.Assessment.ReferralSource.ReferralSourceId);

            var statusSetting = referralSource.AppointmentStatusSettings
                .Where(appointmentStatusSetting =>
                    appointmentStatusSetting.AppointmentSequence.AppointmentSequenceId == appointmentSequence.AppointmentSequenceId &&
                    appointmentStatusSetting.AppointmentStatus.AppointmentStatusId == appointment.AppointmentStatus.AppointmentStatusId &&
                    appointmentStatusSetting.InvoiceType.InvoiceTypeId == invoiceType.InvoiceTypeId
                ).SingleOrDefault();
            
            if (null != statusSetting)
            {
                rate = Convert.ToInt32(statusSetting.InvoiceRate * 100);
            }

            return rate;
        }
    }
}
