using System;

namespace PsychologicalServices.Models.Common.Utility
{
    public static class ModelExtensions
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

        public static DateTime StartOfWeek(this DateTime date, DayOfWeek firstDayOfWeek = DayOfWeek.Monday)
        {
            DateTime start = date.Date;

            var direction = start.DayOfWeek < firstDayOfWeek ? 1 : -1;

            while (start.DayOfWeek != firstDayOfWeek)
            {
                start = start.AddDays(direction);
            }

            return start;
        }

        public static DateTime EndOfWeek(this DateTime date, DayOfWeek firstDayOfWeek = DayOfWeek.Monday, DayOfWeek lastDayOfWeek = DayOfWeek.Friday)
        {
            DateTime end = date.Date;

            var direction = end.DayOfWeek > lastDayOfWeek ? -1 : 1;

            while (end.DayOfWeek != lastDayOfWeek)
            {
                end = end.AddDays(direction);
            }

            return end;
        }
        
        public static DateTime StartOfDay(this DateTime date)
        {
            return date.Date;
        }

        public static DateTime EndOfDay(this DateTime date)
        {
            return StartOfDay(date).AddDays(1).AddSeconds(-1);
        }
    }
}
