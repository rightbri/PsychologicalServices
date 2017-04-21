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

        public Invoice CreateInvoice(Appointment appointment)
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
                Appointment = appointment,
                InvoiceDate = appointment.AppointmentTime.Date,
                InvoiceStatus = _invoiceRepository.GetInitialInvoiceStatus(),
                TaxRate = _invoiceRepository.GetTaxRate(),
                UpdateDate = _date.UtcNow,
            };

            invoice.Lines = GetInvoiceLines(appointment);

            invoice.Total = GetInvoiceTotal(invoice);

            return invoice;
        }

        public IEnumerable<InvoiceLine> GetInvoiceLines(Appointment appointment)
        {
            var lines = new List<InvoiceLine>();

            var isLateCancellation = appointment.IsLateCancellation();

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
            var subtotal = (invoice.Lines.Select(line => line.Amount).Sum());

            var referralSource = _referralRepository.GetReferralSource(invoice.Appointment.Assessment.ReferralSource.ReferralSourceId);

            var appointmentStatusSetting = referralSource.AppointmentStatusSettings.SingleOrDefault(setting => setting.AppointmentStatus.AppointmentStatusId == invoice.Appointment.AppointmentStatus.AppointmentStatusId);
            if (null != appointmentStatusSetting)
            {
                subtotal = subtotal * appointmentStatusSetting.InvoiceRate;
            }

            return subtotal * (1 + invoice.TaxRate);
        }
    }
}
