using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Serilog;
using TTN_DDOI.Model;
using TTN_Tracker.Data.Http;
using TTN_Tracker.Features.Dto;
using TTN_Tracker.MiddleWare;
using ZXing;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace TTN_Tracker.Data
{
    public class TTNIntegrationCommands : ITTNIntegrationCommands
    {
        private readonly TTNTrackerDbContext _context;
        private ITTNCustomClient _customClient;
        private readonly ApplicationSettings _appSettings;
        IWebHostEnvironment _hostingEnvironment;
        public TTNIntegrationCommands(TTNTrackerDbContext context, ITTNCustomClient customClient,
        IOptions<ApplicationSettings> appSettings,
        IWebHostEnvironment hostingEnvironment
        )
        {
            _context = context;
            _customClient = customClient;
            _appSettings = appSettings.Value;
            _hostingEnvironment = hostingEnvironment;
        }
        public async Task<ApiResponse> PostUplinkMessage(UplinkMessageCreateDto data)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                var appId = data.end_device_ids.application_ids.application_id;
                var devId = data.end_device_ids.device_id;
                var port = data.uplink_message.decoded_payload.port;
                if (data.uplink_message.decoded_payload.latitude == 0 && data.uplink_message.decoded_payload.longitude == 0)
                {
                    response.code = 4;
                    response.message = "No geolocation information in uplink message ";
                    Log.Error($"No geolocation information in uplink message for device ID {devId} of App ID {appId}.");
                    return response;
                }
                //check if device exist 
                var devExist = await _context.Devices.AnyAsync(e => e.DeviceId == devId);
                if (devExist)
                {
                    DeviceUplinkMsg uplinkMsg = new DeviceUplinkMsg()
                    {
                        Altitude = data.uplink_message.decoded_payload.altitude,
                        AppId = appId,
                        DevAddr = data.end_device_ids.dev_addr,
                        DevEui = data.end_device_ids.dev_eui,
                        DeviceId = data.end_device_ids.device_id,
                        ConsumedAirtime = data.uplink_message.consumed_airtime,
                        SessionKeyId = data.uplink_message.session_key_id,
                        FPort = data.uplink_message.f_port,
                        FCnt = data.uplink_message.f_cnt,
                        FrmPayload = data.uplink_message.frm_payload,
                        Latitude = data.uplink_message.decoded_payload.latitude,
                        Longitude = data.uplink_message.decoded_payload.longitude,
                        Port = data.uplink_message.decoded_payload.port,
                        Sats = data.uplink_message.decoded_payload.sats,
                        Hdop = data.uplink_message.decoded_payload.hdop,
                        DateCreated = DateTime.UtcNow.ToCentralTime(),
                        UserId = await GetDeviceUserId(data.end_device_ids.device_id),
                        ReceivedAt = DateTime.Parse(data.uplink_message.received_at),
                        JoinEui = data.end_device_ids.join_eui,


                    };

                    _context.DeviceUplinkMsgs.Add(uplinkMsg);
                    var resp = await _context.SaveChangesAsync();
                    if (resp > 0)
                    {
                        response.code = 0;
                        response.message = "Success";
                    }
                    else
                    {
                        response.code = 1;
                        response.message = "Unable to Post Uplink Data";
                        Log.Error("Unable to Post Uplink Data: {@data}", uplinkMsg);
                    }
                }
                else
                {
                    response.code = 2;
                    response.message = $"Device ID {devId} of App ID {appId} does not exist";
                    Log.Error($"Device ID {devId} of App ID {appId} does not exist");
                }
            }
            catch (Exception ex)
            {
                response.code = 2;
                response.message = $"Error Posting Uplink Data";
                Log.Error("Error Posting Uplink Data: {@data}", ex.Message);
            }
            return response;
        }

        private async Task<int> GetDeviceUserId(string deviceId)
        {
            var devUser = await _context.UserDevices.FirstOrDefaultAsync(d => d.DeviceId == deviceId);
            return devUser != null ? devUser.UserId : 0;
        }

        public async Task<ApiResponse> CreateDeviceQrCode(DeviceQrCodeDto data)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                //check if device exist 
                var devExist = await _context.DevicesQrcode.AnyAsync(e => e.DevEui == data.DevEui);
                if (!devExist)
                {
                    data.QrcodePath = GenerateQrCode(data.DevEui);

                    DeviceQrcode qrObj = new DeviceQrcode()
                    {
                        DevEui = data.DevEui,
                        AppEui = data.AppEui,
                        AppKey = data.AppKey,
                        SupportsClassB = data.SupportsClassB,
                        SupportsClassC = data.SupportsClassC,
                        LorawanVersion = data.LorawanVersion,
                        QrcodePath = data.QrcodePath,
                        DateCreated = DateTime.UtcNow.ToCentralTime(),
                        UserId = data.UserId
                    };

                    _context.DevicesQrcode.Add(qrObj);
                    var resp = await _context.SaveChangesAsync();
                    if (resp > 0)
                    {
                        response.code = 0;
                        response.message = "Success";
                        response.status = true;
                        response.data = new
                        {
                            qrCodePath = data.QrcodePath
                        };
                    }
                    else
                    {
                        response.code = 1;
                        response.message = "Unable to Create Device Qr Code";
                        Log.Error("Unable to Create Device Qr Code: {@data}", data);
                    }
                }
                else
                {
                    response.code = 2;
                    response.message = $"Device EUI {data.DevEui} Qrcode already;";
                    Log.Error($"Device EUI {data.DevEui} Qrcode already");
                }
            }
            catch (Exception ex)
            {
                response.code = 2;
                response.message = $"Error Posting Uplink Data";
                Log.Error("Error Posting Uplink Data: {@data}", ex.Message);
            }
            return response;
        }

        public async Task<ApiResponse> DeleteDeviceQrCode(string devEui)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                //check if device exist 
                var devRecord = await _context.DevicesQrcode.FirstOrDefaultAsync(e => e.DevEui == devEui);
                if (devRecord != null)
                {
                    _context.DevicesQrcode.Remove(devRecord);

                    var resp = await _context.SaveChangesAsync();
                    if (resp > 0)
                    {
                        response.code = 0;
                        response.message = "Success";
                        response.status = true;
                    }
                    else
                    {
                        response.code = 1;
                        response.message = "Unable to Delete Device Qr Code";
                        Log.Error("Unable to Create Delete Qr Code: {@data}", devEui);
                    }
                }
                else
                {
                    response.code = 2;
                    response.message = $"Device EUI {devEui} does not exist;";
                    Log.Error($"Device EUI {devEui} does not exist");
                }
            }
            catch (Exception ex)
            {
                response.code = 2;
                response.message = $"Error Deleting QR Code Device";
                Log.Error("Error Deleting QR Code Device: {@data}", ex.Message);
            }
            return response;
        }

        private string GenerateQrCode(string qrcodeText)
        {
            string folderPath = _hostingEnvironment.WebRootPath + "\\DevicesQrImages\\";
            var barcodeWriter = new BarcodeWriter();
            barcodeWriter.Format = BarcodeFormat.QR_CODE;
            var result = barcodeWriter.Write(qrcodeText);

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            string barcodePath = _hostingEnvironment.WebRootPath + "\\DevicesQrImages\\" + $"{qrcodeText}.jpg";
            var barcodeBitmap = new Bitmap(result);

            using (MemoryStream memory = new MemoryStream())
            {
                using (FileStream fs = new FileStream(barcodePath, FileMode.Create, FileAccess.ReadWrite))
                {
                    barcodeBitmap.Save(memory, ImageFormat.Jpeg);
                    byte[] bytes = memory.ToArray();
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
            return barcodePath;

        }

        public async Task<ApiResponse> RegisterUserDevice(UserDeviceCreateDto data)
        {
            //1. validate devid
            //2. validate dev_eui
            //3. save device into device table
            //4. call ttn endpoint to save device
            //5. save device to user device table
            ApiResponse response = new ApiResponse();
            if (await DeviceIdExist(data.DeviceId))
            {
                response.code = 1;
                response.message = $"Device with ID {data.DeviceId} already exist.";
            }

            if (await DeviceEUIExist(data.DevEui))
            {
                response.code = 1;
                response.message = $"Device with EUI {data.DevEui} already exist.";
            }

            Device deviceObj = SetDeviceObjectLocal(data);
            _context.Devices.Add(deviceObj);
            var resp = await _context.SaveChangesAsync();
            if (resp > 0)
            {
                // call TTN endpoint
                var devObj = SetDeviceObject(data);
                var devResult = await _customClient.CreateDeviceAsync(devObj);
                if (devResult.status)
                {
                    var nsObj = SetNsDeviceObject(data);

                    var asObj = SetAsDeviceObject(data);

                    var jsObj = SetJsDeviceObject(data);
                    // var task1 = await _customClient.UpdateNsDeviceAsync(nsObj);
                    // var task2 = await _customClient.UpdateAsDeviceAsync(asObj);
                    // var task3 = await _customClient.UpdateJsDeviceAsync(jsObj);
                    var task1 = _customClient.UpdateNsDeviceAsync(nsObj);
                    var task2 = _customClient.UpdateAsDeviceAsync(asObj);
                    var task3 = _customClient.UpdateJsDeviceAsync(jsObj);
                    await Task.WhenAll(task1, task2, task3);

                    UserDevice userDeviceObj = SetUserDeviceObjectLocal(data);
                    _context.UserDevices.Add(userDeviceObj);
                    var resp2 = await _context.SaveChangesAsync();
                    if (resp2 > 0)
                    {
                        response.code = 0;
                        response.message = "Success";
                        response.status = true;
                    }
                    else
                    {
                        response.code = 1;
                        response.message = "Failure creating user device";
                    }

                }
                else
                {
                    //unable to create device on ttn network
                    response.code = devResult.code;
                    response.message = devResult.message;
                    //remove device
                    _context.Devices.Remove(deviceObj);
                    await _context.SaveChangesAsync();
                }

            }

            return response;

        }

        private UserDevice SetUserDeviceObjectLocal(UserDeviceCreateDto data)
        {
            return new UserDevice()
            {
                UserId = data.UserId,
                DeviceId = data.DeviceId,

            };
        }

        private Device SetDeviceObjectLocal(UserDeviceCreateDto data)
        {
            return new Device()
            {
                AppEui = data.AppEui,
                AppId = _appSettings.App_Id,
                AppKey = data.AppKey,
                ApplicationServerAddress = data.ApplicationServerAddress,
                JoinServerAddress = data.JoinServerAddress,
                NetworkServerAddress = data.NetworkServerAddress,
                DevEui = data.DevEui,
                DeviceId = data.DeviceId,
                DeviceDescription = data.DeviceDescription,
                DeviceName = data.DeviceName,
                DateCreated = DateTime.UtcNow.ToUniversalTime(),
                DateLastUpdated = DateTime.Now.ToUniversalTime(),
                SupportsClassB = data.SupportsClassB,
                SupportsClassC = data.SupportsClassC,
                FrequencyPlanId = data.FrequencyPlanId,
                LorawanVersion = data.LorawanVersion,
                LorawanPhyVersion = GetLorawanPhyVersion(data.LorawanVersion),
                Status = "Active"
            };
        }

        private string GetLorawanPhyVersion(string lorawanVersion)
        {
            return lorawanVersion.Replace("MAC", "PHY");
        }

        private async Task<bool> DeviceIdExist(string devId)
        {
            var appExist = await _context.Devices.AnyAsync(d => d.DeviceId == devId);
            return appExist;
        }

        // private async Task<bool> AppEUIExist(string appEUI)
        // {
        //     var appExist = await _context.Devices.AnyAsync(d => d.DeviceId == devId);
        //     return appExist;
        // }

        private async Task<bool> DeviceEUIExist(string devEUI)
        {
            var devExist = await _context.Devices.AnyAsync(d => d.DevEui == devEUI);
            return devExist;
        }
        Features.Dto.EndDeviceRegistry.EndDeviceDto SetDeviceObject(UserDeviceCreateDto data)
        {
            return new Features.Dto.EndDeviceRegistry.EndDeviceDto()
            {
                end_device = new Features.Dto.EndDeviceRegistry.End_Device()
                {
                    ids = new Features.Dto.EndDeviceRegistry.Ids()
                    {
                        device_id = data.DeviceId,
                        dev_eui = data.DevEui,
                        join_eui = data.AppEui
                    },
                    join_server_address = data.JoinServerAddress,
                    network_server_address = data.NetworkServerAddress,
                    application_server_address = data.ApplicationServerAddress,
                    name = data.DeviceName,
                    description = data.DeviceDescription,
                }
            };


        }

        Features.Dto.NsEndDeviceRegistry.EndDeviceDto SetNsDeviceObject(UserDeviceCreateDto data)
        {
            return new Features.Dto.NsEndDeviceRegistry.EndDeviceDto()
            {
                end_device = new Features.Dto.NsEndDeviceRegistry.End_Device()
                {
                    multicast = false,
                    supports_join = true,
                    lorawan_version = data.LorawanVersion, // "MAC_V1_0",
                    ids = new Features.Dto.NsEndDeviceRegistry.Ids()
                    {
                        device_id = data.DeviceId,
                        dev_eui = data.DevEui,
                        join_eui = data.AppEui
                    },
                    mac_settings = new Features.Dto.NsEndDeviceRegistry.Mac_Settings()
                    {
                        supports_32_bit_f_cnt = true
                    },
                    supports_class_b = false,
                    supports_class_c = false,
                    lorawan_phy_version = GetLorawanPhyVersion(data.LorawanVersion), // "PHY_V1_0",
                    frequency_plan_id = data.FrequencyPlanId,
                    // "EU_863_870_TTN"
                }
            };


        }
        Features.Dto.AsEndDeviceRegistry.EndDeviceDto SetAsDeviceObject(UserDeviceCreateDto data)
        {
            return new Features.Dto.AsEndDeviceRegistry.EndDeviceDto()
            {
                end_device = new Features.Dto.AsEndDeviceRegistry.End_Device()
                {
                    ids = new Features.Dto.AsEndDeviceRegistry.Ids()
                    {
                        device_id = data.DeviceId,
                        dev_eui = data.DevEui,
                        join_eui = data.AppEui
                    }
                }
            };
        }
        Features.Dto.JsEndDeviceRegistry.EndDeviceDto SetJsDeviceObject(UserDeviceCreateDto data)
        {
            return new Features.Dto.JsEndDeviceRegistry.EndDeviceDto()
            {
                end_device = new Features.Dto.JsEndDeviceRegistry.End_Device()
                {
                    ids = new Features.Dto.JsEndDeviceRegistry.Ids()
                    {
                        device_id = data.DeviceId,
                        dev_eui = data.DevEui,
                        join_eui = data.AppEui
                    },
                    network_server_address = data.NetworkServerAddress, // "eu1.cloud.thethings.network",
                    application_server_address = data.ApplicationServerAddress, // "eu1.cloud.thethings.network",
                    network_server_kek_label = "",
                    application_server_kek_label = "",
                    application_server_id = "",
                    net_id = null,
                    root_keys = new Features.Dto.JsEndDeviceRegistry.Root_Keys()
                    {
                        app_key = new Features.Dto.JsEndDeviceRegistry.App_Key()
                        {
                            key = data.AppKey// "D3877D96E78DBB7C7F2DE2790010A202"
                        }
                    }
                }
            };


        }

    }
}