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
        private delegate void Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>
            (T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, 
            T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, 
            T17 t17, T18 t18);

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
                Mock<IInvoiceSender>,
                Mock<IInvoiceSendModelFactory>
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
            var invoiceSenderMock = new Mock<IInvoiceSender>();
            var invoiceSendModelFactoryMock = new Mock<IInvoiceSendModelFactory>();
            
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
                invoiceSenderMock,
                invoiceSendModelFactoryMock
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
                invoiceSenderMock.Object,
                invoiceSendModelFactoryMock.Object
            );

            return invoiceService;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SendInvoiceDocumentThrowsExceptionWhenInvoiceSendParametersIsNull()
        {
            var service = GetService();

            service.SendInvoiceDocument(null);
        }

        [TestMethod]
        public void SendInvoiceDocumentReturnsErrorWhenInvoiceIsNotFound()
        {
            var invoiceDocumentId = 1;

            var service = GetService(); //invoice repo method not set up

            var result = service.SendInvoiceDocument(new InvoiceSendParameters { InvoiceDocumentId = invoiceDocumentId });

            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Errors.Any(error => error.Type == InvoiceSendErrorType.InvoiceNotFound));
        }

        [TestMethod]
        public void SendInvoiceDocumentReturnsErrorWhenInvoiceTypeCannotBeSent()
        {
            var invoiceDocumentId = 1;
            
            var invoice = new Invoice
            {
                InvoiceType = new InvoiceType
                {
                    CanSend = false //configure invoice type to be not sendable
                }
            };
            
            var invoiceService = GetService(
                (appointmentRepositoryMock, assessmentRepositoryMock, arbitrationRepositoryMock, claimRepositoryMock, companyRepositoryMock, referralRepositoryMock, userServiceMock, invoiceRepositoryMock, invoiceValidatorMock, invoiceConfigurationValidatorMock, psychologistInvoiceGeneratorMock, psychometristInvoiceGeneratorMock, arbitrationInvoiceGeneratorMock, dateMock, logMock, timezoneServiceMock, invoiceSenderMock, invoiceSendModelFactoryMock) =>
                {
                    invoiceRepositoryMock
                        .Setup(invoiceRepository => invoiceRepository.GetInvoiceForDocument(It.Is<int>(i => i == invoiceDocumentId)))
                        .Returns(invoice);
                });

            var result = invoiceService.SendInvoiceDocument(new InvoiceSendParameters { InvoiceDocumentId = invoiceDocumentId });

            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Errors.Any(error => error.Type == InvoiceSendErrorType.InvoiceTypeCannotBeSent));
        }

        [TestMethod]
        public void SendInvoiceDocumentReturnsErrorWhenInvoiceDocumentIsNotFound()
        {
            var invoiceDocumentId = 1;
            
            var invoice = new Invoice
            {
                InvoiceType = new InvoiceType
                {
                    CanSend = true,
                }
            };

            var invoiceService = GetService(
                (appointmentRepositoryMock, assessmentRepositoryMock, arbitrationRepositoryMock, claimRepositoryMock, companyRepositoryMock, referralRepositoryMock, userServiceMock, invoiceRepositoryMock, invoiceValidatorMock, invoiceConfigurationValidatorMock, psychologistInvoiceGeneratorMock, psychometristInvoiceGeneratorMock, arbitrationInvoiceGeneratorMock, dateMock, logMock, timezoneServiceMock, invoiceSenderMock, invoiceSendModelFactoryMock) =>
                {
                    invoiceRepositoryMock
                        .Setup(invoiceRepository => invoiceRepository.GetInvoiceForDocument(It.Is<int>(i => i == invoiceDocumentId)))
                        .Returns(invoice);

                    //invoice document repo method not set up
                });

            var result = invoiceService.SendInvoiceDocument(new InvoiceSendParameters { InvoiceDocumentId = invoiceDocumentId });

            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Errors.Any(error => error.Type == InvoiceSendErrorType.InvoiceDocumentNotFound));
        }

        [TestMethod]
        public void SendInvoiceDocumentReturnsErrorWhenInvoiceSendModelIsNotImplemented()
        {
            var document = GetInvoiceDocument();

            var invoice = new Invoice
            {
                InvoiceType = new InvoiceType
                {
                    CanSend = true,
                }
            };

            var invoiceService = GetService(
                (appointmentRepositoryMock, assessmentRepositoryMock, arbitrationRepositoryMock, claimRepositoryMock, companyRepositoryMock, referralRepositoryMock, userServiceMock, invoiceRepositoryMock, invoiceValidatorMock, invoiceConfigurationValidatorMock, psychologistInvoiceGeneratorMock, psychometristInvoiceGeneratorMock, arbitrationInvoiceGeneratorMock, dateMock, logMock, timezoneServiceMock, invoiceSenderMock, invoiceSendModelFactoryMock) =>
                {
                    invoiceRepositoryMock
                        .Setup(invoiceRepository => invoiceRepository.GetInvoiceForDocument(It.Is<int>(i => i == document.InvoiceDocumentId)))
                        .Returns(invoice);

                    invoiceRepositoryMock
                        .Setup(invoiceRepository => invoiceRepository.GetInvoiceDocument(It.Is<int>(i => i == document.InvoiceDocumentId)))
                        .Returns(document);

                    //mock for invoice send model factory is not set up
                });

            var result = invoiceService.SendInvoiceDocument(new InvoiceSendParameters { InvoiceDocumentId = document.InvoiceDocumentId });

            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Errors.Any(error => error.Type == InvoiceSendErrorType.InvoiceSendModelNotImplemented));
        }

        [TestMethod]
        public void SendInvoiceDocumentReturnsSuccessWhenInvoiceSenderSendsInvoice()
        {
            var document = GetInvoiceDocument();

            var invoice = new Invoice
            {
                InvoiceType = new InvoiceType
                {
                    CanSend = true,
                }
            };

            var invoiceSendResult = new InvoiceSendResult(true, Enumerable.Empty<InvoiceSendError>(), null);

            var invoiceService = GetService(
                (appointmentRepositoryMock, assessmentRepositoryMock, arbitrationRepositoryMock, claimRepositoryMock, companyRepositoryMock, referralRepositoryMock, userServiceMock, invoiceRepositoryMock, invoiceValidatorMock, invoiceConfigurationValidatorMock, psychologistInvoiceGeneratorMock, psychometristInvoiceGeneratorMock, arbitrationInvoiceGeneratorMock, dateMock, logMock, timezoneServiceMock, invoiceSenderMock, invoiceSendModelFactoryMock) =>
                {
                    invoiceRepositoryMock
                        .Setup(invoiceRepository => invoiceRepository.GetInvoiceForDocument(It.Is<int>(i => i == document.InvoiceDocumentId)))
                        .Returns(invoice);

                    invoiceRepositoryMock
                        .Setup(invoiceRepository => invoiceRepository.GetInvoiceDocument(It.Is<int>(i => i == document.InvoiceDocumentId)))
                        .Returns(document);

                    var invoiceSendModelMock = new Mock<IInvoiceSendModel>();

                    invoiceSendModelFactoryMock
                        .Setup(invoiceSendModelFactory => invoiceSendModelFactory.GetInvoiceSendModel(It.IsAny<Invoice>(), It.IsAny<InvoiceDocument>()))
                        .Returns(invoiceSendModelMock.Object);

                    invoiceSenderMock
                        .Setup(invoiceSender => invoiceSender.SendInvoiceDocument(It.IsAny<IInvoiceSendModel>()))
                        .Returns(invoiceSendResult);
                });

            var result = invoiceService.SendInvoiceDocument(new InvoiceSendParameters { InvoiceDocumentId = document.InvoiceDocumentId });

            Assert.IsTrue(result.Success);
        }

        [TestMethod]
        public void SendnvoiceDocumentReturnsErrorWhenInvoiceIsNotSentSuccessfully()
        {
            var document = GetInvoiceDocument();

            var invoice = new Invoice
            {
                InvoiceType = new InvoiceType
                {
                    InvoiceTypeId = InvoiceType.Psychologist,
                    CanSend = true,
                }
            };

            var errorType = InvoiceSendErrorType.InvoiceSendModelValidationError;
            var invoiceSendResult = new InvoiceSendResult(false, new[] { new InvoiceSendError("", errorType) }, null);

            var invoiceService = GetService(
                (appointmentRepositoryMock, assessmentRepositoryMock, arbitrationRepositoryMock, claimRepositoryMock, companyRepositoryMock, referralRepositoryMock, userServiceMock, invoiceRepositoryMock, invoiceValidatorMock, invoiceConfigurationValidatorMock, psychologistInvoiceGeneratorMock, psychometristInvoiceGeneratorMock, arbitrationInvoiceGeneratorMock, dateMock, logMock, timezoneServiceMock, invoiceSenderMock, invoiceSendModelFactoryMock) =>
                {
                    invoiceRepositoryMock
                        .Setup(invoiceRepository => invoiceRepository.GetInvoiceForDocument(It.Is<int>(i => i == document.InvoiceDocumentId)))
                        .Returns(invoice);

                    invoiceRepositoryMock
                        .Setup(invoiceRepository => invoiceRepository.GetInvoiceDocument(It.Is<int>(i => i == document.InvoiceDocumentId)))
                        .Returns(document);

                    var invoiceSendModelMock = new Mock<IInvoiceSendModel>();

                    invoiceSendModelFactoryMock
                        .Setup(invoiceSendModelFactory => invoiceSendModelFactory.GetInvoiceSendModel(It.IsAny<Invoice>(), It.IsAny<InvoiceDocument>()))
                        .Returns(invoiceSendModelMock.Object);

                    invoiceSenderMock
                        .Setup(invoiceSender => invoiceSender.SendInvoiceDocument(It.IsAny<IInvoiceSendModel>()))
                        .Returns(invoiceSendResult);
                });

            var result = invoiceService.SendInvoiceDocument(new InvoiceSendParameters { InvoiceDocumentId = document.InvoiceDocumentId });

            Assert.AreEqual(false, result.Success);
            Assert.IsTrue(result.Errors.Any(error => error.Type == errorType));
        }

        private InvoiceDocument GetInvoiceDocument()
        {
            var document = new InvoiceDocument
            {
                Content = Encoding.UTF8.GetBytes("test"),
                CreateDate = DateTimeOffset.UtcNow,
                FileName = "test",
                InvoiceDocumentId = 1,
            };

            return document;
        }
    }
}
