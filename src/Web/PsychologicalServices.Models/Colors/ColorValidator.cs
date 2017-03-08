using PsychologicalServices.Models.Common.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Colors
{
    public class ColorValidator : IColorValidator
    {
        private readonly IColorRepository _colorRepository = null;

        public ColorValidator(
            IColorRepository colorRepository
        )
        {
            _colorRepository = colorRepository;
        }

        public IValidationResult Validate(Color item)
        {
            var result = new ValidationResult
            {
                ValidationErrors = new List<IValidationError>(),
            };

            if (string.IsNullOrWhiteSpace(item.Name))
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "Name", Message = "Color Name is required" }
                );
            }

            if (string.IsNullOrWhiteSpace(item.HexCode))
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "HexCode", Message = "Color Value is required" }
                );
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(item.HexCode, @"#[0-9a-fA-F]{6}"))
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "HexCode", Message = "Color Value must match the pattern '#999999'" }
                );
            }

            result.IsValid = !result.ValidationErrors.Any();

            return result;
        }
    }
}
