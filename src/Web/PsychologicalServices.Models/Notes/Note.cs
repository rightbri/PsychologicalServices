using PsychologicalServices.Models.Users;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Notes
{
    public class Note
    {
        public int NoteId { get; set; }

        public string NoteText { get; set; }

        public DateTimeOffset CreateDate { get; set; }

        public DateTimeOffset UpdateDate { get; set; }

        public User CreateUser { get; set; }

        public User UpdateUser { get; set; }

        public IEnumerable<User> Recipients { get; set; }
    }
}
