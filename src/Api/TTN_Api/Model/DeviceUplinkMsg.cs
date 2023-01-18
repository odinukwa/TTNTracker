using System;
using System.Collections.Generic;

#nullable disable

namespace TTN_DDOI.Model
{
    public partial class DeviceUplinkMsg
    {
        public long Id { get; set; }
        public string AppId { get; set; }
        public int UserId { get; set; }
        public string DeviceId { get; set; }
        public string DevEui { get; set; }
        public string JoinEui { get; set; }
        public string DevAddr { get; set; }
        public string SessionKeyId { get; set; }
        public int? FPort { get; set; }
        public int? FCnt { get; set; }
        public string FrmPayload { get; set; }
        public int? Altitude { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Hdop { get; set; }
        public int? Port { get; set; }
        public int? Sats { get; set; }
        public DateTime? ReceivedAt { get; set; }
        public string ConsumedAirtime { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual Application App { get; set; }
        public virtual UserDevice UserDevice { get; set; }
    }
}
