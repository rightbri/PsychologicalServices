using PsychologicalServices.Data;
using PsychologicalServices.Data.EntityClasses;
using PsychologicalServices.Data.Linq;
using PsychologicalServices.Infrastructure.Common.Repository;
using PsychologicalServices.Models.Claims;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
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

        #region Prefetch Paths

        private static readonly Func<IPathEdgeRootParser<ClaimantEntity>, IPathEdgeRootParser<ClaimantEntity>>
            ClaimantWithClaimPath =
                (claimantPath => claimantPath
                    .Prefetch<ClaimEntity>(claimant => claimant.Claims)
                );

        #endregion

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
                    .WithPath(ClaimantWithClaimPath)
                    .Where(claimant => claimant.ClaimantId == id)
                    .SingleOrDefault()
                    .ToClaimantWithClaims();
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

        public IEnumerable<Claimant> SearchClaimants(string name)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return Execute<ClaimantEntity>(
                    (ILLBLGenProQuery)
                    meta.Claimant
                    .WithPath(ClaimantWithClaimPath)
                    .Where(claimant => claimant.LastName.Contains(name) || claimant.FirstName.Contains(name))
                    .Take(20)
                )
                .Select(claimant => claimant.ToClaimantWithClaims())
                .ToList();
            }
        }
        
        public IEnumerable<Claimant> SearchClaimants(ClaimantSearchParameters parameters)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var claimants = meta.Claimant.AsQueryable();

                if (null != parameters)
                {
                    if (!string.IsNullOrWhiteSpace(parameters.FirstName))
                    {
                        claimants = claimants.Where(claimant => claimant.FirstName.Contains(parameters.FirstName));
                    }

                    if (!string.IsNullOrWhiteSpace(parameters.LastName))
                    {
                        claimants = claimants.Where(claimant => claimant.LastName.Contains(parameters.LastName));
                    }

                    if (!string.IsNullOrWhiteSpace(parameters.Name))
                    {
                        claimants = claimants.Where(claimant => claimant.LastName.Contains(parameters.Name) || claimant.FirstName.Contains(parameters.Name));
                    }

                    if (parameters.DateOfBirth.HasValue)
                    {
                        claimants = claimants.Where(claimant => claimant.DateOfBirth == parameters.DateOfBirth);
                    }
                }

                return Execute<ClaimantEntity>(
                    (ILLBLGenProQuery)
                    claimants
                    .WithPath(ClaimantWithClaimPath)
                    .Take(20)
                )
                .Select(claimant => claimant.ToClaimantWithClaims())
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

        public int SaveClaimant(Claimant claimant)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var uow = new UnitOfWork2();

                var isNew = claimant.IsNew();

                var entity = new ClaimantEntity
                {
                    IsNew = isNew,
                    ClaimantId = claimant.ClaimantId,
                };

                if (!isNew)
                {
                    var prefetch = new PrefetchPath2(EntityType.ClaimantEntity);

                    prefetch.Add(ClaimantEntity.PrefetchPathClaims);

                    adapter.FetchEntity(entity, prefetch);
                }

                entity.FirstName = claimant.FirstName;
                entity.LastName = claimant.LastName;
                entity.DateOfBirth = claimant.DateOfBirth;
                entity.Gender = claimant.Gender;
                entity.IsActive = claimant.IsActive;

                var claimsToRemove = entity.Claims
                    .Where(claimantClaim => !claimant.Claims.Any(claim => claim.ClaimId == claimantClaim.ClaimId))
                    .ToList();

                var claimsToAdd = claimant.Claims
                    .Where(claim => !entity.Claims.Any(claimantClaim => claimantClaim.ClaimId == claim.ClaimId))
                    .ToList();

                var claimsToUpdate = claimant.Claims
                    .Where(claim => entity.Claims.Any(claimantClaim =>
                        claim.ClaimId == claimantClaim.ClaimId &&
                        (
                        claim.ClaimNumber != claimantClaim.ClaimNumber ||
                        claim.DateOfLoss != claimantClaim.DateOfLoss ||
                        claim.InsuranceCompany != claimantClaim.InsuranceCompany ||
                        claim.Lawyer != claimantClaim.Lawyer
                        )
                    ))
                    .ToList();

                foreach (var claim in claimsToRemove)
                {
                    uow.AddForDelete(claim);
                }

                foreach (var claim in claimsToUpdate)
                {
                    var claimEntity = entity.Claims
                        .Where(claimantClaim => claimantClaim.ClaimId == claim.ClaimId)
                        .SingleOrDefault();

                    if (null != claimEntity)
                    {
                        claimEntity.ClaimNumber = claim.ClaimNumber;
                        claimEntity.DateOfLoss = claim.DateOfLoss;
                        claimEntity.Lawyer = claim.Lawyer;
                        claimEntity.InsuranceCompany = claim.InsuranceCompany;
                    }
                }

                entity.Claims.AddRange(
                    claimsToAdd.Select(claim => new ClaimEntity
                    {
                        ClaimNumber = claim.ClaimNumber,
                        DateOfLoss = claim.DateOfLoss,
                        Lawyer = claim.Lawyer,
                        InsuranceCompany = claim.InsuranceCompany,
                    })
                );

                uow.AddForSave(entity);

                uow.Commit(adapter);

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

                adapter.SaveEntity(entity, false);

                return entity.IssueInDisputeId;
            }
        }

        public bool DeleteClaimant(int id)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var success = adapter.DeleteEntity(
                    new ClaimantEntity(id)
                );

                return success;
            }
        }
    }
}
