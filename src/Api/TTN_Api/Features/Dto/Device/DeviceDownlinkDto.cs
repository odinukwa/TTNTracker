
using System;

namespace TTN_Tracker.Features.Dto
{
    public class DeviceDownlinkDto
    {
        public long id { get; set; }
        public string deviceId { get; set; }
        public string deviceName { get; set; }
        public string DevEui { get; set; }
        public string appEui { get; set; }
        public string devAddr { get; set; }
        public int? fCnt { get; set; }
        public int? fPort { get; set; }
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
        public int altitude { get; set; }
        public decimal hdop { get; set; }
        public int sats { get; set; }
        public DateTime receivedAt { get; set; }


    }
}