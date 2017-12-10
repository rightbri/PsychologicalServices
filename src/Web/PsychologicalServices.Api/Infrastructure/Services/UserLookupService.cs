using System;
using PsychologicalServices.Models.Users;
using PsychologicalServices.Models.Common.Utility;

namespace PsychologicalServices.Api.Infrastructure.Services
{
    public class UserLookupService : IUserLookupService
    {
        private readonly IUserService _userService = null;
        private readonly ICacheService _cacheService = null;
        private readonly IDate _date = null;

        public UserLookupService(
            IUserService userService,
            ICacheService cacheService,
            IDate date
        )
        {
            _userService = userService;
            _cacheService = cacheService;
            _date = date;
        }

        public User GetUserByEmail(string email)
        {
            return _cacheService.Get(
                email,
                () => _userService.GetUserByEmail(email),
                _date.UtcNow.AddMinutes(10).DateTime
            );
        }
    }
}