using PsychologicalServices.Models.Schedule;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Users
{
    public interface IUserRepository
    {
        User GetUserById(int id);

        User GetUserByEmail(string email);

        IEnumerable<User> GetUsers(UserSearchCriteria criteria);

        IEnumerable<User> GetDocListWriters(int? companyId = null);

        IEnumerable<User> GetNotesWriters(int? companyId = null);

        IEnumerable<User> GetPsychometrists(int? companyId = null);

        IEnumerable<User> GetPsychologists(int? companyId = null);

        IEnumerable<User> GetPsychometristSchedules(PsychometristScheduleSearchCriteria criteria);

        int SaveUser(User user);
    }
}
