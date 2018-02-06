using System;
using System.Collections.Generic;
using System.Linq;
using PsychologicalServices.Models.Common.Validation;
using PsychologicalServices.Models.Contacts;
using PsychologicalServices.Models.Assessments;

namespace PsychologicalServices.Models.Arbitrations
{
    public class ArbitrationValidator : IArbitrationValidator
    {
        private readonly IAssessmentRepository _assessmentRepository = null;
        private readonly IContactRepository _contactRepository = null;

        public ArbitrationValidator(
            IAssessmentRepository assessmentRepository,
            IContactRepository contactRepository
        )
        {
            _assessmentRepository = assessmentRepository;
            _contactRepository = contactRepository;
        }

        public IValidationResult Validate(Arbitration item)
        {
            if (null == item)
            {
                throw new ArgumentNullException("item");
            }

            var result = new ValidationResult
            {
                ValidationErrors = new List<IValidationError>(),
            };

            if (null != item.Assessment)
            {
                var assessment = _assessmentRepository.GetAssessment(item.Assessment.AssessmentId);

                if (null == assessment)
                {
                    result.ValidationErrors.Add(
                        new ValidationError { PropertyName = "AssessmentId", Message = GetValidationMessage(item, "Invalid Assessment") }
                    );
                }
            }

            if (string.IsNullOrWhiteSpace(item.Title))
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "Title", Message = GetValidationMessage(item, "Title is required") }
                );
            }

            if (item.StartDate.HasValue && item.EndDate.HasValue && item.StartDate > item.EndDate)
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "EndDate", Message = GetValidationMessage(item, "End Date must be after Start Date") }
                );
            }

            if ((item.AvailableDate.HasValue && item.AvailableDate < item.StartDate) ||
                (item.AvailableDate.HasValue && item.EndDate.HasValue && item.AvailableDate > item.EndDate))
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "AvailableDate", Message = GetValidationMessage(item, "Available Date must be within Start and End dates") }
                );
            }

            if (null != item.DefenseLawyer)
            {
                var lawyer = _contactRepository.GetContactById(item.DefenseLawyer.ContactId);

                if (null == lawyer)
                {
                    result.ValidationErrors.Add(
                        new ValidationError { PropertyName = "DefenseLawyerId", Message = GetValidationMessage(item, "Invalid Defense Lawyer") }
                    );
                }
                else if (lawyer.ContactType.ContactTypeId != ContactType.Lawyer)
                {
                    result.ValidationErrors.Add(
                        new ValidationError { PropertyName = "DefenseLawyerId", Message = GetValidationMessage(item, "Selected Defense Lawyer is not a lawyer contact type") }
                    );
                }
            }

            result.IsValid = !result.ValidationErrors.Any();

            return result;
        }
        
        private string GetValidationMessage(Arbitration item, string message)
        {
            return string.Format("{0}{1}", GetMessagePrefix(item), message);
        }

        private string GetMessagePrefix(Arbitration item)
        {
            return string.Format("Arbitration starting {0:MMMM d, yyyy}: ", item.StartDate);
        }
    }
}
