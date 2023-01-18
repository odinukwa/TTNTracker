using System;
using System.Collections.Generic;

#nullable disable

namespace TTN_DDOI.Model
{
    public partial class Device
    {
        public Device()
        {
            UserDevices = new HashSet<UserDevice>();
        }

        public int Id { get; set; }
        public string AppId { get; set; }
        public string DeviceId { get; set; }
        public string AppEui { get; set; }
        public string DevEui { get; set; }
        public string DeviceName { get; set; }
        public string DeviceDescription { get; set; }
        public string LorawanVersion { get; set; }
        public string LorawanPhyVersion { get; set; }
        public string NetworkServerAddress { get; set; }
        public string ApplicationServerAddress { get; set; }
        public string JoinServerAddress { get; set; }
        public string FrequencyPlanId { get; set; }
        public bool? SupportsClassB { get; set; }
        public bool? SupportsClassC { get; set; }
        public string AppKey { get; set; }
        public string Status { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateLastUpdated { get; set; }

        public virtual Application App { get; set; }
        public virtual FrequencyPlan FrequencyPlan { get; set; }
        public virtual LorawanVersion LorawanVersionNavigation { get; set; }
        public virtual ICollection<UserDevice> UserDevices { get; set; }
    }
}
