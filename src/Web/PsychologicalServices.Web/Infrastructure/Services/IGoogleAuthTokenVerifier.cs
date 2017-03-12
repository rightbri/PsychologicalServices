using System;
using System.Security.Claims;

namespace PsychologicalServices.Web.Infrastructure.Services
{
    public interface IGoogleAuthTokenVerifier
    {
        bool Verify(string authToken, out ClaimsPrincipal principal);
    }
}
