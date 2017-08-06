﻿using System;

namespace PsychologicalServices.Models.Common.Utility
{
    public class TimezoneService : ITimezoneService
    {
        public DateTimeOffset GetDateTimeOffset(DateTime dateTime, TimeZoneInfo timeZoneInfo)
        {
            var utcOffset = timeZoneInfo.GetUtcOffset(dateTime);

            var dateTimeOffset = new DateTimeOffset(dateTime, utcOffset);

            return dateTimeOffset;
        }

        public DateTime ConvertFromUtc(DateTime utcDateTime, TimeZoneInfo timeZoneInfo)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, timeZoneInfo);
        }

        public TimeZoneInfo GetTimeZoneInfo(string timezone)
        {
            return TimeZoneInfo.FindSystemTimeZoneById(timezone);
        }
    }
}