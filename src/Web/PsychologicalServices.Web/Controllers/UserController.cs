using PsychologicalServices.Models.Common;
using PsychologicalServices.Models.Users;
using System.Collections.Generic;
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

        [Route("byUsername")]
        [HttpPost]
        [ResponseType(typeof(User))]
        public IHttpActionResult Post([FromBody]string username)
        {
            var user = _userService.GetUserByEmail(username);

            return Ok(user);
        }

        [Route("search")]
        [HttpPost]
        [ResponseType(typeof(IEnumerable<User>))]
        public IHttpActionResult Post(UserSearchCriteria criteria)
        {
            var users = _userService.GetUsers(criteria);

            return Ok(users);
        }

        [Route("psychometrists/{companyId?}")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<User>))]
        public IHttpActionResult GetPsychometrists(int? companyId = null)
        {
            var psychometrists = _userService.GetPsychometrists(companyId);

            return Ok(psychometrists);
        }

        [Route("psychologists/{companyId?}")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<User>))]
        public IHttpActionResult GetPsychologists(int? companyId = null)
        {
            var psychologists = _userService.GetPsychologists(companyId);

            return Ok(psychologists);
        }

        [Route("docListWriters/{companyId?}")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<User>))]
        public IHttpActionResult GetDocListWriters(int? companyId = null)
        {
            var docListWriters = _userService.GetDocListWriters(companyId);

            return Ok(docListWriters);
        }

        [Route("notesWriters/{companyId?}")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<User>))]
        public IHttpActionResult GetNotesWriters(int? companyId)
        {
            var notesWriters = _userService.GetNotesWriters(companyId);

            return Ok(notesWriters);
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
