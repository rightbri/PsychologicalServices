using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Users
{
    public interface IUserService
    {
        User GetUserById(int id);

        IEnumerable<User> GetPsychometrists(int? companyId = null);

        IEnumerable<User> GetPsychologists(int? companyId = null);

        SaveResult<User> SaveUser(User user);
    }
}
