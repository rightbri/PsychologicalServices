using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Assessments
{
    public interface IAssessmentService
    {
        Assessment GetAssessment(int id);

        Assessment GetNewAssessment(int companyId, DateTime appointmentTime);

        AssessmentType GetAssessmentType(int id);

        AssessmentTestingResults GetAssessmentTestingResults(int assessmentId, string name);

        IEnumerable<AssessmentSearchResult> SearchAssessments(AssessmentSearchCriteria criteria);

        IEnumerable<AssessmentType> GetAssessmentTypes(bool? isActive = true);

        SaveResult<Assessment> SaveAssessment(Assessment assessment);

        SaveResult<AssessmentTestingResults> SaveAssessmentTestingResults(AssessmentTestingResults testingResults);

        SaveResult<AssessmentType> SaveAssessmentType(AssessmentType assessmentType);

        DeleteResult DeleteAssessment(int id);

        DeleteResult DeleteAssessmentTestingResults(int assessmentId, string name);
    }
}
