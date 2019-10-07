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
            var month = 11;
            var day = 4;
            var offset = -4;
            var timezone = "Eastern Standard Time";

            var utcDate = new DateTimeOffset(year, month, day, 12, 0, 0, TimeSpan.Zero);

            var expected = new DateTimeOffset(year, month, day, 0, 0, 0, TimeSpan.FromHours(offset)).AddDays(1).AddSeconds(-1);

            var actual = utcDate.EndOfDay(timezone);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EndOfDayReturnsCorrectDayForUtcDate4()
        {
            var year = 2017;
            var month = 11;
            var day = 5;
            var offset = -5;
            var timezone = "Eastern Standard Time";

            var utcDate = new DateTimeOffset(year, month, day, 12, 0, 0, TimeSpan.Zero);

            var expected = new DateTimeOffset(year, month, day, 0, 0, 0, TimeSpan.FromHours(offset)).AddDays(1).AddSeconds(-1);

            var actual = utcDate.EndOfDay(timezone);

            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void StartOfDayReturnsCorrectDayWhen36HoursIsAddedToPreDstDate()
        {
            var year = 2017;
            var month = 11;
            var day = 5;
            var offset = -4;
            var timezone = "Eastern Standard Time";

            var startDate = new DateTimeOffset(year, month, day, 0, 0, 0, TimeSpan.FromHours(offset));

            var expected = new DateTimeOffset(year, month, day + 1, 0, 0, 0, TimeSpan.FromHours(offset - 1));

            var actual = startDate.AddDays(1).AddHours(12).StartOfDay(timezone);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void YearsFromReturnsCorrectValue1()
        {
            var value1 = new DateTimeOffset(2017, 12, 11, 12, 00, 00, TimeSpan.FromHours(-5));

            var value2 = new DateTimeOffset(1979, 1, 23, 7, 30, 0, TimeSpan.FromHours(-5));

            var expected = 38;

            var actual = value1.YearsFrom(value2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void YearsFromReturnsCorrectValue2()
        {
            var value1 = new DateTimeOffset(2017, 1, 1, 0, 0, 0, TimeSpan.FromHours(-5));

            var value2 = new DateTimeOffset(1979, 1, 1, 7, 30, 0, TimeSpan.FromHours(-5));

            var expected = 37;

            var actual = value1.YearsFrom(value2);

            Assert.AreEqual(expected, actual);
        }
    }

    [TestClass]
    public class When_Date_Is_After_Sunday
    {
        [TestMethod]
        public void TwoSundaysAfter_Returns_Correct_Date()
        {
            //a monday
            var d = new DateTimeOffset(2019, 10, 7, 0, 0, 0, TimeSpan.Zero);

            var twoSundaysLater = d.TwoSundaysAfter();

            Assert.AreEqual(DayOfWeek.Sunday, twoSundaysLater.DayOfWeek);

            Assert.AreEqual(d.Offset, twoSundaysLater.Offset);
        }
    }

    [TestClass]
    public class When_Date_Is_Sunday
    {
        [TestMethod]
        public void TwoSundaysAfter_Returns_Correct_Date()
        {
            //a sunday
            var d = new DateTimeOffset(2019, 10, 6, 0, 0, 0, TimeSpan.Zero);

            var twoSundaysLater = d.TwoSundaysAfter();

            Assert.AreEqual(DayOfWeek.Sunday, twoSundaysLater.DayOfWeek);

            Assert.AreEqual(d.Offset, twoSundaysLater.Offset);
        }
    }
}
