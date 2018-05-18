using PsychologicalServices.Models.Common;
using PsychologicalServices.Models.Documents;
using PsychologicalServices.Models.Users;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/userspinner")]
    public class UserSpinnerController : ApiController
    {
        private readonly IUserService _userService = null;

        public UserSpinnerController(
            IUserService userService
        )
        {
            _userService = userService;
        }

        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(Document))]
        public IHttpActionResult Get(int id)
        {
            var spinner = _userService.GetSpinnerForUser(id);

            return Ok(spinner);
        }

        [Route("save")]
        [HttpPut]
        [ResponseType(typeof(SaveResult<Document>))]
        public IHttpActionResult Save(UserSpinner userSpinner)
        {
            var result = _userService.SaveUserSpinner(userSpinner.UserId, userSpinner.DocumentId);

            return Ok(result);
        }
    }
}
