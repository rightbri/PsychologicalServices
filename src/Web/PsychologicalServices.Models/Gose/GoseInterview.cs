using System;

namespace PsychologicalServices.Models.Gose
{
    public class GoseInterview
    {
		public int Id { get; set; }

		public int AssessmentId { get; set; }

		public int? AccidentTimeframeId { get; set; }

		public int? RespondentTypeId { get; set; }

		public bool? ConciousnessAbleToObeyCommandsOrSpeak { get; set; }

		public bool? IndependenceAtHomeRequireEveryDayAssistance { get; set; }

		public bool? IndependenceAtHomeNeedFrequentHelp { get; set; }

		public bool? IndependenceAtHomeIndependentBeforeInjury { get; set; }

		public bool? IndependenceOutsideHomeAbleToShopWithoutAssistance { get; set; }

		public bool? IndependenceOutsideHomeAbleToShopWithoutAssistanceBeforeInjury { get; set; }

		public bool? IndependenceOutsideHomeAbleToTravelLocallyWithoutAssistance { get; set; }

		public bool? IndependenceOutsideHomeAbleToTravelLocallyWithoutAssistanceBeforeInjury { get; set; }

		public bool? WorkAbleToWorkAtPreviousCapacity { get; set; }

		public int? WorkRestrictionLevelId { get; set; }

		public bool? WorkRestrictionLevelDifferentAfterInjury { get; set; }

		public bool? SocialAndLeisureAbleToResumeRegularActivities { get; set; }

		public int? SocialAndLeisureExtentOfRestrictionId { get; set; }

		public bool? SocialAndLeisureExtentOfRestrictionDifferentAfterInjury { get; set; }

		public bool? FamilyAndFriendshipsDisruptionDueToPsychologicalProblems { get; set; }

		public int? FamilyAndFriendshipsDisruptionLevelId { get; set; }

		public bool? FamilyAndFriendshipsDisruptionLevelDifferentAfterInjury { get; set; }

		public bool? ReturnToNormalLifeAnyOtherCurrentProblems { get; set; }

		public bool? ReturnToNormalLifeSimilarProblemsHaveBecomeWorse { get; set; }

		public int? ReturnToNormalLifeMostImportantFactorInOutcomeId { get; set; }

		public DateTimeOffset CreatedDate { get; set; }

		public int CreateUserId { get; set; }

		public DateTimeOffset UpdateDate { get; set; }

		public int UpdateUserId { get; set; }
	}
}
