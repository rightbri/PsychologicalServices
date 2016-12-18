using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Roles
{
    public interface IRoleRepository
    {
        Role GetRole(int id);

        IEnumerable<Role> GetRoles(bool? isActive = true);

        int SaveRole(Role role);
    }
}
