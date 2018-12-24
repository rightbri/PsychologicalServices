﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PsychologicalServices.Models.Common.Utility;
using PsychologicalServices.Models.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Test.Invoices
{
    [TestClass]
    public class PsychometristInvoiceGeneratorTests
    {
        private PsychometristInvoiceGenerator GetService(
            Action<Mock<IInvoiceRepository>, Mock<Appointments.IAppointmentRepository>, Mock<Users.IUserRepository>, Mock<IDate>> setupMocks = null
        )
        {
            var dateServiceMock = new Mock<IDate>();
            var appointmentRepositoryMock = new Mock<Appointments.IAppointmentRepository>();
            var invoiceRepositoryMock = new Mock<IInvoiceRepository>();
            var userRepositoryMock = new Mock<Users.IUserRepository>();

            setupMocks?.Invoke(
                invoiceRepositoryMock,
                appointmentRepositoryMock,
                userRepositoryMock,
                dateServiceMock
            );

            var psychometristInvoiceGenerator = new PsychometristInvoiceGenerator(
                appointmentRepositoryMock.Object,
                invoiceRepositoryMock.Object,
                userRepositoryMock.Object,
                dateServiceMock.Object
            );

            return psychometristInvoiceGenerator;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CreateInvoiceThrowsExceptionWhenInvoiceAlreadyExists()
        {
            var payableToUserId = 1;
            var companyId = 2;
            var invoiceDate = new DateTimeOffset(2017, 09, 30, 11, 59, 59, TimeSpan.FromHours(-4));

            var psychometristInvoiceGenerator = GetService(
                (invoiceRepositoryMock, appointmentRepositoryMock, userRepositoryMock, dateServiceMock) =>
                {
                    invoiceRepositoryMock
                        .Setup(invoiceRepository =>
                            invoiceRepository.GetInvoices(
                                It.Is<InvoiceSearchCriteria>(c => c.InvoiceTypeId == InvoiceType.Psychometrist && c.PayableToId == payableToUserId && c.InvoiceDate == invoiceDate && c.CompanyId == companyId)
                            )
                        )
                        .Returns(() => new[]
                        {
                            new Invoice(),
                        });
                });

            psychometristInvoiceGenerator.CreateInvoice(
                new Users.User
                {
                    UserId = payableToUserId,
                    Company = new Companies.Company
                    {
                        CompanyId = companyId,
                    },
                }, invoiceDate);
        }

        [TestMethod]
        public void CreateInvoiceWithNoAppointmentsCreatesZeroTotalInvoice()
        {
            var userId = 1;
            var invoiceDate = new DateTimeOffset(2017, 08, 25, 0, 0, 0, TimeSpan.Zero);
            var taxRate = 0.15m;
            var invoiceStatusId = 1;

            var psychometristInvoiceGenerator = GetService(
                (invoiceRepositoryMock, appointmentRepositoryMock, userRepositoryMock, dateServiceMock) =>
                {
                    invoiceRepositoryMock
                        .Setup(invoiceRepository => invoiceRepository.GetInvoices(It.IsAny<InvoiceSearchCriteria>()))
                        .Returns(() => Enumerable.Empty<Invoice>());

                    invoiceRepositoryMock
                        .Setup(invoiceRepository => invoiceRepository.GetInvoiceCount(It.Is<int>(i => i == userId)))
                        .Returns(() => 0);

                    invoiceRepositoryMock
                        .Setup(invoiceRepository => invoiceRepository.GetInitialInvoiceStatus())
                        .Returns(() => new InvoiceStatus
                        {
                            InvoiceStatusId = invoiceStatusId,
                        });

                    invoiceRepositoryMock
                        .Setup(invoiceRepository => invoiceRepository.GetTaxRate())
                        .Returns(() => taxRate);

                    appointmentRepositoryMock
                        .Setup(appointmentRepository => appointmentRepository.GetAppointments(It.IsAny<Appointments.AppointmentSearchCriteria>()))
                        .Returns(() => Enumerable.Empty<Appointments.Appointment>());

                    dateServiceMock
                        .Setup(dateService => dateService.UtcNow)
                        .Returns(() => DateTimeOffset.UtcNow);
                });

            var psychometrist = new Users.User
            {
                UserId = userId,
                Company = new Companies.Company
                {
                    Timezone = "Eastern Standard Time",
                },
            };

            var invoice = psychometristInvoiceGenerator.CreateInvoice(psychometrist, invoiceDate);

            Assert.AreEqual(0, invoice.Total);

            Assert.AreEqual(userId, invoice.PayableTo.UserId);

            Assert.AreEqual(invoiceDate, invoice.InvoiceDate);

            Assert.AreEqual(taxRate, invoice.TaxRate);

            Assert.AreEqual(invoiceStatusId, invoice.InvoiceStatus.InvoiceStatusId);

            Assert.AreEqual(InvoiceType.Psychometrist, invoice.InvoiceType.InvoiceTypeId);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetInvoiceLineGroupsThrowsExceptionForPsychologistInvoice()
        {
            var psychometristInvoiceGenerator = GetService();

            var invoice = new Invoice
            {
                InvoiceType = new InvoiceType
                {
                    InvoiceTypeId = InvoiceType.Psychologist,
                }
            };

            psychometristInvoiceGenerator.GetInvoiceLineGroups(invoice);
        }

        [TestMethod]
        public void GetInvoiceLineGroupsRetainsCustomInvoiceLines()
        {
            var appointmentStatusId = 5;
            var taxRate = 0.15m;
            var assessmentTypeId = 4;
            var assessmentTypeDescription = "Assessment Type";
            var referralSourceName = "Referral Source";
            var claimantFirstName = "First";
            var claimantLastName = "Last";
            var companyId = 5;
            var cityId = 44;
            var cityName = "Oakville";
            var travelFeeAmount = 10000;
            var appointmentAmount = 20000;
            var timezone = "Eastern Standard Time";
            var userId = 1;
            var isCompletion = false;
            var appointmentId = 123;
            var appointmentSequenceId = isCompletion ? Appointments.AppointmentSequence.Subsequent : Appointments.AppointmentSequence.First;
            var invoiceLineGroupId = 456;
            var appointment = new Appointments.Appointment
            {
                AppointmentId = appointmentId,
                AppointmentStatus = new Appointments.AppointmentStatus
                {
                    AppointmentStatusId = appointmentStatusId,
                    CanInvoice = true,
                },
                Assessment = new Assessments.Assessment
                {
                    AssessmentType = new Assessments.AssessmentType
                    {
                        AssessmentTypeId = assessmentTypeId,
                        Description = assessmentTypeDescription,
                    },
                    Claimant = new Claims.Claimant
                    {
                        FirstName = claimantFirstName,
                        LastName = claimantLastName,
                    },
                    ReferralSource = new Referrals.ReferralSource
                    {
                        Name = referralSourceName,
                    },
                    Company = new Companies.Company
                    {
                        CompanyId = companyId,
                    },
                },
                IsCompletion = isCompletion,
                Location = new Addresses.Address
                {
                    City = new Cities.City
                    {
                        CityId = cityId,
                        Name = cityName,
                    }
                },
                Psychometrist = new Users.User
                {
                    UserId = userId,
                },
            };

            var psychometristInvoiceGenerator = GetService(
                (invoiceRepositoryMock, appointmentRepositoryMock, userRepositoryMock, dateServiceMock) =>
                {
                    invoiceRepositoryMock.Setup(invoiceRepository => invoiceRepository.GetPsychometristInvoiceAmount(
                        It.Is<int>(i => i == assessmentTypeId),
                        It.Is<int>(i => i == appointmentStatusId),
                        It.Is<int>(i => i == appointmentSequenceId),
                        It.Is<int>(i => i == companyId))
                    ).Returns(new PsychometristInvoiceAmount
                    {
                        AssessmentType = new Assessments.AssessmentType { AssessmentTypeId = assessmentTypeId },
                        AppointmentStatus = new Appointments.AppointmentStatus { AppointmentStatusId = appointmentStatusId },
                        AppointmentSequence = new Appointments.AppointmentSequence { AppointmentSequenceId = appointmentSequenceId },
                        InvoiceAmount = appointmentAmount,
                    });

                    appointmentRepositoryMock
                        .Setup(appointmentRepository => appointmentRepository.GetAppointmentsForPsychometristInvoice(It.IsAny<Appointments.AppointmentSearchCriteria>()))
                        .Returns(new[] { appointment });

                    userRepositoryMock
                        .Setup(userRepository => userRepository.GetUserById(It.Is<int>(i => i == userId)))
                        .Returns(new Users.User
                        {
                            UserId = userId,
                            Company = new Companies.Company
                            {
                                CompanyId = companyId,
                                Timezone = timezone,
                            },
                            TravelFees = new[]
                                {
                                    new Users.UserTravelFee
                                    {
                                        City = new Cities.City
                                        {
                                            CityId = cityId,
                                            Name = cityName,
                                        },
                                        Amount = travelFeeAmount,
                                    }
                                },
                        });
                });

            var invoiceLines = new[]
            {
                new InvoiceLine
                {
                    InvoiceLineId = 1,
                    Amount = appointmentAmount + 10000,
                    Description = "Psychological Assessment",
                },
                new InvoiceLine
                {
                    InvoiceLineId = 2,
                    Amount = travelFeeAmount + 5000,
                    Description = "Travel to Oakville",
                },
                new InvoiceLine
                {
                    InvoiceLineId = 3,
                    Amount = 2500,
                    Description = "Tip",
                    IsCustom = true,
                },
                new InvoiceLine
                {
                    InvoiceLineId = 4,
                    Amount = 1000,
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
                    InvoiceTypeId = InvoiceType.Psychometrist,
                },
                TaxRate = taxRate,
                PayableTo = new Users.User
                {
                    UserId = userId,
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
            
            var lineGroups = psychometristInvoiceGenerator.GetInvoiceLineGroups(invoice);

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

            var expectedAmount = Convert.ToInt32((appointmentAmount + travelFeeAmount + customLineTotal) * (1 + taxRate));

            invoice.LineGroups = lineGroups;

            var actualAmount = psychometristInvoiceGenerator.GetInvoiceTotal(invoice);

            Assert.AreEqual(expectedAmount, actualAmount);
        }

        [TestMethod]
        public void GetInvoiceLineGroupsCalculatesCompletionCorrectly()
        {
            var taxRate = 0.15m;
            var assessmentTypeId = 4;
            var assessmentTypeDescription = "Assessment Type";
            var referralSourceName = "Referral Source";
            var claimantFirstName = "First";
            var claimantLastName = "Last";
            var companyId = 5;
            var timezone = "Eastern Standard Time";
            var cityId = 44;
            var cityName = "Oakville";
            var travelFeeAmount = 10000;
            var appointmentIncompleteAmount = 35000;
            var appointmentCompletionAmount = 17500;
            var userId = 1;
            var year = 2017;
            var month = 10;
            
            var appointments = new List<Appointments.Appointment>
            {
                new Appointments.Appointment
                {
                    AppointmentId = 123,
                    AppointmentTime = new DateTimeOffset(year, month, 1, 13, 0, 0, TimeSpan.Zero),
                    AppointmentStatus = new Appointments.AppointmentStatus
                    {
                        AppointmentStatusId = Appointments.AppointmentStatus.NoShow,
                        CanInvoice = true,
                    },
                    Assessment = new Assessments.Assessment
                    {
                        AssessmentType = new Assessments.AssessmentType
                        {
                            AssessmentTypeId = assessmentTypeId,
                            Description = assessmentTypeDescription,
                        },
                        Claimant = new Claims.Claimant
                        {
                            FirstName = claimantFirstName,
                            LastName = claimantLastName,
                        },
                        ReferralSource = new Referrals.ReferralSource
                        {
                            Name = referralSourceName,
                        },
                        Company = new Companies.Company
                        {
                            CompanyId = companyId,
                        },
                    },
                    IsCompletion = false,
                    Location = new Addresses.Address
                    {
                        City = new Cities.City
                        {
                            CityId = cityId,
                            Name = cityName,
                        }
                    },
                    Psychometrist = new Users.User
                    {
                        UserId = userId,
                    },
                },
                new Appointments.Appointment
                {
                    AppointmentId = 234,
                    AppointmentTime = new DateTimeOffset(year, month, 8, 13, 0, 0, TimeSpan.Zero),
                    AppointmentStatus = new Appointments.AppointmentStatus
                    {
                        AppointmentStatusId = Appointments.AppointmentStatus.Incomplete,
                        CanInvoice = true,
                    },
                    Assessment = new Assessments.Assessment
                    {
                        AssessmentType = new Assessments.AssessmentType
                        {
                            AssessmentTypeId = assessmentTypeId,
                            Description = assessmentTypeDescription,
                        },
                        Claimant = new Claims.Claimant
                        {
                            FirstName = claimantFirstName,
                            LastName = claimantLastName,
                        },
                        ReferralSource = new Referrals.ReferralSource
                        {
                            Name = referralSourceName,
                        },
                        Company = new Companies.Company
                        {
                            CompanyId = companyId,
                        },
                    },
                    IsCompletion = false,
                    Location = new Addresses.Address
                    {
                        City = new Cities.City
                        {
                            CityId = cityId,
                            Name = cityName,
                        }
                    },
                    Psychometrist = new Users.User
                    {
                        UserId = userId,
                    },
                },
                new Appointments.Appointment
                {
                    AppointmentId = 345,
                    AppointmentTime = new DateTimeOffset(year, month, 15, 13, 0, 0, TimeSpan.Zero),
                    AppointmentStatus = new Appointments.AppointmentStatus
                    {
                        AppointmentStatusId = Appointments.AppointmentStatus.Complete,
                        CanInvoice = true,
                    },
                    Assessment = new Assessments.Assessment
                    {
                        AssessmentType = new Assessments.AssessmentType
                        {
                            AssessmentTypeId = assessmentTypeId,
                            Description = assessmentTypeDescription,
                        },
                        Claimant = new Claims.Claimant
                        {
                            FirstName = claimantFirstName,
                            LastName = claimantLastName,
                        },
                        ReferralSource = new Referrals.ReferralSource
                        {
                            Name = referralSourceName,
                        },
                        Company = new Companies.Company
                        {
                            CompanyId = companyId,
                        },
                    },
                    IsCompletion = true,
                    Location = new Addresses.Address
                    {
                        City = new Cities.City
                        {
                            CityId = cityId,
                            Name = cityName,
                        }
                    },
                    Psychometrist = new Users.User
                    {
                        UserId = userId,
                    },
                },
            };

            var psychometristInvoiceGenerator = GetService(
                (invoiceRepositoryMock, appointmentRepositoryMock, userRepositoryMock, dateServiceMock) =>
                {
                    invoiceRepositoryMock.Setup(invoiceRepository => invoiceRepository.GetPsychometristInvoiceAmount(
                        It.Is<int>(i => i == assessmentTypeId),
                        It.Is<int>(i => i == Appointments.AppointmentStatus.NoShow),
                        It.Is<int>(i => i == Appointments.AppointmentSequence.First),
                        It.Is<int>(i => i == companyId))
                    ).Returns(new PsychometristInvoiceAmount
                    {
                        AssessmentType = new Assessments.AssessmentType { AssessmentTypeId = assessmentTypeId },
                        AppointmentStatus = new Appointments.AppointmentStatus { AppointmentStatusId = Appointments.AppointmentStatus.NoShow },
                        AppointmentSequence = new Appointments.AppointmentSequence { AppointmentSequenceId = Appointments.AppointmentSequence.First },
                        InvoiceAmount = appointmentCompletionAmount,
                    });

                    invoiceRepositoryMock.Setup(invoiceRepository => invoiceRepository.GetPsychometristInvoiceAmount(
                        It.Is<int>(i => i == assessmentTypeId),
                        It.Is<int>(i => i == Appointments.AppointmentStatus.Incomplete),
                        It.Is<int>(i => i == Appointments.AppointmentSequence.First),
                        It.Is<int>(i => i == companyId))
                    ).Returns(new PsychometristInvoiceAmount
                    {
                        AssessmentType = new Assessments.AssessmentType { AssessmentTypeId = assessmentTypeId },
                        AppointmentStatus = new Appointments.AppointmentStatus { AppointmentStatusId = Appointments.AppointmentStatus.Incomplete },
                        AppointmentSequence = new Appointments.AppointmentSequence { AppointmentSequenceId = Appointments.AppointmentSequence.First },
                        InvoiceAmount = appointmentIncompleteAmount,
                    });

                    invoiceRepositoryMock.Setup(invoiceRepository => invoiceRepository.GetPsychometristInvoiceAmount(
                        It.Is<int>(i => i == assessmentTypeId),
                        It.Is<int>(i => i == Appointments.AppointmentStatus.Incomplete),
                        It.Is<int>(i => i == Appointments.AppointmentSequence.Subsequent),
                        It.Is<int>(i => i == companyId))
                    ).Returns(new PsychometristInvoiceAmount
                    {
                        AssessmentType = new Assessments.AssessmentType { AssessmentTypeId = assessmentTypeId },
                        AppointmentStatus = new Appointments.AppointmentStatus { AppointmentStatusId = Appointments.AppointmentStatus.Incomplete },
                        AppointmentSequence = new Appointments.AppointmentSequence { AppointmentSequenceId = Appointments.AppointmentSequence.Subsequent },
                        InvoiceAmount = appointmentCompletionAmount,
                    });

                    invoiceRepositoryMock.Setup(invoiceRepository => invoiceRepository.GetPsychometristInvoiceAmount(
                        It.Is<int>(i => i == assessmentTypeId),
                        It.Is<int>(i => i == Appointments.AppointmentStatus.Complete),
                        It.Is<int>(i => i == Appointments.AppointmentSequence.Subsequent),
                        It.Is<int>(i => i == companyId))
                    ).Returns(new PsychometristInvoiceAmount
                    {
                        AssessmentType = new Assessments.AssessmentType { AssessmentTypeId = assessmentTypeId },
                        AppointmentStatus = new Appointments.AppointmentStatus { AppointmentStatusId = Appointments.AppointmentStatus.Complete },
                        AppointmentSequence = new Appointments.AppointmentSequence { AppointmentSequenceId = Appointments.AppointmentSequence.Subsequent },
                        InvoiceAmount = appointmentCompletionAmount,
                    });

                    appointmentRepositoryMock
                        .Setup(appointmentRepository => appointmentRepository.GetAppointmentsForPsychometristInvoice(It.IsAny<Appointments.AppointmentSearchCriteria>()))
                        .Returns(appointments);

                    userRepositoryMock
                        .Setup(userRepository => userRepository.GetUserById(It.Is<int>(i => i == userId)))
                        .Returns(new Users.User
                        {
                            UserId = userId,
                            Company = new Companies.Company
                            {
                                CompanyId = companyId,
                                Timezone = timezone,
                            },
                            TravelFees = new[]
                            {
                                new Users.UserTravelFee
                                {
                                    City = new Cities.City
                                    {
                                        CityId = cityId,
                                        Name = cityName,
                                    },
                                    Amount = travelFeeAmount,
                                }
                            },
                        });
                });

            var invoiceLineGroupWithCustomLinesId = 2;

            var invoice = new Invoice
            {
                InvoiceId = 1,
                InvoiceDate = DateTimeOffset.UtcNow,
                InvoiceType = new InvoiceType
                {
                    InvoiceTypeId = InvoiceType.Psychometrist,
                },
                TaxRate = taxRate,
                PayableTo = new Users.User
                {
                    UserId = userId,
                    Company = new Companies.Company
                    {
                        CompanyId = companyId,
                    },
                },
                LineGroups = new[]
                {
                    new InvoiceLineGroup
                    {
                        InvoiceLineGroupId = 1,
                        Appointment = appointments[0],
                        Lines = new List<InvoiceLine>(new[]
                        {
                            new InvoiceLine
                            {
                                InvoiceLineId = 1,
                                Amount = appointmentCompletionAmount,
                                Description = "Psychological Assessment - No Show",
                            },
                            new InvoiceLine
                            {
                                InvoiceLineId = 2,
                                Amount = travelFeeAmount + 5000,
                                Description = "Travel to Oakville",
                            },
                        }),
                    },
                    new InvoiceLineGroup
                    {
                        InvoiceLineGroupId = invoiceLineGroupWithCustomLinesId,
                        Appointment = appointments[1],
                        Lines = new List<InvoiceLine>(new[]
                        {
                            new InvoiceLine
                            {
                                InvoiceLineId = 3,
                                Amount = appointmentIncompleteAmount,
                                Description = "Psychological Assessment - Incomplete",
                            },
                            new InvoiceLine
                            {
                                InvoiceLineId = 4,
                                Amount = travelFeeAmount + 5000,
                                Description = "Travel to Oakville",
                            },
                            new InvoiceLine
                            {
                                InvoiceLineId = 5,
                                Amount = 2500,
                                Description = "Tip",
                                IsCustom = true,
                            },
                            new InvoiceLine
                            {
                                InvoiceLineId = 6,
                                Amount = 1000,
                                Description = "Gas Money",
                                IsCustom = true
                            },
                        }),
                    },
                    new InvoiceLineGroup
                    {
                        InvoiceLineGroupId = 3,
                        Appointment = appointments[2],
                        Lines = new List<InvoiceLine>(new[]
                        {
                            new InvoiceLine
                            {
                                InvoiceLineId = 7,
                                Amount = appointmentIncompleteAmount,
                                Description = "Psychological Assessment - Complete (Completion)",
                            },
                            new InvoiceLine
                            {
                                InvoiceLineId = 8,
                                Amount = travelFeeAmount,
                                Description = "Travel to Oakville",
                            },
                        }),
                    },
                }
            };

            var lineGroups = psychometristInvoiceGenerator.GetInvoiceLineGroups(invoice);

            //verify custom lines are still present
            foreach (var invoiceLine in invoice.LineGroups.SelectMany(ia => ia.Lines).Where(il => il.IsCustom))
            {
                Assert.IsTrue(
                    lineGroups.Any(lineGroup =>
                        lineGroup.InvoiceLineGroupId == invoiceLineGroupWithCustomLinesId &&
                        lineGroup.Lines.Any(line =>
                            line.InvoiceLineId == invoiceLine.InvoiceLineId &&
                            line.IsCustom == invoiceLine.IsCustom &&
                            line.Amount == invoiceLine.Amount &&
                            line.Description == invoiceLine.Description
                        )
                    )
                );
            }

            var customLineTotal = invoice.LineGroups.SelectMany(ia => ia.Lines)
                .Where(invoiceLine => invoiceLine.IsCustom)
                .Select(invoiceLine => invoiceLine.Amount)
                .Sum();

            var expectedAmount = Convert.ToInt32(
                (
                    appointmentCompletionAmount + //no show appointment
                    travelFeeAmount +               //travel for no show appointment
                    appointmentIncompleteAmount + //incomplete appointment
                    travelFeeAmount +               //travel for incomplete appointment
                    customLineTotal +               //custom lines for incomplete appointment
                    appointmentCompletionAmount + //completion appointment
                    travelFeeAmount                 //travel for completion appointment
                ) * (1 + taxRate)
            );

            invoice.LineGroups = lineGroups;

            var actualAmount = psychometristInvoiceGenerator.GetInvoiceTotal(invoice);

            Assert.AreEqual(expectedAmount, actualAmount);
        }

        [TestMethod]
        public void GetInvoiceLineGroupsFindsNewInvoiceableAppointments()
        {
            var taxRate = 0.15m;
            var assessmentTypeId = 4;
            var assessmentTypeDescription = "Assessment Type";
            var referralSourceName = "Referral Source";
            var claimantFirstName = "First";
            var claimantLastName = "Last";
            var companyId = 5;
            var timezone = "Eastern Standard Time";
            var cityId = 44;
            var cityName = "Oakville";
            var travelFeeAmount = 10000;
            var appointmentIncompleteAmount = 35000;
            var appointmentCompletionAmount = 17500;
            var userId = 1;
            var year = 2017;
            var month = 10;

            var appointments = new List<Appointments.Appointment>
            {
                new Appointments.Appointment
                {
                    AppointmentId = 123,
                    AppointmentTime = new DateTimeOffset(year, month, 1, 13, 0, 0, TimeSpan.Zero),
                    AppointmentStatus = new Appointments.AppointmentStatus
                    {
                        AppointmentStatusId = Appointments.AppointmentStatus.NoShow,
                        CanInvoice = true,
                    },
                    Assessment = new Assessments.Assessment
                    {
                        AssessmentType = new Assessments.AssessmentType
                        {
                            AssessmentTypeId = assessmentTypeId,
                            Description = assessmentTypeDescription,
                        },
                        Claimant = new Claims.Claimant
                        {
                            FirstName = claimantFirstName,
                            LastName = claimantLastName,
                        },
                        ReferralSource = new Referrals.ReferralSource
                        {
                            Name = referralSourceName,
                        },
                        Company = new Companies.Company
                        {
                            CompanyId = companyId,
                        },
                    },
                    IsCompletion = false,
                    Location = new Addresses.Address
                    {
                        City = new Cities.City
                        {
                            CityId = cityId,
                            Name = cityName,
                        }
                    },
                    Psychometrist = new Users.User
                    {
                        UserId = userId,
                    },
                },
                new Appointments.Appointment
                {
                    AppointmentId = 234,
                    AppointmentTime = new DateTimeOffset(year, month, 8, 13, 0, 0, TimeSpan.Zero),
                    AppointmentStatus = new Appointments.AppointmentStatus
                    {
                        AppointmentStatusId = Appointments.AppointmentStatus.Incomplete,
                        CanInvoice = true,
                    },
                    Assessment = new Assessments.Assessment
                    {
                        AssessmentType = new Assessments.AssessmentType
                        {
                            AssessmentTypeId = assessmentTypeId,
                            Description = assessmentTypeDescription,
                        },
                        Claimant = new Claims.Claimant
                        {
                            FirstName = claimantFirstName,
                            LastName = claimantLastName,
                        },
                        ReferralSource = new Referrals.ReferralSource
                        {
                            Name = referralSourceName,
                        },
                        Company = new Companies.Company
                        {
                            CompanyId = companyId,
                        },
                    },
                    IsCompletion = false,
                    Location = new Addresses.Address
                    {
                        City = new Cities.City
                        {
                            CityId = cityId,
                            Name = cityName,
                        }
                    },
                    Psychometrist = new Users.User
                    {
                        UserId = userId,
                    },
                },
                new Appointments.Appointment
                {
                    AppointmentId = 345,
                    AppointmentTime = new DateTimeOffset(year, month, 15, 13, 0, 0, TimeSpan.Zero),
                    AppointmentStatus = new Appointments.AppointmentStatus
                    {
                        AppointmentStatusId = Appointments.AppointmentStatus.Complete,
                        CanInvoice = true,
                    },
                    Assessment = new Assessments.Assessment
                    {
                        AssessmentType = new Assessments.AssessmentType
                        {
                            AssessmentTypeId = assessmentTypeId,
                            Description = assessmentTypeDescription,
                        },
                        Claimant = new Claims.Claimant
                        {
                            FirstName = claimantFirstName,
                            LastName = claimantLastName,
                        },
                        ReferralSource = new Referrals.ReferralSource
                        {
                            Name = referralSourceName,
                        },
                        Company = new Companies.Company
                        {
                            CompanyId = companyId,
                        },
                    },
                    IsCompletion = true,
                    Location = new Addresses.Address
                    {
                        City = new Cities.City
                        {
                            CityId = cityId,
                            Name = cityName,
                        }
                    },
                    Psychometrist = new Users.User
                    {
                        UserId = userId,
                    },
                },
            };

            var psychometristInvoiceGenerator = GetService(
                (invoiceRepositoryMock, appointmentRepositoryMock, userRepositoryMock, dateServiceMock) =>
                {
                    invoiceRepositoryMock.Setup(invoiceRepository => invoiceRepository.GetPsychometristInvoiceAmount(
                        It.Is<int>(i => i == assessmentTypeId),
                        It.Is<int>(i => i == Appointments.AppointmentStatus.NoShow),
                        It.Is<int>(i => i == Appointments.AppointmentSequence.First),
                        It.Is<int>(i => i == companyId))
                    ).Returns(new PsychometristInvoiceAmount
                    {
                        AssessmentType = new Assessments.AssessmentType { AssessmentTypeId = assessmentTypeId },
                        AppointmentStatus = new Appointments.AppointmentStatus { AppointmentStatusId = Appointments.AppointmentStatus.NoShow },
                        AppointmentSequence = new Appointments.AppointmentSequence { AppointmentSequenceId = Appointments.AppointmentSequence.First },
                        InvoiceAmount = appointmentCompletionAmount,
                    });

                    invoiceRepositoryMock.Setup(invoiceRepository => invoiceRepository.GetPsychometristInvoiceAmount(
                        It.Is<int>(i => i == assessmentTypeId),
                        It.Is<int>(i => i == Appointments.AppointmentStatus.Incomplete),
                        It.Is<int>(i => i == Appointments.AppointmentSequence.First),
                        It.Is<int>(i => i == companyId))
                    ).Returns(new PsychometristInvoiceAmount
                    {
                        AssessmentType = new Assessments.AssessmentType { AssessmentTypeId = assessmentTypeId },
                        AppointmentStatus = new Appointments.AppointmentStatus { AppointmentStatusId = Appointments.AppointmentStatus.Incomplete },
                        AppointmentSequence = new Appointments.AppointmentSequence { AppointmentSequenceId = Appointments.AppointmentSequence.First },
                        InvoiceAmount = appointmentIncompleteAmount,
                    });

                    invoiceRepositoryMock.Setup(invoiceRepository => invoiceRepository.GetPsychometristInvoiceAmount(
                        It.Is<int>(i => i == assessmentTypeId),
                        It.Is<int>(i => i == Appointments.AppointmentStatus.Incomplete),
                        It.Is<int>(i => i == Appointments.AppointmentSequence.Subsequent),
                        It.Is<int>(i => i == companyId))
                    ).Returns(new PsychometristInvoiceAmount
                    {
                        AssessmentType = new Assessments.AssessmentType { AssessmentTypeId = assessmentTypeId },
                        AppointmentStatus = new Appointments.AppointmentStatus { AppointmentStatusId = Appointments.AppointmentStatus.Incomplete },
                        AppointmentSequence = new Appointments.AppointmentSequence { AppointmentSequenceId = Appointments.AppointmentSequence.Subsequent },
                        InvoiceAmount = appointmentCompletionAmount,
                    });

                    invoiceRepositoryMock.Setup(invoiceRepository => invoiceRepository.GetPsychometristInvoiceAmount(
                        It.Is<int>(i => i == assessmentTypeId),
                        It.Is<int>(i => i == Appointments.AppointmentStatus.Complete),
                        It.Is<int>(i => i == Appointments.AppointmentSequence.Subsequent),
                        It.Is<int>(i => i == companyId))
                    ).Returns(new PsychometristInvoiceAmount
                    {
                        AssessmentType = new Assessments.AssessmentType { AssessmentTypeId = assessmentTypeId },
                        AppointmentStatus = new Appointments.AppointmentStatus { AppointmentStatusId = Appointments.AppointmentStatus.Complete },
                        AppointmentSequence = new Appointments.AppointmentSequence { AppointmentSequenceId = Appointments.AppointmentSequence.Subsequent },
                        InvoiceAmount = appointmentCompletionAmount,
                    });

                    appointmentRepositoryMock
                        .Setup(appointmentRepository => appointmentRepository.GetAppointmentsForPsychometristInvoice(It.IsAny<Appointments.AppointmentSearchCriteria>()))
                        .Returns(appointments);

                    userRepositoryMock
                        .Setup(userRepository => userRepository.GetUserById(It.Is<int>(i => i == userId)))
                        .Returns(new Users.User
                        {
                            UserId = userId,
                            Company = new Companies.Company
                            {
                                CompanyId = companyId,
                                Timezone = timezone,
                            },
                            TravelFees = new[]
                            {
                                new Users.UserTravelFee
                                {
                                    City = new Cities.City
                                    {
                                        CityId = cityId,
                                        Name = cityName,
                                    },
                                    Amount = travelFeeAmount,
                                }
                            },
                        });
                });

            var invoiceLineGroupWithCustomLinesId = 2;

            var invoice = new Invoice
            {
                InvoiceId = 1,
                InvoiceDate = DateTimeOffset.UtcNow,
                InvoiceType = new InvoiceType
                {
                    InvoiceTypeId = InvoiceType.Psychometrist,
                },
                TaxRate = taxRate,
                PayableTo = new Users.User
                {
                    UserId = userId,
                    Company = new Companies.Company
                    {
                        CompanyId = companyId,
                    },
                },
                LineGroups = new[]
                {
                    new InvoiceLineGroup
                    {
                        InvoiceLineGroupId = 1,
                        Appointment = appointments[0],
                        Lines = new List<InvoiceLine>(new[]
                        {
                            new InvoiceLine
                            {
                                InvoiceLineId = 1,
                                Amount = appointmentCompletionAmount,
                                Description = "Psychological Assessment - No Show",
                            },
                            new InvoiceLine
                            {
                                InvoiceLineId = 2,
                                Amount = travelFeeAmount + 5000,
                                Description = "Travel to Oakville",
                            },
                        }),
                    },
                    new InvoiceLineGroup
                    {
                        InvoiceLineGroupId = invoiceLineGroupWithCustomLinesId,
                        Appointment = appointments[1],
                        Lines = new List<InvoiceLine>(new[]
                        {
                            new InvoiceLine
                            {
                                InvoiceLineId = 3,
                                Amount = appointmentIncompleteAmount,
                                Description = "Psychological Assessment - Incomplete",
                            },
                            new InvoiceLine
                            {
                                InvoiceLineId = 4,
                                Amount = travelFeeAmount + 5000,
                                Description = "Travel to Oakville",
                            },
                            new InvoiceLine
                            {
                                InvoiceLineId = 5,
                                Amount = 2500,
                                Description = "Tip",
                                IsCustom = true,
                            },
                            new InvoiceLine
                            {
                                InvoiceLineId = 6,
                                Amount = 1000,
                                Description = "Gas Money",
                                IsCustom = true
                            },
                        }),
                    },
                }
            };

            var lineGroups = psychometristInvoiceGenerator.GetInvoiceLineGroups(invoice);

            //verify custom lines are still present
            foreach (var invoiceLine in invoice.LineGroups.SelectMany(ia => ia.Lines).Where(il => il.IsCustom))
            {
                Assert.IsTrue(
                    lineGroups.Any(lineGroup =>
                        lineGroup.InvoiceLineGroupId == invoiceLineGroupWithCustomLinesId &&
                        lineGroup.Lines.Any(line =>
                            line.InvoiceLineId == invoiceLine.InvoiceLineId &&
                            line.IsCustom == invoiceLine.IsCustom &&
                            line.Amount == invoiceLine.Amount &&
                            line.Description == invoiceLine.Description
                        )
                    )
                );
            }

            var customLineTotal = invoice.LineGroups.SelectMany(ia => ia.Lines)
                .Where(invoiceLine => invoiceLine.IsCustom)
                .Select(invoiceLine => invoiceLine.Amount)
                .Sum();

            var expectedAmount = Convert.ToInt32(
                (
                    appointmentCompletionAmount + //no show appointment
                    travelFeeAmount +               //travel for no show appointment
                    appointmentIncompleteAmount + //incomplete appointment
                    travelFeeAmount +               //travel for incomplete appointment
                    customLineTotal +               //custom lines for incomplete appointment
                    appointmentCompletionAmount + //completion appointment
                    travelFeeAmount                 //travel for completion appointment
                ) * (1 + taxRate)
            );

            invoice.LineGroups = lineGroups;

            var actualAmount = psychometristInvoiceGenerator.GetInvoiceTotal(invoice);

            Assert.AreEqual(expectedAmount, actualAmount);
        }

        [TestMethod]
        public void GetInvoiceTotalSumsInvoiceLinesAndAddsTax()
        {
            var taxRate = 0.147m;
            
            var invoice = new Invoice
            {
                TaxRate = taxRate,
                LineGroups = new List<InvoiceLineGroup>(
                    new[]
                    {
                        new InvoiceLineGroup
                        {
                            Lines = new[]
                            {
                                new InvoiceLine
                                {
                                    Amount = 15000,
                                    Description = "Psychological Assessment",
                                },
                                new InvoiceLine
                                {
                                    Amount = 7555,
                                    Description = "Travel to London",
                                },
                            }
                        },
                        new InvoiceLineGroup
                        {
                            Lines = new[]
                            {
                                new InvoiceLine
                                {
                                    Amount = 33000,
                                    Description = "Neurocognitive Assessment",
                                },
                            }
                        }
                    }),
            };
            
            var psychometristInvoiceGenerator = GetService();

            var expectedSubtotal = 55555 * (1 + taxRate);

            var expected = Convert.ToInt32(expectedSubtotal);

            var actual = psychometristInvoiceGenerator.GetInvoiceTotal(invoice);

            Assert.AreEqual(expected, actual);
        }
        
    }
}
