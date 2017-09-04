using log4net;
using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository = null;
        private readonly IUserValidator _userValidator = null;
        private readonly ILog _log = null;

        public UserService(
            IUserRepository userRepository,
            IUserValidator userValidator,
            ILog log
        )
        {
            _userRepository = userRepository;
            _userValidator = userValidator;
            _log = log;
        }

        public User GetUserByEmail(string email)
        {
            var user = _userRepository.GetUserByEmail(email);

            return user;
        }

        public User GetUserById(int id)
        {
            var user = _userRepository.GetUserById(id);

            return user;
        }

        public IEnumerable<User> GetUsers(UserSearchCriteria criteria)
        {
            var users = _userRepository.GetUsers(criteria);

            return users;
        }

        public IEnumerable<User> GetUsersWithUnavailability(UnavailabilitySearchCriteria criteria)
        {
            var users = _userRepository.GetUsersWithUnavailability(criteria);

            return users;
        }

        public IEnumerable<User> GetPsychometrists(int? companyId = null)
        {
            var psychometrists = _userRepository.GetPsychometrists(companyId);

            return psychometrists;
        }

        public IEnumerable<User> GetPsychologists(int? companyId = null)
        {
            var psychologists = _userRepository.GetPsychologists(companyId);

            return psychologists;
        }

        public IEnumerable<User> GetDocListWriters(int? companyId = null)
        {
            var docListWriters = _userRepository.GetDocListWriters(companyId);

            return docListWriters;
        }

        public IEnumerable<User> GetNotesWriters(int? companyId = null)
        {
            var notesWriters = _userRepository.GetNotesWriters(companyId);

            return notesWriters;
        }

        public SaveResult<User> SaveUser(User user)
        {
            var result = new SaveResult<User>();

            try
            {
                var validation = _userValidator.Validate(user);

                result.ValidationResult = validation;

                if (result.ValidationResult.IsValid)
                {
                    var id = _userRepository.SaveUser(user);

                    result.Item = _userRepository.GetUserById(id);
                    result.IsSaved = true;
                }
            }
            catch (Exception ex)
            {
                _log.Error("SaveUser", ex);
                result.IsError = true;
                result.ErrorDetails = ex.Message;
            }

            return result;
        }
    }
}
