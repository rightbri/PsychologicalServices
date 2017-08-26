using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PsychologicalServices.Models.Common.Utility;

namespace PsychologicalServices.Models.Test.Common.Utility
{
    [TestClass]
    public class CommonUtilityModelExtensionsTests
    {
        [TestMethod]
        public void StartOfWeekForSundayIsTheFollowingMonday()
        {
            //Sunday July 30th, 2017
            var date = new DateTime(2017, 7, 30);

            var expected = date.AddDays(1);

            var actual = date.StartOfWeek();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StartOfWeekForMondayIsSameMonday()
        {
            //Monday July 31st, 2017
            var date = new DateTime(2017, 7, 31);

            var expected = date;

            var actual = date.StartOfWeek();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StartOfWeekForTuesdayIsPreviousMonday()
        {
            //Tuesday August 1st, 2017
            var date = new DateTime(2017, 8, 1);

            var expected = date.AddDays(-1);

            var actual = date.StartOfWeek();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EndOfWeekForThursdayIsTheFollowingFriday()
        {
            //Thursday August 3rd, 2017
            var date = new DateTime(2017, 8, 3);

            var expected = date.AddDays(1);

            var actual = date.EndOfWeek();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EndOfWeekForFridayIsSameFriday()
        {
            //Friday August 4th, 2017
            var date = new DateTime(2017, 8, 4);

            var expected = date;

            var actual = date.EndOfWeek();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EndOfWeekForSaturdayIsThePreviousFriday()
        {
            //Saturday August 5th, 2017
            var date = new DateTime(2017, 8, 5);

            var expected = date.AddDays(-1);

            var actual = date.EndOfWeek();

            Assert.AreEqual(expected, actual);
        }
    }
}
