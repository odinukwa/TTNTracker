

using System.Text.Json.Serialization;

namespace TTN_Tracker.Features.Dto
{
    public class UserDeviceCreateDto
    {
        public string DeviceId { get; set; }
        public string AppEui { get; set; }
        public string DevEui { get; set; }
        public string DeviceName { get; set; }
        public string DeviceDescription { get; set; }
        public string LorawanVersion { get; set; }
        //public string LorawanPhyVersion { get; set; }
        public string NetworkServerAddress { get; set; }
        public string ApplicationServerAddress { get; set; }
        public string JoinServerAddress { get; set; }
        public string FrequencyPlanId { get; set; }
        public bool? SupportsClassB { get; set; }
        public bool? SupportsClassC { get; set; }
        public string AppKey { get; set; }
        [JsonIgnore]
        public int UserId { get; set; }
        [JsonIgnore]
        public string AppId { get; set; }

    }
}