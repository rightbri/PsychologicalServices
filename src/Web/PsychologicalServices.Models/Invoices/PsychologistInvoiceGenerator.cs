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
                InvoiceDate = appointment.AppointmentTime.Date,
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

            var isLargeFile = appointment.Assessment.IsLargeFile || appointment.Assessment.FileSize >= invoiceCalculationData.LargeFileSize;
            
            if (invoiceCalculationData.ApplyCompletionFee)
            {
                lines.Add(
                    new InvoiceLine
                    {
                        Amount = invoiceCalculationData.CompletionFeeAmount,
                        Description = appointment.ToCompletionFeeInvoiceLineDescription(),
                    });
            }
            else
            {
                //primary reports
                var primaryReports = appointment.Assessment.Reports.Where(report => !report.IsAdditional);
                
                if (primaryReports.Count() > 1)
                {
                    lines.Add(
                        new InvoiceLine
                        {
                            Amount = invoiceCalculationData.ComboReportInvoiceAmount,
                            Description = appointment.Assessment.ToPrimaryReportsInvoiceLineDescription(),
                            ApplyInvoiceRate = true,
                        });
                }
                else if (primaryReports.Count() == 1)
                {
                    lines.Add(
                        new InvoiceLine
                        {
                            Amount = invoiceCalculationData.SingleReportInvoiceAmount,
                            Description = appointment.Assessment.ToPrimaryReportsInvoiceLineDescription(),
                            ApplyInvoiceRate = true,
                        });
                }

                //extra reports
                if (invoiceCalculationData.ApplyExtraReportFees)
                {
                    var extraReports = appointment.Assessment.Reports.Where(report => report.IsAdditional);

                    foreach (var extraReport in extraReports)
                    {
                        lines.Add(
                            new InvoiceLine
                            {
                                Amount = invoiceCalculationData.ExtraReportFee,
                                Description = extraReport.ToExtraReportsInvoiceLineDescriptions(appointment.Assessment.AssessmentType.Description),
                                ApplyInvoiceRate = true,
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
                            lines.Add(
                                new InvoiceLine
                                {
                                    Amount = issueInDisputeInvoiceAmount.InvoiceAmount,
                                    Description = $"{issueInDisputeInvoiceAmount.IssueInDispute.Name} surcharge",
                                    ApplyInvoiceRate = true,
                                });
                        }
                    }
                }
            }

            //large file fee - apply to first billable && first time seen appointments
            if (invoiceCalculationData.ApplyLargeFileFee)
            {
                if (
                    (
                        appointment.IsFirstInvoiceableAppointment(assessmentAppointments) ||
                        appointment.IsFirstTimeSeen(assessmentAppointments)
                    ) && isLargeFile
                )
                {
                    lines.Add(
                        new InvoiceLine
                        {
                            Amount = invoiceCalculationData.LargeFileFee,
                            Description = "Large File Fee",
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
                            Description = string.Format("Travel to {0}", travelFee.City.Name),
                            Amount = travelFee.Amount
                        }
                    );
                }
            }
            
            return lines;
        }

        public int GetInvoiceTotal(Invoice invoice)
        {
            var total = 0.0m;

            var subtotal = 0.0m;

            foreach (var invoiceAppointment in invoice.Appointments)
            {
                var appointmentTotal = 0.0m;
                
                var appointment = invoiceAppointment.Appointment;

                var assessmentAppointments = _appointmentRepository.GetAppointmentSequenceSiblings(appointment.AppointmentId);

                var appointmentSequence = appointment.AppointmentSequence(assessmentAppointments);

                var invoiceCalculationData = _invoiceRepository.GetPsychologistInvoiceCalculationData(
                    appointment.Assessment.Company.CompanyId,
                    appointment.Assessment.ReferralSource.ReferralSourceId,
                    appointment.Assessment.AssessmentType.AssessmentTypeId,
                    appointment.AppointmentStatus.AppointmentStatusId,
                    appointmentSequence.AppointmentSequenceId
                );

                var invoiceRate = invoiceCalculationData.InvoiceRate;

                appointmentTotal =
                    invoiceAppointment.Lines.Where(line => !line.ApplyInvoiceRate).Select(line => line.Amount).Sum() +
                    //apply invoice rate to base assessment charges only
                    (invoiceAppointment.Lines.Where(line => line.ApplyInvoiceRate).Select(line => line.Amount).Sum() * invoiceRate);

                subtotal += appointmentTotal;
            }

            total = subtotal * (1 + invoice.TaxRate);

            return Convert.ToInt32(total);
        }
    }
}
