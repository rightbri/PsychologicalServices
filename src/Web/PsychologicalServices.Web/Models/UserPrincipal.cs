using PsychologicalServices.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace PsychologicalServices.Web.Models
{
    public class UserPrincipal : IPrincipal
    {
        private readonly User _user = null;

        public UserPrincipal(
            User user
        )
        {
            _user = user;
        }

        public IIdentity Identity
        {
            get
            {
                return new GenericIdentity(_user.Email);
            }
        }

        public bool IsInRole(string role)
        {
            return _user.Roles.Any(rl => rl.Name.Equals(role, StringComparison.OrdinalIgnoreCase));
        }

        public User Info
        {
            get { return _user; }
        }
    }
}