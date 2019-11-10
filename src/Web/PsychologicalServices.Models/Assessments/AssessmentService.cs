using log4net;
using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Assessments
{
    public class AssessmentService : IAssessmentService
    {
        private readonly IAssessmentRepository _assessmentRepository = null;
        private readonly IAssessmentValidator _assessmentValidator = null;
        private readonly ILog _log = null;

        public AssessmentService(
            IAssessmentRepository assessmentRepository,
            IAssessmentValidator  assessmentValidator,
            ILog log
        )
        {
            _assessmentRepository = assessmentRepository;
            _assessmentValidator = assessmentValidator;
            _log = log;
        }

        public Assessment GetAssessment(int id)
        {
            var assessment = _assessmentRepository.GetAssessment(id);

            return assessment;
        }

        public Assessment GetNewAssessment(int companyId, DateTime appointmentTime)
        {
            var newAssessment = _assessmentRepository.GetNewAssessment(companyId, appointmentTime);

            return newAssessment;
        }

        public AssessmentType GetAssessmentType(int id)
        {
            var assessmentType = _assessmentRepository.GetAssessmentType(id);

            if (null == assessmentType)
            {
                throw new AssessmentTypeNotFoundException(id);
            }

            return assessmentType;
        }

        public AssessmentTestingResults GetAssessmentTestingResults(int assessmentId, string name)
        {
            var testingResults = _assessmentRepository.GetAssessmentTestingResults(assessmentId, name);

            return testingResults;
        }

        public IEnumerable<AssessmentSearchResult> SearchAssessments(AssessmentSearchCriteria criteria)
        {
            var assessments = _assessmentRepository.SearchAssessments(criteria);

            return assessments;
        }

        public IEnumerable<AssessmentType> GetAssessmentTypes(bool? isActive = true)
        {
            var assessmentTypes = _assessmentRepository.GetAssessmentTypes(isActive);

            return assessmentTypes;
        }

        public SaveResult<Assessment> SaveAssessment(Assessment assessment)
        {
            var result = new SaveResult<Assessment>();

            try
            {
                var validation = _assessmentValidator.Validate(assessment);

                result.ValidationResult = validation;

                if (result.ValidationResult.IsValid)
                {
                    var id = _assessmentRepository.SaveAssessment(assessment);

                    result.Item = _assessmentRepository.GetAssessment(id);
                    result.IsSaved = true;
                }
            }
            catch (Exception ex)
            {
                _log.Error("SaveAssessment", ex);
                result.IsError = true;
                result.ErrorDetails = ex.Message;
            }

            return result;
        }

        public SaveResult<AssessmentTestingResults> SaveAssessmentTestingResults(AssessmentTestingResults testingResults)
        {
            var result = new SaveResult<AssessmentTestingResults>();

            try
            {
                var isSaved = _assessmentRepository.SaveAssessmentTestingResults(testingResults);

                result.Item = _assessmentRepository.GetAssessmentTestingResults(testingResults.Assessment.AssessmentId, testingResults.Name);
                result.IsSaved = isSaved;
            }
            catch (Exception ex)
            {
                _log.Error("SaveAssessmentTestingResults", ex);
                result.IsError = true;
                result.ErrorDetails = ex.Message;
            }

            return result;
        }

        public SaveResult<AssessmentType> SaveAssessmentType(AssessmentType assessmentType)
        {
            var result = new SaveResult<AssessmentType>();

            try
            {
                var id = _assessmentRepository.SaveAssessmentType(assessmentType);

                result.Item = _assessmentRepository.GetAssessmentType(id);
                result.IsSaved = true;
            }
            catch (Exception ex)
            {
                _log.Error("SaveAssessmentType", ex);
                result.IsError = true;
                result.ErrorDetails = ex.Message;
            }

            return result;
        }

        public DeleteResult DeleteAssessment(int id)
        {
            var result = new DeleteResult();

            try
            {
                var rowsAffected = _assessmentRepository.DeleteAssessment(id);

                result.IsDeleted = rowsAffected > 0;
            }
            catch (Exception ex)
            {
                _log.Error("DeleteAssessment", ex);
                result.IsError = true;
                result.ErrorDetails = ex.Message;
            }

            return result;
        }
    }
}
