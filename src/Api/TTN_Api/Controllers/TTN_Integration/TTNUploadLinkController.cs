using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;
using TTN_Tracker.Data.Http;
using TTN_Tracker.Features.Commands;
using TTN_Tracker.Features.Dto;
using TTN_Tracker.Features.Dto.EndDeviceRegistry;

namespace TTN_Tracker.Controllers
{
    [ApiController]

    public class TTNUploadLinkController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ITTNCustomClient _customClient;

        public TTNUploadLinkController(IMediator mediator, ITTNCustomClient customClient)
        {
            _mediator = mediator;
            _customClient = customClient;
        }
        [HttpPost]
        [Route("api/v3/uplink-message")]
        public async Task<ActionResult> Post(object data)
        {
            try
            {
                Log.Information("Request: {@data}", data.ToString());
                var upData = JsonConvert.DeserializeObject<CreateUplinkMessageCommand>(data.ToString());

                string json = JsonConvert.SerializeObject(upData);
                Log.Information("Request1: {@data}", json);

                var result = await _mediator.Send(upData);

            }
            catch (Exception ex)
            {
                Log.Error("Error: {@data}", ex.Message);
            }
            return Ok();
        }

        [HttpGet]
        [Route("api/v3/device")]
        public async Task<ActionResult> Get()
        {
            //Log.Information("Request: {@data}", request.ToString());
            var result = await _customClient.GetDevice(null);
            return Ok(result.ToString());
        }


        // [HttpPost]
        // [Route("v3/device")]
        // public async Task<ActionResult> CreateDevice(EndDeviceDto data)
        // {
        //     Log.Information("Request: {@data}", data.ToString());
        //     //Task[] tasks = new Task[3];
        //     var result = await _customClient.CreateDeviceAsync(data);
        //     var nsObj = new Features.Dto.NsEndDeviceRegistry.EndDeviceDto()
        //     {
        //         end_device = new Features.Dto.NsEndDeviceRegistry.End_Device()
        //         {
        //             multicast = false,
        //             supports_join = true,
        //             lorawan_version = "MAC_V1_0",
        //             ids = new Features.Dto.NsEndDeviceRegistry.Ids()
        //             {
        //                 device_id = "grp1-dev4",
        //                 dev_eui = "70B3D50000000002",
        //                 join_eui = "500291883D94FEFF"
        //             },
        //             mac_settings = new Features.Dto.NsEndDeviceRegistry.Mac_Settings()
        //             {
        //                 supports_32_bit_f_cnt = true
        //             },
        //             supports_class_b = false,
        //             supports_class_c = false,
        //             lorawan_phy_version = "PHY_V1_0",
        //             frequency_plan_id = "EU_863_870_TTN"
        //         }
        //     };

        //     var asObj = new Features.Dto.AsEndDeviceRegistry.EndDeviceDto()
        //     {
        //         end_device = new Features.Dto.AsEndDeviceRegistry.End_Device()
        //         {
        //             ids = new Features.Dto.AsEndDeviceRegistry.Ids()
        //             {
        //                 device_id = "grp1-dev4",
        //                 dev_eui = "70B3D50000000002",
        //                 join_eui = "500291883D94FEFF"
        //             }
        //         }
        //     };

        //     var jsObj = new Features.Dto.JsEndDeviceRegistry.EndDeviceDto()
        //     {
        //         end_device = new Features.Dto.JsEndDeviceRegistry.End_Device()
        //         {
        //             ids = new Features.Dto.JsEndDeviceRegistry.Ids()
        //             {
        //                 device_id = "grp1-dev4",
        //                 dev_eui = "70B3D50000000002",
        //                 join_eui = "500291883D94FEFF"
        //             },
        //             network_server_address = "eu1.cloud.thethings.network",
        //             application_server_address = "eu1.cloud.thethings.network",
        //             network_server_kek_label = "",
        //             application_server_kek_label = "",
        //             application_server_id = "",
        //             net_id = null,
        //             root_keys = new Features.Dto.JsEndDeviceRegistry.Root_Keys()
        //             {
        //                 app_key = new Features.Dto.JsEndDeviceRegistry.App_Key()
        //                 {
        //                     key = "D3877D96E78DBB7C7F2DE2790010A202"
        //                 }
        //             }
        //         }
        //     };
        //     var task1 = await _customClient.UpdateNsDeviceAsync(nsObj);
        //     var task2 = await _customClient.UpdateAsDeviceAsync(asObj);
        //     var task3 = await _customClient.UpdateJsDeviceAsync(jsObj);
        //     //var result2 = await Task.WhenAll(task1, task2, task3);
        //     return Ok(new { endDevice = result, NS = task1, AS = task2, JS = task3 });

        //     // var task1 = _customClient.UpdateNsDeviceAsync(data);
        //     // var task2 = _customClient.UpdateAsDeviceAsync(data);
        //     // var task3 = _customClient.UpdateJsDeviceAsync(data);
        //     // var result2 = await Task.WhenAll(task1, task2, task3);
        //     // return Ok(new { result1 = result, result2 = result2 });
        // }

    }
}