using PsychologicalServices.Models.Gose;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/gosefamilyandfriendshipsdisruptionlevel")]
    public class GoseFamilyAndFriendshipsDisruptionLevelController : ApiController
    {
        private readonly IGoseService _goseService = null;

        public GoseFamilyAndFriendshipsDisruptionLevelController(
            IGoseService goseService
        )
        {
            _goseService = goseService;
        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<GoseFamilyAndFriendshipsDisruptionLevel>))]
        public IHttpActionResult Get()
        {
            var result = _goseService.GetFamilyAndFriendshipDisruptionLevels();

            return Ok(result);
        }
    }
}
