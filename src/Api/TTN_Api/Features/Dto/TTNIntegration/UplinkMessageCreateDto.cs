using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TTN_Tracker.Features.Dto
{

    public class UplinkMessageCreateDto
    {
        public string type { get; set; }
        public End_Device_Ids end_device_ids { get; set; }
        public string[] correlation_ids { get; set; }
        public string received_at { get; set; }
        public Uplink_Message uplink_message { get; set; }
    }

    public class End_Device_Ids
    {
        public string device_id { get; set; }
        public Application_Ids application_ids { get; set; }
        public string dev_eui { get; set; }
        public string join_eui { get; set; }
        public string dev_addr { get; set; }
    }

    public class Application_Ids
    {
        public string application_id { get; set; }
    }

    public class Uplink_Message
    {
        public string session_key_id { get; set; }
        public int f_port { get; set; }
        public int f_cnt { get; set; }
        public string frm_payload { get; set; }
        public Decoded_Payload decoded_payload { get; set; }
        public Rx_Metadata[] rx_metadata { get; set; }
        public Settings settings { get; set; }
        public string received_at { get; set; }
        public string consumed_airtime { get; set; }
    }

    public class Decoded_Payload
    {
        public int altitude { get; set; }
        public int[] bytes { get; set; }
        public decimal hdop { get; set; }
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
        public int port { get; set; }
        public int sats { get; set; }
    }

    public class Settings
    {
        public Data_Rate data_rate { get; set; }
        public int data_rate_index { get; set; }
        public string coding_rate { get; set; }
        public string frequency { get; set; }
    }

    public class Data_Rate
    {
        public Lora lora { get; set; }
    }

    public class Lora
    {
        public int bandwidth { get; set; }
        public int spreading_factor { get; set; }
    }

    public class Rx_Metadata
    {
        public Gateway_Ids gateway_ids { get; set; }
        public Packet_Broker packet_broker { get; set; }
        public DateTime time { get; set; }
        public int rssi { get; set; }
        public int channel_rssi { get; set; }
        public decimal snr { get; set; }
        public string uplink_token { get; set; }
    }

    public class Gateway_Ids
    {
        public string gateway_id { get; set; }
    }

    public class Packet_Broker
    {
        public string message_id { get; set; }
        public string forwarder_net_id { get; set; }
        public string forwarder_tenant_id { get; set; }
        public string forwarder_cluster_id { get; set; }
        public string home_network_net_id { get; set; }
        public string home_network_tenant_id { get; set; }
        public string home_network_cluster_id { get; set; }
        public Hop[] hops { get; set; }
    }

    public class Hop
    {
        public string received_at { get; set; }
        public string sender_address { get; set; }
        public string receiver_name { get; set; }
        public string receiver_agent { get; set; }
        public string sender_name { get; set; }
    }

}
