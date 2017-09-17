using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PsychologicalServices.Models.Common.Utility;

namespace PsychologicalServices.Models.Test.Common.Utility
{
    [TestClass]
    public class DateExtensionsTests
    {
        [TestMethod]
        public void IsWithinReturnsTrueWhenDateIsEqualToStartOfCompareRange()
        {
            var year = 2017;
            var month = 9;
            var day = 18;
            var offset = -4;

            var utcDate = new DateTimeOffset(year, month, day, offset * -1, 0, 0, TimeSpan.Zero);

            var rangeStart = new DateTimeOffset(year, month, day, 0, 0, 0, TimeSpan.FromHours(offset));
            
            var rangeEnd = rangeStart.AddDays(1).AddHours(-1);

            var expected = true;

            var actual = utcDate.IsWithin(rangeStart, rangeEnd);

            Assert.AreEqual(expected, actual);

            Assert.AreEqual(utcDate, rangeStart);
        }

        [TestMethod]
        public void IsWithinReturnsTrueWhenDateIsEqualToEndOfCompareRange()
        {
            var year = 2017;
            var month = 9;
            var day = 18;
            var offset = -4;

            var utcDate = new DateTimeOffset(year, month, day, offset * -1, 0, 0, TimeSpan.Zero).AddDays(1).AddSeconds(-1);

            var rangeStart = new DateTimeOffset(year, month, day, 0, 0, 0, TimeSpan.FromHours(offset));

            var rangeEnd = rangeStart.AddDays(1).AddSeconds(-1);

            var expected = true;

            var actual = utcDate.IsWithin(rangeStart, rangeEnd);

            Assert.AreEqual(expected, actual);

            Assert.AreEqual(utcDate, rangeEnd);
        }

        [TestMethod]
        public void IsWithinReturnsFalseWhenDateIsBeforeStartOfCompareRange()
        {
            var year = 2017;
            var month = 9;
            var day = 18;
            var offset = -4;

            var utcDate = new DateTimeOffset(year, month, day, offset * -1, 0, 0, TimeSpan.Zero).AddSeconds(-1);

            var rangeStart = new DateTimeOffset(year, month, day, 0, 0, 0, TimeSpan.FromHours(offset));

            var rangeEnd = rangeStart.AddDays(1).AddHours(-1);

            var expected = false;

            var actual = utcDate.IsWithin(rangeStart, rangeEnd);

            Assert.AreEqual(expected, actual);

            Assert.IsTrue(utcDate < rangeStart);
        }

        [TestMethod]
        public void IsWithinReturnsFalseWhenDateIsAfterEndOfCompareRange()
        {
            var year = 2017;
            var month = 9;
            var day = 18;
            var offset = -4;

            var utcDate = new DateTimeOffset(year, month, day, offset * -1, 0, 0, TimeSpan.Zero).AddDays(1);

            var rangeStart = new DateTimeOffset(year, month, day, 0, 0, 0, TimeSpan.FromHours(offset));

            var rangeEnd = rangeStart.AddDays(1).AddSeconds(-1);

            var expected = false;

            var actual = utcDate.IsWithin(rangeStart, rangeEnd);

            Assert.AreEqual(expected, actual);

            Assert.IsTrue(utcDate > rangeEnd);
        }

        [TestMethod]
        public void StartOfDayReturnsCorrectDayForUtcDate1()
        {
            var year = 2017;
            var month = 9;
            var day = 18;
            var offset = -4;
            var timezone = "Eastern Standard Time";

            var utcDate = new DateTimeOffset(year, month, day, 0, 0, 0, TimeSpan.Zero).AddDays(1).AddHours(offset * -1).AddSeconds(-1);

            var expected = new DateTimeOffset(year, month, day, 0, 0, 0, TimeSpan.FromHours(offset));

            var actual = utcDate.StartOfDay(timezone);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StartOfDayReturnsCorrectDayForUtcDate2()
        {
            var year = 2017;
            var month = 9;
            var day = 18;
            var offset = -4;
            var timezone = "Eastern Standard Time";

            var utcDate = new DateTimeOffset(year, month, day, 0, 0, 0, TimeSpan.Zero);

            var expected = new DateTimeOffset(year, month, day, 0, 0, 0, TimeSpan.FromHours(offset)).AddDays(-1);

            var actual = utcDate.StartOfDay(timezone);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StartOfDayReturnsCorrectDayForUtcDate3()
        {
            var year = 2017;
            var month = 9;
            var day = 18;
            var offset = -4;
            var timezone = "Eastern Standard Time";

            var utcDate = new DateTimeOffset(year, month, day, 12, 0, 0, TimeSpan.Zero);

            var expected = new DateTimeOffset(year, month, day, 0, 0, 0, TimeSpan.FromHours(offset));

            var actual = utcDate.StartOfDay(timezone);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EndOfDayReturnsCorrectDayForUtcDate1()
        {
            var year = 2017;
            var month = 9;
            var day = 18;
            var offset = -4;
            var timezone = "Eastern Standard Time";

            var utcDate = new DateTimeOffset(year, month, day, 0, 0, 0, TimeSpan.Zero).AddDays(1).AddHours(offset * -1).AddSeconds(-1);

            var expected = new DateTimeOffset(year, month, day, 23, 59, 59, TimeSpan.FromHours(offset));

            var actual = utcDate.EndOfDay(timezone);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EndOfDayReturnsCorrectDayForUtcDate2()
        {
            var year = 2017;
            var month = 9;
            var day = 18;
            var offset = -4;
            var timezone = "Eastern Standard Time";

            var utcDate = new DateTimeOffset(year, month, day, 0, 0, 0, TimeSpan.Zero);

            var expected = new DateTimeOffset(year, month, day, 0, 0, 0, TimeSpan.FromHours(offset)).AddSeconds(-1);

            var actual = utcDate.EndOfDay(timezone);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EndOfDayReturnsCorrectDayForUtcDate3()
        {
            var year = 2017;
            var month = 9;
            var day = 18;
            var offset = -4;
            var timezone = "Eastern Standard Time";

            var utcDate = new DateTimeOffset(year, month, day, 12, 0, 0, TimeSpan.Zero);

            var expected = new DateTimeOffset(year, month, day, 0, 0, 0, TimeSpan.FromHours(offset)).AddDays(1).AddSeconds(-1);

            var actual = utcDate.EndOfDay(timezone);

            Assert.AreEqual(expected, actual);
        }
    }
}
