using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTN_Tracker.MiddleWare;

namespace TTN_Tracker.Data.Http
{
    public interface ITTNCustomClient
    {
        Task<object> GetDevice(string devId);
        Task<ApiResponse> CreateDeviceAsync(Features.Dto.EndDeviceRegistry.EndDeviceDto endDeviceDto);
        Task<Features.Dto.NsEndDeviceRegistry.End_Device> UpdateNsDeviceAsync(Features.Dto.NsEndDeviceRegistry.EndDeviceDto endDeviceDto);
        Task<Features.Dto.AsEndDeviceRegistry.End_Device> UpdateAsDeviceAsync(Features.Dto.AsEndDeviceRegistry.EndDeviceDto endDeviceDto);
        Task<Features.Dto.JsEndDeviceRegistry.End_Device> UpdateJsDeviceAsync(Features.Dto.JsEndDeviceRegistry.EndDeviceDto endDeviceDto);
    }
}
