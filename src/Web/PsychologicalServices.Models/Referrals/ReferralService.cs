using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Referrals
{
    public class ReferralService : IReferralService
    {
        private readonly IReferralRepository _referralRepository = null;
        private readonly IReferralSourceTypeValidator _referralSourceTypeValidator = null;
        private readonly IReferralSourceValidator _referralSourceValidator = null;
        private readonly IReferralTypeValidator _referralTypeValidator = null;

        public ReferralService(
            IReferralRepository referralRepository,
            IReferralSourceTypeValidator referralSourceTypeValidator,
            IReferralSourceValidator referralSourceValidator,
            IReferralTypeValidator referralTypeValidator
        )
        {
            _referralRepository = referralRepository;
            _referralSourceTypeValidator = referralSourceTypeValidator;
            _referralSourceValidator = referralSourceValidator;
            _referralTypeValidator = referralTypeValidator;
        }

        public ReferralSource GetReferralSource(int id)
        {
            var referralSource = _referralRepository.GetReferralSource(id);

            return referralSource;
        }

        public ReferralSourceType GetReferralSourceType(int id)
        {
            var referralSourceType = _referralRepository.GetReferralSourceType(id);

            return referralSourceType;
        }

        public ReferralType GetReferralType(int id)
        {
            var referralType = _referralRepository.GetReferralType(id);

            return referralType;
        }

        public IEnumerable<ReferralSource> GetReferralSources(ReferralSourceSearchCriteria criteria)
        {
            var referralSources = _referralRepository.GetReferralSources(criteria);

            return referralSources;
        }

        public IEnumerable<ReferralSourceType> GetReferralSourceTypes(bool? isActive = true)
        {
            var referralSourceTypes = _referralRepository.GetReferralSourceTypes(isActive);

            return referralSourceTypes;
        }

        public IEnumerable<ReferralType> GetReferralTypes(bool? isActive = true)
        {
            var referralTypes = _referralRepository.GetReferralTypes(isActive);

            return referralTypes;
        }

        public SaveResult<ReferralSource> SaveReferralSource(ReferralSource referralSource)
        {
            var result = new SaveResult<ReferralSource>();

            try
            {
                var validation = _referralSourceValidator.Validate(referralSource);

                result.ValidationResult = validation;

                if (result.ValidationResult.IsValid)
                {
                    var id = _referralRepository.SaveReferralSource(referralSource);

                    result.Item = _referralRepository.GetReferralSource(id);
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

        public SaveResult<ReferralSourceType> SaveReferralSourceType(ReferralSourceType referralSourceType)
        {
            var result = new SaveResult<ReferralSourceType>();

            try
            {
                var validation = _referralSourceTypeValidator.Validate(referralSourceType);

                result.ValidationResult = validation;

                if (result.ValidationResult.IsValid)
                {
                    var id = _referralRepository.SaveReferralSourceType(referralSourceType);

                    result.Item = _referralRepository.GetReferralSourceType(id);
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

        public SaveResult<ReferralType> SaveReferralType(ReferralType referralType)
        {
            var result = new SaveResult<ReferralType>();

            try
            {
                var validation = _referralTypeValidator.Validate(referralType);

                result.ValidationResult = validation;

                if (result.ValidationResult.IsValid)
                {
                    var id = _referralRepository.SaveReferralType(referralType);

                    result.Item = _referralRepository.GetReferralType(id);
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
