using PsychologicalServices.Api.Infrastructure.Filters;
using PsychologicalServices.Models.Rights;
using PsychologicalServices.Models.Users;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/userunavailability")]
    public class UserUnavailabilityController : ApiController
    {
        private readonly IUserService _userService = null;

        public UserUnavailabilityController(
            IUserService userService
        )
        {
            _userService = userService;
        }

        [RightAuthorize(StaticRights.SearchUser)]
        [Route("search")]
        [HttpPost]
        [ResponseType(typeof(IEnumerable<User>))]
        public IHttpActionResult Post(UnavailabilitySearchCriteria criteria)
        {
            var users = _userService.GetUsersWithUnavailability(criteria);

            return Ok(users);
        }
    }
}
