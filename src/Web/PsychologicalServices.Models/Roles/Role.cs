using PsychologicalServices.Models.Rights;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Roles
{
    public class Role
    {
        public int RoleId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public List<Right> Rights { get; set; }

        public bool IsNew()
        {
            return RoleId == 0;
        }
    }
}
