using PsychologicalServices.Models.Users;
using System;

namespace PsychologicalServices.Api.Infrastructure.Services
{
    public interface IUserLookupService
    {
        User GetUserByEmail(string email);
    }
}
