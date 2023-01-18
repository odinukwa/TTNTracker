

using System;

namespace TTN_Tracker.Features.Dto
{
    public class UserProfileGetDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FUllName { get { return $"{LastName} {FirstName}"; } }
        public DateTime? DateCreated { get; set; }
        public DateTime? LastDateUpdated { get; set; }
    }
}