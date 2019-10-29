using PsychologicalServices.Data;
using PsychologicalServices.Data.EntityClasses;
using PsychologicalServices.Data.Linq;
using PsychologicalServices.Infrastructure.Common.Repository;
using PsychologicalServices.Models.Appointments;
using PsychologicalServices.Models.Common.Configuration;
using PsychologicalServices.Models.Common.Utility;
using PsychologicalServices.Models.Documents;
using PsychologicalServices.Models.Rights;
using PsychologicalServices.Models.Schedule;
using PsychologicalServices.Models.Users;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PsychologicalServices.Infrastructure.Users
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        private readonly ICacheService _cache = null;
        private readonly IConfigurationService _configuration = null;
        private readonly IDate _now = null;

        public UserRepository(
            IDataAccessAdapterFactory adapterFactory,
            ICacheService cache,
            IConfigurationService configuration,
            IDate now
        ) : base(adapterFactory)
        {
            _cache = cache;
            _configuration = configuration;
            _now = now;
        }

        #region Prefetch Paths

        private static readonly Func<IPathEdgeRootParser<UserEntity>, IPathEdgeRootParser<UserEntity>>
            UserLitePath =
                (uPath => uPath
                    .Prefetch<UserRoleEntity>(user => user.UserRoles)
                        .FilterOn(userRole => userRole.Role.IsActive)
                        .SubPath(userRolePath => userRolePath
                            .Prefetch<RoleEntity>(userRole => userRole.Role)
                            //.FilterOn(role => role.IsActive)
                            .SubPath(rolePath => rolePath
                                .Prefetch<RoleRightEntity>(role => role.RoleRights)
                                .SubPath(roleRightPath => roleRightPath
                                    .Prefetch<RightEntity>(roleRight => roleRight.Right)
                                    .FilterOn(right => right.IsActive)
                                )
                            )    
                        )
                    .Prefetch<UserUnavailabilityEntity>(user => user.UserUnavailabilities)
                    .Prefetch<CompanyEntity>(user => user.Company)
                );

        private static readonly Func<IPathEdgeRootParser<UserEntity>, IPathEdgeRootParser<UserEntity>>
            UserPath =
                (uPath => uPath
                    .Prefetch<UserRoleEntity>(user => user.UserRoles)
                        .FilterOn(userRole => userRole.Role.IsActive)
                        .SubPath(userRolePath => userRolePath
                            .Prefetch<RoleEntity>(userRole => userRole.Role)
                            //.FilterOn(role => role.IsActive)
                            .SubPath(rolePath => rolePath
                                .Prefetch<RoleRightEntity>(role => role.RoleRights)
                                .SubPath(roleRightPath => roleRightPath
                                    .Prefetch<RightEntity>(roleRight => roleRight.Right)
                                    .FilterOn(right => right.IsActive)
                                )
                            )
                        )
                    .Prefetch<UserTravelFeeEntity>(user => user.UserTravelFees)
                        .SubPath(userTravelFeePath => userTravelFeePath
                            .Prefetch<CityEntity>(userTravelFee => userTravelFee.City)
                        )
                    .Prefetch<UserUnavailabilityEntity>(user => user.UserUnavailabilities)
                    .Prefetch<CompanyEntity>(user => user.Company)
                    .Prefetch<AddressEntity>(user => user.Address)
                        .SubPath(addressPath => addressPath
                            .Prefetch<CityEntity>(address => address.City)
                        )
                );

            private static readonly Func<IPathEdgeRootParser<UserEntity>, IPathEdgeRootParser<UserEntity>>
                UserUnavailabilityPath =
                    (uPath => uPath
                        .Prefetch<UserUnavailabilityEntity>(user => user.UserUnavailabilities)
                    );

        private Func<IPathEdgeRootParser<UserEntity>, IPathEdgeRootParser<UserEntity>> GetPsychometristSchedulePath(
            PsychometristScheduleSearchCriteria criteria
        )
        {
            return (uPath => uPath
                    .Prefetch<CompanyEntity>(user => user.Company)
                    .Prefetch<AppointmentEntity>(user => user.PsychometristAppointments)
                        .SubPath(appointmentPath => appointmentPath
                            .Prefetch<AppointmentStatusEntity>(appointment => appointment.AppointmentStatus)
                            .Prefetch<AddressEntity>(appointment => appointment.Location)
                                .SubPath(addressPath => addressPath
                                    .Prefetch<CityEntity>(address => address.City)
                                )
                            .Prefetch<AppointmentAttributeEntity>(appointment => appointment.AppointmentAttributes)
                                .FilterOn(appointmentAttribute => appointmentAttribute.Attribute.IsActive)
                                .SubPath(appointmentAttributePath => appointmentAttributePath
                                    .Prefetch<AttributeEntity>(appointmentAttribute => appointmentAttribute.Attribute)
                                        .SubPath(attributePath => attributePath
                                            .Prefetch<AttributeTypeEntity>(attribute => attribute.AttributeType)
                                        )
                                )
                            .Prefetch<AssessmentEntity>(appointment => appointment.Assessment)
                                .SubPath(assessmentPath => assessmentPath
                                    .Prefetch<AssessmentTypeEntity>(assessment => assessment.AssessmentType)
                                    .Prefetch<ReferralSourceEntity>(assessment => assessment.ReferralSource)
                                    .Prefetch<ClaimantEntity>(assessment => assessment.Claimant)
                                    .Prefetch<AssessmentClaimEntity>(assessment => assessment.AssessmentClaims)
                                        .SubPath(assessmentClaimPath => assessmentClaimPath
                                            .Prefetch<ClaimEntity>(assessmentClaim => assessmentClaim.Claim)
                                        )
                                    .Prefetch<AssessmentAttributeEntity>(assessment => assessment.AssessmentAttributes)
                                        .FilterOn(assessmentAttribute => assessmentAttribute.Attribute.IsActive)
                                        .SubPath(assessmentAttributePath => assessmentAttributePath
                                            .Prefetch<AttributeEntity>(assessmentAttribute => assessmentAttribute.Attribute)
                                                .SubPath(attributePath => attributePath
                                                    .Prefetch<AttributeTypeEntity>(attribute => attribute.AttributeType)
                                                )
                                        )
                                    .Prefetch<AppointmentEntity>(assessment => assessment.Appointments)
                                )
                        )
                        .FilterOn(appointment =>
                            null == criteria ||
                            (
                                appointment.AppointmentTime >= criteria.StartDate &&
                                appointment.AppointmentTime <= criteria.EndDate &&
                                (
                                    appointment.AppointmentStatusId == AppointmentStatus.OnHold ||
                                    appointment.AppointmentStatusId == AppointmentStatus.Confirmed
                                )
                            )
                        )
                );
        }

        #endregion

        public User GetUserById(int id)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var users = meta.User
                    .WithPath(UserPath)
                    .Where(user => user.UserId == id);

                return users
                    .SingleOrDefault()
                    .ToUser();
            }
        }

        public User GetUserByEmail(string email)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var users = meta.User
                    .WithPath(UserPath)
                    .Where(user => user.Email == email);

                return users
                    .SingleOrDefault()
                    .ToUser();
            }
        }

        public IEnumerable<User> GetUsers(UserSearchCriteria criteria)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var users = meta.User
                    .WithPath(UserPath);

                if (null != criteria)
                {

                    if (criteria.CompanyId.HasValue)
                    {
                        users = users.Where(user => user.CompanyId == criteria.CompanyId.Value);
                    }

                    if (!string.IsNullOrWhiteSpace(criteria.Email))
                    {
                        users = users.Where(user => user.Email.Contains(criteria.Email));
                    }

                    if (!string.IsNullOrWhiteSpace(criteria.FirstName))
                    {
                        users = users.Where(user => user.FirstName.Contains(criteria.FirstName));
                    }

                    if (!string.IsNullOrWhiteSpace(criteria.LastName))
                    {
                        users = users.Where(user => user.LastName.Contains(criteria.LastName));
                    }

                    if (criteria.RightId.HasValue)
                    {
                        users = users
                            .Where(user =>
                                user.UserRoles.Any(userRole =>
                                    userRole.Role.RoleRights.Any(roleRight =>
                                        roleRight.RightId == criteria.RightId.Value
                                    )
                                )
                            );
                    }

                    if (criteria.RoleId.HasValue)
                    {
                        users = users.Where(user => user.UserRoles.Any(userRole => userRole.RoleId == criteria.RoleId.Value));
                    }

                    if (criteria.UserId.HasValue)
                    {
                        users = users.Where(user => user.UserId == criteria.UserId.Value);
                    }

                    if (criteria.IsActive.HasValue)
                    {
                        users = users.Where(user => user.IsActive == criteria.IsActive.Value);
                    }

                    if (criteria.AvailableDate.HasValue)
                    {
                        users = users
                            .Where(user => !user.UserUnavailabilities
                                .Any(unavailability =>
                                    unavailability.StartDate <= criteria.AvailableDate.Value && 
                                    unavailability.EndDate >= criteria.AvailableDate.Value
                                )
                            );
                    }
                }

                return Execute<UserEntity>(
                        (ILLBLGenProQuery)
                        users
                    )
                    .Select(user => user.ToUserLite())
                    .ToList();
            }
        }
        
        public IEnumerable<User> GetDocListWriters(int? companyId = null)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var users = meta.User
                    .WithPath(UserLitePath)
                    .Where(u =>
                        u.UserRoles.Any(userRole =>
                            userRole.Role.RoleRights.Any(roleRight =>
                                roleRight.Right.Name == StaticRights.WriteDocList.ToString()
                            )
                        ) &&
                        (companyId == null || companyId.Value == u.CompanyId)
                    );

                return Execute<UserEntity>(
                        (ILLBLGenProQuery)
                        users
                    )
                    .Select(entity => entity.ToUserLite())
                    .ToList();
            }
        }

        public IEnumerable<User> GetNotesWriters(int? companyId = null)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var users = meta.User
                    .WithPath(UserLitePath)
                    .Where(u =>
                        u.UserRoles.Any(userRole =>
                            userRole.Role.RoleRights.Any(roleRight =>
                                roleRight.Right.Name == StaticRights.WriteNotes.ToString()
                            )
                        ) &&
                        (companyId == null || companyId.Value == u.CompanyId)
                    );

                return Execute<UserEntity>(
                        (ILLBLGenProQuery)
                        users
                    )
                    .Select(entity => entity.ToUserLite())
                    .ToList();
            }
        }

        public IEnumerable<User> GetPsychometrists(int? companyId = null)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var users = meta.User
                    .WithPath(UserLitePath)
                    .Where(u =>
                        u.UserRoles.Any(userRole =>
                            userRole.Role.RoleRights.Any(roleRight =>
                                roleRight.Right.Name == StaticRights.Psychometrist.ToString()
                            )
                        ) &&
                        (companyId == null || companyId.Value == u.CompanyId)
                    );

                return Execute<UserEntity>(
                        (ILLBLGenProQuery)
                        users
                    )
                    .Select(entity => entity.ToUserLite())
                    .ToList();
            }
        }

        public IEnumerable<User> GetPsychologists(int? companyId = null)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var users = meta.User
                    .WithPath(UserLitePath)
                    .Where(u =>
                        u.UserRoles.Any(userRole =>
                            userRole.Role.RoleRights.Any(roleRight =>
                                roleRight.Right.Name == StaticRights.Psychologist.ToString()
                            )
                        ) &&
                        (companyId == null || companyId.Value == u.CompanyId)
                    );

                return Execute<UserEntity>(
                        (ILLBLGenProQuery)
                        users
                    )
                    .Select(entity => entity.ToUserLite())
                    .ToList();
            }
        }

        public IEnumerable<User> GetPsychometristSchedules(PsychometristScheduleSearchCriteria criteria)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var path = GetPsychometristSchedulePath(criteria);

                var users = meta.User
                    .WithPath(path);
                
                if (null != criteria)
                {
                    users = users
                        .Where(user =>
                            user.CompanyId == criteria.CompanyId &&
                            user.PsychometristAppointments.Any(appointment =>
                                appointment.AppointmentTime >= criteria.StartDate &&
                                appointment.AppointmentTime <= criteria.EndDate &&
                                (
                                    new[]
                                    {
                                        AppointmentStatus.OnHold,
                                        AppointmentStatus.Confirmed
                                    }.Contains(appointment.AppointmentStatusId)
                                )
                            )
                        );

                    if (criteria.PsychometristId.HasValue)
                    {
                        users = users.Where(user => user.UserId == criteria.PsychometristId);
                    }
                }
                
                return Execute<UserEntity>(
                        (ILLBLGenProQuery)
                        users
                    )
                    .Select(entity => entity.ToPsychometristScheduleUser())
                    .ToList();
            }
        }
        
        public IEnumerable<User> GetUsersWithUnavailability(UnavailabilitySearchCriteria criteria)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var users = meta.User
                    .WithPath(UserUnavailabilityPath);

                if (null != criteria)
                {
                    if (criteria.CompanyId.HasValue)
                    {
                        users = users.Where(user => user.CompanyId == criteria.CompanyId.Value);
                    }

                    if (criteria.UnavailabilityStart.HasValue)
                    {
                        users = users.Where(user =>
                            user.UserUnavailabilities.Any(unavailability =>
                                unavailability.StartDate >= criteria.UnavailabilityStart.Value
                            )
                        );
                    }

                    if (criteria.UnavailabilityEnd.HasValue)
                    {
                        users = users.Where(user =>
                            user.UserUnavailabilities.Any(unavailability =>
                                unavailability.StartDate < criteria.UnavailabilityEnd.Value
                            )
                        );
                    }
                }

                return Execute<UserEntity>(
                        (ILLBLGenProQuery)
                        users
                    )
                    .Select(user => user.ToUser())
                    .ToList();
            }
        }

        public int SaveUser(User user)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var uow = new UnitOfWork2();

                var isNew = user.IsNew();

                var userEntity = new UserEntity
                {
                    IsNew = isNew,
                    UserId = user.UserId,
                };

                if (!isNew)
                {
                    var prefetch = new PrefetchPath2(EntityType.UserEntity);

                    prefetch.Add(UserEntity.PrefetchPathUserRoles);

                    prefetch.Add(UserEntity.PrefetchPathUserUnavailabilities);

                    prefetch.Add(UserEntity.PrefetchPathUserTravelFees);

                    adapter.FetchEntity(userEntity, prefetch);
                }

                userEntity.FirstName = user.FirstName;
                userEntity.LastName = user.LastName;
                userEntity.Email = user.Email;
                userEntity.CompanyId = user.Company.CompanyId;
                userEntity.AddressId = user.Address.AddressId;
                userEntity.IsActive = user.IsActive;

                if (user.DateInactivated.HasValue)
                {
                    userEntity.DateInactivated = user.DateInactivated;
                }
                else
                {
                    userEntity.SetNewFieldValue((int)UserFieldIndex.DateInactivated, null);
                }

                #region roles

                var rolesToRemove = userEntity.UserRoles.Where(userRole => !user.Roles.Any(role => role.RoleId == userRole.RoleId));

                foreach (var userRole in rolesToRemove)
                {
                    uow.AddForDelete(userRole);
                }

                var rolesToAdd = user.Roles.Where(role => !userEntity.UserRoles.Any(userRole => userRole.RoleId == role.RoleId));

                userEntity.UserRoles.AddRange(
                    rolesToAdd.Select(role => new UserRoleEntity { UserId = user.UserId, RoleId = role.RoleId })
                );
                
                #endregion

                #region unavailabilities

                var unavailabilitiesToAdd = user.Unavailability
                    .Where(unavailability => !userEntity.UserUnavailabilities.Any(unavailabilityEntity => 
                        unavailabilityEntity.StartDate == unavailability.StartDate));

                var unavailabilitiesToRemove = userEntity.UserUnavailabilities
                    .Where(unavailabilityEntity => !user.Unavailability.Any(unavailability => 
                        unavailability.StartDate == unavailabilityEntity.StartDate));

                var unavailabilitiesToUpdate = user.Unavailability
                    .Where(unavailability => userEntity.UserUnavailabilities
                        .Any(unavailabilityEntity =>
                            unavailabilityEntity.StartDate == unavailability.StartDate &&
                            unavailabilityEntity.EndDate != unavailability.EndDate
                        )
                    );

                foreach (var unavailability in unavailabilitiesToRemove)
                {
                    uow.AddForDelete(unavailability);
                }

                foreach (var unavailability in unavailabilitiesToUpdate)
                {
                    var unavailabilityEntity = userEntity.UserUnavailabilities.Where(ue => ue.StartDate == unavailability.StartDate).SingleOrDefault();

                    if (null != unavailabilityEntity)
                    {
                        unavailabilityEntity.EndDate = unavailability.EndDate;
                    }
                }

                userEntity.UserUnavailabilities.AddRange(
                    unavailabilitiesToAdd.Select(unavailability => new UserUnavailabilityEntity
                    {
                        StartDate = unavailability.StartDate,
                        EndDate = unavailability.EndDate,
                    })
                );

                #endregion

                #region travel fees

                var travelFeesToAdd = user.TravelFees
                    .Where(travelFee => !userEntity.UserTravelFees.Any(travelFeeEntity =>
                        travelFeeEntity.CityId == travelFee.City.CityId));

                var travelFeesToRemove = userEntity.UserTravelFees
                    .Where(travelFeeEntity => !user.TravelFees.Any(travelFee =>
                        travelFee.City.CityId == travelFeeEntity.CityId));

                var travelFeesToUpdate = user.TravelFees
                    .Where(travelFee => userEntity.UserTravelFees
                        .Any(travelFeeEntity =>
                            travelFeeEntity.CityId == travelFee.City.CityId &&
                            travelFeeEntity.Amount != travelFee.Amount
                        )
                    );

                foreach (var travelFee in travelFeesToRemove)
                {
                    uow.AddForDelete(travelFee);
                }

                foreach (var travelFee in travelFeesToUpdate)
                {
                    var travelFeeEntity = userEntity.UserTravelFees.Where(tf => tf.CityId == travelFee.City.CityId).SingleOrDefault();

                    if (null != travelFeeEntity)
                    {
                        travelFeeEntity.Amount = travelFee.Amount;
                    }
                }

                userEntity.UserTravelFees.AddRange(
                    travelFeesToAdd.Select(travelFee => new UserTravelFeeEntity
                    {
                        CityId = travelFee.City.CityId,
                        Amount = travelFee.Amount
                    })
                );

                #endregion

                uow.AddForSave(userEntity);

                uow.Commit(adapter);

                _cache.Remove(user.Email);

                return userEntity.UserId;
            }
        }

        public Document GetSpinnerForUser(int userId)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var spinner = meta.User
                    .Where(user => user.UserId == userId)
                    .Select(user => user.Spinner.ToDocument())
                    .SingleOrDefault();

                return spinner;
            }
        }

        public void SaveUserSpinner(int userId, int? documentId)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var user = meta.User.Where(u => u.UserId == userId).SingleOrDefault();

                if (null != user)
                {
                    if (documentId.HasValue)
                    {
                        user.SpinnerId = documentId;
                    }
                    else
                    {
                        user.SetNewFieldValue((int)UserFieldIndex.SpinnerId, null);
                    }

                    adapter.SaveEntity(user);
                }
            }
        }
    }
}
