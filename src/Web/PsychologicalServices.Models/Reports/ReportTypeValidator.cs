using PsychologicalServices.Models.Common.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Reports
{
    public class ReportTypeValidator : IReportTypeValidator
    {
        public IValidationResult Validate(ReportType item)
        {
            var result = new ValidationResult
            {
                ValidationErrors = new List<IValidationError>(),
            };

            if (string.IsNullOrWhiteSpace(item.Name))
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "Name", Message = "Name is required" }
                );
            }

            if (item.NumberOfReports < 0)
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "NumberOfReports", Message = "Number of reports must be greater than or equal to zero" }
                );
            }

            result.IsValid = !result.ValidationErrors.Any();

            return result;
        }
    }
}
