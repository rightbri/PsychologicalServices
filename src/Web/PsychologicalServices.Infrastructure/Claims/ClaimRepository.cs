using PsychologicalServices.Data;
using PsychologicalServices.Data.DatabaseSpecific;
using PsychologicalServices.Data.EntityClasses;
using PsychologicalServices.Data.Linq;
using PsychologicalServices.Infrastructure.Common.Repository;
using PsychologicalServices.Models.Claims;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System;
using System.Collections.Generic;
using System.Data;
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

        private static readonly Func<IPathEdgeRootParser<ClaimEntity>, IPathEdgeRootParser<ClaimEntity>>
            ClaimReferencesPath =
                (claimPath => claimPath
                    .Prefetch<ArbitrationClaimEntity>(claim => claim.ArbitrationClaims)
                    .Prefetch<AssessmentClaimEntity>(claim => claim.AssessmentClaims)
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

        public IEnumerable<ClaimReference> GetClaimReferences(int claimId)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var claim = meta.Claim
                    .WithPath(ClaimReferencesPath)
                    .Where(c => c.ClaimId == claimId)
                    .SingleOrDefault();

                var references = new List<ClaimReference>();

                if (claim != null)
                {
                    references.AddRange(
                        claim.ArbitrationClaims.Select(ac => new ClaimReference("Arbitration", ac.ArbitrationId))
                    );

                    references.AddRange(
                        claim.AssessmentClaims.Select(ac => new ClaimReference("Assessment", ac.AssessmentId))
                    );
                }

                return references;
            }
        }

        public IEnumerable<Claimant> SearchClaimants(string name)
        {
            var count = 20;

            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var dataset = RetrievalProcedures.ClaimantSearch(
                    null,
                    null,
                    name,
                    null,
                    count,
                    (DataAccessAdapter)adapter
                );

                var claimants = ToClaimants(dataset);

                return claimants;
            }
        }
        
        public IEnumerable<Claimant> SearchClaimants(ClaimantSearchParameters parameters)
        {
            if (parameters == null)
                return Enumerable.Empty<Claimant>();

            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var count = 20;

                var dataset = RetrievalProcedures.ClaimantSearch(
                    !string.IsNullOrWhiteSpace(parameters.FirstName) ? $"%{parameters.FirstName}%" : null,
                    !string.IsNullOrWhiteSpace(parameters.LastName) ? $"%{parameters.LastName}%" : null,
                    !string.IsNullOrWhiteSpace(parameters.Name) ? $"%{parameters.Name}%" : null,
                    parameters.DateOfBirth,
                    count,
                    (DataAccessAdapter)adapter
                );

                var claimants = ToClaimants(dataset);

                return claimants;
            }
        }

        private IEnumerable<Claimant> ToClaimants(DataSet dataset)
        {
            var claims = dataset.Tables[1]
                    .AsEnumerable()
                    .Select(row =>
                        new Claim
                        {
                            ClaimId = Convert.ToInt32(row["ClaimId"]),
                            ClaimantId = Convert.ToInt32(row["ClaimantId"]),
                            ClaimNumber = Convert.ToString(row["ClaimNumber"]),
                            InsuranceCompany = Convert.ToString(row["InsuranceCompany"]),
                            Lawyer = Convert.ToString(row["Lawyer"]),
                            DateOfLoss = row["DateOfLoss"] == DBNull.Value ? (DateTimeOffset?)null : (DateTimeOffset?)row["DateOfLoss"],
                        })
                    .ToList();

            var claimants = dataset.Tables[0]
                .AsEnumerable()
                .Select(row =>
                    new Claimant
                    {
                        ClaimantId = Convert.ToInt32(row["ClaimantId"]),
                        FirstName = Convert.ToString(row["FirstName"]),
                        LastName = Convert.ToString(row["LastName"]),
                        Gender = Convert.ToString(row["Gender"]),
                        DateOfBirth = (DateTimeOffset)row["DateOfBirth"],
                        IsActive = Convert.ToBoolean(row["IsActive"]),
                        Claims = claims.Where(c => c.ClaimantId == Convert.ToInt32(row["ClaimantId"])).ToList()
                    }
                )
                .ToList();

            return claimants;
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
