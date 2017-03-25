using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Cities
{
    public interface ICityRepository
    {
        City GetCity(int id);

        IEnumerable<City> GetCities(bool? isActive = true);

        int SaveCity(City city);
    }
}
