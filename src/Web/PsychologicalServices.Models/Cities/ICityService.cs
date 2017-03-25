using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Cities
{
    public interface ICityService
    {
        City GetCity(int id);

        IEnumerable<City> GetCities(bool? isActive = true);

        SaveResult<City> SaveCity(City city);
    }
}
