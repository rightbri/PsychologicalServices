using PsychologicalServices.Api.Infrastructure.Filters;
using PsychologicalServices.Models.Common;
using PsychologicalServices.Models.Rights;
using PsychologicalServices.Models.Users;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
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

        [RightAuthorize(StaticRights.ViewUser)]
        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(User))]
        public IHttpActionResult Get(int id)
        {
            var user = _userService.GetUserById(id);

            return Ok(user);
        }

        [RightAuthorize(StaticRights.ViewUser)]
        [Route("byUsername")]
        [HttpPost]
        [ResponseType(typeof(User))]
        public IHttpActionResult Post([FromBody]string username)
        {
            var user = _userService.GetUserByEmail(username);

            return Ok(user);
        }

        [RightAuthorize(StaticRights.SearchUser)]
        [Route("search")]
        [HttpPost]
        [ResponseType(typeof(IEnumerable<User>))]
        public IHttpActionResult Post(UserSearchCriteria criteria)
        {
            var users = _userService.GetUsers(criteria);

            return Ok(users);
        }

        [RightAuthorize(StaticRights.ViewUser)]
        [Route("psychometrists/{companyId?}")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<User>))]
        public IHttpActionResult GetPsychometrists(int? companyId = null)
        {
            var psychometrists = _userService.GetPsychometrists(companyId);

            return Ok(psychometrists);
        }

        [RightAuthorize(StaticRights.ViewUser)]
        [Route("psychologists/{companyId?}")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<User>))]
        public IHttpActionResult GetPsychologists(int? companyId = null)
        {
            var psychologists = _userService.GetPsychologists(companyId);

            return Ok(psychologists);
        }

        [RightAuthorize(StaticRights.ViewUser)]
        [Route("docListWriters/{companyId?}")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<User>))]
        public IHttpActionResult GetDocListWriters(int? companyId = null)
        {
            var docListWriters = _userService.GetDocListWriters(companyId);

            return Ok(docListWriters);
        }

        [RightAuthorize(StaticRights.ViewUser)]
        [Route("notesWriters/{companyId?}")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<User>))]
        public IHttpActionResult GetNotesWriters(int? companyId)
        {
            var notesWriters = _userService.GetNotesWriters(companyId);

            return Ok(notesWriters);
        }

        [RightAuthorize(StaticRights.EditUser)]
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
