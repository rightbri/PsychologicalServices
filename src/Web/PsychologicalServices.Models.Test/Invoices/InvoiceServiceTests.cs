using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PsychologicalServices.Models.Common.Utility;
using PsychologicalServices.Models.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalServices.Models.Test.Invoices
{
    [TestClass]
    public class InvoiceServiceTests
    {
        private InvoiceService GetService(
            Action<
                Mock<Appointments.IAppointmentRepository>,
                Mock<Companies.ICompanyRepository>,
                Mock<Users.IUserService>,
                Mock<IInvoiceRepository>,
                Mock<IInvoiceValidator>,
                Mock<IPsychologistInvoiceGenerator>,
                Mock<IPsychometristInvoiceGenerator>,
                Mock<IDate>,
                Mock<ILog>,
                Mock<ITimezoneService>,
                Mock<IMailService>
            > setupMocks = null
        )
        {
            var appointmentRepositoryMock = new Mock<Appointments.IAppointmentRepository>();
            var companyRepositoryMock = new Mock<Companies.ICompanyRepository>();
            var userServiceMock = new Mock<Users.IUserService>();
            var invoiceRepositoryMock = new Mock<IInvoiceRepository>();
            var invoiceValidatorMock = new Mock<IInvoiceValidator>();
            var psychologistInvoiceGeneratorMock = new Mock<IPsychologistInvoiceGenerator>();
            var psychometristInvoiceGeneratorMock = new Mock<IPsychometristInvoiceGenerator>();
            var dateServiceMock = new Mock<IDate>();
            var logMock = new Mock<ILog>();
            var timezoneServiceMock = new Mock<ITimezoneService>();
            var mailServiceMock = new Mock<IMailService>();
            
            setupMocks?.Invoke(
                appointmentRepositoryMock,
                companyRepositoryMock,
                userServiceMock,
                invoiceRepositoryMock,
                invoiceValidatorMock,
                psychologistInvoiceGeneratorMock,
                psychometristInvoiceGeneratorMock,
                dateServiceMock,
                logMock,
                timezoneServiceMock,
                mailServiceMock
            );

            var invoiceService = new InvoiceService(
                appointmentRepositoryMock.Object,
                companyRepositoryMock.Object,
                userServiceMock.Object,
                invoiceRepositoryMock.Object,
                invoiceValidatorMock.Object,
                psychologistInvoiceGeneratorMock.Object,
                psychometristInvoiceGeneratorMock.Object,
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
            var invoiceRate = 1.0m;
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
                Appointments = new[]
                {
                    new InvoiceAppointment
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
                InvoiceRate = invoiceRate,
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
                (appointmentRepositoryMock, companyRepositoryMock, userServiceMock, invoiceRepositoryMock, invoiceValidatorMock, psychologistInvoiceGeneratorMock, psychometristInvoiceGeneratorMock, dateMock, logMock, timezoneServiceMock, mailServiceMock) =>
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
            var invoiceRate = 1.0m;
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
                Appointments = Enumerable.Empty<InvoiceAppointment>(),
                Documents = new[]
                {
                    document,
                },
                Identifier = "1",
                InvoiceDate = DateTimeOffset.UtcNow,
                InvoiceId = 1,
                InvoiceRate = invoiceRate,
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
                (appointmentRepositoryMock, companyRepositoryMock, userServiceMock, invoiceRepositoryMock, invoiceValidatorMock, psychologistInvoiceGeneratorMock, psychometristInvoiceGeneratorMock, dateMock, logMock, timezoneServiceMock, mailServiceMock) =>
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
            var invoiceRate = 1.0m;
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
                    Claims = Enumerable.Empty<Claims.Claim>(),
                    Company = new Companies.Company
                    {
                        CompanyId = companyId,
                    },
                },
                Psychologist = new Users.User { UserId = psychologistId },
            };

            var invoice = new Invoice
            {
                Appointments = new[]
                {
                    new InvoiceAppointment
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
                InvoiceRate = invoiceRate,
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
                (appointmentRepositoryMock, companyRepositoryMock, userServiceMock, invoiceRepositoryMock, invoiceValidatorMock, psychologistInvoiceGeneratorMock, psychometristInvoiceGeneratorMock, dateMock, logMock, timezoneServiceMock, mailServiceMock) =>
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
            var invoiceRate = 1.0m;
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
                        new Claims.Claim
                        {
                            Claimant = new Claims.Claimant
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
                Appointments = new[]
                {
                    new InvoiceAppointment
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
                InvoiceRate = invoiceRate,
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
                (appointmentRepositoryMock, companyRepositoryMock, userServiceMock, invoiceRepositoryMock, invoiceValidatorMock, psychologistInvoiceGeneratorMock, psychometristInvoiceGeneratorMock, dateMock, logMock, timezoneServiceMock, mailServiceMock) =>
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
            var invoiceRate = 1.0m;
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
                        new Claims.Claim
                        {
                            Claimant = new Claims.Claimant
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
                Appointments = new[]
                {
                    new InvoiceAppointment
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
                InvoiceRate = invoiceRate,
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
                (appointmentRepositoryMock, companyRepositoryMock, userServiceMock, invoiceRepositoryMock, invoiceValidatorMock, psychologistInvoiceGeneratorMock, psychometristInvoiceGeneratorMock, dateMock, logMock, timezoneServiceMock, mailServiceMock) =>
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
            var invoiceRate = 1.0m;
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
                        new Claims.Claim
                        {
                            Claimant = new Claims.Claimant
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
                Appointments = new[]
                {
                    new InvoiceAppointment
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
                InvoiceRate = invoiceRate,
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
                (appointmentRepositoryMock, companyRepositoryMock, userServiceMock, invoiceRepositoryMock, invoiceValidatorMock, psychologistInvoiceGeneratorMock, psychometristInvoiceGeneratorMock, dateMock, logMock, timezoneServiceMock, mailServiceMock) =>
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
            var invoiceRate = 1.0m;
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
                        new Claims.Claim
                        {
                            Claimant = new Claims.Claimant
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
                Appointments = new[]
                {
                    new InvoiceAppointment
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
                InvoiceRate = invoiceRate,
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

            var invoiceService = GetService(
                (appointmentRepositoryMock, companyRepositoryMock, userServiceMock, invoiceRepositoryMock, invoiceValidatorMock, psychologistInvoiceGeneratorMock, psychometristInvoiceGeneratorMock, dateMock, logMock, timezoneServiceMock, mailServiceMock) =>
                {
                    invoiceRepositoryMock
                        .Setup(invoiceRepository => invoiceRepository.GetInvoiceDocument(It.Is<int>(i => i == invoiceDocumentId)))
                        .Returns(document);

                    invoiceRepositoryMock
                        .Setup(invoiceRepository => invoiceRepository.GetInvoiceForDocument(It.Is<int>(i => i == invoiceDocumentId)))
                        .Returns(invoice);

                    mailServiceMock
                        .Setup(mailService => mailService.Send(It.IsAny<System.Net.Mail.MailMessage>()))
                        .Returns(mailResult)
                        .Verifiable();

                    mailServiceMockToVerify = mailServiceMock;
                });

            var parameters = new PsychologistInvoiceSendParameters
            {
                InvoiceDocumentId = invoiceDocumentId,
            };

            var sendResult = invoiceService.SendPsychologistInvoiceDocument(parameters);

            Assert.AreEqual(true, sendResult.Success);
            Assert.IsFalse(sendResult.Errors.Any());

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
            var invoiceRate = 1.0m;
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
                        new Claims.Claim
                        {
                            Claimant = new Claims.Claimant
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
                Appointments = new[]
                {
                    new InvoiceAppointment
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
                InvoiceRate = invoiceRate,
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
                (appointmentRepositoryMock, companyRepositoryMock, userServiceMock, invoiceRepositoryMock, invoiceValidatorMock, psychologistInvoiceGeneratorMock, psychometristInvoiceGeneratorMock, dateMock, logMock, timezoneServiceMock, mailServiceMock) =>
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
