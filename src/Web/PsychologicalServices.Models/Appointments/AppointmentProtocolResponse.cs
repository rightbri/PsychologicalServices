using PsychologicalServices.Models.Users;
using System;

namespace PsychologicalServices.Models.Appointments
{
    public class AppointmentProtocolResponse
    {
        public int AppointmentId { get; set; }

        public int? OnTimeArrivalAndNotificationId { get; set; }

        public int? ClaimantArrivalNotificationId { get; set; }

        public int? CovidFormsCompletedBeforeEnteringRoomId { get; set; }

        public int? TestedClaimantsEnglishReadingLevelId { get; set; }

        public int? TommSimsScoreNotificationId { get; set; }

        public int? AskedWhichTestsShouldBeRemovedId { get; set; }

        public int? AdvisedOfUnexpectedDelaysId { get; set; }

        public int? AfterAssessmentNotificationId { get; set; }

        public int? AllPapersHaveClaimantInitialsAndDateId { get; set; }

        public int? ScoringDoubleCheckedId { get; set; }

        public int? RelevantObservationsDocumentedId { get; set; }

        public int? ErrorCheckedObservationsId { get; set; }

        public int? AllFormsCompletedId { get; set; }

        public int? TimeAssessmentLabelCompletedId { get; set; }

        public int? ScansUploadedNotificationId { get; set; }

        public int? UploadedScanLegibilityVerifiedId { get; set; }

        public int? SpareSetReplenishmentRequestSentId { get; set; }

        public int? RespondedToQuestionsWithinRequiredTimeframeId { get; set; }

        public int? StapledItemsTogetherId { get; set; }

        public int? WillPersonallyDropOffPackageId { get; set; }

        public string Comments { get; set; }

        public DateTimeOffset CreateDate { get; set; }

        public User CreateUser { get; set; }

        public DateTimeOffset UpdateDate { get; set; }

        public User UpdateUser { get; set; }

        public bool IsNew { get; set; }
    }
}
