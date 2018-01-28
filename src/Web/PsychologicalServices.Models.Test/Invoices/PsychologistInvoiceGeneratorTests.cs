using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PsychologicalServices.Models.Common.Utility;
using PsychologicalServices.Models.Invoices;
using System;
using System.Linq;

namespace PsychologicalServices.Models.Test.Invoices
{
    [TestClass]
    public class PsychologistInvoiceGeneratorTests
    {
        private PsychologistInvoiceGenerator GetService(
            Action<Mock<IInvoiceRepository>, Mock<Appointments.IAppointmentRepository>, Mock<Referrals.IReferralRepository>, Mock<Users.IUserRepository>, Mock<IDate>> setupMocks = null
        )
        {
            var dateServiceMock = new Mock<IDate>();
            var invoiceRepositoryMock = new Mock<IInvoiceRepository>();
            var appointmentRepositoryMock = new Mock<Appointments.IAppointmentRepository>();
            var referralRepositoryMock = new Mock<Referrals.IReferralRepository>();
            var userRepositoryMock = new Mock<Users.IUserRepository>();

            setupMocks?.Invoke(
                invoiceRepositoryMock,
                appointmentRepositoryMock,
                referralRepositoryMock,
                userRepositoryMock,
                dateServiceMock
            );

            var psychometristInvoiceGenerator = new PsychologistInvoiceGenerator(
                invoiceRepositoryMock.Object,
                appointmentRepositoryMock.Object,
                referralRepositoryMock.Object,
                userRepositoryMock.Object,
                dateServiceMock.Object
            );

            return psychometristInvoiceGenerator;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CreateInvoiceThrowsExceptionAppointmentStatusIsNotInvoiceable()
        {
            var psychologistInvoiceGenerator = GetService();

            var appointment = new Appointments.Appointment
            {
                AppointmentStatus = new Appointments.AppointmentStatus
                {
                    CanInvoice = false,
                },
            };

            psychologistInvoiceGenerator.CreateInvoice(appointment);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CreateInvoiceThrowsExceptionWhenPsychologistInvoiceAlreadyExists()
        {
            var appointmentId = 1;

            var psychologistInvoiceGenerator = GetService(
                (invoiceRepositoryMock, appointmentRepositoryMock, referralRepository, userRepositoryMock, dateServiceMock) =>
                {
                    invoiceRepositoryMock
                        .Setup(invoiceRepository =>
                            invoiceRepository.GetInvoices(
                                It.Is<InvoiceSearchCriteria>(c => c.InvoiceTypeId == InvoiceType.Psychologist && c.AppointmentId == appointmentId)
                            )
                        )
                        .Returns(() => new[]
                        {
                            new Invoice(),
                        });
                });

            var appointment = new Appointments.Appointment
            {
                AppointmentId = appointmentId,
                AppointmentStatus = new Appointments.AppointmentStatus
                {
                    CanInvoice = true,
                },
                Assessment = new Assessments.Assessment
                {
                    Company = new Companies.Company
                    {
                        Email = "email@company.com",
                    },
                },
            };

            psychologistInvoiceGenerator.CreateInvoice(appointment);
        }

        [TestMethod]
        public void SingleReportAmountIsAppliedForAssessmentWithSingleReport()
        {
            var appointmentId = 1;
            var appointmentTime = new DateTimeOffset(2017, 10, 8, 13, 0, 0, TimeSpan.Zero);
            var appointmentStatusId = Appointments.AppointmentStatus.Complete;
            var cityId = 2;
            var assessmentTypeId = 3;
            var assessmentTypeDescription = "Assessment Type";
            var fileSize = 500;
            var isLargeFile = false;
            var largeFileSize = 1000;
            var largeFileFee = 50000;
            var referralSourceId = 4;
            var companyId = 5;
            var psychologistId = 6;
            var psychologist = new Users.User
            {
                UserId = psychologistId,
                TravelFees = Enumerable.Empty<Users.UserTravelFee>(),
            };
            var taxRate = 0.1m;
            var invoiceCount = 0;
            var appointmentSequenceId = Appointments.AppointmentSequence.First;
            var siblingAppointments = Enumerable.Empty<Appointments.Appointment>();
            var singleReportInvoiceAmount = 123400;
            var comboReportInvoiceAmount = 432100;
            var applyCompletionFee = false;
            var applyExtraReportFees = false;
            var applyIssueInDisputeFees = false;
            var applyLargeFileFee = false;
            var applyTravelFee = false;
            var completionFeeAmount = 75000;
            var extraReportFee = 50000;
            var invoiceRate = 1.0m;
            var catastrophicFee = 35000;
            var issuesInDispute = Enumerable.Empty<Models.Claims.IssueInDispute>();
            var issueInDisputeInvoiceAmounts = new[]
            {
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 1, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 2, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 3, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 4, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 5, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 6, }, InvoiceAmount = catastrophicFee },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 7, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 8, }, InvoiceAmount = 0 },
            };

            var psychologistInvoiceGenerator = GetService(
                (invoiceRepositoryMock, appointmentRepositoryMock, referralRepositoryMock, userRepositoryMock, dateMock) =>
                {
                    userRepositoryMock.Setup(ur => ur.GetUserById(It.Is<int>(i => i == psychologistId))).Returns(psychologist);

                    appointmentRepositoryMock
                        .Setup(ar => ar.GetAppointmentSequenceSiblings(It.Is<int>(i => i == appointmentId)))
                        .Returns(() => siblingAppointments);

                    invoiceRepositoryMock.Setup(ir => ir.GetPsychologistInvoiceCalculationData(
                        It.Is<int>(i => i == companyId),
                        It.Is<int>(i => i == referralSourceId),
                        It.Is<int>(i => i == assessmentTypeId),
                        It.Is<int>(i => i == appointmentStatusId),
                        It.Is<int>(i => i == appointmentSequenceId)
                    )).Returns(new PsychologistInvoiceCalculationData
                    {
                        Company = new Companies.Company { CompanyId = companyId, },
                        SingleReportInvoiceAmount = singleReportInvoiceAmount,
                        ComboReportInvoiceAmount = comboReportInvoiceAmount,
                        CompletionFeeAmount = completionFeeAmount,
                        ExtraReportFee = extraReportFee,
                        InvoiceRate = invoiceRate,
                        IssueInDisputeInvoiceAmounts = issueInDisputeInvoiceAmounts,
                        LargeFileSize = largeFileSize,
                        LargeFileFee = largeFileFee,
                        ApplyCompletionFee = applyCompletionFee,
                        ApplyExtraReportFees = applyExtraReportFees,
                        ApplyIssueInDisputeFees = applyIssueInDisputeFees,
                        ApplyLargeFileFee = applyLargeFileFee,
                        ApplyTravelFee = applyTravelFee,
                    });

                    invoiceRepositoryMock
                        .Setup(ir => ir.GetInvoices(It.Is<InvoiceSearchCriteria>(isc =>
                            isc.AppointmentId == appointmentId &&
                            isc.InvoiceTypeId == InvoiceType.Psychologist)))
                        .Returns(() => Enumerable.Empty<Invoice>());

                    invoiceRepositoryMock.Setup(ir => ir.GetInvoiceCount(It.Is<int>(i => i == psychologistId))).Returns(invoiceCount);

                    invoiceRepositoryMock.Setup(ir => ir.GetInitialInvoiceStatus()).Returns(new InvoiceStatus { InvoiceStatusId = InvoiceStatus.Open });

                    invoiceRepositoryMock.Setup(ir => ir.GetTaxRate()).Returns(taxRate);

                    dateMock.SetupGet(d => d.UtcNow).Returns(DateTime.UtcNow);
                });

            var appointment = new Appointments.Appointment
            {
                AppointmentId = appointmentId,
                AppointmentTime = appointmentTime,
                AppointmentStatus = new Appointments.AppointmentStatus
                {
                    AppointmentStatusId = appointmentStatusId,
                    CanInvoice = true,
                },
                Location = new Addresses.Address
                {
                    City = new Cities.City
                    {
                        CityId = cityId,
                    },
                },
                Assessment = new Assessments.Assessment
                {
                    AssessmentType = new Assessments.AssessmentType
                    {
                        AssessmentTypeId = assessmentTypeId,
                        Description = assessmentTypeDescription,
                    },
                    FileSize = fileSize,
                    IsLargeFile = isLargeFile,
                    ReferralSource = new Referrals.ReferralSource
                    {
                        ReferralSourceId = referralSourceId,
                    },
                    Reports = new[] {
                        new Reports.Report
                        {
                            IsAdditional = false,
                            IssuesInDispute = issuesInDispute,
                        }
                    },
                    Company = new Companies.Company
                    {
                        CompanyId = companyId,
                    },
                },
                Psychologist = new Users.User { UserId = psychologistId },
            };

            var invoice = psychologistInvoiceGenerator.CreateInvoice(appointment);

            var subtotal = singleReportInvoiceAmount * invoiceRate;

            var expected = Convert.ToInt32(subtotal + (subtotal * taxRate));

            var actual = invoice.Total;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ComboReportAmountIsAppliedForAssessmentWithSingleReport()
        {
            var appointmentId = 1;
            var appointmentTime = new DateTimeOffset(2017, 10, 8, 13, 0, 0, TimeSpan.Zero);
            var appointmentStatusId = Appointments.AppointmentStatus.Complete;
            var cityId = 2;
            var assessmentTypeId = 3;
            var assessmentTypeDescription = "Assessment Type";
            var fileSize = 500;
            var isLargeFile = false;
            var largeFileSize = 1000;
            var largeFileFee = 50000;
            var referralSourceId = 4;
            var companyId = 5;
            var psychologistId = 6;
            var psychologist = new Users.User
            {
                UserId = psychologistId,
                TravelFees = Enumerable.Empty<Users.UserTravelFee>(),
            };
            var taxRate = 0.1m;
            var invoiceCount = 0;
            var appointmentSequenceId = Appointments.AppointmentSequence.First;
            var siblingAppointments = Enumerable.Empty<Appointments.Appointment>();
            var singleReportInvoiceAmount = 123400;
            var comboReportInvoiceAmount = 432100;
            var applyCompletionFee = false;
            var applyExtraReportFees = false;
            var applyIssueInDisputeFees = false;
            var applyLargeFileFee = false;
            var applyTravelFee = false;
            var completionFeeAmount = 75000;
            var extraReportFee = 50000;
            var invoiceRate = 1.0m;
            var catastrophicFee = 35000;
            var issuesInDispute = Enumerable.Empty<Models.Claims.IssueInDispute>();
            var issueInDisputeInvoiceAmounts = new[]
            {
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 1, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 2, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 3, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 4, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 5, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 6, }, InvoiceAmount = catastrophicFee },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 7, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 8, }, InvoiceAmount = 0 },
            };

            var psychologistInvoiceGenerator = GetService(
                (invoiceRepositoryMock, appointmentRepositoryMock, referralRepositoryMock, userRepositoryMock, dateMock) =>
                {
                    userRepositoryMock.Setup(ur => ur.GetUserById(It.Is<int>(i => i == psychologistId))).Returns(psychologist);

                    appointmentRepositoryMock
                        .Setup(ar => ar.GetAppointmentSequenceSiblings(It.Is<int>(i => i == appointmentId)))
                        .Returns(() => siblingAppointments);

                    invoiceRepositoryMock.Setup(ir => ir.GetPsychologistInvoiceCalculationData(
                        It.Is<int>(i => i == companyId),
                        It.Is<int>(i => i == referralSourceId),
                        It.Is<int>(i => i == assessmentTypeId),
                        It.Is<int>(i => i == appointmentStatusId),
                        It.Is<int>(i => i == appointmentSequenceId)
                    )).Returns(new PsychologistInvoiceCalculationData
                    {
                        Company = new Companies.Company { CompanyId = companyId, },
                        SingleReportInvoiceAmount = singleReportInvoiceAmount,
                        ComboReportInvoiceAmount = comboReportInvoiceAmount,
                        CompletionFeeAmount = completionFeeAmount,
                        ExtraReportFee = extraReportFee,
                        InvoiceRate = invoiceRate,
                        IssueInDisputeInvoiceAmounts = issueInDisputeInvoiceAmounts,
                        LargeFileSize = largeFileSize,
                        LargeFileFee = largeFileFee,
                        ApplyCompletionFee = applyCompletionFee,
                        ApplyExtraReportFees = applyExtraReportFees,
                        ApplyIssueInDisputeFees = applyIssueInDisputeFees,
                        ApplyLargeFileFee = applyLargeFileFee,
                        ApplyTravelFee = applyTravelFee,
                    });

                    invoiceRepositoryMock
                        .Setup(ir => ir.GetInvoices(It.Is<InvoiceSearchCriteria>(isc =>
                            isc.AppointmentId == appointmentId &&
                            isc.InvoiceTypeId == InvoiceType.Psychologist)))
                        .Returns(() => Enumerable.Empty<Invoice>());

                    invoiceRepositoryMock.Setup(ir => ir.GetInvoiceCount(It.Is<int>(i => i == psychologistId))).Returns(invoiceCount);

                    invoiceRepositoryMock.Setup(ir => ir.GetInitialInvoiceStatus()).Returns(new InvoiceStatus { InvoiceStatusId = InvoiceStatus.Open });

                    invoiceRepositoryMock.Setup(ir => ir.GetTaxRate()).Returns(taxRate);

                    dateMock.SetupGet(d => d.UtcNow).Returns(DateTime.UtcNow);
                });

            var appointment = new Appointments.Appointment
            {
                AppointmentId = appointmentId,
                AppointmentTime = appointmentTime,
                AppointmentStatus = new Appointments.AppointmentStatus
                {
                    AppointmentStatusId = appointmentStatusId,
                    CanInvoice = true,
                },
                Location = new Addresses.Address
                {
                    City = new Cities.City
                    {
                        CityId = cityId,
                    },
                },
                Assessment = new Assessments.Assessment
                {
                    AssessmentType = new Assessments.AssessmentType
                    {
                        AssessmentTypeId = assessmentTypeId,
                        Description = assessmentTypeDescription,
                    },
                    FileSize = fileSize,
                    IsLargeFile = isLargeFile,
                    ReferralSource = new Referrals.ReferralSource
                    {
                        ReferralSourceId = referralSourceId,
                    },
                    Reports = new[] {
                        new Reports.Report
                        {
                            IsAdditional = false,
                            IssuesInDispute = issuesInDispute,
                        },
                        new Reports.Report
                        {
                            IsAdditional = false,
                            IssuesInDispute = Enumerable.Empty<Models.Claims.IssueInDispute>(),
                        }
                    },
                    Company = new Companies.Company
                    {
                        CompanyId = companyId,
                    },
                },
                Psychologist = new Users.User { UserId = psychologistId },
            };

            var invoice = psychologistInvoiceGenerator.CreateInvoice(appointment);

            var subtotal = comboReportInvoiceAmount * invoiceRate;

            var expected = Convert.ToInt32(subtotal + (subtotal * taxRate));

            var actual = invoice.Total;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FullFeeIsChargedForNonCompletionStatusSequence()
        {
            var appointmentId = 1;
            var appointmentTime = new DateTimeOffset(2017, 10, 8, 13, 0, 0, TimeSpan.Zero);
            var appointmentStatusId = Appointments.AppointmentStatus.Complete;
            var cityId = 2;
            var assessmentTypeId = 3;
            var assessmentTypeDescription = "Assessment Type";
            var fileSize = 500;
            var isLargeFile = false;
            var largeFileSize = 1000;
            var largeFileFee = 50000;
            var referralSourceId = 4;
            var companyId = 5;
            var psychologistId = 6;
            var psychologist = new Users.User
            {
                UserId = psychologistId,
                TravelFees = Enumerable.Empty<Users.UserTravelFee>(),
            };
            var taxRate = 0.1m;
            var invoiceCount = 0;
            var appointmentSequenceId = Appointments.AppointmentSequence.First;
            var siblingAppointments = Enumerable.Empty<Appointments.Appointment>();
            var singleReportInvoiceAmount = 123400;
            var comboReportInvoiceAmount = 432100;
            var applyCompletionFee = false;
            var applyExtraReportFees = false;
            var applyIssueInDisputeFees = false;
            var applyLargeFileFee = false;
            var applyTravelFee = false;
            var completionFeeAmount = 75000;
            var extraReportFee = 50000;
            var invoiceRate = 1.0m;
            var catastrophicFee = 35000;
            var issuesInDispute = Enumerable.Empty<Models.Claims.IssueInDispute>();
            var issueInDisputeInvoiceAmounts = new[]
            {
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 1, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 2, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 3, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 4, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 5, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 6, }, InvoiceAmount = catastrophicFee },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 7, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 8, }, InvoiceAmount = 0 },
            };

            var psychologistInvoiceGenerator = GetService(
                (invoiceRepositoryMock, appointmentRepositoryMock, referralRepositoryMock, userRepositoryMock, dateMock) =>
                {
                    userRepositoryMock.Setup(ur => ur.GetUserById(It.Is<int>(i => i == psychologistId))).Returns(psychologist);

                    appointmentRepositoryMock
                        .Setup(ar => ar.GetAppointmentSequenceSiblings(It.Is<int>(i => i == appointmentId)))
                        .Returns(() => siblingAppointments);

                    invoiceRepositoryMock.Setup(ir => ir.GetPsychologistInvoiceCalculationData(
                        It.Is<int>(i => i == companyId),
                        It.Is<int>(i => i == referralSourceId),
                        It.Is<int>(i => i == assessmentTypeId),
                        It.Is<int>(i => i == appointmentStatusId),
                        It.Is<int>(i => i == appointmentSequenceId)
                    )).Returns(new PsychologistInvoiceCalculationData
                    {
                        Company = new Companies.Company { CompanyId = companyId, },
                        SingleReportInvoiceAmount = singleReportInvoiceAmount,
                        ComboReportInvoiceAmount = comboReportInvoiceAmount,
                        CompletionFeeAmount = completionFeeAmount,
                        ExtraReportFee = extraReportFee,
                        InvoiceRate = invoiceRate,
                        IssueInDisputeInvoiceAmounts = issueInDisputeInvoiceAmounts,
                        LargeFileSize = largeFileSize,
                        LargeFileFee = largeFileFee,
                        ApplyCompletionFee = applyCompletionFee,
                        ApplyExtraReportFees = applyExtraReportFees,
                        ApplyIssueInDisputeFees = applyIssueInDisputeFees,
                        ApplyLargeFileFee = applyLargeFileFee,
                        ApplyTravelFee = applyTravelFee,
                    });

                    invoiceRepositoryMock
                        .Setup(ir => ir.GetInvoices(It.Is<InvoiceSearchCriteria>(isc =>
                            isc.AppointmentId == appointmentId &&
                            isc.InvoiceTypeId == InvoiceType.Psychologist)))
                        .Returns(() => Enumerable.Empty<Invoice>());

                    invoiceRepositoryMock.Setup(ir => ir.GetInvoiceCount(It.Is<int>(i => i == psychologistId))).Returns(invoiceCount);

                    invoiceRepositoryMock.Setup(ir => ir.GetInitialInvoiceStatus()).Returns(new InvoiceStatus { InvoiceStatusId = InvoiceStatus.Open });

                    invoiceRepositoryMock.Setup(ir => ir.GetTaxRate()).Returns(taxRate);

                    dateMock.SetupGet(d => d.UtcNow).Returns(DateTime.UtcNow);
                });

            var appointment = new Appointments.Appointment
            {
                AppointmentId = appointmentId,
                AppointmentTime = appointmentTime,
                AppointmentStatus = new Appointments.AppointmentStatus
                {
                    AppointmentStatusId = appointmentStatusId,
                    CanInvoice = true,
                },
                Location = new Addresses.Address
                {
                    City = new Cities.City
                    {
                        CityId = cityId,
                    },
                },
                Assessment = new Assessments.Assessment
                {
                    AssessmentType = new Assessments.AssessmentType
                    {
                        AssessmentTypeId = assessmentTypeId,
                        Description = assessmentTypeDescription,
                    },
                    FileSize = fileSize,
                    IsLargeFile = isLargeFile,
                    ReferralSource = new Referrals.ReferralSource
                    {
                        ReferralSourceId = referralSourceId,
                    },
                    Reports = new[] {
                        new Reports.Report
                        {
                            IsAdditional = false,
                            IssuesInDispute = issuesInDispute,
                        },
                    },
                    Company = new Companies.Company
                    {
                        CompanyId = companyId,
                    },
                },
                Psychologist = new Users.User { UserId = psychologistId },
            };

            var invoice = psychologistInvoiceGenerator.CreateInvoice(appointment);

            var subtotal = singleReportInvoiceAmount * invoiceRate;

            var expected = Convert.ToInt32(subtotal + (subtotal * taxRate));

            var actual = invoice.Total;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CompletionFeeIsChargedForCompletionStatusSequence()
        {
            var appointmentId = 1;
            var appointmentTime = new DateTimeOffset(2017, 10, 8, 13, 0, 0, TimeSpan.Zero);
            var appointmentStatusId = Appointments.AppointmentStatus.Complete;
            var cityId = 2;
            var assessmentTypeId = 3;
            var assessmentTypeDescription = "Assessment Type";
            var fileSize = 500;
            var isLargeFile = false;
            var largeFileSize = 1000;
            var largeFileFee = 50000;
            var referralSourceId = 4;
            var companyId = 5;
            var psychologistId = 6;
            var psychologist = new Users.User
            {
                UserId = psychologistId,
                TravelFees = Enumerable.Empty<Users.UserTravelFee>(),
            };
            var taxRate = 0.1m;
            var invoiceCount = 0;
            var appointmentSequenceId = Appointments.AppointmentSequence.First;
            var siblingAppointments = Enumerable.Empty<Appointments.Appointment>();
            var singleReportInvoiceAmount = 123400;
            var comboReportInvoiceAmount = 432100;
            var applyCompletionFee = true;
            var applyExtraReportFees = false;
            var applyIssueInDisputeFees = false;
            var applyLargeFileFee = false;
            var applyTravelFee = false;
            var completionFeeAmount = 75000;
            var extraReportFee = 50000;
            var invoiceRate = 1.0m;
            var catastrophicFee = 35000;
            var issuesInDispute = Enumerable.Empty<Models.Claims.IssueInDispute>();
            var issueInDisputeInvoiceAmounts = new[]
            {
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 1, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 2, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 3, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 4, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 5, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 6, }, InvoiceAmount = catastrophicFee },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 7, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 8, }, InvoiceAmount = 0 },
            };

            var psychologistInvoiceGenerator = GetService(
                (invoiceRepositoryMock, appointmentRepositoryMock, referralRepositoryMock, userRepositoryMock, dateMock) =>
                {
                    userRepositoryMock.Setup(ur => ur.GetUserById(It.Is<int>(i => i == psychologistId))).Returns(psychologist);

                    appointmentRepositoryMock
                        .Setup(ar => ar.GetAppointmentSequenceSiblings(It.Is<int>(i => i == appointmentId)))
                        .Returns(() => siblingAppointments);

                    invoiceRepositoryMock.Setup(ir => ir.GetPsychologistInvoiceCalculationData(
                        It.Is<int>(i => i == companyId),
                        It.Is<int>(i => i == referralSourceId),
                        It.Is<int>(i => i == assessmentTypeId),
                        It.Is<int>(i => i == appointmentStatusId),
                        It.Is<int>(i => i == appointmentSequenceId)
                    )).Returns(new PsychologistInvoiceCalculationData
                    {
                        Company = new Companies.Company { CompanyId = companyId, },
                        SingleReportInvoiceAmount = singleReportInvoiceAmount,
                        ComboReportInvoiceAmount = comboReportInvoiceAmount,
                        CompletionFeeAmount = completionFeeAmount,
                        ExtraReportFee = extraReportFee,
                        InvoiceRate = invoiceRate,
                        IssueInDisputeInvoiceAmounts = issueInDisputeInvoiceAmounts,
                        LargeFileSize = largeFileSize,
                        LargeFileFee = largeFileFee,
                        ApplyCompletionFee = applyCompletionFee,
                        ApplyExtraReportFees = applyExtraReportFees,
                        ApplyIssueInDisputeFees = applyIssueInDisputeFees,
                        ApplyLargeFileFee = applyLargeFileFee,
                        ApplyTravelFee = applyTravelFee,
                    });

                    invoiceRepositoryMock
                        .Setup(ir => ir.GetInvoices(It.Is<InvoiceSearchCriteria>(isc =>
                            isc.AppointmentId == appointmentId &&
                            isc.InvoiceTypeId == InvoiceType.Psychologist)))
                        .Returns(() => Enumerable.Empty<Invoice>());

                    invoiceRepositoryMock.Setup(ir => ir.GetInvoiceCount(It.Is<int>(i => i == psychologistId))).Returns(invoiceCount);

                    invoiceRepositoryMock.Setup(ir => ir.GetInitialInvoiceStatus()).Returns(new InvoiceStatus { InvoiceStatusId = InvoiceStatus.Open });

                    invoiceRepositoryMock.Setup(ir => ir.GetTaxRate()).Returns(taxRate);

                    dateMock.SetupGet(d => d.UtcNow).Returns(DateTime.UtcNow);
                });

            var appointment = new Appointments.Appointment
            {
                AppointmentId = appointmentId,
                AppointmentTime = appointmentTime,
                AppointmentStatus = new Appointments.AppointmentStatus
                {
                    AppointmentStatusId = appointmentStatusId,
                    CanInvoice = true,
                },
                Location = new Addresses.Address
                {
                    City = new Cities.City
                    {
                        CityId = cityId,
                    },
                },
                Assessment = new Assessments.Assessment
                {
                    AssessmentType = new Assessments.AssessmentType
                    {
                        AssessmentTypeId = assessmentTypeId,
                        Description = assessmentTypeDescription,
                    },
                    FileSize = fileSize,
                    IsLargeFile = isLargeFile,
                    ReferralSource = new Referrals.ReferralSource
                    {
                        ReferralSourceId = referralSourceId,
                    },
                    Reports = new[] {
                        new Reports.Report
                        {
                            IsAdditional = false,
                            IssuesInDispute = issuesInDispute,
                        },
                    },
                    Company = new Companies.Company
                    {
                        CompanyId = companyId,
                    },
                },
                Psychologist = new Users.User { UserId = psychologistId },
            };

            var invoice = psychologistInvoiceGenerator.CreateInvoice(appointment);

            var subtotal = completionFeeAmount;

            var expected = Convert.ToInt32(subtotal + (subtotal * taxRate));

            var actual = invoice.Total;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InvoiceRateIsAppliedToBaseCharges()
        {
            var appointmentId = 1;
            var appointmentTime = new DateTimeOffset(2017, 10, 8, 13, 0, 0, TimeSpan.Zero);
            var appointmentStatusId = Appointments.AppointmentStatus.Complete;
            var cityId = 2;
            var assessmentTypeId = 3;
            var assessmentTypeDescription = "Assessment Type";
            var fileSize = 500;
            var isLargeFile = false;
            var largeFileSize = 1000;
            var largeFileFee = 50000;
            var referralSourceId = 4;
            var companyId = 5;
            var psychologistId = 6;
            var psychologist = new Users.User
            {
                UserId = psychologistId,
                TravelFees = Enumerable.Empty<Users.UserTravelFee>(),
            };
            var taxRate = 0.1m;
            var invoiceCount = 0;
            var appointmentSequenceId = Appointments.AppointmentSequence.First;
            var siblingAppointments = Enumerable.Empty<Appointments.Appointment>();
            var singleReportInvoiceAmount = 123400;
            var comboReportInvoiceAmount = 432100;
            var applyCompletionFee = false;
            var applyExtraReportFees = false;
            var applyIssueInDisputeFees = false;
            var applyLargeFileFee = false;
            var applyTravelFee = false;
            var completionFeeAmount = 75000;
            var extraReportFee = 50000;
            var invoiceRate = 1.3m;
            var catastrophicFee = 35000;
            var issuesInDispute = Enumerable.Empty<Models.Claims.IssueInDispute>();
            var issueInDisputeInvoiceAmounts = new[]
            {
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 1, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 2, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 3, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 4, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 5, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 6, }, InvoiceAmount = catastrophicFee },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 7, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 8, }, InvoiceAmount = 0 },
            };

            var psychologistInvoiceGenerator = GetService(
                (invoiceRepositoryMock, appointmentRepositoryMock, referralRepositoryMock, userRepositoryMock, dateMock) =>
                {
                    userRepositoryMock.Setup(ur => ur.GetUserById(It.Is<int>(i => i == psychologistId))).Returns(psychologist);

                    appointmentRepositoryMock
                        .Setup(ar => ar.GetAppointmentSequenceSiblings(It.Is<int>(i => i == appointmentId)))
                        .Returns(() => siblingAppointments);

                    invoiceRepositoryMock.Setup(ir => ir.GetPsychologistInvoiceCalculationData(
                        It.Is<int>(i => i == companyId),
                        It.Is<int>(i => i == referralSourceId),
                        It.Is<int>(i => i == assessmentTypeId),
                        It.Is<int>(i => i == appointmentStatusId),
                        It.Is<int>(i => i == appointmentSequenceId)
                    )).Returns(new PsychologistInvoiceCalculationData
                    {
                        Company = new Companies.Company { CompanyId = companyId, },
                        SingleReportInvoiceAmount = singleReportInvoiceAmount,
                        ComboReportInvoiceAmount = comboReportInvoiceAmount,
                        CompletionFeeAmount = completionFeeAmount,
                        ExtraReportFee = extraReportFee,
                        InvoiceRate = invoiceRate,
                        IssueInDisputeInvoiceAmounts = issueInDisputeInvoiceAmounts,
                        LargeFileSize = largeFileSize,
                        LargeFileFee = largeFileFee,
                        ApplyCompletionFee = applyCompletionFee,
                        ApplyExtraReportFees = applyExtraReportFees,
                        ApplyIssueInDisputeFees = applyIssueInDisputeFees,
                        ApplyLargeFileFee = applyLargeFileFee,
                        ApplyTravelFee = applyTravelFee,
                    });

                    invoiceRepositoryMock
                        .Setup(ir => ir.GetInvoices(It.Is<InvoiceSearchCriteria>(isc =>
                            isc.AppointmentId == appointmentId &&
                            isc.InvoiceTypeId == InvoiceType.Psychologist)))
                        .Returns(() => Enumerable.Empty<Invoice>());

                    invoiceRepositoryMock.Setup(ir => ir.GetInvoiceCount(It.Is<int>(i => i == psychologistId))).Returns(invoiceCount);

                    invoiceRepositoryMock.Setup(ir => ir.GetInitialInvoiceStatus()).Returns(new InvoiceStatus { InvoiceStatusId = InvoiceStatus.Open });

                    invoiceRepositoryMock.Setup(ir => ir.GetTaxRate()).Returns(taxRate);

                    dateMock.SetupGet(d => d.UtcNow).Returns(DateTime.UtcNow);
                });

            var appointment = new Appointments.Appointment
            {
                AppointmentId = appointmentId,
                AppointmentTime = appointmentTime,
                AppointmentStatus = new Appointments.AppointmentStatus
                {
                    AppointmentStatusId = appointmentStatusId,
                    CanInvoice = true,
                },
                Location = new Addresses.Address
                {
                    City = new Cities.City
                    {
                        CityId = cityId,
                    },
                },
                Assessment = new Assessments.Assessment
                {
                    AssessmentType = new Assessments.AssessmentType
                    {
                        AssessmentTypeId = assessmentTypeId,
                        Description = assessmentTypeDescription,
                    },
                    FileSize = fileSize,
                    IsLargeFile = isLargeFile,
                    ReferralSource = new Referrals.ReferralSource
                    {
                        ReferralSourceId = referralSourceId,
                    },
                    Reports = new[] {
                        new Reports.Report
                        {
                            IsAdditional = false,
                            IssuesInDispute = issuesInDispute,
                        },
                    },
                    Company = new Companies.Company
                    {
                        CompanyId = companyId,
                    },
                },
                Psychologist = new Users.User { UserId = psychologistId },
            };

            var invoice = psychologistInvoiceGenerator.CreateInvoice(appointment);

            var subtotal = singleReportInvoiceAmount * invoiceRate;

            var expected = Convert.ToInt32(subtotal + (subtotal * taxRate));

            var actual = invoice.Total;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LargeFileFeeIsAppliedForConfiguredStatusSequenceWhenFileIsLarge()
        {
            var appointmentId = 1;
            var appointmentTime = new DateTimeOffset(2017, 10, 8, 13, 0, 0, TimeSpan.Zero);
            var appointmentStatusId = Appointments.AppointmentStatus.Complete;
            var cityId = 2;
            var assessmentTypeId = 3;
            var assessmentTypeDescription = "Assessment Type";
            var fileSize = 1500;
            var isLargeFile = false;
            var largeFileSize = 1000;
            var largeFileFee = 50000;
            var referralSourceId = 4;
            var companyId = 5;
            var psychologistId = 6;
            var psychologist = new Users.User
            {
                UserId = psychologistId,
                TravelFees = Enumerable.Empty<Users.UserTravelFee>(),
            };
            var taxRate = 0.1m;
            var invoiceCount = 0;
            var appointmentSequenceId = Appointments.AppointmentSequence.First;
            var siblingAppointments = Enumerable.Empty<Appointments.Appointment>();
            var singleReportInvoiceAmount = 123400;
            var comboReportInvoiceAmount = 432100;
            var applyCompletionFee = false;
            var applyExtraReportFees = false;
            var applyIssueInDisputeFees = false;
            var applyLargeFileFee = true;
            var applyTravelFee = false;
            var completionFeeAmount = 75000;
            var extraReportFee = 50000;
            var invoiceRate = 1.3m;
            var catastrophicFee = 35000;
            var issuesInDispute = Enumerable.Empty<Models.Claims.IssueInDispute>();
            var issueInDisputeInvoiceAmounts = new[]
            {
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 1, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 2, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 3, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 4, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 5, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 6, }, InvoiceAmount = catastrophicFee },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 7, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 8, }, InvoiceAmount = 0 },
            };

            var psychologistInvoiceGenerator = GetService(
                (invoiceRepositoryMock, appointmentRepositoryMock, referralRepositoryMock, userRepositoryMock, dateMock) =>
                {
                    userRepositoryMock.Setup(ur => ur.GetUserById(It.Is<int>(i => i == psychologistId))).Returns(psychologist);

                    appointmentRepositoryMock
                        .Setup(ar => ar.GetAppointmentSequenceSiblings(It.Is<int>(i => i == appointmentId)))
                        .Returns(() => siblingAppointments);

                    invoiceRepositoryMock.Setup(ir => ir.GetPsychologistInvoiceCalculationData(
                        It.Is<int>(i => i == companyId),
                        It.Is<int>(i => i == referralSourceId),
                        It.Is<int>(i => i == assessmentTypeId),
                        It.Is<int>(i => i == appointmentStatusId),
                        It.Is<int>(i => i == appointmentSequenceId)
                    )).Returns(new PsychologistInvoiceCalculationData
                    {
                        Company = new Companies.Company { CompanyId = companyId, },
                        SingleReportInvoiceAmount = singleReportInvoiceAmount,
                        ComboReportInvoiceAmount = comboReportInvoiceAmount,
                        CompletionFeeAmount = completionFeeAmount,
                        ExtraReportFee = extraReportFee,
                        InvoiceRate = invoiceRate,
                        IssueInDisputeInvoiceAmounts = issueInDisputeInvoiceAmounts,
                        LargeFileSize = largeFileSize,
                        LargeFileFee = largeFileFee,
                        ApplyCompletionFee = applyCompletionFee,
                        ApplyExtraReportFees = applyExtraReportFees,
                        ApplyIssueInDisputeFees = applyIssueInDisputeFees,
                        ApplyLargeFileFee = applyLargeFileFee,
                        ApplyTravelFee = applyTravelFee,
                    });

                    invoiceRepositoryMock
                        .Setup(ir => ir.GetInvoices(It.Is<InvoiceSearchCriteria>(isc =>
                            isc.AppointmentId == appointmentId &&
                            isc.InvoiceTypeId == InvoiceType.Psychologist)))
                        .Returns(() => Enumerable.Empty<Invoice>());

                    invoiceRepositoryMock.Setup(ir => ir.GetInvoiceCount(It.Is<int>(i => i == psychologistId))).Returns(invoiceCount);

                    invoiceRepositoryMock.Setup(ir => ir.GetInitialInvoiceStatus()).Returns(new InvoiceStatus { InvoiceStatusId = InvoiceStatus.Open });

                    invoiceRepositoryMock.Setup(ir => ir.GetTaxRate()).Returns(taxRate);

                    dateMock.SetupGet(d => d.UtcNow).Returns(DateTime.UtcNow);
                });

            var appointment = new Appointments.Appointment
            {
                AppointmentId = appointmentId,
                AppointmentTime = appointmentTime,
                AppointmentStatus = new Appointments.AppointmentStatus
                {
                    AppointmentStatusId = appointmentStatusId,
                    CanInvoice = true,
                },
                Location = new Addresses.Address
                {
                    City = new Cities.City
                    {
                        CityId = cityId,
                    },
                },
                Assessment = new Assessments.Assessment
                {
                    AssessmentType = new Assessments.AssessmentType
                    {
                        AssessmentTypeId = assessmentTypeId,
                        Description = assessmentTypeDescription,
                    },
                    FileSize = fileSize,
                    IsLargeFile = isLargeFile,
                    ReferralSource = new Referrals.ReferralSource
                    {
                        ReferralSourceId = referralSourceId,
                    },
                    Reports = new[] {
                        new Reports.Report
                        {
                            IsAdditional = false,
                            IssuesInDispute = issuesInDispute,
                        },
                    },
                    Company = new Companies.Company
                    {
                        CompanyId = companyId,
                    },
                },
                Psychologist = new Users.User { UserId = psychologistId },
            };

            var invoice = psychologistInvoiceGenerator.CreateInvoice(appointment);

            var subtotal = (singleReportInvoiceAmount * invoiceRate) + largeFileFee;

            var expected = Convert.ToInt32(subtotal + (subtotal * taxRate));

            var actual = invoice.Total;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LargeFileFeeIsNotAppliedForConfiguredStatusSequenceWhenFileIsNotLarge()
        {
            var appointmentId = 1;
            var appointmentTime = new DateTimeOffset(2017, 10, 8, 13, 0, 0, TimeSpan.Zero);
            var appointmentStatusId = Appointments.AppointmentStatus.Complete;
            var cityId = 2;
            var assessmentTypeId = 3;
            var assessmentTypeDescription = "Assessment Type";
            var fileSize = 500;
            var isLargeFile = false;
            var largeFileSize = 1000;
            var largeFileFee = 50000;
            var referralSourceId = 4;
            var companyId = 5;
            var psychologistId = 6;
            var psychologist = new Users.User
            {
                UserId = psychologistId,
                TravelFees = Enumerable.Empty<Users.UserTravelFee>(),
            };
            var taxRate = 0.1m;
            var invoiceCount = 0;
            var appointmentSequenceId = Appointments.AppointmentSequence.First;
            var siblingAppointments = Enumerable.Empty<Appointments.Appointment>();
            var singleReportInvoiceAmount = 123400;
            var comboReportInvoiceAmount = 432100;
            var applyCompletionFee = false;
            var applyExtraReportFees = false;
            var applyIssueInDisputeFees = false;
            var applyLargeFileFee = true;
            var applyTravelFee = false;
            var completionFeeAmount = 75000;
            var extraReportFee = 50000;
            var invoiceRate = 1.3m;
            var catastrophicFee = 35000;
            var issuesInDispute = Enumerable.Empty<Models.Claims.IssueInDispute>();
            var issueInDisputeInvoiceAmounts = new[]
            {
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 1, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 2, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 3, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 4, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 5, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 6, }, InvoiceAmount = catastrophicFee },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 7, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 8, }, InvoiceAmount = 0 },
            };

            var psychologistInvoiceGenerator = GetService(
                (invoiceRepositoryMock, appointmentRepositoryMock, referralRepositoryMock, userRepositoryMock, dateMock) =>
                {
                    userRepositoryMock.Setup(ur => ur.GetUserById(It.Is<int>(i => i == psychologistId))).Returns(psychologist);

                    appointmentRepositoryMock
                        .Setup(ar => ar.GetAppointmentSequenceSiblings(It.Is<int>(i => i == appointmentId)))
                        .Returns(() => siblingAppointments);

                    invoiceRepositoryMock.Setup(ir => ir.GetPsychologistInvoiceCalculationData(
                        It.Is<int>(i => i == companyId),
                        It.Is<int>(i => i == referralSourceId),
                        It.Is<int>(i => i == assessmentTypeId),
                        It.Is<int>(i => i == appointmentStatusId),
                        It.Is<int>(i => i == appointmentSequenceId)
                    )).Returns(new PsychologistInvoiceCalculationData
                    {
                        Company = new Companies.Company { CompanyId = companyId, },
                        SingleReportInvoiceAmount = singleReportInvoiceAmount,
                        ComboReportInvoiceAmount = comboReportInvoiceAmount,
                        CompletionFeeAmount = completionFeeAmount,
                        ExtraReportFee = extraReportFee,
                        InvoiceRate = invoiceRate,
                        IssueInDisputeInvoiceAmounts = issueInDisputeInvoiceAmounts,
                        LargeFileSize = largeFileSize,
                        LargeFileFee = largeFileFee,
                        ApplyCompletionFee = applyCompletionFee,
                        ApplyExtraReportFees = applyExtraReportFees,
                        ApplyIssueInDisputeFees = applyIssueInDisputeFees,
                        ApplyLargeFileFee = applyLargeFileFee,
                        ApplyTravelFee = applyTravelFee,
                    });

                    invoiceRepositoryMock
                        .Setup(ir => ir.GetInvoices(It.Is<InvoiceSearchCriteria>(isc =>
                            isc.AppointmentId == appointmentId &&
                            isc.InvoiceTypeId == InvoiceType.Psychologist)))
                        .Returns(() => Enumerable.Empty<Invoice>());

                    invoiceRepositoryMock.Setup(ir => ir.GetInvoiceCount(It.Is<int>(i => i == psychologistId))).Returns(invoiceCount);

                    invoiceRepositoryMock.Setup(ir => ir.GetInitialInvoiceStatus()).Returns(new InvoiceStatus { InvoiceStatusId = InvoiceStatus.Open });

                    invoiceRepositoryMock.Setup(ir => ir.GetTaxRate()).Returns(taxRate);

                    dateMock.SetupGet(d => d.UtcNow).Returns(DateTime.UtcNow);
                });

            var appointment = new Appointments.Appointment
            {
                AppointmentId = appointmentId,
                AppointmentTime = appointmentTime,
                AppointmentStatus = new Appointments.AppointmentStatus
                {
                    AppointmentStatusId = appointmentStatusId,
                    CanInvoice = true,
                },
                Location = new Addresses.Address
                {
                    City = new Cities.City
                    {
                        CityId = cityId,
                    },
                },
                Assessment = new Assessments.Assessment
                {
                    AssessmentType = new Assessments.AssessmentType
                    {
                        AssessmentTypeId = assessmentTypeId,
                        Description = assessmentTypeDescription,
                    },
                    FileSize = fileSize,
                    IsLargeFile = isLargeFile,
                    ReferralSource = new Referrals.ReferralSource
                    {
                        ReferralSourceId = referralSourceId,
                    },
                    Reports = new[] {
                        new Reports.Report
                        {
                            IsAdditional = false,
                            IssuesInDispute = issuesInDispute,
                        },
                    },
                    Company = new Companies.Company
                    {
                        CompanyId = companyId,
                    },
                },
                Psychologist = new Users.User { UserId = psychologistId },
            };

            var invoice = psychologistInvoiceGenerator.CreateInvoice(appointment);

            var subtotal = (singleReportInvoiceAmount * invoiceRate);

            var expected = Convert.ToInt32(subtotal + (subtotal * taxRate));

            var actual = invoice.Total;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TravelFeeIsAppliedForStatusSequenceWhenAppointmentIsInTravelFeeCity()
        {
            var appointmentId = 1;
            var appointmentTime = new DateTimeOffset(2017, 10, 8, 13, 0, 0, TimeSpan.Zero);
            var appointmentStatusId = Appointments.AppointmentStatus.Complete;
            var cityId = 2;
            var assessmentTypeId = 3;
            var assessmentTypeDescription = "Assessment Type";
            var fileSize = 500;
            var isLargeFile = false;
            var largeFileSize = 1000;
            var largeFileFee = 50000;
            var referralSourceId = 4;
            var companyId = 5;
            var travelFeeAmount = 22500;
            var psychologistId = 6;
            var psychologist = new Users.User
            {
                UserId = psychologistId,
                TravelFees = new[]
                {
                    new Users.UserTravelFee
                    {
                        City = new Cities.City { CityId = cityId },
                        Amount = travelFeeAmount,
                    }
                },
            };
            var taxRate = 0.1m;
            var invoiceCount = 0;
            var appointmentSequenceId = Appointments.AppointmentSequence.First;
            var siblingAppointments = Enumerable.Empty<Appointments.Appointment>();
            var singleReportInvoiceAmount = 123400;
            var comboReportInvoiceAmount = 432100;
            var applyCompletionFee = false;
            var applyExtraReportFees = false;
            var applyIssueInDisputeFees = false;
            var applyLargeFileFee = false;
            var applyTravelFee = true;
            var completionFeeAmount = 75000;
            var extraReportFee = 50000;
            var invoiceRate = 1.3m;
            var catastrophicFee = 35000;
            var issuesInDispute = Enumerable.Empty<Models.Claims.IssueInDispute>();
            var issueInDisputeInvoiceAmounts = new[]
            {
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 1, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 2, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 3, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 4, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 5, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 6, }, InvoiceAmount = catastrophicFee },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 7, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 8, }, InvoiceAmount = 0 },
            };

            var psychologistInvoiceGenerator = GetService(
                (invoiceRepositoryMock, appointmentRepositoryMock, referralRepositoryMock, userRepositoryMock, dateMock) =>
                {
                    userRepositoryMock.Setup(ur => ur.GetUserById(It.Is<int>(i => i == psychologistId))).Returns(psychologist);

                    appointmentRepositoryMock
                        .Setup(ar => ar.GetAppointmentSequenceSiblings(It.Is<int>(i => i == appointmentId)))
                        .Returns(() => siblingAppointments);

                    invoiceRepositoryMock.Setup(ir => ir.GetPsychologistInvoiceCalculationData(
                        It.Is<int>(i => i == companyId),
                        It.Is<int>(i => i == referralSourceId),
                        It.Is<int>(i => i == assessmentTypeId),
                        It.Is<int>(i => i == appointmentStatusId),
                        It.Is<int>(i => i == appointmentSequenceId)
                    )).Returns(new PsychologistInvoiceCalculationData
                    {
                        Company = new Companies.Company { CompanyId = companyId, },
                        SingleReportInvoiceAmount = singleReportInvoiceAmount,
                        ComboReportInvoiceAmount = comboReportInvoiceAmount,
                        CompletionFeeAmount = completionFeeAmount,
                        ExtraReportFee = extraReportFee,
                        InvoiceRate = invoiceRate,
                        IssueInDisputeInvoiceAmounts = issueInDisputeInvoiceAmounts,
                        LargeFileSize = largeFileSize,
                        LargeFileFee = largeFileFee,
                        ApplyCompletionFee = applyCompletionFee,
                        ApplyExtraReportFees = applyExtraReportFees,
                        ApplyIssueInDisputeFees = applyIssueInDisputeFees,
                        ApplyLargeFileFee = applyLargeFileFee,
                        ApplyTravelFee = applyTravelFee,
                    });

                    invoiceRepositoryMock
                        .Setup(ir => ir.GetInvoices(It.Is<InvoiceSearchCriteria>(isc =>
                            isc.AppointmentId == appointmentId &&
                            isc.InvoiceTypeId == InvoiceType.Psychologist)))
                        .Returns(() => Enumerable.Empty<Invoice>());

                    invoiceRepositoryMock.Setup(ir => ir.GetInvoiceCount(It.Is<int>(i => i == psychologistId))).Returns(invoiceCount);

                    invoiceRepositoryMock.Setup(ir => ir.GetInitialInvoiceStatus()).Returns(new InvoiceStatus { InvoiceStatusId = InvoiceStatus.Open });

                    invoiceRepositoryMock.Setup(ir => ir.GetTaxRate()).Returns(taxRate);

                    dateMock.SetupGet(d => d.UtcNow).Returns(DateTime.UtcNow);
                });

            var appointment = new Appointments.Appointment
            {
                AppointmentId = appointmentId,
                AppointmentTime = appointmentTime,
                AppointmentStatus = new Appointments.AppointmentStatus
                {
                    AppointmentStatusId = appointmentStatusId,
                    CanInvoice = true,
                },
                Location = new Addresses.Address
                {
                    City = new Cities.City
                    {
                        CityId = cityId,
                    },
                },
                Assessment = new Assessments.Assessment
                {
                    AssessmentType = new Assessments.AssessmentType
                    {
                        AssessmentTypeId = assessmentTypeId,
                        Description = assessmentTypeDescription,
                    },
                    FileSize = fileSize,
                    IsLargeFile = isLargeFile,
                    ReferralSource = new Referrals.ReferralSource
                    {
                        ReferralSourceId = referralSourceId,
                    },
                    Reports = new[] {
                        new Reports.Report
                        {
                            IsAdditional = false,
                            IssuesInDispute = issuesInDispute,
                        },
                    },
                    Company = new Companies.Company
                    {
                        CompanyId = companyId,
                    },
                },
                Psychologist = new Users.User { UserId = psychologistId },
            };

            var invoice = psychologistInvoiceGenerator.CreateInvoice(appointment);

            var subtotal = (singleReportInvoiceAmount * invoiceRate) + travelFeeAmount;

            var expected = Convert.ToInt32(subtotal + (subtotal * taxRate));

            var actual = invoice.Total;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TravelFeeIsNotAppliedForStatusSequenceWhenAppointmentIsNotInTravelFeeCity()
        {
            var appointmentId = 1;
            var appointmentTime = new DateTimeOffset(2017, 10, 8, 13, 0, 0, TimeSpan.Zero);
            var appointmentStatusId = Appointments.AppointmentStatus.Complete;
            var cityId = 2;
            var assessmentTypeId = 3;
            var assessmentTypeDescription = "Assessment Type";
            var fileSize = 500;
            var isLargeFile = false;
            var largeFileSize = 1000;
            var largeFileFee = 50000;
            var referralSourceId = 4;
            var companyId = 5;
            var travelFeeAmount = 22500;
            var psychologistId = 6;
            var psychologist = new Users.User
            {
                UserId = psychologistId,
                TravelFees = new[]
                {
                    new Users.UserTravelFee
                    {
                        City = new Cities.City { CityId = 7 },
                        Amount = travelFeeAmount,
                    }
                },
            };
            var taxRate = 0.1m;
            var invoiceCount = 0;
            var appointmentSequenceId = Appointments.AppointmentSequence.First;
            var siblingAppointments = Enumerable.Empty<Appointments.Appointment>();
            var singleReportInvoiceAmount = 123400;
            var comboReportInvoiceAmount = 432100;
            var applyCompletionFee = false;
            var applyExtraReportFees = false;
            var applyIssueInDisputeFees = false;
            var applyLargeFileFee = false;
            var applyTravelFee = true;
            var completionFeeAmount = 75000;
            var extraReportFee = 50000;
            var invoiceRate = 1.3m;
            var catastrophicFee = 35000;
            var issuesInDispute = Enumerable.Empty<Models.Claims.IssueInDispute>();
            var issueInDisputeInvoiceAmounts = new[]
            {
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 1, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 2, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 3, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 4, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 5, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 6, }, InvoiceAmount = catastrophicFee },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 7, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 8, }, InvoiceAmount = 0 },
            };

            var psychologistInvoiceGenerator = GetService(
                (invoiceRepositoryMock, appointmentRepositoryMock, referralRepositoryMock, userRepositoryMock, dateMock) =>
                {
                    userRepositoryMock.Setup(ur => ur.GetUserById(It.Is<int>(i => i == psychologistId))).Returns(psychologist);

                    appointmentRepositoryMock
                        .Setup(ar => ar.GetAppointmentSequenceSiblings(It.Is<int>(i => i == appointmentId)))
                        .Returns(() => siblingAppointments);

                    invoiceRepositoryMock.Setup(ir => ir.GetPsychologistInvoiceCalculationData(
                        It.Is<int>(i => i == companyId),
                        It.Is<int>(i => i == referralSourceId),
                        It.Is<int>(i => i == assessmentTypeId),
                        It.Is<int>(i => i == appointmentStatusId),
                        It.Is<int>(i => i == appointmentSequenceId)
                    )).Returns(new PsychologistInvoiceCalculationData
                    {
                        Company = new Companies.Company { CompanyId = companyId, },
                        SingleReportInvoiceAmount = singleReportInvoiceAmount,
                        ComboReportInvoiceAmount = comboReportInvoiceAmount,
                        CompletionFeeAmount = completionFeeAmount,
                        ExtraReportFee = extraReportFee,
                        InvoiceRate = invoiceRate,
                        IssueInDisputeInvoiceAmounts = issueInDisputeInvoiceAmounts,
                        LargeFileSize = largeFileSize,
                        LargeFileFee = largeFileFee,
                        ApplyCompletionFee = applyCompletionFee,
                        ApplyExtraReportFees = applyExtraReportFees,
                        ApplyIssueInDisputeFees = applyIssueInDisputeFees,
                        ApplyLargeFileFee = applyLargeFileFee,
                        ApplyTravelFee = applyTravelFee,
                    });

                    invoiceRepositoryMock
                        .Setup(ir => ir.GetInvoices(It.Is<InvoiceSearchCriteria>(isc =>
                            isc.AppointmentId == appointmentId &&
                            isc.InvoiceTypeId == InvoiceType.Psychologist)))
                        .Returns(() => Enumerable.Empty<Invoice>());

                    invoiceRepositoryMock.Setup(ir => ir.GetInvoiceCount(It.Is<int>(i => i == psychologistId))).Returns(invoiceCount);

                    invoiceRepositoryMock.Setup(ir => ir.GetInitialInvoiceStatus()).Returns(new InvoiceStatus { InvoiceStatusId = InvoiceStatus.Open });

                    invoiceRepositoryMock.Setup(ir => ir.GetTaxRate()).Returns(taxRate);

                    dateMock.SetupGet(d => d.UtcNow).Returns(DateTime.UtcNow);
                });

            var appointment = new Appointments.Appointment
            {
                AppointmentId = appointmentId,
                AppointmentTime = appointmentTime,
                AppointmentStatus = new Appointments.AppointmentStatus
                {
                    AppointmentStatusId = appointmentStatusId,
                    CanInvoice = true,
                },
                Location = new Addresses.Address
                {
                    City = new Cities.City
                    {
                        CityId = cityId,
                    },
                },
                Assessment = new Assessments.Assessment
                {
                    AssessmentType = new Assessments.AssessmentType
                    {
                        AssessmentTypeId = assessmentTypeId,
                        Description = assessmentTypeDescription,
                    },
                    FileSize = fileSize,
                    IsLargeFile = isLargeFile,
                    ReferralSource = new Referrals.ReferralSource
                    {
                        ReferralSourceId = referralSourceId,
                    },
                    Reports = new[] {
                        new Reports.Report
                        {
                            IsAdditional = false,
                            IssuesInDispute = issuesInDispute,
                        },
                    },
                    Company = new Companies.Company
                    {
                        CompanyId = companyId,
                    },
                },
                Psychologist = new Users.User { UserId = psychologistId },
            };

            var invoice = psychologistInvoiceGenerator.CreateInvoice(appointment);

            var subtotal = (singleReportInvoiceAmount * invoiceRate);

            var expected = Convert.ToInt32(subtotal + (subtotal * taxRate));

            var actual = invoice.Total;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IssueInDisputeFeeIsAppliedForStatusSequence()
        {
            var appointmentId = 1;
            var appointmentTime = new DateTimeOffset(2017, 10, 8, 13, 0, 0, TimeSpan.Zero);
            var appointmentStatusId = Appointments.AppointmentStatus.Complete;
            var cityId = 2;
            var assessmentTypeId = 3;
            var assessmentTypeDescription = "Assessment Type";
            var fileSize = 500;
            var isLargeFile = false;
            var largeFileSize = 1000;
            var largeFileFee = 50000;
            var referralSourceId = 4;
            var companyId = 5;
            var psychologistId = 6;
            var psychologist = new Users.User
            {
                UserId = psychologistId,
                TravelFees = Enumerable.Empty<Users.UserTravelFee>(),
            };
            var taxRate = 0.1m;
            var invoiceCount = 0;
            var appointmentSequenceId = Appointments.AppointmentSequence.First;
            var siblingAppointments = Enumerable.Empty<Appointments.Appointment>();
            var singleReportInvoiceAmount = 123400;
            var comboReportInvoiceAmount = 432100;
            var applyCompletionFee = false;
            var applyExtraReportFees = false;
            var applyIssueInDisputeFees = true;
            var applyLargeFileFee = false;
            var applyTravelFee = false;
            var completionFeeAmount = 75000;
            var extraReportFee = 50000;
            var invoiceRate = 1.3m;
            var catastrophicId = 6;
            var catastrophicFee = 35000;
            var issuesInDispute = new[]
            {
                new Models.Claims.IssueInDispute { IssueInDisputeId = catastrophicId, },
            };
            var issueInDisputeInvoiceAmounts = new[]
            {
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 1, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 2, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 3, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 4, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 5, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = catastrophicId, }, InvoiceAmount = catastrophicFee },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 7, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 8, }, InvoiceAmount = 0 },
            };

            var psychologistInvoiceGenerator = GetService(
                (invoiceRepositoryMock, appointmentRepositoryMock, referralRepositoryMock, userRepositoryMock, dateMock) =>
                {
                    userRepositoryMock.Setup(ur => ur.GetUserById(It.Is<int>(i => i == psychologistId))).Returns(psychologist);

                    appointmentRepositoryMock
                        .Setup(ar => ar.GetAppointmentSequenceSiblings(It.Is<int>(i => i == appointmentId)))
                        .Returns(() => siblingAppointments);

                    invoiceRepositoryMock.Setup(ir => ir.GetPsychologistInvoiceCalculationData(
                        It.Is<int>(i => i == companyId),
                        It.Is<int>(i => i == referralSourceId),
                        It.Is<int>(i => i == assessmentTypeId),
                        It.Is<int>(i => i == appointmentStatusId),
                        It.Is<int>(i => i == appointmentSequenceId)
                    )).Returns(new PsychologistInvoiceCalculationData
                    {
                        Company = new Companies.Company { CompanyId = companyId, },
                        SingleReportInvoiceAmount = singleReportInvoiceAmount,
                        ComboReportInvoiceAmount = comboReportInvoiceAmount,
                        CompletionFeeAmount = completionFeeAmount,
                        ExtraReportFee = extraReportFee,
                        InvoiceRate = invoiceRate,
                        IssueInDisputeInvoiceAmounts = issueInDisputeInvoiceAmounts,
                        LargeFileSize = largeFileSize,
                        LargeFileFee = largeFileFee,
                        ApplyCompletionFee = applyCompletionFee,
                        ApplyExtraReportFees = applyExtraReportFees,
                        ApplyIssueInDisputeFees = applyIssueInDisputeFees,
                        ApplyLargeFileFee = applyLargeFileFee,
                        ApplyTravelFee = applyTravelFee,
                    });

                    invoiceRepositoryMock
                        .Setup(ir => ir.GetInvoices(It.Is<InvoiceSearchCriteria>(isc =>
                            isc.AppointmentId == appointmentId &&
                            isc.InvoiceTypeId == InvoiceType.Psychologist)))
                        .Returns(() => Enumerable.Empty<Invoice>());

                    invoiceRepositoryMock.Setup(ir => ir.GetInvoiceCount(It.Is<int>(i => i == psychologistId))).Returns(invoiceCount);

                    invoiceRepositoryMock.Setup(ir => ir.GetInitialInvoiceStatus()).Returns(new InvoiceStatus { InvoiceStatusId = InvoiceStatus.Open });

                    invoiceRepositoryMock.Setup(ir => ir.GetTaxRate()).Returns(taxRate);

                    dateMock.SetupGet(d => d.UtcNow).Returns(DateTime.UtcNow);
                });

            var appointment = new Appointments.Appointment
            {
                AppointmentId = appointmentId,
                AppointmentTime = appointmentTime,
                AppointmentStatus = new Appointments.AppointmentStatus
                {
                    AppointmentStatusId = appointmentStatusId,
                    CanInvoice = true,
                },
                Location = new Addresses.Address
                {
                    City = new Cities.City
                    {
                        CityId = cityId,
                    },
                },
                Assessment = new Assessments.Assessment
                {
                    AssessmentType = new Assessments.AssessmentType
                    {
                        AssessmentTypeId = assessmentTypeId,
                        Description = assessmentTypeDescription,
                    },
                    FileSize = fileSize,
                    IsLargeFile = isLargeFile,
                    ReferralSource = new Referrals.ReferralSource
                    {
                        ReferralSourceId = referralSourceId,
                    },
                    Reports = new[] {
                        new Reports.Report
                        {
                            IsAdditional = false,
                            IssuesInDispute = issuesInDispute,
                        },
                    },
                    Company = new Companies.Company
                    {
                        CompanyId = companyId,
                    },
                },
                Psychologist = new Users.User { UserId = psychologistId },
            };

            var invoice = psychologistInvoiceGenerator.CreateInvoice(appointment);

            var subtotal = ((singleReportInvoiceAmount + catastrophicFee) * invoiceRate);

            var expected = Convert.ToInt32(subtotal + (subtotal * taxRate));

            var actual = invoice.Total;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ExtraReportFeeIsAppliedForConfiguredStatusSequence()
        {
            var appointmentId = 1;
            var appointmentTime = new DateTimeOffset(2017, 10, 8, 13, 0, 0, TimeSpan.Zero);
            var appointmentStatusId = Appointments.AppointmentStatus.Complete;
            var cityId = 2;
            var assessmentTypeId = 3;
            var assessmentTypeDescription = "Assessment Type";
            var fileSize = 500;
            var isLargeFile = false;
            var largeFileSize = 1000;
            var largeFileFee = 50000;
            var referralSourceId = 4;
            var companyId = 5;
            var psychologistId = 6;
            var psychologist = new Users.User
            {
                UserId = psychologistId,
                TravelFees = Enumerable.Empty<Users.UserTravelFee>(),
            };
            var taxRate = 0.1m;
            var invoiceCount = 0;
            var appointmentSequenceId = Appointments.AppointmentSequence.First;
            var siblingAppointments = Enumerable.Empty<Appointments.Appointment>();
            var singleReportInvoiceAmount = 123400;
            var comboReportInvoiceAmount = 432100;
            var applyCompletionFee = false;
            var applyExtraReportFees = true;
            var applyIssueInDisputeFees = false;
            var applyLargeFileFee = false;
            var applyTravelFee = false;
            var completionFeeAmount = 75000;
            var extraReportFee = 50000;
            var invoiceRate = 1.3m;
            var catastrophicFee = 35000;
            var issuesInDispute = Enumerable.Empty<Models.Claims.IssueInDispute>();
            var issueInDisputeInvoiceAmounts = new[]
            {
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 1, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 2, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 3, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 4, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 5, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 6, }, InvoiceAmount = catastrophicFee },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 7, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 8, }, InvoiceAmount = 0 },
            };

            var psychologistInvoiceGenerator = GetService(
                (invoiceRepositoryMock, appointmentRepositoryMock, referralRepositoryMock, userRepositoryMock, dateMock) =>
                {
                    userRepositoryMock.Setup(ur => ur.GetUserById(It.Is<int>(i => i == psychologistId))).Returns(psychologist);

                    appointmentRepositoryMock
                        .Setup(ar => ar.GetAppointmentSequenceSiblings(It.Is<int>(i => i == appointmentId)))
                        .Returns(() => siblingAppointments);

                    invoiceRepositoryMock.Setup(ir => ir.GetPsychologistInvoiceCalculationData(
                        It.Is<int>(i => i == companyId),
                        It.Is<int>(i => i == referralSourceId),
                        It.Is<int>(i => i == assessmentTypeId),
                        It.Is<int>(i => i == appointmentStatusId),
                        It.Is<int>(i => i == appointmentSequenceId)
                    )).Returns(new PsychologistInvoiceCalculationData
                    {
                        Company = new Companies.Company { CompanyId = companyId, },
                        SingleReportInvoiceAmount = singleReportInvoiceAmount,
                        ComboReportInvoiceAmount = comboReportInvoiceAmount,
                        CompletionFeeAmount = completionFeeAmount,
                        ExtraReportFee = extraReportFee,
                        InvoiceRate = invoiceRate,
                        IssueInDisputeInvoiceAmounts = issueInDisputeInvoiceAmounts,
                        LargeFileSize = largeFileSize,
                        LargeFileFee = largeFileFee,
                        ApplyCompletionFee = applyCompletionFee,
                        ApplyExtraReportFees = applyExtraReportFees,
                        ApplyIssueInDisputeFees = applyIssueInDisputeFees,
                        ApplyLargeFileFee = applyLargeFileFee,
                        ApplyTravelFee = applyTravelFee,
                    });

                    invoiceRepositoryMock
                        .Setup(ir => ir.GetInvoices(It.Is<InvoiceSearchCriteria>(isc =>
                            isc.AppointmentId == appointmentId &&
                            isc.InvoiceTypeId == InvoiceType.Psychologist)))
                        .Returns(() => Enumerable.Empty<Invoice>());

                    invoiceRepositoryMock.Setup(ir => ir.GetInvoiceCount(It.Is<int>(i => i == psychologistId))).Returns(invoiceCount);

                    invoiceRepositoryMock.Setup(ir => ir.GetInitialInvoiceStatus()).Returns(new InvoiceStatus { InvoiceStatusId = InvoiceStatus.Open });

                    invoiceRepositoryMock.Setup(ir => ir.GetTaxRate()).Returns(taxRate);

                    dateMock.SetupGet(d => d.UtcNow).Returns(DateTime.UtcNow);
                });

            var appointment = new Appointments.Appointment
            {
                AppointmentId = appointmentId,
                AppointmentTime = appointmentTime,
                AppointmentStatus = new Appointments.AppointmentStatus
                {
                    AppointmentStatusId = appointmentStatusId,
                    CanInvoice = true,
                },
                Location = new Addresses.Address
                {
                    City = new Cities.City
                    {
                        CityId = cityId,
                    },
                },
                Assessment = new Assessments.Assessment
                {
                    AssessmentType = new Assessments.AssessmentType
                    {
                        AssessmentTypeId = assessmentTypeId,
                        Description = assessmentTypeDescription,
                    },
                    FileSize = fileSize,
                    IsLargeFile = isLargeFile,
                    ReferralSource = new Referrals.ReferralSource
                    {
                        ReferralSourceId = referralSourceId,
                    },
                    Reports = new[] {
                        new Reports.Report
                        {
                            IsAdditional = false,
                            IssuesInDispute = issuesInDispute,
                        },
                        new Reports.Report
                        {
                            IsAdditional = true,
                            IssuesInDispute = issuesInDispute,
                        },
                    },
                    Company = new Companies.Company
                    {
                        CompanyId = companyId,
                    },
                },
                Psychologist = new Users.User { UserId = psychologistId },
            };

            var invoice = psychologistInvoiceGenerator.CreateInvoice(appointment);

            var subtotal = ((singleReportInvoiceAmount + extraReportFee) * invoiceRate);

            var expected = Convert.ToInt32(subtotal + (subtotal * taxRate));

            var actual = invoice.Total;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RoomRentalFeeIsApplied()
        {
            var appointmentId = 1;
            var appointmentTime = new DateTimeOffset(2017, 10, 8, 13, 0, 0, TimeSpan.Zero);
            var appointmentStatusId = Appointments.AppointmentStatus.Complete;
            var cityId = 2;
            var assessmentTypeId = 3;
            var assessmentTypeDescription = "Assessment Type";
            var fileSize = 500;
            var isLargeFile = false;
            var largeFileSize = 1000;
            var largeFileFee = 50000;
            var referralSourceId = 4;
            var companyId = 5;
            var psychologistId = 6;
            var psychologist = new Users.User
            {
                UserId = psychologistId,
                TravelFees = Enumerable.Empty<Users.UserTravelFee>(),
            };
            var taxRate = 0.1m;
            var invoiceCount = 0;
            var appointmentSequenceId = Appointments.AppointmentSequence.First;
            var siblingAppointments = Enumerable.Empty<Appointments.Appointment>();
            var singleReportInvoiceAmount = 123400;
            var comboReportInvoiceAmount = 432100;
            var applyCompletionFee = false;
            var applyExtraReportFees = true;
            var applyIssueInDisputeFees = false;
            var applyLargeFileFee = false;
            var applyTravelFee = false;
            var completionFeeAmount = 75000;
            var extraReportFee = 50000;
            var roomRentalFee = 40000;
            var invoiceRate = 1.3m;
            var catastrophicFee = 35000;
            var issuesInDispute = Enumerable.Empty<Models.Claims.IssueInDispute>();
            var issueInDisputeInvoiceAmounts = new[]
            {
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 1, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 2, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 3, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 4, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 5, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 6, }, InvoiceAmount = catastrophicFee },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 7, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 8, }, InvoiceAmount = 0 },
            };

            var psychologistInvoiceGenerator = GetService(
                (invoiceRepositoryMock, appointmentRepositoryMock, referralRepositoryMock, userRepositoryMock, dateMock) =>
                {
                    userRepositoryMock.Setup(ur => ur.GetUserById(It.Is<int>(i => i == psychologistId))).Returns(psychologist);

                    appointmentRepositoryMock
                        .Setup(ar => ar.GetAppointmentSequenceSiblings(It.Is<int>(i => i == appointmentId)))
                        .Returns(() => siblingAppointments);

                    invoiceRepositoryMock.Setup(ir => ir.GetPsychologistInvoiceCalculationData(
                        It.Is<int>(i => i == companyId),
                        It.Is<int>(i => i == referralSourceId),
                        It.Is<int>(i => i == assessmentTypeId),
                        It.Is<int>(i => i == appointmentStatusId),
                        It.Is<int>(i => i == appointmentSequenceId)
                    )).Returns(new PsychologistInvoiceCalculationData
                    {
                        Company = new Companies.Company { CompanyId = companyId, },
                        SingleReportInvoiceAmount = singleReportInvoiceAmount,
                        ComboReportInvoiceAmount = comboReportInvoiceAmount,
                        CompletionFeeAmount = completionFeeAmount,
                        ExtraReportFee = extraReportFee,
                        InvoiceRate = invoiceRate,
                        IssueInDisputeInvoiceAmounts = issueInDisputeInvoiceAmounts,
                        LargeFileSize = largeFileSize,
                        LargeFileFee = largeFileFee,
                        ApplyCompletionFee = applyCompletionFee,
                        ApplyExtraReportFees = applyExtraReportFees,
                        ApplyIssueInDisputeFees = applyIssueInDisputeFees,
                        ApplyLargeFileFee = applyLargeFileFee,
                        ApplyTravelFee = applyTravelFee,
                    });

                    invoiceRepositoryMock
                        .Setup(ir => ir.GetInvoices(It.Is<InvoiceSearchCriteria>(isc =>
                            isc.AppointmentId == appointmentId &&
                            isc.InvoiceTypeId == InvoiceType.Psychologist)))
                        .Returns(() => Enumerable.Empty<Invoice>());

                    invoiceRepositoryMock.Setup(ir => ir.GetInvoiceCount(It.Is<int>(i => i == psychologistId))).Returns(invoiceCount);

                    invoiceRepositoryMock.Setup(ir => ir.GetInitialInvoiceStatus()).Returns(new InvoiceStatus { InvoiceStatusId = InvoiceStatus.Open });

                    invoiceRepositoryMock.Setup(ir => ir.GetTaxRate()).Returns(taxRate);

                    dateMock.SetupGet(d => d.UtcNow).Returns(DateTime.UtcNow);
                });

            var appointment = new Appointments.Appointment
            {
                AppointmentId = appointmentId,
                AppointmentTime = appointmentTime,
                AppointmentStatus = new Appointments.AppointmentStatus
                {
                    AppointmentStatusId = appointmentStatusId,
                    CanInvoice = true,
                },
                Location = new Addresses.Address
                {
                    City = new Cities.City
                    {
                        CityId = cityId,
                    },
                },
                Assessment = new Assessments.Assessment
                {
                    AssessmentType = new Assessments.AssessmentType
                    {
                        AssessmentTypeId = assessmentTypeId,
                        Description = assessmentTypeDescription,
                    },
                    FileSize = fileSize,
                    IsLargeFile = isLargeFile,
                    ReferralSource = new Referrals.ReferralSource
                    {
                        ReferralSourceId = referralSourceId,
                    },
                    Reports = new[] {
                        new Reports.Report
                        {
                            IsAdditional = false,
                            IssuesInDispute = issuesInDispute,
                        },
                    },
                    Company = new Companies.Company
                    {
                        CompanyId = companyId,
                    },
                },
                Psychologist = new Users.User { UserId = psychologistId },
                RoomRentalBillableAmount = roomRentalFee,
            };

            var invoice = psychologistInvoiceGenerator.CreateInvoice(appointment);

            var subtotal = ((singleReportInvoiceAmount * invoiceRate) + roomRentalFee);

            var expected = Convert.ToInt32(subtotal + (subtotal * taxRate));

            var actual = invoice.Total;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InvoiceDateIsUtcNow()
        {
            var appointmentId = 1;
            var appointmentTime = new DateTimeOffset(2017, 10, 8, 13, 0, 0, TimeSpan.Zero);
            var appointmentStatusId = Appointments.AppointmentStatus.Complete;
            var cityId = 2;
            var assessmentTypeId = 3;
            var assessmentTypeDescription = "Assessment Type";
            var fileSize = 500;
            var isLargeFile = false;
            var largeFileSize = 1000;
            var largeFileFee = 50000;
            var referralSourceId = 4;
            var companyId = 5;
            var psychologistId = 6;
            var psychologist = new Users.User
            {
                UserId = psychologistId,
                TravelFees = Enumerable.Empty<Users.UserTravelFee>(),
            };
            var taxRate = 0.1m;
            var invoiceCount = 0;
            var utcNow = DateTimeOffset.UtcNow;
            var appointmentSequenceId = Appointments.AppointmentSequence.First;
            var siblingAppointments = Enumerable.Empty<Appointments.Appointment>();
            var singleReportInvoiceAmount = 123400;
            var comboReportInvoiceAmount = 432100;
            var applyCompletionFee = false;
            var applyExtraReportFees = false;
            var applyIssueInDisputeFees = false;
            var applyLargeFileFee = false;
            var applyTravelFee = false;
            var completionFeeAmount = 75000;
            var extraReportFee = 50000;
            var invoiceRate = 1.0m;
            var catastrophicFee = 35000;
            var issuesInDispute = Enumerable.Empty<Models.Claims.IssueInDispute>();
            var issueInDisputeInvoiceAmounts = new[]
            {
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 1, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 2, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 3, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 4, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 5, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 6, }, InvoiceAmount = catastrophicFee },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 7, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 8, }, InvoiceAmount = 0 },
            };

            var psychologistInvoiceGenerator = GetService(
                (invoiceRepositoryMock, appointmentRepositoryMock, referralRepositoryMock, userRepositoryMock, dateMock) =>
                {
                    userRepositoryMock.Setup(ur => ur.GetUserById(It.Is<int>(i => i == psychologistId))).Returns(psychologist);

                    appointmentRepositoryMock
                        .Setup(ar => ar.GetAppointmentSequenceSiblings(It.Is<int>(i => i == appointmentId)))
                        .Returns(() => siblingAppointments);

                    invoiceRepositoryMock.Setup(ir => ir.GetPsychologistInvoiceCalculationData(
                        It.Is<int>(i => i == companyId),
                        It.Is<int>(i => i == referralSourceId),
                        It.Is<int>(i => i == assessmentTypeId),
                        It.Is<int>(i => i == appointmentStatusId),
                        It.Is<int>(i => i == appointmentSequenceId)
                    )).Returns(new PsychologistInvoiceCalculationData
                    {
                        Company = new Companies.Company { CompanyId = companyId, },
                        SingleReportInvoiceAmount = singleReportInvoiceAmount,
                        ComboReportInvoiceAmount = comboReportInvoiceAmount,
                        CompletionFeeAmount = completionFeeAmount,
                        ExtraReportFee = extraReportFee,
                        InvoiceRate = invoiceRate,
                        IssueInDisputeInvoiceAmounts = issueInDisputeInvoiceAmounts,
                        LargeFileSize = largeFileSize,
                        LargeFileFee = largeFileFee,
                        ApplyCompletionFee = applyCompletionFee,
                        ApplyExtraReportFees = applyExtraReportFees,
                        ApplyIssueInDisputeFees = applyIssueInDisputeFees,
                        ApplyLargeFileFee = applyLargeFileFee,
                        ApplyTravelFee = applyTravelFee,
                    });

                    invoiceRepositoryMock
                        .Setup(ir => ir.GetInvoices(It.Is<InvoiceSearchCriteria>(isc =>
                            isc.AppointmentId == appointmentId &&
                            isc.InvoiceTypeId == InvoiceType.Psychologist)))
                        .Returns(() => Enumerable.Empty<Invoice>());

                    invoiceRepositoryMock.Setup(ir => ir.GetInvoiceCount(It.Is<int>(i => i == psychologistId))).Returns(invoiceCount);

                    invoiceRepositoryMock.Setup(ir => ir.GetInitialInvoiceStatus()).Returns(new InvoiceStatus { InvoiceStatusId = InvoiceStatus.Open });

                    invoiceRepositoryMock.Setup(ir => ir.GetTaxRate()).Returns(taxRate);

                    dateMock.SetupGet(d => d.UtcNow).Returns(utcNow);
                });

            var appointment = new Appointments.Appointment
            {
                AppointmentId = appointmentId,
                AppointmentTime = appointmentTime,
                AppointmentStatus = new Appointments.AppointmentStatus
                {
                    AppointmentStatusId = appointmentStatusId,
                    CanInvoice = true,
                },
                Location = new Addresses.Address
                {
                    City = new Cities.City
                    {
                        CityId = cityId,
                    },
                },
                Assessment = new Assessments.Assessment
                {
                    AssessmentType = new Assessments.AssessmentType
                    {
                        AssessmentTypeId = assessmentTypeId,
                        Description = assessmentTypeDescription,
                    },
                    FileSize = fileSize,
                    IsLargeFile = isLargeFile,
                    ReferralSource = new Referrals.ReferralSource
                    {
                        ReferralSourceId = referralSourceId,
                    },
                    Reports = new[] {
                        new Reports.Report
                        {
                            IsAdditional = false,
                            IssuesInDispute = issuesInDispute,
                        }
                    },
                    Company = new Companies.Company
                    {
                        CompanyId = companyId,
                    },
                },
                Psychologist = new Users.User { UserId = psychologistId },
            };

            var invoice = psychologistInvoiceGenerator.CreateInvoice(appointment);

            var subtotal = singleReportInvoiceAmount * invoiceRate;

            var expected = utcNow;

            var actual = invoice.InvoiceDate;

            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void GetInvoiceLineGroupsRetainsCustomInvoiceLines()
        {
            var appointmentId = 1;
            var appointmentTime = new DateTimeOffset(2017, 10, 8, 13, 0, 0, TimeSpan.Zero);
            var appointmentStatusId = Appointments.AppointmentStatus.Complete;
            var cityId = 2;
            var assessmentTypeId = 3;
            var assessmentTypeDescription = "Assessment Type";
            var referralSourceName = "Referral Source";
            var claimantFirstName = "First";
            var claimantLastName = "Last";
            var fileSize = 500;
            var isLargeFile = false;
            var largeFileSize = 1000;
            var largeFileFee = 50000;
            var referralSourceId = 4;
            var companyId = 5;
            var psychologistId = 6;
            var psychologist = new Users.User
            {
                UserId = psychologistId,
                TravelFees = Enumerable.Empty<Users.UserTravelFee>(),
            };
            var taxRate = 0.1m;
            var invoiceCount = 0;
            var appointmentSequenceId = Appointments.AppointmentSequence.First;
            var siblingAppointments = Enumerable.Empty<Appointments.Appointment>();
            var singleReportInvoiceAmount = 123400;
            var comboReportInvoiceAmount = 432100;
            var applyCompletionFee = false;
            var applyExtraReportFees = false;
            var applyIssueInDisputeFees = false;
            var applyLargeFileFee = false;
            var applyTravelFee = false;
            var completionFeeAmount = 75000;
            var extraReportFee = 50000;
            var invoiceRate = 1.0m;
            var catastrophicFee = 35000;
            var issuesInDispute = Enumerable.Empty<Models.Claims.IssueInDispute>();
            var issueInDisputeInvoiceAmounts = new[]
            {
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 1, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 2, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 3, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 4, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 5, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 6, }, InvoiceAmount = catastrophicFee },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 7, }, InvoiceAmount = 0 },
                new IssueInDisputeInvoiceAmount { IssueInDispute = new Models.Claims.IssueInDispute { IssueInDisputeId = 8, }, InvoiceAmount = 0 },
            };

            var psychologistInvoiceGenerator = GetService(
                (invoiceRepositoryMock, appointmentRepositoryMock, referralRepositoryMock, userRepositoryMock, dateMock) =>
                {
                    userRepositoryMock.Setup(ur => ur.GetUserById(It.Is<int>(i => i == psychologistId))).Returns(psychologist);

                    appointmentRepositoryMock
                        .Setup(ar => ar.GetAppointmentSequenceSiblings(It.Is<int>(i => i == appointmentId)))
                        .Returns(() => siblingAppointments);

                    invoiceRepositoryMock.Setup(ir => ir.GetPsychologistInvoiceCalculationData(
                        It.Is<int>(i => i == companyId),
                        It.Is<int>(i => i == referralSourceId),
                        It.Is<int>(i => i == assessmentTypeId),
                        It.Is<int>(i => i == appointmentStatusId),
                        It.Is<int>(i => i == appointmentSequenceId)
                    )).Returns(new PsychologistInvoiceCalculationData
                    {
                        Company = new Companies.Company { CompanyId = companyId, },
                        SingleReportInvoiceAmount = singleReportInvoiceAmount,
                        ComboReportInvoiceAmount = comboReportInvoiceAmount,
                        CompletionFeeAmount = completionFeeAmount,
                        ExtraReportFee = extraReportFee,
                        InvoiceRate = invoiceRate,
                        IssueInDisputeInvoiceAmounts = issueInDisputeInvoiceAmounts,
                        LargeFileSize = largeFileSize,
                        LargeFileFee = largeFileFee,
                        ApplyCompletionFee = applyCompletionFee,
                        ApplyExtraReportFees = applyExtraReportFees,
                        ApplyIssueInDisputeFees = applyIssueInDisputeFees,
                        ApplyLargeFileFee = applyLargeFileFee,
                        ApplyTravelFee = applyTravelFee,
                    });

                    invoiceRepositoryMock
                        .Setup(ir => ir.GetInvoices(It.Is<InvoiceSearchCriteria>(isc =>
                            isc.AppointmentId == appointmentId &&
                            isc.InvoiceTypeId == InvoiceType.Psychologist)))
                        .Returns(() => Enumerable.Empty<Invoice>());

                    invoiceRepositoryMock.Setup(ir => ir.GetInvoiceCount(It.Is<int>(i => i == psychologistId))).Returns(invoiceCount);

                    invoiceRepositoryMock.Setup(ir => ir.GetInitialInvoiceStatus()).Returns(new InvoiceStatus { InvoiceStatusId = InvoiceStatus.Open });

                    invoiceRepositoryMock.Setup(ir => ir.GetTaxRate()).Returns(taxRate);

                    dateMock.SetupGet(d => d.UtcNow).Returns(DateTime.UtcNow);
                });

            var appointment = new Appointments.Appointment
            {
                AppointmentId = appointmentId,
                AppointmentTime = appointmentTime,
                AppointmentStatus = new Appointments.AppointmentStatus
                {
                    AppointmentStatusId = appointmentStatusId,
                    CanInvoice = true,
                },
                Location = new Addresses.Address
                {
                    City = new Cities.City
                    {
                        CityId = cityId,
                    },
                },
                Assessment = new Assessments.Assessment
                {
                    AssessmentType = new Assessments.AssessmentType
                    {
                        AssessmentTypeId = assessmentTypeId,
                        Description = assessmentTypeDescription,
                    },
                    FileSize = fileSize,
                    IsLargeFile = isLargeFile,
                    ReferralSource = new Referrals.ReferralSource
                    {
                        ReferralSourceId = referralSourceId,
                        Name = referralSourceName,
                    },
                    Reports = new[] {
                        new Reports.Report
                        {
                            IsAdditional = false,
                            IssuesInDispute = issuesInDispute,
                        }
                    },
                    Company = new Companies.Company
                    {
                        CompanyId = companyId,
                    },
                    Claims = new[]
                    {
                        new Claims.Claim
                        {
                            Claimant = new Claims.Claimant
                            {
                                FirstName = claimantFirstName,
                                LastName = claimantLastName,
                            },
                        }
                    },
                },
                Psychologist = new Users.User { UserId = psychologistId },
            };

            var invoiceLineGroupId = 1;
            var tipAmount = 2500;
            var gasAmount = 1000;

            var invoiceLines = new[]
            {
                new InvoiceLine
                {
                    InvoiceLineId = 1,
                    Amount = singleReportInvoiceAmount,
                    Description = "Psychological Assessment",
                },
                new InvoiceLine
                {
                    InvoiceLineId = 2,
                    Amount = tipAmount,
                    Description = "Tip",
                    IsCustom = true,
                },
                new InvoiceLine
                {
                    InvoiceLineId = 3,
                    Amount = gasAmount,
                    Description = "Gas Money",
                    IsCustom = true
                },
            };

            var invoice = new Invoice
            {
                InvoiceId = 1,
                InvoiceDate = DateTimeOffset.UtcNow,
                InvoiceType = new InvoiceType
                {
                    InvoiceTypeId = InvoiceType.Psychologist,
                },
                TaxRate = taxRate,
                PayableTo = new Users.User
                {
                    UserId = psychologistId,
                    Company = new Companies.Company
                    {
                        CompanyId = companyId,
                    },
                },
                LineGroups = new[]
                {
                    new InvoiceLineGroup
                    {
                        InvoiceLineGroupId = invoiceLineGroupId,
                        Appointment = appointment,
                        Lines = invoiceLines,
                    }
                }
            };
            
            var lineGroups = psychologistInvoiceGenerator.GetInvoiceLineGroups(invoice);

            //verify custom lines are still present
            foreach (var invoiceLine in invoiceLines.Where(il => il.IsCustom))
            {
                Assert.IsTrue(
                    lineGroups.Any(lineGroup =>
                        lineGroup.InvoiceLineGroupId == invoiceLineGroupId &&
                        lineGroup.Lines.Any(line =>
                            line.InvoiceLineId == invoiceLine.InvoiceLineId &&
                            line.IsCustom == invoiceLine.IsCustom &&
                            line.Amount == invoiceLine.Amount &&
                            line.Description == invoiceLine.Description
                        )
                    )
                );
            }

            var customLineTotal = invoiceLines
                .Where(invoiceLine => invoiceLine.IsCustom)
                .Select(invoiceLine => invoiceLine.Amount)
                .Sum();

            var expectedAmount = Convert.ToInt32((singleReportInvoiceAmount + customLineTotal) * (1 + taxRate));

            invoice.LineGroups = lineGroups;

            var actualAmount = psychologistInvoiceGenerator.GetInvoiceTotal(invoice);

            Assert.AreEqual(expectedAmount, actualAmount);
        }

    }
}
