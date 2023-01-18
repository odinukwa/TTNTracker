

using System.Text.Json.Serialization;

namespace TTN_Tracker.Features.Dto
{
    public class UserDeviceGetDto
    {
        public string DeviceId { get; set; }
        public string AppEui { get; set; }
        public string DevEui { get; set; }
        public string DeviceName { get; set; }
        // public string DeviceDescription { get; set; }
    }
}