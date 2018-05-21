using log4net;
using PsychologicalServices.Models.Common;
using PsychologicalServices.Models.Documents;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository = null;
        private readonly IUserValidator _userValidator = null;
        private readonly IDocumentRepository _documentRepository = null;
        private readonly ILog _log = null;

        public UserService(
            IUserRepository userRepository,
            IUserValidator userValidator,
            IDocumentRepository documentRepository,
            ILog log
        )
        {
            _userRepository = userRepository;
            _userValidator = userValidator;
            _documentRepository = documentRepository;
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

        public SaveResult<Document> SaveUserSpinner(int userId, int? documentId)
        {
            var result = new SaveResult<Document>();

            try
            {
                var validation = new Common.Validation.ValidationResult
                {
                    ValidationErrors = new List<Common.Validation.IValidationError>(),
                };

                var user = _userRepository.GetUserById(userId);

                if (null == user)
                {
                    validation.ValidationErrors.Add(
                        new Common.Validation.ValidationError { PropertyName = "UserId", Message = "User does not exist" }
                    );
                }

                if (documentId.HasValue)
                {
                    var documentExists = _documentRepository.DocumentExists(documentId.Value);

                    if (!documentExists)
                    {
                        validation.ValidationErrors.Add(
                            new Common.Validation.ValidationError { PropertyName = "DocumentId", Message = "Document does not exist" }
                        );
                    }
                }
                
                result.ValidationResult = validation;

                result.ValidationResult.IsValid = !result.ValidationResult.ValidationErrors.Any();

                if (result.ValidationResult.IsValid)
                {
                    _userRepository.SaveUserSpinner(userId, documentId);

                    result.Item = documentId.HasValue ? _documentRepository.GetDocument(documentId.Value) : null;

                    result.IsSaved = true;
                }
            }
            catch (Exception ex)
            {
                _log.Error("SaveUserSpinner", ex);
                result.IsError = true;
                result.ErrorDetails = ex.Message;
            }

            return result;
        }

        public Document GetSpinnerForUser(int userId)
        {
            var spinner = _userRepository.GetSpinnerForUser(userId);

            return spinner;
        }
    }
}
