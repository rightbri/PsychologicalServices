using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PsychologicalServices.Models.Common.Utility;

namespace PsychologicalServices.Models.Test.Schedule
{
    [TestClass]
    public class PsychologistScheduleModelTests
    {
        [TestMethod]
        public void lah()
        {
            var days = new List<DateTimeOffset>();

            var displayTimezoneId = "Eastern Standard Time";

            var fromDate = new DateTimeOffset(2017, 11, 4, 0, 0, 0, TimeSpan.FromHours(-4));
            var toDate = new DateTimeOffset(2017, 12, 31, 23, 59, 59, TimeSpan.FromHours(-5));

            var day = fromDate.StartOfDay(displayTimezoneId);

            while (day <= toDate)
            {
                days.Add(day);

                //day = day.AddDays(1);
                day = day.AddHours(36).StartOfDay(displayTimezoneId);
            }


        }
    }
}
