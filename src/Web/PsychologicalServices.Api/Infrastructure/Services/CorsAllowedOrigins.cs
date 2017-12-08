using PsychologicalServices.Models.Common.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PsychologicalServices.Api.Infrastructure.Services
{
    public class CorsAllowedOrigins : ICorsAllowedOrigins
    {
        public CorsAllowedOrigins(
            IConfigurationService configurationService
        )
        {
            AllowedOrigins = configurationService.AppSettingValue("CorsAllowedOrigins").Split(',').ToList();
        }

        public List<string> AllowedOrigins
        {
            get; private set;
        }
    }
}