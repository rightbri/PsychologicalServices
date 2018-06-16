using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PsychologicalServices.Models.Appointments;
using PsychologicalServices.Models.Arbitrations;
using PsychologicalServices.Models.Invoices;
using PsychologicalServices.Models.Users;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Test.Invoices
{
    [TestClass]
    public class InvoiceDocumentFileNameGeneratorTests
    {
        private InvoiceDocumentFileNameGenerator GetService(
            Action<Mock<IAppointmentRepository>, Mock<IUserRepository>> setupMocks = null
        )
        {
            var appointmentRepositoryMock = new Mock<IAppointmentRepository>();
            var userRepositoryMock = new Mock<IUserRepository>();

            if (null != setupMocks)
            {
                setupMocks(
                    appointmentRepositoryMock,
                    userRepositoryMock
                );
            }

            var service = new InvoiceDocumentFileNameGenerator(
                appointmentRepositoryMock.Object,
                userRepositoryMock.Object
            );

            return service;
        }

        [TestMethod]
        public void GetFileNameForArbitrationMatchesExpectedValue()
        {
            var invoiceDocumentFileNameGenerator = GetService();

            var date = new DateTimeOffset(2018, 6, 12, 17, 48, 00, TimeSpan.FromHours(-5));

            var invoice = new Invoice
            {
                InvoiceDate = date,
                InvoiceType = new InvoiceType
                {
                    InvoiceTypeId = InvoiceType.Arbitration
                },
                LineGroups = new List<InvoiceLineGroup>(new[]
                {
                    new InvoiceLineGroup
                    {
                        Arbitration = new Arbitration
                        {
                            Claimant = new Claims.Claimant
                            {
                                FirstName = "First",
                                LastName = "Last",
                            }
                        }
                    }
                }),
            };

            var expected = $"Last First INVOICE Jun 12 2018";

            var actual = invoiceDocumentFileNameGenerator.GetFileName(invoice);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetFileNameForPsychometristInvoiceMatchesExpectedValue()
        {
            var psychometrist = new User
            {
                UserId = 99,
                FirstName = "Zelda",
            };

            var date = new DateTimeOffset(2018, 6, 12, 17, 48, 00, TimeSpan.FromHours(-5));

            var invoice = new Invoice
            {
                InvoiceDate = date,
                InvoiceType = new InvoiceType
                {
                    InvoiceTypeId = InvoiceType.Psychometrist
                },
                PayableTo = psychometrist,
            };

            var invoiceDocumentFileNameGenerator = GetService(
                (appointmentRepositoryMoq, userRepositoryMoq) =>
                {
                    userRepositoryMoq
                        .Setup(repo => repo.GetUserById(It.Is<int>(i => i == psychometrist.UserId)))
                        .Returns(psychometrist);
                });

            var expected = "Jun 2018 Zelda INVOICE";

            var actual = invoiceDocumentFileNameGenerator.GetFileName(invoice);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetFileNameForPsychologistInvoiceMatchesExpectedValue()
        {
            var appointmentId = 1;
            var appointmentTime = new DateTimeOffset(2018, 6, 16, 10, 44, 00, TimeSpan.FromHours(-5));
            var assessmentTypeName = "Assessment Type Name";
            var claimantFirstName = "ClaimantFirst";
            var claimantLastName = "ClaimantLast";
            var referralSourceName = "Referral Source Name";

            var appointment = new Appointments.Appointment
            {
                AppointmentId = appointmentId,
                AppointmentTime = appointmentTime,
                Assessment = new Assessments.Assessment
                {
                    AssessmentType = new Assessments.AssessmentType
                    {
                        Name = assessmentTypeName,
                    },
                    Claims = new[]
                    {
                        new Claims.Claim
                        {
                            Claimant = new Claims.Claimant
                            {
                                FirstName = claimantFirstName,
                                LastName = claimantLastName,
                            }
                        }
                    },
                    ReferralSource = new Referrals.ReferralSource
                    {
                        Name = referralSourceName,
                    }
                }
            };

            var invoice = new Invoice
            {
                InvoiceType = new InvoiceType
                {
                    InvoiceTypeId = InvoiceType.Psychologist,
                },
                LineGroups = new[]
                {
                    new InvoiceLineGroup
                    {
                        Appointment = appointment,
                    }
                }
            };

            var invoiceDocumentFileNameGenerator = GetService(
                (appointmentRepositoryMoq, userRepositoryMoq) =>
                {
                    appointmentRepositoryMoq
                        .Setup(repo => repo.GetAppointment(It.Is<int>(i => i == appointmentId)))
                        .Returns(appointment);
                });

            var expected = "ClaimantLast, ClaimantFirst Assessment Type Name INVOICE Referral Source Name Jun 2018";

            var actual = invoiceDocumentFileNameGenerator.GetFileName(invoice);

            Assert.AreEqual(expected, actual);
        }
    }
}
