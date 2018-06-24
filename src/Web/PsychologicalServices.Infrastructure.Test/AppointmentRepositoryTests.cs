using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace PsychologicalServices.Infrastructure.Test
{
    [TestClass]
    public class AppointmentRepositoryTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var configurationServiceMock = new Mock<Models.Common.Configuration.IConfigurationService>();
            var connectionString = @"Data Source=(local)\SQLEXPRESS2017;Initial Catalog=PsychologicalServices;Integrated Security=True";
            configurationServiceMock.Setup(cs => cs.ConnectionStringValue(It.IsAny<string>())).Returns(() => connectionString);
            
            var adapterFactory = new Common.Repository.SqlServerAdapterFactory(
                    new Common.Repository.DataConnectionParametersFactory(
                        configurationServiceMock.Object
                    )
                );

            var repo = new Appointments.AppointmentRepository(
                adapterFactory,
                new Models.Common.Utility.Date(),
                new Companies.CompanyRepository(adapterFactory),
                new Attributes.AttributeRepository(adapterFactory),
                new Models.Common.Utility.TimezoneService()
            );

            var criteria = new Models.Appointments.AppointmentSearchCriteria
            {
                CompanyId = 1,
                AppointmentTimeStart = new DateTimeOffset(2017, 01, 1, 0, 0, 0, TimeSpan.FromHours(-4)),
                AppointmentTimeEnd = new DateTimeOffset(2017, 12, 31, 0, 0, 0, TimeSpan.FromHours(-4)),
            };

            var appointments = repo.GetAppointmentsForPsychometristInvoice(criteria);

            var appointment = appointments
                .Where(appt => appt.Psychometrist.TravelFees.Any())
                .First();

            Assert.IsNotNull(appointment.AppointmentStatus);

            Assert.IsNotNull(appointment.Psychometrist);

            Assert.IsTrue(appointment.Psychometrist.TravelFees.Any());

            Assert.IsTrue(appointment.Psychometrist.TravelFees.All(travelFee => null != travelFee.City));

            Assert.IsNotNull(appointment.Assessment);

            Assert.IsNotNull(appointment.Assessment.ReferralSource);

            Assert.IsNotNull(appointment.Assessment.Company);


            /*
             Appointments
                AppointmentStatus
                Location
                    City
                Psychometrist
                    TravelFees
                        City
                Assessment
                    AssessmentType
                    ReferralSource
                    Appointments
                    Company
            */
        }
    }
}
