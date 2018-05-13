using PsychologicalServices.Data;
using PsychologicalServices.Data.EntityClasses;
using PsychologicalServices.Data.Linq;
using PsychologicalServices.Infrastructure.Common.Repository;
using PsychologicalServices.Models.Arbitrations;
using PsychologicalServices.Models.Common.Utility;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Infrastructure.Arbitrations
{
    public class ArbitrationRepository : RepositoryBase, IArbitrationRepository
    {
        private readonly IDate _date = null;

        public ArbitrationRepository(
            IDataAccessAdapterFactory adapterFactory,
            IDate date
        ) : base(adapterFactory)
        {
            _date = date;
        }

        #region Prefetch Paths

        private static readonly Func<IPathEdgeRootParser<ArbitrationEntity>, IPathEdgeRootParser<ArbitrationEntity>>
            ArbitrationPath =
                (arbitrationPath => arbitrationPath
                    .Prefetch<UserEntity>(arbitration => arbitration.Psychologist)
                        .SubPath(psychologistPath => psychologistPath
                            .Prefetch<CompanyEntity>(psychologist => psychologist.Company)
                                .SubPath(companyPath => companyPath
                                    .Prefetch<AddressEntity>(company => company.Address)
                                        .SubPath(addressPath => addressPath
                                            .Prefetch<CityEntity>(address => address.City)
                                        )
                                )
                        )
                    .Prefetch<ClaimantEntity>(arbitration => arbitration.Claimant)
                        .SubPath(claimantPath => claimantPath
                            .Prefetch<ClaimEntity>(claimant => claimant.Claims)
                        )
                    .Prefetch<ArbitrationClaimEntity>(arbitration => arbitration.ArbitrationClaims)
                        .SubPath(arbitrationClaimPath => arbitrationClaimPath
                            .Prefetch<ClaimEntity>(arbitrationClaim => arbitrationClaim.Claim)
                        )
                    .Prefetch<ContactEntity>(arbitration => arbitration.DefenseLawyer)
                        .SubPath(contactPath => contactPath
                            .Prefetch<ContactTypeEntity>(contact => contact.ContactType)
                            .Prefetch<EmployerEntity>(contact => contact.Employer)
                            .Prefetch<AddressEntity>(contact => contact.Address)
                                .SubPath(addressPath => addressPath
                                    .Prefetch<CityEntity>(address => address.City)
                                )
                        )
                    .Prefetch<ContactEntity>(arbitration => arbitration.PlaintiffLawyer)
                        .SubPath(contactPath => contactPath
                            .Prefetch<ContactTypeEntity>(contact => contact.ContactType)
                            .Prefetch<EmployerEntity>(contact => contact.Employer)
                            .Prefetch<AddressEntity>(contact => contact.Address)
                                .SubPath(addressPath => addressPath
                                    .Prefetch<CityEntity>(address => address.City)
                                )
                        )
                    .Prefetch<ContactEntity>(arbitration => arbitration.BillToContact)
                        .SubPath(contactPath => contactPath
                            .Prefetch<ContactTypeEntity>(contact => contact.ContactType)
                            .Prefetch<EmployerEntity>(contact => contact.Employer)
                            .Prefetch<AddressEntity>(contact => contact.Address)
                                .SubPath(addressPath => addressPath
                                    .Prefetch<CityEntity>(address => address.City)
                                )
                        )
                    .Prefetch<NoteEntity>(arbitration => arbitration.Note)
                        .SubPath(notePath => notePath
                            .Prefetch<UserEntity>(note => note.CreateUser)
                            .Prefetch<UserEntity>(note => note.UpdateUser)
                        )
                    .Prefetch<ArbitrationStatusEntity>(arbitration => arbitration.ArbitrationStatus)
                );

        #endregion

        public Arbitration GetArbitration(int arbitrationId)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var arbitration = meta.Arbitration
                    .WithPath(ArbitrationPath)
                    .Where(a => a.ArbitrationId == arbitrationId)
                    .SingleOrDefault()
                    .ToArbitration();

                return arbitration;
            }
        }

        public IEnumerable<ArbitrationStatus> GetArbitrationStatuses(bool? isActive = true)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return
                    Execute<ArbitrationStatusEntity>(
                        (ILLBLGenProQuery)
                        meta.ArbitrationStatus
                        .Where(arbitrationStatus => isActive == null || arbitrationStatus.IsActive == isActive.Value)
                    )
                    .Select(arbitrationStatus => arbitrationStatus.ToArbitrationStatus())
                    .ToList();
            }
        }

        public IEnumerable<Arbitration> GetArbitrations(ArbitrationSearchCriteria criteria)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var arbitrations = meta.Arbitration
                    .WithPath(ArbitrationPath)
                    .Where(arbitration =>
                        (criteria.StartDate == null || arbitration.StartDate == null || arbitration.StartDate <= criteria.EndDate) &&
                        (criteria.EndDate == null || arbitration.EndDate == null || arbitration.EndDate >= criteria.StartDate)
                    );

                if (criteria.CompanyId.HasValue)
                {
                    arbitrations = arbitrations.Where(arbitration => arbitration.Assessment.CompanyId == criteria.CompanyId);
                }

                if (criteria.ClaimantId.HasValue)
                {
                    arbitrations = arbitrations.Where(arbitration => arbitration.ClaimantId == criteria.ClaimantId);
                }

                if (null != criteria.ArbitrationStatusIds && criteria.ArbitrationStatusIds.Any())
                {
                    arbitrations = arbitrations.Where(arbitration =>
                        arbitration.ArbitrationStatusId == null ||
                        criteria.ArbitrationStatusIds.Contains(arbitration.ArbitrationStatusId.Value)
                    );
                }
                
                return Execute<ArbitrationEntity>(
                        (ILLBLGenProQuery)
                        arbitrations
                    )
                    .Select(arbitration => arbitration.ToArbitration())
                    .ToList();
            }
        }

        public int SaveArbitration(Arbitration arbitration)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var uow = new UnitOfWork2();

                var isNew = arbitration.IsNew();

                var entity = new ArbitrationEntity
                {
                    IsNew = isNew,
                    ArbitrationId = arbitration.ArbitrationId,
                };
                
                if (!isNew)
                {
                    var prefetch = new PrefetchPath2(EntityType.ArbitrationEntity);

                    prefetch.Add(ArbitrationEntity.PrefetchPathArbitrationClaims);
                    
                    adapter.FetchEntity(entity, prefetch);
                }
                
                entity.Title = arbitration.Title;

                entity.PsychologistId = arbitration.Psychologist.UserId;
                entity.ClaimantId = arbitration.Claimant.ClaimantId;
                
                if (arbitration.StartDate.HasValue)
                {
                    entity.StartDate = arbitration.StartDate;
                }
                else
                {
                    entity.SetNewFieldValue((int)ArbitrationFieldIndex.StartDate, null);
                }

                if (arbitration.EndDate.HasValue)
                {
                    entity.EndDate = arbitration.EndDate;
                }
                else
                {
                    entity.SetNewFieldValue((int)ArbitrationFieldIndex.EndDate, null);
                }

                if (arbitration.AvailableDate.HasValue)
                {
                    entity.AvailableDate = arbitration.AvailableDate;
                }
                else
                {
                    entity.SetNewFieldValue((int)ArbitrationFieldIndex.AvailableDate, null);
                }

                if (arbitration.NotifiedDate.HasValue)
                {
                    entity.NotifiedDate = arbitration.NotifiedDate;
                }
                else
                {
                    entity.SetNewFieldValue((int)ArbitrationFieldIndex.NotifiedDate, null);
                }

                if (arbitration.LetterOfUnderstandingSentDate.HasValue)
                {
                    entity.LetterOfUnderstandingSentDate = arbitration.LetterOfUnderstandingSentDate;
                }
                else
                {
                    entity.SetNewFieldValue((int)ArbitrationFieldIndex.LetterOfUnderstandingSentDate, null);
                }

                if (null == arbitration.DefenseLawyer)
                {
                    entity.SetNewFieldValue((int)ArbitrationFieldIndex.DefenseLawyerId, null);
                }
                else
                {
                    entity.DefenseLawyerId = arbitration.DefenseLawyer.ContactId;
                }

                if (string.IsNullOrWhiteSpace(arbitration.DefenseFileNumber))
                {
                    entity.SetNewFieldValue((int)ArbitrationFieldIndex.DefenseFileNumber, null);
                }
                else
                {
                    entity.DefenseFileNumber = arbitration.DefenseFileNumber;
                }

                if (null == arbitration.PlaintiffLawyer)
                {
                    entity.SetNewFieldValue((int)ArbitrationFieldIndex.PlaintiffLawyerId, null);
                }
                else
                {
                    entity.PlaintiffLawyerId = arbitration.PlaintiffLawyer.ContactId;
                }

                if (null == arbitration.BillToContact)
                {
                    entity.SetNewFieldValue((int)ArbitrationFieldIndex.BillToContactId, null);
                }
                else
                {
                    entity.BillToContactId = arbitration.BillToContact.ContactId;
                }

                if (null == arbitration.ArbitrationStatus)
                {
                    entity.SetNewFieldValue((int)ArbitrationFieldIndex.ArbitrationStatusId, null);
                }
                else
                {
                    entity.ArbitrationStatusId = arbitration.ArbitrationStatus.ArbitrationStatusId;
                }

                if (null != arbitration.Note)
                {
                    if (null == entity.Note)
                    {
                        if (!string.IsNullOrWhiteSpace(arbitration.Note.NoteText))
                        {
                            entity.Note = new NoteEntity
                            {
                                Note = arbitration.Note.NoteText,
                                CreateUserId = arbitration.Note.CreateUser.UserId,
                                UpdateUserId = arbitration.Note.UpdateUser.UserId,
                            };
                        }
                    }
                    else if (entity.Note.Note != arbitration.Note.NoteText)
                    {
                        entity.Note.Note = arbitration.Note.NoteText;
                        entity.Note.UpdateUserId = arbitration.Note.UpdateUser.UserId;
                        entity.Note.UpdateDate = _date.UtcNow;
                    }
                }

                #region arbitration claims

                var arbitrationClaimsToRemove = entity.ArbitrationClaims
                    .Where(arbitrationClaim =>
                        !arbitration.Claims.Any(claim =>
                            claim.ClaimId == arbitrationClaim.ClaimId
                        )
                    );

                foreach (var arbitrationClaim in arbitrationClaimsToRemove)
                {
                    uow.AddForDelete(arbitrationClaim);
                }

                var arbitrationClaimsToAdd = arbitration.Claims
                    .Where(claim =>
                        !entity.ArbitrationClaims.Any(arbitrationClaim =>
                            arbitrationClaim.ClaimId == claim.ClaimId
                        )
                    );

                entity.ArbitrationClaims.AddRange(
                    arbitrationClaimsToAdd.Select(claim =>
                    new ArbitrationClaimEntity
                    {
                        ClaimId = claim.ClaimId,
                    })
                );

                #endregion

                uow.AddForSave(entity);

                uow.Commit(adapter);

                return entity.ArbitrationId;
            }
        }
    }
}
