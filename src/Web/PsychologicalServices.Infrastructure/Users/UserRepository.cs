using PsychologicalServices.Data;
using PsychologicalServices.Data.EntityClasses;
using PsychologicalServices.Data.HelperClasses;
using PsychologicalServices.Data.Linq;
using PsychologicalServices.Infrastructure.Common.Repository;
using PsychologicalServices.Models.Common.Configuration;
using PsychologicalServices.Models.Common.Utility;
using PsychologicalServices.Models.Companies;
using PsychologicalServices.Models.Rights;
using PsychologicalServices.Models.Roles;
using PsychologicalServices.Models.Users;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace PsychologicalServices.Infrastructure.Users
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        //private readonly ICacheService _cache = null;
        private readonly IConfigurationService _configuration = null;
        private readonly IDate _now = null;

        public UserRepository(
            IDataAccessAdapterFactory adapterFactory,
            //ICacheService cache,
            IConfigurationService configuration,
            IDate now
        ) : base(adapterFactory)
        {
            //_cache = cache;
            _configuration = configuration;
            _now = now;
        }

        #region Prefetch Paths

        private static readonly Func<IPathEdgeRootParser<UserEntity>, IPathEdgeRootParser<UserEntity>>
            UserLitePath =
                (uPath => uPath
                    .Prefetch<UserRoleEntity>(user => user.UserRoles)
                        .SubPath(userRolePath => userRolePath
                            .Prefetch<RoleEntity>(userRole => userRole.Role)
                            .FilterOn(role => role.IsActive)
                            .SubPath(rolePath => rolePath
                                .Prefetch<RoleRightEntity>(role => role.RoleRights)
                                .SubPath(roleRightPath => roleRightPath
                                    .Prefetch<RightEntity>(roleRight => roleRight.Right)
                                    .FilterOn(right => right.IsActive)
                                )
                            )    
                        )
                    .Prefetch<CompanyEntity>(user => user.Company)
                );

        private static readonly Func<IPathEdgeRootParser<UserEntity>, IPathEdgeRootParser<UserEntity>>
            UserPath =
                (uPath => uPath
                    .Prefetch<UserRoleEntity>(user => user.UserRoles)
                        .SubPath(userRolePath => userRolePath
                            .Prefetch<RoleEntity>(userRole => userRole.Role)
                            .FilterOn(role => role.IsActive)
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
                            .Prefetch<AddressEntity>(userTravelFee => userTravelFee.Location)
                                .SubPath(addressPath => addressPath
                                    .Prefetch<AddressTypeEntity>(address => address.AddressType)
                                )
                        )
                    .Prefetch<UserUnavailabilityEntity>(user => user.UserUnavailabilities)
                    .Prefetch<CompanyEntity>(user => user.Company)
                );

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

                    adapter.FetchEntity(userEntity, prefetch);
                }

                userEntity.FirstName = user.FirstName;
                userEntity.LastName = user.LastName;
                userEntity.Email = user.Email;
                userEntity.CompanyId = user.Company.CompanyId;
                userEntity.IsActive = user.IsActive;

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
                        travelFeeEntity.LocationId == travelFee.Location.AddressId));

                var travelFeesToRemove = userEntity.UserTravelFees
                    .Where(travelFeeEntity => !user.TravelFees.Any(travelFee =>
                        travelFee.Location.AddressId == travelFeeEntity.LocationId));

                var travelFeesToUpdate = user.TravelFees
                    .Where(travelFee => userEntity.UserTravelFees
                        .Any(travelFeeEntity =>
                            travelFeeEntity.LocationId == travelFee.Location.AddressId &&
                            travelFeeEntity.Amount != travelFee.Amount
                        )
                    );

                foreach (var travelFee in travelFeesToRemove)
                {
                    uow.AddForDelete(travelFee);
                }

                foreach (var travelFee in travelFeesToUpdate)
                {
                    var travelFeeEntity = userEntity.UserTravelFees.Where(tf => tf.LocationId == travelFee.Location.AddressId).SingleOrDefault();

                    if (null != travelFeeEntity)
                    {
                        travelFeeEntity.Amount = travelFee.Amount;
                    }
                }

                userEntity.UserTravelFees.AddRange(
                    travelFeesToAdd.Select(travelFee => new UserTravelFeeEntity
                    {
                        LocationId = travelFee.Location.AddressId,
                        Amount = travelFee.Amount
                    })
                );

                #endregion

                uow.AddForSave(userEntity);

                uow.Commit(adapter);
                
                return userEntity.UserId;
            }
        }
    }
}
