using PsychologicalServices.Data.EntityClasses;
using PsychologicalServices.Data.Linq;
using PsychologicalServices.Infrastructure.Common.Repository;
using PsychologicalServices.Models.Roles;
using SD.LLBLGen.Pro.LinqSupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Infrastructure.Roles
{
    public class RoleRepository : RepositoryBase, IRoleRepository
    {
        public RoleRepository(
            IDataAccessAdapterFactory dataAccessAdapterFactory
        ) : base(dataAccessAdapterFactory)
        {
        }

        #region Prefetch Paths

        private static readonly Func<IPathEdgeRootParser<RoleEntity>, IPathEdgeRootParser<RoleEntity>>
            RolePath =
                (rolePath => rolePath
                    .Prefetch<RoleRightEntity>(role => role.RoleRights)
                        .SubPath(roleRightPath => roleRightPath
                            .Prefetch<RightEntity>(roleRight => roleRight.Right)
                            .FilterOn(right => right.IsActive)
                        )
                );

        #endregion

        public Role GetRole(int id)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return meta.Role
                    .WithPath(RolePath)
                    .Where(role => role.RoleId == id)
                    .SingleOrDefault()
                    .ToRole();
            }
        }

        public IEnumerable<Role> GetRoles(bool? isActive = true)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return Execute<RoleEntity>(
                        (ILLBLGenProQuery)
                        meta.Role
                        .WithPath(RolePath)
                        .Where(role => isActive == null || role.IsActive == isActive)
                    )
                    .Select(role => role.ToRole())
                    .ToList();
            }
        }

        public int SaveRole(Role role)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var isNew = role.IsNew();

                var entity = new RoleEntity
                {
                    IsNew = isNew,
                    RoleId = role.RoleId,
                };

                if (!isNew)
                {
                    adapter.FetchEntity(entity);
                }

                entity.Name = role.Name;
                entity.Description = role.Description;
                entity.IsActive = role.IsActive;

                var rightsToAdd = role.Rights.Where(right => !entity.RoleRights.Any(roleRight => roleRight.RightId == right.RightId));

                var rightsToRemove = entity.RoleRights.Where(roleRight => !role.Rights.Any(right => right.RightId == roleRight.RightId));

                entity.RoleRights.AddRange(
                    role.Rights.Select(right => new RoleRightEntity
                    {
                        RoleId = role.RoleId,
                        RightId = right.RightId,
                    })
                );
                
                foreach (var right in rightsToRemove)
                {
                    entity.RoleRights.Remove(right);
                }

                adapter.SaveEntity(entity, false);

                return entity.RoleId;
            }
        }
    }
}
