using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Roles
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository = null;

        public RoleService(
            IRoleRepository roleRepository
        )
        {
            _roleRepository = roleRepository;
        }

        public Role GetRole(int id)
        {
            var role = _roleRepository.GetRole(id);

            return role;
        }

        public IEnumerable<Role> GetRoles(bool? isActive = true)
        {
            var roles = _roleRepository.GetRoles(isActive);

            return roles;
        }

        public SaveResult<Role> SaveRole(Role role)
        {
            throw new NotImplementedException();
        }
    }
}
