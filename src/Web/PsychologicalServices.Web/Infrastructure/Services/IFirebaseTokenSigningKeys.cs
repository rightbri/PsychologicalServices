using Microsoft.IdentityModel.Tokens;
using System;

namespace PsychologicalServices.Web.Infrastructure.Services
{
    public interface IFirebaseTokenSigningKeys
    {
        SecurityKey[] GetSecurityKeys();
    }
}
