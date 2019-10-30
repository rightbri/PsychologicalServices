using PsychologicalServices.Api.Infrastructure.Filters;
using PsychologicalServices.Models.Cities;
using PsychologicalServices.Models.Common;
using PsychologicalServices.Models.Rights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/city")]
    public class CityController : ApiController
    {
        private readonly ICityService _cityService = null;

        public CityController(
            ICityService cityService
        )
        {
            _cityService = cityService;
        }

        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(City))]
        public IHttpActionResult Get(int id)
        {
            var city = _cityService.GetCity(id);

            return Ok(city);
        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<City>))]
        public IHttpActionResult Get()
        {
            var cities = _cityService.GetCities();

            return Ok(cities);
        }

        [RightAuthorize(StaticRights.EditCity)]
        [Route("save")]
        [HttpPut]
        [ResponseType(typeof(SaveResult<City>))]
        public IHttpActionResult Save(City city)
        {
            var result = _cityService.SaveCity(city);

            return Ok(result);
        }
    }
}
