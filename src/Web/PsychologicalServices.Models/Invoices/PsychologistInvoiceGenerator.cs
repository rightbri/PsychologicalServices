using PsychologicalServices.Models.Appointments;
using PsychologicalServices.Models.Common.Utility;
using PsychologicalServices.Models.Referrals;
using PsychologicalServices.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Invoices
{
    public class PsychologistInvoiceGenerator : IPsychologistInvoiceGenerator
    {
        private readonly IInvoiceRepository _invoiceRepository = null;
        private readonly IAppointmentRepository _appointmentRepository = null;
        private readonly IReferralRepository _referralRepository = null;
        private readonly IUserRepository _userRepository = null;
        private readonly IDate _date = null;

        public PsychologistInvoiceGenerator(
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
            var invoiceTypeId = InvoiceType.Psychologist;

            if (!appointment.AppointmentStatus.CanInvoice)
            {
                throw new InvalidOperationException("An invoice cannot be opened without an invoiceable appointment.");
            }

            if (_invoiceRepository.GetInvoices(new InvoiceSearchCriteria
                {
                    CompanyId = appointment.Assessment.Company.CompanyId,
                    AppointmentId = appointment.AppointmentId,
                    InvoiceTypeId = invoiceTypeId,
                }).Any()
            )
            {
                throw new InvalidOperationException("A psychologist invoice already exists for this appointment.");
            }

            var assessmentAppointments = _appointmentRepository.GetAppointmentSequenceSiblings(appointment.AppointmentId);

            var appointmentSequence = appointment.AppointmentSequence(assessmentAppointments);

            var invoiceCalculationData = _invoiceRepository.GetPsychologistInvoiceCalculationData(
                appointment.Assessment.Company.CompanyId,
                appointment.Assessment.ReferralSource.ReferralSourceId,
                appointment.Assessment.AssessmentType.AssessmentTypeId,
                appointment.AppointmentStatus.AppointmentStatusId,
                appointmentSequence.AppointmentSequenceId
            );

            var invoice = new Invoice
            {
                InvoiceDate = _date.UtcNow,
                InvoiceStatus = _invoiceRepository.GetInitialInvoiceStatus(),
                InvoiceType = new InvoiceType
                    {
                        InvoiceTypeId = invoiceTypeId,
                    },
                PayableTo = appointment.Psychologist,
                Appointments = new List<InvoiceAppointment>(new[]
                    {
                        new InvoiceAppointment
                        {
                            Appointment = appointment,
                            Lines = GetInvoiceLines(appointment),
                        }
                    }),
                InvoiceRate = invoiceCalculationData.InvoiceRate,
                TaxRate = _invoiceRepository.GetTaxRate(),
                UpdateDate = _date.UtcNow,
            };

            invoice.Total = GetInvoiceTotal(invoice);

            invoice.Identifier = $"{appointment.AppointmentTime:yy-MM-}{_invoiceRepository.IncrementCompanyInvoiceCounter(appointment.Assessment.Company.CompanyId):00#}";
            
            return invoice;
        }
        
        public IEnumerable<InvoiceAppointment> GetInvoiceAppointments(Invoice invoice)
        {
            var invoiceAppointments = new List<InvoiceAppointment>();
            
            foreach (var invoiceAppointment in invoice.Appointments)
            {
                invoiceAppointments.Add(
                    new InvoiceAppointment
                    {
                        InvoiceAppointmentId = invoiceAppointment.InvoiceAppointmentId,
                        Appointment = invoiceAppointment.Appointment,
                        Lines = GetInvoiceLines(invoiceAppointment.Appointment)
                            .Union(invoiceAppointment.Lines.Where(line => line.IsCustom)),
                    });
            }
            
            return invoiceAppointments;
        }

        private List<InvoiceLine> GetInvoiceLines(Appointment appointment)
        {
            var lines = new List<InvoiceLine>();

            var psychologist = _userRepository.GetUserById(appointment.Psychologist.UserId);

            var assessmentAppointments = _appointmentRepository.GetAppointmentSequenceSiblings(appointment.AppointmentId);

            var appointmentSequence = appointment.AppointmentSequence(assessmentAppointments);
            
            var invoiceCalculationData = _invoiceRepository.GetPsychologistInvoiceCalculationData(
                appointment.Assessment.Company.CompanyId,
                appointment.Assessment.ReferralSource.ReferralSourceId,
                appointment.Assessment.AssessmentType.AssessmentTypeId,
                appointment.AppointmentStatus.AppointmentStatusId,
                appointmentSequence.AppointmentSequenceId
            );
            
            if (invoiceCalculationData.ApplyCompletionFee)
            {
                lines.Add(
                    new InvoiceLine
                    {
                        Amount = invoiceCalculationData.CompletionFeeAmount,
                        OriginalAmount = invoiceCalculationData.CompletionFeeAmount,
                        Description = appointment.ToCompletionFeeInvoiceLineDescription(),
                    });
            }
            else
            {
                //primary reports
                var primaryReports = appointment.Assessment.Reports.Where(report => !report.IsAdditional);

                if (primaryReports.Any())
                {
                    var baseAmount = primaryReports.Count() > 1
                        ? invoiceCalculationData.ComboReportInvoiceAmount
                        : invoiceCalculationData.SingleReportInvoiceAmount;

                    var amount = Convert.ToInt32(baseAmount * invoiceCalculationData.InvoiceRate);

                    var baseDescription = appointment.Assessment.ToPrimaryReportsInvoiceLineDescription();

                    var description = invoiceCalculationData.IsDiscountedRate()
                        ? $"{baseDescription} - {appointment.AppointmentStatus.Name}"
                        : baseDescription;

                    lines.Add(
                        new InvoiceLine
                        {
                            Amount = amount,
                            OriginalAmount = baseAmount,
                            Description = description,
                        });
                }
                
                //extra reports
                if (invoiceCalculationData.ApplyExtraReportFees)
                {
                    var extraReports = appointment.Assessment.Reports.Where(report => report.IsAdditional);

                    foreach (var extraReport in extraReports)
                    {
                        var baseAmount = invoiceCalculationData.ExtraReportFee;

                        var amount = Convert.ToInt32(baseAmount * invoiceCalculationData.InvoiceRate);

                        var baseDescription = extraReport.ToExtraReportsInvoiceLineDescriptions(appointment.Assessment.AssessmentType.Description);

                        var description = invoiceCalculationData.IsDiscountedRate()
                            ? $"{baseDescription} - {appointment.AppointmentStatus.Name}"
                            : baseDescription;

                        lines.Add(
                            new InvoiceLine
                            {
                                Amount = amount,
                                OriginalAmount = baseAmount,
                                Description = description,
                            });
                    }
                }
                
                //issues in dispute
                if (invoiceCalculationData.ApplyIssueInDisputeFees)
                {
                    foreach (var issueInDisputeInvoiceAmount in invoiceCalculationData.IssueInDisputeInvoiceAmounts)
                    {
                        if (issueInDisputeInvoiceAmount.InvoiceAmount > 0 &&
                            appointment.Assessment.Reports.Any(report =>
                                report.IssuesInDispute.Any(issueInDispute =>
                                    issueInDispute.IssueInDisputeId == issueInDisputeInvoiceAmount.IssueInDispute.IssueInDisputeId
                                )
                            )
                        )
                        {
                            var baseAmount = issueInDisputeInvoiceAmount.InvoiceAmount;

                            var amount = Convert.ToInt32(baseAmount * invoiceCalculationData.InvoiceRate);

                            var baseDescription = $"{issueInDisputeInvoiceAmount.IssueInDispute.Name} surcharge";

                            var description = invoiceCalculationData.IsDiscountedRate()
                                ? $"{baseDescription} - {appointment.AppointmentStatus.Name}"
                                : baseDescription;

                            lines.Add(
                                new InvoiceLine
                                {
                                    Amount = amount,
                                    OriginalAmount = baseAmount,
                                    Description = description,
                                });
                        }
                    }
                }
            }

            var isLargeFile = appointment.Assessment.IsLargeFile || appointment.Assessment.FileSize >= invoiceCalculationData.LargeFileSize;

            //large file fee - apply to first billable && first time seen appointments
            if (isLargeFile && invoiceCalculationData.ApplyLargeFileFee)
            {
                if (appointment.IsFirstInvoiceableAppointment(assessmentAppointments) ||
                    appointment.IsFirstTimeSeen(assessmentAppointments))
                {
                    var fileSize = appointment.Assessment.FileSize;

                    var description = fileSize.HasValue
                        ? $"Large File Fee ({fileSize:#,##0} pages)"
                        : "Large File Fee";

                    lines.Add(
                        new InvoiceLine
                        {
                            Amount = invoiceCalculationData.LargeFileFee,
                            OriginalAmount = invoiceCalculationData.LargeFileFee,
                            Description = description,
                        }
                    );
                }
            }
            
            //travel fee
            if (invoiceCalculationData.ApplyTravelFee)
            {
                var travelFee = psychologist.TravelFees.SingleOrDefault(tf => tf.City.CityId == appointment.Location.City.CityId);
                if (null != travelFee && travelFee.Amount > 0)
                {
                    lines.Add(
                        new InvoiceLine
                        {
                            Amount = travelFee.Amount,
                            OriginalAmount = travelFee.Amount,
                            Description = $"Travel to {travelFee.City.Name}",
                        }
                    );
                }
            }

            //room rental fee
            if (appointment.RoomRentalBillableAmount.HasValue &&
                appointment.RoomRentalBillableAmount.Value > 0)
            {
                lines.Add(
                    new InvoiceLine
                    {
                        Amount = appointment.RoomRentalBillableAmount.Value,
                        OriginalAmount = appointment.RoomRentalBillableAmount.Value,
                        Description = $"Room Rental Fee",
                    }
                );
            }
            
            return lines;
        }

        public int GetInvoiceTotal(Invoice invoice)
        {
            var subtotal = invoice.Appointments
                .SelectMany(invoiceAppointment => invoiceAppointment.Lines)
                .Select(line => line.Amount)
                .Sum();
            
            var total = subtotal * (1 + invoice.TaxRate);

            return Convert.ToInt32(total);
        }
    }
}
