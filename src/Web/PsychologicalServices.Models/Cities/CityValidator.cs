using PsychologicalServices.Models.Common.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Cities
{
    public class CityValidator : ICityValidator
    {
        private const string ProvincePattern = @"[A-Za-z]{2}";
        
        public IValidationResult Validate(City item)
        {
            var result = new ValidationResult
            {
                ValidationErrors = new List<IValidationError>(),
            };

            if (string.IsNullOrWhiteSpace(item.Name))
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "Name", Message = "City name is required" }
                );
            }

            if (string.IsNullOrWhiteSpace(item.Province))
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "Province", Message = "Province is required" }
                );
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(item.Province, ProvincePattern))
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "Province", Message = "Province must be a two letter abbreviation" }
                );
            }

            if (string.IsNullOrWhiteSpace(item.Country))
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "Country", Message = "Country is required" }
                );
            }
            else if (!new[] { "canada", "usa"}.Contains(item.Country.ToLower()))
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "Country", Message = "Country must be Canada or USA" }
                );
            }

            result.IsValid = !result.ValidationErrors.Any();

            return result;
        }
    }
}
