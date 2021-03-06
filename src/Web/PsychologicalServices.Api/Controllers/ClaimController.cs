﻿using PsychologicalServices.Api.Infrastructure.Filters;
using PsychologicalServices.Models.Claims;
using PsychologicalServices.Models.Rights;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/claim")]
    public class ClaimController : ApiController
    {
        private readonly IClaimService _claimService = null;

        public ClaimController(
            IClaimService claimService
        )
        {
            _claimService = claimService;
        }

        [RightAuthorize(StaticRights.ViewClaim)]
        [Route("{id}/references")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<ClaimReference>))]
        public IHttpActionResult References(int id)
        {
            var references = _claimService.GetClaimReferences(id);

            return Ok(references);
        }
    }
}
