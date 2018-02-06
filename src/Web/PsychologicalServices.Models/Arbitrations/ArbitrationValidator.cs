using System;
using System.Collections.Generic;
using System.Linq;
using PsychologicalServices.Models.Common.Validation;
using PsychologicalServices.Models.Contacts;
using PsychologicalServices.Models.Assessments;
using PsychologicalServices.Models.Claims;

namespace PsychologicalServices.Models.Arbitrations
{
    public class ArbitrationValidator : IArbitrationValidator
    {
        private readonly IClaimRepository _claimRepository = null;
        private readonly IContactRepository _contactRepository = null;

        public ArbitrationValidator(
            IClaimRepository claimRepository,
            IContactRepository contactRepository
        )
        {
            _claimRepository = claimRepository;
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

            if (null == item.Claimant)
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "ClaimantId", Message = GetValidationMessage(item, "Claimant is required") }
                );
            }
            else
            {
                var claimant = _claimRepository.GetClaimant(item.Claimant.ClaimantId);

                if (null == claimant)
                {
                    result.ValidationErrors.Add(
                        new ValidationError { PropertyName = "ClaimantId", Message = GetValidationMessage(item, "Invalid Claimant") }
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
