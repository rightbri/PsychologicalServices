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
    [RoutePrefix("api/context")]
    public class ContextController : ApiController
    {
        private readonly IUserService _userService = null;

        public ContextController(
            IUserService userService
        )
        {
            _userService = userService;
        }

        //[HttpGet]
        //[ResponseType(typeof(User))]
        //public IHttpActionResult Get()
        //{
        //    var user = _userService.GetUserById(id);

        //    return Ok(user);
        //}
    }
}
