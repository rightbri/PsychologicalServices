using System;

namespace PsychologicalServices.Models.Common.Utility
{
    public interface ITimezoneService
    {
        DateTimeOffset GetDateTimeOffset(DateTime dateTime, TimeZoneInfo timeZoneInfo);

        TimeZoneInfo GetTimeZoneInfo(string timezone);
    }
}
