using System;
using System.Collections.Generic;
using log4net;
using PsychologicalServices.Models.Common;

namespace PsychologicalServices.Models.RawTestData
{
    public class RawTestDataService : IRawTestDataService
    {
        private readonly IRawTestDataValidator _rawTestDataValidator = null;
        private readonly IRawTestDataRepository _rawTestDataRepository = null;
        private readonly ILog _log = null;

        public RawTestDataService(
            IRawTestDataValidator rawTestDataValidator,
            IRawTestDataRepository rawTestDataRepository,
            ILog log
        )
        {
            _rawTestDataValidator = rawTestDataValidator;
            _rawTestDataRepository = rawTestDataRepository;
            _log = log;
        }

        public RawTestData GetRawTestData(int rawTestDataId)
        {
            var rawTestData = _rawTestDataRepository.GetRawTestData(rawTestDataId);

            return rawTestData;
        }

        public IEnumerable<RawTestData> GetRawTestDatas(RawTestDataSearchCriteria criteria)
        {
            var rawTestDatas = _rawTestDataRepository.GetRawTestDatas(criteria);

            return rawTestDatas;
        }

        public IEnumerable<RawTestDataStatus> GetRawTestDataStatuses(bool? isActive = true)
        {
            var rawTestDataStatuses = _rawTestDataRepository.GetRawTestDataStatuses(isActive);

            return rawTestDataStatuses;
        }

        public SaveResult<RawTestData> SaveRawTestData(RawTestData rawTestData)
        {
            var result = new SaveResult<RawTestData>();

            try
            {
                var validation = _rawTestDataValidator.Validate(rawTestData);

                result.ValidationResult = validation;

                if (result.ValidationResult.IsValid)
                {
                    var id = _rawTestDataRepository.SaveRawTestData(rawTestData);

                    result.Item = _rawTestDataRepository.GetRawTestData(id);
                    result.IsSaved = true;
                }
            }
            catch (Exception ex)
            {
                _log.Error("SaveRawTestData", ex);
                result.IsError = true;
                result.ErrorDetails = ex.Message;
            }

            return result;
        }
    }
}
