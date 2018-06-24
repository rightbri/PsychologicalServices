using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.RawTestData
{
    public interface IRawTestDataRepository
    {
        RawTestData GetRawTestData(int rawTestDataId);

        IEnumerable<RawTestDataStatus> GetRawTestDataStatuses(bool? isActive = true);

        IEnumerable<RawTestData> GetRawTestDatas(RawTestDataSearchCriteria criteria);

        int SaveRawTestData(RawTestData rawTestData);
    }
}
