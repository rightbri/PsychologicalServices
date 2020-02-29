using PsychologicalServices.Data;
using PsychologicalServices.Data.EntityClasses;
using PsychologicalServices.Data.Linq;
using PsychologicalServices.Infrastructure.Common.Repository;
using PsychologicalServices.Models.Assessments;
using PsychologicalServices.Models.Common.Utility;
using PsychologicalServices.Models.Gose;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Infrastructure.Gose
{
    public class GoseRepository : RepositoryBase, IGoseRepository
    {
        private readonly IDate _date = null;

        public GoseRepository(
            IDataAccessAdapterFactory adapterFactory,
            IDate date
        ) : base(adapterFactory)
        {
            _date = date;
        }

        #region Prefetch Paths
        
        private static readonly Func<IPathEdgeRootParser<GoseInterviewEntity>, IPathEdgeRootParser<GoseInterviewEntity>>
            GoseInterviewPath =
                (interviewPath => interviewPath
                    .Prefetch<AssessmentEntity>(interview => interview.Assessment)
                        .SubPath(assessmentPath => assessmentPath
                            .Prefetch<ClaimantEntity>(assessment => assessment.Claimant)
                            .Prefetch<AppointmentEntity>(assessment => assessment.Appointments)
                        )
                    .Prefetch<GoseAccidentTimeframeEntity>(interview => interview.GoseAccidentTimeframe)
                    .Prefetch<GoseFamilyAndFriendshipsDisruptionLevelEntity>(interview => interview.GoseFamilyAndFriendshipsDisruptionLevel)
                    .Prefetch<GoseRespondentTypeEntity>(interview => interview.GoseRespondentType)
                    .Prefetch<GoseReturnToNormalLifeOutcomeFactorEntity>(interview => interview.GoseReturnToNormalLifeOutcomeFactor)
                    .Prefetch<GoseSocialAndLeisureRestrictionExtentEntity>(interview => interview.GoseSocialAndLeisureRestrictionExtent)
                    .Prefetch<GoseWorkRestrictionLevelEntity>(interview => interview.GoseWorkRestrictionLevel)
                    .Prefetch<UserEntity>(interview => interview.CreateUser)
                    .Prefetch<UserEntity>(interview => interview.UpdateUser)
                );

        private static readonly Func<IPathEdgeRootParser<AssessmentEntity>, IPathEdgeRootParser<AssessmentEntity>>
            AssessmentPath =
                (assessmentPath => assessmentPath
                    .Prefetch<ClaimantEntity>(assessment => assessment.Claimant)
                    .Prefetch<AppointmentEntity>(assessment => assessment.Appointments)
                );

        #endregion

        public List<TModel> GetListWithMeta<TEntity, TModel>(
            Func<LinqMetaData, DataSource2<TEntity>> entityFunc,
            Func<TEntity, TModel> modelFunc
        ) where TEntity : CommonEntityBase
        {
            return GetWithMeta(meta =>
                Execute<TEntity>(
                    (ILLBLGenProQuery)
                    entityFunc(meta)
                )
                .Select(entity => modelFunc(entity))
                .ToList()
            );
        }

        public T GetWithMeta<T>(Func<LinqMetaData, T> func)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return func(meta);
            }
        }

        public IEnumerable<GoseAccidentTimeframe> GetAccidentTimeframes()
        {
            return GetListWithMeta(meta => meta.GoseAccidentTimeframe, entity => entity.ToModel());
        }

        public IEnumerable<GoseFamilyAndFriendshipsDisruptionLevel> GetFamilyAndFriendshipDisruptionLevels()
        {
            return GetListWithMeta(meta => meta.GoseFamilyAndFriendshipsDisruptionLevel, entity => entity.ToModel());
        }

        public GoseInterview GetInterview(int assessmentId)
        {
            var interview = GetWithMeta(meta =>
                meta.GoseInterview
                    .WithPath(GoseInterviewPath)
                    .Where(entity => entity.AssessmentId == assessmentId)
                    .FirstOrDefault()
                    .ToModel()
                );

            if (interview == null)
            {
                var assessment = GetWithMeta(meta =>
                    meta.Assessment
                        .WithPath(AssessmentPath)
                        .Where(entity => entity.AssessmentId == assessmentId)
                        .SingleOrDefault()
                        .ToAssessment()
                    );

                interview = new GoseInterview
                {
                    Assessment = assessment,
                };
            }

            return interview;
        }

        public IEnumerable<GoseRespondentType> GetRespondentTypes()
        {
            return GetListWithMeta(meta => meta.GoseRespondentType, entity => entity.ToModel());
        }

        public IEnumerable<GoseReturnToNormalLifeOutcomeFactor> GetReturnToNormalLifeOutcomeFactors()
        {
            return GetListWithMeta(meta => meta.GoseReturnToNormalLifeOutcomeFactor, entity => entity.ToModel());
        }

        public IEnumerable<GoseSocialAndLeisureRestrictionExtent> GetSocialAndLeisureRestrictionExtents()
        {
            return GetListWithMeta(meta => meta.GoseSocialAndLeisureRestrictionExtent, entity => entity.ToModel());
        }

        public IEnumerable<GoseWorkRestrictionLevel> GetWorkRestrictionLevels()
        {
            return GetListWithMeta(meta => meta.GoseWorkRestrictionLevel, entity => entity.ToModel());
        }

        public int SaveInterview(GoseInterview interview)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var uow = new UnitOfWork2();

                var isNew = interview.IsNew();

                var entity = new GoseInterviewEntity
                {
                    IsNew = isNew,
                    GoseInterviewId = interview.GoseInterviewId
                };

                if (!isNew)
                {
                    adapter.FetchEntity(entity);
                }
                else
                {
                    entity.CreatedDate = _date.UtcNow;
                    entity.CreateUserId = interview.CreateUser.UserId;
                }

                entity.UpdateDate = _date.UtcNow;
                entity.UpdateUserId = interview.UpdateUser.UserId;

                if (null == interview.AccidentTimeframe)
                {
                    entity.SetNewFieldValue((int)GoseInterviewFieldIndex.AccidentTimeframeId, null);
                }
                else
                {
                    entity.AccidentTimeframeId = interview.AccidentTimeframe.GoseAccidentTimeframeId;
                }

                if (null == interview.Assessment)
                {
                    entity.SetNewFieldValue((int)GoseInterviewFieldIndex.AssessmentId, null);
                }
                else
                {
                    entity.AssessmentId = interview.Assessment.AssessmentId;
                }

                if (null == interview.ConciousnessAbleToObeyCommandsOrSpeak)
                {
                    entity.SetNewFieldValue((int)GoseInterviewFieldIndex.ConciousnessAbleToObeyCommandsOrSpeak, null);
                }
                else
                {
                    entity.ConciousnessAbleToObeyCommandsOrSpeak = interview.ConciousnessAbleToObeyCommandsOrSpeak;
                }

                if (null == interview.FamilyAndFriendshipsDisruptionDueToPsychologicalProblems)
                {
                    entity.SetNewFieldValue((int)GoseInterviewFieldIndex.FamilyAndFriendshipsDisruptionDueToPsychologicalProblems, null);
                }
                else
                {
                    entity.FamilyAndFriendshipsDisruptionDueToPsychologicalProblems = interview.FamilyAndFriendshipsDisruptionDueToPsychologicalProblems;
                }

                if (null == interview.FamilyAndFriendshipsDisruptionLevel)
                {
                    entity.SetNewFieldValue((int)GoseInterviewFieldIndex.FamilyAndFriendshipsDisruptionLevelId, null);
                }
                else
                {
                    entity.FamilyAndFriendshipsDisruptionLevelId = interview.FamilyAndFriendshipsDisruptionLevel.GoseFamilyAndFriendshipDisruptionLevelId;
                }

                if (null == interview.FamilyAndFriendshipsDisruptionLevelDifferentAfterInjury)
                {
                    entity.SetNewFieldValue((int)GoseInterviewFieldIndex.FamilyAndFriendshipsDisruptionLevelDifferentAfterInjury, null);
                }
                else
                {
                    entity.FamilyAndFriendshipsDisruptionLevelDifferentAfterInjury = interview.FamilyAndFriendshipsDisruptionLevelDifferentAfterInjury;
                }

                if (null == interview.IndependenceAtHomeIndependentBeforeInjury)
                {
                    entity.SetNewFieldValue((int)GoseInterviewFieldIndex.IndependenceAtHomeIndependentBeforeInjury, null);
                }
                else
                {
                    entity.IndependenceAtHomeIndependentBeforeInjury = interview.IndependenceAtHomeIndependentBeforeInjury;
                }

                if (null == interview.IndependenceAtHomeNeedFrequentHelp)
                {
                    entity.SetNewFieldValue((int)GoseInterviewFieldIndex.IndependenceAtHomeNeedFrequentHelp, null);
                }
                else
                {
                    entity.IndependenceAtHomeNeedFrequentHelp = interview.IndependenceAtHomeNeedFrequentHelp;
                }

                if (null == interview.IndependenceAtHomeRequireEveryDayAssistance)
                {
                    entity.SetNewFieldValue((int)GoseInterviewFieldIndex.IndependenceAtHomeRequireEveryDayAssistance, null);
                }
                else
                {
                    entity.IndependenceAtHomeRequireEveryDayAssistance = interview.IndependenceAtHomeRequireEveryDayAssistance;
                }

                if (null == interview.IndependenceOutsideHomeAbleToShopWithoutAssistance)
                {
                    entity.SetNewFieldValue((int)GoseInterviewFieldIndex.IndependenceOutsideHomeAbleToShopWithoutAssistance, null);
                }
                else
                {
                    entity.IndependenceOutsideHomeAbleToShopWithoutAssistance = interview.IndependenceOutsideHomeAbleToShopWithoutAssistance;
                }

                if (null == interview.IndependenceOutsideHomeAbleToShopWithoutAssistanceBeforeInjury)
                {
                    entity.SetNewFieldValue((int)GoseInterviewFieldIndex.IndependenceOutsideHomeAbleToShopWithoutAssistanceBeforeInjury, null);
                }
                else
                {
                    entity.IndependenceOutsideHomeAbleToShopWithoutAssistanceBeforeInjury = interview.IndependenceOutsideHomeAbleToShopWithoutAssistanceBeforeInjury;
                }

                if (null == interview.IndependenceOutsideHomeAbleToTravelLocallyWithoutAssistance)
                {
                    entity.SetNewFieldValue((int)GoseInterviewFieldIndex.IndependenceOutsideHomeAbleToTravelLocallyWithoutAssistance, null);
                }
                else
                {
                    entity.IndependenceOutsideHomeAbleToTravelLocallyWithoutAssistance = interview.IndependenceOutsideHomeAbleToTravelLocallyWithoutAssistance;
                }

                if (null == interview.IndependenceOutsideHomeAbleToTravelLocallyWithoutAssistanceBeforeInjury)
                {
                    entity.SetNewFieldValue((int)GoseInterviewFieldIndex.IndependenceOutsideHomeAbleToTravelLocallyWithoutAssistanceBeforeInjury, null);
                }
                else
                {
                    entity.IndependenceOutsideHomeAbleToTravelLocallyWithoutAssistanceBeforeInjury = interview.IndependenceOutsideHomeAbleToTravelLocallyWithoutAssistanceBeforeInjury;
                }

                if (null == interview.RespondentType)
                {
                    entity.SetNewFieldValue((int)GoseInterviewFieldIndex.RespondentTypeId, null);
                }
                else
                {
                    entity.RespondentTypeId = interview.RespondentType.GoseRespondentTypeId;
                }

                if (null == interview.ReturnToNormalLifeAnyOtherCurrentProblems)
                {
                    entity.SetNewFieldValue((int)GoseInterviewFieldIndex.ReturnToNormalLifeAnyOtherCurrentProblems, null);
                }
                else
                {
                    entity.ReturnToNormalLifeAnyOtherCurrentProblems = interview.ReturnToNormalLifeAnyOtherCurrentProblems;
                }

                if (null == interview.ReturnToNormalLifeMostImportantFactorInOutcome)
                {
                    entity.SetNewFieldValue((int)GoseInterviewFieldIndex.ReturnToNormalLifeMostImportantFactorInOutcomeId, null);
                }
                else
                {
                    entity.ReturnToNormalLifeMostImportantFactorInOutcomeId = interview.ReturnToNormalLifeMostImportantFactorInOutcome.GoseReturnToNormalLifeOutcomeFactorId;
                }

                if (null == interview.ReturnToNormalLifeSimilarProblemsHaveBecomeWorse)
                {
                    entity.SetNewFieldValue((int)GoseInterviewFieldIndex.ReturnToNormalLifeSimilarProblemsHaveBecomeWorse, null);
                }
                else
                {
                    entity.ReturnToNormalLifeSimilarProblemsHaveBecomeWorse = interview.ReturnToNormalLifeSimilarProblemsHaveBecomeWorse;
                }

                if (null == interview.SocialAndLeisureAbleToResumeRegularActivities)
                {
                    entity.SetNewFieldValue((int)GoseInterviewFieldIndex.SocialAndLeisureAbleToResumeRegularActivities, null);
                }
                else
                {
                    entity.SocialAndLeisureAbleToResumeRegularActivities = interview.SocialAndLeisureAbleToResumeRegularActivities;
                }

                if (null == interview.SocialAndLeisureExtentOfRestriction)
                {
                    entity.SetNewFieldValue((int)GoseInterviewFieldIndex.SocialAndLeisureExtentOfRestrictionId, null);
                }
                else
                {
                    entity.SocialAndLeisureExtentOfRestrictionId = interview.SocialAndLeisureExtentOfRestriction.GoseSocialAndLeisureRestrictionExtentId;
                }

                if (null == interview.SocialAndLeisureExtentOfRestrictionDifferentAfterInjury)
                {
                    entity.SetNewFieldValue((int)GoseInterviewFieldIndex.SocialAndLeisureExtentOfRestrictionDifferentAfterInjury, null);
                }
                else
                {
                    entity.SocialAndLeisureExtentOfRestrictionDifferentAfterInjury = interview.SocialAndLeisureExtentOfRestrictionDifferentAfterInjury;
                }

                if (null == interview.WorkAbleToWorkAtPreviousCapacity)
                {
                    entity.SetNewFieldValue((int)GoseInterviewFieldIndex.WorkAbleToWorkAtPreviousCapacity, null);
                }
                else
                {
                    entity.WorkAbleToWorkAtPreviousCapacity = interview.WorkAbleToWorkAtPreviousCapacity;
                }

                if (null == interview.WorkRestrictionLevel)
                {
                    entity.SetNewFieldValue((int)GoseInterviewFieldIndex.WorkRestrictionLevelId, null);
                }
                else
                {
                    entity.WorkRestrictionLevelId = interview.WorkRestrictionLevel.GoseWorkRestrictionLevelId;
                }

                if (null == interview.WorkRestrictionLevelDifferentAfterInjury)
                {
                    entity.SetNewFieldValue((int)GoseInterviewFieldIndex.WorkRestrictionLevelDifferentAfterInjury, null);
                }
                else
                {
                    entity.WorkRestrictionLevelDifferentAfterInjury = interview.WorkRestrictionLevelDifferentAfterInjury;
                }

                uow.AddForSave(entity);

                uow.Commit(adapter);

                return entity.GoseInterviewId;
            }
        }

        public bool DeleteInterview(int id)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var success = adapter.DeleteEntity(
                    new GoseInterviewEntity(id)
                );

                return success;
            }
        }
    }
}
