﻿using PsychologicalServices.Models.Common.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Reports
{
    public class ReportStatusValidator : IReportStatusValidator
    {
        public IValidationResult Validate(ReportStatus item)
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

            result.IsValid = !result.ValidationErrors.Any();

            return result;
        }
    }
}
