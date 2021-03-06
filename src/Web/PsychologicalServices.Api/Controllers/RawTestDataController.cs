﻿using PsychologicalServices.Api.Infrastructure.Filters;
using PsychologicalServices.Models.Common;
using PsychologicalServices.Models.RawTestData;
using PsychologicalServices.Models.Rights;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/rawtestdata")]
    public class RawTestDataController : ApiController
    {
        private IRawTestDataService _rawTestDataService = null;

        public RawTestDataController(
            IRawTestDataService rawTestDataService
        )
        {
            _rawTestDataService = rawTestDataService;
        }

        [RightAuthorize(StaticRights.ViewRawTestData)]
        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(RawTestData))]
        public IHttpActionResult Get(int id)
        {
            var rawTestData = _rawTestDataService.GetRawTestData(id);

            return Ok(rawTestData);
        }

        [RightAuthorize(StaticRights.SearchRawTestData)]
        [Route("search")]
        [HttpPost]
        [ResponseType(typeof(IEnumerable<RawTestData>))]
        public IHttpActionResult Search(RawTestDataSearchCriteria criteria)
        {
            var rawTestData = _rawTestDataService.GetRawTestDatas(criteria);

            return Ok(rawTestData);
        }

        [RightAuthorize(StaticRights.EditRawTestData)]
        [Route("save")]
        [HttpPut]
        [ResponseType(typeof(SaveResult<RawTestData>))]
        public IHttpActionResult Save(RawTestData rawTestData)
        {
            var result = _rawTestDataService.SaveRawTestData(rawTestData);

            return Ok(result);
        }
    }
}
