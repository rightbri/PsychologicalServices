using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Assessments
{
    public interface IAssessmentRepository
    {
        Assessment GetAssessment(int id);

        Assessment GetNewAssessment(int companyId, DateTime appointmentTime);

        AssessmentType GetAssessmentType(int id);

        AssessmentTestingResults GetAssessmentTestingResults(int assessmentId, string name);

        IEnumerable<AssessmentSearchResult> SearchAssessments(AssessmentSearchCriteria criteria);

        IEnumerable<AssessmentType> GetAssessmentTypes(bool? isActive = true);

        int SaveAssessment(Assessment assessment);

        bool SaveAssessmentTestingResults(AssessmentTestingResults testingResults);

        int SaveAssessmentType(AssessmentType assessmentType);

        int DeleteAssessment(int id);
    }
}
