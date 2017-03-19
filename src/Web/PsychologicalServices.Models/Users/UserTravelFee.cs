using PsychologicalServices.Models.Addresses;
using System;

namespace PsychologicalServices.Models.Users
{
    public class UserTravelFee
    {
        public User User { get; set; }

        public Address Location { get; set; }

        public int Amount { get; set; }
    }
}
