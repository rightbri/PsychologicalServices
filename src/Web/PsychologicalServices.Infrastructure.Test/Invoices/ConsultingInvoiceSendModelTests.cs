using Microsoft.VisualStudio.TestTools.UnitTesting;
using PsychologicalServices.Models.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalServices.Infrastructure.Test.Invoices.ConsultingInvoiceSendModelTests
{
    [TestClass]
    public class When_ConsultingAgreement_Has_ConsultingEmailAddress
    {
        [TestMethod]
        public void Constructor_Sets_CourtesyCopyEmail_To_PsychologistEmail_And_ConsultingAgreement_ConsultingEmailAddress()
        {
            var result = new ConsultingInvoiceSendModel(
                new InvoiceDocument(),
                new Invoice
                {
                    Documents = new List<InvoiceDocument>(),
                    Identifier = "Identifier",
                    InvoiceDate = DateTimeOffset.Now,
                    InvoiceId = 1,
                    InvoicePeriodBegin = new DateTimeOffset(2021,1,1,0,0,0,TimeSpan.Zero),
                    InvoicePeriodEnd = new DateTimeOffset(2021, 2, 1, 0, 0, 0, TimeSpan.Zero),
                    InvoiceStatus = new InvoiceStatus { InvoiceStatusId = InvoiceStatus.Submitted, IsActive = true, Name = "Submitted" },
                    InvoiceType = new InvoiceType {  InvoiceTypeId = InvoiceType.Consulting, Name = "Consulting", CanSend = true, IsActive = true },
                    LineGroups = new List<InvoiceLineGroup>
                    {
                        new InvoiceLineGroup
                        {
                            ConsultingAgreement = new Models.Consulting.ConsultingAgreement
                            {
                                BillReferenceNumber = "12345",
                                BillToReferralSource = new Models.Referrals.ReferralSource
                                {
                                    InvoicesContactEmail = "contact@referralSource.com",
                                    Name = "Referral Source",
                                    IsActive = true,
                                },
                                Company = new Models.Companies.Company
                                {
                                    IsActive = true,
                                    Email = "company@company.com",
                                    CompanyId = 123,
                                    AccountingEmail = "accounting@company.com",
                                    Name = "Company",
                                    ReplyToEmail = "reply@company.com",
                                    TaxId = "tax id",
                                },
                                ConsultingAgreementId = 19,
                                ConsultingEmailAddress = "consulting@referralSource.com",
                                Psychologist = new Models.Users.User
                                {
                                    Email = "psychologist@company.com",
                                    IsActive = true,
                                    FirstName = "psy",
                                    LastName = "chologist",
                                }
                            },
                            Lines = new List<InvoiceLine>
                            {
                                new InvoiceLine
                                {
                                    Description = "Stuff I did",
                                    OriginalAmount = 5000,
                                    Amount = 5000,
                                    IsCustom = true,
                                }
                            }
                        }
                    },
                    PayableTo = new Models.Users.User
                    {
                        IsActive = true,
                        Email = "fake@email.com"
                    },
                });

            Assert.AreEqual("psychologist@company.com,consulting@referralSource.com", result.CourtesyCopyEmail);
        }
    }
}
