using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PsychologicalServices.Models.Common.Utility;
using PsychologicalServices.Models.Common.Validation;
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
                Mock<IDate>,
                Mock<Appointments.IAppointmentRepository>,
                Mock<Assessments.IAssessmentRepository>,
                Mock<Claims.IClaimRepository>,
                Mock<Referrals.IReferralRepository>,
                Mock<IInvoiceRepository>,
                Mock<IInvoiceValidator>,
                Mock<IInvoiceConfigurationValidator>,
                Mock<ILog>,
                Mock<IInvoiceSender>,
                Mock<IInvoiceSendModelFactory>,
                Mock<IInvoiceGenerator>
            > setupMocks = null
        )
        {
            var dateMock = new Mock<IDate>();
            var appointmentRepositoryMock = new Mock<Appointments.IAppointmentRepository>();
            var assessmentRepositoryMock = new Mock<Assessments.IAssessmentRepository>();
            var claimRepositoryMock = new Mock<Claims.IClaimRepository>();
            var referralRepositoryMock = new Mock<Referrals.IReferralRepository>();
            var invoiceRepositoryMock = new Mock<IInvoiceRepository>();
            var invoiceValidatorMock = new Mock<IInvoiceValidator>();
            var invoiceConfigurationValidatorMock = new Mock<IInvoiceConfigurationValidator>();
            var logMock = new Mock<ILog>();
            var invoiceSenderMock = new Mock<IInvoiceSender>();
            var invoiceSendModelFactoryMock = new Mock<IInvoiceSendModelFactory>();
            var invoiceGeneratorMock = new Mock<IInvoiceGenerator>();

            setupMocks?.Invoke(
                dateMock,
                appointmentRepositoryMock,
                assessmentRepositoryMock,
                claimRepositoryMock,
                referralRepositoryMock,
                invoiceRepositoryMock,
                invoiceValidatorMock,
                invoiceConfigurationValidatorMock,
                logMock,
                invoiceSenderMock,
                invoiceSendModelFactoryMock,
                invoiceGeneratorMock
            );

            var invoiceService = new InvoiceService(
                dateMock.Object,
                appointmentRepositoryMock.Object,
                assessmentRepositoryMock.Object,
                claimRepositoryMock.Object,
                referralRepositoryMock.Object,
                invoiceRepositoryMock.Object,
                invoiceValidatorMock.Object,
                invoiceConfigurationValidatorMock.Object,
                logMock.Object,
                invoiceSenderMock.Object,
                invoiceSendModelFactoryMock.Object,
                invoiceGeneratorMock.Object
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
                (
                    dateMock,
                    appointmentRepositoryMock,
                    assessmentRepositoryMock,
                    claimRepositoryMock,
                    referralRepositoryMock,
                    invoiceRepositoryMock,
                    invoiceValidatorMock,
                    invoiceConfigurationValidatorMock,
                    logMock,
                    invoiceSenderMock,
                    invoiceSendModelFactoryMock,
                    invoiceGeneratorMock
                ) =>
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
                (
                    dateMock,
                    appointmentRepositoryMock,
                    assessmentRepositoryMock,
                    claimRepositoryMock,
                    referralRepositoryMock,
                    invoiceRepositoryMock,
                    invoiceValidatorMock,
                    invoiceConfigurationValidatorMock,
                    logMock,
                    invoiceSenderMock,
                    invoiceSendModelFactoryMock,
                    invoiceGeneratorMock
                ) =>
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
                (
                    dateMock,
                    appointmentRepositoryMock,
                    assessmentRepositoryMock,
                    claimRepositoryMock,
                    referralRepositoryMock,
                    invoiceRepositoryMock,
                    invoiceValidatorMock,
                    invoiceConfigurationValidatorMock,
                    logMock,
                    invoiceSenderMock,
                    invoiceSendModelFactoryMock,
                    invoiceGeneratorMock
                ) =>
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
                (
                    dateMock,
                    appointmentRepositoryMock,
                    assessmentRepositoryMock,
                    claimRepositoryMock,
                    referralRepositoryMock,
                    invoiceRepositoryMock,
                    invoiceValidatorMock,
                    invoiceConfigurationValidatorMock,
                    logMock,
                    invoiceSenderMock,
                    invoiceSendModelFactoryMock,
                    invoiceGeneratorMock
                ) =>
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
        public void SendInvoiceDocumentReturnsErrorWhenInvoiceIsNotSentSuccessfully()
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
                (
                    dateMock,
                    appointmentRepositoryMock,
                    assessmentRepositoryMock,
                    claimRepositoryMock,
                    referralRepositoryMock,
                    invoiceRepositoryMock,
                    invoiceValidatorMock,
                    invoiceConfigurationValidatorMock,
                    logMock,
                    invoiceSenderMock,
                    invoiceSendModelFactoryMock,
                    invoiceGeneratorMock
                ) =>
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

        [TestMethod]
        public void When_Invoice_Status_Indicates_A_New_Invoice_Document_Should_Be_Saved_Then_InvoiceDate_Is_Updated()
        {
            var now = DateTime.UtcNow;
            var total = 100;
            
            var invoice = new Invoice
            {
                InvoiceId = 1,
                InvoiceStatus = new InvoiceStatus
                {
                    SaveDocument = true,
                },
            };

            var service = GetService(
                (dateMock, appointmentRepositoryMock, assessmentRepositoryMock, claimRepositoryMock, referralRepositoryMock, invoiceRepositoryMock, invoiceValidatorMock, invoiceConfigurationValidatorMock, logMock, invoiceSenderMock, invoiceSendModelFactoryMock, invoiceGeneratorMock) =>
                {
                    dateMock.SetupGet(d => d.UtcNow).Returns(now);

                    var validationResultMock = new Mock<IValidationResult>();
                    validationResultMock.Setup(vr => vr.IsValid).Returns(true);

                    invoiceValidatorMock.Setup(iv => iv.Validate(It.IsAny<Invoice>())).Returns(validationResultMock.Object);

                    invoiceGeneratorMock.Setup(ig => ig.GetInvoiceTotal(It.IsAny<Invoice>())).Returns(total);

                    invoiceRepositoryMock.Setup(ir => ir.SaveInvoice(It.IsAny<Invoice>())).Returns(invoice.InvoiceId);

                    invoiceRepositoryMock.Setup(ir => ir.GetInvoice(It.Is<int>(i => i == invoice.InvoiceId))).Returns(invoice);
                });

            var result = service.SaveInvoice(invoice);

            Assert.AreEqual(now, result.Item.InvoiceDate);
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
