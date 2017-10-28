using System;

namespace PsychologicalServices.Models.Common.Utility
{
    public interface ITimezoneService
    {
        DateTimeOffset GetDateTimeOffset(DateTime dateTime, TimeZoneInfo timeZoneInfo);

        DateTimeOffset ConvertTime(DateTimeOffset dateTimeOffset, TimeZoneInfo timeZoneInfo);

        DateTime ConvertFromUtc(DateTime utcDateTime, TimeZoneInfo timeZoneInfo);

        DateTimeOffset ConvertTimeBySystemTimeZoneId(DateTimeOffset dateTimeOffset, string timezoneId);

        TimeZoneInfo GetTimeZoneInfo(string timezone);
    }
}
