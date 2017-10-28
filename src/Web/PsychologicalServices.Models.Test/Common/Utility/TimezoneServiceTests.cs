using Microsoft.VisualStudio.TestTools.UnitTesting;
using PsychologicalServices.Models.Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalServices.Models.Test.Common.Utility
{
    [TestClass]
    public class TimezoneServiceTests
    {
        [TestMethod]
        public void ConvertTimeConvertsDateTimeOffset()
        {
            var timezoneService = new TimezoneService();

            var year = 2017;
            var month = 9;
            var day = 18;
            var offset = -4;

            var date = new DateTimeOffset(new DateTime(year, month, day).AddHours(offset * -1), TimeSpan.Zero);

            var displayDate = timezoneService.ConvertTime(date, timezoneService.GetTimeZoneInfo("Eastern Standard Time"));

            var display = string.Format("{0:MMMM dd, yyyy HH:mm}", displayDate);
        }

        [TestMethod]
        public void ConvertTimeAdjustsForDaylightSavingsTime()
        {
            var timezoneId = "Eastern Standard Time";

            var year = 2017;
            var month = 11;

            //[pre-converted day, pre-converted hour, pre-converted minute, pre-converted second, converted day, converted hour, converted minute, converted second]
            var date1Values = new[] { 5, 3, 59, 59, 4, 23, 59, 59 };
            var date2Values = new[] { 6, 5, 0, 0, 6, 0, 0, 0 };

            var dates = new List<DateTimeOffset>
            {
                new DateTimeOffset(year, month, date1Values[0], date1Values[1], date1Values[2], date1Values[3], TimeSpan.Zero),
                new DateTimeOffset(year, month, date2Values[0], date2Values[1], date2Values[2], date2Values[3], TimeSpan.Zero),
            };

            var timezoneService = new TimezoneService();

            var date1Converted = timezoneService.ConvertTimeBySystemTimeZoneId(dates[0], timezoneId);

            Assert.AreEqual(year, date1Converted.Year);
            Assert.AreEqual(month, date1Converted.Month);
            Assert.AreEqual(date1Values[4], date1Converted.Day);
            Assert.AreEqual(date1Values[5], date1Converted.Hour);
            Assert.AreEqual(date1Values[6], date1Converted.Minute);
            Assert.AreEqual(date1Values[7], date1Converted.Second);

            var date2Converted = timezoneService.ConvertTimeBySystemTimeZoneId(dates[1], timezoneId);

            Assert.AreEqual(year, date1Converted.Year);
            Assert.AreEqual(month, date1Converted.Month);
            Assert.AreEqual(date2Values[4], date2Converted.Day);
            Assert.AreEqual(date2Values[5], date2Converted.Hour);
            Assert.AreEqual(date2Values[6], date2Converted.Minute);
            Assert.AreEqual(date2Values[7], date2Converted.Second);

        }
    }
}
