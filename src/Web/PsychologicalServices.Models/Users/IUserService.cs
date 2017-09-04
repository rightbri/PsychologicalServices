using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Users
{
    public interface IUserService
    {
        User GetUserByEmail(string email);

        User GetUserById(int id);

        IEnumerable<User> GetUsers(UserSearchCriteria criteria);

        IEnumerable<User> GetUsersWithUnavailability(UnavailabilitySearchCriteria criteria);

        IEnumerable<User> GetPsychometrists(int? companyId = null);

        IEnumerable<User> GetPsychologists(int? companyId = null);

        IEnumerable<User> GetDocListWriters(int? companyId = null);

        IEnumerable<User> GetNotesWriters(int? companyId = null);

        SaveResult<User> SaveUser(User user);
    }
}
