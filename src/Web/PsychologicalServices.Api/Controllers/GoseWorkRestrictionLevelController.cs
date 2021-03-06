﻿using PsychologicalServices.Models.Gose;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/goseworkrestrictionlevel")]
    public class GoseWorkRestrictionLevelController : ApiController
    {
        private readonly IGoseService _goseService = null;

        public GoseWorkRestrictionLevelController(
            IGoseService goseService
        )
        {
            _goseService = goseService;
        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<GoseWorkRestrictionLevel>))]
        public IHttpActionResult Get()
        {
            var result = _goseService.GetWorkRestrictionLevels();

            return Ok(result);
        }
    }
}
