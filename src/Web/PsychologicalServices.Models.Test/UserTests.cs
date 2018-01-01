using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PsychologicalServices.Models.Users;

namespace PsychologicalServices.Models.Test
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void IsAvailableReturnsTrueWhenIsActiveIsTrueAndUnavailabilityIsNull()
        {
            var user = new User
            {
                IsActive = true,
                Unavailability = null,
            };

            var availabilityDate = DateTime.Now;

            var expected = true;

            var actual = user.IsAvailable(availabilityDate);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsAvailableReturnsTrueWhenIsActiveIsTrueAndDateParameterValueIsOutsideUnavailability()
        {
            var user = new User
            {
                IsActive = true,
                Unavailability = new[] { new Unavailability { StartDate = DateTime.Today.AddDays(1), EndDate = DateTime.Today.AddDays(2) } },
            };

            var availabilityDate = DateTime.Now;

            var expected = true;

            var actual = user.IsAvailable(availabilityDate);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsAvailableReturnsFalseWhenIsActiveIsTrueAndDateParameterValueIsInsideUnavailability()
        {
            var user = new User
            {
                IsActive = true,
                Unavailability = new[] { new Unavailability { StartDate = DateTime.Today, EndDate = DateTime.Today.AddDays(1) } },
            };

            var availabilityDate = DateTime.Now;

            var expected = false;

            var actual = user.IsAvailable(availabilityDate);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsAvailableReturnsTrueWhenIsActiveIsTrueAndDateInactivatedIsNull()
        {
            var user = new User
            {
                IsActive = true,
                DateInactivated = null,
                Unavailability = null,
            };

            var availabilityDate = DateTime.Now;

            var expected = true;

            var actual = user.IsAvailable(availabilityDate);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsAvailableReturnsTrueWhenIsActiveIsTrueAndDateInactivatedIsBeforeDateParameterValue()
        {
            var user = new User
            {
                IsActive = true,
                DateInactivated = DateTime.Today,
                Unavailability = null,
            };

            var availabilityDate = DateTime.Now;

            var expected = true;

            var actual = user.IsAvailable(availabilityDate);

            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void IsAvailableReturnsTrueWhenIsActiveIsTrueAndDateInactivatedIsAfterDateParameterValue()
        {
            var user = new User
            {
                IsActive = true,
                DateInactivated = DateTime.Now.AddDays(1),
                Unavailability = null,
            };

            var availabilityDate = DateTime.Now;

            var expected = true;

            var actual = user.IsAvailable(availabilityDate);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsAvailableReturnsFalseWhenIsActiveIsFalseAndDateInactivatedIsNull()
        {
            var user = new User
            {
                IsActive = false,
                DateInactivated = null,
                Unavailability = null,
            };

            var availabilityDate = DateTime.Now;

            var expected = false;

            var actual = user.IsAvailable(availabilityDate);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsAvailableReturnsFalseWhenIsActiveIsFalseAndDateInactivatedIsBeforeDateParameterValue()
        {
            var user = new User
            {
                IsActive = false,
                DateInactivated = DateTime.Today,
                Unavailability = null,
            };

            var availabilityDate = DateTime.Now;

            var expected = false;

            var actual = user.IsAvailable(availabilityDate);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsAvailableReturnsTrueWhenIsActiveIsFalseAndDateInactivatedIsAfterDateParameterValue()
        {
            var user = new User
            {
                IsActive = false,
                DateInactivated = DateTime.Now.AddDays(1),
                Unavailability = null,
            };

            var availabilityDate = DateTime.Now;

            var expected = true;

            var actual = user.IsAvailable(availabilityDate);

            Assert.AreEqual(expected, actual);
        }
    }
}
