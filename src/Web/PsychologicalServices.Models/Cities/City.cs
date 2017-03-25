using System;

namespace PsychologicalServices.Models.Cities
{
    public class City
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public bool IsActive { get; set; }

        public bool IsNew()
        {
            return CityId == 0;
        }
    }
}
