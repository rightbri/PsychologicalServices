using PsychologicalServices.Models.Assessments;
using PsychologicalServices.Models.Users;
using System;

namespace PsychologicalServices.Models.Gose
{
    public class GoseInterview
    {
		public int GoseInterviewId { get; set; }

		public Assessment Assessment { get; set; }

		public GoseAccidentTimeframe AccidentTimeframe { get; set; }

		public GoseRespondentType RespondentType { get; set; }

		public bool? ConciousnessAbleToObeyCommandsOrSpeak { get; set; }

		public bool? IndependenceAtHomeRequireEveryDayAssistance { get; set; }

		public bool? IndependenceAtHomeNeedFrequentHelp { get; set; }

		public bool? IndependenceAtHomeIndependentBeforeInjury { get; set; }

		public bool? IndependenceOutsideHomeAbleToShopWithoutAssistance { get; set; }

		public bool? IndependenceOutsideHomeAbleToShopWithoutAssistanceBeforeInjury { get; set; }

		public bool? IndependenceOutsideHomeAbleToTravelLocallyWithoutAssistance { get; set; }

		public bool? IndependenceOutsideHomeAbleToTravelLocallyWithoutAssistanceBeforeInjury { get; set; }

		public bool? WorkAbleToWorkAtPreviousCapacity { get; set; }

		public GoseWorkRestrictionLevel WorkRestrictionLevel { get; set; }

		public bool? WorkRestrictionLevelDifferentAfterInjury { get; set; }

		public bool? SocialAndLeisureAbleToResumeRegularActivities { get; set; }

		public GoseSocialAndLeisureRestrictionExtent SocialAndLeisureExtentOfRestriction { get; set; }

		public bool? SocialAndLeisureExtentOfRestrictionDifferentAfterInjury { get; set; }

		public bool? FamilyAndFriendshipsDisruptionDueToPsychologicalProblems { get; set; }

		public GoseFamilyAndFriendshipsDisruptionLevel FamilyAndFriendshipsDisruptionLevel { get; set; }

		public bool? FamilyAndFriendshipsDisruptionLevelDifferentAfterInjury { get; set; }

		public bool? ReturnToNormalLifeAnyOtherCurrentProblems { get; set; }

		public bool? ReturnToNormalLifeSimilarProblemsHaveBecomeWorse { get; set; }

		public GoseReturnToNormalLifeOutcomeFactor ReturnToNormalLifeMostImportantFactorInOutcome { get; set; }

		public DateTimeOffset CreatedDate { get; set; }

		public User CreateUser { get; set; }

		public DateTimeOffset UpdateDate { get; set; }

		public User UpdateUser { get; set; }

		public bool IsNew()
		{
			return GoseInterviewId == 0;
		}
	}
}
