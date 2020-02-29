using PsychologicalServices.Data.EntityClasses;
using PsychologicalServices.Infrastructure.Common.Repository;
using PsychologicalServices.Models.Gose;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Infrastructure.Gose
{
    public static class GoseExtensions
    {
        public static GoseAccidentTimeframe ToModel(this GoseAccidentTimeframeEntity entity)
        {
            return entity != null
                ? new GoseAccidentTimeframe
                {
                    GoseAccidentTimeframeId = entity.GoseAccidentTimeframeId,
                    Description = entity.Description,
                    Months = entity.Months,
                    Basic = entity.Basic,
                    Intermediate = entity.Intermediate,
                    Advanced = entity.Advanced,
                }
                : null;
        }

        public static GoseFamilyAndFriendshipsDisruptionLevel ToModel(this GoseFamilyAndFriendshipsDisruptionLevelEntity entity)
        {
            return entity != null
                ? new GoseFamilyAndFriendshipsDisruptionLevel
                {
                    GoseFamilyAndFriendshipDisruptionLevelId = entity.GoseFamilyAndFriendshipsDisruptionLevelId,
                    Description = entity.Description,
                }
                : null;
        }

        public static GoseInterview ToModel(this GoseInterviewEntity entity)
        {
            return entity != null
                ? new GoseInterview
                {
                    GoseInterviewId = entity.GoseInterviewId,
                    Assessment = entity.Assessment.ToAssessment(),
                    AccidentTimeframe = entity.GoseAccidentTimeframe.ToModel(),
                    ConciousnessAbleToObeyCommandsOrSpeak = entity.ConciousnessAbleToObeyCommandsOrSpeak,
                    FamilyAndFriendshipsDisruptionDueToPsychologicalProblems = entity.FamilyAndFriendshipsDisruptionDueToPsychologicalProblems,
                    FamilyAndFriendshipsDisruptionLevelDifferentAfterInjury = entity.FamilyAndFriendshipsDisruptionLevelDifferentAfterInjury,
                    FamilyAndFriendshipsDisruptionLevel = entity.GoseFamilyAndFriendshipsDisruptionLevel.ToModel(),
                    IndependenceAtHomeIndependentBeforeInjury = entity.IndependenceAtHomeIndependentBeforeInjury,
                    IndependenceAtHomeNeedFrequentHelp = entity.IndependenceAtHomeNeedFrequentHelp,
                    IndependenceAtHomeRequireEveryDayAssistance = entity.IndependenceAtHomeRequireEveryDayAssistance,
                    IndependenceOutsideHomeAbleToShopWithoutAssistance = entity.IndependenceOutsideHomeAbleToShopWithoutAssistance,
                    IndependenceOutsideHomeAbleToShopWithoutAssistanceBeforeInjury = entity.IndependenceOutsideHomeAbleToShopWithoutAssistanceBeforeInjury,
                    IndependenceOutsideHomeAbleToTravelLocallyWithoutAssistance = entity.IndependenceOutsideHomeAbleToTravelLocallyWithoutAssistance,
                    IndependenceOutsideHomeAbleToTravelLocallyWithoutAssistanceBeforeInjury = entity.IndependenceOutsideHomeAbleToTravelLocallyWithoutAssistanceBeforeInjury,
                    RespondentType = entity.GoseRespondentType.ToModel(),
                    ReturnToNormalLifeAnyOtherCurrentProblems = entity.ReturnToNormalLifeAnyOtherCurrentProblems,
                    ReturnToNormalLifeMostImportantFactorInOutcome = entity.GoseReturnToNormalLifeOutcomeFactor.ToModel(),
                    ReturnToNormalLifeSimilarProblemsHaveBecomeWorse = entity.ReturnToNormalLifeSimilarProblemsHaveBecomeWorse,
                    SocialAndLeisureAbleToResumeRegularActivities = entity.SocialAndLeisureAbleToResumeRegularActivities,
                    SocialAndLeisureExtentOfRestrictionDifferentAfterInjury = entity.SocialAndLeisureExtentOfRestrictionDifferentAfterInjury,
                    SocialAndLeisureExtentOfRestriction = entity.GoseSocialAndLeisureRestrictionExtent.ToModel(),
                    WorkAbleToWorkAtPreviousCapacity = entity.WorkAbleToWorkAtPreviousCapacity,
                    WorkRestrictionLevelDifferentAfterInjury = entity.WorkRestrictionLevelDifferentAfterInjury,
                    WorkRestrictionLevel = entity.GoseWorkRestrictionLevel.ToModel(),
                    CreatedDate = entity.CreatedDate,
                    CreateUser = entity.CreateUser.ToUser(),
                    UpdateDate = entity.UpdateDate,
                    UpdateUser = entity.UpdateUser.ToUser(),
                }
                : null;
        }

        public static GoseRespondentType ToModel(this GoseRespondentTypeEntity entity)
        {
            return entity != null
                ? new GoseRespondentType
                {
                    GoseRespondentTypeId = entity.GoseRespondentTypeId,
                    Description = entity.Description,
                }
                : null;
        }

        public static GoseReturnToNormalLifeOutcomeFactor ToModel(this GoseReturnToNormalLifeOutcomeFactorEntity entity)
        {
            return entity != null
                ? new GoseReturnToNormalLifeOutcomeFactor
                {
                    GoseReturnToNormalLifeOutcomeFactorId = entity.GoseReturnToNormalLifeOutcomeFactorId,
                    Description = entity.Description,
                }
                : null;
        }

        public static GoseSocialAndLeisureRestrictionExtent ToModel(this GoseSocialAndLeisureRestrictionExtentEntity entity)
        {
            return entity != null
                ? new GoseSocialAndLeisureRestrictionExtent
                {
                    GoseSocialAndLeisureRestrictionExtentId = entity.GoseSocialAndLeisureRestrictionExtentId,
                    Description = entity.Description,
                }
                : null;
        }

        public static GoseWorkRestrictionLevel ToModel(this GoseWorkRestrictionLevelEntity entity)
        {
            return entity != null
                ? new GoseWorkRestrictionLevel
                {
                    GoseWorkRestrictionLevelId = entity.GoseWorkRestrictionLevelId,
                    Description = entity.Description,
                }
                : null;
        }
    }
}
