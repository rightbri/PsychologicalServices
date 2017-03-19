using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Roles
{
    public interface IRoleService
    {
        Role GetRole(int id);

        IEnumerable<Role> GetRoles(bool? isActive = true);

        SaveResult<Role> SaveRole(Role role);
    }
}
