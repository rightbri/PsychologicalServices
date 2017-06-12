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

        IEnumerable<Assessment> SearchAssessments(AssessmentSearchCriteria criteria);

        IEnumerable<AssessmentType> GetAssessmentTypes(bool? isActive = true);

        SaveResult<Assessment> SaveAssessment(Assessment assessment);

        SaveResult<AssessmentType> SaveAssessmentType(AssessmentType assessmentType);
    }
}
