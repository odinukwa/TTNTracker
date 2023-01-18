using System;
using System.Collections.Generic;

#nullable disable

namespace TTN_DDOI.Model
{
    public partial class Application
    {
        public Application()
        {
            DeviceUplinkMsgs = new HashSet<DeviceUplinkMsg>();
            Devices = new HashSet<Device>();
        }

        public int Id { get; set; }
        public string AppId { get; set; }
        public string AppName { get; set; }
        public string AppDesc { get; set; }
        public string Status { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateLastUpdated { get; set; }

        public virtual ICollection<DeviceUplinkMsg> DeviceUplinkMsgs { get; set; }
        public virtual ICollection<Device> Devices { get; set; }
    }
}
