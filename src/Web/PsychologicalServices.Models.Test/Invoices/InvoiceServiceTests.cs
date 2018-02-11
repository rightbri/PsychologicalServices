using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PsychologicalServices.Models.Common.Utility;
using PsychologicalServices.Models.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PsychologicalServices.Models.Test.Invoices
{
    [TestClass]
    public class InvoiceServiceTests
    {
        private delegate void Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>
            (T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, 
            T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, 
            T17 t17);

        private InvoiceService GetService(
            Action<
                Mock<Appointments.IAppointmentRepository>,
                Mock<Assessments.IAssessmentRepository>,
                Mock<Arbitrations.IArbitrationRepository>,
                Mock<Claims.IClaimRepository>,
                Mock<Companies.ICompanyRepository>,
                Mock<Referrals.IReferralRepository>,
                Mock<Users.IUserService>,
                Mock<IInvoiceRepository>,
                Mock<IInvoiceValidator>,
                Mock<IInvoiceConfigurationValidator>,
                Mock<IPsychologistInvoiceGenerator>,
                Mock<IPsychometristInvoiceGenerator>,
                Mock<IArbitrationInvoiceGenerator>,
                Mock<IDate>,
                Mock<ILog>,
                Mock<ITimezoneService>,
                Mock<IMailService>
            > setupMocks = null
        )
        {
            var appointmentRepositoryMock = new Mock<Appointments.IAppointmentRepository>();
            var assessmentRepositoryMock = new Mock<Assessments.IAssessmentRepository>();
            var arbitrationRepositoryMock = new Mock<Arbitrations.IArbitrationRepository>();
            var claimRepositoryMock = new Mock<Claims.IClaimRepository>();
            var companyRepositoryMock = new Mock<Companies.ICompanyRepository>();
            var referralRepositoryMock = new Mock<Referrals.IReferralRepository>();
            var userServiceMock = new Mock<Users.IUserService>();
            var invoiceRepositoryMock = new Mock<IInvoiceRepository>();
            var invoiceValidatorMock = new Mock<IInvoiceValidator>();
            var invoiceConfigurationValidatorMock = new Mock<IInvoiceConfigurationValidator>();
            var psychologistInvoiceGeneratorMock = new Mock<IPsychologistInvoiceGenerator>();
            var psychometristInvoiceGeneratorMock = new Mock<IPsychometristInvoiceGenerator>();
            var arbitrationInvoiceGeneratorMock = new Mock<IArbitrationInvoiceGenerator>();
            var dateServiceMock = new Mock<IDate>();
            var logMock = new Mock<ILog>();
            var timezoneServiceMock = new Mock<ITimezoneService>();
            var mailServiceMock = new Mock<IMailService>();
            
            setupMocks?.Invoke(
                appointmentRepositoryMock,
                assessmentRepositoryMock,
                arbitrationRepositoryMock,
                claimRepositoryMock,
                companyRepositoryMock,
                referralRepositoryMock,
                userServiceMock,
                invoiceRepositoryMock,
                invoiceValidatorMock,
                invoiceConfigurationValidatorMock,
                psychologistInvoiceGeneratorMock,
                psychometristInvoiceGeneratorMock,
                arbitrationInvoiceGeneratorMock,
                dateServiceMock,
                logMock,
                timezoneServiceMock,
                mailServiceMock
            );

            var invoiceService = new InvoiceService(
                appointmentRepositoryMock.Object,
                assessmentRepositoryMock.Object,
                arbitrationRepositoryMock.Object,
                claimRepositoryMock.Object,
                companyRepositoryMock.Object,
                referralRepositoryMock.Object,
                userServiceMock.Object,
                invoiceRepositoryMock.Object,
                invoiceValidatorMock.Object,
                invoiceConfigurationValidatorMock.Object,
                psychologistInvoiceGeneratorMock.Object,
                psychometristInvoiceGeneratorMock.Object,
                arbitrationInvoiceGeneratorMock.Object,
                dateServiceMock.Object,
                logMock.Object,
                timezoneServiceMock.Object,
                mailServiceMock.Object
            );

            return invoiceService;
        }

        [TestMethod]
        public void SendPsychologistInvoiceDocumentReturnsErrorWhenInvoiceDocumentDoesNotExist()
        {
            var invoiceDocumentId = 1;

            var invoiceService = GetService();

            var parameters = new PsychologistInvoiceSendParameters
            {
                InvoiceDocumentId = invoiceDocumentId,
            };

            var sendResult = invoiceService.SendPsychologistInvoiceDocument(parameters);

            Assert.AreEqual(false, sendResult.Success);
            Assert.IsTrue(sendResult.Errors.Any(error => error.Contains("document")));
        }

        [TestMethod]
        public void SendPsychologistInvoiceDocumentReturnsErrorWhenInvoiceTypeIsNotPsychologist()
        {
            var appointmentId = 1;
            var appointmentTime = new DateTimeOffset(2017, 10, 8, 13, 0, 0, TimeSpan.Zero);
            var appointmentStatusId = Appointments.AppointmentStatus.Complete;
            var cityId = 2;
            var assessmentTypeId = 3;
            var assessmentTypeDescription = "Assessment Type";
            var referralSourceId = 4;
            var companyId = 5;
            var psychologistId = 6;
            var psychologist = new Users.User
            {
                UserId = psychologistId,
                TravelFees = Enumerable.Empty<Users.UserTravelFee>(),
            };
            var taxRate = 0.1m;
            var utcNow = DateTimeOffset.UtcNow;
            var invoiceTypeId = InvoiceType.Psychometrist;
            var invoiceDocumentId = 1;
            var document = new InvoiceDocument
            {
                Content = Encoding.UTF8.GetBytes("test"),
                CreateDate = DateTimeOffset.UtcNow,
                FileName = "test",
                InvoiceDocumentId = invoiceDocumentId,
            };
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
                    ReferralSource = new Referrals.ReferralSource
                    {
                        ReferralSourceId = referralSourceId,
                    },
                    Company = new Companies.Company
                    {
                        CompanyId = companyId,
                    },
                },
                Psychologist = new Users.User { UserId = psychologistId },
            };

            var invoice = new Invoice
            {
                LineGroups = new[]
                {
                    new InvoiceLineGroup
                    {
                        Appointment = appointment,
                    },
                },
                Documents = new[]
                {
                    document,
                },
                Identifier = "1",
                InvoiceDate = DateTimeOffset.UtcNow,
                InvoiceId = 1,
                InvoiceStatus = new InvoiceStatus
                {
                    InvoiceStatusId = InvoiceStatus.Open,
                },
                InvoiceType = new InvoiceType
                {
                    InvoiceTypeId = invoiceTypeId,
                },
                PayableTo = new Users.User
                {
                    UserId = psychologistId,
                },
                TaxRate = taxRate,
                Total = 100000,
                UpdateDate = DateTimeOffset.UtcNow,
            };
            
            var invoiceService = GetService(
                (appointmentRepositoryMock, assessmentRepositoryMock, arbitrationRepositoryMock, claimRepositoryMock, companyRepositoryMock, referralRepositoryMock, userServiceMock, invoiceRepositoryMock, invoiceValidatorMock, invoiceConfigurationValidatorMock, psychologistInvoiceGeneratorMock, psychometristInvoiceGeneratorMock, arbitrationInvoiceGeneratorMock, dateMock, logMock, timezoneServiceMock, mailServiceMock) =>
                {
                    invoiceRepositoryMock
                        .Setup(invoiceRepository => invoiceRepository.GetInvoiceDocument(It.Is<int>(i => i == invoiceDocumentId)))
                        .Returns(document);

                    invoiceRepositoryMock
                        .Setup(invoiceRepository => invoiceRepository.GetInvoiceForDocument(It.Is<int>(i => i == invoiceDocumentId)))
                        .Returns(invoice);


                });

            var parameters = new PsychologistInvoiceSendParameters
            {
                InvoiceDocumentId = invoiceDocumentId,
            };

            var sendResult = invoiceService.SendPsychologistInvoiceDocument(parameters);

            Assert.AreEqual(false, sendResult.Success);
            Assert.IsTrue(sendResult.Errors.Any(error => error.Contains("psychologist")));
        }

        [TestMethod]
        public void SendPsychologistInvoiceDocumentReturnsErrorWhenInvoiceHasNoInvoiceAppointments()
        {
            var appointmentId = 1;
            var appointmentTime = new DateTimeOffset(2017, 10, 8, 13, 0, 0, TimeSpan.Zero);
            var appointmentStatusId = Appointments.AppointmentStatus.Complete;
            var cityId = 2;
            var assessmentTypeId = 3;
            var assessmentTypeDescription = "Assessment Type";
            var referralSourceId = 4;
            var companyId = 5;
            var psychologistId = 6;
            var psychologist = new Users.User
            {
                UserId = psychologistId,
                TravelFees = Enumerable.Empty<Users.UserTravelFee>(),
            };
            var taxRate = 0.1m;
            var utcNow = DateTimeOffset.UtcNow;
            var invoiceTypeId = InvoiceType.Psychologist;
            var invoiceDocumentId = 1;
            var document = new InvoiceDocument
            {
                Content = Encoding.UTF8.GetBytes("test"),
                CreateDate = DateTimeOffset.UtcNow,
                FileName = "test",
                InvoiceDocumentId = invoiceDocumentId,
            };
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
                    ReferralSource = new Referrals.ReferralSource
                    {
                        ReferralSourceId = referralSourceId,
                    },
                    Company = new Companies.Company
                    {
                        CompanyId = companyId,
                    },
                },
                Psychologist = new Users.User { UserId = psychologistId },
            };

            var invoice = new Invoice
            {
                LineGroups = Enumerable.Empty<InvoiceLineGroup>(),
                Documents = new[]
                {
                    document,
                },
                Identifier = "1",
                InvoiceDate = DateTimeOffset.UtcNow,
                InvoiceId = 1,
                InvoiceStatus = new InvoiceStatus
                {
                    InvoiceStatusId = InvoiceStatus.Open,
                },
                InvoiceType = new InvoiceType
                {
                    InvoiceTypeId = invoiceTypeId,
                },
                PayableTo = new Users.User
                {
                    UserId = psychologistId,
                },
                TaxRate = taxRate,
                Total = 100000,
                UpdateDate = DateTimeOffset.UtcNow,
            };

            var invoiceService = GetService(
                (appointmentRepositoryMock, assessmentRepositoryMock, arbitrationRepositoryMock, claimRepositoryMock, companyRepositoryMock, referralRepositoryMock, userServiceMock, invoiceRepositoryMock, invoiceValidatorMock, invoiceConfigurationValidatorMock, psychologistInvoiceGeneratorMock, psychometristInvoiceGeneratorMock, arbitrationInvoiceGeneratorMock, dateMock, logMock, timezoneServiceMock, mailServiceMock) =>
                {
                    invoiceRepositoryMock
                        .Setup(invoiceRepository => invoiceRepository.GetInvoiceDocument(It.Is<int>(i => i == invoiceDocumentId)))
                        .Returns(document);

                    invoiceRepositoryMock
                        .Setup(invoiceRepository => invoiceRepository.GetInvoiceForDocument(It.Is<int>(i => i == invoiceDocumentId)))
                        .Returns(invoice);
                });

            var parameters = new PsychologistInvoiceSendParameters
            {
                InvoiceDocumentId = invoiceDocumentId,
            };

            var sendResult = invoiceService.SendPsychologistInvoiceDocument(parameters);

            Assert.AreEqual(false, sendResult.Success);
            Assert.IsTrue(sendResult.Errors.Any(error => error.Contains("appointment")));
        }

        [TestMethod]
        public void SendPsychologistInvoiceDocumentReturnsErrorWhenAssessmentHasNoClaims()
        {
            var appointmentId = 1;
            var appointmentTime = new DateTimeOffset(2017, 10, 8, 13, 0, 0, TimeSpan.Zero);
            var appointmentStatusId = Appointments.AppointmentStatus.Complete;
            var cityId = 2;
            var assessmentTypeId = 3;
            var assessmentTypeDescription = "Assessment Type";
            var referralSourceId = 4;
            var companyId = 5;
            var psychologistId = 6;
            var psychologist = new Users.User
            {
                UserId = psychologistId,
                TravelFees = Enumerable.Empty<Users.UserTravelFee>(),
            };
            var taxRate = 0.1m;
            var utcNow = DateTimeOffset.UtcNow;
            var invoiceTypeId = InvoiceType.Psychologist;
            var invoiceDocumentId = 1;
            var document = new InvoiceDocument
            {
                Content = Encoding.UTF8.GetBytes("test"),
                CreateDate = DateTimeOffset.UtcNow,
                FileName = "test",
                InvoiceDocumentId = invoiceDocumentId,
            };
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
                    ReferralSource = new Referrals.ReferralSource
                    {
                        ReferralSourceId = referralSourceId,
                    },
                    Claims = Enumerable.Empty<Models.Claims.Claim>(),
                    Company = new Companies.Company
                    {
                        CompanyId = companyId,
                    },
                },
                Psychologist = new Users.User { UserId = psychologistId },
            };

            var invoice = new Invoice
            {
                LineGroups = new[]
                {
                    new InvoiceLineGroup
                    {
                        Appointment = appointment,
                    },
                },
                Documents = new[]
                {
                    document,
                },
                Identifier = "1",
                InvoiceDate = DateTimeOffset.UtcNow,
                InvoiceId = 1,
                InvoiceStatus = new InvoiceStatus
                {
                    InvoiceStatusId = InvoiceStatus.Open,
                },
                InvoiceType = new InvoiceType
                {
                    InvoiceTypeId = invoiceTypeId,
                },
                PayableTo = new Users.User
                {
                    UserId = psychologistId,
                },
                TaxRate = taxRate,
                Total = 100000,
                UpdateDate = DateTimeOffset.UtcNow,
            };

            var invoiceService = GetService(
                (appointmentRepositoryMock, assessmentRepositoryMock, arbitrationRepositoryMock, claimRepositoryMock, companyRepositoryMock, referralRepositoryMock, userServiceMock, invoiceRepositoryMock, invoiceValidatorMock, invoiceConfigurationValidatorMock, psychologistInvoiceGeneratorMock, psychometristInvoiceGeneratorMock, arbitrationInvoiceGeneratorMock, dateMock, logMock, timezoneServiceMock, mailServiceMock) =>
                {
                    invoiceRepositoryMock
                        .Setup(invoiceRepository => invoiceRepository.GetInvoiceDocument(It.Is<int>(i => i == invoiceDocumentId)))
                        .Returns(document);

                    invoiceRepositoryMock
                        .Setup(invoiceRepository => invoiceRepository.GetInvoiceForDocument(It.Is<int>(i => i == invoiceDocumentId)))
                        .Returns(invoice);
                });

            var parameters = new PsychologistInvoiceSendParameters
            {
                InvoiceDocumentId = invoiceDocumentId,
            };

            var sendResult = invoiceService.SendPsychologistInvoiceDocument(parameters);

            Assert.AreEqual(false, sendResult.Success);
            Assert.IsTrue(sendResult.Errors.Any(error => error.Contains("claim")));
        }

        [TestMethod]
        public void SendPsychologistInvoiceDocumentReturnsErrorWhenReferralSourceHasNoInvoicesContactEmail()
        {
            var appointmentId = 1;
            var appointmentTime = new DateTimeOffset(2017, 10, 8, 13, 0, 0, TimeSpan.Zero);
            var appointmentStatusId = Appointments.AppointmentStatus.Complete;
            var cityId = 2;
            var assessmentTypeId = 3;
            var assessmentTypeDescription = "Assessment Type";
            var referralSourceId = 4;
            var companyId = 5;
            var psychologistId = 6;
            var psychologist = new Users.User
            {
                UserId = psychologistId,
                TravelFees = Enumerable.Empty<Users.UserTravelFee>(),
            };
            var taxRate = 0.1m;
            var utcNow = DateTimeOffset.UtcNow;
            var invoiceTypeId = InvoiceType.Psychologist;
            var invoiceDocumentId = 1;
            var document = new InvoiceDocument
            {
                Content = Encoding.UTF8.GetBytes("test"),
                CreateDate = DateTimeOffset.UtcNow,
                FileName = "test",
                InvoiceDocumentId = invoiceDocumentId,
            };
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
                    ReferralSource = new Referrals.ReferralSource
                    {
                        ReferralSourceId = referralSourceId,
                        InvoicesContactEmail = "",
                    },
                    Claims = new[]
                    {
                        new Models.Claims.Claim
                        {
                            Claimant = new Models.Claims.Claimant
                            {
                                FirstName = "First",
                                LastName = "Last",
                            },
                        },
                    },
                    Company = new Companies.Company
                    {
                        CompanyId = companyId,
                    },
                },
                Psychologist = new Users.User { UserId = psychologistId },
            };

            var invoice = new Invoice
            {
                LineGroups = new[]
                {
                    new InvoiceLineGroup
                    {
                        Appointment = appointment,
                    },
                },
                Documents = new[]
                {
                    document,
                },
                Identifier = "1",
                InvoiceDate = DateTimeOffset.UtcNow,
                InvoiceId = 1,
                InvoiceStatus = new InvoiceStatus
                {
                    InvoiceStatusId = InvoiceStatus.Open,
                },
                InvoiceType = new InvoiceType
                {
                    InvoiceTypeId = invoiceTypeId,
                },
                PayableTo = new Users.User
                {
                    UserId = psychologistId,
                },
                TaxRate = taxRate,
                Total = 100000,
                UpdateDate = DateTimeOffset.UtcNow,
            };

            var invoiceService = GetService(
                (appointmentRepositoryMock, assessmentRepositoryMock, arbitrationRepositoryMock, claimRepositoryMock, companyRepositoryMock, referralRepositoryMock, userServiceMock, invoiceRepositoryMock, invoiceValidatorMock, invoiceConfigurationValidatorMock, psychologistInvoiceGeneratorMock, psychometristInvoiceGeneratorMock, arbitrationInvoiceGeneratorMock, dateMock, logMock, timezoneServiceMock, mailServiceMock) =>
                {
                    invoiceRepositoryMock
                        .Setup(invoiceRepository => invoiceRepository.GetInvoiceDocument(It.Is<int>(i => i == invoiceDocumentId)))
                        .Returns(document);

                    invoiceRepositoryMock
                        .Setup(invoiceRepository => invoiceRepository.GetInvoiceForDocument(It.Is<int>(i => i == invoiceDocumentId)))
                        .Returns(invoice);
                });

            var parameters = new PsychologistInvoiceSendParameters
            {
                InvoiceDocumentId = invoiceDocumentId,
            };

            var sendResult = invoiceService.SendPsychologistInvoiceDocument(parameters);

            Assert.AreEqual(false, sendResult.Success);
            Assert.IsTrue(sendResult.Errors.Any(error => error.Contains("email")));
        }

        [TestMethod]
        public void SendPsychologistInvoiceDocumentReturnsErrorWhenAssessmentHasNoCompanyEmail()
        {
            var appointmentId = 1;
            var appointmentTime = new DateTimeOffset(2017, 10, 8, 13, 0, 0, TimeSpan.Zero);
            var appointmentStatusId = Appointments.AppointmentStatus.Complete;
            var cityId = 2;
            var assessmentTypeId = 3;
            var assessmentTypeDescription = "Assessment Type";
            var referralSourceId = 4;
            var referralSourceInvoicesContactEmail = "invoices@ime.com";
            var companyId = 5;
            var psychologistId = 6;
            var psychologist = new Users.User
            {
                UserId = psychologistId,
                TravelFees = Enumerable.Empty<Users.UserTravelFee>(),
            };
            var taxRate = 0.1m;
            var utcNow = DateTimeOffset.UtcNow;
            var invoiceTypeId = InvoiceType.Psychologist;
            var invoiceDocumentId = 1;
            var document = new InvoiceDocument
            {
                Content = Encoding.UTF8.GetBytes("test"),
                CreateDate = DateTimeOffset.UtcNow,
                FileName = "test",
                InvoiceDocumentId = invoiceDocumentId,
            };
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
                    ReferralSource = new Referrals.ReferralSource
                    {
                        ReferralSourceId = referralSourceId,
                        InvoicesContactEmail = referralSourceInvoicesContactEmail,
                    },
                    Claims = new[]
                    {
                        new Models.Claims.Claim
                        {
                            Claimant = new Models.Claims.Claimant
                            {
                                FirstName = "First",
                                LastName = "Last",
                            },
                        },
                    },
                    Company = new Companies.Company
                    {
                        CompanyId = companyId,
                    },
                },
                Psychologist = new Users.User { UserId = psychologistId },
            };

            var invoice = new Invoice
            {
                LineGroups = new[]
                {
                    new InvoiceLineGroup
                    {
                        Appointment = appointment,
                    },
                },
                Documents = new[]
                {
                    document,
                },
                Identifier = "1",
                InvoiceDate = DateTimeOffset.UtcNow,
                InvoiceId = 1,
                InvoiceStatus = new InvoiceStatus
                {
                    InvoiceStatusId = InvoiceStatus.Open,
                },
                InvoiceType = new InvoiceType
                {
                    InvoiceTypeId = invoiceTypeId,
                },
                PayableTo = new Users.User
                {
                    UserId = psychologistId,
                },
                TaxRate = taxRate,
                Total = 100000,
                UpdateDate = DateTimeOffset.UtcNow,
            };

            var invoiceService = GetService(
                (appointmentRepositoryMock, assessmentRepositoryMock, arbitrationRepositoryMock, claimRepositoryMock, companyRepositoryMock, referralRepositoryMock, userServiceMock, invoiceRepositoryMock, invoiceValidatorMock, invoiceConfigurationValidatorMock, psychologistInvoiceGeneratorMock, psychometristInvoiceGeneratorMock, arbitrationInvoiceGeneratorMock, dateMock, logMock, timezoneServiceMock, mailServiceMock) =>
                {
                    invoiceRepositoryMock
                        .Setup(invoiceRepository => invoiceRepository.GetInvoiceDocument(It.Is<int>(i => i == invoiceDocumentId)))
                        .Returns(document);

                    invoiceRepositoryMock
                        .Setup(invoiceRepository => invoiceRepository.GetInvoiceForDocument(It.Is<int>(i => i == invoiceDocumentId)))
                        .Returns(invoice);
                });

            var parameters = new PsychologistInvoiceSendParameters
            {
                InvoiceDocumentId = invoiceDocumentId,
            };

            var sendResult = invoiceService.SendPsychologistInvoiceDocument(parameters);

            Assert.AreEqual(false, sendResult.Success);
            Assert.IsTrue(sendResult.Errors.Any(error => error.Contains("company")));
        }

        [TestMethod]
        public void SendPsychologistInvoiceDocumentReturnsErrorWhenPsychologistHasNoEmail()
        {
            var appointmentId = 1;
            var appointmentTime = new DateTimeOffset(2017, 10, 8, 13, 0, 0, TimeSpan.Zero);
            var appointmentStatusId = Appointments.AppointmentStatus.Complete;
            var cityId = 2;
            var assessmentTypeId = 3;
            var assessmentTypeDescription = "Assessment Type";
            var referralSourceId = 4;
            var referralSourceInvoicesContactEmail = "invoices@ime.com";
            var companyId = 5;
            var companyEmail = "company@email.com";
            var psychologistId = 6;
            var psychologist = new Users.User
            {
                UserId = psychologistId,
                TravelFees = Enumerable.Empty<Users.UserTravelFee>(),
            };
            var taxRate = 0.1m;
            var utcNow = DateTimeOffset.UtcNow;
            var invoiceTypeId = InvoiceType.Psychologist;
            var invoiceDocumentId = 1;
            var document = new InvoiceDocument
            {
                Content = Encoding.UTF8.GetBytes("test"),
                CreateDate = DateTimeOffset.UtcNow,
                FileName = "test",
                InvoiceDocumentId = invoiceDocumentId,
            };
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
                    ReferralSource = new Referrals.ReferralSource
                    {
                        ReferralSourceId = referralSourceId,
                        InvoicesContactEmail = referralSourceInvoicesContactEmail,
                    },
                    Claims = new[]
                    {
                        new Models.Claims.Claim
                        {
                            Claimant = new Models.Claims.Claimant
                            {
                                FirstName = "First",
                                LastName = "Last",
                            },
                        },
                    },
                    Company = new Companies.Company
                    {
                        CompanyId = companyId,
                        Email = companyEmail,
                    },
                },
                Psychologist = new Users.User { UserId = psychologistId },
            };

            var invoice = new Invoice
            {
                LineGroups = new[]
                {
                    new InvoiceLineGroup
                    {
                        Appointment = appointment,
                    },
                },
                Documents = new[]
                {
                    document,
                },
                Identifier = "1",
                InvoiceDate = DateTimeOffset.UtcNow,
                InvoiceId = 1,
                InvoiceStatus = new InvoiceStatus
                {
                    InvoiceStatusId = InvoiceStatus.Open,
                },
                InvoiceType = new InvoiceType
                {
                    InvoiceTypeId = invoiceTypeId,
                },
                PayableTo = new Users.User
                {
                    UserId = psychologistId,
                },
                TaxRate = taxRate,
                Total = 100000,
                UpdateDate = DateTimeOffset.UtcNow,
            };

            var invoiceService = GetService(
                (appointmentRepositoryMock, assessmentRepositoryMock, arbitrationRepositoryMock, claimRepositoryMock, companyRepositoryMock, referralRepositoryMock, userServiceMock, invoiceRepositoryMock, invoiceValidatorMock, invoiceConfigurationValidatorMock, psychologistInvoiceGeneratorMock, psychometristInvoiceGeneratorMock, arbitrationInvoiceGeneratorMock, dateMock, logMock, timezoneServiceMock, mailServiceMock) =>
                {
                    invoiceRepositoryMock
                        .Setup(invoiceRepository => invoiceRepository.GetInvoiceDocument(It.Is<int>(i => i == invoiceDocumentId)))
                        .Returns(document);

                    invoiceRepositoryMock
                        .Setup(invoiceRepository => invoiceRepository.GetInvoiceForDocument(It.Is<int>(i => i == invoiceDocumentId)))
                        .Returns(invoice);
                });

            var parameters = new PsychologistInvoiceSendParameters
            {
                InvoiceDocumentId = invoiceDocumentId,
            };

            var sendResult = invoiceService.SendPsychologistInvoiceDocument(parameters);

            Assert.AreEqual(false, sendResult.Success);
            Assert.IsTrue(sendResult.Errors.Any(error => error.Contains("psychologist")));
        }

        [TestMethod]
        public void SendPsychologistInvoiceDocumentReturnsSuccessWhenInvoiceEmailIsSentSuccessfully()
        {
            var appointmentId = 1;
            var appointmentTime = new DateTimeOffset(2017, 10, 8, 13, 0, 0, TimeSpan.Zero);
            var appointmentStatusId = Appointments.AppointmentStatus.Complete;
            var cityId = 2;
            var assessmentTypeId = 3;
            var assessmentTypeDescription = "Assessment Type";
            var referralSourceId = 4;
            var companyId = 5;
            var companyEmail = "company@email.com";
            var referralSourceInvoicesContactEmail = "invoices@ime.com";
            var claimantFirstName = "First";
            var claimantLastName = "Last";
            var psychologistId = 6;
            var psychologist = new Users.User
            {
                UserId = psychologistId,
                Email = "psychologist@company.com",
                TravelFees = Enumerable.Empty<Users.UserTravelFee>(),
            };
            var taxRate = 0.1m;
            var utcNow = DateTimeOffset.UtcNow;
            var invoiceTypeId = InvoiceType.Psychologist;
            var invoiceDocumentId = 1;
            var document = new InvoiceDocument
            {
                Content = Encoding.UTF8.GetBytes("test"),
                CreateDate = DateTimeOffset.UtcNow,
                FileName = "test",
                InvoiceDocumentId = invoiceDocumentId,
            };
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
                    ReferralSource = new Referrals.ReferralSource
                    {
                        ReferralSourceId = referralSourceId,
                        InvoicesContactEmail = referralSourceInvoicesContactEmail,
                    },
                    Claims = new[]
                    {
                        new Models.Claims.Claim
                        {
                            Claimant = new Models.Claims.Claimant
                            {
                                FirstName = claimantFirstName,
                                LastName = claimantLastName,
                            },
                        },
                    },
                    Company = new Companies.Company
                    {
                        CompanyId = companyId,
                        Email = companyEmail,
                    },
                },
                Psychologist = psychologist,
            };

            var invoice = new Invoice
            {
                LineGroups = new[]
                {
                    new InvoiceLineGroup
                    {
                        Appointment = appointment,
                    },
                },
                Documents = new[]
                {
                    document,
                },
                Identifier = "1",
                InvoiceDate = DateTimeOffset.UtcNow,
                InvoiceId = 1,
                InvoiceStatus = new InvoiceStatus
                {
                    InvoiceStatusId = InvoiceStatus.Open,
                },
                InvoiceType = new InvoiceType
                {
                    InvoiceTypeId = invoiceTypeId,
                },
                PayableTo = psychologist,
                TaxRate = taxRate,
                Total = 100000,
                UpdateDate = DateTimeOffset.UtcNow,
            };
            var mailResult = new MailResult
            {
                IsError = false,
                ErrorDetails = null,
                MailSent = true,
            };

            Mock<IMailService> mailServiceMockToVerify = null;
            Mock<IInvoiceRepository> invoiceRepositoryMockToVerify = null;

            var invoiceService = GetService(
                (appointmentRepositoryMock, assessmentRepositoryMock, arbitrationRepositoryMock, claimRepositoryMock, companyRepositoryMock, referralRepositoryMock, userServiceMock, invoiceRepositoryMock, invoiceValidatorMock, invoiceConfigurationValidatorMock, psychologistInvoiceGeneratorMock, psychometristInvoiceGeneratorMock, arbitrationInvoiceGeneratorMock, dateMock, logMock, timezoneServiceMock, mailServiceMock) =>
                {
                    invoiceRepositoryMock
                        .Setup(invoiceRepository => invoiceRepository.GetInvoiceDocument(It.Is<int>(i => i == invoiceDocumentId)))
                        .Returns(document);

                    invoiceRepositoryMock
                        .Setup(invoiceRepository => invoiceRepository.GetInvoiceForDocument(It.Is<int>(i => i == invoiceDocumentId)))
                        .Returns(invoice);

                    invoiceRepositoryMock
                        .Setup(invoiceRepository => invoiceRepository.LogInvoiceDocumentSent(It.Is<int>(i => i == invoiceDocumentId), It.Is<string>(s => s == referralSourceInvoicesContactEmail)))
                        .Verifiable();

                    mailServiceMock
                        .Setup(mailService => mailService.Send(It.IsAny<System.Net.Mail.MailMessage>()))
                        .Returns(mailResult)
                        .Verifiable();

                    invoiceRepositoryMockToVerify = invoiceRepositoryMock;
                    mailServiceMockToVerify = mailServiceMock;
                });

            var parameters = new PsychologistInvoiceSendParameters
            {
                InvoiceDocumentId = invoiceDocumentId,
            };

            var sendResult = invoiceService.SendPsychologistInvoiceDocument(parameters);

            Assert.AreEqual(true, sendResult.Success);
            Assert.IsFalse(sendResult.Errors.Any());

            invoiceRepositoryMockToVerify.Verify();

            mailServiceMockToVerify
                .Verify(mailService => mailService.Send(It.Is<System.Net.Mail.MailMessage>(mm =>
                    mm.From.Address == appointment.Assessment.Company.Email &&
                    mm.To.Count() == 1 &&
                    mm.To.First().Address == appointment.Assessment.ReferralSource.InvoicesContactEmail &&
                    mm.CC.Count() == 1 &&
                    mm.CC.First().Address == invoice.PayableTo.Email &&
                    mm.Body.Contains($"{claimantFirstName} {claimantLastName}") &&
                    mm.Attachments.Count() == 1 &&
                    mm.Attachments.First().Name == document.FileName
                )));
        }

        [TestMethod]
        public void SendPsychologistInvoiceDocumentReturnsErrorWhenMailServiceSendFails()
        {
            var appointmentId = 1;
            var appointmentTime = new DateTimeOffset(2017, 10, 8, 13, 0, 0, TimeSpan.Zero);
            var appointmentStatusId = Appointments.AppointmentStatus.Complete;
            var cityId = 2;
            var assessmentTypeId = 3;
            var assessmentTypeDescription = "Assessment Type";
            var referralSourceId = 4;
            var companyId = 5;
            var companyEmail = "company@email.com";
            var referralSourceInvoicesContactEmail = "invoices@ime.com";
            var claimantFirstName = "First";
            var claimantLastName = "Last";
            var psychologistId = 6;
            var psychologist = new Users.User
            {
                UserId = psychologistId,
                Email = "psychologist@company.com",
                TravelFees = Enumerable.Empty<Users.UserTravelFee>(),
            };
            var taxRate = 0.1m;
            var utcNow = DateTimeOffset.UtcNow;
            var invoiceTypeId = InvoiceType.Psychologist;
            var invoiceDocumentId = 1;
            var document = new InvoiceDocument
            {
                Content = Encoding.UTF8.GetBytes("test"),
                CreateDate = DateTimeOffset.UtcNow,
                FileName = "test",
                InvoiceDocumentId = invoiceDocumentId,
            };
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
                    ReferralSource = new Referrals.ReferralSource
                    {
                        ReferralSourceId = referralSourceId,
                        InvoicesContactEmail = referralSourceInvoicesContactEmail,
                    },
                    Claims = new[]
                    {
                        new Models.Claims.Claim
                        {
                            Claimant = new Models.Claims.Claimant
                            {
                                FirstName = claimantFirstName,
                                LastName = claimantLastName,
                            },
                        },
                    },
                    Company = new Companies.Company
                    {
                        CompanyId = companyId,
                        Email = companyEmail,
                    },
                },
                Psychologist = psychologist,
            };

            var invoice = new Invoice
            {
                LineGroups = new[]
                {
                    new InvoiceLineGroup
                    {
                        Appointment = appointment,
                    },
                },
                Documents = new[]
                {
                    document,
                },
                Identifier = "1",
                InvoiceDate = DateTimeOffset.UtcNow,
                InvoiceId = 1,
                InvoiceStatus = new InvoiceStatus
                {
                    InvoiceStatusId = InvoiceStatus.Open,
                },
                InvoiceType = new InvoiceType
                {
                    InvoiceTypeId = invoiceTypeId,
                },
                PayableTo = psychologist,
                TaxRate = taxRate,
                Total = 100000,
                UpdateDate = DateTimeOffset.UtcNow,
            };

            var mailResult = new MailResult
            {
                IsError = true,
                ErrorDetails = "Email Fail",
                MailSent = false,
            };

            var invoiceService = GetService(
                (appointmentRepositoryMock, assessmentRepositoryMock, arbitrationRepositoryMock, claimRepositoryMock, companyRepositoryMock, referralRepositoryMock, userServiceMock, invoiceRepositoryMock, invoiceValidatorMock, invoiceConfigurationValidatorMock, psychologistInvoiceGeneratorMock, psychometristInvoiceGeneratorMock, arbitrationInvoiceGeneratorMock, dateMock, logMock, timezoneServiceMock, mailServiceMock) =>
                {
                    invoiceRepositoryMock
                        .Setup(invoiceRepository => invoiceRepository.GetInvoiceDocument(It.Is<int>(i => i == invoiceDocumentId)))
                        .Returns(document);

                    invoiceRepositoryMock
                        .Setup(invoiceRepository => invoiceRepository.GetInvoiceForDocument(It.Is<int>(i => i == invoiceDocumentId)))
                        .Returns(invoice);

                    mailServiceMock
                        .Setup(mailService => mailService.Send(It.IsAny<System.Net.Mail.MailMessage>()))
                        .Returns(mailResult);
                });

            var parameters = new PsychologistInvoiceSendParameters
            {
                InvoiceDocumentId = invoiceDocumentId,
            };

            var sendResult = invoiceService.SendPsychologistInvoiceDocument(parameters);

            Assert.AreEqual(false, sendResult.Success);
            Assert.IsTrue(sendResult.Errors.Any(error => error.Contains("Email")));
            
        }

    }
}
