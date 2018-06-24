using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.RawTestData
{
    public interface IRawTestDataService
    {
        RawTestData GetRawTestData(int rawTestDataId);

        IEnumerable<RawTestDataStatus> GetRawTestDataStatuses(bool? isActive = true);

        IEnumerable<RawTestData> GetRawTestDatas(RawTestDataSearchCriteria criteria);

        SaveResult<RawTestData> SaveRawTestData(RawTestData rawTestData);
    }
}
