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

        public UserService(
            IUserRepository userRepository,
            IUserValidator userValidator
        )
        {
            _userRepository = userRepository;
            _userValidator = userValidator;
        }

        public User GetUserById(int id)
        {
            var user = _userRepository.GetUserById(id);

            return user;
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
                //TODO: log error
                result.IsError = true;
                result.ErrorDetails = ex.Message;
            }

            return result;
        }
    }
}
