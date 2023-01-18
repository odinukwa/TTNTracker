using System;
using System.Collections.Generic;

#nullable disable

namespace TTN_DDOI.Model
{
    public partial class LorawanVersion
    {
        public LorawanVersion()
        {
            Devices = new HashSet<Device>();
        }

        public int Id { get; set; }
        public string LorawanVersionCode { get; set; }
        public string LorawanVersionName { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<Device> Devices { get; set; }
    }
}
