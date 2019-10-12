using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PsychologicalServices.Infrastructure.Common.Repository;
using PsychologicalServices.Infrastructure.Invoices;
using PsychologicalServices.Models.Common.Utility;
using PsychologicalServices.Models.Companies;
using PsychologicalServices.Models.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Infrastructure.Test.Invoices.InvoiceRepositoryTests
{
    [TestClass]
    public class When_Date_Is_After_Psychometrists_Became_Employees
    {
        [TestMethod]
        public void GetPsychometristInvoiceTaxRate_Is_Zero()
        {
            var now = new DateTimeOffset(2019, 10, 2, 0, 0, 0, TimeSpan.Zero);

            var company = new Company
            {
                CompanyId = 1,
                IsActive = true,
                Timezone = "Eastern Standard Time"
            };

            var service = InvoiceRepositoryTest.GetService(
                (adapterFactoryMock, dateMock, invoiceHtmlGeneratorMock, htmlToPdfServiceMock, companyRepoMock, invoiceDocumentFileNameGeneratorMock) =>
                {
                    companyRepoMock
                        .Setup(repo => repo.GetCompany(It.Is<int>(i => i == company.CompanyId)))
                        .Returns(company);

                    dateMock
                        .Setup(d => d.UtcNow)
                        .Returns(now);
                });

            var actual = service.GetPsychometristInvoiceTaxRate(company.CompanyId);

            var expected = 0.0m;

            Assert.AreEqual(expected, actual);
        }
    }

    [TestClass]
    public class When_Date_Is_Before_Psychometrists_Became_Employees
    {
        [TestMethod]
        public void GetPsychometristInvoiceTaxRate_Is_General_TaxRate()
        {
            var generalTaxRate = 0.13m;

            var now = new DateTimeOffset(2019, 9, 30, 0, 0, 0, TimeSpan.Zero);

            var company = new Company
            {
                CompanyId = 1,
                IsActive = true,
                Timezone = "Eastern Standard Time"
            };

            var service = InvoiceRepositoryTest.GetService(
                (adapterFactoryMock, dateMock, invoiceHtmlGeneratorMock, htmlToPdfServiceMock, companyRepoMock, invoiceDocumentFileNameGeneratorMock) =>
                {
                    companyRepoMock
                        .Setup(repo => repo.GetCompany(It.Is<int>(i => i == company.CompanyId)))
                        .Returns(company);

                    dateMock
                        .Setup(d => d.UtcNow)
                        .Returns(now);
                });

            var actual = service.GetPsychometristInvoiceTaxRate(company.CompanyId);

            var expected = generalTaxRate;

            Assert.AreEqual(expected, actual);
        }
    }

    [TestClass]
    public class When_Date_Is_When_Psychometrists_Became_Employees
    {
        [TestMethod]
        public void GetPsychometristInvoiceTaxRate_Is_Zero()
        {
            var company = new Company
            {
                CompanyId = 1,
                IsActive = true,
                Timezone = "Eastern Standard Time"
            };

            var now = new DateTimeOffset(2019, 10, 1, 0, 0, 0, TimeSpan.Zero).InTimezone(company.Timezone);

            var service = InvoiceRepositoryTest.GetService(
                (adapterFactoryMock, dateMock, invoiceHtmlGeneratorMock, htmlToPdfServiceMock, companyRepoMock, invoiceDocumentFileNameGeneratorMock) =>
                {
                    companyRepoMock
                        .Setup(repo => repo.GetCompany(It.Is<int>(i => i == company.CompanyId)))
                        .Returns(company);

                    dateMock
                        .Setup(d => d.UtcNow)
                        .Returns(now);
                });

            var actual = service.GetPsychometristInvoiceTaxRate(company.CompanyId);

            var expected = 0.0m;

            Assert.AreEqual(expected, actual);
        }
    }

    public static class InvoiceRepositoryTest
    {
        public static InvoiceRepository GetService(
            Action<
                Mock<IDataAccessAdapterFactory>,
                Mock<IDate>,
                Mock<IInvoiceHtmlGenerator>,
                Mock<IHtmlToPdfService>,
                Mock<ICompanyRepository>,
                Mock<IInvoiceDocumentFileNameGenerator>
            > setupMocks = null
        )
        {
            var adapterFactoryMock = new Mock<IDataAccessAdapterFactory>();
            var dateMock = new Mock<IDate>();
            var invoiceHtmlGeneratorMock = new Mock<IInvoiceHtmlGenerator>();
            var htmlToPdfServiceMock = new Mock<IHtmlToPdfService>();
            var companyRepoMock = new Mock<ICompanyRepository>();
            var invoiceDocumentFileNameGeneratorMock = new Mock<IInvoiceDocumentFileNameGenerator>();

            if (setupMocks != null)
            {
                setupMocks(
                    adapterFactoryMock,
                    dateMock,
                    invoiceHtmlGeneratorMock,
                    htmlToPdfServiceMock,
                    companyRepoMock,
                    invoiceDocumentFileNameGeneratorMock
                );
            }

            var service = new InvoiceRepository(
                adapterFactoryMock.Object,
                dateMock.Object,
                invoiceHtmlGeneratorMock.Object,
                htmlToPdfServiceMock.Object,
                companyRepoMock.Object,
                invoiceDocumentFileNameGeneratorMock.Object
            );

            return service;
        }
    }
}