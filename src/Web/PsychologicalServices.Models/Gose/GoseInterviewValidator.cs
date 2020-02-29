using PsychologicalServices.Models.Common.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Gose
{
    public class GoseInterviewValidator : IGoseInterviewValidator
    {
        private readonly IGoseRepository _goseRepository = null;

        public GoseInterviewValidator(
            IGoseRepository goseRepository
        )
        {
            _goseRepository = goseRepository;
        }

        public IValidationResult Validate(GoseInterview item)
        {
            if (null == item)
            {
                throw new ArgumentNullException("item");
            }

            var result = new ValidationResult
            {
                ValidationErrors = new List<IValidationError>(),
            };

            if (null == item.Assessment)
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "AssessmentId", Message = "The interview must be associated with an assessment." }
                );
            }

            result.IsValid = !result.ValidationErrors.Any();

            return result;
        }
    }
}
