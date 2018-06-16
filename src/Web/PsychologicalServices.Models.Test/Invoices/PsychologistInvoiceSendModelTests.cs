using Microsoft.VisualStudio.TestTools.UnitTesting;
using PsychologicalServices.Models.Invoices;
using System;
using System.Linq;
using System.Text;

namespace PsychologicalServices.Models.Test.Invoices
{
    [TestClass]
    public class PsychologistInvoiceSendModelTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsExceptionWhenInvoiceDocumentIsNull()
        {
            var appointment = GetAppointment();
            var invoiceDocument = GetInvoiceDocument();
            var invoice = GetInvoice(appointment, invoiceDocument);

            var model = new PsychologistInvoiceSendModel(null, invoice);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsExceptionWhenInvoiceIsNull()
        {
            var invoiceDocument = GetInvoiceDocument();
            
            var model = new PsychologistInvoiceSendModel(invoiceDocument, null);
        }

        [TestMethod]
        public void ModelIsNotValidWhenInvoiceTypeIsNotPsychologist()
        {
            var appointment = GetAppointment();
            var invoiceDocument = GetInvoiceDocument();
            var invoice = GetInvoice(appointment, invoiceDocument);

            invoice.InvoiceType.InvoiceTypeId = InvoiceType.Arbitration;

            var model = new PsychologistInvoiceSendModel(invoiceDocument, invoice);

            Assert.IsFalse(model.IsValid);
        }

        [TestMethod]
        public void ModelIsNotValidWhenInvoiceHasNoAppointments()
        {
            var invoiceDocument = GetInvoiceDocument();
            var invoice = GetInvoice(null, invoiceDocument);

            var model = new PsychologistInvoiceSendModel(invoiceDocument, invoice);

            Assert.IsFalse(model.IsValid);
        }

        [TestMethod]
        public void ModelIsNotValidWhenReferralSourceHasNoInvoiceContactEmail()
        {
            var appointment = GetAppointment();
            var invoiceDocument = GetInvoiceDocument();
            var invoice = GetInvoice(appointment, invoiceDocument);

            appointment.Assessment.ReferralSource.InvoicesContactEmail = null;

            var model = new PsychologistInvoiceSendModel(invoiceDocument, invoice);

            Assert.IsFalse(model.IsValid);
        }

        [TestMethod]
        public void ModelIsNotValidWhenAssessmentHasNoClaimant()
        {
            var appointment = GetAppointment();
            var invoiceDocument = GetInvoiceDocument();
            var invoice = GetInvoice(appointment, invoiceDocument);

            foreach (var claim in appointment.Assessment.Claims)
            {
                claim.Claimant = null;
            }

            var model = new PsychologistInvoiceSendModel(invoiceDocument, invoice);

            Assert.IsFalse(model.IsValid);
        }

        [TestMethod]
        public void ModelIsNotValidWhenCompanyHasNoEmail()
        {
            var appointment = GetAppointment();
            var invoiceDocument = GetInvoiceDocument();
            var invoice = GetInvoice(appointment, invoiceDocument);

            appointment.Assessment.Company.Email = null;

            var model = new PsychologistInvoiceSendModel(invoiceDocument, invoice);

            Assert.IsFalse(model.IsValid);
        }

        [TestMethod]
        public void ModelIsNotValidWhenPsychologistHasNoEmail()
        {
            var appointment = GetAppointment();
            var invoiceDocument = GetInvoiceDocument();
            var invoice = GetInvoice(appointment, invoiceDocument);

            appointment.Psychologist.Email = null;

            var model = new PsychologistInvoiceSendModel(invoiceDocument, invoice);

            Assert.IsFalse(model.IsValid);
        }

        [TestMethod]
        public void ModelIsValidWhenInvoiceIsValid()
        {
            var appointment = GetAppointment();
            var invoiceDocument = GetInvoiceDocument();
            var invoice = GetInvoice(appointment, invoiceDocument);

            var model = new PsychologistInvoiceSendModel(invoiceDocument, invoice);

            Assert.IsTrue(model.IsValid);
            Assert.AreEqual(appointment.Assessment.Company.Email, model.SenderEmail);
            Assert.AreEqual(appointment.Assessment.ReferralSource.InvoicesContactEmail, model.RecipientEmail);
            Assert.AreEqual(appointment.Psychologist.Email, model.CourtesyCopyEmail);
            Assert.AreEqual(invoiceDocument.FileName, model.InvoiceDocument.FileName);
        }

        private Appointments.Appointment GetAppointment()
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
            var utcNow = DateTimeOffset.UtcNow;

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

            return appointment;
        }

        private Invoice GetInvoice(Appointments.Appointment appointment, InvoiceDocument document)
        {
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
                    CanSend = true,
                },
                PayableTo = psychologist,
                TaxRate = taxRate,
                Total = 100000,
                UpdateDate = DateTimeOffset.UtcNow,
            };

            return invoice;
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
