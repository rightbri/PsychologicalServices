using PsychologicalServices.Models.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Web.Controllers
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

        [HttpGet]
        [ResponseType(typeof(IEnumerable<Role>))]
        public IHttpActionResult Get()
        {
            var roles = _roleService.GetRoles();

            return Ok(roles);
        }
    }
}
