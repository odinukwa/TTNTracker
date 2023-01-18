using System;
using System.Collections.Generic;

#nullable disable

namespace TTN_DDOI.Model
{
    public partial class UserDevice
    {
        public UserDevice()
        {
            DeviceUplinkMsgs = new HashSet<DeviceUplinkMsg>();
        }

        public int UserId { get; set; }
        public string DeviceId { get; set; }

        public virtual Device Device { get; set; }
        public virtual UserProfile User { get; set; }
        public virtual ICollection<DeviceUplinkMsg> DeviceUplinkMsgs { get; set; }
    }
}
