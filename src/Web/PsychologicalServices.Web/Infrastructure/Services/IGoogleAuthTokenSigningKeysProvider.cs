using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Web.Infrastructure.Services
{
    public interface IGoogleAuthTokenSigningKeysProvider
    {
        IEnumerable<SecurityKey> GetSecurityKeys();

        IEnumerable<SecurityKey> GetSecurityKeys(DateTime cacheUntilTime);
    }
}
