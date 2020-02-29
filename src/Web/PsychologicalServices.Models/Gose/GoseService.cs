using log4net;
using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Gose
{
    public class GoseService : IGoseService
    {
        private readonly IGoseRepository _goseRepository = null;
        private readonly IGoseInterviewValidator _interviewValidator = null;
        private readonly ILog _log = null;

        public GoseService(
            IGoseRepository goseRepository,
            IGoseInterviewValidator interviewValidator,
            ILog log
        )
        {
            _goseRepository = goseRepository;
            _interviewValidator = interviewValidator;
            _log = log;
        }

        public IEnumerable<GoseAccidentTimeframe> GetAccidentTimeframes()
        {
            return _goseRepository.GetAccidentTimeframes();
        }

        public IEnumerable<GoseFamilyAndFriendshipsDisruptionLevel> GetFamilyAndFriendshipDisruptionLevels()
        {
            return _goseRepository.GetFamilyAndFriendshipDisruptionLevels();
        }

        public GoseInterview GetInterview(int id)
        {
            return _goseRepository.GetInterview(id);
        }

        public IEnumerable<GoseRespondentType> GetRespondentTypes()
        {
            return _goseRepository.GetRespondentTypes();
        }

        public IEnumerable<GoseReturnToNormalLifeOutcomeFactor> GetReturnToNormalLifeOutcomeFactors()
        {
            return _goseRepository.GetReturnToNormalLifeOutcomeFactors();
        }

        public IEnumerable<GoseSocialAndLeisureRestrictionExtent> GetSocialAndLeisureRestrictionExtents()
        {
            return _goseRepository.GetSocialAndLeisureRestrictionExtents();
        }

        public IEnumerable<GoseWorkRestrictionLevel> GetWorkRestrictionLevels()
        {
            return _goseRepository.GetWorkRestrictionLevels();
        }

        public SaveResult<GoseInterview> SaveInterview(GoseInterview interview)
        {
            var result = new SaveResult<GoseInterview>();

            try
            {
                var validation = _interviewValidator.Validate(interview);

                result.ValidationResult = validation;

                if (result.ValidationResult.IsValid)
                {
                    var id = _goseRepository.SaveInterview(interview);

                    result.Item = _goseRepository.GetInterview(id);
                    result.IsSaved = true;
                }
            }
            catch (Exception ex)
            {
                _log.Error("SaveInterview", ex);
                result.IsError = true;
                result.ErrorDetails = ex.Message;
            }

            return result;
        }

        public DeleteResult DeleteInterview(int id)
        {
            var result = new DeleteResult();

            try
            {
                result.IsDeleted = _goseRepository.DeleteInterview(id);
            }
            catch (Exception ex)
            {
                _log.Error("DeleteInterview", ex);
                result.IsError = true;
                result.ErrorDetails = ex.Message;
            }

            return result;
        }
    }
}
