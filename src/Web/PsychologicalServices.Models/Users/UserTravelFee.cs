using PsychologicalServices.Models.Cities;
using System;

namespace PsychologicalServices.Models.Users
{
    public class UserTravelFee
    {
        public User User { get; set; }

        public City City { get; set; }

        public int Amount { get; set; }
    }
}
