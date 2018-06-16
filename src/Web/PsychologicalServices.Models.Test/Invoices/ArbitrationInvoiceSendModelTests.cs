using Microsoft.VisualStudio.TestTools.UnitTesting;
using PsychologicalServices.Models.Invoices;
using System;
using System.Linq;
using System.Text;

namespace PsychologicalServices.Models.Test.Invoices
{
    [TestClass]
    public class ArbitrationInvoiceSendModelTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsExceptionWhenInvoiceDocumentIsNull()
        {
            var arbitration = GetArbitration();
            var invoiceDocument = GetInvoiceDocument();
            var invoice = GetInvoice(arbitration, invoiceDocument);

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
        public void ModelIsNotValidWhenInvoiceTypeIsNotArbitration()
        {
            var arbitration = GetArbitration();
            var invoiceDocument = GetInvoiceDocument();
            var invoice = GetInvoice(arbitration, invoiceDocument);

            invoice.InvoiceType.InvoiceTypeId = InvoiceType.Psychologist;

            var model = new ArbitrationInvoiceSendModel(invoiceDocument, invoice);

            Assert.IsFalse(model.IsValid);
        }

        [TestMethod]
        public void ModelIsNotValidWhenInvoiceHasNoArbitrations()
        {
            var invoiceDocument = GetInvoiceDocument();
            var invoice = GetInvoice(null, invoiceDocument);

            var model = new PsychologistInvoiceSendModel(invoiceDocument, invoice);

            Assert.IsFalse(model.IsValid);
        }

        [TestMethod]
        public void ModelIsNotValidWhenBillToContactHasNoEmail()
        {
            var arbitration = GetArbitration();
            var invoiceDocument = GetInvoiceDocument();
            var invoice = GetInvoice(arbitration, invoiceDocument);

            arbitration.BillToContact.Email = null;

            var model = new ArbitrationInvoiceSendModel(invoiceDocument, invoice);

            Assert.IsFalse(model.IsValid);
        }

        [TestMethod]
        public void ModelIsNotValidWhenArbitrationHasNoClaimant()
        {
            var arbitration = GetArbitration();
            var invoiceDocument = GetInvoiceDocument();
            var invoice = GetInvoice(arbitration, invoiceDocument);

            arbitration.Claimant = null;

            var model = new ArbitrationInvoiceSendModel(invoiceDocument, invoice);

            Assert.IsFalse(model.IsValid);
        }

        [TestMethod]
        public void ModelIsNotValidWhenCompanyHasNoEmail()
        {
            var arbitration = GetArbitration();
            var invoiceDocument = GetInvoiceDocument();
            var invoice = GetInvoice(arbitration, invoiceDocument);

            arbitration.Psychologist.Company.Email = null;

            var model = new ArbitrationInvoiceSendModel(invoiceDocument, invoice);

            Assert.IsFalse(model.IsValid);
        }

        [TestMethod]
        public void ModelIsNotValidWhenPsychologistHasNoEmail()
        {
            var arbitration = GetArbitration();
            var invoiceDocument = GetInvoiceDocument();
            var invoice = GetInvoice(arbitration, invoiceDocument);

            arbitration.Psychologist.Email = null;

            var model = new ArbitrationInvoiceSendModel(invoiceDocument, invoice);

            Assert.IsFalse(model.IsValid);
        }

        [TestMethod]
        public void ModelIsValidWhenInvoiceIsValid()
        {
            var arbitration = GetArbitration();
            var invoiceDocument = GetInvoiceDocument();
            var invoice = GetInvoice(arbitration, invoiceDocument);

            var model = new ArbitrationInvoiceSendModel(invoiceDocument, invoice);

            Assert.IsTrue(model.IsValid);
            Assert.AreEqual(arbitration.Psychologist.Company.Email, model.SenderEmail);
            Assert.AreEqual(arbitration.BillToContact.Email, model.RecipientEmail);
            Assert.AreEqual(arbitration.Psychologist.Email, model.CourtesyCopyEmail);
            Assert.AreEqual(invoiceDocument.FileName, model.InvoiceDocument.FileName);
        }

        private Arbitrations.Arbitration GetArbitration()
        {
            var arbitration = new Arbitrations.Arbitration
            {
                ArbitrationId = 1,
                BillToContact = new Contacts.Contact
                {
                    Email = "lawyer@lawfirm.com",
                },
                Claimant = new Claims.Claimant
                {
                    ClaimantId = 3,
                    FirstName = "ClaimantFirst",
                    LastName = "ClaimantLast"
                },
                Psychologist = new Users.User
                {
                    Email = "psychologist@company.com",
                    Company = new Companies.Company
                    {
                        Email = "admin@company.com"
                    }
                }
            };

            return arbitration;
        }

        private Invoice GetInvoice(Arbitrations.Arbitration arbitration, InvoiceDocument document)
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
            var invoiceTypeId = InvoiceType.Arbitration;

            var invoice = new Invoice
            {
                LineGroups = new[]
                {
                    new InvoiceLineGroup
                    {
                        Arbitration = arbitration,
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
