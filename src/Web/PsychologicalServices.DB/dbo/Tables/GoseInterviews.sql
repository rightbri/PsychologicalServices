﻿CREATE TABLE [dbo].[GoseInterviews] (
    [Id]                                                                      INT                IDENTITY (1, 1) NOT NULL,
    [AssessmentId]                                                            INT                NOT NULL,
    [AccidentTimeframeId]                                                     INT                NULL,
    [RespondentTypeId]                                                        INT                NULL,
    [ConciousnessAbleToObeyCommandsOrSpeak]                                   BIT                NULL,
    [IndependenceAtHomeRequireEveryDayAssistance]                             BIT                NULL,
    [IndependenceAtHomeNeedFrequentHelp]                                      BIT                NULL,
    [IndependenceAtHomeIndependentBeforeInjury]                               BIT                NULL,
    [IndependenceOutsideHomeAbleToShopWithoutAssistance]                      BIT                NULL,
    [IndependenceOutsideHomeAbleToShopWithoutAssistanceBeforeInjury]          BIT                NULL,
    [IndependenceOutsideHomeAbleToTravelLocallyWithoutAssistance]             BIT                NULL,
    [IndependenceOutsideHomeAbleToTravelLocallyWithoutAssistanceBeforeInjury] BIT                NULL,
    [WorkAbleToWorkAtPreviousCapacity]                                        BIT                NULL,
    [WorkRestrictionLevelId]                                                  INT                NULL,
    [WorkRestrictionLevelDifferentAfterInjury]                                BIT                NULL,
    [SocialAndLeisureAbleToResumeRegularActivities]                           BIT                NULL,
    [SocialAndLeisureExtentOfRestrictionId]                                   INT                NULL,
    [SocialAndLeisureExtentOfRestrictionDifferentAfterInjury]                 BIT                NULL,
    [FamilyAndFriendshipsDisruptionDueToPsychologicalProblems]                BIT                NULL,
    [FamilyAndFriendshipsDisruptionLevelId]                                   INT                NULL,
    [FamilyAndFriendshipsDisruptionLevelDifferentAfterInjury]                 BIT                NULL,
    [ReturnToNormalLifeAnyOtherCurrentProblems]                               BIT                NULL,
    [ReturnToNormalLifeSimilarProblemsHaveBecomeWorse]                        BIT                NULL,
    [ReturnToNormalLifeMostImportantFactorInOutcomeId]                        INT                NULL,
    [CreatedDate]                                                             DATETIMEOFFSET (7) CONSTRAINT [DF_GoseInterviews_CreatedDate] DEFAULT (sysutcdatetime()) NOT NULL,
    [CreateUserId]                                                            INT                NOT NULL,
    [UpdateDate]                                                              DATETIMEOFFSET (7) CONSTRAINT [DF_GoseInterviews_UpdateDate] DEFAULT (sysutcdatetime()) NOT NULL,
    [UpdateUserId]                                                            INT                NOT NULL,
    CONSTRAINT [PK_GoseInterviews_1] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_GoseInterviews_Assessments] FOREIGN KEY ([AssessmentId]) REFERENCES [dbo].[Assessments] ([AssessmentId]),
    CONSTRAINT [FK_GoseInterviews_CreateUsers] FOREIGN KEY ([CreateUserId]) REFERENCES [dbo].[Users] ([UserId]),
    CONSTRAINT [FK_GoseInterviews_GoseAccidentTimeframes] FOREIGN KEY ([AccidentTimeframeId]) REFERENCES [dbo].[GoseAccidentTimeframes] ([GoseAccidentTimeframeId]),
    CONSTRAINT [FK_GoseInterviews_GoseFamilyAndFriendshipsDisruptionLevels] FOREIGN KEY ([FamilyAndFriendshipsDisruptionLevelId]) REFERENCES [dbo].[GoseFamilyAndFriendshipsDisruptionLevels] ([GoseFamilyAndFriendshipsDisruptionLevelId]),
    CONSTRAINT [FK_GoseInterviews_GoseRespondentTypes] FOREIGN KEY ([RespondentTypeId]) REFERENCES [dbo].[GoseRespondentTypes] ([GoseRespondentTypeId]),
    CONSTRAINT [FK_GoseInterviews_GoseReturnToNormalLifeOutcomeFactors] FOREIGN KEY ([ReturnToNormalLifeMostImportantFactorInOutcomeId]) REFERENCES [dbo].[GoseReturnToNormalLifeOutcomeFactors] ([GoseReturnToNormalLifeOutcomeFactorId]),
    CONSTRAINT [FK_GoseInterviews_GoseSocialAndLeisureRestrictionExtents] FOREIGN KEY ([SocialAndLeisureExtentOfRestrictionId]) REFERENCES [dbo].[GoseSocialAndLeisureRestrictionExtents] ([GoseSocialAndLeisureRestrictionExtentId]),
    CONSTRAINT [FK_GoseInterviews_GoseWorkRestrictionLevels] FOREIGN KEY ([WorkRestrictionLevelId]) REFERENCES [dbo].[GoseWorkRestrictionLevels] ([GoseWorkRestrictionLevelId]),
    CONSTRAINT [FK_GoseInterviews_UpdateUsers] FOREIGN KEY ([UpdateUserId]) REFERENCES [dbo].[Users] ([UserId])
);

