using System;
using System.Collections.Generic;

namespace PsychologicalServices.Api.Infrastructure.Services
{
    public interface ICorsAllowedOrigins
    {
        List<string> AllowedOrigins { get; }
    }
}
