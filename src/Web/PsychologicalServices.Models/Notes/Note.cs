using PsychologicalServices.Models.Users;
using System;

namespace PsychologicalServices.Models.Notes
{
    public class Note
    {
        public int NoteId { get; set; }

        public string NoteText { get; set; }

        public int CreateUserId { get; set; }

        public DateTime CreateDate { get; set; }

        public int UpdateUserId { get; set; }

        public DateTime UpdateDate { get; set; }

        public bool Deleted { get; set; }

        public User CreateUser { get; set; }

        public User UpdateUser { get; set; }
    }
}
