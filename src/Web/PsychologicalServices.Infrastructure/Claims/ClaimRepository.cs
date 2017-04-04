﻿using PsychologicalServices.Data.EntityClasses;
using PsychologicalServices.Data.Linq;
using PsychologicalServices.Infrastructure.Common.Repository;
using PsychologicalServices.Models.Claims;
using PsychologicalServices.Models.Common;
using SD.LLBLGen.Pro.LinqSupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Infrastructure.Claims
{
    public class ClaimRepository : RepositoryBase, IClaimRepository
    {
        public ClaimRepository(
            IDataAccessAdapterFactory adapterFactory
        ) : base(adapterFactory)
        {
        }

        public Claim GetClaim(int id)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return meta.Claim
                    .Where(claim => claim.ClaimId == id)
                    .SingleOrDefault()
                    .ToClaim();
            }
        }

        public Claimant GetClaimant(int id)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return meta.Claimant
                    .Where(claimant => claimant.ClaimantId == id)
                    .SingleOrDefault()
                    .ToClaimant();
            }
        }

        public IssueInDispute GetIssueInDispute(int id)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return meta.IssueInDispute
                    .Where(issueInDispute => issueInDispute.IssueInDisputeId == id)
                    .SingleOrDefault()
                    .ToIssueInDispute();
            }
        }

        public IEnumerable<Claim> GetAssessmentClaims(int assessmentId)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var assessmentEntity = meta.Assessment
                    .Where(assessment => assessment.AssessmentId == assessmentId)
                    .SingleOrDefault();

                return null != assessmentEntity
                    ? Execute<ClaimEntity>(
                            (ILLBLGenProQuery)
                            assessmentEntity.AssessmentClaims
                                .Select(assessmentClaim => assessmentClaim.Claim)
                        )
                        .Select(claim => claim.ToClaim())
                        .ToList()
                    : Enumerable.Empty<Claim>();
            }
        }

        public IEnumerable<Claimant> SearchClaimants(string lastName)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return Execute<ClaimantEntity>(
                    (ILLBLGenProQuery)
                    meta.Claimant
                    .Where(claimant => claimant.LastName.Contains(lastName))
                    .Take(20)
                )
                .Select(claimant => claimant.ToClaimant())
                .ToList();
            }
        }

        public IEnumerable<IssueInDispute> GetReferralTypeIssuesInDispute(int referralTypeId)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return Execute<IssueInDisputeEntity>(
                        (ILLBLGenProQuery)
                        meta.ReferralTypeIssueInDispute
                        .Where(referralTypeIssueInDispute => 
                            referralTypeIssueInDispute.ReferralTypeId == referralTypeId && 
                            referralTypeIssueInDispute.IssueInDispute.IsActive
                        )
                        .Select(referralTypeIssueInDispute => referralTypeIssueInDispute.IssueInDispute)
                    )
                    .Select(issueInDispute => issueInDispute.ToIssueInDispute())
                    .ToList();
            }
        }

        public IEnumerable<IssueInDispute> GetIssuesInDispute(bool? isActive = true)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return Execute<IssueInDisputeEntity>(
                        (ILLBLGenProQuery)
                        meta.IssueInDispute
                        .Where(issueInDispute => isActive == null || issueInDispute.IsActive == isActive.Value)
                    )
                    .Select(issueInDispute => issueInDispute.ToIssueInDispute())
                    .ToList();
            }
        }

        public IEnumerable<Gender> GetGenders()
        {
            //TODO: fetch from database
            return new Dictionary<string, string>
            {
                { "M", "Male" },
                { "F", "Female" },
                { "U", "Unknown" },
            }.Select(keyValuePair =>
                new Gender
                {
                    Abbreviation = keyValuePair.Key,
                    Description = keyValuePair.Value
                }
            );
        }

        public int SaveClaim(Claim claim)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var isNew = claim.IsNew();

                var entity = new ClaimEntity
                {
                    IsNew = isNew,
                    ClaimId = claim.ClaimId,
                };

                if (!isNew)
                {
                    adapter.FetchEntity(entity);
                }

                entity.ClaimantId = claim.Claimant.ClaimantId;
                entity.ClaimNumber = claim.ClaimNumber;
                entity.DateOfLoss = claim.DateOfLoss;
                entity.Deleted = claim.Deleted;
                
                adapter.SaveEntity(entity, false);

                return entity.ClaimId;
            }
        }

        public int SaveClaimant(Claimant claimant)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var isNew = claimant.IsNew();

                var entity = new ClaimantEntity
                {
                    IsNew = isNew,
                    ClaimantId = claimant.ClaimantId,
                };

                if (!isNew)
                {
                    adapter.FetchEntity(entity);
                }

                entity.FirstName = claimant.FirstName;
                entity.LastName = claimant.LastName;
                entity.Age = claimant.Age;
                entity.DateOfBirth = claimant.DateOfBirth;
                entity.Gender = claimant.Gender;
                entity.IsActive = claimant.IsActive;

                adapter.SaveEntity(entity, false);

                return entity.ClaimantId;
            }
        }

        public int SaveIssueInDispute(IssueInDispute issueInDispute)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var isNew = issueInDispute.IsNew();

                var entity = new IssueInDisputeEntity
                {
                    IsNew = isNew,
                    IssueInDisputeId = issueInDispute.IssueInDisputeId,
                };

                if (!isNew)
                {
                    adapter.FetchEntity(entity);
                }

                entity.Name = issueInDispute.Name;
                entity.IsActive = issueInDispute.IsActive;
                entity.AdditionalFee = issueInDispute.AdditionalFee;

                adapter.SaveEntity(entity, false);

                return entity.IssueInDisputeId;
            }
        }

    }
}
