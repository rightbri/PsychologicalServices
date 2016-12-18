using PsychologicalServices.Models.Common;
using PsychologicalServices.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Web.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private readonly IUserService _userService = null;

        public UserController(
            IUserService userService
        )
        {
            _userService = userService;
        }

        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(User))]
        public IHttpActionResult Get(int id)
        {
            var user = _userService.GetUserById(id);

            return Ok(user);
        }

        [Route("psychometrists/{companyId}")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<User>))]
        public IHttpActionResult GetPsychometrists(int? companyId)
        {
            var psychometrists = _userService.GetPsychometrists(companyId);

            return Ok(psychometrists);
        }

        [Route("psychologists/{companyId}")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<User>))]
        public IHttpActionResult GetPsychologists(int? companyId)
        {
            var psychologists = _userService.GetPsychologists(companyId);

            return Ok(psychologists);
        }

        [Route("save")]
        [HttpPut]
        [ResponseType(typeof(SaveResult<User>))]
        public IHttpActionResult SaveUser(User user)
        {
            var result = _userService.SaveUser(user);

            return Ok(result);
        }
    }
}
