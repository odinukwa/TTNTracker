using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TTN_Tracker.Features.Dto.EndDeviceRegistry
{
    public class EndDeviceDto
    {
        public End_Device end_device { get; set; }
        public Field_Mask field_mask { get; set; } = new Field_Mask();
    }

    public class End_Device
    {
        //Common
        public Ids ids { get; set; }
        //EndDeviceRegistry
        public string join_server_address { get; set; }
        public string network_server_address { get; set; }//JsEndDeviceRegistry
        public string application_server_address { get; set; }//JsEndDeviceRegistry
        public string name { get; set; }
        public string description { get; set; }
    }

    public class Ids
    {
        public string device_id { get; set; }
        public string dev_eui { get; set; }
        public string join_eui { get; set; }
    }

    public class Field_Mask
    {
        public string[] paths { get; set; } = new string[] {"join_server_address",
         "network_server_address",
         "application_server_address",
         "ids.dev_eui",
         "ids.join_eui",
         "name",
         "description"};
    }


}

namespace TTN_Tracker.Features.Dto.NsEndDeviceRegistry
{
    public class EndDeviceDto
    {
        public End_Device end_device { get; set; }
        public Field_Mask field_mask { get; set; } = new Field_Mask();
    }

    public class End_Device
    {

        public bool multicast { get; set; }
        public bool supports_join { get; set; } = true;
        public string lorawan_version { get; set; }
        public Ids ids { get; set; }
        //NsEndDeviceRegistry
        public Mac_Settings mac_settings { get; set; }
        public bool supports_class_c { get; set; }
        public bool supports_class_b { get; set; }
        public string lorawan_phy_version { get; set; }
        public string frequency_plan_id { get; set; }
    }

    public class Ids
    {
        public string device_id { get; set; }
        public string dev_eui { get; set; }
        public string join_eui { get; set; }
    }

    public class Mac_Settings
    {
        public bool supports_32_bit_f_cnt { get; set; }
    }

    public class Field_Mask
    {
        public string[] paths { get; set; } = new string[] {"multicast",
            "supports_join",
            "lorawan_version",
            "ids.device_id",
            "ids.dev_eui",
            "ids.join_eui",
            "mac_settings.supports_32_bit_f_cnt",
            "supports_class_c",
            "supports_class_b",
            "lorawan_phy_version",
            "frequency_plan_id"};
    }

}
namespace TTN_Tracker.Features.Dto.AsEndDeviceRegistry
{
    public class EndDeviceDto
    {
        public End_Device end_device { get; set; }
        public Field_Mask field_mask { get; set; } = new Field_Mask();
    }

    public class End_Device
    {
        //Common
        public Ids ids { get; set; }
    }
    public class Ids
    {
        public string device_id { get; set; }
        public string dev_eui { get; set; }
        public string join_eui { get; set; }
    }

    public class Field_Mask
    {
        public string[] paths { get; set; } = new string[] {"ids.device_id",
            "ids.dev_eui",
            "ids.join_eui"};
    }
}

namespace TTN_Tracker.Features.Dto.JsEndDeviceRegistry
{
    public class EndDeviceDto
    {
        public End_Device end_device { get; set; }
        public Field_Mask field_mask { get; set; } = new Field_Mask();
    }

    public class End_Device
    {
        //Common
        public Ids ids { get; set; }
        //EndDeviceRegistry
        public string network_server_address { get; set; }//JsEndDeviceRegistry
        public string application_server_address { get; set; }//JsEndDeviceRegistry
        public string network_server_kek_label { get; set; }
        public string application_server_kek_label { get; set; }
        public string application_server_id { get; set; }
        public object net_id { get; set; }
        public Root_Keys root_keys { get; set; }
    }

    public class Ids
    {
        public string device_id { get; set; }
        public string dev_eui { get; set; }
        public string join_eui { get; set; }
    }
    public class Root_Keys
    {
        public App_Key app_key { get; set; }
    }

    public class App_Key
    {
        public string key { get; set; }
    }
    public class Field_Mask
    {
        public string[] paths { get; set; } = new string[] {"network_server_address",
            "application_server_address",
            "ids.device_id",
            "ids.dev_eui",
            "ids.join_eui",
            "network_server_kek_label",
            "application_server_kek_label",
            "application_server_id",
            "net_id",
            "root_keys.app_key.key"};
    }

}
namespace TTN_Tracker.Features.Dto
{
    public class Errorobject
    {
        public int code { get; set; }
        public string message { get; set; }
        public Detail[] details { get; set; }
    }

    public class Detail
    {
        public string type { get; set; }
        public string _namespace { get; set; }
        public string name { get; set; }
        public string message_format { get; set; }
        public string correlation_id { get; set; }
        public int code { get; set; }
    }
}