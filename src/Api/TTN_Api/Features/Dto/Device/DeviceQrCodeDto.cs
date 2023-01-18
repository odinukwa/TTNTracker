
using System.Text.Json.Serialization;

namespace TTN_Tracker.Features.Dto
{
    public class DeviceQrCodeDto
    {
        public string AppEui { get; set; }
        public string DevEui { get; set; }
        public string AppKey { get; set; }
        public string LorawanVersion { get; set; }
        public bool? SupportsClassB { get; set; }
        public bool? SupportsClassC { get; set; }
        [JsonIgnore]
        public int UserId { get; set; }
        [JsonIgnore]
        public string QrcodePath { get; set; }
    }
}