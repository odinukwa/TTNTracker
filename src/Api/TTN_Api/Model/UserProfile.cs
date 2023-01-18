using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace TTN_DDOI.Model
{
    public partial class UserProfile
    {
        public UserProfile()
        {
            UserDevices = new HashSet<UserDevice>();
        }

        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime? DateCreated { get; set; }

        [ForeignKey("Id")]
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<UserDevice> UserDevices { get; set; }
    }
}
