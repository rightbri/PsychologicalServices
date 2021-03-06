﻿using PsychologicalServices.Api.Infrastructure.Filters;
using PsychologicalServices.Models.Common;
using PsychologicalServices.Models.Companies;
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
    [RoutePrefix("api/company")]
    public class CompanyController : ApiController
    {
        private readonly ICompanyService _companyService = null;

        public CompanyController(
            ICompanyService companyService
        )
        {
            _companyService = companyService;
        }

        [RightAuthorize(StaticRights.ViewCompany)]
        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(Company))]
        public IHttpActionResult Get(int id)
        {
            var company = _companyService.GetCompany(id);

            return Ok(company);
        }

        [RightAuthorize(StaticRights.ViewCompany)]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Company>))]
        public IHttpActionResult Get()
        {
            var companies = _companyService.GetCompanies();

            return Ok(companies);
        }

        [RightAuthorize(StaticRights.EditCompany)]
        [Route("save")]
        [HttpPut]
        [ResponseType(typeof(SaveResult<Company>))]
        public IHttpActionResult Save(Company company)
        {
            var result = _companyService.SaveCompany(company);

            return Ok(result);
        }
    }
}
