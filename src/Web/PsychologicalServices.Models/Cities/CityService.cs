using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Cities
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository = null;
        private readonly ICityValidator _cityValidator = null;

        public CityService(
            ICityRepository cityRepository,
            ICityValidator cityValidator
        )
        {
            _cityRepository = cityRepository;
            _cityValidator = cityValidator;
        }

        public City GetCity(int id)
        {
            var city = _cityRepository.GetCity(id);

            return city;
        }

        public IEnumerable<City> GetCities(bool? isActive = true)
        {
            var cities = _cityRepository.GetCities(isActive);

            return cities;
        }

        public SaveResult<City> SaveCity(City city)
        {
            var result = new SaveResult<City>();

            try
            {
                var validation = _cityValidator.Validate(city);

                result.ValidationResult = validation;

                if (result.ValidationResult.IsValid)
                {
                    var id = _cityRepository.SaveCity(city);

                    result.Item = _cityRepository.GetCity(id);
                    result.IsSaved = true;
                }
            }
            catch (Exception ex)
            {
                //TODO: log error
                result.IsError = true;
                result.ErrorDetails = ex.Message;
            }

            return result;
        }
    }
}
