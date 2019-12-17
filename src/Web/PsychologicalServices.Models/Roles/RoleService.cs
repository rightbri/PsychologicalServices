using log4net;
using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Roles
{
    public class RoleService : IRoleService
    {
        private readonly IRoleValidator _roleValidator = null;
        private readonly IRoleRepository _roleRepository = null;
        private readonly ILog _log = null;

        public RoleService(
            IRoleValidator roleValidator,
            IRoleRepository roleRepository,
            ILog log
        )
        {
            _roleValidator = roleValidator;
            _roleRepository = roleRepository;
            _log = log;
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
            var result = new SaveResult<Role>();

            try
            {
                var validation = _roleValidator.Validate(role);

                result.ValidationResult = validation;

                if (result.ValidationResult.IsValid)
                {
                    var id = _roleRepository.SaveRole(role);

                    result.Item = _roleRepository.GetRole(id);
                    result.IsSaved = true;
                }
            }
            catch (Exception ex)
            {
                _log.Error("SaveRole", ex);
                result.IsError = true;
                result.ErrorDetails = ex.Message;
            }

            return result;
        }
    }
}
