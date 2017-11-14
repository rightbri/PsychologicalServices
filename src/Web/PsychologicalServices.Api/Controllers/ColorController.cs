using PsychologicalServices.Models.Colors;
using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/color")]
    public class ColorController : ApiController
    {
        private readonly IColorService _colorService = null;

        public ColorController(
            IColorService colorService
        )
        {
            _colorService = colorService;
        }

        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(Color))]
        public IHttpActionResult Get(int id)
        {
            var color = _colorService.GetColor(id);

            return Ok(color);
        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<Color>))]
        public IHttpActionResult Get()
        {
            var colors = _colorService.GetColors();

            return Ok(colors);
        }

        [Route("save")]
        [HttpPut]
        [ResponseType(typeof(SaveResult<Color>))]
        public IHttpActionResult Save(Color color)
        {
            var result = _colorService.SaveColor(color);

            return Ok(result);
        }
    }
}
