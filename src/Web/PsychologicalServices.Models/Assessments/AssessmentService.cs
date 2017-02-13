using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Assessments
{
    public class AssessmentService : IAssessmentService
    {
        private readonly IAssessmentRepository _assessmentRepository = null;
        private readonly IAssessmentValidator _assessmentValidator = null;

        public AssessmentService(
            IAssessmentRepository assessmentRepository,
            IAssessmentValidator  assessmentValidator
        )
        {
            _assessmentRepository = assessmentRepository;
            _assessmentValidator = assessmentValidator;
        }

        public Assessment GetAssessment(int id)
        {
            try
            {
                var assessment = _assessmentRepository.GetAssessment(id);

                if (null == assessment)
                {
                    throw new AssessmentNotFoundException(id);
                }

                return assessment;
            }
            catch (Exception ex)
            {

            }

            return null;
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

        public IEnumerable<Assessment> SearchAssessments(AssessmentSearchCriteria criteria)
        {
            var assessments = _assessmentRepository.GetAssessments(criteria);

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
                //TODO: log error
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
                //TODO: log error
                result.IsError = true;
                result.ErrorDetails = ex.Message;
            }

            return result;
        }
    }
}
