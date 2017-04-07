using PsychologicalServices.Models.Appointments;
using PsychologicalServices.Models.Common.Utility;
using PsychologicalServices.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Invoices
{
    public class InvoiceGenerator : IInvoiceGenerator
    {
        private readonly IInvoiceRepository _invoiceRepository = null;
        private readonly IUserRepository _userRepository = null;
        private readonly IDate _date = null;

        public InvoiceGenerator(
            IInvoiceRepository invoiceRepository,
            IUserRepository userRepository,
            IDate date
        )
        {
            _invoiceRepository = invoiceRepository;
            _userRepository = userRepository;
            _date = date;
        }

        //TODO: don't hard-code fake values
        public Invoice CreateInvoice(Appointment appointment)
        {
            if (!appointment.AppointmentStatus.CanInvoice)
            {
                throw new InvalidOperationException("An invoice cannot be opened without an invoiceable appointment.");
            }

            var existingInvoices = _invoiceRepository.GetInvoices(new InvoiceSearchCriteria
                {
                    AppointmentId = appointment.AppointmentId
                });

            if (existingInvoices.Any())
            {
                throw new InvalidOperationException("An invoice already exists for this appointment.");
            }

            var psychologist = _userRepository.GetUserById(appointment.Psychologist.UserId);

            var invoiceAmounts = _invoiceRepository.GetInvoiceAmounts(appointment.Assessment.Company.CompanyId, appointment.Assessment.ReferralSource.ReferralSourceId);

            var invoiceCount = _invoiceRepository.GetInvoiceCount(appointment.AppointmentTime.Year, appointment.AppointmentTime.Month);

            var taxRate = _invoiceRepository.GetTaxRate();

            var invoiceStatus = _invoiceRepository.GetInvoiceStatus(1); //TODO: don't hard-code id

            var invoice = new Invoice
            {
                Identifier = string.Format("{0:yy-MM-}{1:00#}", appointment.AppointmentTime, invoiceCount + 1),
                Appointment = appointment,
                InvoiceDate = appointment.AppointmentTime.Date,
                InvoiceStatus = invoiceStatus,
                TaxRate = taxRate,
                UpdateDate = _date.UtcNow,
            };

            var lines = new List<InvoiceLine>();

            foreach (var report in appointment.Assessment.Reports)
            {
                var reportAmount = invoiceAmounts
                    .Where(invoiceAmount => invoiceAmount.ReportType.ReportTypeId == report.ReportType.ReportTypeId)
                    .SingleOrDefault();

                lines.Add(
                    new InvoiceLine
                    {
                        Description = string.Format("{0} report addressing {1}", 
                            report.ReportType.Name, 
                            string.Join(", ", report.IssuesInDispute.Select(issueInDispute => issueInDispute.Name))
                        ),
                        Amount = 
                            (null != reportAmount
                                ? report.IsAdditional ? reportAmount.AdditionalReportAmount : reportAmount.FirstReportAmount
                                : 0) +
                            report.IssuesInDispute.Sum(issueInDispute => issueInDispute.AdditionalFee)
                    }
                );
            }

            var travelFee = psychologist.TravelFees.Where(tf => tf.City.CityId == appointment.Location.City.CityId)
                .SingleOrDefault();

            if (null != travelFee && travelFee.Amount > 0)
            {
                lines.Add(
                    new InvoiceLine
                    {
                        Description = "Travel Fee",
                        Amount = travelFee.Amount
                    }
                );
            }

            invoice.Lines = lines;

            return invoice;
        }
    }
}
