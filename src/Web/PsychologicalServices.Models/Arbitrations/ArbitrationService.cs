using System;
using System.Collections.Generic;
using PsychologicalServices.Models.Assessments;
using PsychologicalServices.Models.Common;
using log4net;

namespace PsychologicalServices.Models.Arbitrations
{
    public class ArbitrationService : IArbitrationService
    {
        public readonly IArbitrationRepository _arbitrationRepository = null;
        public readonly IArbitrationValidator _arbitrationValidator = null;
        public readonly ILog _log = null;

        public ArbitrationService(
            IArbitrationRepository arbitrationRepository,
            IArbitrationValidator arbitrationValidator,
            ILog log
        )
        {
            _arbitrationRepository = arbitrationRepository;
            _arbitrationValidator = arbitrationValidator;
            _log = log;
        }

        public Arbitration GetArbitration(int arbitrationId)
        {
            var arbitration = _arbitrationRepository.GetArbitration(arbitrationId);

            return arbitration;
        }

        public Arbitration GetNewArbitration(int assessmentId)
        {
            
            return new Arbitration
            {
            };
        }

        public IEnumerable<Arbitration> GetArbitrations(ArbitrationSearchCriteria criteria)
        {
            var arbitrations = _arbitrationRepository.GetArbitrations(criteria);

            return arbitrations;
        }

        public SaveResult<Arbitration> SaveArbitration(Arbitration arbitration)
        {
            var result = new SaveResult<Arbitration>();

            try
            {
                var validation = _arbitrationValidator.Validate(arbitration);

                result.ValidationResult = validation;

                if (result.ValidationResult.IsValid)
                {
                    var id = _arbitrationRepository.SaveArbitration(arbitration);

                    result.Item = _arbitrationRepository.GetArbitration(id);
                    result.IsSaved = true;
                }
            }
            catch (Exception ex)
            {
                _log.Error("SaveArbitration", ex);
                result.IsError = true;
                result.ErrorDetails = ex.Message;
            }

            return result;
        }
    }
}
