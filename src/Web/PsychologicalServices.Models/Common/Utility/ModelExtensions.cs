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
    }
}
