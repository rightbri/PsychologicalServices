using System;
using System.Linq;

namespace PsychologicalServices.Models.Common.Utility
{
    public static class DateExtensions
    {
        public static int YearsFrom(this DateTimeOffset d1, DateTimeOffset d2)
        {
            DateTimeOffset earlier = d1 < d2 ? d1 : d2;
            DateTimeOffset later = d1 < d2 ? d2 : d1;

            var years = later.Year - earlier.Year;

            if (earlier > later.AddYears(-years))
            {
                years--;
            }

            return years;
        }

        public static DateTimeOffset StartOfMonth(this DateTimeOffset date, string timezoneId)
        {
            return TimeZoneInfo.ConvertTimeBySystemTimeZoneId(
                new DateTimeOffset(date.Year, date.Month, 1, 0, 0, 0, 0, TimeSpan.Zero),
                timezoneId);
        }

        public static DateTimeOffset EndOfMonth(this DateTimeOffset date, string timezoneId)
        {
            return TimeZoneInfo.ConvertTimeBySystemTimeZoneId(
                new DateTimeOffset(date.Year, date.Month, 1, 0, 0, 0, 0, TimeSpan.Zero)
                    .AddMonths(1)
                    .AddSeconds(-1),
                timezoneId);
        }

        public static DateTimeOffset TwoSundaysAfter(this DateTimeOffset date)
        {
            var secondSundayAfterDate = Enumerable.Range(1, 14)
                .Select(days => new DateTimeOffset(date.Year, date.Month, date.Day, 0, 0, 0, date.Offset).AddDays(days))
                .Where(d => d.DayOfWeek == DayOfWeek.Sunday)
                .Skip(1)
                .First()
                .AddDays(1)
                .AddSeconds(-1);

            return secondSundayAfterDate;
        }

        public static DateTimeOffset InTimezone(this DateTimeOffset date, string timezoneId)
        {
            return TimeZoneInfo.ConvertTimeBySystemTimeZoneId(
                date,
                timezoneId
            );
        }
        
        public static DateTimeOffset StartOfDay(this DateTimeOffset date, string timezoneId)
        {
            var displayDay = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(date, timezoneId);
            
            var startOfDisplayDay = new DateTimeOffset(new DateTime(displayDay.Year, displayDay.Month, displayDay.Day), displayDay.Offset);

            return startOfDisplayDay;
        }

        public static DateTimeOffset EndOfDay(this DateTimeOffset date, string timezoneId)
        {
            return date.StartOfDay(timezoneId).AddDays(1).AddSeconds(-1);
        }

        public static bool IsWithin(this DateTimeOffset date, DateTimeOffset start, DateTimeOffset end)
        {
            return date >= start && date <= end;
        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           