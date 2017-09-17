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
    }
}
