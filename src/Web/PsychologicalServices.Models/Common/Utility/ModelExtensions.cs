using System;

namespace PsychologicalServices.Models.Common.Utility
{
    public static class ModelExtensions
    {
        public static int YearsFrom(this DateTime d1, DateTime d2)
        {
            DateTime earlier = d1 < d2 ? d1 : d2;
            DateTime later = d1 < d2 ? d2 : d1;

            var years = later.Year - earlier.Year;

            if (earlier > later.AddYears(-years))
            {
                years--;
            }

            return years;
        }

        public static DateTime StartOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }

        public static DateTime EndOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1).AddMonths(1).AddSeconds(-1);
        }

        public static DateTime FirstDayOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }

        public static DateTime LastDayOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1).AddMonths(1).AddDays(-1);
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
    }
}
