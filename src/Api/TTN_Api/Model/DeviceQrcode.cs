using System;
using System.Collections.Generic;

#nullable disable

namespace TTN_DDOI.Model
{
    public partial class DeviceQrcode
    {
        public DeviceQrcode()
        {
        }

        public int Id { get; set; }
        public string AppEui { get; set; }
        public string DevEui { get; set; }
        public string LorawanVersion { get; set; }
        public bool? SupportsClassB { get; set; }
        public bool? SupportsClassC { get; set; }
        public string AppKey { get; set; }
        public string QrcodePath { get; set; }
        public int UserId { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
