using PsychologicalServices.Api.Infrastructure.Filters;
using PsychologicalServices.Models.Common;
using PsychologicalServices.Models.Rights;
using PsychologicalServices.Models.Roles;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/role")]
    public class RoleController : ApiController
    {
        private readonly IRoleService _roleService = null;

        public RoleController(
            IRoleService roleService
        )
        {
            _roleService = roleService;
        }

        [RightAuthorize(StaticRights.ViewRole)]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Role>))]
        public IHttpActionResult Get()
        {
            var roles = _roleService.GetRoles();

            return Ok(roles);
        }

        [RightAuthorize(StaticRights.ViewRole)]
        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(Role))]
        public IHttpActionResult Get(int id)
        {
            var role = _roleService.GetRole(id);

            return Ok(role);
        }

        [RightAuthorize(StaticRights.EditRole)]
        [Route("save")]
        [HttpPut]
        [ResponseType(typeof(SaveResult<Role>))]
        public IHttpActionResult SaveRole(Role role)
        {
            var result = _roleService.SaveRole(role);

            return Ok(result);
        }
    }
}
