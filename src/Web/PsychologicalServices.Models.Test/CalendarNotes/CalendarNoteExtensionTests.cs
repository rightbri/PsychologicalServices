using Microsoft.VisualStudio.TestTools.UnitTesting;
using PsychologicalServices.Models.CalendarNotes;
using System;

namespace PsychologicalServices.Models.Test.CalendarNotes
{
    [TestClass]
    public class CalendarNoteExtensionTests
    {

        [TestMethod]
        public void AppliesToDayReturnsFalseWhenCalendarNoteIsForBeforeCompareDay()
        {
            var compareDay = new DateTimeOffset(2017, 9, 9, 0, 0, 0, TimeSpan.FromHours(-5));

            var calendarNote = new CalendarNote
            {
                FromDate = new DateTimeOffset(2017, 9, 8, 0, 0, 0, TimeSpan.FromHours(-5)),
                ToDate = new DateTimeOffset(2017, 9, 8, 23, 59, 59, TimeSpan.FromHours(-5)),
            };
            
            var expected = false;

            var actual = calendarNote.AppliesToDay(compareDay);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AppliesToDayReturnsFalseWhenCalendarNoteIsForAfterCompareDay()
        {
            var compareDay = new DateTimeOffset(2017, 9, 9, 0, 0, 0, TimeSpan.FromHours(-5));

            var calendarNote = new CalendarNote
            {
                FromDate = new DateTimeOffset(2017, 9, 10, 0, 0, 0, TimeSpan.FromHours(-5)),
                ToDate = new DateTimeOffset(2017, 9, 10, 0, 0, 0, TimeSpan.FromHours(-5)),
            };

            var expected = false;

            var actual = calendarNote.AppliesToDay(compareDay);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AppliesToDayReturnsTrueWhenCalendarNoteFromDateIsEqualToBeginningOfCompareDay()
        {
            var compareDay = new DateTimeOffset(2017, 9, 9, 0, 0, 0, TimeSpan.FromHours(-5));

            var calendarNote = new CalendarNote
            {
                FromDate = new DateTimeOffset(2017, 9, 9, 5, 0, 0, TimeSpan.Zero),
                ToDate = new DateTimeOffset(2017, 9, 9, 5, 0, 0, TimeSpan.Zero),
            };

            var expected = true;

            var actual = calendarNote.AppliesToDay(compareDay);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AppliesToDayReturnsTrueWhenCalendarNoteFromDateIsEqualToEndOfCompareDay()
        {
            var compareDay = new DateTimeOffset(2017, 9, 9, 0, 0, 0, TimeSpan.FromHours(-5));

            var calendarNote = new CalendarNote
            {
                FromDate = new DateTimeOffset(2017, 9, 10, 4, 59, 59, TimeSpan.Zero),
                ToDate = new DateTimeOffset(2017, 9, 10, 5, 0, 0, TimeSpan.Zero),
            };

            var expected = true;

            var actual = calendarNote.AppliesToDay(compareDay);

            Assert.AreEqual(expected, actual);
        }
    }
}
